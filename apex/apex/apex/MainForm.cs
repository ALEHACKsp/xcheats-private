using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apex
{
    public partial class MainForm : Form
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = RandomString(50);
            RefreshList();
            timer1.Start();

            toolStripStatusLabel1.Text = "0x" + G.baseaddr.ToString("X");
        }

        private void SaveConfig()
        {
            G.s.Aimbot = checkBox1.Checked;
            G.s.SmoothAim = checkBox2.Checked;
            G.s.NoRecoil = checkBox3.Checked;
            
            G.s.RecoilDivider = Decimal.ToInt32(numericUpDown1.Value);
            G.s.SmoothDivider = Decimal.ToInt32(numericUpDown2.Value);
            G.s.FOV = Decimal.ToInt32(numericUpDown3.Value);

            G.s.Glow = checkBox4.Checked;
            G.s.Health = checkBox5.Checked;
            G.s.Shields = checkBox6.Checked;
        }

        private void LoadConfig()
        {
            checkBox1.Checked = G.s.Aimbot;
            checkBox2.Checked = G.s.SmoothAim;
            checkBox3.Checked = G.s.NoRecoil;

            numericUpDown1.Value = G.s.RecoilDivider;
            numericUpDown2.Value = G.s.SmoothDivider;
            numericUpDown3.Value = G.s.FOV;

            checkBox4.Checked = G.s.Glow;
            checkBox5.Checked = G.s.Health;
            checkBox6.Checked = G.s.Shields;

            button1.Text = "0x" + G.s.Aimkey.ToString("X");
        }

        private void RefreshList()
        {
            if (!Directory.Exists("configs"))
            {
                Directory.CreateDirectory("configs");
            }
            
            string[] files = Directory.GetFiles("configs");

            listBox1.Items.Clear();

            foreach (string file in files)
            {
                if (Path.GetExtension(file).ToLower() != ".json")
                    continue;
                
                string name = Path.GetFileNameWithoutExtension(file);
                listBox1.Items.Add(name);
            }
        }

        private string GetPath(string filename)
        {
            return "configs\\" + filename + ".json";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Settings));
            MemoryStream msObj = new MemoryStream();
            js.WriteObject(msObj, G.s);
            msObj.Position = 0;
            StreamReader sr = new StreamReader(msObj);

            string json = sr.ReadToEnd();

            string path = GetPath(listBox1.SelectedItem.ToString());
            File.WriteAllText(path, json);

            MessageBox.Show($"Location: {Path.GetFullPath(path)}", "Config was saved!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = GetPath(listBox1.SelectedItem.ToString());
            string json = File.ReadAllText(path);

            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                try
                {
                    DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(Settings));
                    Settings bsObj2 = (Settings)deserializer.ReadObject(ms);
                    G.s = bsObj2;
                } catch (Exception error)
                {
                    MessageBox.Show($"Failed parsing config. \n\n{error.ToString()}", "Fatal error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }

            LoadConfig();

            MessageBox.Show($"Location: {Path.GetFullPath(path)}", "Config was loaded!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("You must specify a name.", "Error when creating config", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string path = GetPath(textBox1.Text);
            
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }

            RefreshList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string path = GetPath(listBox1.SelectedItem.ToString());

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            RefreshList();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private void KeyThread()
        {
            while (true)
            {
                Thread.Sleep(10);
                for (int i = 0x01; i < 0xFE; i++)
                {
                    if (Convert.ToBoolean(Native.GetKeyState((Native.VirtualKeyStates)i) & 0x8000))
                    {
                        button1.Invoke((MethodInvoker)delegate {
                            button1.Text = "0x" + i.ToString("X");
                            button1.Enabled = true;
                        });
                        G.s.Aimkey = i;
                        return;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "Press key";
            button1.Enabled = false;

            Thread th = new Thread(KeyThread);
            th.Start();
        }
    }
}

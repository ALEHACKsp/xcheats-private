using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
    public partial class MainForm : MaterialForm
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static void SetTheme(MaterialForm form)
        {
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(form);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;

            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Red700, Primary.Red900,
                Primary.Red500, Accent.Red100,
                TextShade.WHITE
            );

            form.MaximizeBox = false;
            form.MaximumSize = form.Size;
            form.MinimumSize = form.Size;
        }

        public MainForm()
        {
            InitializeComponent();

            SetTheme(this);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = RandomString(20);
            RefreshList();
            LoadConfig();
            
            timer1.Start();
            timer2.Start();

            //toolStripStatusLabel1.Text = "0x" + G.baseaddr.ToString("X");
        }

        private void SaveConfig()
        {
            G.s.Aimbot = materialCheckBox1.Checked;
            G.s.SmoothAim = materialCheckBox8.Checked;
            G.s.NoRecoil = materialCheckBox3.Checked;
            
            try
            {
                G.s.SmoothDivider = Int32.Parse(materialSingleLineTextField2.Text);
                if (G.s.SmoothDivider < 100)
                {
                    G.s.SmoothDivider = 100;
                } 
            } catch (Exception error)
            {
                Log.Error(error.Message);
                G.s.SmoothDivider = 300;
            }

            try
            {
                G.s.FOV = Int32.Parse(materialSingleLineTextField1.Text);
            } catch (Exception error)
            {
                Log.Error(error.Message);
                G.s.FOV = 180;
            }


            G.s.Glow = materialCheckBox5.Checked;
            G.s.Health = materialCheckBox6.Checked;
            G.s.Shields = materialCheckBox7.Checked;

            G.s.DistanceCheck = materialCheckBox2.Checked;        
            try
            {
                G.s.DistanceMax = Int32.Parse(materialSingleLineTextField3.Text);
            }
            catch (Exception error)
            {
                Log.Error(error.Message);
                G.s.DistanceMax = 10000;
            }

            G.s.RandomizeAim = materialCheckBox4.Checked;
        }

        private void LoadConfig()
        {
            materialCheckBox1.Checked = G.s.Aimbot;
            materialCheckBox8.Checked = G.s.SmoothAim;
            materialCheckBox3.Checked = G.s.NoRecoil;

            materialSingleLineTextField2.Text = G.s.SmoothDivider.ToString();
            materialSingleLineTextField1.Text = G.s.FOV.ToString();

            materialCheckBox5.Checked = G.s.Glow;
            materialCheckBox6.Checked = G.s.Health;
            materialCheckBox7.Checked = G.s.Shields;

            materialFlatButton1.Text = "0x" + G.s.Aimkey.ToString("X");

            materialCheckBox2.Checked = G.s.DistanceCheck;
            materialSingleLineTextField3.Text = G.s.DistanceMax.ToString();

            materialCheckBox4.Checked = G.s.RandomizeAim;
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
            if (string.IsNullOrEmpty(materialSingleLineTextField4.Text))
            {
                MessageBox.Show("You must specify a name.", "Error when creating config", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string path = GetPath(materialSingleLineTextField4.Text);
            
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
                for (int i = 0x01; i < 0xB5; i++)
                {
                    if (Convert.ToBoolean(Native.GetKeyState((Native.VirtualKeyStates)i) & 0x8000))
                    {
                        materialFlatButton1.Invoke((MethodInvoker)delegate {
                            materialFlatButton1.Text = "0x" + i.ToString("X");
                            materialFlatButton1.Enabled = true;
                        });
                        G.s.Aimkey = i;
                        return;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            materialFlatButton1.Text = "Press key";
            materialFlatButton1.Enabled = false;

            Thread th = new Thread(KeyThread);
            th.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {            
            G.t1.Abort();
            G.t2.Abort();
            G.t3.Abort();
            G.t4.Abort();

            Console.WriteLine();

            G.baseaddr = Driver.Helper1.GetBase();
            Log.Debug("Base address: " + G.baseaddr);

            Log.Debug("Entity update thread...");
            G.t1 = new Thread(Threads.EntityUpdate);
            G.t1.Start();

            Log.Debug("Aimbot update thread...");
            G.t2 = new Thread(Threads.AimUpdate);
            G.t2.Start();

            Log.Debug("Aimbot thread...");
            G.t3 = new Thread(Threads.AimThread);
            G.t3.Start();

            Log.Debug("Info thread...");
            G.t4 = new Thread(Threads.InfoThread);
            G.t4.Start();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Process.Start("winver");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("Dbgview.exe");
            } catch
            {
                MessageBox.Show("Dbgview.exe was not found in cheat directory!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int positive = SDK.RandomInt(1, 100);
            if (Math.Abs(G.random) < 0.5f)
            {
                G.random = 0;
            }
            if (positive >= 50)
            {
                G.random += SDK.RandomFloat() * 0.2f;
            }
            else
            {
                G.random -= SDK.RandomFloat() * 0.2f;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            G.t1.Abort();
            G.t2.Abort();
            G.t3.Abort();
            G.t4.Abort();
        }
    }
}

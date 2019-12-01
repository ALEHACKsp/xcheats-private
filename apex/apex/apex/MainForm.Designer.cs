namespace apex
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.materialCheckBox8 = new MaterialSkin.Controls.MaterialCheckBox();
            this.materialCheckBox4 = new MaterialSkin.Controls.MaterialCheckBox();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialSingleLineTextField3 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialCheckBox2 = new MaterialSkin.Controls.MaterialCheckBox();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialFlatButton1 = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialSingleLineTextField2 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialSingleLineTextField1 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialCheckBox3 = new MaterialSkin.Controls.MaterialCheckBox();
            this.materialCheckBox1 = new MaterialSkin.Controls.MaterialCheckBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.materialCheckBox7 = new MaterialSkin.Controls.MaterialCheckBox();
            this.materialCheckBox6 = new MaterialSkin.Controls.MaterialCheckBox();
            this.materialCheckBox5 = new MaterialSkin.Controls.MaterialCheckBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.materialFlatButton5 = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialFlatButton4 = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialFlatButton3 = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialFlatButton2 = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialSingleLineTextField4 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialFlatButton6 = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialRadioButton1 = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.materialRadioButton2 = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialTabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBox1.ForeColor = System.Drawing.Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Items.AddRange(new object[] {
            "Default"});
            this.listBox1.Location = new System.Drawing.Point(10, 6);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(195, 96);
            this.listBox1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(6, 352);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(438, 57);
            this.materialLabel1.TabIndex = 8;
            this.materialLabel1.Text = "This software is distributed as freeware and if you bought it you \r\nhave been sca" +
    "mmed! You can download latest version for free \r\non official website (xcheats.cc" +
    ").";
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(0, 63);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(539, 51);
            this.materialTabSelector1.TabIndex = 9;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPage4);
            this.materialTabControl1.Controls.Add(this.tabPage5);
            this.materialTabControl1.Controls.Add(this.tabPage6);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Location = new System.Drawing.Point(12, 120);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(488, 447);
            this.materialTabControl1.TabIndex = 10;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tabPage4.Controls.Add(this.materialRadioButton2);
            this.tabPage4.Controls.Add(this.materialLabel6);
            this.tabPage4.Controls.Add(this.materialRadioButton1);
            this.tabPage4.Controls.Add(this.materialCheckBox8);
            this.tabPage4.Controls.Add(this.materialCheckBox4);
            this.tabPage4.Controls.Add(this.materialLabel5);
            this.tabPage4.Controls.Add(this.materialSingleLineTextField3);
            this.tabPage4.Controls.Add(this.materialCheckBox2);
            this.tabPage4.Controls.Add(this.materialLabel4);
            this.tabPage4.Controls.Add(this.materialFlatButton1);
            this.tabPage4.Controls.Add(this.materialLabel3);
            this.tabPage4.Controls.Add(this.materialSingleLineTextField2);
            this.tabPage4.Controls.Add(this.materialLabel2);
            this.tabPage4.Controls.Add(this.materialSingleLineTextField1);
            this.tabPage4.Controls.Add(this.materialCheckBox3);
            this.tabPage4.Controls.Add(this.materialCheckBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(480, 421);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Aimbot";
            // 
            // materialCheckBox8
            // 
            this.materialCheckBox8.AutoSize = true;
            this.materialCheckBox8.Depth = 0;
            this.materialCheckBox8.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialCheckBox8.Location = new System.Drawing.Point(7, 69);
            this.materialCheckBox8.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckBox8.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckBox8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckBox8.Name = "materialCheckBox8";
            this.materialCheckBox8.Ripple = true;
            this.materialCheckBox8.Size = new System.Drawing.Size(104, 30);
            this.materialCheckBox8.TabIndex = 13;
            this.materialCheckBox8.Text = "Smooth aim";
            this.materialCheckBox8.UseVisualStyleBackColor = true;
            // 
            // materialCheckBox4
            // 
            this.materialCheckBox4.AutoSize = true;
            this.materialCheckBox4.Depth = 0;
            this.materialCheckBox4.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialCheckBox4.Location = new System.Drawing.Point(7, 262);
            this.materialCheckBox4.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckBox4.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckBox4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckBox4.Name = "materialCheckBox4";
            this.materialCheckBox4.Ripple = true;
            this.materialCheckBox4.Size = new System.Drawing.Size(125, 30);
            this.materialCheckBox4.TabIndex = 12;
            this.materialCheckBox4.Text = "Randomize aim";
            this.materialCheckBox4.UseVisualStyleBackColor = true;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(167, 240);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(98, 19);
            this.materialLabel5.TabIndex = 11;
            this.materialLabel5.Text = "Max distance";
            // 
            // materialSingleLineTextField3
            // 
            this.materialSingleLineTextField3.Depth = 0;
            this.materialSingleLineTextField3.Hint = "";
            this.materialSingleLineTextField3.Location = new System.Drawing.Point(7, 236);
            this.materialSingleLineTextField3.MaxLength = 32767;
            this.materialSingleLineTextField3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField3.Name = "materialSingleLineTextField3";
            this.materialSingleLineTextField3.PasswordChar = '\0';
            this.materialSingleLineTextField3.SelectedText = "";
            this.materialSingleLineTextField3.SelectionLength = 0;
            this.materialSingleLineTextField3.SelectionStart = 0;
            this.materialSingleLineTextField3.Size = new System.Drawing.Size(154, 23);
            this.materialSingleLineTextField3.TabIndex = 10;
            this.materialSingleLineTextField3.TabStop = false;
            this.materialSingleLineTextField3.Text = "10000";
            this.materialSingleLineTextField3.UseSystemPasswordChar = false;
            // 
            // materialCheckBox2
            // 
            this.materialCheckBox2.AutoSize = true;
            this.materialCheckBox2.Depth = 0;
            this.materialCheckBox2.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialCheckBox2.Location = new System.Drawing.Point(7, 203);
            this.materialCheckBox2.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckBox2.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckBox2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckBox2.Name = "materialCheckBox2";
            this.materialCheckBox2.Ripple = true;
            this.materialCheckBox2.Size = new System.Drawing.Size(124, 30);
            this.materialCheckBox2.TabIndex = 9;
            this.materialCheckBox2.Text = "Distance check";
            this.materialCheckBox2.UseVisualStyleBackColor = true;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(167, 169);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(141, 19);
            this.materialLabel4.TabIndex = 8;
            this.materialLabel4.Text = "Set key used to aim";
            // 
            // materialFlatButton1
            // 
            this.materialFlatButton1.AutoSize = true;
            this.materialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton1.Depth = 0;
            this.materialFlatButton1.Icon = null;
            this.materialFlatButton1.Location = new System.Drawing.Point(7, 161);
            this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton1.Name = "materialFlatButton1";
            this.materialFlatButton1.Primary = false;
            this.materialFlatButton1.Size = new System.Drawing.Size(45, 36);
            this.materialFlatButton1.TabIndex = 7;
            this.materialFlatButton1.Text = "0x6";
            this.materialFlatButton1.UseVisualStyleBackColor = true;
            this.materialFlatButton1.Click += new System.EventHandler(this.button1_Click);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(167, 135);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(184, 19);
            this.materialLabel3.TabIndex = 6;
            this.materialLabel3.Text = "Smooth divider (100-1000)";
            // 
            // materialSingleLineTextField2
            // 
            this.materialSingleLineTextField2.Depth = 0;
            this.materialSingleLineTextField2.Hint = "";
            this.materialSingleLineTextField2.Location = new System.Drawing.Point(7, 131);
            this.materialSingleLineTextField2.MaxLength = 32767;
            this.materialSingleLineTextField2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField2.Name = "materialSingleLineTextField2";
            this.materialSingleLineTextField2.PasswordChar = '\0';
            this.materialSingleLineTextField2.SelectedText = "";
            this.materialSingleLineTextField2.SelectionLength = 0;
            this.materialSingleLineTextField2.SelectionStart = 0;
            this.materialSingleLineTextField2.Size = new System.Drawing.Size(154, 23);
            this.materialSingleLineTextField2.TabIndex = 5;
            this.materialSingleLineTextField2.TabStop = false;
            this.materialSingleLineTextField2.Text = "1";
            this.materialSingleLineTextField2.UseSystemPasswordChar = false;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(167, 106);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(69, 19);
            this.materialLabel2.TabIndex = 4;
            this.materialLabel2.Text = "Max FOV";
            // 
            // materialSingleLineTextField1
            // 
            this.materialSingleLineTextField1.Depth = 0;
            this.materialSingleLineTextField1.Hint = "";
            this.materialSingleLineTextField1.Location = new System.Drawing.Point(7, 102);
            this.materialSingleLineTextField1.MaxLength = 32767;
            this.materialSingleLineTextField1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField1.Name = "materialSingleLineTextField1";
            this.materialSingleLineTextField1.PasswordChar = '\0';
            this.materialSingleLineTextField1.SelectedText = "";
            this.materialSingleLineTextField1.SelectionLength = 0;
            this.materialSingleLineTextField1.SelectionStart = 0;
            this.materialSingleLineTextField1.Size = new System.Drawing.Size(154, 23);
            this.materialSingleLineTextField1.TabIndex = 3;
            this.materialSingleLineTextField1.TabStop = false;
            this.materialSingleLineTextField1.Text = "1";
            this.materialSingleLineTextField1.UseSystemPasswordChar = false;
            // 
            // materialCheckBox3
            // 
            this.materialCheckBox3.AutoSize = true;
            this.materialCheckBox3.Depth = 0;
            this.materialCheckBox3.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialCheckBox3.Location = new System.Drawing.Point(7, 37);
            this.materialCheckBox3.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckBox3.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckBox3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckBox3.Name = "materialCheckBox3";
            this.materialCheckBox3.Ripple = true;
            this.materialCheckBox3.Size = new System.Drawing.Size(85, 30);
            this.materialCheckBox3.TabIndex = 2;
            this.materialCheckBox3.Text = "No recoil";
            this.materialCheckBox3.UseVisualStyleBackColor = true;
            // 
            // materialCheckBox1
            // 
            this.materialCheckBox1.AutoSize = true;
            this.materialCheckBox1.Depth = 0;
            this.materialCheckBox1.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialCheckBox1.Location = new System.Drawing.Point(7, 7);
            this.materialCheckBox1.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckBox1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckBox1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckBox1.Name = "materialCheckBox1";
            this.materialCheckBox1.Ripple = true;
            this.materialCheckBox1.Size = new System.Drawing.Size(75, 30);
            this.materialCheckBox1.TabIndex = 0;
            this.materialCheckBox1.Text = "Aimbot";
            this.materialCheckBox1.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tabPage5.Controls.Add(this.materialCheckBox7);
            this.tabPage5.Controls.Add(this.materialCheckBox6);
            this.tabPage5.Controls.Add(this.materialCheckBox5);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(480, 421);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Visuals";
            // 
            // materialCheckBox7
            // 
            this.materialCheckBox7.AutoSize = true;
            this.materialCheckBox7.Depth = 0;
            this.materialCheckBox7.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialCheckBox7.Location = new System.Drawing.Point(7, 67);
            this.materialCheckBox7.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckBox7.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckBox7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckBox7.Name = "materialCheckBox7";
            this.materialCheckBox7.Ripple = true;
            this.materialCheckBox7.Size = new System.Drawing.Size(75, 30);
            this.materialCheckBox7.TabIndex = 2;
            this.materialCheckBox7.Text = "Shields";
            this.materialCheckBox7.UseVisualStyleBackColor = true;
            // 
            // materialCheckBox6
            // 
            this.materialCheckBox6.AutoSize = true;
            this.materialCheckBox6.Depth = 0;
            this.materialCheckBox6.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialCheckBox6.Location = new System.Drawing.Point(7, 37);
            this.materialCheckBox6.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckBox6.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckBox6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckBox6.Name = "materialCheckBox6";
            this.materialCheckBox6.Ripple = true;
            this.materialCheckBox6.Size = new System.Drawing.Size(70, 30);
            this.materialCheckBox6.TabIndex = 1;
            this.materialCheckBox6.Text = "Health";
            this.materialCheckBox6.UseVisualStyleBackColor = true;
            // 
            // materialCheckBox5
            // 
            this.materialCheckBox5.AutoSize = true;
            this.materialCheckBox5.Depth = 0;
            this.materialCheckBox5.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialCheckBox5.Location = new System.Drawing.Point(7, 7);
            this.materialCheckBox5.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckBox5.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckBox5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckBox5.Name = "materialCheckBox5";
            this.materialCheckBox5.Ripple = true;
            this.materialCheckBox5.Size = new System.Drawing.Size(61, 30);
            this.materialCheckBox5.TabIndex = 0;
            this.materialCheckBox5.Text = "Glow";
            this.materialCheckBox5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tabPage6.Controls.Add(this.materialFlatButton5);
            this.tabPage6.Controls.Add(this.materialFlatButton4);
            this.tabPage6.Controls.Add(this.materialFlatButton3);
            this.tabPage6.Controls.Add(this.materialFlatButton2);
            this.tabPage6.Controls.Add(this.materialSingleLineTextField4);
            this.tabPage6.Controls.Add(this.materialLabel1);
            this.tabPage6.Controls.Add(this.listBox1);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(480, 421);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "Config";
            // 
            // materialFlatButton5
            // 
            this.materialFlatButton5.AutoSize = true;
            this.materialFlatButton5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton5.Depth = 0;
            this.materialFlatButton5.Icon = null;
            this.materialFlatButton5.Location = new System.Drawing.Point(276, 55);
            this.materialFlatButton5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton5.Name = "materialFlatButton5";
            this.materialFlatButton5.Primary = false;
            this.materialFlatButton5.Size = new System.Drawing.Size(69, 36);
            this.materialFlatButton5.TabIndex = 13;
            this.materialFlatButton5.Text = "Delete";
            this.materialFlatButton5.UseVisualStyleBackColor = true;
            this.materialFlatButton5.Click += new System.EventHandler(this.button5_Click);
            // 
            // materialFlatButton4
            // 
            this.materialFlatButton4.AutoSize = true;
            this.materialFlatButton4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton4.Depth = 0;
            this.materialFlatButton4.Icon = null;
            this.materialFlatButton4.Location = new System.Drawing.Point(276, 7);
            this.materialFlatButton4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton4.Name = "materialFlatButton4";
            this.materialFlatButton4.Primary = false;
            this.materialFlatButton4.Size = new System.Drawing.Size(71, 36);
            this.materialFlatButton4.TabIndex = 12;
            this.materialFlatButton4.Text = "Create";
            this.materialFlatButton4.UseVisualStyleBackColor = true;
            this.materialFlatButton4.Click += new System.EventHandler(this.button4_Click);
            // 
            // materialFlatButton3
            // 
            this.materialFlatButton3.AutoSize = true;
            this.materialFlatButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton3.Depth = 0;
            this.materialFlatButton3.Icon = null;
            this.materialFlatButton3.Location = new System.Drawing.Point(213, 55);
            this.materialFlatButton3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton3.Name = "materialFlatButton3";
            this.materialFlatButton3.Primary = false;
            this.materialFlatButton3.Size = new System.Drawing.Size(55, 36);
            this.materialFlatButton3.TabIndex = 11;
            this.materialFlatButton3.Text = "Save";
            this.materialFlatButton3.UseVisualStyleBackColor = true;
            this.materialFlatButton3.Click += new System.EventHandler(this.button3_Click);
            // 
            // materialFlatButton2
            // 
            this.materialFlatButton2.AutoSize = true;
            this.materialFlatButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton2.Depth = 0;
            this.materialFlatButton2.Icon = null;
            this.materialFlatButton2.Location = new System.Drawing.Point(212, 7);
            this.materialFlatButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton2.Name = "materialFlatButton2";
            this.materialFlatButton2.Primary = false;
            this.materialFlatButton2.Size = new System.Drawing.Size(56, 36);
            this.materialFlatButton2.TabIndex = 10;
            this.materialFlatButton2.Text = "Load";
            this.materialFlatButton2.UseVisualStyleBackColor = true;
            this.materialFlatButton2.Click += new System.EventHandler(this.button2_Click);
            // 
            // materialSingleLineTextField4
            // 
            this.materialSingleLineTextField4.Depth = 0;
            this.materialSingleLineTextField4.Hint = "";
            this.materialSingleLineTextField4.Location = new System.Drawing.Point(10, 109);
            this.materialSingleLineTextField4.MaxLength = 32767;
            this.materialSingleLineTextField4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField4.Name = "materialSingleLineTextField4";
            this.materialSingleLineTextField4.PasswordChar = '\0';
            this.materialSingleLineTextField4.SelectedText = "";
            this.materialSingleLineTextField4.SelectionLength = 0;
            this.materialSingleLineTextField4.SelectionStart = 0;
            this.materialSingleLineTextField4.Size = new System.Drawing.Size(195, 23);
            this.materialSingleLineTextField4.TabIndex = 9;
            this.materialSingleLineTextField4.TabStop = false;
            this.materialSingleLineTextField4.UseSystemPasswordChar = false;
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.AutoSize = true;
            this.materialRaisedButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Icon = null;
            this.materialRaisedButton1.Location = new System.Drawing.Point(12, 573);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(144, 36);
            this.materialRaisedButton1.TabIndex = 11;
            this.materialRaisedButton1.Text = "Restart threads";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.button6_Click);
            // 
            // materialFlatButton6
            // 
            this.materialFlatButton6.AutoSize = true;
            this.materialFlatButton6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton6.Depth = 0;
            this.materialFlatButton6.Icon = null;
            this.materialFlatButton6.Location = new System.Drawing.Point(163, 573);
            this.materialFlatButton6.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton6.Name = "materialFlatButton6";
            this.materialFlatButton6.Primary = false;
            this.materialFlatButton6.Size = new System.Drawing.Size(120, 36);
            this.materialFlatButton6.TabIndex = 12;
            this.materialFlatButton6.Text = "Open Dbgview";
            this.materialFlatButton6.UseVisualStyleBackColor = true;
            this.materialFlatButton6.Click += new System.EventHandler(this.button7_Click);
            // 
            // materialRadioButton1
            // 
            this.materialRadioButton1.AutoSize = true;
            this.materialRadioButton1.Depth = 0;
            this.materialRadioButton1.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialRadioButton1.Location = new System.Drawing.Point(7, 296);
            this.materialRadioButton1.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton1.Name = "materialRadioButton1";
            this.materialRadioButton1.Ripple = true;
            this.materialRadioButton1.Size = new System.Drawing.Size(61, 30);
            this.materialRadioButton1.TabIndex = 14;
            this.materialRadioButton1.TabStop = true;
            this.materialRadioButton1.Text = "Head";
            this.materialRadioButton1.UseVisualStyleBackColor = true;
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(167, 301);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(53, 19);
            this.materialLabel6.TabIndex = 15;
            this.materialLabel6.Text = "Aim at";
            // 
            // materialRadioButton2
            // 
            this.materialRadioButton2.AutoSize = true;
            this.materialRadioButton2.Depth = 0;
            this.materialRadioButton2.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialRadioButton2.Location = new System.Drawing.Point(7, 326);
            this.materialRadioButton2.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton2.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton2.Name = "materialRadioButton2";
            this.materialRadioButton2.Ripple = true;
            this.materialRadioButton2.Size = new System.Drawing.Size(65, 30);
            this.materialRadioButton2.TabIndex = 16;
            this.materialRadioButton2.TabStop = true;
            this.materialRadioButton2.Text = "Chest";
            this.materialRadioButton2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 622);
            this.Controls.Add(this.materialFlatButton6);
            this.Controls.Add(this.materialRaisedButton1);
            this.Controls.Add(this.materialTabControl1);
            this.Controls.Add(this.materialTabSelector1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(9999, 1038);
            this.MinimumSize = new System.Drawing.Size(425, 100);
            this.Name = "MainForm";
            this.Text = "xcheats.cc";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.materialTabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabPage4;
        private MaterialSkin.Controls.MaterialCheckBox materialCheckBox1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private MaterialSkin.Controls.MaterialCheckBox materialCheckBox3;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField3;
        private MaterialSkin.Controls.MaterialCheckBox materialCheckBox2;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton1;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField2;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField1;
        private MaterialSkin.Controls.MaterialCheckBox materialCheckBox4;
        private MaterialSkin.Controls.MaterialCheckBox materialCheckBox7;
        private MaterialSkin.Controls.MaterialCheckBox materialCheckBox6;
        private MaterialSkin.Controls.MaterialCheckBox materialCheckBox5;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton5;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton4;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton3;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton2;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField4;
        private MaterialSkin.Controls.MaterialCheckBox materialCheckBox8;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton6;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton2;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton1;
    }
}
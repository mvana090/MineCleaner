namespace MineCleaner
{
    partial class Form1
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
            this.tbheight = new System.Windows.Forms.TextBox();
            this.tbwidth = new System.Windows.Forms.TextBox();
            this.tbmines = new System.Windows.Forms.TextBox();
            this.linfo = new System.Windows.Forms.Label();
            this.lreset = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.l_TimeEllapsed = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cb_difficulty = new System.Windows.Forms.ComboBox();
            this.cb_mode = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tbheight
            // 
            this.tbheight.Location = new System.Drawing.Point(45, 52);
            this.tbheight.Name = "tbheight";
            this.tbheight.Size = new System.Drawing.Size(30, 20);
            this.tbheight.TabIndex = 1;
            this.tbheight.Text = "10";
            // 
            // tbwidth
            // 
            this.tbwidth.Location = new System.Drawing.Point(120, 52);
            this.tbwidth.Name = "tbwidth";
            this.tbwidth.Size = new System.Drawing.Size(30, 20);
            this.tbwidth.TabIndex = 0;
            this.tbwidth.Text = "10";
            // 
            // tbmines
            // 
            this.tbmines.Location = new System.Drawing.Point(200, 52);
            this.tbmines.Name = "tbmines";
            this.tbmines.Size = new System.Drawing.Size(30, 20);
            this.tbmines.TabIndex = 2;
            this.tbmines.Text = "10";
            // 
            // linfo
            // 
            this.linfo.AutoSize = true;
            this.linfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.linfo.Location = new System.Drawing.Point(254, 0);
            this.linfo.Name = "linfo";
            this.linfo.Size = new System.Drawing.Size(18, 20);
            this.linfo.TabIndex = 3;
            this.linfo.Text = "?";
            this.linfo.Click += new System.EventHandler(this.linfo_Click);
            // 
            // lreset
            // 
            this.lreset.AutoSize = true;
            this.lreset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lreset.Location = new System.Drawing.Point(136, 5);
            this.lreset.Name = "lreset";
            this.lreset.Size = new System.Drawing.Size(37, 15);
            this.lreset.TabIndex = 3;
            this.lreset.Text = "Reset";
            this.lreset.Click += new System.EventHandler(this.lreset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Width:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Height:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mines:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(136, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Time:";
            // 
            // l_TimeEllapsed
            // 
            this.l_TimeEllapsed.AutoSize = true;
            this.l_TimeEllapsed.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.l_TimeEllapsed.Location = new System.Drawing.Point(175, 25);
            this.l_TimeEllapsed.Name = "l_TimeEllapsed";
            this.l_TimeEllapsed.Size = new System.Drawing.Size(13, 13);
            this.l_TimeEllapsed.TabIndex = 8;
            this.l_TimeEllapsed.Text = "0";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cb_difficulty
            // 
            this.cb_difficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_difficulty.FormattingEnabled = true;
            this.cb_difficulty.Location = new System.Drawing.Point(7, 2);
            this.cb_difficulty.Name = "cb_difficulty";
            this.cb_difficulty.Size = new System.Drawing.Size(121, 21);
            this.cb_difficulty.TabIndex = 9;
            this.cb_difficulty.TextChanged += new System.EventHandler(this.cb_difficulty_TextChanged);
            // 
            // cb_mode
            // 
            this.cb_mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_mode.FormattingEnabled = true;
            this.cb_mode.Location = new System.Drawing.Point(7, 25);
            this.cb_mode.Name = "cb_mode";
            this.cb_mode.Size = new System.Drawing.Size(121, 21);
            this.cb_mode.TabIndex = 10;
            this.cb_mode.TextChanged += new System.EventHandler(this.cb_mode_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.cb_mode);
            this.Controls.Add(this.cb_difficulty);
            this.Controls.Add(this.l_TimeEllapsed);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lreset);
            this.Controls.Add(this.linfo);
            this.Controls.Add(this.tbmines);
            this.Controls.Add(this.tbwidth);
            this.Controls.Add(this.tbheight);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Mine Cleaner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbheight;
        private System.Windows.Forms.TextBox tbwidth;
        private System.Windows.Forms.TextBox tbmines;
        private System.Windows.Forms.Label linfo;
        private System.Windows.Forms.Label lreset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label l_TimeEllapsed;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cb_difficulty;
        private System.Windows.Forms.ComboBox cb_mode;
    }
}


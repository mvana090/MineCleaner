namespace minesweeper
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
            this.tbheight = new System.Windows.Forms.TextBox();
            this.tbwidth = new System.Windows.Forms.TextBox();
            this.tbmines = new System.Windows.Forms.TextBox();
            this.linfo = new System.Windows.Forms.Label();
            this.lreset = new System.Windows.Forms.Label();
            this.tbnull = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbheight
            // 
            this.tbheight.Location = new System.Drawing.Point(99, 106);
            this.tbheight.Name = "tbheight";
            this.tbheight.Size = new System.Drawing.Size(100, 20);
            this.tbheight.TabIndex = 1;
            this.tbheight.Text = "10";
            // 
            // tbwidth
            // 
            this.tbwidth.Location = new System.Drawing.Point(110, 167);
            this.tbwidth.Name = "tbwidth";
            this.tbwidth.Size = new System.Drawing.Size(100, 20);
            this.tbwidth.TabIndex = 0;
            this.tbwidth.Text = "10";
            // 
            // tbmines
            // 
            this.tbmines.Location = new System.Drawing.Point(134, 193);
            this.tbmines.Name = "tbmines";
            this.tbmines.Size = new System.Drawing.Size(100, 20);
            this.tbmines.TabIndex = 2;
            this.tbmines.Text = "10";
            // 
            // linfo
            // 
            this.linfo.AutoSize = true;
            this.linfo.Location = new System.Drawing.Point(173, 53);
            this.linfo.Name = "linfo";
            this.linfo.Size = new System.Drawing.Size(13, 13);
            this.linfo.TabIndex = 3;
            this.linfo.Text = "?";
            this.linfo.Click += new System.EventHandler(this.linfo_Click);
            // 
            // lreset
            // 
            this.lreset.AutoSize = true;
            this.lreset.Location = new System.Drawing.Point(131, 39);
            this.lreset.Name = "lreset";
            this.lreset.Size = new System.Drawing.Size(35, 13);
            this.lreset.TabIndex = 3;
            this.lreset.Text = "Reset";
            this.lreset.Click += new System.EventHandler(this.lreset_Click);
            // 
            // tbnull
            // 
            this.tbnull.Location = new System.Drawing.Point(12, 220);
            this.tbnull.Name = "tbnull";
            this.tbnull.Size = new System.Drawing.Size(100, 20);
            this.tbnull.TabIndex = 5;
            this.tbnull.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tbnull);
            this.Controls.Add(this.lreset);
            this.Controls.Add(this.linfo);
            this.Controls.Add(this.tbmines);
            this.Controls.Add(this.tbwidth);
            this.Controls.Add(this.tbheight);
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
        private System.Windows.Forms.TextBox tbnull;
    }
}


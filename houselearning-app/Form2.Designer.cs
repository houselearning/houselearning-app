namespace houselearning_app
{
    partial class SafeBrowser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SafeBrowser));
            this.backbtnsafebrowser = new System.Windows.Forms.Button();
            this.searchindex = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.safebrowserindex = new System.Windows.Forms.WebBrowser();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.settingsbtnSafeBrowser = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backbtnsafebrowser
            // 
            this.backbtnsafebrowser.Location = new System.Drawing.Point(1049, 48);
            this.backbtnsafebrowser.Name = "backbtnsafebrowser";
            this.backbtnsafebrowser.Size = new System.Drawing.Size(75, 23);
            this.backbtnsafebrowser.TabIndex = 0;
            this.backbtnsafebrowser.Text = "Portal";
            this.backbtnsafebrowser.UseVisualStyleBackColor = true;
            this.backbtnsafebrowser.Click += new System.EventHandler(this.backbtnsafebrowser_Click);
            // 
            // searchindex
            // 
            this.searchindex.Location = new System.Drawing.Point(83, 23);
            this.searchindex.Name = "searchindex";
            this.searchindex.Size = new System.Drawing.Size(883, 20);
            this.searchindex.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(972, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1023, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(51, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Foward";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1080, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(44, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Home";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // safebrowserindex
            // 
            this.safebrowserindex.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.safebrowserindex.Location = new System.Drawing.Point(0, 93);
            this.safebrowserindex.MinimumSize = new System.Drawing.Size(20, 20);
            this.safebrowserindex.Name = "safebrowserindex";
            this.safebrowserindex.Size = new System.Drawing.Size(1136, 509);
            this.safebrowserindex.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.settingsbtnSafeBrowser);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.backbtnsafebrowser);
            this.groupBox1.Controls.Add(this.searchindex);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1136, 87);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menu";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 23);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(71, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Search";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // settingsbtnSafeBrowser
            // 
            this.settingsbtnSafeBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsbtnSafeBrowser.Location = new System.Drawing.Point(968, 49);
            this.settingsbtnSafeBrowser.Name = "settingsbtnSafeBrowser";
            this.settingsbtnSafeBrowser.Size = new System.Drawing.Size(75, 23);
            this.settingsbtnSafeBrowser.TabIndex = 6;
            this.settingsbtnSafeBrowser.Text = "Settings";
            this.settingsbtnSafeBrowser.UseVisualStyleBackColor = true;
            this.settingsbtnSafeBrowser.Click += new System.EventHandler(this.button5_Click);
            // 
            // SafeBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 602);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.safebrowserindex);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SafeBrowser";
            this.Text = "HouseLearning | SafeBrowser";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button backbtnsafebrowser;
        private System.Windows.Forms.TextBox searchindex;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.WebBrowser safebrowserindex;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button settingsbtnSafeBrowser;
    }
}
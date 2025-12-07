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
            this.backbtnsafebrowser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // backbtnsafebrowser
            // 
            this.backbtnsafebrowser.Location = new System.Drawing.Point(5, 4);
            this.backbtnsafebrowser.Name = "backbtnsafebrowser";
            this.backbtnsafebrowser.Size = new System.Drawing.Size(75, 23);
            this.backbtnsafebrowser.TabIndex = 0;
            this.backbtnsafebrowser.Text = "Back";
            this.backbtnsafebrowser.UseVisualStyleBackColor = true;
            this.backbtnsafebrowser.Click += new System.EventHandler(this.backbtnsafebrowser_Click);
            // 
            // SafeBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.backbtnsafebrowser);
            this.Name = "SafeBrowser";
            this.Text = "HouseLearning | SafeBrowser";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button backbtnsafebrowser;
    }
}
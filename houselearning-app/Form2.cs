using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace houselearning_app
{
    public partial class SafeBrowser : Form
    {
        public SafeBrowser()
        {
            InitializeComponent();
        }

        private void backbtnsafebrowser_Click(object sender, EventArgs e)
        {
            Form1 houselearning = new Form1(); // Create an instance of Form2
            houselearning.Show(); // Show Form2

            this.Hide(); // Hide Form1 (you can also use this.Close() if you want to close it completely)
        }
    }
}

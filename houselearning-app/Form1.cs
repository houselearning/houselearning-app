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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        } 

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void safebrowserbtn_Click(object sender, EventArgs e)
        {
            SafeBrowser safeBrowser = new SafeBrowser(); // Create an instance of Form2
            safeBrowser.Show(); // Show Form2

            this.Hide(); // Hide Form1 (you can also use this.Close() if you want to close it completely)
        }

        private void homebtn_Click(object sender, EventArgs e)
        {

        }

        private void mathbtn_Click(object sender, EventArgs e)
        {

        }

        private void sciencebtn_Click(object sender, EventArgs e)
        {

        }

        private void codingbtn_Click(object sender, EventArgs e)
        {

        }

        private void playmath_Click(object sender, EventArgs e)
        {

        }

        private void playscience_Click(object sender, EventArgs e)
        {

        }

        private void playcoding_Click(object sender, EventArgs e)
        {

        }
    }
}

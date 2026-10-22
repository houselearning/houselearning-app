using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace houselearning_app
{
    public partial class mainscreen : Form
    {
        public mainscreen()
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
            this.Hide();
        }

        private void homebtn_Click(object sender, EventArgs e)
        {
            OpenHouseLearningPage("https://www.houselearning.org/home/");
        }

        private void mathbtn_Click(object sender, EventArgs e)
        {
            OpenHouseLearningPage("https://www.houselearning.org/home/math-page.html");
        }

        private void sciencebtn_Click(object sender, EventArgs e)
        {
            OpenHouseLearningPage("https://www.houselearning.org/home/science-page.html");
        }

        private void codingbtn_Click(object sender, EventArgs e)
        {
            OpenHouseLearningPage("https://www.houselearning.org/home/computer-science-page.html");
        }

        private void playmath_Click(object sender, EventArgs e)
        {
            OpenHouseLearningPage("https://www.houselearning.org/home/games.html");
        }

        private void playscience_Click(object sender, EventArgs e)
        {
            OpenHouseLearningPage("https://www.houselearning.org/home/science-page.html");
        }

        private void playcoding_Click(object sender, EventArgs e)
        {
            OpenHouseLearningPage("https://www.houselearning.org/home/computer-science-page.html");
        }

        private void lessonCliBtn_Click(object sender, EventArgs e)
        {
            using (var lessonCli = new LessonCliForm())
            {
                lessonCli.ShowDialog(this);
            }
        }

        private static void OpenHouseLearningPage(string url)
        {
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
    }
}

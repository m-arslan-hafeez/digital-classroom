using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace MultipleChoice
{
    public partial class ErrorReport : Form
    {
        private int increment = 1;
        public ErrorReport()
        {
            InitializeComponent();
            SystemSounds.Asterisk.Play();
            timer1.Start();
            this.Text = "Offline Mode";
           
        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            //default Point(387, 255)
            if (increment == 1) 
            {
                pictureArrowBox.Location = new Point(387, 257);
            }
            else if (increment == 2) 
            {
                pictureArrowBox.Location = new Point(387, 259);
            }
            else if (increment == 3) 
            {
                pictureArrowBox.Location = new Point(387, 261);
            }
            else if (increment == 4) 
            {
                pictureArrowBox.Location = new Point(387, 263);
            }
            else if (increment == 5) 
            {
                pictureArrowBox.Location = new Point(387, 265);
            }
            else if (increment == 6) 
            {
                pictureArrowBox.Location = new Point(387, 267);
            }
            else if (increment == 7) 
            {
                pictureArrowBox.Location = new Point(387, 269);
            }
            else if (increment == 8)
            {
                pictureArrowBox.Location = new Point(387, 271);
            }
            else if (increment == 9)
            {
                pictureArrowBox.Location = new Point(387, 273);
            }
            else if (increment == 10)
            {
                pictureArrowBox.Location = new Point(387, 275);
            }
            else if (increment == 11)
            {
                pictureArrowBox.Location = new Point(387, 277);
            }
            else if (increment == 12)
            {
                pictureArrowBox.Location = new Point(387, 279);
            }
            else if (increment == 13)
            {
                pictureArrowBox.Location = new Point(387, 281);
            }
            else if (increment == 14)
            {
                pictureArrowBox.Location = new Point(387, 283);
            }
            else if (increment == 15)
            {
                pictureArrowBox.Location = new Point(387, 285);
            }
            else if (increment == 16)
            {
                pictureArrowBox.Location = new Point(387, 255);
                increment = 0;
            }
            increment++;
        }

        private void lblDismiss_Click(object sender, EventArgs e)
        {
            btnDismiss.BackgroundImage = Properties.Resources.onlickBlue;
            timer1.Stop();
            this.Hide();
           
        }

        private void btnDismiss_Click(object sender, EventArgs e)
        {
            btnDismiss.BackgroundImage = Properties.Resources.onlickBlue;
            timer1.Stop();
            this.Hide();
        }

        private void btnDismiss_MouseLeave(object sender, EventArgs e)
        {
            btnDismiss.BackgroundImage = Properties.Resources.stableBlue;
        }

        private void lblDismiss_Leave(object sender, EventArgs e)
        {
            btnDismiss.BackgroundImage = Properties.Resources.stableBlue;
        }
        
    }
}

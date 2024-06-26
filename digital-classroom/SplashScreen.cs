﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultipleChoice
{
    public partial class SplashScreen : Form
    {
        //decalring 
        int load = 0;
        int done = 0;
        public SplashScreen()
        {
            InitializeComponent();
            lblLoading.Text = "";
            //timerLoading.Start();
            timerCircular.Start();
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
        }

        private void timerLoading_Tick(object sender, EventArgs e)
        {
            done++;
            if (load == 1) 
            {
                lblLoading.Text = "loading.";
            }
            else if (load == 3) 
            {
             lblLoading.Text = "loading..";
            }
            else if(load == 5)
            {
             lblLoading.Text = "loading...";
            }
            else if(load == 7)
            {
             lblLoading.Text = "loading....";
            }
            else if (load == 8)
            {
             lblLoading.Text = "loading.....";
            }
            else if(load==10)
            {
                lblLoading.Text = "loading......";
                load = 0;
            }
            else if (done == 20) 
            {
                timerLoading.Stop();
                timerCircular.Stop();
                MultipleChoice multiple = new MultipleChoice();
                this.Hide();
                multiple.ShowDialog();
            }
            load++;
            
        }
        int cir = 0;
        int start = 0;
        private void timerCircular_Tick(object sender, EventArgs e)
        {
            if (start == 10) 
            {
                timerLoading.Start();
            }
            else if (cir == 1) 
            {
                label2.Visible = true;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
            }
            else if (cir == 2) 
            {
                label3.Visible = true;
                label2.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
            }
            else if (cir == 3) 
            {
                label4.Visible = true;
                label2.Visible = false;
                label3.Visible = false;
                label5.Visible = false;
            }
            else if (cir == 4) 
            {
                label5.Visible = true;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;

                cir = 0;
            }
            
            start++;
            cir++;
        }
    }
}

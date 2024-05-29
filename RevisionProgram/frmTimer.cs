using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevisionProgram
{
    public partial class frmTimer : Form
    {
        public frmTimer()
        {
            InitializeComponent();
            timerTick.Enabled = false;
            btnStart.Enabled = false;
            btnStop.Enabled = false;
            btnReset.Enabled = false;
            //Disables buttons first to prevent errors
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmRevisionTools nf = new frmRevisionTools();
            nf.Show();
            this.Hide();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            frmSignIn nf = new frmSignIn();
            nf.Show();
            this.Hide();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbInputTime.Text != "") //Validation check
                {
                    if (Convert.ToInt32(tbInputTime.Text) > 86399 || Convert.ToInt32(tbInputTime.Text) < 0) //Checks to see if time is invalid, i.e. less than 0 or greater than 24 hours
                    {
                        MessageBox.Show("Please enter a time between 0 and 24 hours!");
                    }
                    else
                    {
                        int seconds = Convert.ToInt32(tbInputTime.Text);
                        TimeSpan time = TimeSpan.FromSeconds(seconds);
                        //Function to convert seconds into hrs/mins
                        lblCounter.Text = time.ToString(@"hh\:mm\:ss");
                        User.timer = seconds;
                        //format string
                        btnStart.Enabled = true;
                    }
                }
                else
                {
                    lblCounter.Text = "00:00:00";
                }
            }
            catch
            {
                MessageBox.Show("Please enter a valid time!");
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timerTick.Enabled = true;
            btnStop.Enabled = true;
            btnStart.Enabled = false;
            btnReset.Enabled = true;
            //starts timer, disables start button
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timerTick.Stop();
            btnStop.Enabled = false;
            btnStart.Enabled = true;
            btnReset.Enabled = true;
            //stop timer, disable stop button
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            timerTick.Stop();
            lblCounter.Text = "00:00:00";
            //reset timer
            btnStart.Enabled = false;
            btnStop.Enabled = false;
            tbInputTime.Enabled = true;
            //disable buttons until user inputs and confirms a time
        }

        private void frmTimer_Load(object sender, EventArgs e)
        {

        }

        private void timerTick_Tick(object sender, EventArgs e)
        {
            if(User.timer > 0)
            {
                //decrement time and format to correct format
                User.timer--;
                TimeSpan time = TimeSpan.FromSeconds(User.timer);
                lblCounter.Text = time.ToString(@"hh\:mm\:ss");
            }
            else
            {
                //Check if time reaches 0
                this.timerTick.Stop();
                MessageBox.Show("Time is up!");
                btnStop.Enabled = false;
                btnStart.Enabled = true;
                timerTick.Enabled = false;
            }
        }
    }
}

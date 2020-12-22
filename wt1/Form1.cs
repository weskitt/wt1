using System;
using System.Windows.Forms;

namespace wt1
{
    public partial class Fm1 : Form
    {
        public Fm1() => InitializeComponent();

        private Funcs funcs = new Funcs();
        private string chpy=null;
        private bool drawOriginFlag=false;
        
        private void OpenBtn_Click(object sender, EventArgs e)
        {
            if (funcs.ReadWaveFile())
                chpy = funcs.DrawOriginData(panel1, this);
            drawOriginFlag = false;
        }
        private void General_Click(object sender, EventArgs e)
        {
            if (chpy != null)
            {
                label_p.Text = funcs.ReturnPeriod().ToString();
                perDev.Text = funcs.ReturnPeriodDeviation().ToString();
                drawOriginFlag = true;
            }
        }
        private void Switch_Click(object sender, EventArgs e)
        {
            if (chpy!=null)
            {
                if (drawOriginFlag)
                    funcs.DrawOriginData(panel1, this);
                else
                    funcs.DrawGerneralData(panel1, this);
                drawOriginFlag = !drawOriginFlag;
            }
            else
            {
                if (funcs.ReadWaveFile())
                    chpy = funcs.DrawOriginData(panel1, this);
            }
        }
        private void Fm1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)Keys.Escape)
            {
                this.Close();
                return;
            }
        }

        private void Output_Click(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

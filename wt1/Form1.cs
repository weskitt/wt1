using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;
using MathNet;
using System.IO;
//using static wt1.Funcs;
//using System.Runtime.InteropServices;

namespace wt1
{
    public partial class Fm1 : Form
    {
        public Fm1() => InitializeComponent();

        private Funcs funcs = new Funcs();
        private string chpy=null;
        private bool drawOriginFlag;

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    
        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            if (funcs.ReadWaveFile())
                chpy = funcs.DrawOriginData(panel1, this);
            drawOriginFlag = true;
        }
        
        private void OpenBtn_Click(object sender, EventArgs e)
        {
            if (funcs.ReadWaveFile())
                chpy = funcs.DrawOriginData(panel1, this);
            drawOriginFlag = true;
        }


        private void General_Click(object sender, EventArgs e)
        {
            funcs.DrawGerneralData(panel1, this);
            drawOriginFlag = false;
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

    }
}

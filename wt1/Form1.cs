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
using static wt1.Funcs;
using static wt1.WaveViewer;
//using System.Runtime.InteropServices;

namespace wt1
{
    public partial class Fm1 : Form
    {
        public Fm1()
        {
            
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 1600;
            this.Height = 1006;
        }


        public void Panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.Width = 1600;
            panel1.Height = 900;

            DrawGerneralData();
            isGeneralShow = false;
        }

        private void SkinTrackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = skinTrackBar1.Value.ToString();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            skinTrackBar1.Value = skinTrackBar1.Maximum/2;
            label1.Text = skinTrackBar1.Value.ToString();
        }
        
        private void OpenBtn_Click(object sender, EventArgs e)
        {
            FuncInit(panel1, this);
            OpenWaveDialog();
            DrawPCMWave();
            isGeneralShow = true;
        }

        private void DrawGerneralData()
        {
            var g = panel1.CreateGraphics();
            Pen p = new Pen(Color.Green);
            SolidBrush bb = new SolidBrush(Color.Black);
            WaveViewer waveViewer = new WaveViewer();
            Rectangle DrawRect = new Rectangle(0, 0, panel1.Width, panel1.Height);

            g.FillRectangle(bb, DrawRect);
            g.DrawLine(p, 0, DrawRect.Height / 2, DrawRect.Width, DrawRect.Height / 2);
            

            waveViewer.GerneralWave();
            waveViewer.BsToVertex(ref DrawRect);
            g.DrawLines(p, pointFs);
            this.Text = "由GerneralWave()函数生成";
        }

        private void General_Click(object sender, EventArgs e)
        {
            DrawGerneralData();
            isGeneralShow = false;
        }

        private void Switch_Click(object sender, EventArgs e)
        {
            if (isGeneralShow)
            {
                DrawGerneralData();
                isGeneralShow = !isGeneralShow;
            }
            else
            {
                if(!isPCMInit)
                {
                    FuncInit(panel1, this);
                    if (OpenWaveDialog()) DrawPCMWave();
                    else goto End;
                }
                else
                    DrawPCMWave();

                isGeneralShow = !isGeneralShow;
            }
        End:;
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

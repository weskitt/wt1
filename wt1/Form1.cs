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
using static wt1.AllDataBase;
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
            chpy = string.Empty; //汉字拼音
            /*
              tVoice = new Voice();
              tInfo = new VoiceModInfo
              {
                  preVoice = false,
                  Initbegin = false,
                  InitlastU = false,
                  areaID = 1
              }; //创建新实例
            */
        }
    
        public void Panel1_Paint(object sender, PaintEventArgs e)
        {
            DrawGerneralData();
            isGeneralShow = false;
        }
        
        private void OpenBtn_Click(object sender, EventArgs e)
        {
            FuncInit(panel1, this);
            OpenWaveDialog();
            chpy = DrawPCMWave();
            isGeneralShow = true;
        }

        private void DrawGerneralData()
        {
            var g = panel1.CreateGraphics();
            Pen p = new Pen(Color.Green);
            SolidBrush bb = new SolidBrush(Color.Black);
            //WaveViewer waveViewer = new WaveViewer();
            Rectangle DrawRect = new Rectangle(0, 0, panel1.Width, panel1.Height);

            g.FillRectangle(bb, DrawRect);
            g.DrawLine(p, 0, DrawRect.Height / 2, DrawRect.Width, DrawRect.Height / 2);


            GerneralWave();
            BsToVertex(ref DrawRect);
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
                    if (OpenWaveDialog()) chpy = DrawPCMWave();
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

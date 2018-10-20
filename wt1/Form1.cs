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
            
            this.Width = 1910;
            this.Height = 1030;

            panel1.Width = 1600;
            panel1.Height = 900;

            Point btnSize = new Point(OpenBtn.Width, OpenBtn.Height);
            Point btnOpenL = new Point(0, 908);
            Point btnSwL = new Point(btnSize.X, 908);
            Point btnGenL = new Point(0, btnSize.Y + 908);
            Point btnBothL = new Point(btnSize.X, btnSize.Y + 908);
            Point gpL = new Point(btnSize.X * 2, 900);

            OpenBtn.Location = btnOpenL;
            Switch.Location = btnSwL;
            General.Location = btnGenL;
            Both.Location = btnBothL;
            groupBox1.Location = gpL;

        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

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

        private void NewArea_Click(object sender, EventArgs e)
        {
            int rowCount = 0;
            AreaGrid.Rows[rowCount].Cells["AreaID"].Value = tVoice.infos.Count+1;
            AreaGrid.Rows[rowCount].Cells["Begin"].Value = "null";
            AreaGrid.Rows[rowCount].Cells["End"].Value = "null";
            AreaGrid.Rows[rowCount].Cells["StartAmp"].Value = StartAmpTRB.Value;
            AreaGrid.Rows[rowCount].Cells["Ort"].Value = "4";


            tInfo = new VoiceModInfo
            {
                areaID = 1,
                preVoice = true,
                InitlastU = true,
                Initbegin = false,

                startAmp = 0.03f,
                begin = -1.0f,
                end = -0.8f
            };
            tVoice.ModInfo.Add(tInfo);
        }


        private void Arate0TRB_Scroll(object sender, EventArgs e)
        {
            Arate0_LShow.Text = Arate0TRB.Value.ToString();
        }
        private void Arate0_Reset_Click(object sender, EventArgs e)
        {
            Arate0TRB.Value = 50;
            Arate0_LShow.Text = Arate0TRB.Value.ToString();
        }

        private void Arate1TRB_Scroll(object sender, EventArgs e)
        {
            Arate1_LShow.Text = Arate1TRB.Value.ToString();
        }
        private void Arate1_Reset_Click(object sender, EventArgs e)
        {
            Arate1TRB.Value = 50;
            Arate1_LShow.Text = Arate1TRB.Value.ToString();
        }


        private void StartAmpTRB_Scroll(object sender, EventArgs e)
        {
            StartAmp_LShow.Text= StartAmpTRB.Value.ToString();
        }
        private void StartAmp_Reset_Click(object sender, EventArgs e)
        {
            StartAmpTRB.Value = StartAmpTRB.Maximum / 2;
            StartAmp_LShow.Text = StartAmpTRB.Value.ToString();
        }
        
        private void RootRateTRB_Scroll(object sender, EventArgs e)
        {
            RootRate_DShow.Text = RootRateTRB.Value.ToString();
        }
        private void RootRate_Reset_Click(object sender, EventArgs e)
        {
            RootRateTRB.Value = 50;
            RootRate_DShow.Text = RootRateTRB.Value.ToString();
        }

        private void BeginDataTRB_Scroll(object sender, EventArgs e)
        {
            BeginData_LShow.Text = BeginDataTRB.Value.ToString();
        }
        private void BeginData_Reset_Click(object sender, EventArgs e)
        {
            BeginDataTRB.Value = 50;
            BeginData_LShow.Text = BeginDataTRB.Value.ToString();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            return;
        }
    }
}

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
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Width = 1440;
            panel1.Height = 810;

            Point btnSize = new Point(OpenBtn.Width, OpenBtn.Height);
            Point btnOpenL = new Point(0, 818);
            Point btnSwL = new Point(btnSize.X, 818);
            Point btnGenL = new Point(0, btnSize.Y + 818);
            Point btnBothL = new Point(btnSize.X, btnSize.Y + 818);
            Point gpL = new Point(btnSize.X * 2, 810);

            OpenBtn.Location = btnOpenL;
            Switch.Location = btnSwL;
            General.Location = btnGenL;
            Both.Location = btnBothL;
            groupBox1.Location = gpL;

            chpy = string.Empty; //汉字拼音
            //tVoice = new Voice();
            tInfo = new VoiceModInfo
            {
                preVoice = false,
                Initbegin = false,
                InitlastU = false,
                areaID = 1
            }; //创建新实例

            //精度相关
            Arate0_Ratio = (double)20 / Arate0TRB.Maximum;
            Arate1_Ratio = (double)2 / Arate1TRB.Maximum;
            Mod_Ratio = (double)2 / BeginTRB.Maximum;
            Amp_Ratio = (double)1 / StartAmpTRB.Maximum;
            Root_Ratio = (double)40 / RootRateTRB.Maximum;

            tVoice = new Voice();
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
            
            tInfo = new VoiceModInfo
            {
                areaID = 2,
                preVoice = false,
                InitlastU = false,
                Initbegin = true,
                beginData = 0.5f,

                begin = -0.8f,
                end = 0.3f,
                ort = -0.001f,//0不变，-1收缩，1膨胀
                RootRate = 8,
                Arate0 = 3,
                Arate1 = -0.08f
            };
            tVoice.ModInfo.Add(tInfo);

            tInfo = new VoiceModInfo
            {
                areaID = 3,
                preVoice = false,
                InitlastU = false,
                Initbegin = false,
                begin = 0.03f,
                end = 1.0f,
                ort = 0.001f,//0不变，-1收缩，1膨胀
                RootRate = 8,
                Arate0 = 3, //收缩时， 为负-则外凸， 为正-则内凹
                Arate1 = -0.08f
            };
            tVoice.ModInfo.Add(tInfo);
        }

        public void LoadDefaultMod()
        {
            int rowCount = 0;
            foreach (var item in tVoice.ModInfo)
            {
                rowCount = AreaGrid.Rows.Add();
                AreaGrid.Rows[rowCount].Cells["AreaID"].Value = item.areaID;
                AreaGrid.Rows[rowCount].Cells["Begin"].Value = Math.Round(item.begin, 2);
                AreaGrid.Rows[rowCount].Cells["End"].Value = Math.Round(item.end, 2);
                AreaGrid.Rows[rowCount].Cells["StartAmp"].Value = Math.Round(item.startAmp, 2);
                AreaGrid.Rows[rowCount].Cells["Ort"].Value = Math.Round(item.ort, 3);

                ModSelect.Items.Add(item.areaID.ToString()+"-Begin:" + Math.Round(item.begin, 2));
            }
            AreaGrid.ClearSelection();
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

        private void NewArea_Click(object sender, EventArgs e)
        {
            int rowCount = 0;
            AreaGrid.Rows[rowCount].Cells["AreaID"].Value = tVoice.infos.Count+1;
            AreaGrid.Rows[rowCount].Cells["Begin"].Value = "null";
            AreaGrid.Rows[rowCount].Cells["End"].Value = "null";
            AreaGrid.Rows[rowCount].Cells["StartAmp"].Value = StartAmpTRB.Value;
            AreaGrid.Rows[rowCount].Cells["Ort"].Value = "4";
            
            tVoice.pinyin = chpy;
            tVoice.ModInfo.Add(tInfo);

            tInfo = new VoiceModInfo() {
                preVoice=false,
                Initbegin=false,
                InitlastU=false,
                areaID = (tVoice.ModInfo.Count + 1)
            };//初始化实例
        }


        private void Arate0TRB_Scroll(object sender, EventArgs e)
        {
            CurMod.Arate0 = Math.Round(Arate0_Ratio * Arate0TRB.Value - 10, 1);
            Arate0_LShow.Text = CurMod.Arate0.ToString();
        }
        private void Arate0_Reset_Click(object sender, EventArgs e)
        {
            Arate0TRB.Value = Arate0TRB.Maximum/2;

            CurMod.Arate0 = Math.Round(Arate0_Ratio * Arate0TRB.Value - 10, 1);
            Arate0_LShow.Text = CurMod.Arate0.ToString();
        }

        private void Arate1TRB_Scroll(object sender, EventArgs e)
        {
            CurMod.Arate1 = Math.Round(Arate1_Ratio * Arate1TRB.Value - 1, 3);
            Arate1_LShow.Text = CurMod.Arate1.ToString();
        }
        private void Arate1_Reset_Click(object sender, EventArgs e)
        {
            Arate1TRB.Value = Arate1TRB.Maximum / 2;

            CurMod.Arate1 = Math.Round(Arate1_Ratio * Arate1TRB.Value - 1, 3);

            Arate1_LShow.Text = CurMod.Arate1.ToString();
        }


        private void StartAmpTRB_Scroll(object sender, EventArgs e)
        {
            CurMod.startAmp = (float)Math.Round(Amp_Ratio * StartAmpTRB.Value, 3);
            StartAmp_LShow.Text= CurMod.startAmp.ToString();
        }
        private void StartAmp_Reset_Click(object sender, EventArgs e)
        {
            StartAmpTRB.Value = StartAmpTRB.Minimum;

            CurMod.startAmp = (float)Math.Round(Amp_Ratio * StartAmpTRB.Value, 3);
            StartAmp_LShow.Text = CurMod.startAmp.ToString();
        }
        
        private void RootRateTRB_Scroll(object sender, EventArgs e)
        {
            CurMod.RootRate= Math.Round(Root_Ratio * RootRateTRB.Value -20, 2);
            RootRate_DShow.Text = CurMod.RootRate.ToString();
        }
        private void RootRate_Reset_Click(object sender, EventArgs e)
        {
            RootRateTRB.Value = RootRateTRB.Maximum / 2 ;

            CurMod.RootRate = Math.Round(Root_Ratio * RootRateTRB.Value-20, 2);
            RootRate_DShow.Text = CurMod.RootRate.ToString();
        }

        private void BeginDataTRB_Scroll(object sender, EventArgs e)
        {
            CurMod.beginData = (float)Math.Round(Amp_Ratio * BeginDataTRB.Value, 3);
            BeginData_LShow.Text = CurMod.beginData.ToString();
        }
        private void BeginData_Reset_Click(object sender, EventArgs e)
        {
            BeginDataTRB.Value = BeginDataTRB.Minimum; ;

            CurMod.beginData = (float)Math.Round(Amp_Ratio * BeginDataTRB.Value, 3);
            BeginData_LShow.Text = CurMod.beginData.ToString();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            return;
        }

        private void BeginTRB_Scroll(object sender, EventArgs e)
        {
            CurMod.begin = Math.Round(Mod_Ratio * BeginTRB.Value - 1, 2);
            Begin_LShow.Text = CurMod.begin.ToString();
        }
        private void Begin_Reset_Click(object sender, EventArgs e)
        {
            BeginTRB.Value = BeginTRB.Maximum / 2;

            CurMod.begin = Math.Round(Mod_Ratio * BeginTRB.Value - 1, 2);
            Begin_LShow.Text = CurMod.begin.ToString();
        }

        private void EndTRB_Scroll(object sender, EventArgs e)
        {
            CurMod.end = Math.Round(Mod_Ratio * EndTRB.Value - 1, 2);
            End_LShow.Text = CurMod.end.ToString();
        }
        private void End_Reset_Click(object sender, EventArgs e)
        {
            EndTRB.Value = EndTRB.Maximum / 2;

            CurMod.end = Math.Round(Mod_Ratio * EndTRB.Value - 1, 2);
            End_LShow.Text = CurMod.end.ToString();
        }

        private void Ort_0_CheckedChanged(object sender, EventArgs e)
        {
            CurMod.ort = 0f;
        }
        private void Ort__1_CheckedChanged(object sender, EventArgs e)
        {
            CurMod.ort = -0.001f;
        }
        private void Ort_1_CheckedChanged(object sender, EventArgs e)
        {
            CurMod.ort = 0.001f;
        }

        private void Initbegin_Set_CheckedChanged(object sender, EventArgs e)
        {
            CurMod.Initbegin = Initbegin_Set.Checked;
        }
        private void PreVoice_Set_CheckedChanged(object sender, EventArgs e)
        {
            CurMod.preVoice = PreVoice_Set.Checked;
        }
        private void InitlastU_Set_CheckedChanged(object sender, EventArgs e)
        {
            CurMod.InitlastU = Initbegin_Set.Checked;
        }

        private void LoadMod_Click(object sender, EventArgs e)
        {
            LoadDefaultMod();
            LoadMod.Enabled = false;
        }

        private void AreaGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //AreaGrid.ClearSelection();
        }

        private void ModSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            char chIndex = ModSelect.SelectedItem.ToString().ElementAt(0);
            CurModIndex = Convert.ToInt16(chIndex.ToString()) - 1;
            CurMod = tVoice.ModInfo[CurModIndex];




            AreaGrid.CurrentCell = AreaGrid[0, CurModIndex];
            AreaGrid.Enabled = false;
        }
    }
}

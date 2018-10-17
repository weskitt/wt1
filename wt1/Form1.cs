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
using System.Runtime.InteropServices;

namespace wt1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;

            panel1.Width = this.Width;
            WaveViewer wv = new WaveViewer();
            wv.GerneralWave();
            
        }


        public void Panel1_Paint(object sender, PaintEventArgs e)
        {
            
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Green);
            SolidBrush bb = new SolidBrush(Color.Black);

            Rectangle rect = new Rectangle(0, 0, panel1.Width, panel1.Height);

            g.FillRectangle(bb, rect);
            g.DrawLine(p, 0, rect.Height / 2, rect.Width, rect.Height / 2);
            WaveViewer wv = new WaveViewer();
            wv.GerneralWave();
            wv.BsToVertex(ref rect);
            g.DrawLines(p, pointFs);
        }

        private void skinTrackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = skinTrackBar1.Value.ToString();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            skinTrackBar1.Value = skinTrackBar1.Maximum/2;
            label1.Text = skinTrackBar1.Value.ToString();
        }


        
        private void openBtn_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    //var fsm = openFileDialog.OpenFile();
                    byte[] srcSizeb = new byte[2];

                    FileStream fsm = new FileStream(filePath, FileMode.Open);
                    fsm.Seek(42, SeekOrigin.Begin);
                    fsm.Read(srcSizeb, 0, 2);
                    int srcDataSize = BitConverter.ToInt16(srcSizeb, 0);

                    byte[] data = new byte[srcDataSize];

                    fsm.Seek(44, SeekOrigin.Begin);
                    fsm.Read(data, 0, srcDataSize);

                    
                    List<Point> lp = new List<Point>();



                    Rectangle rect = new Rectangle(0, 0, panel1.Width, panel1.Height);
                    int t = 0;
                    for (int i = 0; i < srcDataSize/2; i++)
                    {
                        Point point = new Point()
                        {
                            X = i * rect.Width /(srcDataSize/2),
                            Y = BitConverter.ToInt16(data, t) /50 + rect.Height / 2
                        };

                        lp.Add(point);
                        t += 2;
                    }

                    Point[] pcm = lp.ToArray();

                    Graphics g = panel1.CreateGraphics();
                    Pen p = new Pen(Color.Green);
                    SolidBrush bb = new SolidBrush(Color.Black);
                    
                    g.FillRectangle(bb, rect);

                    g.DrawLines(p, pcm);
                }
            }

            //MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
        }
    }
}

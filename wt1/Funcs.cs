using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace wt1
{
    public class Funcs : AllDataBase
    {
        public struct WAVE_HEAD
        {
            public char[] riff_id;            //---4byte,资源交换文件标志:RIFF 
            public int chunkSize;          //4byte,从下个地址到文件结尾的总字节数(不含前8个字节)  
            public char[] wave_fmt;       //---8byte,wav文件标志:WAVE + 4byte,波形文件标志:FMT(最后一位空格符)
            public int formatSize;         //4byte,格式块的大小  
            public short fmttag;               //2byte,格式种类波形编码格式  
            public short channels;         //2byte,波形文件数据中的通道数  
            public int sampleRate;         //4byte,波形文件的采样率  
            public int bytePerSecond;      //4byte,传输速率平均每秒波形音频所需要的记录的字节数  
            public short blockAlign;           //2byte,数据块的对齐一个采样所需要的字节数  
            public short bitPerSample;     //2byte,采样精度声音文件数据的每个采样的位数  
            public short NullChunk;            //2byte,附加信息
            public char[] dataType;       //---4byte,"data"  
            public short dataSize;         //2byte,数据块大小  
        };

        static Graphics gp;
        static Panel p;
        static Rectangle drawRect;
        static List<Point> lp = new List<Point>();
        static string PCMPath = string.Empty;
        static Form fm;
        static public bool isPCMInit =false;
        public static Point[] pcm;

        public static void FuncInit(Panel panel, Form form)
        {
            p = panel;
            gp = panel.CreateGraphics();
            drawRect = new Rectangle(0, 0, panel.Width, panel.Height);
            fm = form;
        }
        // FileStream读取文件
        public static string FileStreamReadFile(string filePath)
        {
            byte[] data = new byte[100];
            char[] charData = new char[100];
            FileStream file = new FileStream(filePath, FileMode.Open);

            //文件指针指向0位置
            file.Seek(0, SeekOrigin.Begin);
            //读入两百个字节
            file.Read(data, 0, (int)file.Length);
            //提取字节数组
            Decoder dec = Encoding.UTF8.GetDecoder();
            dec.GetChars(data, 0, data.Length, charData, 0);
            return Convert.ToString(charData);
        }

        // 用FileStream写文件
        public static void FileStreamWriteFile(string filePath, string str)
        {
            byte[] byData;
            char[] charData;
            try
            {
                FileStream nFile = new FileStream(filePath + "love.txt", FileMode.Create);
                //获得字符数组
                charData = str.ToCharArray();
                //初始化字节数组
                byData = new byte[charData.Length];
                //将字符数组转换为正确的字节格式
                Encoder enc = Encoding.UTF8.GetEncoder();
                enc.GetBytes(charData, 0, charData.Length, byData, 0, true);
                nFile.Seek(0, SeekOrigin.Begin);
                nFile.Write(byData, 0, byData.Length);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void OpenWaveDialog()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\Users\\weskitt\\OneDrive\\wav";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    byte[] dataSizeByte = new byte[2];
                    PCMPath = openFileDialog.FileName;

                    var fsm = openFileDialog.OpenFile(); //FileStream fsm = new FileStream(filePath, FileMode.Open);
                    fsm.Seek(42, SeekOrigin.Begin);
                    fsm.Read(dataSizeByte, 0, 2);
                    int dataSizeInt = BitConverter.ToInt16(dataSizeByte, 0);

                    byte[] data = new byte[dataSizeInt];

                    fsm.Seek(44, SeekOrigin.Begin);
                    fsm.Read(data, 0, dataSizeInt);

                    int t = 0;
                    lp = new List<Point>();
                    for (int i = 0; i < dataSizeInt / 2; i++)
                    {
                        Point point = new Point()
                        {
                            X = i * drawRect.Width / (dataSizeInt / 2),
                            Y = BitConverter.ToInt16(data, t) / 50 + drawRect.Height / 2
                        };

                        lp.Add(point);
                        t += 2;
                    }
                }

                isPCMInit = true;
                //MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
            }
            
            pcm = lp.ToArray();
        }

        public static void DrawPCMWave()
        {
            Pen pen = new Pen(Color.Green);
            SolidBrush bb = new SolidBrush(Color.Black);

            gp.FillRectangle(bb, drawRect);

            gp.DrawLines(pen, pcm);

            fm.Text = PCMPath;
        }

    }
}

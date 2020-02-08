using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Web.UI;
//using System.Collections.Generic;

namespace wt1
{ 
    public class Funcs
    {
        internal class WAVE_s
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
            public string WavPath;
            public string WavName;
            public ArrayList dataArray, keyArray, keyLocArray, keyDiffArray;
            public Point[] dataPoint;
            public int period;
        };

        internal WAVE_s wavs = new WAVE_s();
        public static bool isPCMInit =false;

        public bool Paint(Panel panel, ArrayList dataArray)
        {
            var gp = panel.CreateGraphics();
            var drawRect = new Rectangle(0, 0, panel.Width, panel.Height);
            var pen = new Pen(Color.Green);
            var bb = new SolidBrush(Color.Black);
            var dataPoint = new Point[dataArray.Count];

            for (int i = 0; i < dataArray.Count; i++)
            {
                dataPoint[i].X = i * panel.Width / dataArray.Count;
                dataPoint[i].Y = (Int16)dataArray[i] / 50 + panel.Height / 2;
            }

            gp.FillRectangle(bb, drawRect);
            gp.DrawLines(pen, dataPoint);
            gp.DrawLine(pen, 0, drawRect.Height / 2, drawRect.Width, drawRect.Height / 2);

            return true;
        }
        public  bool ReadWaveFile() 
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\Users\\weskitt\\OneDrive\\wav";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    wavs.WavPath = openFileDialog.FileName; //获取文件路径
                    wavs.WavName = openFileDialog.SafeFileName;//获取文件名
                    var fsm = openFileDialog.OpenFile();

                    byte[] dataSize_Byte = new byte[2];
                    fsm.Seek(42, SeekOrigin.Begin); //定位储存数据大小处,检查数据大小
                    fsm.Read(dataSize_Byte, 0, 2);
                    wavs.dataSize = BitConverter.ToInt16(dataSize_Byte, 0);

                    byte[] data = new byte[wavs.dataSize];//读取数据
                    fsm.Seek(44, SeekOrigin.Begin);
                    fsm.Read(data, 0, wavs.dataSize);
                    wavs.dataSize /= 2;
                    wavs.WavName = wavs.WavName.Replace(".wav", "");
                    wavs.dataArray = new ArrayList();
                    int t = 0;
                    for (int i = 0; i < wavs.dataSize; i++)
                    {
                        wavs.dataArray.Add(BitConverter.ToInt16(data, t));
                        t += 2;
                    }
                    isPCMInit = true;
                    WaveAzProcess();
                }
            }
            return true;
        }
        public void SplitKeydata()
        {
            int diff, index = 0;
            Int16 tmpData = 0;
            bool upFlag = false;
            bool downFlag = false;
            bool keyFlag = false;
            wavs.keyLocArray = new ArrayList();
            wavs.keyArray = new ArrayList();
            foreach (Int16 item in wavs.dataArray)
            {
                if (item != 0 && tmpData != 0)
                {
                    diff = item - tmpData;
                    if (diff > 0)//步入递增
                    {
                        upFlag = true;
                        if (downFlag) //判断前面是否有递减标记,触发记录
                        {
                            keyFlag = true;
                            downFlag = false;//关闭标记，避免再次触发记录 得到
                        }
                    }
                    else if (diff < 0)//步入递减
                    {
                        downFlag = true;
                        if (upFlag) //判断前面是否递增标记,触发记录
                        {
                            keyFlag = true;
                            upFlag = false;//关闭标记，避免再次触发记录
                        }

                    }
                    else if (diff == 0)
                    {
                        keyFlag = true;
                        upFlag = false;
                        downFlag = false;
                    }
                }
                if (keyFlag)
                {
                    keyFlag = false;
                    //if ((Int16)wavs.dataArray[index-1]>0) //记录大于零的数据，方便计算周期
                    wavs.keyLocArray.Add(index - 1);
                    wavs.keyArray.Add((wavs.dataArray[index - 1]));
                }
                else wavs.keyArray.Add((Int16)0);
                tmpData = item;
                ++index;
            }
        }
        public void AnalyzePeriod() 
        {
            int tmpA=0;
            wavs.keyDiffArray = new ArrayList();
            for (int index = 0; index < wavs.keyArray.Count; index++)
            {
                var perd = new Period();
                var item = (short)wavs.keyArray[index];
                if (item != 0 && tmpA != 0)
                {
                    perd.diff = item - tmpA;
                    perd.index = index-1;
                }
                wavs.keyDiffArray.Add(perd);
                tmpA = item;
            }

            var periodTemplateArray = new ArrayList();
            foreach (Period item in wavs.keyDiffArray)
            {

                periodTemplateArray.Add(item);
            }
        }
        public bool WaveAzProcess()
        {
            SplitKeydata(); //分离极点数据出来
            AnalyzePeriod();//分析周期
            return true;
        }
        public string DrawOriginData(Panel panel, Form form)
        {
            Paint(panel, wavs.dataArray);
            form.Text = wavs.WavPath;
            return wavs.WavName;
        }
        public void DrawGerneralData(Panel panel, Form form)
        {

            Paint(panel, wavs.keyArray);
            form.Text = "由GerneralWave()函数生成";
        }
    }
}

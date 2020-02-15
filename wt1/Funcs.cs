using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;

namespace wt1
{
    public class Funcs
    {
        
        internal WAVE_s wavs = new WAVE_s();
        public static void Paint(Panel panel, ArrayList dataArray, int dataCount)
        {
            var gp = panel.CreateGraphics();
            var drawRect = new Rectangle(0, 0, panel.Width, panel.Height);
            var pen = new Pen(Color.Green);
            var bb = new SolidBrush(Color.Black);
            var dataPoint = new Point[dataArray.Count];
            int index = 0;
            foreach (SampleData item in dataArray)
            {
                dataPoint[index].X = item.location * panel.Width / dataCount ;
                //dataPoint[index].X = item.index-3000;
                dataPoint[index].Y = item.value / 50 + panel.Height / 2;
                ++index;
            }

            gp.FillRectangle(bb, drawRect);
            gp.DrawLines(pen, dataPoint);
            gp.DrawLine(pen, 0, drawRect.Height / 2, drawRect.Width, drawRect.Height / 2);

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
                    SampleData spd;
                    for (int i = 0; i < wavs.dataSize; i++)
                    {
                        spd = new SampleData( BitConverter.ToInt16(data, t) ,  i);
                        wavs.dataArray.Add(spd);
                        t += 2;
                    }
                    WaveAzProcess();
                }
            }
            return true;
        }
        public static int Compet(int a, int b)
        { 
            if ((a - b) > 0) return 1;
            else if ((a - b) < 0) return -1;
            else  return 0;
        }
        public void SplitKeydata()
        {
            var preData=new SampleData();
            bool upFlag = false;
            bool downFlag = false;
            bool keyFlag = false;
            const int Down = -1;
            const int UP = 1;
            const int Zero = 0;
            wavs.keyArray = new ArrayList();
            foreach (SampleData item in wavs.dataArray)
            {
                switch(Compet(item.value , preData.value))
                {
                    case UP://步入递增
                        upFlag = true;
                        if (downFlag) //判断前面是否有递减标记,触发记录
                        {
                            keyFlag = true;
                            downFlag = false;//关闭标记，避免再次触发记录 得到
                        }
                        break;
                    case Down://步入递减
                        downFlag = true;
                        if (upFlag) //判断前面是否递增标记,触发记录
                        {
                            keyFlag = true;
                            upFlag = false;//关闭标记，避免再次触发记录
                        }
                        break;
                    case Zero://等值
                        if(preData.value != 0) 
                            keyFlag = true;
                        upFlag = false;
                        downFlag = false;
                        break;
                }

                if (keyFlag)
                {
                    keyFlag = false;
                    wavs.keyArray.Add(preData);
                }
                preData = item;
            }
        }
        public void AnalyzePeriod() 
        {            
            wavs.keyDiffArray = new ArrayList();
            var preData = new SampleData();
            SortedSet<SampleData> lsdA = new SortedSet<SampleData>(new SampleCompare()); //上
            SortedSet<SampleData> lsdB = new SortedSet<SampleData>(new SampleCompare()); //下

            foreach (SampleData item in wavs.keyArray)
            {
                if (item.value > 0)
                    lsdA.Add(item);  //正区
                else
                    lsdB.Add(item);  //负区
            }

            //int minimum = 100;//最低周期保守值
            
            
            
            bool upFlag = false;
            var preItem = new Period();
            wavs.tmpArray = new ArrayList();
            //var periodTemplateArray = new ArrayList();
            foreach (Period item in wavs.keyDiffArray)
            {
                if (item.diff > preItem.diff)  
                    upFlag = true;
                else if (item.diff < preItem.diff )
                {
                    if (upFlag)
                    {
                        upFlag = false;
                        SampleData smp = new SampleData();
                        smp =(SampleData)wavs.dataArray[preItem.index];
                        wavs.tmpArray.Add(smp);
                    }
                }
                preItem = item;
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
            Paint(panel, wavs.dataArray, wavs.dataSize);
            form.Text = wavs.WavPath;
            return wavs.WavName;
        }
        public void DrawGerneralData(Panel panel, Form form)
        {
            //Paint(panel, wavs.tmpArray, wavs.dataSize);
            Paint(panel, wavs.keyArray, wavs.dataSize);
            form.Text = "由GerneralWave()函数生成";
        }
    }
}

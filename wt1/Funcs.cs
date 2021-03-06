﻿using System;
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
        public static int drawStep = 0;
        public static int density = 1; 
        //绘制部分
        public static void Paint(Panel panel, List<SampleData> dataArray, int dataCount)
        {
            var gp = panel.CreateGraphics();
            var drawRect = new Rectangle(0, 0, panel.Width, panel.Height);
            var pen = new Pen(Color.Green);
            var bb = new SolidBrush(Color.Black);
            var dataPoint = new Point[dataArray.Count];
            int index = 0;
            foreach (var item in dataArray)
            {
                dataPoint[ index ].X = item.location * panel.Width / dataCount ;
                //dataPoint[ index ].X = (item.location - drawStep) * density;
                dataPoint[ index ].Y = item.value / 50 + panel.Height / 2;
                ++index;
            }

            gp.FillRectangle(bb, drawRect);
            gp.DrawLines(pen, dataPoint);
            gp.DrawLine(pen, 0, drawRect.Height / 2, drawRect.Width, drawRect.Height / 2);

        }
        //读取文件部分
        public  bool ReadWaveFile() 
        {
            string path = @"C:\Users\weskitt\OneDrive\wav\Test.wav";
            string wavpath= @"C:\Users\weskitt\OneDrive\wav";
            FileStream fs = File.Create(path);

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = wavpath;
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    wavs.WavPath = openFileDialog.FileName; //获取文件路径
                    wavs.WavName = openFileDialog.SafeFileName;//获取文件名
                    var fsm = openFileDialog.OpenFile();

                    byte[] wavHeader = new byte[42];
                    fsm.Read(wavHeader, 0, 42);
                    fs.Write(wavHeader, 0, 42);
                    //fs.Close();
                    byte[] dataSize_Byte = new byte[2];
                    fsm.Seek(42, SeekOrigin.Begin); //定位储存数据大小处,检查数据大小
                    fsm.Read(dataSize_Byte, 0, 2);
                    wavs.dataSize = BitConverter.ToInt16(dataSize_Byte, 0);

                    byte[] data = new byte[wavs.dataSize];//读取数据
                    fsm.Seek(44, SeekOrigin.Begin); //wav头44byte
                    fsm.Read(data, 0, wavs.dataSize);
                    //fsm.Write()
                    wavs.dataSize /= 2;
                    wavs.WavName = wavs.WavName.Replace(".wav", "");
                    wavs.sourceArray = new List<SampleData>();
                    int t = 0;
                    SampleData spd;
                    for (int i = 0; i < wavs.dataSize; i++)
                    {
                        spd = new SampleData( BitConverter.ToInt16(data, t) ,  i);
                        wavs.sourceArray.Add(spd);
                        t += 2;
                    }
                    WaveAzProcess();
                }
            }
            return true;
            
        }
        //功能函数部分
        public static int Compet(int a, int b)
        { 
            if (a > b) return 1;
            else if (a < b) return -1;
            else  return 0;
        }
        public void SplitKeydata()
        {
            bool upFlag = false;
            bool downFlag = false;
            bool keyFlag = false;
            const int Down = -1;
            const int UP = 1;
            const int Zero = 0;
            var preData = new SampleData();
            wavs.keyArray = new List<SampleData>(); //初始化 峰谷数据集合
            wavs.peakList  = new List<SampleData>(); //初始化 峰数据包
            wavs.valleyList = new List<SampleData>(); //初始化 谷数据包
            foreach (var item in wavs.sourceArray)
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
                        //if(preData.value != 0) 
                        //    keyFlag = true;
                        //upFlag = false;
                        //downFlag = false;
                        break;
                }

                if (keyFlag)
                {
                    keyFlag = false;//关闭标记，进入下个循环
                    wavs.keyArray.Add(preData); //记录入峰谷集合
                    if (downFlag)
                        wavs.peakList.Add(preData); //记录入峰数据包
                    if (upFlag)
                        wavs.valleyList.Add(preData); //记录入谷数据包
                }
                preData = item;
            }
        }
        public void AnalyzePeriod() // 相邻最大值周期获取算法
        {
            // 相邻最大值周期获取算法
            int minPeriod = 50;//定义最小周期用于排除前置非周期数据
            wavs.keyDiffArray = new List<SampleData>(); //初始化峰谷位移数据包
            //**************************分离正负样本并排序*************************************************用于采集峰谷最大值
            var posSet    = new SortedSet<SampleData>(new ByValueCompare() ); //正数集合以value排序
            var negSet = new SortedSet<SampleData>(new ByValueCompare()); //负数集合以value排序
            SampleData spd;
            foreach (SampleData item in wavs.keyArray)
            {
                if (item.value > 0)
                    posSet.Add(item);  //正区
                else if (item.value < 0)  {
                    spd = new SampleData { value = Math.Abs(item.value),  location = item.location  }; //采集负数区样本并取正
                    negSet.Add(spd); //负区
                }
                
            }
            //List<SampleData> _plusList = new List<SampleData>(plusSet);
            //**************************采取20个最大值value样本*******************************************
            //**************************以Location排序******************************************************
            int smpCount = 20; 
            int tcount = smpCount;
            var LocListAtPosSet    = new List<int>();//20个最大正数集合
            var LocListAtNegSet = new List<int>();//20个最小负数集合
            foreach (var item in posSet)
            {
                LocListAtPosSet.Add(item.location);
                if (--tcount == 0) //判断采集完成后恢复Location序列排序并跳出
                {
                    tcount = smpCount;
                    LocListAtPosSet.Sort();
                    break;
                }
            }
            foreach (var item in negSet)
            {
                LocListAtNegSet.Add(item.location);
                if (--tcount == 0)//判断采集完成后恢复Location序列排序并跳出
                {
                    tcount = smpCount;
                    LocListAtNegSet.Sort();
                    break;
                }
            }

            //*******************************分析相邻间距获取周期******************************************
            int perSamp; //周期样本
            var perSampDic = new Dictionary<int, int>();//周期候选样本集合
            //List<int> ht = new List<int>();
            var preDataA = LocListAtPosSet[0];
            var preDataB = LocListAtNegSet[0];
            for (int c = 1; c < smpCount; c++)
            {
                perSamp = Math.Abs(LocListAtPosSet[c] - preDataA);
                if (perSampDic.ContainsKey(perSamp))
                    perSampDic[perSamp] += 1;
                else if(perSamp > minPeriod) //剔除小于最小周期的样本
                    perSampDic.Add(perSamp, 1);

                perSamp = Math.Abs(LocListAtNegSet[c] - preDataB);
                if (perSampDic.ContainsKey(perSamp))
                    perSampDic[perSamp] += 1;
                else if (perSamp > minPeriod)//剔除小于最小周期的样本
                    perSampDic.Add(perSamp, 1);


                preDataA = LocListAtPosSet[c];
                preDataB = LocListAtNegSet[c];
            }

            var list = new List<KeyValuePair<int, int>>(perSampDic);
            //list.Sort(delegate (KeyValuePair<int, int> s1, KeyValuePair<int, int> s2) {
            //    return s2.Key.CompareTo(s1.Key);
            //});
            //wavs.per_deviation = list[0].Key - list[1].Key;//粗略周期偏差 

            list.Sort(delegate(KeyValuePair<int, int> s1, KeyValuePair<int, int> s2){
                return s2.Value.CompareTo(s1.Value);
            });
            perSampDic.Clear();
            foreach (KeyValuePair<int, int> pair in list)
                if (pair.Value > 2) //记录候选权值大于2的周期值
                    perSampDic.Add(pair.Key, pair.Value);

            wavs.period = list[0].Key;
            wavs.per_deviation = Math.Abs(list[0].Key - list[1].Key);//粗略周期偏差 
            //*******************以下分析周期内各相分布状态***************************************************
            var _plusList = new List<SampleData>(posSet);
            int cur = _plusList[0].location; //默认以最大值来定义初始相位
            int curEnd = cur + wavs.period;
            Phase phase = new Phase
            {
                Amplitude = _plusList[0].value,
                step = 0
            };
            wavs.phsaePack = new List<Phase>{ phase };//添加默认初始相
            foreach (var item in wavs.peakList)
            {
                if ( cur < item.location && item.location <= curEnd)
                {
                    phase = new Phase {
                        Amplitude = item.value,
                        step = item.location - cur
                    };
                    wavs.phsaePack.Add(phase);
                }
            }

        }
        public void WaveAzProcess()
        {
            SplitKeydata(); //分离极点数据出来
            AnalyzePeriod();//分析周期

        }
        public string DrawOriginData(Panel panel, Form form)
        {
            Paint(panel, wavs.sourceArray, wavs.dataSize);
            form.Text = wavs.WavPath;
            return wavs.WavName;
        }
        public int DrawGerneralData(Panel panel, Form form)
        {
            //Paint(panel, wavs.tmpArray, wavs.dataSize);
            Paint(panel, wavs.keyArray, wavs.dataSize);
            form.Text = "由GerneralWave()函数生成";
            return wavs.period;
        }
        public int ReturnPeriod() { return wavs.period; }
        public int ReturnPeriodDeviation() { return wavs.per_deviation; }
    }
}

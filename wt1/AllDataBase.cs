using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wt1
{
    public class AllDataBase
    {
        public class WaveRichPoint
        {
            public int index;
            public float value;
            public int invertPoint; //反转点 ，Y轴值
            public int areaID;
        };

        public static double Mod_Ratio;
        public static double Arate0_Ratio;
        public static double Arate1_Ratio;
        public static double Amp_Ratio;
        public static double Root_Ratio;

        public class VoiceModInfo 
        {
            public int areaID;
            public double begin; //区域描述起点//-1  -----   1    0.01分辨率
            public double end;   //区域描述终点

            public float beginData; //0  -----   1    0.001分辨率
            public bool Initbegin; //弃用
            public bool preVoice;//判断是否预发音前置区
            public float startAmp; //-1  -----   1    0.001分辨率
            public bool InitlastU; //弃用

            public double ort;
            public double RootRate; //-20  -----   20    0.01分辨率
            public double Arate=99999;
            public double Arate0;//-10---10  200  0.1分辨率
            public double Arate1;//-1---1  2000  0.001分辨率
            //public double Arate2;
            //public float baseN;

            public void Fusion(SortedDictionary<int, WaveRichPoint> bvs, int index,ref float lastU)
            {
                if (preVoice)   //判断是否前置区
                {
                    if (lastU<0)
                        lastU = startAmp;

                    bvs[index].value = lastU;
                    lastU = bvs[index].value;
                }
                else
                {
                    if (lastU<0)
                        lastU = beginData;

                    if (Arate==99999)
                        Arate = Arate0;
                    
                    Arate += Arate1;
                    float baseN = (float)(Arate * RootRate * ort);
                    bvs[index].value = lastU + baseN;
                    lastU = bvs[index].value;
                }
            }
        };

        public class Voice
        {
            //public string[] glyphs; //符号，用于存储显示字符 同音字
            public string pinyin; //符号发音
            //public int tone;  //声调


            public SortedDictionary<int, VoiceModInfo> infos = new SortedDictionary<int, VoiceModInfo>();
            public List<VoiceModInfo> ModInfo = new List<VoiceModInfo>();
            public SortedDictionary<int, int> keyData = new SortedDictionary<int, int>();  //间断不连续关键帧数据
            public List<int> data = new List<int>(); //发音具体数据
        };


        public static SortedDictionary<string, Voice> VoiceData = new SortedDictionary<string, Voice>();  //汉字， 发音数据

        public static double General_x(int curX)
        {
            return -1.0f + (curX / (double)(1920 - 1)) * 2.0f;
        }

    }
}

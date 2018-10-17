using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wt1
{
    public class AllDataBase
    {
        public class BaseVoiceSamp
        {
            public int index;
            public float value;
            public int invertPoint; //反转点 ，Y轴值
            public int areaID;

        };
        public class VoiceModInfo
        {
            public int areaID;
            public float begin; //区域描述起点
            public float end;   //区域描述终点
            public int countEnd;
            public float beginData;
            public bool Initbegin = false;
            public bool preVoice = false;
            public float startAmp;
            public bool InitlastU = false;

            public float ort;
            public float RootRate;
            public float Arate0; //附加变化率，用于修改主rate，实现:变加速，变减速
            public float Arate1;
            public float Arate2;
            public float baseN;

            public void Fusion(SortedDictionary<int, BaseVoiceSamp> bvs, int index,ref float lastU)
            {
                if (preVoice)
                {
                    if (InitlastU)
                    {
                        lastU = startAmp;
                        InitlastU = false;
                    }
                    bvs[index].value = lastU;
                    lastU = bvs[index].value;
                }
                else
                {
                    if (Initbegin)
                    {
                        lastU = beginData;
                        Initbegin = false;
                    }
                    //counter += 1; //加速参数
                    Arate0 += Arate1;
                    baseN = Arate0 * RootRate * ort;
                    bvs[index].value = lastU + baseN;
                    lastU = bvs[index].value;
                }
            }
        };

        public class Voice
        {
            public string symbol; //符号，用于存储显示字符
            public string pinyin; //符号发音
            public int tone;  //声调

            public SortedDictionary<int, VoiceModInfo> info = new SortedDictionary<int, VoiceModInfo>();
            public List<VoiceModInfo> ModInfo = new List<VoiceModInfo>();
            public SortedDictionary<int, int> keyData = new SortedDictionary<int, int>();  //间断不连续关键帧数据
            public List<int> data = new List<int>(); //发音具体数据
        };


        public static SortedDictionary<string, Voice> VoiceData = new SortedDictionary<string, Voice>();  //汉字， 发音数据

        public static float General_x(int curX)
        {
            return -1.0f + (curX / (float)(1920 - 1)) * 2.0f;
        }

    }
}

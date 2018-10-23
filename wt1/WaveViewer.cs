using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using static wt1.AllDataBase;

namespace wt1
{
    public static class WaveViewer
    {
        public static int PCMSamCount;
        public static int BaseSamCount;
        public static float preIter;
        public static float dataIter;
        public static bool isGeneralShow =false;
        public static bool isInitExample = false;

        public static VoiceModInfo tInfo;
        public static Voice tVoice;
        public static string chpy;
        public static int CurModIndex;
        public static VoiceModInfo CurMod;
        //double lastD;

        public static SortedDictionary<int, WaveRichPoint> BaseWaveSingle = new SortedDictionary<int, WaveRichPoint>();
        public static SortedDictionary<int, WaveRichPoint> BaseSamps = new SortedDictionary<int, WaveRichPoint>();
        public static List<PointF> listPoints = new List<PointF>();
        public static PointF[] pointFs;

        public static void InitExample()
        {
            tVoice = new Voice();
            tInfo = new VoiceModInfo
            {
                areaID = 0,
                preVoice = true,
                startAmp = 0.03f,
                begin = -1.0f,
                end = -0.8f
            };
            tVoice.ModInfo.Add(tInfo);

            tInfo = new VoiceModInfo
            {
                areaID = 1,
                preVoice = false,
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
                areaID = 2,
                preVoice = false,

                begin = 0.03f,
                end = 1.0f,
                ort = 0.001f,//0不变，-1收缩，1膨胀
                RootRate = 8,
                Arate0 = 3, //收缩时， 为负-则外凸， 为正-则内凹
                Arate1 = -0.08f
            };
            tVoice.ModInfo.Add(tInfo);
        }

        public static void GerneralWave()
        {

            //bsiter.Current.Key;
            //创建base基本数据
            float preAmp = 0.000000001f;
            int diffStep = 1;
            int T_step = 28;
            int PackStep = diffStep + T_step;
            int PairCount = 1920 / PackStep;
            BaseSamCount = PairCount * 2;

            BaseWaveSingle = new SortedDictionary<int, WaveRichPoint>();

            for (int i = 0; i < PairCount; i++)
            {
                WaveRichPoint t_bvs = new WaveRichPoint
                {
                    index = i * PackStep,
                    value = preAmp,
                    invertPoint = 0,
                    areaID = 0
                };
                //BaseSamps[t_bvs.index] = t_bvs; //重复，覆盖
                BaseWaveSingle.Add(t_bvs.index, t_bvs);
            }

            /******************************************************************/
            //塑形计算   数据修饰.
            if (!isInitExample)
            {
                InitExample();
                isInitExample = true;
            }
            
            preIter = -1;
            dataIter = -1;
            int modIndex = 0;

            var BSkeys = new List<int>(BaseWaveSingle.Keys);

            for (int i = 0; i < BSkeys.Count; i++)
            {
            NewMod:
                var bsv = BaseWaveSingle[BSkeys[i]];
                double SampIndex = General_x(bsv.index);

                if (SampIndex >= tVoice.ModInfo[modIndex].begin && SampIndex < tVoice.ModInfo[modIndex].end)
                {
                    if (tVoice.ModInfo[modIndex].preVoice)
                        tVoice.ModInfo[modIndex].Fusion(BaseWaveSingle, BSkeys[i], ref preIter);
                    else
                        tVoice.ModInfo[modIndex].Fusion(BaseWaveSingle, BSkeys[i], ref dataIter);

                }
                else
                {
                    //仅适用于preVoice前置区无Arate的情况
                    ++modIndex;  //切换mod
                    tVoice.ModInfo[modIndex].ArateReset();  //使用下个mod前重置Arate
                    goto NewMod;
                }
            }

            /******************************************************************/
            //数据补完
            //一:补全逆转数据
            BaseSamps = new SortedDictionary<int, WaveRichPoint>(); 
            foreach (var samp in BaseWaveSingle)
            {
                WaveRichPoint t_bvs = new WaveRichPoint
                {
                    index = samp.Value.index + diffStep,
                    invertPoint = samp.Value.invertPoint,
                    value = samp.Value.invertPoint - samp.Value.value
                };

                BaseSamps[samp.Value.index] = samp.Value;
                BaseSamps[t_bvs.index] = t_bvs;
            }
            
        }

        public static void BsToVertex(ref Rectangle rect)
        {
            listPoints = new List<PointF>();

            foreach (var bs in BaseSamps)
            {
                PointF point = new PointF
                {
                    X = bs.Value.index * rect.Width / 1920,
                    Y = bs.Value.value * (rect.Height / 2) + rect.Height / 2
                };
                listPoints.Add(point);
            }

            pointFs = listPoints.ToArray();
            //pointFs = new PointF[](listPoints.ToArray);
        }
    }
}

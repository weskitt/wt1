using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using static wt1.AllDataBase;

namespace wt1
{
    public class WaveViewer
    {
        public int PCMSamCount;
        public int BaseSamCount;
        public float lastU;
        public static bool isGeneralShow =false;

        public static VoiceModInfo tInfo;
        public static Voice tVoice;
        //float lastD;

        public SortedDictionary<int, BaseVoiceSamp> BaseSampSingle = new SortedDictionary<int, BaseVoiceSamp>();
        public SortedDictionary<int, BaseVoiceSamp> BaseSamps = new SortedDictionary<int, BaseVoiceSamp>();
        public List<PointF> listPoints = new List<PointF>();
        public static PointF[] pointFs;

        public void GerneralWave()
        {

            //bsiter.Current.Key;
            //创建base基本数据
            float preAmp = 0.000000001f;
            int diffStep = 1;
            int T_step = 28;
            int PackStep = diffStep + T_step;
            int PairCount = 1920 / PackStep;
            BaseSamCount = PairCount * 2;

            for (int i = 0; i < PairCount; i++)
            {
                BaseVoiceSamp t_bvs = new BaseVoiceSamp
                {
                    index = i * PackStep,
                    value = preAmp,
                    invertPoint = 0,
                    areaID = 0
                };
                //BaseSamps[t_bvs.index] = t_bvs; //重复，覆盖
                BaseSampSingle.Add(t_bvs.index, t_bvs); //
                //BSkeys.Add(t_bvs.index);
            }

            /******************************************************************/
            //塑形计算   数据修饰.


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

            lastU = preAmp;
            int modIndex = 0;
            //var bsiter = BaseSampSingle.GetEnumerator();
            var BSkeys = new List<int>(BaseSampSingle.Keys);

            for (int i = 0; i < BSkeys.Count; i++)
            {
            NewMod:
                var bsv = BaseSampSingle[BSkeys[i]];
                float SampIndex = General_x(bsv.index);

                if (SampIndex >= tVoice.ModInfo[modIndex].begin && SampIndex < tVoice.ModInfo[modIndex].end)
                {
                    tVoice.ModInfo[modIndex].Fusion(BaseSampSingle, BSkeys[i], ref lastU);
                }
                else
                {
                    ++modIndex;
                    goto NewMod;
                }
            }

            /******************************************************************/
            //数据补完
            //一:补全逆转数据
            foreach (var samp in BaseSampSingle)
            {
                BaseVoiceSamp t_bvs = new BaseVoiceSamp
                {
                    index = samp.Value.index + diffStep,
                    invertPoint = samp.Value.invertPoint,
                    value = samp.Value.invertPoint - samp.Value.value
                };

                BaseSamps[samp.Value.index] = samp.Value;
                BaseSamps[t_bvs.index] = t_bvs;
            }
            
        }

        public void BsToVertex(ref Rectangle rect)
        {
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

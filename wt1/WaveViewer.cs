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
        public static string chpy;
        public static int CurModIndex;
        public static VoiceModInfo CurMod;
        //double lastD;

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




            lastU = preAmp;
            int modIndex = 0;
            //var bsiter = BaseSampSingle.GetEnumerator();
            var BSkeys = new List<int>(BaseSampSingle.Keys);

            for (int i = 0; i < BSkeys.Count; i++)
            {
            NewMod:
                var bsv = BaseSampSingle[BSkeys[i]];
                double SampIndex = General_x(bsv.index);

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

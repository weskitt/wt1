using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static wt1.AllDataBase;

namespace wt1
{
    class WaveViewer
    {
        public int PCMSamCount;
        public int BaseSamCount;
        public float lastU;
        float lastD;

        public SortedDictionary<int, BaseVoiceSamp> BaseSampMap = new SortedDictionary<int, BaseVoiceSamp>();
        public SortedDictionary<int, BaseVoiceSamp> BaseSampMap2 = new SortedDictionary<int, BaseVoiceSamp>();

        public void GerneralWave()
        {
            //创建base基本数据
            float preAmp = 0.000000001f;
            int diffStep = 1;
            int T_step = 28;
            int PackStep = diffStep + T_step;
            int PairCount = 1920 / PackStep;
            BaseSamCount = PairCount * 2;
            
            for (int i = 0; i < PairCount; i++)
            {
                BaseVoiceSamp t_bvs;

                t_bvs.index = i * PackStep;
                t_bvs.value = preAmp;
                t_bvs.invertPoint = 0;
                t_bvs.areaID = 0;
                //BaseSampMap[t_bvs.index] = t_bvs; //重复，覆盖
                BaseSampMap.Add(t_bvs.index, t_bvs); //
            }

            /******************************************************************/
            //塑形计算   数据修饰.
            PhonationInfo tInfo;
            Voice tVoice = new Voice();

            tInfo = new PhonationInfo
            {
                areaID = 1,
                preVoice = true,
                InitlastU = true,
                Initbegin = false,

                startAmp = 0.03f,
                begin = -1.0f,
                end = -0.8f
            };
            tVoice.vinfo.Add(tInfo);

            tInfo = new PhonationInfo
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
            tVoice.vinfo.Add(tInfo);

            tInfo = new PhonationInfo
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
            tVoice.vinfo.Add(tInfo);


        }
    }
}

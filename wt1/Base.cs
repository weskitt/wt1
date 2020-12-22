using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace wt1
{
    public struct Phase //描述周期内各相分布情况
    {
        public int step; //与初始相位移
        public int Amplitude; //最大振幅
    }

    public struct SampleData
    {
        public int value, location;
        public SampleData(int value=0, int loc = 0)
        {
            this.value = value;
            this.location = loc;
        }

        //public static bool operator > (SampleData left, SampleData right)
        //{
        //    if (left.value > right.value)
        //        return true;
        //    else
        //        return false;
        //}
        //public static bool operator < (SampleData left, SampleData right)
        //{
        //    return !(left > right);
        //}
        //public static bool operator ==(SampleData left, SampleData right)
        //{
        //    if (left.value == right.value)
        //        return true;
        //    else
        //        return false;
        //}
        //public static bool operator !=(SampleData left, SampleData right)
        //{
        //    return !(left == right);
        //}

        //public override bool Equals(object obj)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public override int GetHashCode()
        //{
        //    throw new System.NotImplementedException();
        //}
    }
    public class ByValueCompare : IComparer<SampleData>
    {
        public int Compare(SampleData x, SampleData y)
        {
            if (y.value == x.value)
                return 1;
            else
                return y.value - x.value;
        }
    }
    public class ByLoctionCompare : IComparer<SampleData>
    {
        public int Compare(SampleData x, SampleData y)
        {
            if (y.location == x.location)
                return 1;
            else
                return y.location - x.location;
        }
    }


    internal class WAVE_s
    {
        /*13150
        public char[] riff_id;            //---4byte,资源交换文件标志:RIFF 
        public int chunkSize;          //4byte,从下个地址到文件结尾的总字节数(不含前8个字节)  
        public char[] wave_fmt;       //---8byte,wav文件标志:WAVE + 4byte,波形文件标志:FMT(最后一位空格符)
        public int formatSize;         //4byte,格式块的大小  20
        public short fmttag;               //2byte,格式种类波形编码格式  
        public short channels;         //2byte,波形文件数据中的通道数  
        public int sampleRate;         //4byte,波形文件的采样率  
        public int bytePerSecond;      //4byte,传输速率平均每秒波形音频所需要的记录的字节数  12
        public short blockAlign;           //2byte,数据块的对齐一个采样所需要的字节数  
        public short bitPerSample;     //2byte,采样精度声音文件数据的每个采样的位数  
        public short NullChunk;            //2byte,附加信息
        public char[] dataType;       //---4byte,"data"  10
        */
        public short dataSize;         //2byte,数据块大小  location 42后
        //合计头文件44byte
        public string WavPath;
        public string WavName;
        public List<SampleData> sourceArray, keyArray, keyDiffArray;  //原始数据，峰谷数据集合，峰谷位移数据
        //public Point[] dataPoint;
        public int period; //周期
        public int per_deviation; //周期偏差 
        public List<SampleData> peakList, valleyList; //定义峰/谷集合数据包
        public List<Phase> phsaePack; //周期包
    };

}

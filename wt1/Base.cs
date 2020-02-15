using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace wt1
{

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
    public class SampleCompare : IComparer<SampleData>
    {
        public int Compare(SampleData x, SampleData y)
        {
            return y.value - x.value;
        }
    }
    internal struct Period
    {
        internal int index, diff, weight;
    }


    internal class WAVE_s
    {
        /*
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
        */
        public short dataSize;         //2byte,数据块大小  
        public string WavPath;
        public string WavName;
        public ArrayList dataArray, keyArray, tmpArray, keyDiffArray;
        public Point[] dataPoint;
        public int period;
    };

}

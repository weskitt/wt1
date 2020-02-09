using System.Collections;
using System.Drawing;

namespace wt1
{

    internal class Period
    {
        public int index, diff, weight;
    }
    internal class WAVE_s
    {
        public short dataSize;         //2byte,数据块大小  
        public string WavPath;
        public string WavName;
        public ArrayList dataArray, keyArray, keyLocArray, keyDiffArray;
        public Point[] dataPoint;
        public int period;

        public char[] Riff_id { get; set; }
        public int ChunkSize { get; set; }
        public char[] Wave_fmt { get; set; }
        public int FormatSize { get; set; }
        public short Fmttag { get; set; }
        public short Channels { get; set; }
        public int SampleRate { get; set; }
        public int BytePerSecond { get; set; }
        public short BlockAlign { get; set; }
        public short BitPerSample { get; set; }
        public short NullChunk { get; set; }
        public char[] DataType { get; set; }
    };

}

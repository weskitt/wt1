using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace wt1
{
    public class Funcs : AllDataBase
    {
        // FileStream读取文件
        public static string FileStreamReadFile(string filePath)
        {
            byte[] data = new byte[100];
            char[] charData = new char[100];
            FileStream file = new FileStream(filePath, FileMode.Open);

            //文件指针指向0位置
            file.Seek(0, SeekOrigin.Begin);
            //读入两百个字节
            file.Read(data, 0, (int)file.Length);
            //提取字节数组
            Decoder dec = Encoding.UTF8.GetDecoder();
            dec.GetChars(data, 0, data.Length, charData, 0);
            return Convert.ToString(charData);
        }
        // 用FileStream写文件
        public static void FileStreamWriteFile(string filePath, string str)
        {
            byte[] byData;
            char[] charData;
            try
            {
                FileStream nFile = new FileStream(filePath + "love.txt", FileMode.Create);
                //获得字符数组
                charData = str.ToCharArray();
                //初始化字节数组
                byData = new byte[charData.Length];
                //将字符数组转换为正确的字节格式
                Encoder enc = Encoding.UTF8.GetEncoder();
                enc.GetBytes(charData, 0, charData.Length, byData, 0, true);
                nFile.Seek(0, SeekOrigin.Begin);
                nFile.Write(byData, 0, byData.Length);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}

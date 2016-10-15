using System;

using System.IO;
using System.IO.Compression;
namespace CL.Common
{
    public class Compressor
    {        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ofilename"></param>
        /// <param name="nfilename"></param>
        /// <param name="isfile"></param>
        public void Docompress(string ofilename, string nfilename, bool isfile)
        {
            if (!File.Exists(ofilename)) throw new FileNotFoundException("未找到源文件 !");
            try
            {
                //把文件写进数组
                using (FileStream iStream = new FileStream(ofilename, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    byte[] buffer = new byte[iStream.Length];
                    int num = iStream.Read(buffer, 0, buffer.Length);
                    if (num != buffer.Length) throw new ApplicationException("压缩文件异常!");
                    //创建文件输出流并输出
                    using (FileStream oStream = new FileStream(ofilename, FileMode.OpenOrCreate, FileAccess.Write))
                    using (GZipStream cStream = new GZipStream(oStream, CompressionMode.Compress, true))
                        cStream.Write(buffer, 0, buffer.Length);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ofilename"></param>
        /// <param name="nfilename"></param>
        public void Uncompress(string ofilename, string nfilename)
        {
            if (!File.Exists(ofilename)) throw new FileNotFoundException("未找到源文件 !");
            try
            {
                using (FileStream iStream = new FileStream(ofilename, FileMode.Open))
                {
                    using (GZipStream dStream = new GZipStream(iStream, CompressionMode.Decompress, true))
                    {
                        byte[] Buffer = new byte[4];
                        int position = (int)iStream.Length - 4;
                        iStream.Position = position;
                        iStream.Read(Buffer, 0, 4);
                        iStream.Position = 0;
                        int num = BitConverter.ToInt32(Buffer, 0);
                        byte[] buffer = new byte[num + 100];
                        int offset = 0, total = 0, count = 0;
                        while (true)
                        {
                            count = dStream.Read(buffer, offset, 100);
                            if (count == 0) break;
                            offset += count;
                            total += count;
                        }
                        //创建输出流并输出
                        using (FileStream oStream = new FileStream(nfilename, FileMode.Create))
                        {
                            oStream.Write(buffer, 0, total);
                            oStream.Flush();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

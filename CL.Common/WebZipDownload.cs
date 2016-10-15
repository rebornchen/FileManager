using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;    //引用于PMS\NRC.PMS\NRC.Resource\Assemblies\ICSharpCode.SharpZipLib.dll
using System.Web;
using System.IO;

namespace CL.Common
{
    public class WebZipDownload
    {
        const int BYTELENGTH = 4096;

        byte[] _m_buf = new byte[BYTELENGTH];

        ZipOutputStream _zos = new ZipOutputStream(System.Web.HttpContext.Current.Response.OutputStream);

        ZipEntryFactory _factory = new ZipEntryFactory(DateTime.Now);

        public void BatchZipDownload(IList<CustomFileInfo> fileList, string zipFileName)
        {
            HttpResponse response = System.Web.HttpContext.Current.Response;

            //输出头信息
            response.Clear();
            response.ClearHeaders();
            response.Charset = "GB2312";
            response.ContentEncoding = System.Text.Encoding.UTF8;
            //string filename = HttpUtility.UrlEncode(zipFileName, System.Text.Encoding.UTF8);
            string filename = HttpUtility.UrlEncode(zipFileName, Encoding.UTF8).ToString();
            response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
            response.ContentType = "application/octet-stream";
            _zos.SetLevel(9);
            if (fileList.Count <= 0) return;
            foreach (CustomFileInfo f in fileList)
            {
                this.AddZipFile(f);
            }
            System.Web.HttpContext.Current.Response.OutputStream.Close();
            _zos.Finish();
            _zos.Close();
        }

        public void AddZipFile(CustomFileInfo file)
        {
            int sourcebytes;
            string strEntryName = file.FilePath;
            Stream fStream = file.FStream;
            
            ZipEntry entry = _factory.MakeFileEntry(strEntryName);
            entry.Size = fStream.Length;
            _zos.PutNextEntry(entry);
            do
            {
                sourcebytes = fStream.Read(_m_buf, 0, _m_buf.Length);
                _zos.Write(_m_buf, 0, sourcebytes);
                System.Web.HttpContext.Current.Response.Flush();
            }
            while (sourcebytes > 0);
            fStream.Close();
            fStream.Dispose();
        }
    }

    public class CustomFileInfo
    {
        private string _fileName;

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }
        private string _filePath;

        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }

        private Stream _fStream;

        public Stream FStream
        {
            get { return _fStream; }
            set { _fStream = value; }
        }
    }
}

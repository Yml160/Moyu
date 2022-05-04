using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.IO.Compression;

namespace moyu
{
    public class StartRequestText
    {
        public void RequestMessage(string url, out string outresult)
        {
            string result = "";
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);//验证服务器证书回调自动验证
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Timeout = 30000;
                req.Method = "GET";
                req.ContentType = "application/octet-stream";
                //req.ContentType = "application/xhtml+xml";

                byte[] arraryByte = new byte[1024];
                using (HttpWebResponse res = (HttpWebResponse)req.GetResponse())
                {
                    Stream stream = res.GetResponseStream();
                    //读取到内存
                    MemoryStream stmMemory = new MemoryStream();
                    byte[] buffer1 = new byte[1024 * 100];//每次从文件读取1024个字节
                    int i;
                    //将字节逐个放入到Byte中
                    while ((i = stream.Read(buffer1, 0, buffer1.Length)) > 0)
                    {
                        stmMemory.Write(buffer1, 0, i);
                    }
                    arraryByte = stmMemory.ToArray();
                    stmMemory.Close();
                    stream.Close();

                }


                System.IO.MemoryStream srr = new MemoryStream();
                srr.Write(arraryByte, 0, arraryByte.Length);
                srr.Position = 0;
                StreamReader rd = new StreamReader(srr);


                //StringReader srr = Tochar(arraryByte);
                result = rd.ReadToEnd();




                //using (StreamReader streamReader = new StreamReader(streamReceive, Encoding.GetEncoding("ISO-8859-1")))
                //{
                //    result = streamReader.ReadToEnd();
                //}
            }
            catch (WebException e)
            {
                Console.WriteLine("错误信息：" + e.Message);
                throw;
            }
            outresult = result;
        }
        public bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) { return true; }
    }
}

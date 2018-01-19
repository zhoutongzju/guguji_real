using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;


namespace RISBroker
{
    public class XLogManager : IDisposable
    {
        private string logPath = string.Empty;
        private FileStream fs = null;
        private StreamWriter sw = null;

        private static XLogManager instance;
        private static object o = new object();

        private XLogManager()
        {
            try
            {
                CreateLog();               
            }
            catch (System.Exception es)
            {
                //MessageBox.Show("日志组件初始化失败", "系统提示");
                //MessageFrom.MessageManager.ShowMessage("日志组件初始化失败");
                Console.WriteLine(es.Message);
            }
        }

        /// <summary>
        /// 创建日志
        /// </summary>
        private void CreateLog()
        {
            string dicPath = string.Format(@"{0}\log", Application.StartupPath);
            string fileName = string.Format("{0}{1}.log", Application.ProductName, DateTime.Now.ToString("yyyyMMddHH"));
            logPath = string.Format(@"{0}\{1}", dicPath, fileName);
            if (!Directory.Exists(dicPath))
            {
                Directory.CreateDirectory(dicPath);
            }
            if (!File.Exists(logPath))
            {

                using (fs = new FileStream(logPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using (sw = new StreamWriter(fs))
                    {
                        sw.WriteLine("创建日志:" + (DateTime.Now.ToString()));
                        sw.Flush();
                    }
                }
            }
        }

        private static XLogManager GetInstance()
        {
            if (instance == null)
            {
                lock (o)
                {
                    if (instance == null)
                    {
                        instance = new XLogManager();
                    }
                }
            }
            return instance;
        }
        public static void LogError(string msg,Exception e)
        {
            instance = GetInstance();
            if (instance != null)
            {
                instance.XLogError(msg+"\n"+e.Message);
            }
        }
        
        public static void LogError(Exception e)
        {
            instance = GetInstance();
            if (instance != null)
            {
                instance.XLogError(e);
            }
        }

        public static void LogError(string errormsg)
        {
            instance = GetInstance();
            if (instance != null)
            {
                instance.XLogError(errormsg);
            }
        }

        public static void LogInfo(string infomsg)
        {
            instance = GetInstance();
            if (instance != null)
            {
                instance.XLogInfo(infomsg);
            }
        }

        private void XLogInfo(string message)
        {
           
            try
            {
                CreateLog();
                using (fs = new FileStream(logPath, FileMode.Append, FileAccess.Write))
                {
                    using (sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(String.Format("{2} Info:  DataTime-{0}  Info-{1}", DateTime.Now.ToString(), message, Application.ProductName));
                        sw.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        
        }



        private void XLogError(Exception ex)
        {
            XLogError(ex.Message);
        }

        private void XLogError(string errormsg)
        {
            
            try
            {
                CreateLog();
                using (fs = new FileStream(logPath, FileMode.Append, FileAccess.Write))
                {
                    using (sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(String.Format("{2} Error: DataTime-{0}  Message-{1}", DateTime.Now.ToString(), errormsg, Application.ProductName));
                        sw.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }

        #region IDisposable 成员

        public void Dispose()
        {
            if (fs != null && sw != null)
            {
                try
                {
                    sw.Close();
                    fs.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        #endregion
    }
}

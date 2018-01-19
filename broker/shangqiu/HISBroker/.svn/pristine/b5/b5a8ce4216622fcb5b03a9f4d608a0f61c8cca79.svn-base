using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace RISBroker
{
    public class Helper
    {
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string DeEncrypt(string password)
        {
            return System.Text.Encoding.Default.GetString(System.Convert.FromBase64String(password));
        }


        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string Encrypt(string password)
        {
            string value = string.Empty;
            byte[] bytes = System.Text.Encoding.Default.GetBytes(password);
            try
            {
                value = Convert.ToBase64String(bytes);
            }
            catch
            {
                value = password;
            }
            return value;

        }


        //读取数据源
        public static string GetRisConnStr()
        {
            string dbName = string.Empty;
            string dbUser = string.Empty;
            string password = string.Empty;

            dbName = ConfigHelper.GetConfig("ristnsname", "ris");
            dbUser = ConfigHelper.GetConfig("risuser", "ris");
            password = Helper.DeEncrypt(ConfigHelper.GetConfig("rispassword", "bWFyb2xhbmQ="));

            string connStr = string.Format("data source={0};user id={1};password={2}", dbName, dbUser, password);
            return connStr;
        }

        public static string GetHisConnStr()
        {
            string dbName = string.Empty;
            string dbUser = string.Empty;
            string password = string.Empty;

            dbName = ConfigHelper.GetConfig("histnsname", "his");
            dbUser = ConfigHelper.GetConfig("hisuser", "his");
            password = Helper.DeEncrypt(ConfigHelper.GetConfig("hispassword", "bWFyb2xhbmQ="));

            string connStr = string.Format("data source={0};user id={1};password={2}", dbName, dbUser, password);
            return connStr;
        }


        /*
        //读取数据源
        public static string GetConnStr()
        {
            
            //读取注册表
            RegistryKey lmkey = Registry.LocalMachine;

            RegistryKey dbKey = lmkey.OpenSubKey("software\\GL\\Database\\iEIS DB\\");

            if (dbKey == null)
            {
                dbKey = lmkey.OpenSubKey("software\\Wow6432Node\\GL\\Database\\iEIS DB\\", true);
            }

            if (dbKey == null || dbKey.ValueCount == 0)
            {               
                XLogManager.LogError("读取数据库配置失败，注册表数据库配置没配好");
                throw new Exception("读取数据库配置失败"); 
            }
            string dbServer = string.Empty;
            string dbName = string.Empty;
            string dbUser = string.Empty;
            string password = string.Empty;

            try
            {
                foreach (string item in dbKey.GetSubKeyNames())
                {
                    RegistryKey rkey = dbKey.OpenSubKey(item);
                    dbName = Helper.GetValue(rkey.GetValue("DataSource"));
                    if (rkey.GetValue("Password") != null)
                    {
                        password = Helper.GetValue(rkey.GetValue("Password"));
                        //解密
                        password = System.Text.Encoding.Default.GetString(System.Convert.FromBase64String(password));
                    }
                    if (rkey.GetValue("UserName") != null)
                    {
                        dbUser = Helper.GetValue(rkey.GetValue("UserName"));
                    }
                    dbServer = Helper.GetValue(rkey.GetValue("ServerIP"));

                    rkey.Close();
                }

                dbKey.Close();
                lmkey.Close();
            }
            catch (Exception ex)
            {

                XLogManager.LogError(ex);
                return string.Empty;
            }

            string connStr = string.Format("data source={0};user id={1};password={2}", dbName, dbUser, password);

            return connStr;
        }
        */


        
 

        public static string GetIP()
        {
            IPAddress[] arrIPAddresses = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress ip in arrIPAddresses)
            {
                if (ip.AddressFamily.Equals(AddressFamily.InterNetwork))
                {
                    return ip.ToString();
                   // MessageBox.Show(ip.ToString());
                }
            }

            return string.Empty;
        }


        public static string FormatOutOrInPatientID(string strID, string strFormatID)
        {
            if (strFormatID == null || strFormatID == "")
            {
                return strID;
            }
            try
            {
                return Convert.ToInt32(strID).ToString(strFormatID);

            }
            catch
            {
                return strID;
            }
        }



        public static string GetSexName(object sexCode)
        {
            string temp = null;
            switch (sexCode.ToString())
            {
                case "M":
                    temp = "男";
                    break;
                case "F":
                    temp = "女";
                    break;
                default:
                    temp = "未知";
                    break;
            }
            return temp;
        }
      
        public static string FormatString(object srcString)
        {
            int intMaxLen = 10;

            if (srcString == null)
            {
                return "&nbsp;";
            }
            else if (srcString.ToString().Length > intMaxLen)
            {
                return srcString.ToString().Substring(0, intMaxLen) + "...";
            }
            else
            {
                return srcString.ToString();
            }
        }


        public static string GetValue(object o)
        {
            if (o == null || o == DBNull.Value)
            {
                return string.Empty;
            }

            return o.ToString();
        }



        public static int GetIntegr(object o)
        {
            string str = GetValue(o);
            int i = 0;
            if(int.TryParse(str,out i)){
                return i;
            }
            return i;
        }


        //获取ip
        public static string GetIP(string str)
        {
            string ip = string.Empty;
            Regex myRegex = new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
            MatchCollection myMatches = myRegex.Matches(str);//对字符串按指定格式进行分解
            foreach (Match myMatch in myMatches)//循环遍历分解后的字符串
            {
                //输出表示ip的字符串
                ip = myMatch.Value;
                break;
            }
            return ip;
        }
        //获取MacAdd
        public static string GetMacAdd(string str)
        {
            string MacAdd = string.Empty;
            Regex myRegex = new Regex(@"[0-9A-F][0-9A-F]-[0-9A-F][0-9A-F]-[0-9A-F][0-9A-F]-[0-9A-F][0-9A-F]-[0-9A-F][0-9A-F]-[0-9A-F][0-9A-F]");
            MatchCollection myMatches = myRegex.Matches(str);//对字符串按指定格式进行分解
            foreach (Match myMatch in myMatches)//循环遍历分解后的字符串
            {
                //输出表示ip的字符串
                MacAdd = myMatch.Value;
                break;
            }
            return MacAdd;
        }

        /// <summary>
        /// DataTable是否有数据
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool DataTableHasData(System.Data.DataTable dt)
        {
            if (dt == null || dt.Rows.Count <= 0)
                return false;

            return true;
        }

        /// <summary>
        /// object->string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetValueTirm(object obj)
        {
            if (obj == null || DBNull.Value == obj)
            {
                return string.Empty;
            }
            try
            {
                return obj.ToString().Trim();
            }
            catch (Exception ex)
            {
                XLogManager.LogError(ex);
            }
            return string.Empty;


        }

        
    }
}

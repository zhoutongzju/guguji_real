using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace RISBroker
{
    public class INIHelper
    {

        // 声明INI文件的写操作函数 WritePrivateProfileString()

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        // 声明INI文件的读操作函数 GetPrivateProfileString()

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, System.Text.StringBuilder retVal, int size, string filePath);


        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defVal, Byte[] retVal, int size, string filePath);


        /// <summary>
        /// 写入配置
        /// </summary>
        /// <param name="section">配置节</param>
        /// <param name="key">键名</param>
        /// <param name="value">键值</param>
        public static void Writue(string section, string key, string value)
        {

            Writue(section, key, value, string.Empty);

        }

        /// <summary>
        /// 写入配置
        /// </summary>
        /// <param name="section">配置节</param>
        /// <param name="key">键名</param>
        /// <param name="value">键值</param>
        /// <param name="sPath">路径</param>
        public static void Writue(string section, string key, string value, string sPath)
        {

            if (string.IsNullOrEmpty(sPath))
            {
                sPath = GetPath();
            }
            // section=配置节，key=键名，value=键值，path=路径

            WritePrivateProfileString(section, key, value, sPath);

        }


        /// <summary>
        /// 读取配置
        /// </summary>
        /// <param name="sPath">路径</param>
        /// <param name="section">配置节</param>
        /// <param name="key">键名</param>
        /// <returns></returns>
        public static string ReadValue(string section, string key)
        {
            return ReadValue(string.Empty, section, key);
        }



        /// <summary>
        /// 读取配置
        /// </summary>
        /// <param name="sPath">路径</param>
        /// <param name="section">配置节</param>
        /// <param name="key">键名</param>
        /// <returns></returns>
        public static string ReadValue(string sPath, string section, string key)
        {
            if (string.IsNullOrEmpty(sPath))
            {
                sPath = GetPath();
            }

            // 每次从ini中读取多少字节

            System.Text.StringBuilder temp = new System.Text.StringBuilder(255);

            // section=配置节，key=键名，temp=上面，path=路径

            GetPrivateProfileString(section, key, "", temp, 255, sPath);

            return temp.ToString();

        }


         /// <summary>
        /// 读取配置
        /// </summary>        
        /// <param name="section">配置节</param>
        /// <param name="key">键名</param>
        /// <param name="dValue">默认值</param>
        /// <returns></returns>
        public static string ReadValueDefaultValue(string section, string key, string dValue)
        {
            return ReadValueDefaultValue(string.Empty, section, key, dValue);
        }


        /// <summary>
        /// 读取配置
        /// </summary>
        /// <param name="sPath">路径</param>
        /// <param name="section">配置节</param>
        /// <param name="key">键名</param>
        /// <param name="dValue">默认值</param>
        /// <returns></returns>
        public static string ReadValueDefaultValue(string sPath, string section, string key, string dValue)
        {

            if (string.IsNullOrEmpty(sPath))
            {
                sPath = GetPath();
            }
            // 每次从ini中读取多少字节

            System.Text.StringBuilder temp = new System.Text.StringBuilder(255);

            // section=配置节，key=键名，temp=上面，path=路径

            GetPrivateProfileString(section, key, "", temp, 255, sPath);
            if (temp.Length == 0)
            {
                return dValue;
            }
            return temp.ToString();

        }


         /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="Section">段，格式[]</param>
        /// <param name="Key">键</param>
        /// <returns>返回byte类型的section组或键值组</returns>
        public static byte[] IniReadValues(  string section, string key)
        {
            return IniReadValues(string.Empty, section, key);
        }

        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="Section">段，格式[]</param>
        /// <param name="Key">键</param>
        /// <returns>返回byte类型的section组或键值组</returns>
        public static byte[] IniReadValues(string sPath, string section, string key)
        {
            if (string.IsNullOrEmpty(sPath))
            {
                sPath = GetPath();
            }
            byte[] temp = new byte[255];

            int i = GetPrivateProfileString(section, key, "", temp, 255, sPath);
            return temp;
        }


        /// <summary>
        /// 得到路径
        /// </summary>
        /// <returns></returns>
        public static string GetPath()
        {
            return string.Format("{0}\\{1}.ini", Application.StartupPath,Application.ProductName);
        }




    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Configuration;
using System.Xml;


namespace RISBroker
{
    public class ConfigHelper
    {

        //private static string AutoSelection = "AutoReort";

        /// <summary>
        /// 初始化
        /// </summary>
        public static void OnInit()
        {
            XCatch.Catches.Clear();//清空缓存,及时更新

        }


       

        public static void SetConfigBool(string key, Boolean value)
        {
            int checkes = 0;
            if (value) checkes = 1;
            SetConfig(key, checkes.ToString());
        }


        public static bool GetConfigToBool(string key)
        {
            int checkes = 0;
            if (int.TryParse(GetConfig(key), out checkes))
            {
                return (checkes == 1);
            }
            return false;
        }


        /// <summary>
        /// 读取配置
        /// </summary>
        /// <param name="key">配置名称</param>
        /// <returns></returns>
        public static bool GetConfigBool(string key, string defaultValue)
        {
            if (!HasKey(key))
            {
                SetConfig(key, defaultValue);
            }

            string value = GetConfig(key);

            if (string.IsNullOrEmpty(value))
                value = defaultValue;

            if (value == "1")
                return true;


            return false;
        }

        /// <summary>
        /// 读取配置
        /// </summary>
        /// <param name="key">配置名称</param>
        /// <returns></returns>
        public static int GetConfigInt(string key, int defaultValue)
        {
            if (!HasKey(key))
            {
                SetConfig(key, defaultValue.ToString());
            }

            string value = GetConfig(key);

            if (string.IsNullOrEmpty(value))
                return defaultValue;

            int temp = 0;
            if (int.TryParse(value, out temp))
            {
                return temp;
            }


            return defaultValue;
        }


        /// <summary>
        /// 读取配置
        /// </summary>
        /// <param name="key">配置名称</param>
        /// <returns></returns>
        public static string GetConfig(string key, string defaultValue)
        {
            string value = GetConfig(key);
            if (string.IsNullOrEmpty(value))
                value = defaultValue;
            return value;
        }



        ///// <summary>
        ///// 保存配置
        ///// </summary>
        ///// <param name="key">配置名称</param>
        ///// <param name="value">保存值</param>
        ///// <returns></returns>
        //public static bool SetConfig(string key, string value)
        //{
        //    INIHelper.Writue("AutoReort", key, value);
        //    return true;
        //}

        ///// <summary>
        ///// 读取配置
        ///// </summary>
        ///// <param name="key">配置名称</param>
        ///// <returns></returns>
        //public static string GetConfig(string key)
        //{
        //    if (!string.IsNullOrEmpty(key))
        //    {
        //        string value = string.Empty;
        //        try
        //        {
        //            object o = null;
        //            if (XCatch.Catches.TryGetValue(key, out o))
        //            {
        //                value = Helper.GetValue(o);
        //            }
        //            else
        //            {
        //                value = INIHelper.ReadValue(AutoSelection, key);
        //                XCatch.Catches.Add(key, value);
        //            }
        //            return value;
        //        }
        //        catch (System.Exception e)
        //        {
        //            XLogManager.LogError(e);
        //        }
        //    }

        //    return string.Empty;
        //}

        ///// <summary>
        ///// 是否报告当前key
        ///// </summary>
        ///// <param name="key"></param>
        ///// <returns></returns>
        //public static bool HasKey(string key)
        //{
        //    bool flag = false;
        //    var value = INIHelper.IniReadValues(AutoSelection, key);
        //    //string[] keys = INIHelper.IniReadValues(AutoSelection, key);
        //    //foreach (string item in keys)
        //    //{
        //    //    if (string.Compare(key, item) == 0)
        //    //    {
        //    //        flag = true;
        //    //        break;
        //    //    }

        //    //}
        //    return flag;
        //}




        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="key">配置名称</param>
        /// <param name="value">保存值</param>
        /// <returns></returns>
        public static bool SetConfig(string key, string value)
        {


            if (!string.IsNullOrEmpty(key))
            {
                value = value.Trim();


                //--修改RunTime(内存)中的App.config
                // Open App.Config of executable
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                // Add an Application Setting.
                config.AppSettings.Settings.Remove(key);
                config.AppSettings.Settings.Add(key, value);
                // Save the configuration file.
                config.Save(ConfigurationSaveMode.Modified);
                // Force a reload of a changed section.
                ConfigurationManager.RefreshSection("appSettings");

                //--修改App.config文件
                XmlDocument xDoc = new XmlDocument();
                //获取可执行文件的路径和名称
                xDoc.Load(System.Windows.Forms.Application.ExecutablePath + ".config");

                XmlNode xNode;
                XmlElement xElem1;
                XmlElement xElem2;
                xNode = xDoc.SelectSingleNode("//appSettings");

                xElem1 = (XmlElement)xNode.SelectSingleNode("//add[@key='" + key + "']");
                if (xElem1 != null)
                {
                    xElem1.SetAttribute("value", value);
                }
                else
                {
                    xElem2 = xDoc.CreateElement("add");
                    xElem2.SetAttribute("key", key);
                    xElem2.SetAttribute("value", value);
                    xNode.AppendChild(xElem2);
                    XLogManager.LogError(string.Format("没有找到对应的[{0}]节点,系统自动添加节点", key));
                }

                OnInit();
                xDoc.Save(System.Windows.Forms.Application.ExecutablePath + ".config");
            }

            return false;

        }


        /// <summary>
        /// 读取配置
        /// </summary>
        /// <param name="key">配置名称</param>
        /// <returns></returns>
        public static string GetConfig(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                string value = string.Empty;
                try
                {
                    object o = null;
                    if (XCatch.Catches.TryGetValue(key, out o))
                    {
                        value = Helper.GetValue(o);
                    }
                    else
                    {   
                       value = ConfigurationManager.AppSettings[key].Trim();                        
                        XCatch.Catches.Add(key, value);
                    }
                    return value;
                }
                catch (System.Exception e)
                {
                    XLogManager.LogError(e);
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// 配置文件中是否有该节点
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool HasKey(string key)
        {
            bool flag = false;
            string[] keys = ConfigurationManager.AppSettings.AllKeys;
            foreach (string item in keys)
            {
                if (string.Compare(key, item) == 0)
                {
                    flag = true;
                    break;
                }

            }
            return flag;
        }
    }
}

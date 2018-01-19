using Maroland.DataAccess;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient; 
using System.Text; 

namespace RISBroker
{
    /// <summary>
    /// 数据库操作类工厂
    /// </summary>
    public class DataMgrFactory
    {
        public enum DBNameEnum
        {
            RIS_DB,
            HIS_DB
        }

        public static DataMgr CreateDataMgr(DBNameEnum dbname)
        {
            string connectStr = "";
            switch (dbname)
            {
                case DBNameEnum.RIS_DB:
                    connectStr = Helper.GetRisConnStr();
                    break;
                case DBNameEnum.HIS_DB:
                    connectStr = Helper.GetHisConnStr();
                    break;
                default:
                    connectStr = Helper.GetRisConnStr();
                    break;
            }

            DataMgr mgr = new DataMgr();
            DataMgr.strConnect = connectStr;
            return mgr;
        }


        //public static IDbConnection GetConnection()
        //{
        //    IDbConnection conn = null;
        //    string connectionStr = Helper.GetConnStr();
        //    try
        //    {
        //        conn = new OracleConnection(connectionStr);
        //        if (conn.State != ConnectionState.Open)
        //        {
        //            conn.Open();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        XLogManager.LogError(connectionStr, ex);
        //        throw new Exception("数据库联接异常，请通知管理员，并在系统设置。\r\n异常信息：" + ex.Message);
        //    }
        //    return conn;
        //}
        
    }
}

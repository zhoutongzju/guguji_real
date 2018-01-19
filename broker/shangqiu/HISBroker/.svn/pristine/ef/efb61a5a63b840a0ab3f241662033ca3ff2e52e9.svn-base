using System;
using System.Collections.Generic;
using System.Text;


namespace RISBroker
{
    /// <summary>
    /// 数据库操作类
    /// </summary>
    public class DBHelperFactory
    {
        private static IDBHelper DBHelper = null;
        private static object o = new object();


        /// <summary>
        /// 获取数据库操作类
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <returns></returns>
        public static IDBHelper GetDBHelper(XDBType dbType)
        {
            return GetDBHelper(dbType, null);
        }
        /// <summary>
        /// 获取数据库操作类
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <returns></returns>
        public static IDBHelper GetDBHelper(XDBType dbType, string connstr)
        {
                
                        switch (dbType)
                        {
                            case XDBType.MSSQL:
                                DBHelper = new SqlServerHelper();
                                break;
                            case XDBType.ACCESS:
                                DBHelper = new AccessHelper();
                                break;
                            case XDBType.ORACLE:
                                DBHelper = new OraHelper();
                                break;                             
                            default:
                                DBHelper = new SqlServerHelper();
                                break;
                        }
 
            
            if (!string.IsNullOrEmpty(connstr))
            {
                DBHelper.ConnString = connstr;
            }
            return DBHelper;
        }
    }


    /// <summary>
    /// 数据库类型
    /// </summary>
    public enum XDBType
    {
        MSSQL = 0,
        ACCESS = 1,
        ORACLE = 2
    }
}

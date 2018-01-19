using System;
using System.Text;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Collections.Generic;
using System.Data.Common;



namespace RISBroker
{


    /// <summary>    
    /// 数据访问抽象基础类(ACCESS)    
    /// Copyright (C) 2006-2007 NMJU.NET    
    /// All rights reserved    
    /// </summary>    
    public  class AccessHelper : ADBHelper, IDBHelper
    {
        //数据库连接字符串(web.config来配置)    
        //public  string connectionString = ConfigurationManager.AppSettings["ConnectionString"];    
        // public  string connectionString = System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["AccessConnectionString"]);    
        public string connectionString = ConfigurationManager.AppSettings["AccessConnectionString"];


        public string ConnString
        {
            get
            {
                return this.connectionString;
            }
            set
            {
                this.connectionString = value;
            }
        }

        public bool OpenConnection()
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("数据库连接字符串为空");
            }
            try
            {
                OleDbConnection connection = new OleDbConnection(connectionString);
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #region 执行SQL语句
        public int GetMaxID(string FieldName, string TableName)
        {
            string strsql = "select max(" + FieldName + ")+1 from " + TableName;
            object obj = GetSingle(strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }
        public bool Exists(string strSql)
        {
            object obj = GetSingle(strSql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Exists(string strSql, params IDbDataParameter[] cmdParms)
        {
            object obj = GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }







        /// <summary>    
        /// 执行SQL语句，设置命令的执行等待时间    
        /// </summary>    
        /// <param name="SQLString"></param>    
        /// <param name="Times"></param>    
        /// <returns></returns>    
        public int ExecuteSqlByTime(string SQLString, int Times)
        {
            return ExecuteSqlByTime(this.connectionString, SQLString, Times);
        }

        /// <summary>    
        /// 执行SQL语句，设置命令的执行等待时间    
        /// </summary>    
        /// <param name="SQLString">SQL语句</param>    
        /// <param name="Times">等待时间</param>    
        /// <returns></returns>    
        public int ExecuteSqlByTime(string connectionstr, string SQLString, int Times)
        {
            if (string.IsNullOrEmpty(connectionstr))
            {
                throw new Exception("数据库连接字符串为空");
            }
            using (OleDbConnection connection = new OleDbConnection(connectionstr))
            {
                using (OleDbCommand cmd = new OleDbCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.CommandTimeout = Times;
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.OleDb.OleDbException E)
                    {
                        connection.Close();
                        throw new Exception(E.Message);
                    }
                }
            }
        }
        
        /// <summary>    
        /// 执行SQL语句，返回影响的记录数    
        /// </summary>    
        /// <param name="SQLString">SQL语句</param>    
        /// <returns>影响的记录数</returns>    
        public int ExecuteSql(string SQLString)
        {
            return ExecuteSql(this.connectionString, CommandType.Text, SQLString, null);
        }

        /// <summary>    
        /// 执行SQL语句，返回影响的记录数    
        /// </summary>    
        /// <param name="SQLString">SQL语句</param>    
        /// <returns>影响的记录数</returns> 
        public int ExecuteSql(string connectionstr, string SQLString)
        {
            return ExecuteSql(connectionstr, CommandType.Text, SQLString, null);
        }

        /// <summary>    
        /// 执行SQL语句，返回影响的记录数    
        /// </summary>    
        /// <param name="SQLString">SQL语句</param>    
        /// <returns>影响的记录数</returns>  
        public int ExecuteSql(string connectionstr, CommandType cmdType, string SQLString)
        {
            return ExecuteSql(connectionstr, cmdType, SQLString, null);
        }

        /// <summary>    
        /// 执行SQL语句，返回影响的记录数    
        /// </summary>    
        /// <param name="SQLString">SQL语句</param>    
        /// <returns>影响的记录数</returns>    
        public int ExecuteSql(string connectionstr, CommandType cmdType, string SQLString, params IDbDataParameter[] cmdParms)
        {
            if (string.IsNullOrEmpty(connectionstr))
            {
                throw new Exception("数据库连接字符串为空");
            }
            using (OleDbConnection connection = new OleDbConnection(connectionstr))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    try
                    {

                        PrepareCommand(cmd, connection, null, CommandType.Text, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.OleDb.OleDbException E)
                    {
                        throw new Exception(E.Message);
                    }
                }
            }
        }


        /// <summary>    
        /// 执行多条SQL语句，实现数据库事务。    
        /// </summary>    
        /// <param name="SQLStringList">多条SQL语句</param>       
        /// <returns>执行失败可能报错</returns>
        public void ExecuteSqlTran(List<string> SQLStringList)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = conn;
                    OleDbTransaction tx = conn.BeginTransaction();
                    cmd.Transaction = tx;
                    try
                    {
                        for (int n = 0; n < SQLStringList.Count; n++)
                        {
                            string strsql = SQLStringList[n].ToString();
                            if (strsql.Trim().Length > 1)
                            {
                                cmd.CommandText = strsql;
                                cmd.ExecuteNonQuery();
                            }
                        }
                        tx.Commit();
                    }
                    catch (Exception ex)
                    {

                        tx.Rollback();
                        throw ex;
                    }

                }
            }
        }

        /// <summary>    
        /// 执行多条SQL语句，实现数据库事务。    
        /// </summary>    
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的OleDbParameter[]）</param>    
        public void ExecuteSqlTran(Hashtable SQLStringList)
        {
            ExecuteSqlTran(this.connectionString, SQLStringList, CommandType.Text);
        }

        /// <summary>    
        /// 执行多条SQL语句，实现数据库事务。    
        /// </summary>    
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的OleDbParameter[]）</param>    
        public void ExecuteSqlTran(string connectionString, Hashtable SQLStringList, CommandType cmdType)
        {
            if (!string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("数据库连接字符串为空");
            }
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbTransaction trans = conn.BeginTransaction())
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandType = cmdType;
                    try
                    {
                        //循环    
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            OleDbParameter[] cmdParms = (OleDbParameter[])myDE.Value;
                            PrepareCommand(cmd, conn, trans, cmdType, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();

                            trans.Commit();
                        }
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }
        

        /// <summary>    
        /// 向数据库里插入图像格式的字段(和上面情况类似的另一种实例)
        /// </summary>    
        /// <param name="strSQL">SQL语句</param>    
        /// <param name="fs">图像字节,数据库的字段类型为image的情况</param>    
        /// <returns>影响的记录数</returns>    
        public int ExecuteSqlInsertImg(string strSQL, byte[] fs)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand cmd = new OleDbCommand(strSQL, connection);
                System.Data.OleDb.OleDbParameter myParameter = new System.Data.OleDb.OleDbParameter("@fs", SqlDbType.Image);
                myParameter.Value = fs;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.OleDb.OleDbException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }

        #endregion


        #region 执行SQL返回数据

        /// <summary>    
        /// 执行一条计算查询结果语句，返回查询结果（object）。    
        /// </summary>    
        /// <param name="SQLString">计算查询结果语句</param>    
        /// <returns>查询结果（object）</returns>    
        public object GetSingle(string SQLString)
        {
            return GetSingle(this.connectionString, CommandType.Text, SQLString, null);
        }

        /// <summary>    
        /// 执行一条计算查询结果语句，返回查询结果（object）。    
        /// </summary>    
        /// <param name="SQLString">计算查询结果语句</param>    
        /// <returns>查询结果（object）</returns>            
        public object GetSingle(string SQLString, params IDbDataParameter[] cmdParms)
        {
            return GetSingle(this.connectionString, CommandType.Text, SQLString, cmdParms);
        }

        /// <summary>    
        /// 执行一条计算查询结果语句，返回查询结果（object）。    
        /// </summary>    
        /// <param name="SQLString">计算查询结果语句</param>    
        /// <returns>查询结果（object）</returns>    
        public object GetSingle(string connectionstr, CommandType cmdType, string SQLString, params IDbDataParameter[] cmdParms)
        {
            if (string.IsNullOrEmpty(connectionstr))
            {
                throw new Exception("数据库连接字符串为空");
            }
            using (OleDbConnection connection = new OleDbConnection(connectionstr))
            {                
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, cmdType, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.OleDb.OleDbException e)
                    {
                        throw new Exception(e.Message);
                    }
                }
            }
        }


        /// <summary>    
        /// 执行查询语句，返回SqlDataReader(使用该方法切记要手工关闭SqlDataReader和连接)    
        /// </summary>    
        /// <param name="strSQL">查询语句</param>    
        /// <returns>SqlDataReader</returns>    
        public DbDataReader ExecuteReader(string SQLString)
        {
            return ExecuteReader(SQLString, null);
        }

        /// <summary>    
        /// 执行查询语句，返回SqlDataReader (使用该方法切记要手工关闭SqlDataReader和连接)    
        /// </summary>    
        /// <param name="strSQL">查询语句</param>    
        /// <returns>SqlDataReader</returns>            
        public DbDataReader ExecuteReader(string SQLString, params IDbDataParameter[] cmdParms)
        {
            return ExecuteReader(this.connectionString, CommandType.Text, SQLString, cmdParms);
        }

        /// <summary>    
        /// 执行查询语句，返回SqlDataReader (使用该方法切记要手工关闭SqlDataReader和连接)    
        /// </summary>    
        /// <param name="strSQL">查询语句</param>    
        /// <returns>SqlDataReader</returns>  
        public DbDataReader ExecuteReader(string connectionstr, CommandType cmdType, string SQLString, params IDbDataParameter[] cmdParms)
        {
            if (string.IsNullOrEmpty(connectionstr))
            {
                throw new Exception("数据库连接字符串为空");
            }
            OleDbConnection conn = new OleDbConnection(connectionstr);
            OleDbCommand cmd = new OleDbCommand();
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, SQLString, cmdParms);
                OleDbDataReader myReader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (System.Data.OleDb.OleDbException e)
            {
                conn.Close();
                throw new Exception(e.Message);
            }
            //finally //不能在此关闭，否则，返回的对象将无法使用    
            //{    
            //  cmd.Dispose();    
            //  connection.Close();    
            //}    

        }
        
        /// <summary>    
        /// 执行查询语句，返回DataSet,设置命令的执行等待时间    
        /// </summary>    
        /// <param name="SQLString"></param>    
        /// <param name="Times"></param>    
        /// <returns></returns>    
        public DataSet Query(string SQLString, int Times)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    OleDbDataAdapter command = new OleDbDataAdapter(SQLString, connection);
                    command.SelectCommand.CommandTimeout = Times;
                    command.Fill(ds, "ds");
                }
                catch (System.Data.OleDb.OleDbException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }
        
        /// <summary>    
        /// 执行查询语句，返回DataSet    
        /// </summary>    
        /// <param name="SQLString">查询语句</param>    
        /// <returns>DataSet</returns> 
        public DataSet Query(string SQLString)
        {
            return Query(this.connectionString, CommandType.Text, SQLString, null);
        }

        /// <summary>    
        /// 执行查询语句，返回DataSet    
        /// </summary>    
        /// <param name="SQLString">查询语句</param>    
        /// <returns>DataSet</returns>    
        public DataSet Query(string SQLString, params IDbDataParameter[] cmdParms)
        {
            return Query(this.connectionString, CommandType.Text, SQLString, null);
        }

        /// <summary>    
        /// 执行查询语句，返回DataSet    
        /// </summary>    
        /// <param name="SQLString">查询语句</param>    
        /// <returns>DataSet</returns>   
        public DataSet Query(string connectionstr, string SQLString)
        {
            return Query(connectionstr, CommandType.Text, SQLString, null);
        }

        /// <summary>    
        /// 执行查询语句，返回DataSet    
        /// </summary>    
        /// <param name="SQLString">查询语句</param>    
        /// <returns>DataSet</returns>   
        public DataSet Query(string connectionstr, CommandType cmdType, string SQLString)
        {
            return Query(connectionstr, cmdType, SQLString, null);
        }

        /// <summary>    
        /// 执行查询语句，返回DataSet    
        /// </summary>    
        /// <param name="SQLString">查询语句</param>    
        /// <returns>DataSet</returns>    
        public DataSet Query(string connectionstr, CommandType cmdType, string SQLString, params IDbDataParameter[] cmdParms)
        {
            if (string.IsNullOrEmpty(connectionstr))
            {
                throw new Exception("数据库连接字符串为空");
            }
            using (OleDbConnection connection = new OleDbConnection(connectionstr))
            {
                DataSet ds = new DataSet();
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    try
                    {
                        connection.Open();
                        PrepareCommand(cmd, connection, null, CommandType.Text, SQLString, cmdParms);
                        OleDbDataAdapter command = new OleDbDataAdapter();
                        command.SelectCommand = cmd;
                        command.Fill(ds, "ds");
                    }
                    catch (System.Data.OleDb.OleDbException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }

        #endregion

        #region 分页

      
      


        /// <summary>    
        /// 智能返回SQL语句    
        /// </summary>    
        /// <param name="primaryKey">主键（不能为空）</param>    
        /// <param name="queryFields">提取字段（不能为空）</param>    
        /// <param name="tableName">表（理论上允许多表）</param>    
        /// <param name="condition">条件（可以空）</param>    
        /// <param name="OrderBy">排序，格式：字段名+""+ASC（可以空）</param>    
        /// <param name="pageSize">分页数（不能为空）</param>    
        /// <param name="pageIndex">当前页，起始为：1（不能为空）</param>    
        /// <returns></returns>    
        public override string getPageListSql(string primaryKey, string queryFields, string tableName, string condition, string orderBy, int pageSize, int pageIndex)
        {
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            string strTmp = ""; //---strTmp用于返回的SQL语句    
            string SqlSelect = "", SqlPrimaryKeySelect = "", strOrderBy = "", strWhere = " where 1=1 ", strTop = "";
            //0：分页数量    
            //1:提取字段    
            //2:表    
            //3:条件    
            //4:主键不存在的记录    
            //5:排序    
            SqlSelect = " select top {0} {1} from {2} {3} {4} {5}";
            //0:主键    
            //1:TOP数量,为分页数*(排序号-1)    
            //2:表    
            //3:条件    
            //4:排序    
            SqlPrimaryKeySelect = " and {0} not in (select {1} {0} from {2} {3} {4}) ";

            if (orderBy != "")
                strOrderBy = " order by " + orderBy;
            if (condition != "")
                strWhere += " and " + condition;
            int pageindexsize = (pageIndex - 1) * pageSize;
            if (pageindexsize > 0)
            {
                strTop = " top " + pageindexsize.ToString();
                SqlPrimaryKeySelect = String.Format(SqlPrimaryKeySelect, primaryKey, strTop, tableName, strWhere, strOrderBy);
                strTmp = String.Format(SqlSelect, pageSize.ToString(), queryFields, tableName, strWhere, SqlPrimaryKeySelect, strOrderBy);

            }
            else
            {
                strTmp = String.Format(SqlSelect, pageSize.ToString(), queryFields, tableName, strWhere, "", strOrderBy);

            }
            return strTmp;
        }

        /// <summary>    
        /// 获取根据指定字段排序并分页查询。DataSet    
        /// </summary>    
        /// <param name="pageSize">每页要显示的记录的数目</param>    
        /// <param name="pageIndex">要显示的页的索引</param>    
        /// <param name="tableName">要查询的数据表</param>    
        /// <param name="queryFields">要查询的字段,如果是全部字段请填写：*</param>    
        /// <param name="primaryKey">主键字段，类似排序用到</param>    
        /// <param name="orderBy">是否为升序排列：0为升序，1为降序</param>    
        /// <param name="condition">查询的筛选条件</param>    
        /// <returns>返回排序并分页查询的DataSet</returns>    
        public DataSet GetPagingList(string primaryKey, string queryFields, string tableName, string condition, string orderBy, int pageSize, int pageIndex)
        {
            return GetPagingList(this.connectionString, primaryKey, queryFields, tableName, condition, orderBy, pageSize, pageIndex);
        }
        /// <summary>    
        /// 获取根据指定字段排序并分页查询。DataSet    
        /// </summary>    
        /// <param name="connstrSql">数据库连接字符串</param>
        /// <param name="pageSize">每页要显示的记录的数目</param>    
        /// <param name="pageIndex">要显示的页的索引</param>    
        /// <param name="tableName">要查询的数据表</param>    
        /// <param name="queryFields">要查询的字段,如果是全部字段请填写：*</param>    
        /// <param name="primaryKey">主键字段，类似排序用到</param>    
        /// <param name="orderBy">是否为升序排列：0为升序，1为降序</param>    
        /// <param name="condition">查询的筛选条件</param>    
        /// <returns>返回排序并分页查询的DataSet</returns>  
        public DataSet GetPagingList(string connectionString, string primaryKey, string queryFields, string tableName, string condition, string orderBy, int pageSize, int pageIndex)
        {
            string sql = getPageListSql(primaryKey, queryFields, tableName, condition, orderBy, pageSize, pageIndex);

            return Query(connectionString, sql);
        }

        /// <summary>    
        /// 分页查询数据记录总数获取    
        /// </summary>    
        /// <param name="_ID">----主表的主键</param>    
        /// <param name="_tbName">----要显示的表或多个表的连接</param>           
        /// <param name="_strCondition">----查询条件,不需where</param>            
        /// <param name="_Dist">----是否添加查询字段的 DISTINCT 默认0不添加/1添加</param>    
        /// <returns></returns>  
        public int GetRecordCount(string _ID, string _tbName, string _strCondition, int _Dist)
        {
            return GetRecordCount(this.connectionString, _ID, _tbName, _strCondition, _Dist);
        }


        public int GetRecordCount(string connstrSql, string _ID, string _tbName, string _strCondition, int _Dist)
        {
            string sql = getPageListCounts(_ID, _tbName, _strCondition, _Dist);

            object obj = GetSingle(connstrSql, CommandType.Text, sql, null);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }

        #endregion
        
    }
}
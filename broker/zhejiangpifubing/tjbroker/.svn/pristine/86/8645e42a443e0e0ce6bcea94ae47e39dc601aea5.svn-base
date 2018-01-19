using System;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Collections;



namespace RISBroker
{
    /// <summary>
    /// A helper class used to execute queries against an Oracle database
    /// </summary>
    public class OraHelper : ADBHelper, IDBHelper
    {

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

        public string connectionString = System.Configuration.ConfigurationManager.AppSettings["OracleConnectionString"];



        public bool OpenConnection()
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("数据库连接字符串为空");
            }
            try
            {
                OracleConnection connection = new OracleConnection(connectionString);
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
        //
        public int GetMaxID(string FieldName, string TableName)
        {
            string strsql = string.Format(" select max{0} from [{1}]", FieldName, TableName);
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

        //
        public bool Exists(string strSql)
        {
            return Exists(strSql);
        }

        //
        public bool Exists(string strSql, params IDbDataParameter[] cmdParms)
        {
            int rownum = ExecuteSql(this.connectionString, CommandType.Text, strSql, cmdParms);
            if (rownum > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //
        public int ExecuteSql(string connectionstr, string SQLString)
        {
            return ExecuteSql(connectionstr, CommandType.Text, SQLString);
        }

        //
        public int ExecuteSql(string connectionstr, CommandType cmdType, string SQLString)
        {
            return ExecuteSql(connectionstr, cmdType, SQLString, null);
        }

        //
        public int ExecuteSql(string connectionstr, CommandType cmdType, string SQLString, params IDbDataParameter[] cmdParms)
        {
            if (string.IsNullOrEmpty(connectionstr))
            {
                throw new Exception("数据库连接字符串为空");
            }
            //Create a connection
            using (OracleConnection conn = new OracleConnection(connectionstr))
            {// Create a new Oracle command
                using (OracleCommand cmd = new OracleCommand())
                {
                    //Prepare the command
                    PrepareCommand(cmd, conn, null, cmdType, SQLString, cmdParms);

                    //Execute the command
                    int val = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return val;
                }
            }
        }

        //
        public int ExecuteSqlByTime(string SQLString, int Times)
        {
            return ExecuteSqlByTime(this.connectionString, SQLString, Times);
        }

        //
        public int ExecuteSqlByTime(string connectionstr, string SQLString, int Times)
        {

            if (string.IsNullOrEmpty(connectionstr))
            {
                throw new Exception("数据库连接字符串为空");
            }
            //Create a connection
            using (OracleConnection conn = new OracleConnection(connectionstr))
            {// Create a new Oracle command
                using (OracleCommand cmd = new OracleCommand())
                {

                    //Prepare the command
                    PrepareCommand(cmd, conn, null, CommandType.Text, SQLString, null);
                    cmd.CommandTimeout = Times;

                    //Execute the command
                    int val = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return val;
                }
            }
        }

        //
        public void ExecuteSqlTran(System.Collections.Generic.List<string> SQLStringList)
        {
            if (!string.IsNullOrEmpty(this.connectionString))
            {
                throw new Exception("数据库连接字符串为空");
            }
            using (OracleConnection conn = new OracleConnection(this.connectionString))
            {
                using (OracleTransaction trans = conn.BeginTransaction())
                {
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        try
                        {
                            foreach (string item in SQLStringList)
                            {

                                PrepareCommand(cmd, conn, trans, CommandType.Text, item, null);
                                int val = cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                            }

                            trans.Commit();
                        }
                        catch (Exception)
                        {
                            trans.Rollback();
                        }

                    }
                }
            }
        }

        //
        public void ExecuteSqlTran(Hashtable SQLStringList)
        {
            ExecuteSqlTran(this.connectionString, SQLStringList, CommandType.Text);
        }

        //
        public void ExecuteSqlTran(string connectionstr, Hashtable SQLStringList, CommandType cmdType)
        {

            if (string.IsNullOrEmpty(connectionstr))
            {
                throw new Exception("数据库连接字符串为空");
            }
            using (OracleConnection conn = new OracleConnection(connectionstr))
            {
                using (OracleTransaction trans = conn.BeginTransaction())
                {
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        try
                        {
                            foreach (DictionaryEntry item in SQLStringList)
                            {
                                string key = item.Key.ToString();
                                OracleParameter[] paras = (OracleParameter[])item.Value;
                                PrepareCommand(cmd, conn, trans, cmdType, key, paras);
                                int val = cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                            }

                            trans.Commit();
                        }
                        catch (Exception)
                        {
                            trans.Rollback();
                        }

                    }
                }
            }
        }


        #endregion



        #region 执行SQL返回数据

        //
        public object GetSingle(string SQLString)
        {
            return GetSingle(SQLString,null);
        }
        //
        public object GetSingle(string SQLString, params IDbDataParameter[] cmdParms)
        {
            return GetSingle(this.connectionString, CommandType.Text, SQLString, cmdParms);
        }
        //
        public object GetSingle(string connectionstr, CommandType cmdType, string SQLString, params IDbDataParameter[] cmdParms)
        {
            if (string.IsNullOrEmpty(connectionstr))
            {
                throw new Exception("数据库连接字符串为空");
            }
            using (OracleConnection conn = new OracleConnection(connectionstr))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    PrepareCommand(cmd, conn, null, cmdType, SQLString, cmdParms);
                    object val = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    return val;
                }

            }
        }

        //
        public System.Data.Common.DbDataReader ExecuteReader(string SQLString, params IDbDataParameter[] cmdParms)
        {
            return ExecuteReader(this.connectionString, CommandType.Text, SQLString, cmdParms);
        }

        //
        public System.Data.Common.DbDataReader ExecuteReader(string connectionstr, CommandType cmdType, string SQLString, params IDbDataParameter[] cmdParms)
        {

            if (string.IsNullOrEmpty(connectionstr))
            {
                throw new Exception("数据库连接字符串为空");
            }
            //Create the command and connection
            OracleCommand cmd = new OracleCommand();
            OracleConnection conn = new OracleConnection(connectionstr);

            try
            {
                //Prepare the command to execute
                PrepareCommand(cmd, conn, null, cmdType, SQLString, cmdParms);

                //Execute the query, stating that the connection should close when the resulting datareader has been read
                OracleDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //cmd.Parameters.Clear();
                return rdr;

            }
            catch (Exception e)
            { 
                //If an error occurs close the connection as the reader will not be used and we expect it to close the connection
                conn.Close();
                throw e;
            }

        }


        //
        public DataSet Query(string SQLString)
        {
            return Query(this.connectionString, CommandType.Text, SQLString, null);
        }
        //
        public DataSet Query(string SQLString, int Times)
        {
            if (!string.IsNullOrEmpty(this.connectionString))
            {
                throw new Exception("数据库连接字符串为空");
            }
            using (OracleConnection conn = new OracleConnection(this.connectionString))
            {
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                PrepareCommand(cmd, conn, null, CommandType.Text, SQLString, null);
                cmd.CommandTimeout = Times;
                DataSet ds = new DataSet();
                OracleDataAdapter ad = new OracleDataAdapter();
                cmd.CommandText = SQLString;
                ad.SelectCommand = cmd;

                ad.Fill(ds);
                conn.Close();
                return ds;
            }
        }
        //
        public DataSet Query(string SQLString, params IDbDataParameter[] cmdParms)
        {
            return Query(this.connectionString, CommandType.Text, SQLString, cmdParms);
        }
        //
        public DataSet Query(string connectionstr, string SQLString)
        {
            return Query(connectionstr, CommandType.Text, SQLString, null);
        }
        //
        public DataSet Query(string connectionstr, CommandType cmdType, string SQLString)
        {
            return Query(connectionstr, cmdType, SQLString, null);
        }
        //
        public DataSet Query(string connectionstr, CommandType cmdType, string SQLString, params IDbDataParameter[] cmdParms)
        {
            if (string.IsNullOrEmpty(connectionstr))
            {
                throw new Exception("数据库连接字符串为空");
            }
            using (OracleConnection conn = new OracleConnection(connectionstr))
            {
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                PrepareCommand(cmd, conn, null, cmdType, SQLString, cmdParms);

                DataSet ds = new DataSet();
                OracleDataAdapter ad = new OracleDataAdapter();
                cmd.CommandText = SQLString;
                ad.SelectCommand = cmd;

                ad.Fill(ds);

                //try
                //{
                //    XLogManager.LogInfo("sql:" + cmd.CommandText);
                //    XLogManager.LogInfo("dsTableCount:" + ds.Tables.Count.ToString());
                //    foreach (DataTable item in ds.Tables)
                //    {
                //        XLogManager.LogInfo("rows:" + item.Rows.Count);
                //    }

                //}
                //catch (Exception ex)
                //{
                //    XLogManager.LogError("es:"+ex);
                //}
             



                conn.Close();
                return ds;
            }
        }


        /// <summary>
        /// 获得DataSet数据集
        /// </summary>
        /// <param name="strSQL">SQL查询语句</param>
        /// <param name="iMin">记录开始位置</param>
        /// <param name="iMax">记录结束位置</param>
        /// <param name="strTableName">填充返回的表名</param>
        /// <returns>DataSet数据集</returns>
        public System.Data.DataSet GetDateDS(string strSQL, int iMin, int iMax, string strTableName)
        {
            if (!string.IsNullOrEmpty(this.connectionString))
            {
                throw new Exception("数据库连接字符串为空");
            }
            using (OracleConnection Conn = new OracleConnection(connectionString))
            {
                Conn.Open();
                using (OracleCommand Cmd = new OracleCommand())
                {
                    Cmd.Connection = Conn;
                    DataSet ds = new DataSet();
                    OracleDataAdapter ad = new OracleDataAdapter();
                    Cmd.CommandText = strSQL;
                    ad.SelectCommand = Cmd;
                    ad.Fill(ds, iMin, iMax, strTableName);
                    Conn.Close();
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
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            string SqlString = string.Empty;

            int start = (pageIndex - 1) * pageSize;
            int end = pageIndex * pageSize;
            string orderFiled = string.Empty;
            if (string.IsNullOrEmpty(orderBy))
            {
                orderFiled = string.Format("{0} asc", primaryKey);
            }
            else
            {
                orderFiled = orderBy;
            }
            SqlString = string.Format("select * from( select r.{0} ,rownum rn from( select {1}  from {2}  where {3} order by {4} ) r) z  where rn>{5} and   rn<={6}", queryFields, queryFields, tableName, condition, orderFiled, start, end);
            return SqlString;
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

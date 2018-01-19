using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;

namespace RISBroker
{
    /// <summary>
    /// 数据库访问抽象类
    /// </summary>
    public abstract class ADBHelper
    {
        #region 辅助
        /// <summary>
        ///绑定DbCommond
        /// </summary>
        /// <param name="cmd">DbCommand</param>
        /// <param name="conn">DbConnection</param>
        /// <param name="trans">DbTransaction</param>
        /// <param name="cmdType">CommandType</param>
        /// <param name="SqlString">数据库操作字符串</param>
        /// <param name="cmdParms">IDbDataParameter数组</param>
        protected void PrepareCommand(DbCommand cmd, DbConnection conn, DbTransaction trans, CommandType cmdType, string SqlString, IDbDataParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();


            cmd.Connection = conn;
            cmd.CommandText = SqlString;            
            cmd.CommandType = cmdType;
            if (trans != null)
                cmd.Transaction = trans;

            if (cmdParms != null)
            {


                foreach (IDbDataParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }


        /// <summary>    
        /// 分页查询数据记录总数获取    
        /// </summary>    
        /// <param name="_tbName">----要显示的表或多个表的连接</param>    
        /// <param name="_ID">----主表的主键</param>    
        /// <param name="_strCondition">----查询条件,不需where</param>            
        /// <param name="_Dist">----是否添加查询字段的 DISTINCT 默认0不添加/1添加</param>    
        /// <returns></returns>    
        public string getPageListCounts(string _ID, string _tbName, string _strCondition, int _Dist)
        {
            //---存放取得查询结果总数的查询语句                        
            //---对含有DISTINCT的查询进行SQL构造    
            //---对含有DISTINCT的总数查询进行SQL构造    
            string strTmp = "", SqlSelect = "", SqlCounts = "";

            if (_Dist == 0)
            {
                SqlSelect = "Select ";
                SqlCounts = "COUNT(*)";
            }
            else
            {
                SqlSelect = "Select DISTINCT ";
                SqlCounts = "COUNT(DISTINCT " + _ID + ")";
            }
            if (_strCondition == string.Empty)
            {
                strTmp = SqlSelect + " " + SqlCounts + " FROM " + _tbName;
            }
            else
            {
                strTmp = SqlSelect + " " + SqlCounts + " FROM " + " Where (1=1) " + _strCondition;
            }
            return strTmp;
        }

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
        public abstract string getPageListSql(string primaryKey, string queryFields, string tableName, string condition, string orderBy, int pageSize, int pageIndex);


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
        public string GetPagingListSQL(string primaryKey, string queryFields, string tableName, string condition, string orderBy, int pageSize, int pageIndex)
        {
            string sql = getPageListSql(primaryKey, queryFields, tableName, condition, orderBy, pageSize, pageIndex);

            return sql;
        }
        #endregion
    }
}

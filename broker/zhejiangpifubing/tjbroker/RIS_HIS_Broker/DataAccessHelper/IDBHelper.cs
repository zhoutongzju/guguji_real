﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Collections;
using System.Data.Common;

namespace RISBroker
{
    /// <summary>
    /// 数据访问抽象类
    /// </summary>
    public interface IDBHelper
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        string ConnString { get; set; }

        /// <summary>
        /// 打开数据库
        /// </summary>
        bool OpenConnection();

        #region 执行SQL语句


        /// <summary>
        /// 获取列最大值
        /// </summary>
        /// <param name="FieldName">列名</param>
        /// <param name="TableName">表名</param>
        /// <returns></returns>
        int GetMaxID(string FieldName, string TableName);

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns></returns>
        bool Exists(string strSql);

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <param name="cmdParms">参数列表</param>
        /// <returns></returns>
        bool Exists(string strSql, params IDbDataParameter[] cmdParms);

        /// <summary>    
        /// 执行SQL语句，返回影响的记录数    
        /// </summary>    
        /// <param name="connectionstr">数据库连接字符串</param>
        /// <param name="SQLString">SQL语句</param>    
        /// <returns>影响的记录数</returns>    
        int ExecuteSql(string connectionstr, string SQLString);



        /// <summary>    
        /// 执行SQL语句，返回影响的记录数    
        /// </summary>    
        /// <param name="connectionstr">数据库连接字符串</param>
        /// <param name="cmdType">操作类型</param>
        /// <param name="SQLString">SQL语句</param>    
        /// <returns>影响的记录数</returns>    
        int ExecuteSql(string connectionstr, CommandType cmdType, string SQLString);

        /// <summary>    
        /// 执行查询语句，返回DataSet    
        /// </summary>    
        /// <param name="connectionstr">数据库连接字符串</param>
        /// <param name="cmdType">操作类型</param>
        /// <param name="SQLString">SQL语句</param>    
        /// <param name="cmdParms">参数列表</param>
        /// <returns>DataSet</returns>    
        int ExecuteSql(string connectionstr, CommandType cmdType, string SQLString, params IDbDataParameter[] cmdParms);



        /// <summary>    
        /// 执行SQL语句，设置命令的执行等待时间    
        /// </summary>    
        /// <param name="SQLString">SQL语句</param>    
        /// <param name="Times">等待时间</param>    
        /// <returns></returns>    
        int ExecuteSqlByTime(string SQLString, int Times);

        /// <summary>    
        /// 执行SQL语句，设置命令的执行等待时间    
        /// </summary>    
        /// <param name="SQLString">SQL语句</param>    
        /// <param name="Times">等待时间</param>    
        /// <returns></returns>    
        int ExecuteSqlByTime(string connectionstr, string SQLString, int Times);


        /// <summary>    
        /// 执行多条SQL语句，实现数据库事务。    
        /// </summary>    
        /// <param name="SQLStringList">多条SQL语句</param>       
        void ExecuteSqlTran(List<string> SQLStringList);

        /// <summary>    
        /// 执行多条SQL语句，实现数据库事务。    
        /// </summary>    
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的OleDbParameter[]）</param>    
        void ExecuteSqlTran(Hashtable SQLStringList);


        /// <summary>    
        /// 执行多条SQL语句，实现数据库事务。    
        /// </summary>    
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的OleDbParameter[]）</param>    
        void ExecuteSqlTran(string connectionstr, Hashtable SQLStringList, CommandType cmdType);
        #endregion

        #region 执行SQL返回数据


        /// <summary>    
        /// 执行一条计算查询结果语句，返回查询结果（object）。    
        /// </summary>    
        /// <param name="SQLString">计算查询结果语句</param>    
        /// <returns>查询结果（object）</returns>    
        object GetSingle(string SQLString);

        /// <summary>    
        /// 执行一条计算查询结果语句，返回查询结果（object）。    
        /// </summary>    
        /// <param name="SQLString">计算查询结果语句</param>    
        /// <returns>查询结果（object）</returns>    
        object GetSingle(string SQLString, params IDbDataParameter[] cmdParms);

        /// <summary>    
        /// 执行一条计算查询结果语句，返回查询结果（object）。    
        /// </summary>    
        /// <param name="SQLString">计算查询结果语句</param>    
        /// <returns>查询结果（object）</returns>    
        object GetSingle(string connectionstr, CommandType cmdType, string SQLString, params IDbDataParameter[] cmdParms);



        /// <summary>    
        /// 执行查询语句，返回SqlDataReader (使用该方法切记要手工关闭SqlDataReader和连接)    
        /// </summary>    
        /// <param name="strSQL">查询语句</param>    
        /// <returns>SqlDataReader</returns>    
        DbDataReader ExecuteReader(string SQLString, params IDbDataParameter[] cmdParms);

        /// <summary>    
        /// 执行查询语句，返回SqlDataReader(使用该方法切记要手工关闭SqlDataReader和连接)    
        /// </summary>    
        /// <param name="strSQL">查询语句</param>    
        /// <returns>SqlDataReader</returns>    
        DbDataReader ExecuteReader(string connectionstr, CommandType cmdType, string SQLString, params IDbDataParameter[] cmdParms);




        /// <summary>    
        /// 执行查询语句，返回DataSet    
        /// </summary>    
        /// <param name="SQLString">查询语句</param>    
        /// <returns>DataSet</returns>    
        DataSet Query(string SQLString);

        /// <summary>    
        /// 执行查询语句，返回DataSet,设置命令的执行等待时间    
        /// </summary>    
        /// <param name="SQLString">查询语句</param>    
        /// <param name="Times">等待时间</param>    
        /// <returns></returns>    
        DataSet Query(string SQLString, int Times);

        /// <summary>    
        /// 执行查询语句，返回DataSet    
        /// </summary>    
        /// <param name="SQLString">查询语句</param>    
        /// <returns>DataSet</returns>    
        DataSet Query(string SQLString, params IDbDataParameter[] cmdParms);



        /// <summary>    
        /// 执行查询语句，返回DataSet    
        /// </summary>    
        /// <param name="SQLString">查询语句</param>    
        /// <returns>DataSet</returns>    
        DataSet Query(string connectionstr, string SQLString);


        /// <summary>    
        /// 执行查询语句，返回DataSet    
        /// </summary>    
        /// <param name="SQLString">查询语句</param>    
        /// <returns>DataSet</returns>    
        DataSet Query(string connectionstr, CommandType cmdType, string SQLString);

        /// <summary>    
        /// 执行查询语句，返回DataSet    
        /// </summary>    
        /// <param name="SQLString">查询语句</param>    
        /// <returns>DataSet</returns>    
        DataSet Query(string connectionstr, CommandType cmdType, string SQLString, params IDbDataParameter[] cmdParms);
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
        string getPageListSql(string primaryKey, string queryFields, string tableName, string condition, string orderBy, int pageSize, int pageIndex);


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
        DataSet GetPagingList(string primaryKey, string queryFields, string tableName, string condition, string orderBy, int pageSize, int pageIndex);

        /// <summary>    
        /// 获取根据指定字段排序并分页查询。DataSet    
        /// </summary>    
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="pageSize">每页要显示的记录的数目</param>    
        /// <param name="pageIndex">要显示的页的索引</param>    
        /// <param name="tableName">要查询的数据表</param>    
        /// <param name="queryFields">要查询的字段,如果是全部字段请填写：*</param>    
        /// <param name="primaryKey">主键字段，类似排序用到</param>    
        /// <param name="orderBy">是否为升序排列：0为升序，1为降序</param>    
        /// <param name="condition">查询的筛选条件</param>    
        /// <returns>返回排序并分页查询的DataSet</returns>    
        DataSet GetPagingList(string connectionString, string primaryKey, string queryFields, string tableName, string condition, string orderBy, int pageSize, int pageIndex);

        /// <summary>    
        /// 分页查询数据记录总数获取    
        /// </summary>    
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="_ID">----主表的主键</param>    
        /// <param name="_tbName">----要显示的表或多个表的连接</param>           
        /// <param name="_strCondition">----查询条件,不需where</param>            
        /// <param name="_Dist">----是否添加查询字段的 DISTINCT 默认0不添加/1添加</param>    
        /// <returns></returns>  
        int GetRecordCount(string connectionString, string _ID, string _tbName, string _strCondition, int _Dist);

        /// <summary>    
        /// 分页查询数据记录总数获取    
        /// </summary>    
        /// <param name="_ID">----主表的主键</param>    
        /// <param name="_tbName">----要显示的表或多个表的连接</param>           
        /// <param name="_strCondition">----查询条件,不需where</param>            
        /// <param name="_Dist">----是否添加查询字段的 DISTINCT 默认0不添加/1添加</param>    
        /// <returns></returns>  
        int GetRecordCount(string _ID, string _tbName, string _strCondition, int _Dist);
        #endregion
    }
}

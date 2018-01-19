using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RISBroker
{
    public class SQLHelper
    {
        private SqlConnection SqlConnection;

        private string connstr;
        public SQLHelper(string str)
        {
            this.connstr = str;
        }
       
      

        #region 初始化数据
     

        /// <summary>
        /// 初始化数据并打开数据库链接
        /// </summary>
        private void OpenConnection()
        {
            SqlConnection = new System.Data.SqlClient.SqlConnection(connstr);
            SqlConnection.Open();
        }

        #endregion

        #region 运行无结果集的Sql语句--ExecutenonQuery

        /// <summary>
        /// 执行无结果集的Sql语句，返回Sql影响的记录行数
        /// </summary>
        /// <param name="strSql">要执行的Sql语句</param>
        /// <returns>返回Sql影响的记录行数</returns>
        public int ExecuteNonQuery(string strSql)
        {
            try
            {
                OpenConnection();
                SqlCommand sqlcmd = new SqlCommand(strSql, SqlConnection);
                return sqlcmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SqlConnection.Close();
            }
        }

        /// <summary>
        /// 执行无结果集的Sql语句，返回Sql影响的记录行数
        /// </summary>
        /// <param name="strSql">要执行的Sql语句</param>
        /// <param name="sqlParameter">Sql的参数</param>
        /// <returns>返回Sql影响的记录行数</returns>
        public int ExecuteNonQuery(string strSql, SqlParameter sqlParameter)
        {
            try
            {
                OpenConnection();
                SqlCommand sqlcmd = new SqlCommand(strSql, SqlConnection);
                sqlcmd.Parameters.Add(sqlParameter);

                return sqlcmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SqlConnection.Close();
            }
        }

        /// <summary>
        /// 执行无结果集的Sql语句，返回Sql影响的记录行数
        /// </summary>
        /// <param name="strSql">要执行的Sql语句</param>
        /// <param name="sqlParameter">Sql的参数集合</param>
        /// <returns>返回Sql影响的记录行数</returns>
        public int ExecuteNonQuery(string strSql, SqlParameter[] SqlParameters)
        {
            try
            {
                OpenConnection();
                SqlCommand sqlcmd = new SqlCommand(strSql, SqlConnection);
                for (int i = 0; i < SqlParameters.Length; i++)
                {
                    sqlcmd.Parameters.Add(SqlParameters[i]);
                }

                return sqlcmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SqlConnection.Close();
            }
        }

        #endregion

        #region 按照ExecuteQuery方式运行sql并返回结果集

        /// <summary>
        /// 运行sql并返回结果集DataSet
        /// </summary>
        /// <param name="Sql">要运行的Sql语句</param>
        /// <returns>sql运行结果集DataSet</returns>
        public DataSet ExecuteQuery(string Sql)
        {
            try
            {
                OpenConnection();
                DataSet ds = new DataSet();
                new SqlDataAdapter(Sql, SqlConnection).Fill(ds);
                return ds;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SqlConnection.Close();
            }
        }

        /// <summary>
        /// 运行sql并返回结果集DataSet
        /// </summary>
        /// <param name="Sql">要运行的Sql语句</param>
        /// <param name="sqlParameter">Sql的参数</param>
        /// <returns>sql运行结果集DataSet</returns>
        public DataSet ExecuteQuery(string Sql, SqlParameter sqlParameter)
        {
            try
            {
                OpenConnection();
                DataSet ds = new DataSet();
                SqlCommand sqlcmd = new SqlCommand(Sql, SqlConnection);
                sqlcmd.Parameters.Add(sqlParameter);
                new SqlDataAdapter(sqlcmd).Fill(ds);
                return ds;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SqlConnection.Close();
            }
        }

        /// <summary>
        /// 运行sql并返回结果集DataSet
        /// </summary>
        /// <param name="Sql">要运行的Sql语句</param>
        /// <param name="sqlParameter">Sql的参数集合</param>
        /// <returns>sql运行结果集DataSet</returns>
        public DataSet ExecuteQuery(string Sql, SqlParameter[] sqlParameters)
        {
            try
            {
                OpenConnection();
                DataSet ds = new DataSet();
                SqlCommand sqlcmd = new SqlCommand(Sql, SqlConnection);
                for (int i = 0; i < sqlParameters.Length; i++)
                {
                    sqlcmd.Parameters.Add(sqlParameters[i]);
                }
                new SqlDataAdapter(sqlcmd).Fill(ds);
                return ds;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SqlConnection.Close();
            }
        }

        #endregion

        #region 事务模式运行sql
        /// <summary>
        /// 事务模式运行sql语句的集合
        /// </summary>
        /// <param name="sqls">要运行sql语句的集合</param>
        public void ExecuteTran(string[] sqls)
        {
            OpenConnection();
            SqlTransaction myTrans = SqlConnection.BeginTransaction();
            SqlCommand sqlcmd = SqlConnection.CreateCommand();
            sqlcmd.Transaction = myTrans;
            try
            {
                for (int i = 0; i < sqls.Length; i++)
                {
                    sqlcmd.CommandText = sqls[i];
                    sqlcmd.ExecuteNonQuery();
                }
                myTrans.Commit();
            }
            catch (Exception e)
            {
                try
                {
                    myTrans.Rollback();
                    throw e;
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
            finally
            {
                SqlConnection.Close();
            }
        }

        #endregion

        #region 获取数据预设链接的SqlCommand对象

        /// <summary>
        /// 先获取数据预设链接的SqlConnection对象（未打开链接），通常使用在外部装配类的时候进行事务性处理。
        /// </summary>
        /// <returns>SqlCommand对象</returns>
        public SqlCommand GetSqlCommand()
        {
            OpenConnection();
            return SqlConnection.CreateCommand();
        }

        #endregion
    }
}

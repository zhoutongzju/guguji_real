using System;
using System.Data;
using System.Data.OracleClient;
using System.Collections;
using Maroland.DataAccess;


namespace RISBroker
{
    public class T_reporttofile : DataObject
    {
        #region		表及字段定义
        public const string TabName = "T_REPORTTOHIS";
        /// <summary>
        /// 主键
        /// </summary>
        public const string F_Id = "ID";
        /// <summary>
        /// 操作日期
        /// </summary>
        public const string F_Datetime = "DATETIME";
        /// <summary>
        /// 序列主键
        /// </summary>
        public const string F_Queueid = "QUEUEID";
        /// <summary>
        /// 结果
        /// </summary>
        public const string F_Result = "RESULT";
        #endregion
        public T_reporttofile()
        {
            this._strTable = TabName;
        }
        #region		私有变量
        private string _Id = null;
        private string _Datetime = null;
        private string _Queueid = null;
        private string _Result = null;
        #endregion
        #region 公开属性定义
        /// <summary>
        /// 主键
        /// </summary>
        public string Id
        {
            get
            {
                return _Id;
            }

            set
            {
                _Id = value;
                if (value != null) base.RecodeChange(F_Id);
            }
        }
        /******************************************************/
        /// <summary>
        /// 操作日期
        /// </summary>
        public string Datetime
        {
            get
            {
                return _Datetime;
            }

            set
            {
                _Datetime = value;
                if (value != null) base.RecodeChange(F_Datetime);
            }
        }
        /******************************************************/
        /// <summary>
        /// 序列主键
        /// </summary>
        public string Queueid
        {
            get
            {
                return _Queueid;
            }

            set
            {
                _Queueid = value;
                if (value != null) base.RecodeChange(F_Queueid);
            }
        }
        /******************************************************/
        /// <summary>
        /// 结果
        /// </summary>
        public string Result
        {
            get
            {
                return _Result;
            }

            set
            {
                _Result = value;
                if (value != null) base.RecodeChange(F_Result);
            }
        }
        /******************************************************/
        #endregion
        public override OracleParameter GetParameter(string strParamName)
        {
            OracleParameter param = new OracleParameter();
            switch (strParamName)
            {
                case F_Id:
                    param.OracleType = OracleType.NVarChar;
                    param.ParameterName = ":" + F_Id;
                    param.Size = 64;
                    param.Value = _Id;
                    break;
                case F_Datetime:
                    param.OracleType = OracleType.DateTime;
                    param.ParameterName = ":" + F_Datetime;
                    param.Size = 7;
                    param.Value = _Datetime;
                    break;
                case F_Queueid:
                    param.OracleType = OracleType.NVarChar;
                    param.ParameterName = ":" + F_Queueid;
                    param.Size = 18;
                    param.Value = _Queueid;
                    break;
                case F_Result:
                    param.OracleType = OracleType.Char;
                    param.ParameterName = ":" + F_Result;
                    param.Size = 10;
                    param.Value = _Result;
                    break;
            }
            return param;
        }
        protected override void SetValueToMemberByName(string strName, string strValue)
        {
            switch (strName)
            {
                case F_Id:
                    Id = strValue;
                    break;
                case F_Datetime:
                    Datetime = strValue;
                    break;
                case F_Queueid:
                    Queueid = strValue;
                    break;
                case F_Result:
                    Result = strValue;
                    break;
                default: throw new Exception("控件名字没有对应的数据库字段：" + strName);
            }
        }
    }
}

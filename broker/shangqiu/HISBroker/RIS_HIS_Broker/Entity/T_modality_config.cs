using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Text;
using Maroland.DataAccess;

namespace RISBroker
{
    public class T_modality_config : DataObject
    {
        #region		表及字段定义
        public const string TabName = "T_MODALITY_CONFIG";
        /// <summary>
        /// 系统模态（如CR，CT，US）等
        /// </summary>
        public const string F_Modality = "MODALITY";
        /// <summary>
        /// 模态扩充（可以随意扩充）
        /// </summary>
        public const string F_Modalityexpand = "MODALITYEXPAND";
        /// <summary>
        /// 备注
        /// </summary>
        public const string F_Remark = "REMARK";
        /// <summary>
        /// 模态格式化
        /// </summary>
        public const string F_Modalityformat = "MODALITYFORMAT";
        /// <summary>
        /// 模态显示名称（主要是worklist显示下）
        /// </summary>
        public const string F_Modalityname = "MODALITYNAME";
        #endregion
        public T_modality_config()
        {
            this._strTable = TabName;
        }
        #region		私有变量
        private string _Modality = null;
        private string _Modalityexpand = null;
        private string _Remark = null;
        private string _Modalityformat = null;
        private string _Modalityname = null;
        #endregion
        #region 公开属性定义
        /// <summary>
        /// 系统模态（如CR，CT，US）等
        /// </summary>
        public string Modality
        {
            get
            {
                return _Modality;
            }

            set
            {
                _Modality = value;
                if (value != null) base.RecodeChange(F_Modality);
            }
        }
        /******************************************************/
        /// <summary>
        /// 模态扩充（可以随意扩充）
        /// </summary>
        public string Modalityexpand
        {
            get
            {
                return _Modalityexpand;
            }

            set
            {
                _Modalityexpand = value;
                if (value != null) base.RecodeChange(F_Modalityexpand);
            }
        }
        /******************************************************/
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get
            {
                return _Remark;
            }

            set
            {
                _Remark = value;
                if (value != null) base.RecodeChange(F_Remark);
            }
        }
        /******************************************************/
        /// <summary>
        /// 模态格式化
        /// </summary>
        public string Modalityformat
        {
            get
            {
                return _Modalityformat;
            }

            set
            {
                _Modalityformat = value;
                if (value != null) base.RecodeChange(F_Modalityformat);
            }
        }
        /******************************************************/
        /// <summary>
        /// 模态显示名称（主要是worklist显示下）
        /// </summary>
        public string Modalityname
        {
            get
            {
                return _Modalityname;
            }

            set
            {
                _Modalityname = value;
                if (value != null) base.RecodeChange(F_Modalityname);
            }
        }
        /******************************************************/
        #endregion
        public override OracleParameter GetParameter(string strParamName)
        {
            OracleParameter param = new OracleParameter();
            switch (strParamName)
            {
                case F_Modality:
                    param.OracleType = OracleType.Char;
                    param.ParameterName = ":" + F_Modality;
                    param.Size = 4;
                    param.Value = _Modality;
                    break;
                case F_Modalityexpand:
                    param.OracleType = OracleType.Char;
                    param.ParameterName = ":" + F_Modalityexpand;
                    param.Size = 4;
                    param.Value = _Modalityexpand;
                    break;
                case F_Remark:
                    param.OracleType = OracleType.NVarChar;
                    param.ParameterName = ":" + F_Remark;
                    param.Size = 500;
                    param.Value = _Remark;
                    break;
                case F_Modalityformat:
                    param.OracleType = OracleType.NVarChar;
                    param.ParameterName = ":" + F_Modalityformat;
                    param.Size = 20;
                    param.Value = _Modalityformat;
                    break;
                case F_Modalityname:
                    param.OracleType = OracleType.NVarChar;
                    param.ParameterName = ":" + F_Modalityname;
                    param.Size = 20;
                    param.Value = _Modalityname;
                    break;
            }
            return param;
        }
        protected override void SetValueToMemberByName(string strName, string strValue)
        {
            switch (strName)
            {
                case F_Modality:
                    Modality = strValue;
                    break;
                case F_Modalityexpand:
                    Modalityexpand = strValue;
                    break;
                case F_Remark:
                    Remark = strValue;
                    break;
                case F_Modalityformat:
                    Modalityformat = strValue;
                    break;
                case F_Modalityname:
                    Modalityname = strValue;
                    break;
                default: throw new Exception("控件名字没有对应的数据库字段：" + strName);
            }
        }
    }
}

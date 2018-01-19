using System;
using System.Data;
using System.Data.OracleClient;
using System.Collections;
using Maroland.DataAccess;


namespace RISBroker
{
    public class T_Dictionary : DataObject
    {
        #region		表及字段定义
        public const string TabName = "T_DICTIONARY";
        public const string F_Dictionaryid = "DICTIONARYID";
        public const string F_Diccategory = "DICCATEGORY";
        public const string F_Itemcode = "ITEMCODE";
        public const string F_Srm = "SRM";
        public const string F_Itemname = "ITEMNAME";
        public const string F_Deleted = "DELETED";
        public const string F_Sequence = "SEQUENCE";
        public const string F_Reserved2 = "RESERVED2";
        public const string F_Reserved3 = "RESERVED3";
        #endregion
        public T_Dictionary()
        {
            this._strTable = TabName;
        }
        #region		私有变量
        private string _Dictionaryid = null;
        private string _Diccategory = null;
        private string _Itemcode = null;
        private string _Srm = null;
        private string _Itemname = null;
        private string _Deleted = null;
        private string _Sequence = null;
        private string _Reserved2 = null;
        private string _Reserved3 = null;
        #endregion
        #region 公开属性定义
        public string Dictionaryid
        {
            get
            {
                return _Dictionaryid;
            }

            set
            {
                _Dictionaryid = value;
                base.RecodeChange(F_Dictionaryid);
            }
        }
        /******************************************************/
        public string Diccategory
        {
            get
            {
                return _Diccategory;
            }

            set
            {
                _Diccategory = value;
                base.RecodeChange(F_Diccategory);
            }
        }
        /******************************************************/
        public string Itemcode
        {
            get
            {
                return _Itemcode;
            }

            set
            {
                _Itemcode = value;
                base.RecodeChange(F_Itemcode);
            }
        }
        /******************************************************/
        public string Srm
        {
            get
            {
                return _Srm;
            }

            set
            {
                _Srm = value;
                base.RecodeChange(F_Srm);
            }
        }
        /******************************************************/
        public string Itemname
        {
            get
            {
                return _Itemname;
            }

            set
            {
                _Itemname = value;
                base.RecodeChange(F_Itemname);
            }
        }
        /******************************************************/
        public string Deleted
        {
            get
            {
                return _Deleted;
            }

            set
            {
                _Deleted = value;
                base.RecodeChange(F_Deleted);
            }
        }
        /******************************************************/
        public string Sequence
        {
            get
            {
                return _Sequence;
            }

            set
            {
                _Sequence = value;
                base.RecodeChange(F_Sequence);
            }
        }
        /******************************************************/
        public string Reserved2
        {
            get
            {
                return _Reserved2;
            }

            set
            {
                _Reserved2 = value;
                base.RecodeChange(F_Reserved2);
            }
        }
        /******************************************************/
        public string Reserved3
        {
            get
            {
                return _Reserved3;
            }

            set
            {
                _Reserved3 = value;
                base.RecodeChange(F_Reserved3);
            }
        }
        /******************************************************/
        #endregion
        public override OracleParameter GetParameter(string strParamName)
        {
            OracleParameter param = new OracleParameter();
            switch (strParamName)
            {
                case F_Dictionaryid:
                    param.OracleType = OracleType.NVarChar;
                    param.ParameterName = ":" + F_Dictionaryid;
                    param.Size = 64;
                    param.Value = _Dictionaryid;
                    break;
                case F_Diccategory:
                    param.OracleType = OracleType.Char;
                    param.ParameterName = ":" + F_Diccategory;
                    param.Size = 4;
                    param.Value = _Diccategory;
                    break;
                case F_Itemcode:
                    param.OracleType = OracleType.NVarChar;
                    param.ParameterName = ":" + F_Itemcode;
                    param.Size = 64;
                    param.Value = _Itemcode;
                    break;
                case F_Srm:
                    param.OracleType = OracleType.NVarChar;
                    param.ParameterName = ":" + F_Srm;
                    param.Size = 16;
                    param.Value = _Srm;
                    break;
                case F_Itemname:
                    param.OracleType = OracleType.NVarChar;
                    param.ParameterName = ":" + F_Itemname;
                    param.Size = 64;
                    param.Value = _Itemname;
                    break;
                case F_Deleted:
                    param.OracleType = OracleType.Char;
                    param.ParameterName = ":" + F_Deleted;
                    param.Size = 1;
                    param.Value = _Deleted;
                    break;
                case F_Sequence:
                    param.OracleType = OracleType.NVarChar;
                    param.ParameterName = ":" + F_Sequence;
                    param.Size = 64;
                    param.Value = _Sequence;
                    break;
                case F_Reserved2:
                    param.OracleType = OracleType.NVarChar;
                    param.ParameterName = ":" + F_Reserved2;
                    param.Size = 64;
                    param.Value = _Reserved2;
                    break;
                case F_Reserved3:
                    param.OracleType = OracleType.NVarChar;
                    param.ParameterName = ":" + F_Reserved3;
                    param.Size = 64;
                    param.Value = _Reserved3;
                    break;
            }
            return param;
        }
        protected override void SetValueToMemberByName(string strName, string strValue)
        {
            switch (strName)
            {
                case F_Dictionaryid:
                    Dictionaryid = strValue;
                    break;
                case F_Diccategory:
                    Diccategory = strValue;
                    break;
                case F_Itemcode:
                    Itemcode = strValue;
                    break;
                case F_Srm:
                    Srm = strValue;
                    break;
                case F_Itemname:
                    Itemname = strValue;
                    break;
                case F_Deleted:
                    Deleted = strValue;
                    break;
                case F_Sequence:
                    Sequence = strValue;
                    break;
                case F_Reserved2:
                    Reserved2 = strValue;
                    break;
                case F_Reserved3:
                    Reserved3 = strValue;
                    break;
                default: throw new Exception("控件名字没有对应的数据库字段：" + strName);
            }
        }
    }
}

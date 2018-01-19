using System;
using System.Collections.Generic;
using System.Data.OracleClient;
 
using System.Text;
using Maroland.DataAccess;

namespace RISBroker
{
    public class T_gm_examitem : DataObject
    {
        #region		表及字段定义
        public const string TabName = "T_GM_EXAMITEM";
        /// <summary>
        /// 主键
        /// </summary>
        public const string F_Itemid = "ITEMID";
        /// <summary>
        /// 代码
        /// </summary>
        public const string F_Itemcode = "ITEMCODE";
        /// <summary>
        /// 输入码
        /// </summary>
        public const string F_Srm = "SRM";
        /// <summary>
        /// 检查名称
        /// </summary>
        public const string F_Itemname = "ITEMNAME";
        /// <summary>
        /// 最大号
        /// </summary>
        public const string F_Maxid = "MAXID";
        /// <summary>
        /// 格式类型
        /// </summary>
        public const string F_Formattype = "FORMATTYPE";
        /// <summary>
        /// 格式
        /// </summary>
        public const string F_Format = "FORMAT";
        /// <summary>
        /// 是否删除[0--否;1--是]
        /// </summary>
        public const string F_Deleted = "DELETED";
        /// <summary>
        /// 顺序
        /// </summary>
        public const string F_Sequence = "SEQUENCE";
        /// <summary>
        /// MAXID生成日期
        /// </summary>
        public const string F_Maxiddate = "MAXIDDATE";
        /// <summary>
        /// 检查名称(英文名)
        /// </summary>
        public const string F_Itemeng = "ITEMENG";
        /// <summary>
        /// 
        /// </summary>
        public const string F_Schemeid = "SCHEMEID";
        /// <summary>
        /// 模态号
        /// </summary>
        public const string F_Modality = "MODALITY";
        /// <summary>
        /// 前坠
        /// </summary>
        public const string F_Prefix = "PREFIX";
        /// <summary>
        /// 分隔号
        /// </summary>
        public const string F_Separatrix = "SEPARATRIX";
        /// <summary>
        /// 是否是病理的检查项目（如免疫等不能算病理检查项目）
        /// </summary>
        public const string F_Isgmexamtype = "ISGMEXAMTYPE";
        #endregion
        public T_gm_examitem()
        {
            this._strTable = TabName;
        }
        #region		私有变量
        private string _Itemid = null;
        private string _Itemcode = null;
        private string _Srm = null;
        private string _Itemname = null;
        private string _Maxid = null;
        private string _Formattype = null;
        private string _Format = null;
        private string _Deleted = null;
        private string _Sequence = null;
        private string _Maxiddate = null;
        private string _Itemeng = null;
        private string _Schemeid = null;
        private string _Modality = null;
        private string _Prefix = null;
        private string _Separatrix = null;
        private string _Isgmexamtype = null;
        #endregion
        #region 公开属性定义
        /// <summary>
        /// 主键
        /// </summary>
        public string Itemid
        {
            get
            {
                return _Itemid;
            }

            set
            {
                _Itemid = value;
                if (value != null) base.RecodeChange(F_Itemid);
            }
        }
        /******************************************************/
        /// <summary>
        /// 代码
        /// </summary>
        public string Itemcode
        {
            get
            {
                return _Itemcode;
            }

            set
            {
                _Itemcode = value;
                if (value != null) base.RecodeChange(F_Itemcode);
            }
        }
        /******************************************************/
        /// <summary>
        /// 输入码
        /// </summary>
        public string Srm
        {
            get
            {
                return _Srm;
            }

            set
            {
                _Srm = value;
                if (value != null) base.RecodeChange(F_Srm);
            }
        }
        /******************************************************/
        /// <summary>
        /// 检查名称
        /// </summary>
        public string Itemname
        {
            get
            {
                return _Itemname;
            }

            set
            {
                _Itemname = value;
                if (value != null) base.RecodeChange(F_Itemname);
            }
        }
        /******************************************************/
        /// <summary>
        /// 最大号
        /// </summary>
        public string Maxid
        {
            get
            {
                return _Maxid;
            }

            set
            {
                _Maxid = value;
                if (value != null) base.RecodeChange(F_Maxid);
            }
        }
        /******************************************************/
        /// <summary>
        /// 格式类型
        /// </summary>
        public string Formattype
        {
            get
            {
                return _Formattype;
            }

            set
            {
                _Formattype = value;
                if (value != null) base.RecodeChange(F_Formattype);
            }
        }
        /******************************************************/
        /// <summary>
        /// 格式
        /// </summary>
        public string Format
        {
            get
            {
                return _Format;
            }

            set
            {
                _Format = value;
                if (value != null) base.RecodeChange(F_Format);
            }
        }
        /******************************************************/
        /// <summary>
        /// 是否删除[0--否;1--是]
        /// </summary>
        public string Deleted
        {
            get
            {
                return _Deleted;
            }

            set
            {
                _Deleted = value;
                if (value != null) base.RecodeChange(F_Deleted);
            }
        }
        /******************************************************/
        /// <summary>
        /// 顺序
        /// </summary>
        public string Sequence
        {
            get
            {
                return _Sequence;
            }

            set
            {
                _Sequence = value;
                if (value != null) base.RecodeChange(F_Sequence);
            }
        }
        /******************************************************/
        /// <summary>
        /// MAXID生成日期
        /// </summary>
        public string Maxiddate
        {
            get
            {
                return _Maxiddate;
            }

            set
            {
                _Maxiddate = value;
                if (value != null) base.RecodeChange(F_Maxiddate);
            }
        }
        /******************************************************/
        /// <summary>
        /// 检查名称(英文名)
        /// </summary>
        public string Itemeng
        {
            get
            {
                return _Itemeng;
            }

            set
            {
                _Itemeng = value;
                if (value != null) base.RecodeChange(F_Itemeng);
            }
        }
        /******************************************************/
        /// <summary>
        /// 
        /// </summary>
        public string Schemeid
        {
            get
            {
                return _Schemeid;
            }

            set
            {
                _Schemeid = value;
                if (value != null) base.RecodeChange(F_Schemeid);
            }
        }
        /******************************************************/
        /// <summary>
        /// 模态号
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
        /// 前坠
        /// </summary>
        public string Prefix
        {
            get
            {
                return _Prefix;
            }

            set
            {
                _Prefix = value;
                if (value != null) base.RecodeChange(F_Prefix);
            }
        }
        /******************************************************/
        /// <summary>
        /// 分隔号
        /// </summary>
        public string Separatrix
        {
            get
            {
                return _Separatrix;
            }

            set
            {
                _Separatrix = value;
                if (value != null) base.RecodeChange(F_Separatrix);
            }
        }
        /******************************************************/
        /// <summary>
        /// 是否是病理的检查项目（如免疫等不能算病理检查项目）
        /// </summary>
        public string Isgmexamtype
        {
            get
            {
                return _Isgmexamtype;
            }

            set
            {
                _Isgmexamtype = value;
                if (value != null) base.RecodeChange(F_Isgmexamtype);
            }
        }
        /******************************************************/
        #endregion
        public override OracleParameter GetParameter(string strParamName)
        {
            OracleParameter param = new OracleParameter();
            switch (strParamName)
            {
                case F_Itemid:
                    param.OracleType = OracleType.NVarChar;
                    param.ParameterName = ":" + F_Itemid;
                    param.Size = 64;
                    param.Value = _Itemid;
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
                    param.Size = 64;
                    param.Value = _Srm;
                    break;
                case F_Itemname:
                    param.OracleType = OracleType.NVarChar;
                    param.ParameterName = ":" + F_Itemname;
                    param.Size = 64;
                    param.Value = _Itemname;
                    break;
                case F_Maxid:
                    param.OracleType = OracleType.NVarChar;
                    param.ParameterName = ":" + F_Maxid;
                    param.Size = 64;
                    param.Value = _Maxid;
                    break;
                case F_Formattype:
                    param.OracleType = OracleType.Char;
                    param.ParameterName = ":" + F_Formattype;
                    param.Size = 4;
                    param.Value = _Formattype;
                    break;
                case F_Format:
                    param.OracleType = OracleType.NVarChar;
                    param.ParameterName = ":" + F_Format;
                    param.Size = 64;
                    param.Value = _Format;
                    break;
                case F_Deleted:
                    param.OracleType = OracleType.Char;
                    param.ParameterName = ":" + F_Deleted;
                    param.Size = 1;
                    param.Value = _Deleted;
                    break;
                case F_Sequence:
                    param.OracleType = OracleType.Number;
                    param.ParameterName = ":" + F_Sequence;
                    param.Size = 22;
                    param.Value = _Sequence;
                    break;
                case F_Maxiddate:
                    param.OracleType = OracleType.NVarChar;
                    param.ParameterName = ":" + F_Maxiddate;
                    param.Size = 10;
                    param.Value = _Maxiddate;
                    break;
                case F_Itemeng:
                    param.OracleType = OracleType.NVarChar;
                    param.ParameterName = ":" + F_Itemeng;
                    param.Size = 64;
                    param.Value = _Itemeng;
                    break;
                case F_Schemeid:
                    param.OracleType = OracleType.NVarChar;
                    param.ParameterName = ":" + F_Schemeid;
                    param.Size = 64;
                    param.Value = _Schemeid;
                    break;
                case F_Modality:
                    param.OracleType = OracleType.NVarChar;
                    param.ParameterName = ":" + F_Modality;
                    param.Size = 64;
                    param.Value = _Modality;
                    break;
                case F_Prefix:
                    param.OracleType = OracleType.NVarChar;
                    param.ParameterName = ":" + F_Prefix;
                    param.Size = 4;
                    param.Value = _Prefix;
                    break;
                case F_Separatrix:
                    param.OracleType = OracleType.Char;
                    param.ParameterName = ":" + F_Separatrix;
                    param.Size = 1;
                    param.Value = _Separatrix;
                    break;
                case F_Isgmexamtype:
                    param.OracleType = OracleType.Char;
                    param.ParameterName = ":" + F_Isgmexamtype;
                    param.Size = 1;
                    param.Value = _Isgmexamtype;
                    break;
            }
            return param;
        }
        protected override void SetValueToMemberByName(string strName, string strValue)
        {
            switch (strName)
            {
                case F_Itemid:
                    Itemid = strValue;
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
                case F_Maxid:
                    Maxid = strValue;
                    break;
                case F_Formattype:
                    Formattype = strValue;
                    break;
                case F_Format:
                    Format = strValue;
                    break;
                case F_Deleted:
                    Deleted = strValue;
                    break;
                case F_Sequence:
                    Sequence = strValue;
                    break;
                case F_Maxiddate:
                    Maxiddate = strValue;
                    break;
                case F_Itemeng:
                    Itemeng = strValue;
                    break;
                case F_Schemeid:
                    Schemeid = strValue;
                    break;
                case F_Modality:
                    Modality = strValue;
                    break;
                case F_Prefix:
                    Prefix = strValue;
                    break;
                case F_Separatrix:
                    Separatrix = strValue;
                    break;
                case F_Isgmexamtype:
                    Isgmexamtype = strValue;
                    break;
                default: throw new Exception("控件名字没有对应的数据库字段：" + strName);
            }
        }
    }
}

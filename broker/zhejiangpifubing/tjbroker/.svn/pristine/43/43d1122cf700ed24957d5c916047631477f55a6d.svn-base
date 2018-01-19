using System;
using System.Data;
using System.Data.OracleClient;
using System.Collections;
using Maroland.DataAccess;


namespace RISBroker
{
	public class T_Report:DataObject
	{
		#region		表及字段定义
		public const string TabName  = "T_Report";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Reportseq="REPORTSEQ";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Hospitalid="HOSPITALID";
		/// <summary>
		/// 检查项目
		/// </summary>
		public const string F_Examitem="EXAMITEM";
		/// <summary>
		/// 检查所见
		/// </summary>
		public const string F_Studyresult="STUDYRESULT";
		/// <summary>
		/// 诊断结果
		/// </summary>
		public const string F_Diagresult="DIAGRESULT";
		/// <summary>
		/// 建议
		/// </summary>
		public const string F_Advice="ADVICE";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Reportdr="REPORTDR";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Reportdrid="REPORTDRID";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Verifydr="VERIFYDR";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Verifydrid="VERIFYDRID";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Medic="MEDIC";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Medicid="MEDICID";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Reporttype="REPORTTYPE";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Keywords1="KEYWORDS1";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Keywords2="KEYWORDS2";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Keywords3="KEYWORDS3";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Extrakeywords="EXTRAKEYWORDS";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Reportdt="REPORTDT";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Verifydt="VERIFYDT";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Printdt="PRINTDT";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Templateid="TEMPLATEID";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Modified="MODIFIED";
		/// <summary>
		/// 临时报告标志
		/// </summary>
		public const string F_Tempreport="TEMPREPORT";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Abnormal="ABNORMAL";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Reportstatus="REPORTSTATUS";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Deleted="DELETED";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Reportremark="REPORTREMARK";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Fixpicno="FIXPICNO";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Displaytype="DISPLAYTYPE";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Verifydr2="VERIFYDR2";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Verifydrid2="VERIFYDRID2";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Bstudyresult="BSTUDYRESULT";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Bdiagresult="BDIAGRESULT";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Cstudyresult="CSTUDYRESULT";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Cdiagresult="CDIAGRESULT";
		/// <summary>
		/// 报告退回理由
		/// </summary>
		public const string F_Rejectreason="REJECTREASON";
		/// <summary>
		/// 分发确认标记(0=未确认,1=确认)
		/// </summary>
		public const string F_Deliveraffirm="DELIVERAFFIRM";
		/// <summary>
		/// 外院诊断结果（为空吻合）
		/// </summary>
		public const string F_Outhospitaldiagresult="OUTHOSPITALDIAGRESULT";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Modifydiagresult="MODIFYDIAGRESULT";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Modifyreason="MODIFYREASON";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Modifytime="MODIFYTIME";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Modifystate="MODIFYSTATE";
		/// <summary>
		/// 2次 冰冻修改报告内容
		/// </summary>
		public const string F_Smodifydiagresult="SMODIFYDIAGRESULT";
		/// <summary>
		/// 2次 修改冰冻报告原因
		/// </summary>
		public const string F_Smodifyreason="SMODIFYREASON";
		/// <summary>
		/// 2次 修改冰冻报告时间
		/// </summary>
		public const string F_Smodifytime="SMODIFYTIME";
        /// <summary>
        /// 
        /// </summary>
        public const string F_Verifydt2 = "VERIFYDT2";
		#endregion
		public T_Report()
		{
			this._strTable =TabName;
		}
		#region		私有变量
		private string _Reportseq=null;
		private string _Hospitalid=null;
		private string _Examitem=null;
		private string _Studyresult=null;
		private string _Diagresult=null;
		private string _Advice=null;
		private string _Reportdr=null;
		private string _Reportdrid=null;
		private string _Verifydr=null;
		private string _Verifydrid=null;
		private string _Medic=null;
		private string _Medicid=null;
		private string _Reporttype=null;
		private string _Keywords1=null;
		private string _Keywords2=null;
		private string _Keywords3=null;
		private string _Extrakeywords=null;
		private string _Reportdt=null;
		private string _Verifydt=null;
        private string _Verifydt2 = null;
		private string _Printdt=null;
		private string _Templateid=null;
		private string _Modified=null;
		private string _Tempreport=null;
		private string _Abnormal=null;
		private string _Reportstatus=null;
		private string _Deleted=null;
		private string _Reportremark=null;
		private string _Fixpicno=null;
		private string _Displaytype=null;
		private string _Verifydr2=null;
		private string _Verifydrid2=null;
		private string _Bstudyresult=null;
	//	private string _Bdiagresult=null;
		private byte[] _Bdiagresult = null;
		private string _Cstudyresult=null;
		private string _Cdiagresult=null;
		private string _Rejectreason=null;
		private string _Deliveraffirm=null;
		private string _Outhospitaldiagresult=null;
		private string _Modifydiagresult=null;
		private string _Modifyreason=null;
		private string _Modifytime=null;
		private string _Modifystate=null;
		private string _Smodifydiagresult=null;
		private string _Smodifyreason=null;
		private string _Smodifytime=null;
		#endregion
		#region 公开属性定义
		/// <summary>
		/// 
		/// </summary>
		public   string   Reportseq
		{
			get
			{
				return _Reportseq;
			}
            
			set
			{
				_Reportseq=value;
				if(value!=null) base.RecodeChange(F_Reportseq);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Hospitalid
		{
			get
			{
				return _Hospitalid;
			}
            
			set
			{
				_Hospitalid=value;
				if(value!=null) base.RecodeChange(F_Hospitalid);
			}
		}
		/******************************************************/
		/// <summary>
		/// 检查项目
		/// </summary>
		public   string   Examitem
		{
			get
			{
				return _Examitem;
			}
            
			set
			{
				_Examitem=value;
				if(value!=null) base.RecodeChange(F_Examitem);
			}
		}
		/******************************************************/
		/// <summary>
		/// 检查所见
		/// </summary>
		public   string   Studyresult
		{
			get
			{
				return _Studyresult;
			}
            
			set
			{
				_Studyresult=value;
				if(value!=null) base.RecodeChange(F_Studyresult);
			}
		}
		/******************************************************/
		/// <summary>
		/// 诊断结果
		/// </summary>
		public   string   Diagresult
		{
			get
			{
				return _Diagresult;
			}
            
			set
			{
				_Diagresult=value;
				if(value!=null) base.RecodeChange(F_Diagresult);
			}
		}
		/******************************************************/
		/// <summary>
		/// 建议
		/// </summary>
		public   string   Advice
		{
			get
			{
				return _Advice;
			}
            
			set
			{
				_Advice=value;
				if(value!=null) base.RecodeChange(F_Advice);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Reportdr
		{
			get
			{
				return _Reportdr;
			}
            
			set
			{
				_Reportdr=value;
				if(value!=null) base.RecodeChange(F_Reportdr);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Reportdrid
		{
			get
			{
				return _Reportdrid;
			}
            
			set
			{
				_Reportdrid=value;
				if(value!=null) base.RecodeChange(F_Reportdrid);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Verifydr
		{
			get
			{
				return _Verifydr;
			}
            
			set
			{
				_Verifydr=value;
				if(value!=null) base.RecodeChange(F_Verifydr);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Verifydrid
		{
			get
			{
				return _Verifydrid;
			}
            
			set
			{
				_Verifydrid=value;
				if(value!=null) base.RecodeChange(F_Verifydrid);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Medic
		{
			get
			{
				return _Medic;
			}
            
			set
			{
				_Medic=value;
				if(value!=null) base.RecodeChange(F_Medic);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Medicid
		{
			get
			{
				return _Medicid;
			}
            
			set
			{
				_Medicid=value;
				if(value!=null) base.RecodeChange(F_Medicid);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Reporttype
		{
			get
			{
				return _Reporttype;
			}
            
			set
			{
				_Reporttype=value;
				if(value!=null) base.RecodeChange(F_Reporttype);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Keywords1
		{
			get
			{
				return _Keywords1;
			}
            
			set
			{
				_Keywords1=value;
				if(value!=null) base.RecodeChange(F_Keywords1);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Keywords2
		{
			get
			{
				return _Keywords2;
			}
            
			set
			{
				_Keywords2=value;
				if(value!=null) base.RecodeChange(F_Keywords2);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Keywords3
		{
			get
			{
				return _Keywords3;
			}
            
			set
			{
				_Keywords3=value;
				if(value!=null) base.RecodeChange(F_Keywords3);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Extrakeywords
		{
			get
			{
				return _Extrakeywords;
			}
            
			set
			{
				_Extrakeywords=value;
				if(value!=null) base.RecodeChange(F_Extrakeywords);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Reportdt
		{
			get
			{
				return _Reportdt;
			}
            
			set
			{
				_Reportdt=value;
				if(value!=null) base.RecodeChange(F_Reportdt);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Verifydt
		{
			get
			{
				return _Verifydt;
			}
            
			set
			{
				_Verifydt=value;
				if(value!=null) base.RecodeChange(F_Verifydt);
			}
		}
		/******************************************************/
        /// <summary>
        /// 
        /// </summary>
        public string Verifydt2
        {
            get
            {
                return _Verifydt2;
            }

            set
            {
                _Verifydt2 = value;
                if (value != null) base.RecodeChange(F_Verifydt2);
            }
        }
        /******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Printdt
		{
			get
			{
				return _Printdt;
			}
            
			set
			{
				_Printdt=value;
				if(value!=null) base.RecodeChange(F_Printdt);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Templateid
		{
			get
			{
				return _Templateid;
			}
            
			set
			{
				_Templateid=value;
				if(value!=null) base.RecodeChange(F_Templateid);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Modified
		{
			get
			{
				return _Modified;
			}
            
			set
			{
				_Modified=value;
				if(value!=null) base.RecodeChange(F_Modified);
			}
		}
		/******************************************************/
		/// <summary>
		/// 临时报告标志
		/// </summary>
		public   string   Tempreport
		{
			get
			{
				return _Tempreport;
			}
            
			set
			{
				_Tempreport=value;
				if(value!=null) base.RecodeChange(F_Tempreport);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Abnormal
		{
			get
			{
				return _Abnormal;
			}
            
			set
			{
				_Abnormal=value;
				if(value!=null) base.RecodeChange(F_Abnormal);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Reportstatus
		{
			get
			{
				return _Reportstatus;
			}
            
			set
			{
				_Reportstatus=value;
				if(value!=null) base.RecodeChange(F_Reportstatus);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Deleted
		{
			get
			{
				return _Deleted;
			}
            
			set
			{
				_Deleted=value;
				if(value!=null) base.RecodeChange(F_Deleted);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Reportremark
		{
			get
			{
				return _Reportremark;
			}
            
			set
			{
				_Reportremark=value;
				if(value!=null) base.RecodeChange(F_Reportremark);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Fixpicno
		{
			get
			{
				return _Fixpicno;
			}
            
			set
			{
				_Fixpicno=value;
				if(value!=null) base.RecodeChange(F_Fixpicno);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Displaytype
		{
			get
			{
				return _Displaytype;
			}
            
			set
			{
				_Displaytype=value;
				if(value!=null) base.RecodeChange(F_Displaytype);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Verifydr2
		{
			get
			{
				return _Verifydr2;
			}
            
			set
			{
				_Verifydr2=value;
				if(value!=null) base.RecodeChange(F_Verifydr2);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Verifydrid2
		{
			get
			{
				return _Verifydrid2;
			}
            
			set
			{
				_Verifydrid2=value;
				if(value!=null) base.RecodeChange(F_Verifydrid2);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Bstudyresult
		{
			get
			{
				return _Bstudyresult;
			}
            
			set
			{
				_Bstudyresult=value;
				if(value!=null) base.RecodeChange(F_Bstudyresult);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
//		public   string   Bdiagresult
//		{
//			get
//			{
//				return _Bdiagresult;
//			}
//            
//			set
//			{
//				_Bdiagresult=value;
//				if(value!=null) base.RecodeChange(F_Bdiagresult);
//			}
//		}

		public byte[] Bdiagresult
		{
			get
			{
				return this._Bdiagresult;
			}
			set
			{
				this._Bdiagresult = value;
				if (value != null)
				{
					base.RecodeChange("BDIAGRESULT");
				}
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Cstudyresult
		{
			get
			{
				return _Cstudyresult;
			}
            
			set
			{
				_Cstudyresult=value;
				if(value!=null) base.RecodeChange(F_Cstudyresult);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Cdiagresult
		{
			get
			{
				return _Cdiagresult;
			}
            
			set
			{
				_Cdiagresult=value;
				if(value!=null) base.RecodeChange(F_Cdiagresult);
			}
		}
		/******************************************************/
		/// <summary>
		/// 报告退回理由
		/// </summary>
		public   string   Rejectreason
		{
			get
			{
				return _Rejectreason;
			}
            
			set
			{
				_Rejectreason=value;
				if(value!=null) base.RecodeChange(F_Rejectreason);
			}
		}
		/******************************************************/
		/// <summary>
		/// 分发确认标记(0=未确认,1=确认)
		/// </summary>
		public   string   Deliveraffirm
		{
			get
			{
				return _Deliveraffirm;
			}
            
			set
			{
				_Deliveraffirm=value;
				if(value!=null) base.RecodeChange(F_Deliveraffirm);
			}
		}
		/******************************************************/
		/// <summary>
		/// 外院诊断结果（为空吻合）
		/// </summary>
		public   string   Outhospitaldiagresult
		{
			get
			{
				return _Outhospitaldiagresult;
			}
            
			set
			{
				_Outhospitaldiagresult=value;
				if(value!=null) base.RecodeChange(F_Outhospitaldiagresult);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Modifydiagresult
		{
			get
			{
				return _Modifydiagresult;
			}
            
			set
			{
				_Modifydiagresult=value;
				if(value!=null) base.RecodeChange(F_Modifydiagresult);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Modifyreason
		{
			get
			{
				return _Modifyreason;
			}
            
			set
			{
				_Modifyreason=value;
				if(value!=null) base.RecodeChange(F_Modifyreason);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Modifytime
		{
			get
			{
				return _Modifytime;
			}
            
			set
			{
				_Modifytime=value;
				if(value!=null) base.RecodeChange(F_Modifytime);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Modifystate
		{
			get
			{
				return _Modifystate;
			}
            
			set
			{
				_Modifystate=value;
				if(value!=null) base.RecodeChange(F_Modifystate);
			}
		}
		/******************************************************/
		/// <summary>
		/// 2次 冰冻修改报告内容
		/// </summary>
		public   string   Smodifydiagresult
		{
			get
			{
				return _Smodifydiagresult;
			}
            
			set
			{
				_Smodifydiagresult=value;
				if(value!=null) base.RecodeChange(F_Smodifydiagresult);
			}
		}
		/******************************************************/
		/// <summary>
		/// 2次 修改冰冻报告原因
		/// </summary>
		public   string   Smodifyreason
		{
			get
			{
				return _Smodifyreason;
			}
            
			set
			{
				_Smodifyreason=value;
				if(value!=null) base.RecodeChange(F_Smodifyreason);
			}
		}
		/******************************************************/
		/// <summary>
		/// 2次 修改冰冻报告时间
		/// </summary>
		public   string   Smodifytime
		{
			get
			{
				return _Smodifytime;
			}
            
			set
			{
				_Smodifytime=value;
				if(value!=null) base.RecodeChange(F_Smodifytime);
			}
		}
		/******************************************************/
		#endregion
		public  override OracleParameter GetParameter(string strParamName)
		{
			OracleParameter param= new OracleParameter();
			switch(strParamName)
			{
				case F_Reportseq:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Reportseq;
					param.Size =64  ;
					param.Value =_Reportseq;
					break;
				case F_Hospitalid:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Hospitalid;
					param.Size =64  ;
					param.Value =_Hospitalid;
					break;
				case F_Examitem:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Examitem;
					param.Size =256  ;
					param.Value =_Examitem;
					break;
				case F_Studyresult:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Studyresult;
					param.Size =4000  ;
					param.Value =_Studyresult;
					break;
				case F_Diagresult:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Diagresult;
					param.Size =2000  ;
					param.Value =_Diagresult;
					break;
				case F_Advice:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Advice;
					param.Size =2000  ;
					param.Value =_Advice;
					break;
				case F_Reportdr:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Reportdr;
					param.Size =64  ;
					param.Value =_Reportdr;
					break;
				case F_Reportdrid:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Reportdrid;
					param.Size =64  ;
					param.Value =_Reportdrid;
					break;
				case F_Verifydr:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Verifydr;
					param.Size =64  ;
					param.Value =_Verifydr;
					break;
				case F_Verifydrid:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Verifydrid;
					param.Size =64  ;
					param.Value =_Verifydrid;
					break;
				case F_Medic:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Medic;
					param.Size =64  ;
					param.Value =_Medic;
					break;
				case F_Medicid:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Medicid;
					param.Size =64  ;
					param.Value =_Medicid;
					break;
				case F_Reporttype:
					param.OracleType = OracleType.Char;
					param.ParameterName = ":"+F_Reporttype;
					param.Size =4  ;
					param.Value =_Reporttype;
					break;
				case F_Keywords1:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Keywords1;
					param.Size =500  ;
					param.Value =_Keywords1;
					break;
				case F_Keywords2:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Keywords2;
					param.Size =500  ;
					param.Value =_Keywords2;
					break;
				case F_Keywords3:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Keywords3;
					param.Size =500  ;
					param.Value =_Keywords3;
					break;
				case F_Extrakeywords:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Extrakeywords;
					param.Size =500  ;
					param.Value =_Extrakeywords;
					break;
				case F_Reportdt:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Reportdt;
					param.Size =20  ;
					param.Value =_Reportdt;
					break;
				case F_Verifydt:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Verifydt;
					param.Size =20  ;
					param.Value =_Verifydt;
					break;
                case F_Verifydt2:
                    param.OracleType = OracleType.NVarChar;
                    param.ParameterName = ":" + F_Verifydt2;
                    param.Size = 20;
                    param.Value = _Verifydt2;
                    break;
				case F_Printdt:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Printdt;
					param.Size =20  ;
					param.Value =_Printdt;
					break;
				case F_Templateid:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Templateid;
					param.Size =64  ;
					param.Value =_Templateid;
					break;
				case F_Modified:
					param.OracleType = OracleType.Char;
					param.ParameterName = ":"+F_Modified;
					param.Size =1  ;
					param.Value =_Modified;
					break;
				case F_Tempreport:
					param.OracleType = OracleType.Char;
					param.ParameterName = ":"+F_Tempreport;
					param.Size =1  ;
					param.Value =_Tempreport;
					break;
				case F_Abnormal:
					param.OracleType = OracleType.Char;
					param.ParameterName = ":"+F_Abnormal;
					param.Size =1  ;
					param.Value =_Abnormal;
					break;
				case F_Reportstatus:
					param.OracleType = OracleType.Char;
					param.ParameterName = ":"+F_Reportstatus;
					param.Size =4  ;
					param.Value =_Reportstatus;
					break;
				case F_Deleted:
					param.OracleType = OracleType.Char;
					param.ParameterName = ":"+F_Deleted;
					param.Size =1  ;
					param.Value =_Deleted;
					break;
				case F_Reportremark:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Reportremark;
					param.Size =1000  ;
					param.Value =_Reportremark;
					break;
				case F_Fixpicno:
					param.OracleType = OracleType.Number;
					param.ParameterName = ":"+F_Fixpicno;
					param.Size =22  ;
					param.Value =_Fixpicno;
					break;
				case F_Displaytype:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Displaytype;
					param.Size =64  ;
					param.Value =_Displaytype;
					break;
				case F_Verifydr2:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Verifydr2;
					param.Size =64  ;
					param.Value =_Verifydr2;
					break;
				case F_Verifydrid2:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Verifydrid2;
					param.Size =64  ;
					param.Value =_Verifydrid2;
					break;
				case F_Bstudyresult:
					param.OracleType = OracleType.Blob;
						param.ParameterName = ":"+F_Bstudyresult;
					param.Size =4000  ;
					param.Value =_Bstudyresult;
					break;
				case F_Bdiagresult:
					param.OracleType =OracleType.Blob ;
						param.ParameterName = ":"+F_Bdiagresult;
					param.Size =4000  ;
					param.Value =_Bdiagresult;
					break;
				case F_Cstudyresult:
					param.OracleType =OracleType.Clob ;
						param.ParameterName = ":"+F_Cstudyresult;
					param.Size =4000  ;
					param.Value =_Cstudyresult;
					break;
				case F_Cdiagresult:
					param.OracleType =OracleType.Clob ;
						param.ParameterName = ":"+F_Cdiagresult;
					param.Size =4000  ;
					param.Value =_Cdiagresult;
					break;
				case F_Rejectreason:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Rejectreason;
					param.Size =1000  ;
					param.Value =_Rejectreason;
					break;
				case F_Deliveraffirm:
					param.OracleType = OracleType.Char;
					param.ParameterName = ":"+F_Deliveraffirm;
					param.Size =1  ;
					param.Value =_Deliveraffirm;
					break;
				case F_Outhospitaldiagresult:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Outhospitaldiagresult;
					param.Size =1000  ;
					param.Value =_Outhospitaldiagresult;
					break;
				case F_Modifydiagresult:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Modifydiagresult;
					param.Size =2000  ;
					param.Value =_Modifydiagresult;
					break;
				case F_Modifyreason:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Modifyreason;
					param.Size =1000  ;
					param.Value =_Modifyreason;
					break;
				case F_Modifytime:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Modifytime;
					param.Size =64  ;
					param.Value =_Modifytime;
					break;
				case F_Modifystate:
					param.OracleType = OracleType.Char;
					param.ParameterName = ":"+F_Modifystate;
					param.Size =1  ;
					param.Value =_Modifystate;
					break;
				case F_Smodifydiagresult:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Smodifydiagresult;
					param.Size =2000  ;
					param.Value =_Smodifydiagresult;
					break;
				case F_Smodifyreason:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Smodifyreason;
					param.Size =1000  ;
					param.Value =_Smodifyreason;
					break;
				case F_Smodifytime:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Smodifytime;
					param.Size =64  ;
					param.Value =_Smodifytime;
					break;
			}
			return param;}
		protected  override void  SetValueToMemberByName(string strName,string strValue) 
		{
			switch(strName)
			{
				case F_Reportseq:
					Reportseq=strValue;
					break;
				case F_Hospitalid:
					Hospitalid=strValue;
					break;
				case F_Examitem:
					Examitem=strValue;
					break;
				case F_Studyresult:
					Studyresult=strValue;
					break;
				case F_Diagresult:
					Diagresult=strValue;
					break;
				case F_Advice:
					Advice=strValue;
					break;
				case F_Reportdr:
					Reportdr=strValue;
					break;
				case F_Reportdrid:
					Reportdrid=strValue;
					break;
				case F_Verifydr:
					Verifydr=strValue;
					break;
				case F_Verifydrid:
					Verifydrid=strValue;
					break;
				case F_Medic:
					Medic=strValue;
					break;
				case F_Medicid:
					Medicid=strValue;
					break;
				case F_Reporttype:
					Reporttype=strValue;
					break;
				case F_Keywords1:
					Keywords1=strValue;
					break;
				case F_Keywords2:
					Keywords2=strValue;
					break;
				case F_Keywords3:
					Keywords3=strValue;
					break;
				case F_Extrakeywords:
					Extrakeywords=strValue;
					break;
				case F_Reportdt:
					Reportdt=strValue;
					break;
				case F_Verifydt:
					Verifydt=strValue;
					break;
                case F_Verifydt2:
                    Verifydt2 = strValue;
                    break;
				case F_Printdt:
					Printdt=strValue;
					break;
				case F_Templateid:
					Templateid=strValue;
					break;
				case F_Modified:
					Modified=strValue;
					break;
				case F_Tempreport:
					Tempreport=strValue;
					break;
				case F_Abnormal:
					Abnormal=strValue;
					break;
				case F_Reportstatus:
					Reportstatus=strValue;
					break;
				case F_Deleted:
					Deleted=strValue;
					break;
				case F_Reportremark:
					Reportremark=strValue;
					break;
				case F_Fixpicno:
					Fixpicno=strValue;
					break;
				case F_Displaytype:
					Displaytype=strValue;
					break;
				case F_Verifydr2:
					Verifydr2=strValue;
					break;
				case F_Verifydrid2:
					Verifydrid2=strValue;
					break;
				case F_Bstudyresult:
					Bstudyresult=strValue;
					break;
				case F_Bdiagresult:
				
					break;
				case F_Cstudyresult:
					Cstudyresult=strValue;
					break;
				case F_Cdiagresult:
					Cdiagresult=strValue;
					break;
				case F_Rejectreason:
					Rejectreason=strValue;
					break;
				case F_Deliveraffirm:
					Deliveraffirm=strValue;
					break;
				case F_Outhospitaldiagresult:
					Outhospitaldiagresult=strValue;
					break;
				case F_Modifydiagresult:
					Modifydiagresult=strValue;
					break;
				case F_Modifyreason:
					Modifyreason=strValue;
					break;
				case F_Modifytime:
					Modifytime=strValue;
					break;
				case F_Modifystate:
					Modifystate=strValue;
					break;
				case F_Smodifydiagresult:
					Smodifydiagresult=strValue;
					break;
				case F_Smodifyreason:
					Smodifyreason=strValue;
					break;
				case F_Smodifytime:
					Smodifytime=strValue;
					break;
				default:throw new Exception("控件名字没有对应的数据库字段："+strName);
			}
		}
		public static T_Report RowToObject(DataTable dt)
		{
			return RowsToObjects(dt)[0];
		}

		public static T_Report [] RowsToObjects(DataTable dt)
		{
			if (dt == null || dt.Rows.Count == 0) return null;
			T_Report[] ary = new T_Report[dt.Rows.Count];
			int i = 0 ;
			foreach (DataRow dr in dt.Rows)
			{  
				ary[i] = new T_Report();
				ary[i]._Reportseq = dr[T_Report.F_Reportseq].ToString();
				ary[i]._Hospitalid = dr[T_Report.F_Hospitalid].ToString();
				ary[i]._Examitem = dr[T_Report.F_Examitem].ToString();
				ary[i]._Studyresult = dr[T_Report.F_Studyresult].ToString();
				ary[i]._Diagresult = dr[T_Report.F_Diagresult].ToString();
				ary[i]._Advice = dr[T_Report.F_Advice].ToString();
				ary[i]._Reportdr = dr[T_Report.F_Reportdr].ToString();
				ary[i]._Reportdrid = dr[T_Report.F_Reportdrid].ToString();
				ary[i]._Verifydr = dr[T_Report.F_Verifydr].ToString();
				ary[i]._Verifydrid = dr[T_Report.F_Verifydrid].ToString();
				ary[i]._Medic = dr[T_Report.F_Medic].ToString();
				ary[i]._Medicid = dr[T_Report.F_Medicid].ToString();
				ary[i]._Reporttype = dr[T_Report.F_Reporttype].ToString();
				ary[i]._Keywords1 = dr[T_Report.F_Keywords1].ToString();
				ary[i]._Keywords2 = dr[T_Report.F_Keywords2].ToString();
				ary[i]._Keywords3 = dr[T_Report.F_Keywords3].ToString();
				ary[i]._Extrakeywords = dr[T_Report.F_Extrakeywords].ToString();
				ary[i]._Reportdt = dr[T_Report.F_Reportdt].ToString();
				ary[i]._Verifydt = dr[T_Report.F_Verifydt].ToString();
                ary[i]._Verifydt2 = dr[T_Report.F_Verifydt2].ToString();
				ary[i]._Printdt = dr[T_Report.F_Printdt].ToString();
				ary[i]._Templateid = dr[T_Report.F_Templateid].ToString();
				ary[i]._Modified = dr[T_Report.F_Modified].ToString();
				ary[i]._Tempreport = dr[T_Report.F_Tempreport].ToString();
				ary[i]._Abnormal = dr[T_Report.F_Abnormal].ToString();
				ary[i]._Reportstatus = dr[T_Report.F_Reportstatus].ToString();
				ary[i]._Deleted = dr[T_Report.F_Deleted].ToString();
				ary[i]._Reportremark = dr[T_Report.F_Reportremark].ToString();
				ary[i]._Fixpicno = dr[T_Report.F_Fixpicno].ToString();
				ary[i]._Displaytype = dr[T_Report.F_Displaytype].ToString();
				ary[i]._Verifydr2 = dr[T_Report.F_Verifydr2].ToString();
				ary[i]._Verifydrid2 = dr[T_Report.F_Verifydrid2].ToString();
				//ary[i]._Bstudyresult = dr[T_Report.F_Bstudyresult].ToString();
				//ary[i]._Bdiagresult = dr[T_Report.F_Bdiagresult].ToString();
				//ary[i]._Cstudyresult = dr[T_Report.F_Cstudyresult].ToString();
				//ary[i]._Cdiagresult = dr[T_Report.F_Cdiagresult].ToString();
				//	ary[i]._Rejectreason = dr[T_Report.F_Rejectreason].ToString();
				//	ary[i]._Deliveraffirm = dr[T_Report.F_Deliveraffirm].ToString();
				//ary[i]._Outhospitaldiagresult = dr[T_Report.F_Outhospitaldiagresult].ToString();
				ary[i]._Modifydiagresult = dr[T_Report.F_Modifydiagresult].ToString();
				ary[i]._Modifyreason = dr[T_Report.F_Modifyreason].ToString();
				ary[i]._Modifytime = dr[T_Report.F_Modifytime].ToString();
				ary[i]._Modifystate = dr[T_Report.F_Modifystate].ToString();
				ary[i]._Smodifydiagresult = dr[T_Report.F_Smodifydiagresult].ToString();
				ary[i]._Smodifyreason = dr[T_Report.F_Smodifyreason].ToString();
				ary[i]._Smodifytime = dr[T_Report.F_Smodifytime].ToString();
				i++;
			}
			return ary;}
	}
}

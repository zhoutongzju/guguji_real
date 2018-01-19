using System;
using System.Data;
using System.Data.OracleClient;
using System.Collections;
using Maroland.DataAccess;


namespace RISBroker
{
	public class T_Order:DataObject
	{
		#region		表及字段定义
		public const string TabName  = "T_ORDER";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Orderseq="ORDERSEQ";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Patseq="PATSEQ";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Pattype="PATTYPE";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Hospitalid="HOSPITALID";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Physicalexamid="PHYSICALEXAMID";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Modalityid="MODALITYID";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Modality="MODALITY";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Clinic="CLINIC";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Clinicid="CLINICID";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Ward="WARD";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Wardid="WARDID";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Sickroom="SICKROOM";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Bedno="BEDNO";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Orderdr="ORDERDR";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Orderdrid="ORDERDRID";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Equipment="EQUIPMENT";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Equipmentid="EQUIPMENTID";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Attendingdr="ATTENDINGDR";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Attendingdrid="ATTENDINGDRID";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Chiefdr1="CHIEFDR1";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Chiefdr1id="CHIEFDR1ID";
		/// <summary>
		/// 指定报告医生姓名
		/// </summary>
		public const string F_Special_reportdr="SPECIAL_REPORTDR";
		/// <summary>
		/// 指定报告医生ID
		/// </summary>
		public const string F_Special_reportdrid="SPECIAL_REPORTDRID";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Nurse="NURSE";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Nurseid="NURSEID";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Technician="TECHNICIAN";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Technicianid="TECHNICIANID";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Examdr="EXAMDR";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Examdrid="EXAMDRID";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Examitem="EXAMITEM";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Examitemid="EXAMITEMID";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Performdeptid="PERFORMDEPTID";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Charge="CHARGE";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Chargeconfirm="CHARGECONFIRM";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Examrequest="EXAMREQUEST";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Examtech="EXAMTECH";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Disease="DISEASE";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Ordercomment="ORDERCOMMENT";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Otherexam="OTHEREXAM";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Orderpaper="ORDERPAPER";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Orderlevel="ORDERLEVEL";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Filmstatus="FILMSTATUS";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Reportstatus="REPORTSTATUS";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Examstatus="EXAMSTATUS";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Orderstatus="ORDERSTATUS";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Bookingdt="BOOKINGDT";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Orderdt="ORDERDT";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Examdt="EXAMDT";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Deleted="DELETED";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Editing="EDITING";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Instanceuid="INSTANCEUID";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Recorder="RECORDER";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Recorddt="RECORDDT";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Order_sn="ORDER_SN";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Pregnancy="PREGNANCY";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Reserved2="RESERVED2";
		/// <summary>
		/// 标本接收标志 1为标本接收
		/// </summary>
		public const string F_Reserved3="RESERVED3";   
		/// <summary>
		/// 
		/// </summary>
		public const string F_Accno="ACCNO";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Register="REGISTER";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Registerid="REGISTERID";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Operatename="OPERATENAME";
		/// <summary>
		/// 
		/// </summary>
		public const string F_His_id="HIS_ID";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Ordertype="ORDERTYPE";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Examroom="EXAMROOM";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Bodypart="BODYPART";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Bodypartid="BODYPARTID";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Exposurecount="EXPOSURECOUNT";
		/// <summary>
		/// 
		/// </summary>
		public const string F_Isbilling="ISBILLING";
		/// <summary>
		/// 院别
		/// </summary>
		public const string F_Hospitalname="HOSPITALNAME";
		/// <summary>
		/// HIS中对应于RIS项目的描述
		/// </summary>
		public const string F_His_examitem="HIS_EXAMITEM";
		/// <summary>
		/// 送检日期
		/// </summary>
		public const string F_Deliverdt="DELIVERDT";
		/// <summary>
		/// 收到日期
		/// </summary>
		public const string F_Receivedt="RECEIVEDT";
		/// <summary>
		/// 是否冰冻[1冰冻]
		/// </summary>
		public const string F_Frost="FROST";
		/// <summary>
		/// 是否从HIS直接获得
		/// </summary>
		public const string F_Directhis="DIRECTHIS";
		/// <summary>
		/// 档案状态
		/// </summary>
		public const string F_Arstatus="ARSTATUS";
		/// <summary>
		/// 条码号
		/// </summary>
		public const string F_Barcode="BARCODE";
		/// <summary>
		/// 冰冻时间
		/// </summary>
		public const string F_Makecuttime="MAKECUTTIME";
		/// <summary>
		/// 出片时间
		/// </summary>
		public const string F_Outcuttime="OUTCUTTIME";
		/// <summary>
		/// 冰冻状态
		/// </summary>
		public const string F_Icedcutstatus="ICEDCUTSTATUS";
		/// <summary>
		/// 冰冻次数
		/// </summary>
		public const string F_Icedtimes="ICEDTIMES";
		/// <summary>
		/// 制片评判
		/// </summary>
		public const string F_Getmaterialjudge="GETMATERIALJUDGE";
		/// <summary>
		/// 取材医生
		/// </summary>
		public const string F_Getmaterialdr="GETMATERIALDR";
		/// <summary>
		/// 取材医生ID
		/// </summary>
		public const string F_Getmaterialdrid="GETMATERIALDRID";
		/// <summary>
		/// 取材评判
		/// </summary>
		public const string F_Getjudged="GETJUDGED";
		/// <summary>
		/// 手术室房间号
		/// </summary>
		public const string F_Operateroomnumber="OPERATEROOMNUMBER";
        /// <summary>
        /// 签收医生
        /// </summary>
        public const string F_Signfordr = "SIGNFORDR";
        /// <summary>
        /// 签收医生ID
        /// </summary>
        public const string F_Signfordrid = "SIGNFORDRID";

        /// <summary>
        /// 标本签收序号
        /// </summary>
        public const string F_Sequence= "SEQUENCE";

		#endregion
		public T_Order()
		{
			this._strTable =TabName;
		}
		#region		私有变量
		private string _Orderseq=null;
		private string _Patseq=null;
		private string _Pattype=null;
		private string _Hospitalid=null;
		private string _Physicalexamid=null;
		private string _Modalityid=null;
		private string _Modality=null;
		private string _Clinic=null;
		private string _Clinicid=null;
		private string _Ward=null;
		private string _Wardid=null;
		private string _Sickroom=null;
		private string _Bedno=null;
		private string _Orderdr=null;
		private string _Orderdrid=null;
		private string _Equipment=null;
		private string _Equipmentid=null;
		private string _Attendingdr=null;
		private string _Attendingdrid=null;
		private string _Chiefdr1=null;
		private string _Chiefdr1id=null;
		private string _Special_reportdr=null;
		private string _Special_reportdrid=null;
		private string _Nurse=null;
		private string _Nurseid=null;
		private string _Technician=null;
		private string _Technicianid=null;
		private string _Examdr=null;
		private string _Examdrid=null;
		private string _Examitem=null;
		private string _Examitemid=null;
		private string _Performdeptid=null;
		private string _Charge=null;
		private string _Chargeconfirm=null;
		private string _Examrequest=null;
		private string _Examtech=null;
		private string _Disease=null;
		private string _Ordercomment=null;
		private string _Otherexam=null;
		private string _Orderpaper=null;
		private string _Orderlevel=null;
		private string _Filmstatus=null;
		private string _Reportstatus=null;
		private string _Examstatus=null;
		private string _Orderstatus=null;
		private string _Bookingdt=null;
		private string _Orderdt=null;
		private string _Examdt=null;
		private string _Deleted=null;
		private string _Editing=null;
		private string _Instanceuid=null;
		private string _Recorder=null;
		private string _Recorddt=null;
		private string _Order_sn=null;
		private string _Pregnancy=null;
		private string _Reserved2=null;
		private string _Reserved3=null;
		private string _Accno=null;
		private string _Register=null;
		private string _Registerid=null;
		private string _Operatename=null;
		private string _His_id=null;
		private string _Ordertype=null;
		private string _Examroom=null;
		private string _Bodypart=null;
		private string _Bodypartid=null;
		private string _Exposurecount=null;
		private string _Isbilling=null;
		private string _Hospitalname=null;
		private string _His_examitem=null;
		private string _Deliverdt=null;
		private string _Receivedt=null;
		private string _Frost=null;
		private string _Directhis=null;
		private string _Arstatus=null;
		private string _Barcode=null;
		private string _Makecuttime=null;
		private string _Outcuttime=null;
		private string _Icedcutstatus=null;
		private string _Icedtimes=null;
		private string _Getmaterialjudge=null;
		private string _Getmaterialdr=null;
		private string _Getmaterialdrid=null;
		private string _Getjudged=null;
		private string _Operateroomnumber=null;
        private string _Signfordr = null;
        private string _Signfordrid = null;
        private string _Sequence = null;
		#endregion
		#region 公开属性定义
		/// <summary>
		/// 
		/// </summary>
		public   string   Orderseq
		{
			get
			{
				return _Orderseq;
			}
            
			set
			{
				_Orderseq=value;
				if(value!=null) base.RecodeChange(F_Orderseq);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Patseq
		{
			get
			{
				return _Patseq;
			}
            
			set
			{
				_Patseq=value;
				if(value!=null) base.RecodeChange(F_Patseq);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Pattype
		{
			get
			{
				return _Pattype;
			}
            
			set
			{
				_Pattype=value;
				if(value!=null) base.RecodeChange(F_Pattype);
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
		/// 
		/// </summary>
		public   string   Physicalexamid
		{
			get
			{
				return _Physicalexamid;
			}
            
			set
			{
				_Physicalexamid=value;
				if(value!=null) base.RecodeChange(F_Physicalexamid);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Modalityid
		{
			get
			{
				return _Modalityid;
			}
            
			set
			{
				_Modalityid=value;
				if(value!=null) base.RecodeChange(F_Modalityid);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Modality
		{
			get
			{
				return _Modality;
			}
            
			set
			{
				_Modality=value;
				if(value!=null) base.RecodeChange(F_Modality);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Clinic
		{
			get
			{
				return _Clinic;
			}
            
			set
			{
				_Clinic=value;
				if(value!=null) base.RecodeChange(F_Clinic);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Clinicid
		{
			get
			{
				return _Clinicid;
			}
            
			set
			{
				_Clinicid=value;
				if(value!=null) base.RecodeChange(F_Clinicid);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Ward
		{
			get
			{
				return _Ward;
			}
            
			set
			{
				_Ward=value;
				if(value!=null) base.RecodeChange(F_Ward);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Wardid
		{
			get
			{
				return _Wardid;
			}
            
			set
			{
				_Wardid=value;
				if(value!=null) base.RecodeChange(F_Wardid);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Sickroom
		{
			get
			{
				return _Sickroom;
			}
            
			set
			{
				_Sickroom=value;
				if(value!=null) base.RecodeChange(F_Sickroom);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Bedno
		{
			get
			{
				return _Bedno;
			}
            
			set
			{
				_Bedno=value;
				if(value!=null) base.RecodeChange(F_Bedno);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Orderdr
		{
			get
			{
				return _Orderdr;
			}
            
			set
			{
				_Orderdr=value;
				if(value!=null) base.RecodeChange(F_Orderdr);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Orderdrid
		{
			get
			{
				return _Orderdrid;
			}
            
			set
			{
				_Orderdrid=value;
				if(value!=null) base.RecodeChange(F_Orderdrid);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Equipment
		{
			get
			{
				return _Equipment;
			}
            
			set
			{
				_Equipment=value;
				if(value!=null) base.RecodeChange(F_Equipment);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Equipmentid
		{
			get
			{
				return _Equipmentid;
			}
            
			set
			{
				_Equipmentid=value;
				if(value!=null) base.RecodeChange(F_Equipmentid);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Attendingdr
		{
			get
			{
				return _Attendingdr;
			}
            
			set
			{
				_Attendingdr=value;
				if(value!=null) base.RecodeChange(F_Attendingdr);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Attendingdrid
		{
			get
			{
				return _Attendingdrid;
			}
            
			set
			{
				_Attendingdrid=value;
				if(value!=null) base.RecodeChange(F_Attendingdrid);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Chiefdr1
		{
			get
			{
				return _Chiefdr1;
			}
            
			set
			{
				_Chiefdr1=value;
				if(value!=null) base.RecodeChange(F_Chiefdr1);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Chiefdr1id
		{
			get
			{
				return _Chiefdr1id;
			}
            
			set
			{
				_Chiefdr1id=value;
				if(value!=null) base.RecodeChange(F_Chiefdr1id);
			}
		}
		/******************************************************/
		/// <summary>
		/// 指定报告医生姓名
		/// </summary>
		public   string   Special_reportdr
		{
			get
			{
				return _Special_reportdr;
			}
            
			set
			{
				_Special_reportdr=value;
				if(value!=null) base.RecodeChange(F_Special_reportdr);
			}
		}
		/******************************************************/
		/// <summary>
		/// 指定报告医生ID
		/// </summary>
		public   string   Special_reportdrid
		{
			get
			{
				return _Special_reportdrid;
			}
            
			set
			{
				_Special_reportdrid=value;
				if(value!=null) base.RecodeChange(F_Special_reportdrid);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Nurse
		{
			get
			{
				return _Nurse;
			}
            
			set
			{
				_Nurse=value;
				if(value!=null) base.RecodeChange(F_Nurse);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Nurseid
		{
			get
			{
				return _Nurseid;
			}
            
			set
			{
				_Nurseid=value;
				if(value!=null) base.RecodeChange(F_Nurseid);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Technician
		{
			get
			{
				return _Technician;
			}
            
			set
			{
				_Technician=value;
				if(value!=null) base.RecodeChange(F_Technician);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Technicianid
		{
			get
			{
				return _Technicianid;
			}
            
			set
			{
				_Technicianid=value;
				if(value!=null) base.RecodeChange(F_Technicianid);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Examdr
		{
			get
			{
				return _Examdr;
			}
            
			set
			{
				_Examdr=value;
				if(value!=null) base.RecodeChange(F_Examdr);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Examdrid
		{
			get
			{
				return _Examdrid;
			}
            
			set
			{
				_Examdrid=value;
				if(value!=null) base.RecodeChange(F_Examdrid);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
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
		/// 
		/// </summary>
		public   string   Examitemid
		{
			get
			{
				return _Examitemid;
			}
            
			set
			{
				_Examitemid=value;
				if(value!=null) base.RecodeChange(F_Examitemid);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Performdeptid
		{
			get
			{
				return _Performdeptid;
			}
            
			set
			{
				_Performdeptid=value;
				if(value!=null) base.RecodeChange(F_Performdeptid);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Charge
		{
			get
			{
				return _Charge;
			}
            
			set
			{
				_Charge=value;
				if(value!=null) base.RecodeChange(F_Charge);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Chargeconfirm
		{
			get
			{
				return _Chargeconfirm;
			}
            
			set
			{
				_Chargeconfirm=value;
				if(value!=null) base.RecodeChange(F_Chargeconfirm);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Examrequest
		{
			get
			{
				return _Examrequest;
			}
            
			set
			{
				_Examrequest=value;
				if(value!=null) base.RecodeChange(F_Examrequest);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Examtech
		{
			get
			{
				return _Examtech;
			}
            
			set
			{
				_Examtech=value;
				if(value!=null) base.RecodeChange(F_Examtech);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Disease
		{
			get
			{
				return _Disease;
			}
            
			set
			{
				_Disease=value;
				if(value!=null) base.RecodeChange(F_Disease);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Ordercomment
		{
			get
			{
				return _Ordercomment;
			}
            
			set
			{
				_Ordercomment=value;
				if(value!=null) base.RecodeChange(F_Ordercomment);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Otherexam
		{
			get
			{
				return _Otherexam;
			}
            
			set
			{
				_Otherexam=value;
				if(value!=null) base.RecodeChange(F_Otherexam);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Orderpaper
		{
			get
			{
				return _Orderpaper;
			}
            
			set
			{
				_Orderpaper=value;
				if(value!=null) base.RecodeChange(F_Orderpaper);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Orderlevel
		{
			get
			{
				return _Orderlevel;
			}
            
			set
			{
				_Orderlevel=value;
				if(value!=null) base.RecodeChange(F_Orderlevel);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Filmstatus
		{
			get
			{
				return _Filmstatus;
			}
            
			set
			{
				_Filmstatus=value;
				if(value!=null) base.RecodeChange(F_Filmstatus);
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
		public   string   Examstatus
		{
			get
			{
				return _Examstatus;
			}
            
			set
			{
				_Examstatus=value;
				if(value!=null) base.RecodeChange(F_Examstatus);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Orderstatus
		{
			get
			{
				return _Orderstatus;
			}
            
			set
			{
				_Orderstatus=value;
				if(value!=null) base.RecodeChange(F_Orderstatus);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Bookingdt
		{
			get
			{
				return _Bookingdt;
			}
            
			set
			{
				_Bookingdt=value;
				if(value!=null) base.RecodeChange(F_Bookingdt);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Orderdt
		{
			get
			{
				return _Orderdt;
			}
            
			set
			{
				_Orderdt=value;
				if(value!=null) base.RecodeChange(F_Orderdt);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Examdt
		{
			get
			{
				return _Examdt;
			}
            
			set
			{
				_Examdt=value;
				if(value!=null) base.RecodeChange(F_Examdt);
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
		public   string   Editing
		{
			get
			{
				return _Editing;
			}
            
			set
			{
				_Editing=value;
				if(value!=null) base.RecodeChange(F_Editing);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Instanceuid
		{
			get
			{
				return _Instanceuid;
			}
            
			set
			{
				_Instanceuid=value;
				if(value!=null) base.RecodeChange(F_Instanceuid);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Recorder
		{
			get
			{
				return _Recorder;
			}
            
			set
			{
				_Recorder=value;
				if(value!=null) base.RecodeChange(F_Recorder);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Recorddt
		{
			get
			{
				return _Recorddt;
			}
            
			set
			{
				_Recorddt=value;
				if(value!=null) base.RecodeChange(F_Recorddt);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Order_sn
		{
			get
			{
				return _Order_sn;
			}
            
			set
			{
				_Order_sn=value;
				if(value!=null) base.RecodeChange(F_Order_sn);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Pregnancy
		{
			get
			{
				return _Pregnancy;
			}
            
			set
			{
				_Pregnancy=value;
				if(value!=null) base.RecodeChange(F_Pregnancy);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Reserved2
		{
			get
			{
				return _Reserved2;
			}
            
			set
			{
				_Reserved2=value;
				if(value!=null) base.RecodeChange(F_Reserved2);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Reserved3
		{
			get
			{
				return _Reserved3;
			}
            
			set
			{
				_Reserved3=value;
				if(value!=null) base.RecodeChange(F_Reserved3);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Accno
		{
			get
			{
				return _Accno;
			}
            
			set
			{
				_Accno=value;
				if(value!=null) base.RecodeChange(F_Accno);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Register
		{
			get
			{
				return _Register;
			}
            
			set
			{
				_Register=value;
				if(value!=null) base.RecodeChange(F_Register);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Registerid
		{
			get
			{
				return _Registerid;
			}
            
			set
			{
				_Registerid=value;
				if(value!=null) base.RecodeChange(F_Registerid);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Operatename
		{
			get
			{
				return _Operatename;
			}
            
			set
			{
				_Operatename=value;
				if(value!=null) base.RecodeChange(F_Operatename);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   His_id
		{
			get
			{
				return _His_id;
			}
            
			set
			{
				_His_id=value;
				if(value!=null) base.RecodeChange(F_His_id);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Ordertype
		{
			get
			{
				return _Ordertype;
			}
            
			set
			{
				_Ordertype=value;
				if(value!=null) base.RecodeChange(F_Ordertype);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Examroom
		{
			get
			{
				return _Examroom;
			}
            
			set
			{
				_Examroom=value;
				if(value!=null) base.RecodeChange(F_Examroom);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Bodypart
		{
			get
			{
				return _Bodypart;
			}
            
			set
			{
				_Bodypart=value;
				if(value!=null) base.RecodeChange(F_Bodypart);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Bodypartid
		{
			get
			{
				return _Bodypartid;
			}
            
			set
			{
				_Bodypartid=value;
				if(value!=null) base.RecodeChange(F_Bodypartid);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Exposurecount
		{
			get
			{
				return _Exposurecount;
			}
            
			set
			{
				_Exposurecount=value;
				if(value!=null) base.RecodeChange(F_Exposurecount);
			}
		}
		/******************************************************/
		/// <summary>
		/// 
		/// </summary>
		public   string   Isbilling
		{
			get
			{
				return _Isbilling;
			}
            
			set
			{
				_Isbilling=value;
				if(value!=null) base.RecodeChange(F_Isbilling);
			}
		}
		/******************************************************/
		/// <summary>
		/// 院别
		/// </summary>
		public   string   Hospitalname
		{
			get
			{
				return _Hospitalname;
			}
            
			set
			{
				_Hospitalname=value;
				if(value!=null) base.RecodeChange(F_Hospitalname);
			}
		}
		/******************************************************/
		/// <summary>
		/// HIS中对应于RIS项目的描述
		/// </summary>
		public   string   His_examitem
		{
			get
			{
				return _His_examitem;
			}
            
			set
			{
				_His_examitem=value;
				if(value!=null) base.RecodeChange(F_His_examitem);
			}
		}
		/******************************************************/
		/// <summary>
		/// 送检日期
		/// </summary>
		public   string   Deliverdt
		{
			get
			{
				return _Deliverdt;
			}
            
			set
			{
				_Deliverdt=value;
				if(value!=null) base.RecodeChange(F_Deliverdt);
			}
		}
		/******************************************************/
		/// <summary>
		/// 收到日期
		/// </summary>
		public   string   Receivedt
		{
			get
			{
				return _Receivedt;
			}
            
			set
			{
				_Receivedt=value;
				if(value!=null) base.RecodeChange(F_Receivedt);
			}
		}
		/******************************************************/
		/// <summary>
		/// 是否冰冻[1冰冻]
		/// </summary>
		public   string   Frost
		{
			get
			{
				return _Frost;
			}
            
			set
			{
				_Frost=value;
				if(value!=null) base.RecodeChange(F_Frost);
			}
		}
		/******************************************************/
		/// <summary>
		/// 是否从HIS直接获得
		/// </summary>
		public   string   Directhis
		{
			get
			{
				return _Directhis;
			}
            
			set
			{
				_Directhis=value;
				if(value!=null) base.RecodeChange(F_Directhis);
			}
		}
		/******************************************************/
		/// <summary>
		/// 档案状态
		/// </summary>
		public   string   Arstatus
		{
			get
			{
				return _Arstatus;
			}
            
			set
			{
				_Arstatus=value;
				if(value!=null) base.RecodeChange(F_Arstatus);
			}
		}
		/******************************************************/
		/// <summary>
		/// 条码号
		/// </summary>
		public   string   Barcode
		{
			get
			{
				return _Barcode;
			}
            
			set
			{
				_Barcode=value;
				if(value!=null) base.RecodeChange(F_Barcode);
			}
		}
		/******************************************************/
		/// <summary>
		/// 冰冻时间
		/// </summary>
		public   string   Makecuttime
		{
			get
			{
				return _Makecuttime;
			}
            
			set
			{
				_Makecuttime=value;
				if(value!=null) base.RecodeChange(F_Makecuttime);
			}
		}
		/******************************************************/
		/// <summary>
		/// 出片时间
		/// </summary>
		public   string   Outcuttime
		{
			get
			{
				return _Outcuttime;
			}
            
			set
			{
				_Outcuttime=value;
				if(value!=null) base.RecodeChange(F_Outcuttime);
			}
		}
		/******************************************************/
		/// <summary>
		/// 冰冻状态
		/// </summary>
		public   string   Icedcutstatus
		{
			get
			{
				return _Icedcutstatus;
			}
            
			set
			{
				_Icedcutstatus=value;
				if(value!=null) base.RecodeChange(F_Icedcutstatus);
			}
		}
		/******************************************************/
		/// <summary>
		/// 冰冻次数
		/// </summary>
		public   string   Icedtimes
		{
			get
			{
				return _Icedtimes;
			}
            
			set
			{
				_Icedtimes=value;
				if(value!=null) base.RecodeChange(F_Icedtimes);
			}
		}
		/******************************************************/
		/// <summary>
		/// 制片评判
		/// </summary>
		public   string   Getmaterialjudge
		{
			get
			{
				return _Getmaterialjudge;
			}
            
			set
			{
				_Getmaterialjudge=value;
				if(value!=null) base.RecodeChange(F_Getmaterialjudge);
			}
		}
		/******************************************************/
		/// <summary>
		/// 取材医生
		/// </summary>
		public   string   Getmaterialdr
		{
			get
			{
				return _Getmaterialdr;
			}
            
			set
			{
				_Getmaterialdr=value;
				if(value!=null) base.RecodeChange(F_Getmaterialdr);
			}
		}
		/******************************************************/
		/// <summary>
		/// 取材医生ID
		/// </summary>
		public   string   Getmaterialdrid
		{
			get
			{
				return _Getmaterialdrid;
			}
            
			set
			{
				_Getmaterialdrid=value;
				if(value!=null) base.RecodeChange(F_Getmaterialdrid);
			}
		}
		/******************************************************/
		/// <summary>
		/// 取材评判
		/// </summary>
		public   string   Getjudged
		{
			get
			{
				return _Getjudged;
			}
            
			set
			{
				_Getjudged=value;
				if(value!=null) base.RecodeChange(F_Getjudged);
			}
		}
		/******************************************************/
		/// <summary>
		/// 手术室房间号
		/// </summary>
		public   string   Operateroomnumber
		{
			get
			{
				return _Operateroomnumber;
			}
            
			set
			{
				_Operateroomnumber=value;
				if(value!=null) base.RecodeChange(F_Operateroomnumber);
			}
		}
		/******************************************************/
        /// <summary>
        /// 签收医生
        /// </summary>
        public string Signfordr
        {
            get
            {
                return _Signfordr;
            }

            set
            {
                _Signfordr = value;
                if (value != null) base.RecodeChange(F_Signfordr);
            }
        }
        /******************************************************/
        /// <summary>
        /// 签收医生ID
        /// </summary>   
        public string Signfordrid
        {
            get
            {
                return _Signfordrid;
            }

            set
            {
                _Signfordrid = value;
                if (value != null) base.RecodeChange(F_Signfordrid);
            }
        }
        /******************************************************/
        /// <summary>
        /// 标本签收序号
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
		#endregion
		public  override OracleParameter GetParameter(string strParamName)
		{
			OracleParameter param= new OracleParameter();
			switch(strParamName)
			{
				case F_Orderseq:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Orderseq;
					param.Size =64  ;
					param.Value =_Orderseq;
					break;
				case F_Patseq:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Patseq;
					param.Size =64  ;
					param.Value =_Patseq;
					break;
				case F_Pattype:
					param.OracleType = OracleType.Char;
					param.ParameterName = ":"+F_Pattype;
					param.Size =1  ;
					param.Value =_Pattype;
					break;
				case F_Hospitalid:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Hospitalid;
					param.Size =64  ;
					param.Value =_Hospitalid;
					break;
				case F_Physicalexamid:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Physicalexamid;
					param.Size =64  ;
					param.Value =_Physicalexamid;
					break;
				case F_Modalityid:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Modalityid;
					param.Size =64  ;
					param.Value =_Modalityid;
					break;
				case F_Modality:
					param.OracleType = OracleType.Char;
					param.ParameterName = ":"+F_Modality;
					param.Size =4  ;
					param.Value =_Modality;
					break;
				case F_Clinic:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Clinic;
					param.Size =64  ;
					param.Value =_Clinic;
					break;
				case F_Clinicid:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Clinicid;
					param.Size =64  ;
					param.Value =_Clinicid;
					break;
				case F_Ward:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Ward;
					param.Size =64  ;
					param.Value =_Ward;
					break;
				case F_Wardid:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Wardid;
					param.Size =64  ;
					param.Value =_Wardid;
					break;
				case F_Sickroom:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Sickroom;
					param.Size =64  ;
					param.Value =_Sickroom;
					break;
				case F_Bedno:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Bedno;
					param.Size =64  ;
					param.Value =_Bedno;
					break;
				case F_Orderdr:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Orderdr;
					param.Size =64  ;
					param.Value =_Orderdr;
					break;
				case F_Orderdrid:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Orderdrid;
					param.Size =64  ;
					param.Value =_Orderdrid;
					break;
				case F_Equipment:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Equipment;
					param.Size =64  ;
					param.Value =_Equipment;
					break;
				case F_Equipmentid:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Equipmentid;
					param.Size =64  ;
					param.Value =_Equipmentid;
					break;
				case F_Attendingdr:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Attendingdr;
					param.Size =64  ;
					param.Value =_Attendingdr;
					break;
				case F_Attendingdrid:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Attendingdrid;
					param.Size =64  ;
					param.Value =_Attendingdrid;
					break;
				case F_Chiefdr1:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Chiefdr1;
					param.Size =64  ;
					param.Value =_Chiefdr1;
					break;
				case F_Chiefdr1id:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Chiefdr1id;
					param.Size =64  ;
					param.Value =_Chiefdr1id;
					break;
				case F_Special_reportdr:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Special_reportdr;
					param.Size =64  ;
					param.Value =_Special_reportdr;
					break;
				case F_Special_reportdrid:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Special_reportdrid;
					param.Size =64  ;
					param.Value =_Special_reportdrid;
					break;
				case F_Nurse:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Nurse;
					param.Size =64  ;
					param.Value =_Nurse;
					break;
				case F_Nurseid:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Nurseid;
					param.Size =64  ;
					param.Value =_Nurseid;
					break;
				case F_Technician:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Technician;
					param.Size =64  ;
					param.Value =_Technician;
					break;
				case F_Technicianid:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Technicianid;
					param.Size =64  ;
					param.Value =_Technicianid;
					break;
				case F_Examdr:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Examdr;
					param.Size =64  ;
					param.Value =_Examdr;
					break;
				case F_Examdrid:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Examdrid;
					param.Size =64  ;
					param.Value =_Examdrid;
					break;
				case F_Examitem:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Examitem;
					param.Size =64  ;
					param.Value =_Examitem;
					break;
				case F_Examitemid:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Examitemid;
					param.Size =64  ;
					param.Value =_Examitemid;
					break;
				case F_Performdeptid:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Performdeptid;
					param.Size =64  ;
					param.Value =_Performdeptid;
					break;
				case F_Charge:
					param.OracleType = OracleType.Number;
					param.ParameterName = ":"+F_Charge;
					param.Size =22  ;
					param.Value =_Charge;
					break;
				case F_Chargeconfirm:
					param.OracleType = OracleType.Number;
					param.ParameterName = ":"+F_Chargeconfirm;
					param.Size =22  ;
					param.Value =_Chargeconfirm;
					break;
				case F_Examrequest:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Examrequest;
					param.Size =256  ;
					param.Value =_Examrequest;
					break;
				case F_Examtech:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Examtech;
					param.Size =512  ;
					param.Value =_Examtech;
					break;
				case F_Disease:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Disease;
					param.Size =256  ;
					param.Value =_Disease;
					break;
				case F_Ordercomment:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Ordercomment;
					param.Size =256  ;
					param.Value =_Ordercomment;
					break;
				case F_Otherexam:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Otherexam;
					param.Size =256  ;
					param.Value =_Otherexam;
					break;
				case F_Orderpaper:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Orderpaper;
					param.Size =256  ;
					param.Value =_Orderpaper;
					break;
				case F_Orderlevel:
					param.OracleType = OracleType.Char;
					param.ParameterName = ":"+F_Orderlevel;
					param.Size =1  ;
					param.Value =_Orderlevel;
					break;
				case F_Filmstatus:
					param.OracleType = OracleType.Char;
					param.ParameterName = ":"+F_Filmstatus;
					param.Size =4  ;
					param.Value =_Filmstatus;
					break;
				case F_Reportstatus:
					param.OracleType = OracleType.Char;
					param.ParameterName = ":"+F_Reportstatus;
					param.Size =4  ;
					param.Value =_Reportstatus;
					break;
				case F_Examstatus:
					param.OracleType = OracleType.Char;
					param.ParameterName = ":"+F_Examstatus;
					param.Size =4  ;
					param.Value =_Examstatus;
					break;
				case F_Orderstatus:
					param.OracleType = OracleType.Char;
					param.ParameterName = ":"+F_Orderstatus;
					param.Size =4  ;
					param.Value =_Orderstatus;
					break;
				case F_Bookingdt:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Bookingdt;
					param.Size =20  ;
					param.Value =_Bookingdt;
					break;
				case F_Orderdt:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Orderdt;
					param.Size =20  ;
					param.Value =_Orderdt;
					break;
				case F_Examdt:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Examdt;
					param.Size =20  ;
					param.Value =_Examdt;
					break;
				case F_Deleted:
					param.OracleType = OracleType.Char;
					param.ParameterName = ":"+F_Deleted;
					param.Size =1  ;
					param.Value =_Deleted;
					break;
				case F_Editing:
					param.OracleType = OracleType.Char;
					param.ParameterName = ":"+F_Editing;
					param.Size =1  ;
					param.Value =_Editing;
					break;
				case F_Instanceuid:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Instanceuid;
					param.Size =64  ;
					param.Value =_Instanceuid;
					break;
				case F_Recorder:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Recorder;
					param.Size =64  ;
					param.Value =_Recorder;
					break;
				case F_Recorddt:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Recorddt;
					param.Size =20  ;
					param.Value =_Recorddt;
					break;
				case F_Order_sn:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Order_sn;
					param.Size =4  ;
					param.Value =_Order_sn;
					break;
				case F_Pregnancy:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Pregnancy;
					param.Size =64  ;
					param.Value =_Pregnancy;
					break;
				case F_Reserved2:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Reserved2;
					param.Size =64  ;
					param.Value =_Reserved2;
					break;
				case F_Reserved3:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Reserved3;
					param.Size =64  ;
					param.Value =_Reserved3;
					break;
				case F_Accno:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Accno;
					param.Size =64  ;
					param.Value =_Accno;
					break;
				case F_Register:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Register;
					param.Size =64  ;
					param.Value =_Register;
					break;
				case F_Registerid:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Registerid;
					param.Size =64  ;
					param.Value =_Registerid;
					break;
				case F_Operatename:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Operatename;
					param.Size =64  ;
					param.Value =_Operatename;
					break;
				case F_His_id:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_His_id;
					param.Size =1000  ;
					param.Value =_His_id;
					break;
				case F_Ordertype:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Ordertype;
					param.Size =64  ;
					param.Value =_Ordertype;
					break;
				case F_Examroom:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Examroom;
					param.Size =64  ;
					param.Value =_Examroom;
					break;
				case F_Bodypart:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Bodypart;
					param.Size =64  ;
					param.Value =_Bodypart;
					break;
				case F_Bodypartid:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Bodypartid;
					param.Size =64  ;
					param.Value =_Bodypartid;
					break;
				case F_Exposurecount:
					param.OracleType = OracleType.Number;
					param.ParameterName = ":"+F_Exposurecount;
					param.Size =22  ;
					param.Value =_Exposurecount;
					break;
				case F_Isbilling:
					param.OracleType = OracleType.Char;
					param.ParameterName = ":"+F_Isbilling;
					param.Size =1  ;
					param.Value =_Isbilling;
					break;
				case F_Hospitalname:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Hospitalname;
					param.Size =128  ;
					param.Value =_Hospitalname;
					break;
				case F_His_examitem:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_His_examitem;
					param.Size =256  ;
					param.Value =_His_examitem;
					break;
				case F_Deliverdt:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Deliverdt;
					param.Size =20  ;
					param.Value =_Deliverdt;
					break;
				case F_Receivedt:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Receivedt;
					param.Size =20  ;
					param.Value =_Receivedt;
					break;
				case F_Frost:
					param.OracleType = OracleType.Char;
					param.ParameterName = ":"+F_Frost;
					param.Size =1  ;
					param.Value =_Frost;
					break;
				case F_Directhis:
					param.OracleType = OracleType.Char;
					param.ParameterName = ":"+F_Directhis;
					param.Size =1  ;
					param.Value =_Directhis;
					break;
				case F_Arstatus:
					param.OracleType = OracleType.Char;
					param.ParameterName = ":"+F_Arstatus;
					param.Size =4  ;
					param.Value =_Arstatus;
					break;
				case F_Barcode:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Barcode;
					param.Size =64  ;
					param.Value =_Barcode;
					break;
				case F_Makecuttime:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Makecuttime;
					param.Size =64  ;
					param.Value =_Makecuttime;
					break;
				case F_Outcuttime:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Outcuttime;
					param.Size =64  ;
					param.Value =_Outcuttime;
					break;
				case F_Icedcutstatus:
					param.OracleType = OracleType.Char;
					param.ParameterName = ":"+F_Icedcutstatus;
					param.Size =1  ;
					param.Value =_Icedcutstatus;
					break;
				case F_Icedtimes:
					param.OracleType = OracleType.Char;
					param.ParameterName = ":"+F_Icedtimes;
					param.Size =2  ;
					param.Value =_Icedtimes;
					break;
				case F_Getmaterialjudge:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Getmaterialjudge;
					param.Size =20  ;
					param.Value =_Getmaterialjudge;
					break;
				case F_Getmaterialdr:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Getmaterialdr;
					param.Size =64  ;
					param.Value =_Getmaterialdr;
					break;
				case F_Getmaterialdrid:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Getmaterialdrid;
					param.Size =64  ;
					param.Value =_Getmaterialdrid;
					break;
				case F_Getjudged:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Getjudged;
					param.Size =64  ;
					param.Value =_Getjudged;
					break;
				case F_Operateroomnumber:
					param.OracleType = OracleType.NVarChar;
					param.ParameterName = ":"+F_Operateroomnumber;
					param.Size =64  ;
					param.Value =_Operateroomnumber;
					break;
                case F_Signfordr:
                    param.OracleType = OracleType.NVarChar;
                    param.ParameterName = ":" + F_Signfordr;
                    param.Size = 64;
                    param.Value = _Signfordr;
                    break;
                case F_Signfordrid:
                    param.OracleType = OracleType.NVarChar;
                    param.ParameterName = ":" + F_Signfordrid;
                    param.Size = 64;
                    param.Value = _Signfordrid;
                    break;
                case F_Sequence:
                    param.OracleType = OracleType.NVarChar;
                    param.ParameterName = ":" + F_Sequence;
                    param.Size = 64;
                    param.Value = _Sequence;
                    break;
			}
			return param;}
		protected  override void  SetValueToMemberByName(string strName,string strValue) 
		{
			switch(strName)
			{
				case F_Orderseq:
					Orderseq=strValue;
					break;
				case F_Patseq:
					Patseq=strValue;
					break;
				case F_Pattype:
					Pattype=strValue;
					break;
				case F_Hospitalid:
					Hospitalid=strValue;
					break;
				case F_Physicalexamid:
					Physicalexamid=strValue;
					break;
				case F_Modalityid:
					Modalityid=strValue;
					break;
				case F_Modality:
					Modality=strValue;
					break;
				case F_Clinic:
					Clinic=strValue;
					break;
				case F_Clinicid:
					Clinicid=strValue;
					break;
				case F_Ward:
					Ward=strValue;
					break;
				case F_Wardid:
					Wardid=strValue;
					break;
				case F_Sickroom:
					Sickroom=strValue;
					break;
				case F_Bedno:
					Bedno=strValue;
					break;
				case F_Orderdr:
					Orderdr=strValue;
					break;
				case F_Orderdrid:
					Orderdrid=strValue;
					break;
				case F_Equipment:
					Equipment=strValue;
					break;
				case F_Equipmentid:
					Equipmentid=strValue;
					break;
				case F_Attendingdr:
					Attendingdr=strValue;
					break;
				case F_Attendingdrid:
					Attendingdrid=strValue;
					break;
				case F_Chiefdr1:
					Chiefdr1=strValue;
					break;
				case F_Chiefdr1id:
					Chiefdr1id=strValue;
					break;
				case F_Special_reportdr:
					Special_reportdr=strValue;
					break;
				case F_Special_reportdrid:
					Special_reportdrid=strValue;
					break;
				case F_Nurse:
					Nurse=strValue;
					break;
				case F_Nurseid:
					Nurseid=strValue;
					break;
				case F_Technician:
					Technician=strValue;
					break;
				case F_Technicianid:
					Technicianid=strValue;
					break;
				case F_Examdr:
					Examdr=strValue;
					break;
				case F_Examdrid:
					Examdrid=strValue;
					break;
				case F_Examitem:
					Examitem=strValue;
					break;
				case F_Examitemid:
					Examitemid=strValue;
					break;
				case F_Performdeptid:
					Performdeptid=strValue;
					break;
				case F_Charge:
					Charge=strValue;
					break;
				case F_Chargeconfirm:
					Chargeconfirm=strValue;
					break;
				case F_Examrequest:
					Examrequest=strValue;
					break;
				case F_Examtech:
					Examtech=strValue;
					break;
				case F_Disease:
					Disease=strValue;
					break;
				case F_Ordercomment:
					Ordercomment=strValue;
					break;
				case F_Otherexam:
					Otherexam=strValue;
					break;
				case F_Orderpaper:
					Orderpaper=strValue;
					break;
				case F_Orderlevel:
					Orderlevel=strValue;
					break;
				case F_Filmstatus:
					Filmstatus=strValue;
					break;
				case F_Reportstatus:
					Reportstatus=strValue;
					break;
				case F_Examstatus:
					Examstatus=strValue;
					break;
				case F_Orderstatus:
					Orderstatus=strValue;
					break;
				case F_Bookingdt:
					Bookingdt=strValue;
					break;
				case F_Orderdt:
					Orderdt=strValue;
					break;
				case F_Examdt:
					Examdt=strValue;
					break;
				case F_Deleted:
					Deleted=strValue;
					break;
				case F_Editing:
					Editing=strValue;
					break;
				case F_Instanceuid:
					Instanceuid=strValue;
					break;
				case F_Recorder:
					Recorder=strValue;
					break;
				case F_Recorddt:
					Recorddt=strValue;
					break;
				case F_Order_sn:
					Order_sn=strValue;
					break;
				case F_Pregnancy:
					Pregnancy=strValue;
					break;
				case F_Reserved2:
					Reserved2=strValue;
					break;
				case F_Reserved3:
					Reserved3=strValue;
					break;
				case F_Accno:
					Accno=strValue;
					break;
				case F_Register:
					Register=strValue;
					break;
				case F_Registerid:
					Registerid=strValue;
					break;
				case F_Operatename:
					Operatename=strValue;
					break;
				case F_His_id:
					His_id=strValue;
					break;
				case F_Ordertype:
					Ordertype=strValue;
					break;
				case F_Examroom:
					Examroom=strValue;
					break;
				case F_Bodypart:
					Bodypart=strValue;
					break;
				case F_Bodypartid:
					Bodypartid=strValue;
					break;
				case F_Exposurecount:
					Exposurecount=strValue;
					break;
				case F_Isbilling:
					Isbilling=strValue;
					break;
				case F_Hospitalname:
					Hospitalname=strValue;
					break;
				case F_His_examitem:
					His_examitem=strValue;
					break;
				case F_Deliverdt:
					Deliverdt=strValue;
					break;
				case F_Receivedt:
					Receivedt=strValue;
					break;
				case F_Frost:
					Frost=strValue;
					break;
				case F_Directhis:
					Directhis=strValue;
					break;
				case F_Arstatus:
					Arstatus=strValue;
					break;
				case F_Barcode:
					Barcode=strValue;
					break;
				case F_Makecuttime:
					Makecuttime=strValue;
					break;
				case F_Outcuttime:
					Outcuttime=strValue;
					break;
				case F_Icedcutstatus:
					Icedcutstatus=strValue;
					break;
				case F_Icedtimes:
					Icedtimes=strValue;
					break;
				case F_Getmaterialjudge:
					Getmaterialjudge=strValue;
					break;
				case F_Getmaterialdr:
					Getmaterialdr=strValue;
					break;
				case F_Getmaterialdrid:
					Getmaterialdrid=strValue;
					break;
				case F_Getjudged:
					Getjudged=strValue;
					break;
				case F_Operateroomnumber:
					Operateroomnumber=strValue;
					break;
                case F_Signfordr:
                    Signfordr = strValue;
                    break;
                case F_Signfordrid:
                    Signfordrid = strValue;
                    break;
                case F_Sequence:
                    Sequence = strValue;
                    break;
				default:throw new Exception("控件名字没有对应的数据库字段："+strName);
			}
		}
	}
}

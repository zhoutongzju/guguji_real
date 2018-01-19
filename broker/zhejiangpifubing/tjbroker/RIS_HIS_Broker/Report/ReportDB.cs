using Maroland.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RISBroker
{
    class ReportDB
    {
          

        public DataTable GetReportViewByOrderSeq(string sOrderSeq)
        {
            DataMgr mgr = DataMgrFactory.CreateDataMgr(DataMgrFactory.DBNameEnum.RIS_DB);
            mgr.AddConditionParameter("ORDERSEQ", sOrderSeq);
            return mgr.GetDataTableBySql("SELECT * FROM VIEWREPORTLIST WHERE ORDERSEQ=:ORDERSEQ");
        }

        public DataTable GetReportViewByReportSeq(string Reportseq)
        {
            DataMgr mgr = DataMgrFactory.CreateDataMgr(DataMgrFactory.DBNameEnum.RIS_DB);
            mgr.AddConditionParameter("reportseq", Reportseq);
            return mgr.GetDataTableBySql("SELECT * FROM VIEWREPORTLIST WHERE reportseq=:reportseq");
        }
              


        /// <summary>
        /// 获取报告贴图
        /// </summary>
        /// <param name="reportseq"></param>
        /// <returns></returns>
        public DataTable GetReportLabelTable(string reportseq)
        {
            DataMgr mgr = DataMgrFactory.CreateDataMgr(DataMgrFactory.DBNameEnum.RIS_DB);
            mgr.AddConditionParameter("reportseq", reportseq);
            return mgr.GetDataTableBySql("SELECT * FROM t_us_dicomimage WHERE SELECTED <>0 AND REPORTID=:reportseq ORDER BY SELINDEX ");

        }

        /// <summary>
        /// 得到报告模板
        /// </summary>
        /// <param name="sTemplateID"></param>
        /// <returns></returns>
        public DataTable GetStyleByTempID(string sTemplateID)// TEMPLATEID
        {
            DataMgr mgr = DataMgrFactory.CreateDataMgr(DataMgrFactory.DBNameEnum.RIS_DB);
            mgr.AddConditionParameter("STYLEID", sTemplateID);
            return mgr.GetDataTableBySql("SELECT * FROM T_STYLE WHERE STYLEID=:STYLEID");
        }

        /// <summary>
        /// 得到签名图片
        /// </summary>
        /// <param name="sUserID"></param>
        /// <returns></returns>
        public string GetSignaturePicByID(string sUserID)
        {
            string sDPath = Application.StartupPath + "\\template";
            if (Directory.Exists(sDPath) == false)
            {
                Directory.CreateDirectory(sDPath);
            }

            string sFPath = string.Format("{0}\\{1}.jpg", sDPath, sUserID);

            if (File.Exists(sFPath))
            {
                return sFPath;
            }

            DataMgr mgr = DataMgrFactory.CreateDataMgr(DataMgrFactory.DBNameEnum.RIS_DB);
            mgr.AddConditionParameter("USERID", sUserID);
            DataTable dtUser = mgr.GetDataTableBySql("SELECT * FROM T_USER WHERE USERID=:USERID");

            System.IO.FileStream fs = null;

            Byte[] bit = null;

            try
            {
                if (dtUser != null && dtUser.Rows.Count > 0 && dtUser.Rows[0]["SIGNATUREPIC"] != DBNull.Value)
                {
                    bit = dtUser.Rows[0]["SIGNATUREPIC"] as Byte[];
                    fs = new System.IO.FileStream(sFPath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
                    fs.Write(bit, 0, bit.Length);
                    fs.Close();
                    return sFPath;
                }
            }
            catch (Exception ex)
            {
                 XLogManager.LogError(ex);
            }
            return null;
        }
        #region 病理专用
        /// <summary>
        /// 取得病理结果
        /// </summary>
        /// <param name="sReportSeq"></param>
        /// <returns></returns>
        public DataRow GetGMReportByReportSeq(string sReportSeq)
        {
            DataMgr mgr = DataMgrFactory.CreateDataMgr(DataMgrFactory.DBNameEnum.RIS_DB);

            mgr.AddConditionParameter("REPORTSEQ", sReportSeq);

            DataTable dt = mgr.GetDataTable("ViewGMReportList");

            if (dt != null && dt.Rows.Count > 0)
                return dt.Rows[0];
            else
                return null;
        }

        /// <summary>
        /// 取得取材记录
        /// </summary>
        /// <param name="sOrderSeq"></param>
        /// <returns></returns>
        public DataTable GetCuttingByOrderSeq(String sOrderSeq)
        {
            DataMgr mgr = DataMgrFactory.CreateDataMgr(DataMgrFactory.DBNameEnum.RIS_DB);
            mgr.AddConditionParameter("ORDERSEQ", sOrderSeq);
            return mgr.GetDataTable("T_GM_Cutting");
        }       
        #endregion

        public DataTable GetReportPic(string sReportSeq)
        {
            DataMgr mgr = DataMgrFactory.CreateDataMgr(DataMgrFactory.DBNameEnum.RIS_DB);
            mgr.AddConditionParameter("REPORTSEQ", sReportSeq);
            return mgr.GetDataTableBySql("SELECT * FROM T_REPORTPIC WHERE REPORTSEQ=:REPORTSEQ");
        }

        public DataTable GetUSMeasureByReportSeq(string sReportSeq)
        {
            DataMgr mgr = DataMgrFactory.CreateDataMgr(DataMgrFactory.DBNameEnum.RIS_DB);
            string sql = string.Format("SELECT * FROM T_US_MEASURE M WHERE M.REPORTSEQ='{0}'", sReportSeq);
            return mgr.GetDataTableBySql(sql);
        }

        public DataTable GetESReportByReportSeq(string sReportSeq)
        {
            DataMgr mgr = DataMgrFactory.CreateDataMgr(DataMgrFactory.DBNameEnum.RIS_DB);
            string sql = string.Format("SELECT * FROM T_ESREPORT M WHERE M.REPORTSEQ='{0}'", sReportSeq);
            return mgr.GetDataTableBySql(sql);
        }
         
    }
}

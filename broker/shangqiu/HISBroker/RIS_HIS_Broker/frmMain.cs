using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Threading;
using System.IO;
using Maroland.DataAccess;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace RISBroker
{
    public partial class frmMain : Form
    {
   

        delegate void ButtonEnable();
        delegate void ShowDataToFrom(string Msg, string queueid, string patName, string patid, string modality, string modalityid, string patType, bool isSuccess);

        private Thread RunThread = null;//运行线程
        private Thread GuardThread = null;//守护线程

        private bool Stop = false;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.btnSetting.Enabled = false;
            this.btnStart.Enabled = false;
            this.btnStop.Enabled = true;
            this.lvData.Items.Clear();
            try
            {
                Stop = false;
                StartWait();
            }
            catch (Exception ex)
            {
                XLogManager.LogError(ex);
            }
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            frmSetting frm = new frmSetting();
            frm.ShowDialog();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Stop = true;
            this.btnSetting.Enabled = true;
            this.btnStart.Enabled = true;
            this.btnStop.Enabled = false;
            try
            {
                if (RunThread != null)
                {
                    try
                    {
                        RunThread.Abort();
                    }
                    catch (Exception ex)
                    {
                        XLogManager.LogError(ex);
                    }
                }

                if (GuardThread != null)
                {
                    try
                    {
                        GuardThread.Abort();
                    }
                    catch (Exception ex)
                    {
                        XLogManager.LogError(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                XLogManager.LogError(ex);
            }
        }

        #region 启动轮询

        private void StartWait()
        {
            try
            {
                RunThread = new Thread(ThreadRun);
                RunThread.IsBackground = true;
                RunThread.Start();

                Thread.Sleep(100);//休息一下

                GuardThread = new Thread(StartGuard);
                GuardThread.IsBackground = true;
                GuardThread.Start(RunThread);
            }
            catch (Exception ex)
            {
                XLogManager.LogError(ex);
            }

        }


        private void StartGuard(object obj)
        {
            Thread t = obj as Thread;
            if (t != null)
            {
                try
                {
                    t.Join();
                    XLogManager.LogError("线程结束了");
                    if (!Stop)
                    {
                        StartWait();
                    }
                }
                catch (Exception ex)
                {
                    XLogManager.LogError(ex);
                }

            }
        }

        private void ThreadRun()
        {
            while (true)
            {
                if (ConfigHelper.GetConfig("DStart", "0") == "1")
                {
                    if ((DateTime.Now.ToString("HH:mm") == ConfigHelper.GetConfig("DTime", "00:00")))
                    {
                        RunData();
                    }
                }
                else
                {
                    RunData();
                }

                if (Stop)
                {
                    break;
                }
                Thread.Sleep(int.Parse(ConfigHelper.GetConfig("ProverTime", "5")) * 1000);
            }
        }

        private void RunData()
        {
            XLogManager.LogInfo("轮询开始");
            try
            {
                List<string> listReportSeq = new List<string>();
                DataTable table = GetDbData();
                if (table != null)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        string his_id = Helper.GetValue(row[T_Order.F_His_id]);
                        string pattype = Helper.GetValue(row[T_Order.F_Pattype]);
                        string queueid = Helper.GetValue(row["HIS_ID"]);
                        string patid = Helper.GetValue(row[T_Patient.F_PatID]);
                        string patName = Helper.GetValue(row[T_Patient.F_PatName]);
                        string modalityid = Helper.GetValue(row[T_Order.F_Modalityid]);
                        string modality = Helper.GetValue(row[T_Order.F_Modality]);
                        string reportseq = Helper.GetValue(row[T_Report.F_Reportseq]);
                        string register = Helper.GetValue(row[T_Order.F_Register]);
                        string outpatientid= Helper.GetValue(row[T_Patient.F_OutpatientID]);
                        string inpatientid = Helper.GetValue(row[T_Patient.F_InpatientID]);
                        bool bStatus = false;
                        if (!String.IsNullOrEmpty(his_id))
                        {

                            OracleConnection oracon = new OracleConnection();
                            oracon.ConnectionString = ConfigurationManager.AppSettings["hisconnection"];
                          //  MessageBox.Show(ConfigurationManager.AppSettings["hisconnection"]);
                            OracleCommand cmd = new OracleCommand();
                            try
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                string proName = "pf_insert_pacs_report_record";
                                cmd.CommandText = proName;
                                cmd.Connection = oracon;
                                OracleParameter[] param = new OracleParameter[12];
                                if (outpatientid == "") outpatientid = "未填写";
                                if (inpatientid == "") inpatientid = "未填写";
                                param[0] = new OracleParameter("AS_APPLY_NO", OracleDbType.Varchar2, his_id, ParameterDirection.Input);
                                param[1] = new OracleParameter("AS_PACS_NO", OracleDbType.Varchar2, modalityid, ParameterDirection.Input);
                              //  MessageBox.Show(row["pattype"].ToString());

                                if (row["pattype"].ToString() == "O" || pattype == "E")
                                {
                                 
                                    param[2] = new OracleParameter("AS_SICK_ID", OracleDbType.Varchar2, outpatientid, ParameterDirection.Input);
                                    param[9] = new OracleParameter("AS_SICK_TYPE", OracleDbType.Varchar2, "门诊", ParameterDirection.Input);
                                }
                                else
                                {
                                    param[2] = new OracleParameter("AS_SICK_ID", OracleDbType.Varchar2, inpatientid, ParameterDirection.Input);
                                    param[9] = new OracleParameter("AS_SICK_TYPE", OracleDbType.Varchar2, "住院", ParameterDirection.Input);
                                }
                                param[3] = new OracleParameter("AS_EXEC_DEPT", OracleDbType.Varchar2, modality, ParameterDirection.Input);
                                param[4] = new OracleParameter("AS_EXEC_MAN", OracleDbType.Varchar2, "register", ParameterDirection.Input);
                                param[5] = new OracleParameter("AS_EXEC_TIME", OracleDbType.Varchar2, row["ORDERDT"], ParameterDirection.Input);
                                param[6] = new OracleParameter("AS_REPORT_MAN", OracleDbType.Varchar2, row["verifydr"], ParameterDirection.Input);
                                param[7] = new OracleParameter("AS_REPORT_TIME", OracleDbType.Varchar2, row["verifydt"], ParameterDirection.Input);
                                param[8] = new OracleParameter("AS_STATES", OracleDbType.Varchar2, "2", ParameterDirection.Input);
                                param[10] = new OracleParameter("AS_RESULT_DESCRIBE", OracleDbType.Varchar2, row["studyresult"], ParameterDirection.Input);
                                if (row["diagresult"].ToString() == "") row["diagresult"] = "";   //20171225 不再给默认值
                                param[11] = new OracleParameter("AS_SUMMRY", OracleDbType.Varchar2, row["diagresult"], ParameterDirection.Input);
                                for (int i = 0; i < param.Length; i++)
                                {
                                 //   MessageBox.Show(param[i].Value.ToString());
                                    cmd.Parameters.Add(param[i]);
                                }
                                if (oracon.State != ConnectionState.Open)
                                    oracon.Open();                                
                                cmd.ExecuteNonQuery();
                       
                                bStatus = true;

                            }
                            catch(OracleException ex)
                            {
                                XLogManager.LogError(ex.Message);
                            }

                            //更新t_report_queue
                            if (bStatus)
                            {

                                // 成功了才更新标记, 使得错误的能够重试
                               UpdateQueueFlag(reportseq, bStatus);
                            }
                        }
                        else
                        {
                            XLogManager.LogInfo("HIS_ID为空，不上传，queue_id: " + queueid);
                            // his_id为空的不需要重试
                            UpdateQueueFlag(reportseq, false);
                        }

                        ShowData(string.Empty, queueid, patName, patid, modality, modalityid, pattype, bStatus);
                    }
                }
            }
            catch (Exception ex)
            {
                XLogManager.LogError(ex);
            }

            XLogManager.LogInfo("轮询结束");
        }


      
      

       


       

      
        private DataTable GetDbData()
        {

            //SQL说明: 时间被格式化成yyyymmddhh24miss格式
            //create by 周侗 20171225
            string sql = @"select distinct r.reportseq,
                p.patname,
                p.outpatientid,
                p.inpatientid,
                o.register,
                r.reportdr,
                o.his_id,
           to_char(to_date(o.orderdt,'yyyy-mm-dd hh24:mi:ss'),'yyyymmddhh24miss') orderdt,
            to_char(to_date(r.reportdt,'yyyy-mm-dd hh24:mi:ss'),'yyyymmddhh24miss') reportdt,
              
                o.modalityid,
                r.diagresult,
                r.studyresult,
                r.verifydr,
                r.verifydt,
                o.modality,
                p.patid,
                o.pattype
  from t_report_queue t, t_order o, t_report r, t_patient p
 where 1 = 1
   and t.read_verify_flag is null
   and o.deleted = '0'
   and t.orderid = o.orderseq
   and p.patseq = o.patseq
   and o.reportseq = r.reportseq
   and r.verifydt >= '{0}'
   and r.verifydt <= '{1}'";

            DataTable table = new DataTable();
            try
            {
                sql = string.Format(sql
              , (ConfigHelper.GetConfig("StartDate", "1979-01-01") + " 00:00:00")
              , DateTime.Now.AddMinutes(-int.Parse(ConfigHelper.GetConfig("LateTime", "0"))).ToString("yyyy-MM-dd HH:mm:ss"));

                DataMgr mgr = DataMgrFactory.CreateDataMgr(DataMgrFactory.DBNameEnum.RIS_DB);
                table = mgr.GetDataTableBySql(sql);
            }
            catch (Exception ex)
            {
                XLogManager.LogError(ex);
            }

            return table;
        }

        /// <summary>
        /// 查找orderseq list 然后回写t_report_queue字段
        /// </summary>
        /// <param name="reportseq"></param>
        /// <param name="isSuccess"></param>
        /// <returns></returns>
        private bool UpdateQueueFlag(string reportseq, bool isSuccess)
        {
            bool flag = false;
            try
            {
                //默认不可能出现orderseq为空的结果，理论上也不可能为空
                var sql1 = string.Format("select orderseq from t_order where reportseq='{0}'", reportseq);
                DataMgr mgr = DataMgrFactory.CreateDataMgr(DataMgrFactory.DBNameEnum.RIS_DB);
                DataTable orderseqTable = mgr.GetDataTableBySql(sql1);
                foreach (DataRow row in orderseqTable.Rows)
                {
                    string sql = string.Format(" update t_report_queue q set q.read_verify_flag='{0}' where q.orderid='{1}'", (isSuccess ? "Y" : "E"), row["orderseq"]);
                    mgr.ExecuteSql(sql);
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                XLogManager.LogError(ex);
                flag = false;
            }
            return flag;
        }


        private static void HasOrNewDic(string dicPath)
        {
            if (!Directory.Exists(dicPath))
            {
                Directory.CreateDirectory(dicPath);
            }
        }


        #endregion

        #region 显示数据
        private void ShowData(string Msg, string queueid, string patName, string patid, string modality, string modalityid, string patType, bool isSuccess)
        {
            if (this.lvData.InvokeRequired)
            {
                this.BeginInvoke(new ShowDataToFrom(ShowData), Msg, queueid, patName, patid, modality, modalityid, patType, isSuccess);
            }
            else
            {
                try
                {
                    ListViewItem item = new ListViewItem((this.lvData.Items.Count + 1).ToString());
                    item.SubItems.Add(queueid);
                    item.SubItems.Add(patType);
                    item.SubItems.Add(modality);
                    item.SubItems.Add(DateTime.Now.ToString());
                    item.SubItems.Add(patName);
                    item.SubItems.Add(patid);
                    item.SubItems.Add(modalityid);
                    //if (patType.Trim().ToUpper() == "P")
                        item.SubItems.Add((isSuccess ? "成功" : "失败"));
                    //else
                        //item.SubItems.Add("放弃");
                    item.ForeColor = Color.Red;
                    if (isSuccess)
                        item.ForeColor = Color.Blue;
                    //if (patType.Trim().ToUpper() != "P")
                    //{
                    //    item.ForeColor = Color.Orange;
                    //}

                    this.lvData.Items.Add(item);
                    this.lvData.EnsureVisible(this.lvData.Items.Count - 1);
                }
                catch (Exception ex)
                {
                    XLogManager.LogError(ex);
                }
            }
        }

        private void AddLog(string queueid, bool isSuccess)
        {
            try
            {
                DataMgr mgr = DataMgrFactory.CreateDataMgr(DataMgrFactory.DBNameEnum.RIS_DB);

                T_reporttofile model = new T_reporttofile();
                model.Id = Guid.NewGuid().ToString();
                model.Queueid = queueid;
                model.Result = (isSuccess ? "成功" : "失败");
                model.Datetime = DateTime.Now.ToString();

                mgr.SaveData(model);
            }
            catch (Exception ex)
            {
                XLogManager.LogError("记录日志发生错误", ex);
            }

        }
        #endregion

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                HideFrom();
        }

        private void HideFrom()
        {
            this.ShowInTaskbar = false;
            this.notifyIcon1.Visible = true;
            this.Hide();
        }



        private void ShowForm()
        {
            if (!this.ShowInTaskbar)
            {
                this.ShowInTaskbar = true;

            }
            this.notifyIcon1.Visible = false;
            this.Show();
            this.Activate();
            this.WindowState = FormWindowState.Normal;
        }



        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            ShowForm();
        }




    }
}

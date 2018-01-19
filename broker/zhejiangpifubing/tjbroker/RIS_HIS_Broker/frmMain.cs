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
                        string his_id = Helper.GetValue(row[T_Order.F_Physicalexamid]);
                        string pattype = Helper.GetValue(row[T_Order.F_Pattype]);
                        string queueid = Helper.GetValue(row["Physicalexamid"]);
                        string patid = Helper.GetValue(row[T_Patient.F_PatID]);
                        string patName = Helper.GetValue(row[T_Patient.F_PatName]);
                        string modalityid = Helper.GetValue(row[T_Order.F_Modalityid]);
                        string modality = Helper.GetValue(row[T_Order.F_Modality]);
                        string reportseq = Helper.GetValue(row[T_Report.F_Reportseq]);
                        bool bStatus = false;
                        if (!String.IsNullOrEmpty(his_id))
                        {
                            DataTable examitemtable;
                            DataTable dcmfiletable;
                            string dcmFilestring = "";
                            string isimageFile="0";
                            string examitemidstring="";
                            string examitemstring="";

                            //获取检查项目
                   //         XLogManager.LogError("该转换reportseq值为" + reportseq);
                            examitemtable = getExamItem(reportseq);
                            
                            if (examitemtable.Rows.Count>0)
                            {

                                examitemidstring = examitemtable.Rows[0]["examitemid"].ToString();
                                examitemstring = examitemtable.Rows[0]["examitem"].ToString();
                         //       XLogManager.LogError("获取到检查项目值为:" + examitemidstring + examitemstring);
                            }
                       if(row["modality"].ToString().Trim()=="CT") //CT不上传t图片
                            {
                                isimageFile = "0";
                            }
                       else
                            {
                                dcmfiletable = getDcmFile(reportseq);
                                if(dcmfiletable.Rows.Count  >0)
                                {
                                    dcmFilestring = dcmfiletable.Rows[0]["dcmfiles"].ToString();
                                    isimageFile = "1";
                                }
                              
                            }

                          SqlServerHelper sqlhelper = new SqlServerHelper();
                            sqlhelper.OpenConnection();
                                string sql = "insert into tj_pacsjgb(DJLSH,ZHXMBH,PACSDJH,JG,JCSJ,SHR,SHRQ,TPZT,JCQKFZSM,TPLJ,CZY,JKID) values('{0}','{1}','{2}','{3}'," +
                                    "'{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')";
                                sql = string.Format(sql, row["physicalexamid"], examitemidstring, row["modalityid"], row["diagresult"],
                                    row["studyresult"], row["verifydr"], row["verifydt"], isimageFile, examitemstring, dcmFilestring, row["verifydr"], "3");
                                if (sqlhelper.ExecuteSql(sql) > 0) bStatus = true;
                            //插入体检系统库

            

                            //更新t_report_queue
                            if (bStatus)
                            {
                              //  MessageBox.Show("成功了");
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

        //获取报告贴图列表并且格式化
        private DataTable getDcmFile(string reportseq)
        {
            var sql = @"select distinct d.serialno,
                        to_char(replace(wmsys.wm_concat('\\192.168.0.17\ris\sht\' ||
                                                        d.pathdetail || '\' ||
                                                        i.imagefile)||';',
                                        ',',
                                        ';')) dcmfiles
          from pacs.dexam d, pacs.dimage i,t_order o
         where d.id = i.dexam
               and o.reportseq='{0}'
               and o.accno=d.serialno
           and (d.modality = 'DX' or d.modality = 'CR' or d.modality = 'DR')
         group by d.serialno";
            var sql1 = string.Format(sql, reportseq);
            DataMgr mgr = DataMgrFactory.CreateDataMgr(DataMgrFactory.DBNameEnum.RIS_DB);
            DataTable dcmFileTable = mgr.GetDataTableBySql(sql1);
            return dcmFileTable;



        }
        //获取检查项目并且格式化

        private DataTable getExamItem(string reportseq)
        {

            var sql1 = string.Format("select to_char(replace(wmsys.wm_concat(l.his_examitemid ),',',';')) " +
                "examitemid,to_char(replace(wmsys.wm_concat(o.examitem ),',',';')) examitem from t_order o, t_His_Examitemlink l where o.reportseq = '{0}' and o.examitemid=l.ris_examitemid", reportseq);
         //   XLogManager.LogInfo(sql1);
            DataMgr mgr = DataMgrFactory.CreateDataMgr(DataMgrFactory.DBNameEnum.RIS_DB);
            DataTable examTable = mgr.GetDataTableBySql(sql1);
            return examTable;



        }
        private bool UploadToHis(string ip, int port, DataRow row)
        {
            bool ret = false;
            try
            {
                //RISServiceProxy.Proxy risproxy = new RISServiceProxy.Proxy();
                string errinfo = "";
            //    ret = risproxy.SenReport(ip, port, row, ref errinfo);

                if(ret)
                {
                    XLogManager.LogInfo("上传HIS失败成功");
                }
                else
                {
                    XLogManager.LogInfo("上传HIS失败，错误信息:" + errinfo);
                }
            }
            catch(Exception ex)
            {
                XLogManager.LogError("上传HIS发生异常：" + ex);
            }

            return ret;
        }

        private string GetHisExamIDFromRis(string risExaID)
        {
            string hisExamID = "";
     
            try
            {
                DataTable table = new DataTable();
                string sql = string.Format("select * from t_his_examitemlink where ris_examitemid='{0}'", risExaID);

                DataMgr mgr = DataMgrFactory.CreateDataMgr(DataMgrFactory.DBNameEnum.RIS_DB);
                table = mgr.GetDataTableBySql(sql);

                if ((table != null) && (table.Rows.Count > 0))
                {
                    hisExamID = Helper.GetValue(table.Rows[0]["his_examitemid"]);
                }
            }
            catch (Exception ex)
            {
                XLogManager.LogError(ex);
            }

            return hisExamID;
        }


        private string GetHisPatID(string his_id)
        {
            string hisPatID = "";

            try
            {
                DataTable table = new DataTable();
                string sql = string.Format("select PatientId from x_order where OrderId='{0}' and DeleteFlag='0'", his_id);

                DataMgr mgr = DataMgrFactory.CreateDataMgr(DataMgrFactory.DBNameEnum.RIS_DB);
                table = mgr.GetDataTableBySql(sql);

                if ((table != null) && (table.Rows.Count > 0))
                {
                    hisPatID = Helper.GetValue(table.Rows[0]["PatientId"]);
                }
            }
            catch (Exception ex)
            {
                XLogManager.LogError(ex);
            }
            XLogManager.LogError("通过HIS_ID获取HIS的病人ID：转换后得到的值：" +hisPatID );
            return hisPatID;
        }

        private string GetMapValue(string section, string key, bool needExcept = false)
        {
            string detailKey = section + "-" + key.Trim();
            string value = ConfigHelper.GetConfig(detailKey, "");
            if (value == "")
            {
                if (needExcept)
                {
                    throw new Exception(string.Format("{0} key not found.", key));
                }
                else
                {
                    XLogManager.LogInfo(string.Format("{0} key not found.", key));
                }
            }
            return value;
        }

        private DataTable GetDbData()
        {

            //SQL说明: 一份报告多份检查，合并检查项目为一个字段，格式  检查项目A/检查项目B
            //        合并所有报告的图像合并为一个字段 ，使用绝对路径。 ;分开
            //CT不传图片
            //只有检查项目与HIS关联过的项目才会回传，如果修改为不关联也回传，请修改examitem的(+)位置
            //create by 周侗 20170810
            string sql = @"select distinct r.reportseq,
                p.patname,
                p.physicalexamid,
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
   and o.pattype = 'P'
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

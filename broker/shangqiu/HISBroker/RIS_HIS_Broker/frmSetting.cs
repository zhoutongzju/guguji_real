﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RISBroker
{
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            InitializeComponent();
        }

        private void btnSelectDic_Click(object sender, EventArgs e)
        {

        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            LoadSetting();
        }

        private void LoadSetting()
        {

            this.txtRISTNSName.Text = ConfigHelper.GetConfig("ristnsname", "ris");
            this.txtRisDBUser.Text = ConfigHelper.GetConfig("risuser", "ris");
            this.txtRisDBPassword.Text = Helper.DeEncrypt(ConfigHelper.GetConfig("rispassword", "bWFyb2xhbmQ="));

            this.txtProxyIP.Text = ConfigHelper.GetConfig("HISProxyIP", "127.0.0.1");
            this.txtProxyPort.Text = ConfigHelper.GetConfig("HISProxyPort", "6556");

            this.ckDStart.Checked = ConfigHelper.GetConfig("DStart", "0") == "1";
            this.ckSql.Checked = ConfigHelper.GetConfig("LogSql", "0") == "1";
            this.dtpStartTime.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " " + ConfigHelper.GetConfig("DTime", "00:00") + ":00");


            this.dtpStart.Value = DateTime.Parse(ConfigHelper.GetConfig("StartDate", "1979-01-01"));

            decimal t =  decimal.Parse(ConfigHelper.GetConfig("LateTime", "0"));
            if(t<0)
                t=1;

            this.nudLatTime.Value = t;

            decimal d =decimal.Parse(ConfigHelper.GetConfig("ProverTime", "5"));
            if(d<=0)
                d=1;

            this.nudTime.Value = d;
        }

        private void btnRisTest_Click(object sender, EventArgs e)
        {
            string connStr = string.Format("data source={0};user id={1};password={2}", this.txtRISTNSName.Text, this.txtRisDBUser.Text, txtRisDBPassword.Text);
            IDBHelper heler = DBHelperFactory.GetDBHelper(XDBType.ORACLE, connStr);
            try
            {
                heler.GetSingle("select 1 from dual");
                MessageBox.Show("连接成功");
            }
            catch (Exception ex)
            {
                XLogManager.LogError(ex);
                MessageBox.Show("连接失败");
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (SaveSetting())
                this.Close();
            else
                MessageBox.Show("保存错误");
        }

        private bool SaveSetting()
        {
            bool flag = false;

            try
            {
                ConfigHelper.SetConfig("ristnsname", this.txtRISTNSName.Text);
                ConfigHelper.SetConfig("risuser", this.txtRisDBUser.Text);
                ConfigHelper.SetConfig("rispassword", Helper.Encrypt(this.txtRisDBPassword.Text));

                ConfigHelper.SetConfig("HISProxyIP", this.txtProxyIP.Text);
                ConfigHelper.SetConfig("HISProxyPort", this.txtProxyPort.Text);

                ConfigHelper.SetConfig("ProverTime", this.nudTime.Value.ToString());

                ConfigHelper.SetConfig("DStart", this.ckDStart.Checked ? "1" : "0");
                ConfigHelper.SetConfig("LogSql", this.ckSql.Checked ? "1" : "0");
                ConfigHelper.SetConfig("DTime", this.dtpStartTime.Value.ToString("HH:mm"));


                ConfigHelper.SetConfig("StartDate", this.dtpStart.Value.ToString("yyyy-MM-dd"));
                ConfigHelper.SetConfig("LateTime", this.nudLatTime.Value.ToString());

                flag = true;
            }
            catch (Exception ex)
            {
                XLogManager.LogError(ex);
            }

            return flag;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpStartTime.Enabled = this.ckDStart.Checked;
        }
        
    }
}

Imports System.Configuration
Imports maroland.RIS.SystemInterface.Common
Imports System.Data.SqlClient
Imports System.Data.OracleClient
Imports maroland.RIS.commonUtility.globalConst
Imports System.Windows.Forms
Imports ISynthesizeIF
Imports SynthesizeIF
Imports System.Collections
Imports System.Xml


''' -----------------------------------------------------------------------------
''' Project	 : HISInterface
''' Class	 : HISInterface
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' 各大医院通用接口
''' </summary>
''' <remarks>
''' 门诊病人的几个ID号的概念
''' ----------------------------------------------------------------------------
''' patient_mzh	    门诊号，基本上是病人唯一的，需要打印在门诊报告单上
''' patient_id	    门诊病人内部号，肯定是病人唯一的，不要打印在门诊报告单上
''' patient_ckxx	门诊就诊卡卡号，仅作为查询的依据，不作为病人唯一标识，也不能打印在门诊报告单上
''' ----------------------------------------------------------------------------
''' </remarks>
''' <history>
''' 	[hezhenbin]	2013-12-17	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class HISInterface
    Implements maroland.RIS.SystemInterface.IHISInterface

    Public _daoHIS As maroland.DAO.baseDAO
    Public _daoHISType As maroland.DAO.helperCommon.DBMSType
    Public _daoRIS As maroland.DAO.oracleDAO
    Public _daoRISType As maroland.DAO.helperCommon.DBMSType
    Public _daoTJ As maroland.DAO.baseDAO
    Public _daoTJType As maroland.DAO.helperCommon.DBMSType
    Private _iSynthesize As ISynthesize
    Private _sqlServer As String

    'HISInterface_Conf.xml配置
    Private _nShowList_Out As Integer = 0
    Private _nShowList_In As Integer = 0
    Private _nShowList_Exam As Integer = 0
    Private _nChoose_Out As Integer = 1
    Private _nChoose_In As Integer = 1
    Private _nChoose_Exam As Integer = 1

    '海勤疗养院webService需要调用的webservice两次
    Private _sHQWSUrl As String = ""
    Private _sHQWSClassName As String = ""
    Private _sHQWSPassword As String = ""


#Region " public constructor for application context "

    Public Sub New()

        Try
            ' // create HIS database dao object...
            Dim dbTypeHIS As maroland.DAO.helperCommon.DBMSType = CInt(Common.getAppSetting("HISDBType", maroland.DAO.helperCommon.DBMSType.oracle9i))
            Dim dbNameHIS As String = Common.getAppSetting("HISDBName", "ris")
            Dim userNameHIS As String = Common.getAppSetting("HISDBUser", "ris")
            Dim passwordHIS As String = Common.getAppSetting("HISDBPassword", "maroland")
            Dim serverHIS As String = Common.getAppSetting("HISDBServer", "192.168.1.85")

            _daoHISType = dbTypeHIS
            _daoHIS = maroland.DAO.daoFactory.Instance.createDAO(dbTypeHIS)
            _daoHIS.connString = _daoHIS.buildConnString(dbTypeHIS, serverHIS, dbNameHIS, userNameHIS, passwordHIS)

            '体检
            Dim TJdbType As maroland.DAO.helperCommon.DBMSType = CInt(Common.getAppSetting("TJDBType", maroland.DAO.helperCommon.DBMSType.mssql))
            Dim TJdbName As String = Common.getAppSetting("TJDBName", "ris")
            Dim TJuserName As String = Common.getAppSetting("TJDBUser", "ris")
            Dim TJpassword As String = Common.getAppSetting("TJDBPassword", "maroland")
            Dim TJserver As String = Common.getAppSetting("TJDBServer", "192.168.1.85")

            _daoTJType = TJdbType
            _daoTJ = maroland.DAO.daoFactory.Instance.createDAO(TJdbType)
            _daoTJ.connString = _daoTJ.buildConnString(TJdbType, TJserver, TJdbName, TJuserName, TJpassword)

            Dim dbTypeRis As maroland.DAO.helperCommon.DBMSType = CInt(Common.getAppSetting("RISDBType", maroland.DAO.helperCommon.DBMSType.oracle10g))
            Dim dbNameRis As String = Common.getAppSetting("RISDBName", "ris")
            Dim userNameRis As String = Common.getAppSetting("RISDBUser", "ris")
            Dim passwordRis As String = Common.getAppSetting("RISDBPassword", "maroland")
            Dim serverRis As String = Common.getAppSetting("RISDBServer", "192.168.1.85")

            _daoRISType = dbTypeRis
            _daoRIS = maroland.DAO.daoFactory.Instance.createDAO(dbTypeRis)
            _daoRIS.connString = _daoHIS.buildConnString(dbTypeRis, serverRis, dbNameRis, userNameRis, passwordRis)
           
            _iSynthesize = New Synthesize
            _iSynthesize.init("HisIFIterface\\IFConfig\\IFInfo", "HisIFIterface\\IFConfig")

            Dim strConf As String = String.Format(System.Windows.Forms.Application.StartupPath + "\\HISInterface_Conf.xml")

            If System.IO.File.Exists(strConf) Then
                Dim doc As New XmlDocument
                doc.Load(strConf)
                Dim ele As XmlElement = doc.DocumentElement

                Dim node As XmlNode
                For Each node In ele.SelectNodes("Unity")
                    If "ShowList_Out" = node.Attributes("ColName").Value.ToString().Trim Then
                        _nShowList_Out = Int32.Parse(node.Attributes("ColSwitch").Value.ToString().Trim)
                    ElseIf "ShowList_In" = node.Attributes("ColName").Value.ToString().Trim Then
                        _nShowList_In = Int32.Parse(node.Attributes("ColSwitch").Value.ToString().Trim)
                    ElseIf "ShowList_Exam" = node.Attributes("ColName").Value.ToString().Trim Then
                        _nShowList_Exam = Int32.Parse(node.Attributes("ColSwitch").Value.ToString().Trim)
                    ElseIf "Choose_Out" = node.Attributes("ColName").Value.ToString().Trim Then
                        _nChoose_Out = Int32.Parse(node.Attributes("ColSwitch").Value.ToString().Trim)
                    ElseIf "Choose_In" = node.Attributes("ColName").Value.ToString().Trim Then
                        _nChoose_In = Int32.Parse(node.Attributes("ColSwitch").Value.ToString().Trim)
                    ElseIf "Choose_Exam" = node.Attributes("ColName").Value.ToString().Trim Then
                        _nChoose_Exam = Int32.Parse(node.Attributes("ColSwitch").Value.ToString().Trim)
                    ElseIf "HQWSUrl" = node.Attributes("ColName").Value.ToString().Trim Then
                        _sHQWSUrl = node.Attributes("ColSwitch").Value.ToString().Trim
                    ElseIf "HQWSClassName" = node.Attributes("ColName").Value.ToString().Trim Then
                        _sHQWSClassName = node.Attributes("ColSwitch").Value.ToString().Trim
                    ElseIf "HQWSPassword" = node.Attributes("ColName").Value.ToString().Trim Then
                        _sHQWSPassword = node.Attributes("ColSwitch").Value.ToString().Trim
                    End If
                Next
            End If

        Catch ex As Exception
            Common.logger.logError("初始化HIS接口对象时发生错误", ex)
        End Try

    End Sub

#End Region

#Region " implementation functions "
    Public Function callExtendFunction(ByVal functionID As String, ByVal ParamArray pList As Object()) As Boolean Implements maroland.RIS.SystemInterface.IHISInterface.callExtendFunction
        If "SetHisDbConn" = functionID Then
            Try
                Dim dic As Hashtable = pList.GetValue(0)

                If True = dic.ContainsKey("RISType") Then
                    _daoRISType = CInt(dic("RISType"))
                End If

                If True = dic.ContainsKey("serverRis") And True = dic.ContainsKey("dbNameRis") And True = dic.ContainsKey("userNameRis") And True = dic.ContainsKey("passwordRis") Then
                    _daoRIS = maroland.DAO.daoFactory.Instance.createDAO(_daoRISType)
                    _daoRIS.connString = _daoHIS.buildConnString(_daoRISType, dic("serverRis"), dic("dbNameRis"), dic("userNameRis"), dic("passwordRis"))
                ElseIf True = dic.ContainsKey("RIS") Then
                    _daoRIS.connString = dic("RIS")
                End If

                If True = dic.ContainsKey("HISType") Then
                    _daoHISType = CInt(dic("HISType"))
                End If
                If True = dic.ContainsKey("serverHIS") And True = dic.ContainsKey("dbNameHIS") And True = dic.ContainsKey("userNameHIS") And True = dic.ContainsKey("passwordHIS") Then
                    _daoHIS = maroland.DAO.daoFactory.Instance.createDAO(_daoHISType)
                    _daoHIS.connString = _daoHIS.buildConnString(_daoHISType, dic("serverHIS"), dic("dbNameHIS"), dic("userNameHIS"), dic("passwordHIS"))
                ElseIf True = dic.ContainsKey("HIS") Then
                    _daoHIS.connString = dic("HIS")
                End If

                If True = dic.ContainsKey("TJType") Then
                    _daoTJType = CInt(dic("TJType"))
                End If
                If True = dic.ContainsKey("TJserver") And True = dic.ContainsKey("TJdbName") And True = dic.ContainsKey("TJuserName") And True = dic.ContainsKey("TJpassword") Then
                    _daoTJ = maroland.DAO.daoFactory.Instance.createDAO(_daoTJType)
                    _daoTJ.connString = _daoTJ.buildConnString(_daoTJType, dic("TJserver"), dic("TJdbName"), dic("TJuserName"), dic("TJpassword"))
                ElseIf True = dic.ContainsKey("TJ") Then
                    _daoTJ.connString = dic("TJ")
                End If
            Catch ex As Exception
                Common.logger.logError("修改HIS接口连接字符串失败", ex)
                Return False
            End Try
        ElseIf "GetSampleInfo" = functionID Then
            Dim OrderID As String = pList.GetValue(0)

            Dim dicSampleInfo As New Hashtable
            Dim dtSampleInfo As New DataTable
            dicSampleInfo.Add("OrderID", OrderID.Trim())
            Try
                _iSynthesize.IFAchieve("GM电子申请单.getOutSampleInfo", _daoHIS.connString, dicSampleInfo, dtSampleInfo, _daoHISType)
                If dtSampleInfo.Rows.Count > 0 Then
                    pList.SetValue(dtSampleInfo, 0)
                    Return True
                End If
            Catch
            End Try
            Try
                _iSynthesize.IFAchieve("GM电子申请单.getInSampleInfo", _daoHIS.connString, dicSampleInfo, dtSampleInfo, _daoHISType)
                If dtSampleInfo.Rows.Count > 0 Then
                    pList.SetValue(dtSampleInfo, 0)
                    Return True
                End If
            Catch
            End Try
            Try
                _iSynthesize.IFAchieve("GM电子申请单.getPhisicalSampleInfo", _daoTJ.connString, dicSampleInfo, dtSampleInfo, _daoTJType)
                If dtSampleInfo.Rows.Count > 0 Then
                    pList.SetValue(dtSampleInfo, 0)
                    Return True
                End If
            Catch
            End Try
        ElseIf "GetInfoByOrderID" = functionID Then
            Dim OrderID As String = pList.GetValue(0)

            Dim dicInfoByOrderID As New Hashtable
            Dim dtInfoByOrderID As New DataTable
            dicInfoByOrderID.Add("OrderID", OrderID.Trim())
            dicInfoByOrderID.Add("patType", "O")
            dicInfoByOrderID.Add("modality", "GM")
            Try
                _iSynthesize.IFAchieve("GM电子申请单.getOutInfoByOrderID", _daoHIS.connString, dicInfoByOrderID, dtInfoByOrderID, _daoHISType)
                If dtInfoByOrderID.Rows.Count > 0 Then
                    pList.SetValue(dtInfoByOrderID, 0)
                    Return True
                End If
            Catch
            End Try
            Try
                dicInfoByOrderID("patType") = "I"
                _iSynthesize.IFAchieve("GM电子申请单.getInInfoByOrderID", _daoHIS.connString, dicInfoByOrderID, dtInfoByOrderID, _daoHISType)
                If dtInfoByOrderID.Rows.Count > 0 Then
                    pList.SetValue(dtInfoByOrderID, 0)
                    Return True
                End If
            Catch
            End Try
            Try
                dicInfoByOrderID("patType") = "P"
                _iSynthesize.IFAchieve("GM电子申请单.getExamInfoByOrderID", _daoTJ.connString, dicInfoByOrderID, dtInfoByOrderID, _daoTJType)
                If dtInfoByOrderID.Rows.Count > 0 Then
                    pList.SetValue(dtInfoByOrderID, 0)
                    Return True
                End If
            Catch
            End Try
        ElseIf "checkApplyList" = functionID Then
            Dim strBeginTime As String = pList.GetValue(0)
            Dim strEndTime As String = pList.GetValue(1)
            Dim strExamType As String = pList.GetValue(2)
            Dim dicCheckApplyList As New Hashtable
            dicCheckApplyList.Add("BeginTime", strBeginTime)
            dicCheckApplyList.Add("EndTime", strEndTime)
            dicCheckApplyList.Add("ExamType", strExamType)
            dicCheckApplyList.Add("modality", "GM")
            Dim dtCheckApplyListOut As New DataTable
            Dim dtCheckApplyListIn As New DataTable
            Dim dtCheckApplyListExam As New DataTable

            Try
                '门诊
                _iSynthesize.IFAchieve("GM电子申请单.checkApplyListOut", _daoHIS.connString, dicCheckApplyList, dtCheckApplyListOut, _daoHISType)
            Catch
            End Try
            Try
                '住院
                _iSynthesize.IFAchieve("GM电子申请单.checkApplyListIn", _daoHIS.connString, dicCheckApplyList, dtCheckApplyListIn, _daoHISType)
            Catch
            End Try
            Try
                '体检
                _iSynthesize.IFAchieve("GM电子申请单.checkApplyListExam", _daoTJ.connString, dicCheckApplyList, dtCheckApplyListExam, _daoTJType)
            Catch
            End Try

            Dim col As DataColumn
            If dtCheckApplyListIn.Rows.Count > 0 Then
                Dim outCount As Int32 = dtCheckApplyListIn.Rows.Count
                Dim drList As DataRow
                For Each drList In dtCheckApplyListOut.Rows
                    dtCheckApplyListIn.Rows.Add(dtCheckApplyListIn.NewRow())
                    For Each col In dtCheckApplyListIn.Columns
                        If True = dtCheckApplyListOut.Columns.Contains(col.ColumnName) Then
                            dtCheckApplyListIn.Rows(outCount)(col.ColumnName) = drList(col.ColumnName)
                        End If
                    Next
                    outCount = outCount + 1
                Next

                For Each drList In dtCheckApplyListExam.Rows
                    dtCheckApplyListIn.Rows.Add(dtCheckApplyListIn.NewRow())
                    For Each col In dtCheckApplyListIn.Columns
                        If True = dtCheckApplyListExam.Columns.Contains(col.ColumnName) Then
                            dtCheckApplyListIn.Rows(outCount)(col.ColumnName) = drList(col.ColumnName)
                        End If
                    Next
                    outCount = outCount + 1
                Next
                pList.SetValue(dtCheckApplyListIn, 0)
                Return True
            End If

            If dtCheckApplyListOut.Rows.Count > 0 Then
                Dim outCount As Int32 = dtCheckApplyListOut.Rows.Count
                Dim drList As DataRow
                For Each drList In dtCheckApplyListExam.Rows
                    dtCheckApplyListOut.Rows.Add(dtCheckApplyListOut.NewRow())
                    For Each col In dtCheckApplyListOut.Columns
                        If True = dtCheckApplyListExam.Columns.Contains(col.ColumnName) Then
                            dtCheckApplyListOut.Rows(outCount)(col.ColumnName) = drList(col.ColumnName)
                        End If
                    Next
                    outCount = outCount + 1
                Next
                pList.SetValue(dtCheckApplyListOut, 0)
                Return True
            End If
            pList.SetValue(dtCheckApplyListExam, 0)
        End If
        Return True
    End Function
    Public Function getExtendFunctionList() As Hashtable Implements maroland.RIS.SystemInterface.IHISInterface.getExtendFunctionList
        Return Nothing
    End Function

    Public Function preRISOrderDeleted(ByVal orderSeq As String) As Boolean Implements maroland.RIS.SystemInterface.IHISInterface.preRISOrderDeleted
        Try

            Dim dtRis As New DataTable
            dtRis = _daoRIS.executeDataTable(String.Format("select his_id, Modality, PatType from t_order where orderseq='{0}'", orderSeq))
            If dtRis Is Nothing OrElse dtRis.Rows.Count = 0 Then
                Return False
            End If
            Dim dt As New DataTable
            Dim dic As New Hashtable
            dic.Add("his_id", dtRis.Rows(0)("HIS_ID").ToString.Trim())
            dic.Add("patType", dtRis.Rows(0)("PatType").ToString.Trim())
            dic.Add("modality", dtRis.Rows(0)("Modality").ToString.Trim())
            Common.logger.logError("删除申请单" + dtRis.Rows(0)("HIS_ID").ToString.Trim() + "：开始")

            Select Case dtRis.Rows(0)("PatType").ToString.Trim()
                Case Common.g_c_Patient_Type_Code_Outpatient, _
                     Common.g_c_Patient_Type_Code_Emergency, _
                     Common.g_c_Patient_Type_Code_ReExamPatient
                    _iSynthesize.IFAchieve("IEIS电子单通费.preRISOrderDeletedOut", _daoHIS.connString, dic, dt, _daoHISType)
                Case Common.g_c_Patient_Type_Code_Inpatient, _
                     Common.g_c_Patient_Type_Code_InpatientEmergency
                    _iSynthesize.IFAchieve("IEIS电子单通费.preRISOrderDeletedIn", _daoHIS.connString, dic, dt, _daoHISType)
                Case Common.g_c_Patient_Type_Code_PhisicalExam
                    _iSynthesize.IFAchieve("IEIS电子单通费.preRISOrderDeletedPhysical", _daoTJ.connString, dic, dt, _daoTJType)
            End Select
            Common.logger.logError("删除申请单" + dtRis.Rows(0)("HIS_ID").ToString.Trim() + "：结束")
        Catch ex As Exception
            Common.logger.logError("调用HIS计费失败", ex)
            Return False
        End Try
        Return True
    End Function

    Public Function postRISOrderDeleted(ByVal orderSeq As String) As Boolean Implements maroland.RIS.SystemInterface.IHISInterface.postRISOrderDeleted
        Try
            Common.logger.logError("进入方法postRISOrderDeleted")
            Dim strInfo As String = orderSeq.Split(";")(0).Trim
            If "GM" = strInfo.Trim Then
                Dim dt As New DataTable
                Dim dic As New Hashtable
                dic.Add("OrderID", orderSeq.Split(";")(1).Trim)
                dic.Add("patType", orderSeq.Split(";")(2).Trim)
                dic.Add("modality", strInfo)

                Dim reMsg As String

                Select Case orderSeq.Split(";")(2).Trim
                    Case Common.g_c_Patient_Type_Code_Outpatient, _
                        Common.g_c_Patient_Type_Code_Emergency, _
                        Common.g_c_Patient_Type_Code_ReExamPatient
                        reMsg = _iSynthesize.IFAchieve("GM电子单通费.postRISOrderDeletedOut", _daoHIS.connString, dic, dt, _daoHISType)
                    Case Common.g_c_Patient_Type_Code_Inpatient, _
                        Common.g_c_Patient_Type_Code_InpatientEmergency
                        reMsg = _iSynthesize.IFAchieve("GM电子单通费.postRISOrderDeletedIn", _daoHIS.connString, dic, dt, _daoHISType)
                    Case Common.g_c_Patient_Type_Code_PhisicalExam
                        reMsg = _iSynthesize.IFAchieve("GM电子单通费.postRISOrderDeletedPhysical", _daoTJ.connString, dic, dt, _daoTJType)
                End Select

                If reMsg = "false" Then
                    Return False
                Else
                    Return True
                End If
            Else
                Common.logger.logError("进入方法else")
                Dim dtRis As New DataTable
                dtRis = _daoRIS.executeDataTable(String.Format("select his_id, Modality, PatType,registerid,OrderDT from t_order where orderseq='{0}'", orderSeq))

                If dtRis Is Nothing And dtRis.Rows.Count = 0 Then
                    Return False
                End If

                Dim his_id As String = dtRis.Rows(0)("HIS_ID").ToString.Trim
                If his_id = Nothing Or his_id = "" Then
                    Return False
                End If

                Dim dt As New DataTable
                Dim dic As New Hashtable

                '绍兴人民医院体检要求严格按照体检接口文档实现
                Dim bStandardInterface As Boolean = CBool(Common.getAppSetting("IsStandardInterface", "0"))
                If bStandardInterface = True Then
                    dic.Add("his_id", his_id)
                    dic.Add("Status", "0")
                    dic.Add("OperateID", dtRis.Rows(0)("REGISTERID").ToString.Trim)
                    dic.Add("OperateDT", dtRis.Rows(0)("OrderDT").ToString.Trim)
                    Common.logger.logError(String.Format("传入数据{0}，{1}，{2}，{3}", dic("his_id"), dic("Status"), dic("OperateID"), dic("OperateDT")))
                Else
                    dic.Add("his_id", his_id)
                    dic.Add("patType", dtRis.Rows(0)("PatType").ToString.Trim)
                    dic.Add("modality", dtRis.Rows(0)("Modality").ToString.Trim)
                End If


                Dim reMsg As String
                Common.logger.logError("删除申请单" + his_id + "：开始")
                Select Case dtRis.Rows(0)("PatType").ToString.Trim()
                    Case Common.g_c_Patient_Type_Code_Outpatient, _
                        Common.g_c_Patient_Type_Code_Emergency, _
                        Common.g_c_Patient_Type_Code_ReExamPatient
                        reMsg = _iSynthesize.IFAchieve("IEIS电子单通费.postRISOrderDeletedOut", _daoHIS.connString, dic, dt, _daoHISType)
                    Case Common.g_c_Patient_Type_Code_Inpatient, _
                        Common.g_c_Patient_Type_Code_InpatientEmergency
                        reMsg = _iSynthesize.IFAchieve("IEIS电子单通费.postRISOrderDeletedIn", _daoHIS.connString, dic, dt, _daoHISType)
                    Case Common.g_c_Patient_Type_Code_PhisicalExam
                        Common.logger.logError("进入方法Common.g_c_Patient_Type_Code_PhisicalExam   _daoHIS.connString" + _daoHIS.connString)
                        reMsg = _iSynthesize.IFAchieve("IEIS电子单通费.postRISOrderSavedPhysical", _daoTJ.connString, dic, dt, _daoTJType)
                        Common.logger.logError("reMsg :" + reMsg)
                End Select
                Common.logger.logError("删除申请单" + his_id + "：结束")
                If reMsg = "false" Then
                    Return False
                Else
                    Return True
                End If
            End If
        Catch ex As Exception
            Common.logger.logError("调用HIS计费失败", ex)
            Return False
        End Try
    End Function

    Public Function postRISOrderSaved(Optional ByRef risPatient As System.Data.DataSet = Nothing, Optional ByRef risOrder As System.Data.DataSet = Nothing, Optional ByRef risORMQueue As System.Data.DataSet = Nothing, Optional ByRef frmParent As Object = Nothing) As Boolean Implements maroland.RIS.SystemInterface.IHISInterface.postRISOrderSaved
        Try
            Dim i As Integer = 0
            Common.logger.logError("进入方法postRISOrderSaved")
            For i = 0 To risOrder.Tables(0).Rows.Count - 1
                Dim modality As String = risOrder.Tables(0).Rows(i)("Modality").ToString.Trim

                If "GM" = modality Then
                    Dim OrderID As String = risOrder.Tables(0).Rows(i)("OrderID").ToString.Trim
                    Dim patType As String = risOrder.Tables(0).Rows(i)("PatType").ToString.Trim
                    Dim status As String = risOrder.Tables(0).Rows(i)("Status").ToString.Trim

                    Dim dt As New DataTable
                    Dim dic As New Hashtable

                    dic.Add("OrderID", OrderID)
                    dic.Add("patType", patType)
                    dic.Add("Status", status)
                    dic.Add("modality", modality.Trim())

                    Select Case patType
                        Case Common.g_c_Patient_Type_Code_Outpatient, _
                             Common.g_c_Patient_Type_Code_Emergency, _
                             Common.g_c_Patient_Type_Code_ReExamPatient
                            _iSynthesize.IFAchieve("GM电子单通费.postRISOrderSavedOut", _daoHIS.connString, dic, dt, _daoHISType)
                        Case Common.g_c_Patient_Type_Code_Inpatient, _
                             Common.g_c_Patient_Type_Code_InpatientEmergency
                            _iSynthesize.IFAchieve("GM电子单通费.postRISOrderSavedIn", _daoHIS.connString, dic, dt, _daoHISType)
                        Case Common.g_c_Patient_Type_Code_PhisicalExam
                            _iSynthesize.IFAchieve("GM电子单通费.postRISOrderSavedPhysical", _daoTJ.connString, dic, dt, _daoTJType)
                    End Select

                Else
                    Dim his_id As String = risOrder.Tables(0).Rows(i)("HIS_ID").ToString.Trim
                    Dim patType As String = risOrder.Tables(0).Rows(i)("PatType").ToString.Trim
                    If _sHQWSUrl.Length > 0 Then
                        Return postRISOrderSavedHQ(his_id)
                    End If
                    Dim dt As New DataTable
                    Dim dic As New Hashtable

                    '绍兴人民医院体检要求严格按照体检接口文档实现
                    Dim bStandardInterface As Boolean = CBool(Common.getAppSetting("IsStandardInterface", "0"))
                    If bStandardInterface = True Then
                        Common.logger.logError("进入bStandardInterface = True")
                        dic.Add("his_id", his_id)
                        dic.Add("Status", "1")
                        dic.Add("OperateID", risOrder.Tables(0).Rows(i)("REGISTERID").ToString.Trim)
                        dic.Add("OperateDT", risOrder.Tables(0).Rows(i)("OrderDT").ToString.Trim)
                        Common.logger.logError(String.Format("传入数据{0}，{1}，{2}，{3}", dic("his_id"), dic("Status"), dic("OperateID"), dic("OperateDT")))
                    Else
                        dic.Add("his_id", his_id)
                        dic.Add("patType", patType)
                        dic.Add("modality", modality.Trim())
                    End If
                    Common.logger.logError("保存申请单，第" + i.ToString + "条记录" + his_id + "：开始")
                    Select Case patType
                        Case Common.g_c_Patient_Type_Code_Outpatient, _
                             Common.g_c_Patient_Type_Code_Emergency, _
                             Common.g_c_Patient_Type_Code_ReExamPatient
                            _iSynthesize.IFAchieve("IEIS电子单通费.postRISOrderSavedOut", _daoHIS.connString, dic, dt, _daoHISType)
                        Case Common.g_c_Patient_Type_Code_Inpatient, _
                             Common.g_c_Patient_Type_Code_InpatientEmergency
                            _iSynthesize.IFAchieve("IEIS电子单通费.postRISOrderSavedIn", _daoHIS.connString, dic, dt, _daoHISType)
                        Case Common.g_c_Patient_Type_Code_PhisicalExam
                            Common.logger.logError("进入方法Common.g_c_Patient_Type_Code_PhisicalExam   _daoHIS.connString" + _daoHIS.connString)
                            Dim retrnStr As String = _iSynthesize.IFAchieve("IEIS电子单通费.postRISOrderSavedPhysical", _daoTJ.connString, dic, dt, _daoTJType)
                            Common.logger.logError("返回值_iSynthesize：" + retrnStr)
                    End Select
                    Common.logger.logError("保存申请单，第" + i.ToString + "条记录" + his_id + "：结束")
                End If
            Next

        Catch ex As Exception
            Common.logger.logError("调用HIS计费失败", ex)
            Return False
        End Try
        ' do nothing here...
        Return True

    End Function

    Public Function preRISOrderSaved(Optional ByRef risPatient As System.Data.DataSet = Nothing, Optional ByRef risOrder As System.Data.DataSet = Nothing, Optional ByRef risORMQueue As System.Data.DataSet = Nothing, Optional ByRef frmParent As Object = Nothing) As Boolean Implements maroland.RIS.SystemInterface.IHISInterface.preRISOrderSaved
        Try
            Dim i As Integer = 0
            For i = 0 To risOrder.Tables(0).Rows.Count - 1
                Dim his_id As String = risOrder.Tables(0).Rows(i)("HIS_ID").ToString.Trim
                Dim modality As String = risOrder.Tables(0).Rows(i)("Modality").ToString.Trim
                Dim patType As String = risOrder.Tables(0).Rows(i)("PatType").ToString.Trim

                Dim dt As New DataTable
                Dim dic As New Hashtable
                dic.Add("his_id", his_id)
                dic.Add("patType", patType)
                dic.Add("modality", modality.Trim())
                Common.logger.logError("保存申请单，第" + i.ToString + "条记录" + his_id + "：开始")
                Select Case patType
                    Case Common.g_c_Patient_Type_Code_Outpatient, _
                         Common.g_c_Patient_Type_Code_Emergency, _
                         Common.g_c_Patient_Type_Code_ReExamPatient
                        _iSynthesize.IFAchieve("IEIS电子单通费.preRISOrderSavedOut", _daoHIS.connString, dic, dt, _daoHISType)
                    Case Common.g_c_Patient_Type_Code_Inpatient, _
                         Common.g_c_Patient_Type_Code_InpatientEmergency
                        _iSynthesize.IFAchieve("IEIS电子单通费.preRISOrderSavedIn", _daoHIS.connString, dic, dt, _daoHISType)
                    Case Common.g_c_Patient_Type_Code_PhisicalExam
                        _iSynthesize.IFAchieve("IEIS电子单通费.preRISOrderSavedPhysical", _daoTJ.connString, dic, dt, _daoTJType)
                End Select
                Common.logger.logError("保存申请单，第" + i.ToString + "条记录" + his_id + "：结束")
            Next

        Catch ex As Exception
            Common.logger.logError("调用HIS计费失败", ex)
            Return False
        End Try
        Return True
    End Function

    Public Function preRISOrderSaveReport(ByVal orderSeq As System.Collections.ArrayList) As Boolean Implements IHISInterface.preRISOrderSaveReport
        Return True
    End Function

    Public Function postRISOrderSaveReport(ByVal orderSeq As System.Collections.ArrayList) As Boolean Implements IHISInterface.postRISOrderSaveReport
        Try
            For Each id As String In orderSeq
                Try
                    Dim sqlris As String = "SELECT HIS_ID,modality, PatType FROM T_ORDER WHERE ORDERSEQ='" & id & "'"
                    Dim dtris As DataTable = _daoRIS.executeDataTable(sqlris)
                    If dtris Is Nothing And dtris.Rows.Count = 0 Then Return False

                    Dim his_id As String = dtris.Rows(0)("HIS_ID").ToString.Trim
                    Dim modality As String = dtris.Rows(0)("Modality").ToString.Trim
                    Dim patType As String = dtris.Rows(0)("PatType").ToString.Trim

                    Dim dt As New DataTable
                    Dim dic As New Hashtable
                    dic.Add("his_id", his_id)
                    dic.Add("patType", patType)
                    dic.Add("modality", modality.Trim())
                    Common.logger.logError("保存报告" + his_id + "：结束")
                    Select Case patType
                        Case Common.g_c_Patient_Type_Code_Outpatient, _
                             Common.g_c_Patient_Type_Code_Emergency, _
                             Common.g_c_Patient_Type_Code_ReExamPatient
                            _iSynthesize.IFAchieve("IEIS电子单通费.postRISOrderSavedReportOut", _daoHIS.connString, dic, dt, _daoHISType)
                        Case Common.g_c_Patient_Type_Code_Inpatient, _
                             Common.g_c_Patient_Type_Code_InpatientEmergency
                            _iSynthesize.IFAchieve("IEIS电子单通费.postRISOrderSavedReportIn", _daoHIS.connString, dic, dt, _daoHISType)
                        Case Common.g_c_Patient_Type_Code_PhisicalExam
                            _iSynthesize.IFAchieve("IEIS电子单通费.postRISOrderSavedReportPhysical", _daoTJ.connString, dic, dt, _daoTJType)
                    End Select
                    Common.logger.logError("保存报告" + his_id + "：结束")
                Catch ex As Exception
                    logger.logError("保存报告通知HIS失败", ex)
                    Return False
                End Try
            Next
        Catch ex As Exception
            Common.logger.logError("保存报告通知HIS失败", ex)
            Return False
        End Try
        Return True
    End Function

    Public Function isHISOrderCanceled(ByVal hisOrderID As System.Collections.ArrayList) As Boolean Implements maroland.RIS.SystemInterface.IHISInterface.isHISOrderCanceled

        ' 查询Order是否已经被取消, 这里不用，直接返回False
        Return False

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 病人号码解析
    ''' </summary>
    ''' <param name="his_id"></param>
    ''' <param name="modality"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    Public Function formatPatientID(ByVal patientType As String, ByVal patientID As String) As String _
                    Implements maroland.RIS.SystemInterface.IHISInterface.formatPatientID
        If patientID Is Nothing Then
            Return Nothing
        End If

        If patientType.Length > 3 Then
            Dim dt As New DataTable
            Dim dic As New Hashtable
            dic.Add("patientID", patientID)
            dic.Add("patType", patientType.Replace("GM-", ""))
            _iSynthesize.IFAchieve("GM电子申请单.formatPatientID", _daoHIS.connString, dic, dt, _daoHISType)
        Else
            Dim dt As New DataTable
            Dim dic As New Hashtable
            dic.Add("patientID", patientID)
            dic.Add("patType", patientType)
            Common.logger.logError("病人号码解析" + patientID + "：开始")
            _iSynthesize.IFAchieve("IEIS电子申请单.formatPatientID", _daoHIS.connString, dic, dt, _daoHISType)

            Try
                If dt.Rows.Count > 0 Then
                    patientID = dt.Rows(0).Item("PatientID").ToString.Trim
                End If
            Catch ex As Exception
                Common.logger.logError("病人号码解析异常", ex)
            End Try

            Common.logger.logError("病人号码解析" + patientID + "：结束")
        End If
        Return patientID

    End Function

    Public Function confirmHISOrderForcely(ByVal hisOrderID As String) As Boolean Implements RIS.SystemInterface.IHISInterface.confirmHISOrderForcely

        MessageBox.Show("对不起，目前系统不支持该功能！", _
                        Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Return True

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 病人信息获取
    ''' </summary>
    Public Function getHISOrderList(ByVal patientType As String, _
                                    Optional ByVal patientID As String = Nothing, _
                                    Optional ByVal dateFrom As String = Nothing, _
                                    Optional ByVal dateTo As String = Nothing, _
                                    Optional ByVal orderType As String = "1000", _
                                    Optional ByVal modality As String = Nothing) As System.Data.DataTable _
                                    Implements maroland.RIS.SystemInterface.IHISInterface.getHISOrderList

        If patientID Is Nothing Then Return Nothing

        patientID = patientID.Replace("'", "").Trim
        Dim hoData As New DataTable

        Select Case patientType
            Case Common.g_c_Patient_Type_Code_Outpatient, _
                 Common.g_c_Patient_Type_Code_Emergency, _
                 Common.g_c_Patient_Type_Code_ReExamPatient
                hoData = Me.getOutPatientInfo(patientID, patientType, modality, orderType)
            Case Common.g_c_Patient_Type_Code_Inpatient, _
                 Common.g_c_Patient_Type_Code_InpatientEmergency
                hoData = Me.getInPatientInformation(patientID, patientType, modality, orderType)
            Case Common.g_c_Patient_Type_Code_PhisicalExam
                hoData = Me.getPhisicalExamInformation(patientID, patientType, modality, orderType)
        End Select

        Return hoData
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 查看病人收费明细
    ''' </summary>
    ''' <param name="orderSeq"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    Public Function getDetailCharge(ByVal orderSeq As System.Collections.ArrayList) As Boolean Implements IHISInterface.getDetailCharge
        For Each id As String In orderSeq
            Try
                Dim sql As String = "SELECT HIS_ID,modality, PatType FROM T_ORDER WHERE ORDERSEQ='" & id & "'"
                Dim dt As DataTable = _daoRIS.executeDataTable(sql)
                If dt Is Nothing And dt.Rows.Count = 0 Then Return False

                GetCharge(dt.Rows(0)("his_id").ToString.Trim, dt.Rows(0)("PatType").ToString.Trim, dt.Rows(0)("modality").ToString.Trim)
            Catch ex As Exception
                logger.logError("查看电子单", ex)
            End Try
        Next
        Return True
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 查看病人收费细则
    ''' </summary>
    ''' <param name="his_id"></param>
    ''' <param name="modality"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    Public Function GetCharge(ByVal his_id As String, ByVal patType As String, ByVal modality As String) As DataTable
        Dim dt As New DataTable
        Dim dicCharge As New Hashtable
        dicCharge.Add("HIS_ID", his_id)
        dicCharge.Add("patType", patType)
        dicCharge.Add("Modality", modality)
        _iSynthesize.IFAchieve("IEIS电子申请单.GetCharge", _daoHIS.connString, dicCharge, dt, _daoHISType)

        If (0 = dt.Rows.Count) Then
            Return Nothing
        End If

        Dim frm As New frmHisBilling
        frm.OpenDialog(dt)
        frm.Dispose()
    End Function


    Public Sub viewApplication(ByVal hisOrderID As String) Implements IHISInterface.viewApplication
        Try
            If hisOrderID = Nothing Then
                MessageBox.Show("该病人没有申请单信息", _
                                         Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            Common.logger.logError("查看申请单，参数：" + hisOrderID)

            Dim orderSeq As String = hisOrderID
            Dim pattype As String = String.Empty
            Dim modality As String = String.Empty
            Dim RisSQL As String = String.Format("select * from t_order o,t_patient p where p.patseq=o.patseq and orderseq='{0}' and deleted='0' ", orderSeq)
            Dim RisDT As DataTable = _daoRIS.executeDataTable(RisSQL)
            If RisDT.Rows.Count > 0 Then
                pattype = RisDT.Rows(0)("pattype").ToString()
                modality = RisDT.Rows(0)("MODALITY").ToString().Trim()
            Else
                orderSeq = getOrderSEQFromHisID(hisOrderID)
                RisSQL = String.Format("select * from t_order o,t_patient p where p.patseq=o.patseq and  orderseq='{0}' and deleted='0' ", orderSeq)
                RisDT = _daoRIS.executeDataTable(RisSQL)
                If RisDT.Rows.Count > 0 Then
                    pattype = RisDT.Rows(0)("pattype").ToString()
                    modality = RisDT.Rows(0)("MODALITY").ToString().Trim()
                End If
            End If

            If RisDT Is Nothing OrElse RisDT.Rows.Count = 0 Then
                Return
            End If

            '''查看拍摄申请单
            Dim dt As DataTable = New DataTable
            If RisDT.Rows(0)("HIS_ID") Is Nothing OrElse RisDT.Rows(0)("HIS_ID").ToString().Trim.Length = 0 Then
                dt = _daoRIS.executeDataTable(String.Format("select * from t_orderfile f where f.orderseq ='{0}' AND DELETED='0'", orderSeq))
            Else
                dt = _daoRIS.executeDataTable(String.Format("select * from t_orderfile f where f.orderseq in (select orderseq from t_order where his_id='{0}' and pattype='{1}' and deleted='0') AND DELETED='0'", RisDT.Rows(0)("HIS_ID").ToString(), pattype))
            End If

            If RisDT.Rows(0)("HIS_ID") Is Nothing OrElse RisDT.Rows(0)("HIS_ID").ToString().Trim.Length = 0 Then
                Dim frm As New frmOrderPaper
                frm.dtOrderFile = dt
                frm.dtHisInfo = Nothing
                frm.ShowDialog()
                frm.Dispose()
            Else
                If pattype = Common.g_c_Patient_Type_Code_Outpatient Or pattype = Common.g_c_Patient_Type_Code_Emergency Or pattype = Common.g_c_Patient_Type_Code_ReExamPatient Then      ''门诊电子申请单
                    Dim HisOutPatdt As DataTable
                    Dim dicCharge As New Hashtable
                    dicCharge.Add("his_id", hisOrderID)
                    dicCharge.Add("patType", pattype)
                    dicCharge.Add("modality", modality)
                    Common.logger.logError("查看门诊申请单，获取HIS数据包" + hisOrderID + "：开始")
                    _iSynthesize.IFAchieve("IEIS电子申请单.viewApplicationOut", _daoHIS.connString, dicCharge, HisOutPatdt, _daoHISType)
                    Common.logger.logError("查看门诊申请单，获取HIS数据包" + hisOrderID + "：结束")
                    If Not HisOutPatdt Is Nothing AndAlso HisOutPatdt.Rows.Count > 0 Then
                        Common.logger.logError("查看门诊申请单，获取HIS数据包" + HisOutPatdt.Rows.Count.ToString + "：条")
                        Dim frm As New frmHisOrderPaper
                        frm.dtOrderFile = dt
                        frm.dtHisInfo = HisOutPatdt
                        frm._hi = Me
                        frm._orderSeqHis = RisDT.Rows(0)("orderseq").ToString().Trim
                        frm.ShowDialog()
                        frm.Dispose()
                    Else
                        If Not HisOutPatdt Is Nothing Then
                            Common.logger.logError("0000查看门诊申请单，获取HIS数据包" + HisOutPatdt.Rows.Count.ToString + "：条")
                        End If
                        Dim frmMsg As New frmMessageBox
                        frmMsg.init("HIS申请单中无数据，请联系HIS厂家")
                        frmMsg.ShowDialog()
                        frmMsg.Dispose()
                    End If
                ElseIf pattype = Common.g_c_Patient_Type_Code_Inpatient Or pattype = Common.g_c_Patient_Type_Code_InpatientEmergency Then   '’住院电子申请单
                    Dim HisInPatdt As DataTable
                    Dim dicCharge As New Hashtable
                    dicCharge.Add("his_id", hisOrderID)
                    dicCharge.Add("patType", pattype)
                    dicCharge.Add("modality", modality)
                    Common.logger.logError("查看住院申请单，获取HIS数据包" + hisOrderID + "：开始")
                    _iSynthesize.IFAchieve("IEIS电子申请单.viewApplicationIn", _daoHIS.connString, dicCharge, HisInPatdt, _daoHISType)
                    Common.logger.logError("查看住院申请单，获取HIS数据包" + hisOrderID + "：结束")
                    If Not HisInPatdt Is Nothing AndAlso HisInPatdt.Rows.Count > 0 Then
                        Common.logger.logError("查看住院申请单，获取HIS数据包" + HisInPatdt.Rows.Count.ToString + "：条")
                        Dim Hisfrm As New frmOrderPaper
                        Hisfrm.dtOrderFile = dt
                        Hisfrm.dtHisInfo = HisInPatdt
                        Hisfrm.ShowDialog()
                        Hisfrm.Dispose()
                    Else
                        If Not HisInPatdt Is Nothing Then
                            Common.logger.logError("0000查看门诊申请单，获取HIS数据包" + HisInPatdt.Rows.Count.ToString + "：条")
                        End If
                        Dim frmMsg As New frmMessageBox
                        frmMsg.init("HIS申请单中无数据，请联系HIS厂家")
                        frmMsg.ShowDialog()
                        frmMsg.Dispose()
                    End If
                End If
            End If
        Catch ex As Exception
            LogManager.Logger.logError("查看申请单失败：", ex)
        End Try
    End Sub
#End Region

#Region " internal functions "
    ''' -----------------------------------------------------------------------------
    Private Function getInPatientInformation(ByVal patientID As String, ByVal patType As String, Optional ByVal modality As String = "", Optional ByVal examType As String = "") As DataTable
        Dim dt As New DataTable
        Try
            If "GM" = modality Then
                Dim dic As New Hashtable
                dic.Add("patientID", patientID)
                dic.Add("patType", patType)
                dic.Add("modality", modality.Trim())
                dic.Add("examtype", examType.Trim())
                _iSynthesize.IFAchieve("GM电子申请单.getInHisOrder", _daoHIS.connString, dic, dt, _daoHISType)
                If (dt Is Nothing) OrElse 0 = dt.Rows.Count Then
                    _iSynthesize.IFAchieve("GM电子申请单.getInPatientInformation", _daoHIS.connString, dic, dt, _daoHISType)
                    Return dt
                End If
            Else
                Dim dic As New Hashtable
                dic.Add("patientID", patientID)
                dic.Add("patType", patType)
                dic.Add("modality", modality.Trim())
                '海勤疗养院特殊处理下
                If _sHQWSUrl.Length > 0 Then
                    Return GetHQOrderList(patientID, modality.Trim(), patType)
                End If
                Common.logger.logError("获取住院电子单，获取HIS数据包" + patientID + "：开始")
                _iSynthesize.IFAchieve("IEIS电子申请单.getInHisOrder", _daoHIS.connString, dic, dt, _daoHISType)
                Common.logger.logError("获取住院电子单，获取HIS数据包" + patientID + "：结束")



                If (dt Is Nothing) OrElse 0 = dt.Rows.Count Then
                    '住院手工单
                    Common.logger.logError("获取住院手工单，获取HIS数据包" + patientID + "：开始")
                    _iSynthesize.IFAchieve("IEIS电子申请单.getInPatientInformation", _daoHIS.connString, dic, dt, _daoHISType)
                    Common.logger.logError("获取住院手工单，获取HIS数据包" + patientID + "：结束")
                    Return dt
                End If

                If dt.Rows.Count > 1 Then
                    If 0 = _nShowList_In Then
                        Dim frm As New frmPatientList
                        frm._nChoose = _nChoose_In
                        dt = frm.getOrderList(dt, patType, Me)
                        frm.Dispose()
                    End If
                Else
                    dt = dtSplit(dt.Copy())
                End If
                GetExamItemIDFormHis(dt, "EXAMITEMID")
                End If

        Catch ex As Exception
            logger.logError("住院电子单", ex)
        End Try

        Return dt
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 根据给定的门诊号, 查找对应的门诊病人基本信息
    ''' </summary>
    ''' <param name="patientID">门诊号，对应字段名为PATIENT_MZH</param>
    ''' <param name="patType">病人类型</param>
    ''' <param name="modality">检查类型</param>
    ''' <returns>包含门诊病人基本信息的Dataset对象</returns>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Private Function getOutPatientInfo(ByVal patientID As String, ByVal patType As String, ByVal modality As String, ByVal examType As String) As DataTable
        Dim dt As New DataTable
        Try
            If "GM" = modality Then
                Dim dic As New Hashtable
                dic.Add("patientID", patientID)
                dic.Add("patType", patType)
                dic.Add("modality", modality.Trim())
                dic.Add("examtype", examType.Trim())
                _iSynthesize.IFAchieve("GM电子申请单.getOutHisOrder", _daoHIS.connString, dic, dt, _daoHISType)

                If (dt Is Nothing) OrElse 0 = dt.Rows.Count Then
                    _iSynthesize.IFAchieve("GM电子申请单.getOutPatientInfo", _daoHIS.connString, dic, dt, _daoHISType)
                    Return dt
                End If
            Else
                Dim dic As New Hashtable
                dic.Add("patientID", patientID)
                dic.Add("patType", patType)
                dic.Add("modality", modality.Trim())
                If _sHQWSUrl.Length > 0 Then
                    Return GetHQOrderList(patientID, modality, patType)
                End If

                Common.logger.logError("获取门诊电子单，获取HIS数据包" + patientID + "：开始")
                _iSynthesize.IFAchieve("IEIS电子申请单.getOutHisOrder", _daoHIS.connString, dic, dt, _daoHISType)
                Common.logger.logError("获取门诊电子单，获取HIS数据包" + patientID + "：结束")

                If (dt Is Nothing) OrElse 0 = dt.Rows.Count Then
                    '门诊手工单
                    Common.logger.logError("获取门诊手工单，获取HIS数据包" + patientID + "：开始")
                    _iSynthesize.IFAchieve("IEIS电子申请单.getOutPatientInfo", _daoHIS.connString, dic, dt, _daoHISType)
                    Common.logger.logError("获取门诊手工单，获取HIS数据包" + patientID + "：结束")
                    Return dt
                End If

                If dt.Rows.Count > 1 Then
                    If 0 = _nShowList_Out Then
                        Dim frm As New frmPatientList
                        frm._nChoose = _nChoose_Out
                        dt = frm.getOrderList(dt, patType, Me)
                        If Not dt Is Nothing Then
                            Common.logger.logError("00-获取门诊电子单，dt.count=" + dt.Rows.Count.ToString)
                        End If
                        frm.Dispose()
                    End If
                Else
                    dt = dtSplit(dt.Copy())
                End If

                GetExamItemIDFormHis(dt, "EXAMITEMID")
                If Not dt Is Nothing Then
                    Dim sLog As String = ""
                    Dim i As Integer = 0
                    For i = 0 To dt.Rows.Count - 1
                        sLog = sLog + dt.Rows(i).Item("his_id") + "&&" + dt.Rows(i).Item("EXAMITEMID") + "&&" + dt.Rows(i).Item("EXAMITEM") + ";"
                    Next
                    Common.logger.logError("01-获取门诊电子单，sLog=" + sLog)
                End If
            End If
        Catch ex As Exception
            logger.logError("门诊电子单", ex)
        End Try

        Return dt
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 根据给定的体检号, 查找对应的体检病人基本信息
    ''' </summary>
    ''' <param name="patientID">体检号</param>
    ''' <param name="patType">病人类型</param>
    ''' <param name="modality">检查类型</param>
    ''' <returns>包含体检病人基本信息的Dataset对象</returns>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Private Function getPhisicalExamInformation(ByVal patientID As String, ByVal patType As String, ByVal modality As String, ByVal examType As String) As DataTable
        Dim dt As New DataTable

        Try
            If "GM" = modality Then
                Dim dic As New Hashtable
                dic.Add("patientID", patientID)
                dic.Add("patType", patType)
                dic.Add("modality", modality.Trim())
                dic.Add("examtype", examType.Trim())
                _iSynthesize.IFAchieve("GM电子申请单.GetPhisicalFSPatient", _daoTJ.connString, dic, dt, _daoTJType)
                '字符串解析 test
                If (dt Is Nothing) OrElse 0 = dt.Rows.Count Then
                    _iSynthesize.IFAchieve("GM电子申请单.getPhisicalExamInformation", _daoTJ.connString, dic, dt, _daoTJType)
                    Return dt
                End If
            Else
                Dim dic As New Hashtable
                dic.Add("patientID", patientID)
                dic.Add("patType", patType)
                dic.Add("modality", modality.Trim())
                Common.logger.logError("获取体检电子单，获取HIS数据包" + patientID + "：开始")
                Dim sResult As String = _iSynthesize.IFAchieve("IEIS电子申请单.GetPhisicalFSPatient", _daoTJ.connString, dic, dt, _daoTJType)
                Common.logger.logError("获取体检电子单，获取HIS数据包" + patientID + "：结束" + sResult)

                If (dt Is Nothing) OrElse 0 = dt.Rows.Count Then
                    '体检手工单
                    Common.logger.logError("获取体检手工单，获取HIS数据包" + patientID + "：开始")
                    _iSynthesize.IFAchieve("IEIS电子申请单.getPhisicalExamInformation", _daoTJ.connString, dic, dt, _daoTJType)
                    Common.logger.logError("获取体检手工单，获取HIS数据包" + patientID + "：结束")
                    Return dt
                End If

                If dt.Rows.Count > 1 Then
                    If 0 = _nShowList_Exam Then
                        Dim frm As New frmPatientList
                        frm._nChoose = _nChoose_Exam
                        dt = frm.getOrderList(dt, patType, Me)
                        frm.Dispose()
                    End If
                Else
                    dt = dtSplit(dt.Copy())
                End If
                GetExamItemIDFormHis(dt, "EXAMITEMID")
            End If
        Catch ex As Exception
            logger.logError("体检电子单", ex)
        End Try

        Return dt
    End Function

    Private Function getOrderSEQFromHisID(ByVal his_id As String) As String
        Try
            Dim sql As String = String.Format("select * from t_order where his_id='{0}' and deleted='0'", his_id)
            Dim RisDT As DataTable = _daoRIS.executeDataTable(sql)
            If RisDT.Rows.Count > 0 Then
                Return RisDT.Rows(0)("orderseq").ToString()
            End If
            Return Nothing
        Catch ex As Exception
            LogManager.Logger.logError("查看申请单失败：his_id:" + his_id, ex)
        End Try
    End Function
#End Region

#Region "数据表解析"
    Private Function GetExamItemIDFormHis(ByRef dt As DataTable, ByVal colName As String)
        Dim i As Int32 = 0
        Dim dtExamItem As DataTable
        For i = 0 To dt.Rows.Count - 1
            dtExamItem = _daoRIS.executeDataTable(String.Format("select * from t_his_examitemlink ,t_examitem where t_his_examitemlink.his_examitemid='{0}' and t_examitem.examitemid=t_his_examitemlink.ris_examitemid and t_examitem.deleted=0", dt.Rows(i)(colName)))
            If (dtExamItem.Rows.Count > 0) Then
                LogManager.Logger.logError("GetExamItemIDFormHis id=" + dtExamItem.Rows(0)("RIS_EXAMITEMID"))
                dt.Rows(i)(colName) = dtExamItem.Rows(0)("RIS_EXAMITEMID")
            End If
        Next
    End Function

    Private Function GetExamItemIDFormHisNew(ByRef dt As DataTable, ByVal colName As String)
        Dim i As Int32 = 0
        Dim dtExamItem As DataTable
        Dim sHisExamItemIDs As String
        Dim sHisExamItemIDArr() As String
        Dim iIndex As Integer = 0
        Dim sRisExamItemIDs As String
        For i = 0 To dt.Rows.Count - 1
            sHisExamItemIDs = String.Empty
            sRisExamItemIDs = String.Empty
            sHisExamItemIDs = dt.Rows(i)(colName)
            sHisExamItemIDArr = sHisExamItemIDs.Split(";")
            If Not sHisExamItemIDArr Is Nothing AndAlso sHisExamItemIDArr.Length > 0 Then
                sHisExamItemIDs = ""
                For iIndex = 0 To sHisExamItemIDArr.Length - 1 Step 1
                    sHisExamItemIDs = String.Format("'{0}',", sHisExamItemIDArr(iIndex)) + sHisExamItemIDs
                Next
                If sHisExamItemIDs.EndsWith(",") Then
                    sHisExamItemIDs = sHisExamItemIDs.Substring(0, sHisExamItemIDs.Length - 1)
                End If
                sHisExamItemIDs = String.Format("({0})", sHisExamItemIDs)
            End If
            dtExamItem = _daoRIS.executeDataTable(String.Format("select * from t_his_examitemlink ,t_examitem where t_his_examitemlink.his_examitemid in {0} and t_examitem.examitemid=t_his_examitemlink.ris_examitemid and t_examitem.deleted=0", sHisExamItemIDs))

            If (dtExamItem.Rows.Count > 0) Then
                For iIndex = 0 To dtExamItem.Rows.Count - 1 Step 1
                    sRisExamItemIDs = String.Format("{0};{1}", dtExamItem.Rows(iIndex)("RIS_EXAMITEMID"), sRisExamItemIDs)
                Next
                If sRisExamItemIDs.EndsWith(";") Then
                    sRisExamItemIDs = sRisExamItemIDs.Substring(0, sRisExamItemIDs.Length - 1)
                End If
                dt.Rows(i)(colName) = sRisExamItemIDs
            End If
        Next
    End Function

    Private Function examOj(ByRef dt As DataTable)
        Dim flag As Boolean = True
        Dim row As DataRow
        Dim iNum As Int32 = 0
        'Dim allNum As Int32 = dt.Rows.Count - 1
        For iNum = 0 To dt.Rows.Count - 1
            Dim jNum As Int32 = 0
            For jNum = iNum + 1 To dt.Rows.Count - 1
                If jNum <= dt.Rows.Count - 1 Then
                    If dt.Rows(iNum)("EXAMITEMID") = dt.Rows(jNum)("EXAMITEMID") Then
                        dt.Rows.RemoveAt(jNum)
                        iNum = iNum - 1
                        jNum = jNum - 1
                        flag = False
                    End If
                End If
            Next
        Next
        If False = flag Then
            Dim frm As New frmMessageBox
            frm.init("有重复检查项目")
            frm.ShowDialog()
        End If
    End Function

    Private Function dtSplit(ByRef dt As DataTable) As DataTable
        Dim subDt As DataTable = dt.Clone()
        Dim row As DataRow = dt.Rows(0)
        Dim rowNum As Int32 = -1

        For Each row In dt.Rows
            subDt.Rows.Add(subDt.NewRow())
            rowNum = rowNum + 1

            Dim subColNum As Int32
            For subColNum = 0 To row.ItemArray.Length - 1
                subDt.Rows(rowNum)(subColNum) = row(subColNum)
            Next

            Dim sExamitemid As Array = CStr(row("EXAMITEMID")).Replace(",", ";").Replace("*", ";").Replace("，", ";").Split(";")

            If sExamitemid.Length > 1 Then
                subDt.Rows(rowNum)("EXAMITEMID") = sExamitemid(0)
                'subDt.Rows(rowNum)("EXAMITEM") = sExamitem(0)
                Dim i As Int32 = 0
                For i = 1 To sExamitemid.Length - 1
                    subDt.Rows.Add(subDt.NewRow())
                    rowNum = rowNum + 1
                    For subColNum = 0 To row.ItemArray.Length - 1
                        subDt.Rows(rowNum)(subColNum) = row(subColNum)
                    Next

                    subDt.Rows(rowNum)("EXAMITEMID") = sExamitemid(i)
                    'subDt.Rows(rowNum)("EXAMITEM") = sExamitem(i)
                Next
            End If
            'End If
        Next
        'examOj(subDt)
        Return subDt
    End Function
#End Region

    Public Function ExtendPreserve(ByRef infoString As String, ByVal sType As String, Optional ByRef dtInfo As System.Data.DataTable = Nothing) As Boolean Implements IHISInterface.ExtendPreserve

    End Function

    Public Function GetCardType() As String(,) Implements IHISInterface.GetCardType

    End Function

    Public Function GetHISTCInfo(ByVal sModality As String, Optional ByRef sTCID As String = "") As Boolean Implements IHISInterface.GetHISTCInfo

    End Function

    Public Function ReadCard(ByVal cardType As String) As String Implements IHISInterface.ReadCard

    End Function

#Region "海勤疗养院 webservice 调用"
    Private Function GetHQOrderList(ByVal sPatientID As String, ByVal sModality As String, ByVal sPatType As String) As System.Data.DataTable
        Try
            Dim tempWS As SynthesizeIF.WebServices.WebServ = New SynthesizeIF.WebServices.WebServ
            Dim retDataTable As System.Data.DataTable
            Dim sHisIDXml As String
            Dim para() As Object
            Dim sHisOrderXml As String
            If sPatType = "O" Then
                tempWS.GetWebServInf(_sHQWSUrl, _sHQWSClassName, "getOrderByBarcode")
                para = New Object() {_sHQWSPassword, sPatientID}
                sHisOrderXml = tempWS.GetData(para)
                If sHisOrderXml Is Nothing OrElse sHisOrderXml = "" Then
                    Return Nothing
                End If
                LogManager.Logger.logError("getOrderByBarcode--" + sHisOrderXml)
                retDataTable = BuildHQDataTable()
                FillOrderTable(sHisOrderXml, sPatType, sModality, retDataTable)
            Else
                tempWS.GetWebServInf(_sHQWSUrl, _sHQWSClassName, "getOrdersByPatientid")
                para = New Object() {_sHQWSPassword, sPatientID}
                sHisIDXml = tempWS.GetData(para)
                If sHisIDXml Is Nothing OrElse sHisIDXml = "" Then
                    Return Nothing
                End If
                LogManager.Logger.logError("getOrdersByPatientid--" + sHisIDXml)
                Dim sHisIDs() As String = PasreHQHisIDs(sHisIDXml)
                tempWS.GetWebServInf(_sHQWSUrl, _sHQWSClassName, "getOrderByBarcode")
                retDataTable = BuildHQDataTable()
                Dim iIndex As Integer = 0
                For iIndex = 0 To sHisIDs.Length - 1 Step 1
                    para = New Object() {_sHQWSPassword, sHisIDs(iIndex)}
                    sHisOrderXml = tempWS.GetData(para)
                    LogManager.Logger.logError("getOrderByBarcode--" + sHisOrderXml)
                    FillOrderTable(sHisOrderXml, sPatType, sModality, retDataTable)
                Next
            End If
            GetExamItemIDFormHisNew(retDataTable, "EXAMITEMID")
            Return retDataTable

        Catch ex As Exception
            LogManager.Logger.logError(String.Format("GetHQOrderList失败，模态{0}，sPatientID：{1}", sModality, sPatientID), ex)
        End Try
    End Function


    '组建表头
    Private Function BuildHQDataTable() As System.Data.DataTable

        Dim retDataTable As System.Data.DataTable = New System.Data.DataTable
        retDataTable.Columns.Add("HIS_ID")
        retDataTable.Columns.Add("Modality")
        retDataTable.Columns.Add("PATIENTID")
        retDataTable.Columns.Add("PatName")
        retDataTable.Columns.Add("IDCard")
        retDataTable.Columns.Add("Occupation")
        retDataTable.Columns.Add("Country")
        retDataTable.Columns.Add("Nationality")
        retDataTable.Columns.Add("PostCode")
        retDataTable.Columns.Add("BedNo")
        retDataTable.Columns.Add("PatSex")
        retDataTable.Columns.Add("PatAge")
        retDataTable.Columns.Add("PatBirthday")
        retDataTable.Columns.Add("TelephoneNo")
        retDataTable.Columns.Add("Address")
        retDataTable.Columns.Add("PatType")
        retDataTable.Columns.Add("ClinicID")
        retDataTable.Columns.Add("Clinic")
        retDataTable.Columns.Add("OrderDT")
        retDataTable.Columns.Add("OrderDr")
        retDataTable.Columns.Add("OrderDrID")
        retDataTable.Columns.Add("WardID")
        retDataTable.Columns.Add("Ward")
        retDataTable.Columns.Add("Disease")
        retDataTable.Columns.Add("AnamnesisRemark")
        retDataTable.Columns.Add("OutpatientID")
        retDataTable.Columns.Add("InpatientID")
        retDataTable.Columns.Add("OrderType")
        retDataTable.Columns.Add("ExamItemID")
        retDataTable.Columns.Add("ExamItem")
        retDataTable.Columns.Add("Charge")
        retDataTable.Columns.Add("REMARK")
        retDataTable.Columns.Add("sickroom")
        retDataTable.Columns.Add("PhysicalExamID")
        Return retDataTable

    End Function

    Private Sub FillOrderTable(ByVal sHisOrderXml As String, ByVal sPatType As String, ByVal sModality As String, ByRef retDataTable As DataTable)
        If sHisOrderXml Is Nothing OrElse sHisOrderXml = "" Then
            Return
        End If
        Dim doc As XmlDocument = New XmlDocument
        doc.LoadXml(sHisOrderXml)
        Dim rootNode As XmlNode = doc.SelectSingleNode("orderinfo")
        Dim dr As DataRow = retDataTable.NewRow()
        Dim currentNode As XmlNode
        Dim examNode As XmlNode

        Dim sInModality As String = GetModality(rootNode.SelectSingleNode("nametype").InnerText)
        If Not sInModality = sModality Then
            Return
        End If
        dr.BeginEdit()
        Dim iIndex As Integer
        Dim iIndexSub As Integer
        For iIndex = 0 To rootNode.ChildNodes.Count - 1 Step 1
            currentNode = rootNode.ChildNodes(iIndex)
            Select Case currentNode.Name
                Case "orderno"
                    dr("HIS_ID") = currentNode.InnerText
                Case "nametype"
                    dr("Modality") = sInModality
                Case "patientid"
                    dr("PATIENTID") = currentNode.InnerText
                    dr("OutpatientID") = currentNode.InnerText
                Case "pname"
                    dr("PatName") = currentNode.InnerText
                Case "idunum"
                    dr("IDCard") = currentNode.InnerText
                Case "psex"
                    If currentNode.InnerText = "男" Then
                        dr("PatSex") = "M"
                    Else
                        dr("PatSex") = "F"
                    End If

                Case "page"
                    dr("PatAge") = currentNode.InnerText
                Case "pbirthdate"
                    dr("PatBirthday") = currentNode.InnerText
                Case "ptelno"
                    dr("TelephoneNo") = currentNode.InnerText
                Case "paddress"
                    dr("Address") = currentNode.InnerText
                Case "orderlevel"
                    If currentNode.InnerText = "紧急" Then
                        dr("PatType") = "急诊E"
                    Else
                        dr("PatType") = "普通"
                    End If

                Case "deptname"
                    dr("Clinic") = currentNode.InnerText
                Case "deptid"
                    dr("ClinicID") = currentNode.InnerText
                Case "sheetdate"
                    dr("OrderDT") = currentNode.InnerText
                Case "doctorname"
                    dr("OrderDr") = currentNode.InnerText
                Case "doctorid"
                    dr("OrderDrID") = currentNode.InnerText
                Case "wardid"
                    dr("WardID") = currentNode.InnerText
                Case "wardname"
                    dr("Ward") = currentNode.InnerText
                Case "diagname"
                    dr("Disease") = currentNode.InnerText
                Case "chiefcomplaint"
                    dr("AnamnesisRemark") = currentNode.InnerText
                Case "medrcdno"
                    dr("InpatientID") = currentNode.InnerText
               
                Case "examitems"
                    Dim examIDs As String
                    Dim examItems As String
                    For iIndexSub = 0 To currentNode.ChildNodes.Count - 1 Step 1
                        examIDs = examIDs + currentNode.ChildNodes(iIndexSub).SelectSingleNode("itemcode").InnerText + ";"
                        examItems = examIDs + currentNode.ChildNodes(iIndexSub).SelectSingleNode("itemname").InnerText + ";"
                    Next
                    If examIDs.EndsWith(";") Then
                        examIDs = examIDs.Substring(0, examIDs.Length - 1)
                    End If
                    If examItems.EndsWith(";") Then
                        examItems = examItems.Substring(0, examItems.Length - 1)
                    End If
                    dr("ExamItem") = examItems
                    dr("ExamItemID") = examIDs
                Case "bedno"
                    dr("BedNo") = currentNode.InnerText
                Case "roomno"
                    dr("sickroom") = currentNode.InnerText
                Case "medrcdno"
                    dr("PhysicalExamID") = currentNode.InnerText
            End Select
        Next
        dr("OrderType") = "1001"
        dr.EndEdit()
        retDataTable.Rows.Add(dr)
    End Sub

    Private Function GetModality(ByVal sInModality As String) As String
        If sInModality.Trim.ToUpper = "DR" Then
            Return "CR"
        Else
            Return sInModality
        End If
    End Function
    '获取符合条件的HIS ID
    Private Function PasreHQHisIDs(ByVal sHisIDXml As String) As String()
        Dim doc As XmlDocument = New XmlDataDocument
        doc.LoadXml(sHisIDXml)
        Dim rootNode As XmlNode = doc.SelectSingleNode("orderlist")
        Dim retHisIds() As String
        ReDim retHisIds(rootNode.ChildNodes.Count - 1)
        Dim iIndex As Integer = 0
        Dim oNode As XmlNode
        For iIndex = 0 To rootNode.ChildNodes.Count - 1 Step 1
            retHisIds(iIndex) = rootNode.ChildNodes(iIndex).SelectSingleNode("orderno").InnerText
        Next

        Return retHisIds
    End Function

    '登记完成后回传给his已经登记
    Private Function postRISOrderSavedHQ(ByVal his_id As String) As Boolean
        Dim tempWS As SynthesizeIF.WebServices.WebServ = New SynthesizeIF.WebServices.WebServ
        tempWS.GetWebServInf(_sHQWSUrl, _sHQWSClassName, "updateOrderStatus")
        Dim para() As Object = New Object() {_sHQWSPassword, his_id, "已登记"}
        Dim retXml As String = tempWS.GetData(para)
        If retXml Is Nothing OrElse retXml = "" Then
            Return True
        Else
            LogManager.Logger.logError("postRISOrderSavedHQ--" + retXml + "  HisID:" + his_id)
            Return False
        End If
    End Function
#End Region
End Class

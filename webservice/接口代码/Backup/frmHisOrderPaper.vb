Imports System.IO
Imports maroland.RIS.commonUtility
Imports maroland.RIS.commonUtility.globalConst
Imports maroland.LogManager
Imports System.Drawing
Imports System.Windows.Forms
Imports C1.Win.C1Report
Imports System.Xml


''Imports maroland.RIS.SystemConfig


Public Class frmHisOrderPaper
    Inherits System.Windows.Forms.Form

#Region " Windows 窗体设计器生成的代码 "

    Public Sub New()
        MyBase.New()

        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()


        '在 InitializeComponent() 调用之后添加任何初始化

    End Sub

    '窗体重写 dispose 以清理组件列表。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改此过程。
    '不要使用代码编辑器修改它。
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents patID As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lbDateTime As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lbDotor As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tbBS As System.Windows.Forms.TextBox
    Friend WithEvents tbZD As System.Windows.Forms.TextBox
    Friend WithEvents tbExam As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CLINIC As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents patPhone As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents patAge As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents patsex As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents patname As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbOrderNo As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents picHolder As System.Windows.Forms.PictureBox
    Friend WithEvents picOrder As System.Windows.Forms.PictureBox
    Friend WithEvents lblZoom As System.Windows.Forms.Label
    Friend WithEvents cboZoom As System.Windows.Forms.ComboBox
    Friend WithEvents cmdDeleteFile As maroland.Base.mlTextButton
    Friend WithEvents cmdNext As maroland.Base.mlTextButton
    Friend WithEvents cmdPrevious As maroland.Base.mlTextButton
    Friend WithEvents cmdRotate270 As maroland.Base.mlTextButton
    Friend WithEvents cmdFlipH As maroland.Base.mlTextButton
    Friend WithEvents cmdRotate90 As maroland.Base.mlTextButton
    Friend WithEvents cmdFlipV As maroland.Base.mlTextButton
    Friend WithEvents cmdExportImage As maroland.Base.mlTextButton
    Friend WithEvents tabOrderView As System.Windows.Forms.TabControl
    Friend WithEvents chkAutoClose As System.Windows.Forms.CheckBox
    Friend WithEvents btnSetAutoCloseTime As maroland.Base.mlTextButton
    Friend WithEvents timeAutoClose As System.Windows.Forms.Timer
    Friend WithEvents chkIsAlwaysOpen As System.Windows.Forms.CheckBox
    Friend WithEvents lblAutoCloseTime As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents nUpDownTime As System.Windows.Forms.NumericUpDown
    Friend WithEvents C1ReportPreView As C1.Win.C1Report.C1Report
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tbTZ As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmHisOrderPaper))
        Me.tabOrderView = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Button1 = New System.Windows.Forms.Button
        Me.tbTZ = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.patID = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.lbDateTime = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.lbDotor = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.tbBS = New System.Windows.Forms.TextBox
        Me.tbZD = New System.Windows.Forms.TextBox
        Me.tbExam = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.CLINIC = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.patPhone = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.patAge = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.patsex = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.patname = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lbOrderNo = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.chkIsAlwaysOpen = New System.Windows.Forms.CheckBox
        Me.cmdDeleteFile = New maroland.Base.mlTextButton
        Me.cmdNext = New maroland.Base.mlTextButton
        Me.cmdPrevious = New maroland.Base.mlTextButton
        Me.cmdRotate270 = New maroland.Base.mlTextButton
        Me.cmdFlipH = New maroland.Base.mlTextButton
        Me.cmdRotate90 = New maroland.Base.mlTextButton
        Me.cmdFlipV = New maroland.Base.mlTextButton
        Me.cmdExportImage = New maroland.Base.mlTextButton
        Me.cboZoom = New System.Windows.Forms.ComboBox
        Me.lblZoom = New System.Windows.Forms.Label
        Me.picHolder = New System.Windows.Forms.PictureBox
        Me.picOrder = New System.Windows.Forms.PictureBox
        Me.lblAutoCloseTime = New System.Windows.Forms.Label
        Me.btnSetAutoCloseTime = New maroland.Base.mlTextButton
        Me.chkAutoClose = New System.Windows.Forms.CheckBox
        Me.timeAutoClose = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.nUpDownTime = New System.Windows.Forms.NumericUpDown
        Me.Label8 = New System.Windows.Forms.Label
        Me.C1ReportPreView = New C1.Win.C1Report.C1Report
        Me.tabOrderView.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.picHolder.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.nUpDownTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1ReportPreView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabOrderView
        '
        Me.tabOrderView.Controls.Add(Me.TabPage1)
        Me.tabOrderView.Controls.Add(Me.TabPage2)
        Me.tabOrderView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabOrderView.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tabOrderView.Location = New System.Drawing.Point(0, 0)
        Me.tabOrderView.Name = "tabOrderView"
        Me.tabOrderView.SelectedIndex = 0
        Me.tabOrderView.Size = New System.Drawing.Size(1080, 658)
        Me.tabOrderView.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.tbTZ)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.patID)
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.lbDateTime)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.lbDotor)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.tbBS)
        Me.TabPage1.Controls.Add(Me.tbZD)
        Me.TabPage1.Controls.Add(Me.tbExam)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.CLINIC)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.patPhone)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.patAge)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.patsex)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.patname)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.lbOrderNo)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(1072, 629)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "电子单"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(928, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(128, 48)
        Me.Button1.TabIndex = 60
        Me.Button1.Text = "特殊退费"
        Me.Button1.Visible = False
        '
        'tbTZ
        '
        Me.tbTZ.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbTZ.Font = New System.Drawing.Font("宋体", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tbTZ.Location = New System.Drawing.Point(120, 456)
        Me.tbTZ.Multiline = True
        Me.tbTZ.Name = "tbTZ"
        Me.tbTZ.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbTZ.Size = New System.Drawing.Size(928, 32)
        Me.tbTZ.TabIndex = 59
        Me.tbTZ.Text = ""
        Me.tbTZ.Visible = False
        '
        'Label13
        '
        Me.Label13.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label13.Location = New System.Drawing.Point(40, 464)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 16)
        Me.Label13.TabIndex = 58
        Me.Label13.Text = "体征："
        Me.Label13.Visible = False
        '
        'patID
        '
        Me.patID.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.patID.Location = New System.Drawing.Point(408, 51)
        Me.patID.Name = "patID"
        Me.patID.Size = New System.Drawing.Size(160, 16)
        Me.patID.TabIndex = 57
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label17.Location = New System.Drawing.Point(288, 51)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(120, 16)
        Me.Label17.TabIndex = 56
        Me.Label17.Text = "门诊/住院号："
        '
        'lbDateTime
        '
        Me.lbDateTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbDateTime.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbDateTime.Location = New System.Drawing.Point(880, 536)
        Me.lbDateTime.Name = "lbDateTime"
        Me.lbDateTime.Size = New System.Drawing.Size(160, 22)
        Me.lbDateTime.TabIndex = 54
        '
        'Label14
        '
        Me.Label14.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label14.Location = New System.Drawing.Point(792, 536)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 16)
        Me.Label14.TabIndex = 53
        Me.Label14.Text = "开单时间："
        '
        'lbDotor
        '
        Me.lbDotor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbDotor.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbDotor.Location = New System.Drawing.Point(880, 512)
        Me.lbDotor.Name = "lbDotor"
        Me.lbDotor.Size = New System.Drawing.Size(160, 16)
        Me.lbDotor.TabIndex = 52
        '
        'Label12
        '
        Me.Label12.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label12.Location = New System.Drawing.Point(792, 512)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 16)
        Me.Label12.TabIndex = 51
        Me.Label12.Text = "开单医生："
        '
        'tbBS
        '
        Me.tbBS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbBS.Font = New System.Drawing.Font("宋体", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tbBS.Location = New System.Drawing.Point(120, 304)
        Me.tbBS.Multiline = True
        Me.tbBS.Name = "tbBS"
        Me.tbBS.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbBS.Size = New System.Drawing.Size(928, 128)
        Me.tbBS.TabIndex = 50
        Me.tbBS.Text = ""
        '
        'tbZD
        '
        Me.tbZD.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbZD.Font = New System.Drawing.Font("宋体", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tbZD.Location = New System.Drawing.Point(120, 200)
        Me.tbZD.Multiline = True
        Me.tbZD.Name = "tbZD"
        Me.tbZD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbZD.Size = New System.Drawing.Size(928, 88)
        Me.tbZD.TabIndex = 48
        Me.tbZD.Text = ""
        '
        'tbExam
        '
        Me.tbExam.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbExam.Font = New System.Drawing.Font("宋体", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tbExam.Location = New System.Drawing.Point(120, 136)
        Me.tbExam.Multiline = True
        Me.tbExam.Name = "tbExam"
        Me.tbExam.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbExam.Size = New System.Drawing.Size(928, 48)
        Me.tbExam.TabIndex = 46
        Me.tbExam.Text = ""
        '
        'Label11
        '
        Me.Label11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label11.Location = New System.Drawing.Point(16, 312)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 16)
        Me.Label11.TabIndex = 49
        Me.Label11.Text = "病史摘要："
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 200)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 16)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "临床诊断："
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 136)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 16)
        Me.Label9.TabIndex = 45
        Me.Label9.Text = "检查项目："
        '
        'CLINIC
        '
        Me.CLINIC.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CLINIC.Location = New System.Drawing.Point(912, 88)
        Me.CLINIC.Name = "CLINIC"
        Me.CLINIC.Size = New System.Drawing.Size(104, 16)
        Me.CLINIC.TabIndex = 44
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label5.Location = New System.Drawing.Point(824, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "开单科室："
        '
        'patPhone
        '
        Me.patPhone.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.patPhone.Location = New System.Drawing.Point(640, 88)
        Me.patPhone.Name = "patPhone"
        Me.patPhone.Size = New System.Drawing.Size(160, 16)
        Me.patPhone.TabIndex = 42
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label6.Location = New System.Drawing.Point(584, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "电话："
        '
        'patAge
        '
        Me.patAge.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.patAge.Location = New System.Drawing.Point(448, 88)
        Me.patAge.Name = "patAge"
        Me.patAge.Size = New System.Drawing.Size(128, 16)
        Me.patAge.TabIndex = 40
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label7.Location = New System.Drawing.Point(384, 88)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 16)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "年龄："
        '
        'patsex
        '
        Me.patsex.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.patsex.Location = New System.Drawing.Point(272, 91)
        Me.patsex.Name = "patsex"
        Me.patsex.Size = New System.Drawing.Size(88, 16)
        Me.patsex.TabIndex = 38
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.Location = New System.Drawing.Point(216, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 16)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "性别："
        '
        'patname
        '
        Me.patname.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.patname.Location = New System.Drawing.Point(80, 91)
        Me.patname.Name = "patname"
        Me.patname.Size = New System.Drawing.Size(128, 16)
        Me.patname.TabIndex = 36
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "姓名："
        '
        'lbOrderNo
        '
        Me.lbOrderNo.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbOrderNo.Location = New System.Drawing.Point(120, 51)
        Me.lbOrderNo.Name = "lbOrderNo"
        Me.lbOrderNo.Size = New System.Drawing.Size(160, 16)
        Me.lbOrderNo.TabIndex = 34
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 16)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "申请单号："
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("宋体", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(448, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 23)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "检查申请单"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.chkIsAlwaysOpen)
        Me.TabPage2.Controls.Add(Me.cmdDeleteFile)
        Me.TabPage2.Controls.Add(Me.cmdNext)
        Me.TabPage2.Controls.Add(Me.cmdPrevious)
        Me.TabPage2.Controls.Add(Me.cmdRotate270)
        Me.TabPage2.Controls.Add(Me.cmdFlipH)
        Me.TabPage2.Controls.Add(Me.cmdRotate90)
        Me.TabPage2.Controls.Add(Me.cmdFlipV)
        Me.TabPage2.Controls.Add(Me.cmdExportImage)
        Me.TabPage2.Controls.Add(Me.cboZoom)
        Me.TabPage2.Controls.Add(Me.lblZoom)
        Me.TabPage2.Controls.Add(Me.picHolder)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(1072, 629)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "拍摄单"
        '
        'chkIsAlwaysOpen
        '
        Me.chkIsAlwaysOpen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkIsAlwaysOpen.BackColor = System.Drawing.Color.FromArgb(CType(232, Byte), CType(232, Byte), CType(232, Byte))
        Me.chkIsAlwaysOpen.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIsAlwaysOpen.ForeColor = System.Drawing.Color.Blue
        Me.chkIsAlwaysOpen.Location = New System.Drawing.Point(976, 328)
        Me.chkIsAlwaysOpen.Name = "chkIsAlwaysOpen"
        Me.chkIsAlwaysOpen.Size = New System.Drawing.Size(104, 20)
        Me.chkIsAlwaysOpen.TabIndex = 22
        Me.chkIsAlwaysOpen.Text = "是否一直开启"
        Me.chkIsAlwaysOpen.Visible = False
        '
        'cmdDeleteFile
        '
        Me.cmdDeleteFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDeleteFile.BorderStyle = maroland.Base.mlTextButton.emBorderStyle.Java
        Me.cmdDeleteFile.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdDeleteFile.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDeleteFile.ForeColor = System.Drawing.Color.Black
        Me.cmdDeleteFile.HoverGradientColor2 = System.Drawing.Color.FromArgb(CType(104, Byte), CType(104, Byte), CType(104, Byte))
        Me.cmdDeleteFile.HoverGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.cmdDeleteFile.Location = New System.Drawing.Point(968, 256)
        Me.cmdDeleteFile.Name = "cmdDeleteFile"
        Me.cmdDeleteFile.NormalGradientColor1 = System.Drawing.Color.FromArgb(CType(249, Byte), CType(249, Byte), CType(249, Byte))
        Me.cmdDeleteFile.NormalGradientColor2 = System.Drawing.Color.DimGray
        Me.cmdDeleteFile.NormalGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.cmdDeleteFile.Size = New System.Drawing.Size(96, 28)
        Me.cmdDeleteFile.TabIndex = 16
        Me.cmdDeleteFile.Text = "删除图像[&D]"
        '
        'cmdNext
        '
        Me.cmdNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdNext.BorderStyle = maroland.Base.mlTextButton.emBorderStyle.Java
        Me.cmdNext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdNext.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.ForeColor = System.Drawing.Color.Black
        Me.cmdNext.HoverGradientColor2 = System.Drawing.Color.FromArgb(CType(104, Byte), CType(104, Byte), CType(104, Byte))
        Me.cmdNext.HoverGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.cmdNext.Location = New System.Drawing.Point(968, 224)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.NormalGradientColor1 = System.Drawing.Color.FromArgb(CType(249, Byte), CType(249, Byte), CType(249, Byte))
        Me.cmdNext.NormalGradientColor2 = System.Drawing.Color.DimGray
        Me.cmdNext.NormalGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.cmdNext.Size = New System.Drawing.Size(96, 28)
        Me.cmdNext.TabIndex = 14
        Me.cmdNext.Text = "下一页[&N]"
        '
        'cmdPrevious
        '
        Me.cmdPrevious.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrevious.BorderStyle = maroland.Base.mlTextButton.emBorderStyle.Java
        Me.cmdPrevious.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdPrevious.Enabled = False
        Me.cmdPrevious.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrevious.ForeColor = System.Drawing.Color.Black
        Me.cmdPrevious.HoverGradientColor2 = System.Drawing.Color.FromArgb(CType(104, Byte), CType(104, Byte), CType(104, Byte))
        Me.cmdPrevious.HoverGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.cmdPrevious.Location = New System.Drawing.Point(968, 200)
        Me.cmdPrevious.Name = "cmdPrevious"
        Me.cmdPrevious.NormalGradientColor1 = System.Drawing.Color.FromArgb(CType(249, Byte), CType(249, Byte), CType(249, Byte))
        Me.cmdPrevious.NormalGradientColor2 = System.Drawing.Color.DimGray
        Me.cmdPrevious.NormalGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.cmdPrevious.Size = New System.Drawing.Size(96, 28)
        Me.cmdPrevious.TabIndex = 13
        Me.cmdPrevious.Text = "上一页[&P]"
        '
        'cmdRotate270
        '
        Me.cmdRotate270.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRotate270.BorderStyle = maroland.Base.mlTextButton.emBorderStyle.Java
        Me.cmdRotate270.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdRotate270.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRotate270.ForeColor = System.Drawing.Color.Black
        Me.cmdRotate270.HoverGradientColor2 = System.Drawing.Color.FromArgb(CType(104, Byte), CType(104, Byte), CType(104, Byte))
        Me.cmdRotate270.HoverGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.cmdRotate270.Location = New System.Drawing.Point(968, 72)
        Me.cmdRotate270.Name = "cmdRotate270"
        Me.cmdRotate270.NormalGradientColor1 = System.Drawing.Color.FromArgb(CType(249, Byte), CType(249, Byte), CType(249, Byte))
        Me.cmdRotate270.NormalGradientColor2 = System.Drawing.Color.DimGray
        Me.cmdRotate270.NormalGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.cmdRotate270.Size = New System.Drawing.Size(96, 28)
        Me.cmdRotate270.TabIndex = 12
        Me.cmdRotate270.Text = "左转&90度"
        '
        'cmdFlipH
        '
        Me.cmdFlipH.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFlipH.BorderStyle = maroland.Base.mlTextButton.emBorderStyle.Java
        Me.cmdFlipH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdFlipH.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFlipH.ForeColor = System.Drawing.Color.Black
        Me.cmdFlipH.HoverGradientColor2 = System.Drawing.Color.FromArgb(CType(104, Byte), CType(104, Byte), CType(104, Byte))
        Me.cmdFlipH.HoverGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.cmdFlipH.Location = New System.Drawing.Point(968, 136)
        Me.cmdFlipH.Name = "cmdFlipH"
        Me.cmdFlipH.NormalGradientColor1 = System.Drawing.Color.FromArgb(CType(249, Byte), CType(249, Byte), CType(249, Byte))
        Me.cmdFlipH.NormalGradientColor2 = System.Drawing.Color.DimGray
        Me.cmdFlipH.NormalGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.cmdFlipH.Size = New System.Drawing.Size(96, 28)
        Me.cmdFlipH.TabIndex = 9
        Me.cmdFlipH.Text = "水平翻转[&H]"
        '
        'cmdRotate90
        '
        Me.cmdRotate90.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRotate90.BorderStyle = maroland.Base.mlTextButton.emBorderStyle.Java
        Me.cmdRotate90.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdRotate90.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRotate90.ForeColor = System.Drawing.Color.Black
        Me.cmdRotate90.HoverGradientColor2 = System.Drawing.Color.FromArgb(CType(104, Byte), CType(104, Byte), CType(104, Byte))
        Me.cmdRotate90.HoverGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.cmdRotate90.Location = New System.Drawing.Point(968, 104)
        Me.cmdRotate90.Name = "cmdRotate90"
        Me.cmdRotate90.NormalGradientColor1 = System.Drawing.Color.FromArgb(CType(249, Byte), CType(249, Byte), CType(249, Byte))
        Me.cmdRotate90.NormalGradientColor2 = System.Drawing.Color.DimGray
        Me.cmdRotate90.NormalGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.cmdRotate90.Size = New System.Drawing.Size(96, 28)
        Me.cmdRotate90.TabIndex = 10
        Me.cmdRotate90.Text = "右转9&0度"
        '
        'cmdFlipV
        '
        Me.cmdFlipV.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFlipV.BorderStyle = maroland.Base.mlTextButton.emBorderStyle.Java
        Me.cmdFlipV.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdFlipV.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFlipV.ForeColor = System.Drawing.Color.Black
        Me.cmdFlipV.HoverGradientColor2 = System.Drawing.Color.FromArgb(CType(104, Byte), CType(104, Byte), CType(104, Byte))
        Me.cmdFlipV.HoverGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.cmdFlipV.Location = New System.Drawing.Point(968, 168)
        Me.cmdFlipV.Name = "cmdFlipV"
        Me.cmdFlipV.NormalGradientColor1 = System.Drawing.Color.FromArgb(CType(249, Byte), CType(249, Byte), CType(249, Byte))
        Me.cmdFlipV.NormalGradientColor2 = System.Drawing.Color.DimGray
        Me.cmdFlipV.NormalGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.cmdFlipV.Size = New System.Drawing.Size(96, 28)
        Me.cmdFlipV.TabIndex = 11
        Me.cmdFlipV.Text = "垂直翻转[&V]"
        '
        'cmdExportImage
        '
        Me.cmdExportImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExportImage.BorderStyle = maroland.Base.mlTextButton.emBorderStyle.Java
        Me.cmdExportImage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdExportImage.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExportImage.ForeColor = System.Drawing.Color.Black
        Me.cmdExportImage.HoverGradientColor2 = System.Drawing.Color.FromArgb(CType(104, Byte), CType(104, Byte), CType(104, Byte))
        Me.cmdExportImage.HoverGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.cmdExportImage.Location = New System.Drawing.Point(968, 288)
        Me.cmdExportImage.Name = "cmdExportImage"
        Me.cmdExportImage.NormalGradientColor1 = System.Drawing.Color.FromArgb(CType(249, Byte), CType(249, Byte), CType(249, Byte))
        Me.cmdExportImage.NormalGradientColor2 = System.Drawing.Color.DimGray
        Me.cmdExportImage.NormalGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.cmdExportImage.Size = New System.Drawing.Size(96, 28)
        Me.cmdExportImage.TabIndex = 15
        Me.cmdExportImage.Text = "导出图像[&X]"
        '
        'cboZoom
        '
        Me.cboZoom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZoom.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboZoom.Items.AddRange(New Object() {"25%", "50%", "75%", "100%", "150%", "200%"})
        Me.cboZoom.Location = New System.Drawing.Point(968, 40)
        Me.cboZoom.Name = "cboZoom"
        Me.cboZoom.Size = New System.Drawing.Size(96, 21)
        Me.cboZoom.TabIndex = 7
        '
        'lblZoom
        '
        Me.lblZoom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblZoom.AutoSize = True
        Me.lblZoom.Location = New System.Drawing.Point(976, 16)
        Me.lblZoom.Name = "lblZoom"
        Me.lblZoom.Size = New System.Drawing.Size(72, 22)
        Me.lblZoom.TabIndex = 6
        Me.lblZoom.Text = "缩放[&Z]:"
        '
        'picHolder
        '
        Me.picHolder.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picHolder.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.picHolder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picHolder.Controls.Add(Me.picOrder)
        Me.picHolder.Location = New System.Drawing.Point(0, 0)
        Me.picHolder.Name = "picHolder"
        Me.picHolder.Size = New System.Drawing.Size(960, 630)
        Me.picHolder.TabIndex = 3
        Me.picHolder.TabStop = False
        '
        'picOrder
        '
        Me.picOrder.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.picOrder.Location = New System.Drawing.Point(154, 72)
        Me.picOrder.Name = "picOrder"
        Me.picOrder.Size = New System.Drawing.Size(400, 320)
        Me.picOrder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picOrder.TabIndex = 3
        Me.picOrder.TabStop = False
        '
        'lblAutoCloseTime
        '
        Me.lblAutoCloseTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAutoCloseTime.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAutoCloseTime.ForeColor = System.Drawing.Color.Navy
        Me.lblAutoCloseTime.Location = New System.Drawing.Point(1000, 8)
        Me.lblAutoCloseTime.Name = "lblAutoCloseTime"
        Me.lblAutoCloseTime.Size = New System.Drawing.Size(76, 23)
        Me.lblAutoCloseTime.TabIndex = 23
        Me.lblAutoCloseTime.Visible = False
        '
        'btnSetAutoCloseTime
        '
        Me.btnSetAutoCloseTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetAutoCloseTime.BorderStyle = maroland.Base.mlTextButton.emBorderStyle.Java
        Me.btnSetAutoCloseTime.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSetAutoCloseTime.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetAutoCloseTime.ForeColor = System.Drawing.Color.Blue
        Me.btnSetAutoCloseTime.HoverGradientColor2 = System.Drawing.Color.FromArgb(CType(104, Byte), CType(104, Byte), CType(104, Byte))
        Me.btnSetAutoCloseTime.HoverGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.btnSetAutoCloseTime.Location = New System.Drawing.Point(416, 8)
        Me.btnSetAutoCloseTime.Name = "btnSetAutoCloseTime"
        Me.btnSetAutoCloseTime.NormalGradientColor1 = System.Drawing.Color.FromArgb(CType(249, Byte), CType(249, Byte), CType(249, Byte))
        Me.btnSetAutoCloseTime.NormalGradientColor2 = System.Drawing.Color.DimGray
        Me.btnSetAutoCloseTime.NormalGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.btnSetAutoCloseTime.Size = New System.Drawing.Size(96, 28)
        Me.btnSetAutoCloseTime.TabIndex = 18
        Me.btnSetAutoCloseTime.Text = "设置关闭时间"
        Me.btnSetAutoCloseTime.Visible = False
        '
        'chkAutoClose
        '
        Me.chkAutoClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkAutoClose.Checked = True
        Me.chkAutoClose.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAutoClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAutoClose.ForeColor = System.Drawing.Color.Blue
        Me.chkAutoClose.Location = New System.Drawing.Point(904, 8)
        Me.chkAutoClose.Name = "chkAutoClose"
        Me.chkAutoClose.Size = New System.Drawing.Size(80, 24)
        Me.chkAutoClose.TabIndex = 17
        Me.chkAutoClose.Text = "自动关闭"
        Me.chkAutoClose.Visible = False
        '
        'timeAutoClose
        '
        Me.timeAutoClose.Interval = 500
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.nUpDownTime)
        Me.Panel1.Controls.Add(Me.chkAutoClose)
        Me.Panel1.Controls.Add(Me.lblAutoCloseTime)
        Me.Panel1.Controls.Add(Me.btnSetAutoCloseTime)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 618)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1080, 40)
        Me.Panel1.TabIndex = 1
        '
        'nUpDownTime
        '
        Me.nUpDownTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nUpDownTime.Location = New System.Drawing.Point(520, 8)
        Me.nUpDownTime.Name = "nUpDownTime"
        Me.nUpDownTime.Size = New System.Drawing.Size(72, 21)
        Me.nUpDownTime.TabIndex = 24
        Me.nUpDownTime.Value = New Decimal(New Integer() {20, 0, 0, 0})
        Me.nUpDownTime.Visible = False
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.Location = New System.Drawing.Point(600, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 23)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "秒"
        Me.Label8.Visible = False
        '
        'C1ReportPreView
        '
        Me.C1ReportPreView.ReportDefinition = "<!--Report *** C1Report1 ***--><Report version=""2.5.20053.188""><Name>C1Report1</N" & _
        "ame><DataSource /><Layout /><Font><Name>Arial</Name><Size>9</Size></Font><Groups" & _
        " /><Sections><Section><Name>Detail</Name><Type>0</Type><Visible>0</Visible></Sec" & _
        "tion><Section><Name>Header</Name><Type>1</Type><Visible>0</Visible></Section><Se" & _
        "ction><Name>Footer</Name><Type>2</Type><Visible>0</Visible></Section><Section><N" & _
        "ame>PageHeader</Name><Type>3</Type><Visible>0</Visible></Section><Section><Name>" & _
        "PageFooter</Name><Type>4</Type><Visible>0</Visible></Section></Sections><Fields " & _
        "/></Report>"
        Me.C1ReportPreView.ReportName = "C1Report1"
        '
        'frmHisOrderPaper
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1080, 658)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tabOrderView)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "frmHisOrderPaper"
        Me.Text = "申请单信息"
        Me.tabOrderView.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.picHolder.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.nUpDownTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1ReportPreView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '' Public _vConfig As SystemConfig.AppConfiguration = SystemConfig.AppConfiguration.GetInstance
    Public dtHisInfo As DataTable
    Public _orderSeqHis As String
    Public _hi As HISInterface
    Private Sub frmHisOrderPaper_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'InitAutoClose()

            If dtHisInfo.Rows.Count > 0 Then
                Me.tabOrderView.SelectedIndex = 0
                OpenDialog(dtHisInfo)
            Else
                Me.tabOrderView.SelectedIndex = 1
            End If

        Catch ex As Exception
            Common.logger.logError("HISInterface._getHISOrderList 发生错误", ex)
        End Try
    End Sub

    ''填充申请信息
    Public Function OpenDialog(ByVal dt As DataTable) As Boolean
        Try
            'If dt.Rows.Count <> 0 Then
            '    Return False
            'End If
            Me.lbOrderNo.Text = dt.Rows(0)("HIS_ID").ToString()  '申请单号
            Me.patID.Text = dt.Rows(0)("PATIENTID").ToString()  '住院门诊号
            Me.patname.Text = dt.Rows(0)("PatName").ToString()  '病人姓名
            If dt.Rows(0)("PatSex").ToString() = "F" Then
                Me.patsex.Text = "女" '病人性别
            ElseIf dt.Rows(0)("PatSex").ToString() = "M" Then
                Me.patsex.Text = "男" '病人性别
            Else
                Me.patsex.Text = "其他" '病人性别
            End If
            Me.patAge.Text = Common.birthdayToAge(dt.Rows(0)("PatBirthday").ToString())   '年龄
            Me.patPhone.Text = dt.Rows(0)("TelephoneNo").ToString()  '电话
            Me.CLINIC.Text = dt.Rows(0)("Clinic").ToString()  '开单科室
            'Me.WARD.Text = dt.Rows(0)("sqdh").ToString()  '病区
            'Me.BEDNO.Text = dt.Rows(0)("sqdh").ToString()  '床号
            Dim count As Integer = 0
            Me.tbExam.Text = "" 'ExamItem
            For count = 0 To dt.Rows.Count - 1
                If tbExam.Text = Nothing OrElse tbExam.Text = String.Empty Then
                    Me.tbExam.Text = dt.Rows(count)("ExamItem").ToString() + ";" '检查项目
                Else
                    Me.tbExam.Text = Me.tbExam.Text + dt.Rows(count)("ExamItem").ToString() + ";" '检查项目
                End If
            Next
            ''   Me.tbExam.Text = dt.Rows(0)("YZMC").ToString()  
            Me.tbZD.Text = dt.Rows(0)("Disease").ToString()   '临床诊断
            'Me.tbBS.Text = dt.Rows(0)("bssm").ToString()  
            Me.lbDotor.Text = dt.Rows(0)("OrderDr").ToString()  '开单医生
            Me.lbDateTime.Text = dt.Rows(0)("OrderDT").ToString()  '科室时间
            Me.tbBS.Text = dt.Rows(0)("AnamnesisRemark").ToString() '病史摘要
            'Me.tbTZ.Text = dt.Rows(0)("tjxx").ToString()
            '_orderSeqHis = dt.Rows(0)("orderseq").ToString()
            'Me.ShowDialog()
            'If cbColse.Checked = True Then
            '    Me.Close()
            'End If
            Return True
        Catch ex As Exception
            LogManager.Logger.logError("查看门诊申请单失败：", ex)
            Return False
        End Try
    End Function

#Region "拍摄申请单"


    Public Property dtOrderFile() As DataTable
        Get
            Return _dOrderFile
        End Get
        Set(ByVal Value As DataTable)
            _dOrderFile = Value
        End Set
    End Property

#Region " 公用变量定义 "
    Private _moveBegin As New Point
    Private _orderPaper As Image                    ' image object contain order paper image
    Private _orderSeq As String                     ' order sequence
    'Private _vPaperType As emOrderPaperType          ' 申请单类型
    Private _rowCount As Integer = 0                ' 保存申请单图像的数量
    Private _currentIndex As Integer = 0            ' 当前申请单图像的索引
    Private _linkSeq As String
    Private _dOrderFile As DataTable 'OrderFileData                      '图像文件名表
    Private _zoomFactor As Single = 0.5             ' 缩放比率
#End Region


    Private Sub cboZoom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboZoom.SelectedIndexChanged

        If cboZoom.SelectedItem Is Nothing Then Return
        If _orderPaper Is Nothing Then Return

        Select Case cboZoom.SelectedItem
            Case "25%"
                _zoomFactor = 0.25
            Case "50%"
                _zoomFactor = 0.5
            Case "75%"
                _zoomFactor = 0.75
            Case "100%"
                _zoomFactor = 1
            Case "150%"
                _zoomFactor = 1.5
            Case "200%"
                _zoomFactor = 2
        End Select

        Me.drawImage()

    End Sub

    Private Sub cmdRotate270_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRotate270.Click
        If picOrder Is Nothing OrElse picOrder.Image Is Nothing Then Return
        picOrder.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
        movePicOrder(1, 1)
        movePicOrder(-1, -1)
        picOrder.Refresh()
    End Sub

    Private Sub cmdRotate90_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRotate90.Click
        If picOrder Is Nothing OrElse picOrder.Image Is Nothing Then Return
        picOrder.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
        movePicOrder(1, 1)
        movePicOrder(-1, -1)
        picOrder.Refresh()
    End Sub

    Private Sub cmdFlipH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFlipH.Click
        If picOrder Is Nothing OrElse picOrder.Image Is Nothing Then Return
        picOrder.Image.RotateFlip(RotateFlipType.Rotate180FlipY)
        picOrder.Refresh()
    End Sub

    Private Sub cmdFlipV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFlipV.Click
        If picOrder Is Nothing OrElse picOrder.Image Is Nothing Then Return
        picOrder.Image.RotateFlip(RotateFlipType.Rotate180FlipX)
        picOrder.Refresh()
    End Sub


    Private Sub cmdPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrevious.Click
        If _currentIndex > 0 Then
            _currentIndex += -1
            Me.loadOrderPaperImage()
        End If
    End Sub

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        If _currentIndex < _rowCount Then
            _currentIndex += 1
            Me.loadOrderPaperImage()
        End If
    End Sub

    Private Sub picOrder_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picOrder.MouseMove

        If e.Button = MouseButtons.Left Then
            Dim iLeft As Integer = 0
            Dim iTop As Integer = 0

            Cursor.Current = Cursors.SizeAll

            iLeft = e.X - _moveBegin.X
            iTop = e.Y - _moveBegin.Y

            movePicOrder(iLeft, iTop)
        End If

    End Sub

    Private Sub movePicOrder(ByVal iLeft As Integer, ByVal iTop As Integer)

        Dim i As Integer
        Dim j As Integer

        If picOrder.Height > picHolder.Height Then
            If (iTop < 0) Then
                '上移
                If picOrder.Top + iTop <= picHolder.Height - picOrder.Height Then
                    j = picHolder.Height - picOrder.Height
                Else
                    j = picOrder.Top + iTop
                End If
            Else
                '下移
                If picOrder.Top + iTop >= 0 Then
                    j = 0
                Else
                    j = picOrder.Top + iTop
                End If
            End If
        Else
            If (iTop < 0) Then
                '上移
                If picOrder.Top + iTop < 0 Then
                    j = 0
                Else
                    j = picOrder.Top + iTop

                End If
            Else
                '下移
                If (picOrder.Top + iTop) > (picHolder.Height - picOrder.Height) Then
                    j = picHolder.Height - picOrder.Height
                Else
                    j = picOrder.Top + iTop
                End If
            End If
        End If

        If picOrder.Width > picHolder.Width Then
            If (iLeft < 0) Then
                '左移
                If (picOrder.Left + iLeft) <= (picHolder.Width - picOrder.Width) Then
                    i = picHolder.Width - picOrder.Width
                Else
                    i = picOrder.Left + iLeft
                End If
            Else
                '右移
                If picOrder.Left + iLeft >= 0 Then
                    i = 0
                Else
                    i = picOrder.Left + iLeft
                End If
            End If
        Else
            If (iLeft < 0) Then
                If picOrder.Left + iLeft < 0 Then
                    i = 0
                Else
                    i = picOrder.Left + iLeft
                End If
            Else
                If (picOrder.Left + iLeft) > (picHolder.Width - picOrder.Width) Then
                    i = picHolder.Width - picOrder.Width
                Else
                    i = picOrder.Left + iLeft
                End If
            End If
        End If

        picOrder.Left = i
        picOrder.Top = j

    End Sub

    Private Sub picOrder_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picOrder.MouseUp

        _moveBegin.X = e.X
        _moveBegin.Y = e.Y

    End Sub

    Private Sub picOrder_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picOrder.MouseDown
        _moveBegin.X = e.X
        _moveBegin.Y = e.Y
    End Sub


    Private Sub tabOrderView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabOrderView.SelectedIndexChanged

        If tabOrderView.SelectedIndex = 1 Then

            'TODO
            '_dOrderFile = 


            If picOrder.Image Is Nothing AndAlso Me._dOrderFile Is Nothing = False AndAlso _dOrderFile.Rows.Count > 0 Then
                loadOrderPaperImage()
            End If
        End If

    End Sub


    Private Sub drawImage()

        If _orderPaper Is Nothing Then Return

        Dim iWidth As Integer = _orderPaper.Width * _zoomFactor
        Dim iHeight As Integer = _orderPaper.Height * _zoomFactor

        ' create new bitmap for display...
        picOrder.Image = New System.Drawing.Bitmap(_orderPaper, iWidth, iHeight)

        If Not (picOrder Is Nothing OrElse picOrder.Image Is Nothing) Then
            Dim nRotateFlipType As Integer = System.Configuration.ConfigurationSettings.AppSettings("ShowImageRotateFlipType")
            Select Case nRotateFlipType
                Case RotateFlipType.Rotate90FlipNone
                    picOrder.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
                    movePicOrder(1, 1)
                    movePicOrder(-1, -1)
                    picOrder.Refresh()
                Case RotateFlipType.Rotate180FlipNone
                    picOrder.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
                    picOrder.Refresh()
                Case RotateFlipType.Rotate270FlipNone
                    picOrder.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
                    movePicOrder(1, 1)
                    movePicOrder(-1, -1)
                    picOrder.Refresh()
                Case Else
                    picOrder.Left = 0
                    picOrder.Top = 0
                    picOrder.Refresh()
            End Select
        End If

    End Sub

    Private Function loadOrderPaperImage() As Boolean
        '
        'plViewImage.Visible = True
        If _dOrderFile Is Nothing OrElse _dOrderFile.Rows.Count = 0 Then
            System.Windows.Forms.MessageBox.Show("无此拍摄申请单", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        tabOrderView.SelectedIndex = 1
        Dim iIndex As Integer = 1
        Dim zoomType As String = System.Configuration.ConfigurationSettings.AppSettings("ShowImageZoomType")
        If zoomType Is Nothing OrElse zoomType.Length = 0 Then
            zoomType = 3
        End If
        Select Case zoomType
            Case "0"
                _zoomFactor = 0.25
                iIndex = 0
            Case "1"
                _zoomFactor = 0.5
                iIndex = 1
            Case "2"
                _zoomFactor = 0.75
                iIndex = 2
            Case "3"
                _zoomFactor = 1
                iIndex = 3
            Case "4"
                _zoomFactor = 1.5
                iIndex = 4
            Case "5"
                _zoomFactor = 2
                iIndex = 5
        End Select

        cboZoom.SelectedIndex = iIndex
        'If iIndex < 3 Then
        '    cboZoom.SelectedIndex = 3
        '    _zoomFactor = 1
        'Else
        '    cboZoom.SelectedIndex = iIndex
        'End If

        'If loadOrderPaperImage() Then
        '    
        'End If

        Dim sOPImageRoot As String              ' 图像存储的根路径
        Dim sImageFile As String                ' 图像存储的完整路径
        Dim sImageLocalFileFullName As String   ' 图像本地存储路径
        'Dim faQuery As New Query
        Dim dt As DataTable

        Try
            dt = _dOrderFile '.Tables(OrderFileData.ORDERFILE_TABLENAME)
            _rowCount = dt.Rows.Count

            If _currentIndex <= _rowCount Then
                ' get order paper linkseq in database
                _linkSeq = dt.Rows(_currentIndex).Item("LINKSEQ")

                ' get order paper image path in database.
                sImageFile = dt.Rows(_currentIndex).Item("FILENAME")

                ' get order paper image storage root path.
                sOPImageRoot = System.Configuration.ConfigurationSettings.AppSettings("OPImageStorage")

                ' get the order paper image full path.
                sImageFile = sOPImageRoot & sImageFile

                sImageLocalFileFullName = Application.StartupPath & "Temp" & sImageFile
                Dim ret As Boolean = FtpClientHelper.DownloadFile(sImageFile, sImageLocalFileFullName)

                ' image file exists validation.
                If Not ret Then
                    System.Windows.Forms.MessageBox.Show("该检查的图像丢失，请联系系统管理员！", _
                                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
                End If

                '使用ftp下载到本地的路径来打开文件
                _orderPaper = System.Drawing.Image.FromFile(sImageLocalFileFullName)

                If _currentIndex > 0 Then
                    cmdPrevious.Enabled = True
                Else
                    cmdPrevious.Enabled = False
                End If

                If _rowCount > (_currentIndex + 1) Then
                    cmdNext.Enabled = True
                Else
                    cmdNext.Enabled = False
                End If

                'cmdDeleteFile.Enabled = True

                Me.drawImage()
                'Dim mi As New MethodInvoker(AddressOf drawImage)
                'mi.BeginInvoke(Nothing, Nothing)

                Return True
            End If
        Catch ex As Exception
            ' Messagebox.Show("显示图像时发生错误: " & ex.Message, Application.ProductName, , MessageBoxIcon.Error)
            Logger.logError("显示图像时发生错误", ex)
        Finally
            ' faQuery = Nothing
        End Try
    End Function


#End Region


    '#Region "自动关闭"
    '    Private _AutoTime As Integer '几秒后自动关闭

    '    Private Sub InitAutoClose()

    '        Dim sTime As String = Common.getAppSetting("OrderImageAutoCloseTime", "30")

    '        If sTime Is Nothing OrElse sTime.Length = 0 Then
    '            Me._AutoTime = 20
    '            Me.timeAutoClose.Enabled = False
    '            Me.chkAutoClose.Enabled = False
    '        Else
    '            Dim nTime As Integer = 20
    '            Try
    '                nTime = Convert.ToInt32(sTime)
    '                If nTime <= 0 Then
    '                    Me.timeAutoClose.Enabled = False
    '                    Me.chkAutoClose.Enabled = False
    '                End If
    '                Me._AutoTime = nTime
    '                Me.timeAutoClose.Enabled = True
    '                chkAutoClose.Checked = True

    '                Me.nUpDownTime.Text = nTime.ToString()
    '                Me.lblAutoCloseTime.Text = sTime & "秒"

    '            Catch ex As Exception
    '                _AutoTime = 15
    '                Me.timeAutoClose.Enabled = False
    '                Me.chkAutoClose.Enabled = False
    '            End Try

    '        End If

    '        Dim sAutoOpenAppOrderPatientType As String = Common.getAppSetting("AutoOpenAppOrderPatientType", "")

    '        If sAutoOpenAppOrderPatientType Is Nothing OrElse sAutoOpenAppOrderPatientType.Trim.Length = 0 Then
    '            Me.chkIsAlwaysOpen.Checked = False
    '        Else
    '            Me.chkIsAlwaysOpen.Checked = True
    '        End If

    '    End Sub

    '    Private Sub chkIsAlwaysOpen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsAlwaysOpen.CheckedChanged
    '        If Me.chkIsAlwaysOpen.Checked Then
    '            Common.getAppSetting("AutoOpenAppOrderPatientType", "O,I,E,N")
    '        Else
    '            Common.getAppSetting("AutoOpenAppOrderPatientType", "")
    '        End If
    '    End Sub

    '    Private Sub timeAutoClose_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timeAutoClose.Tick
    '        ''_AutoTime()
    '        '' InitAutoClose()
    '        If _AutoTime < 0 Then
    '            Me.Close()
    '        Else
    '            Me.lblAutoCloseTime.Text = _AutoTime.ToString() & "秒"
    '        End If
    '        _AutoTime = _AutoTime - 1
    '    End Sub

    '    Private Sub chkAutoClose_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoClose.CheckedChanged
    '        Me.timeAutoClose.Enabled = Me.chkAutoClose.Checked
    '    End Sub

    '    Private Sub btnSetAutoCloseTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetAutoCloseTime.Click
    '        Common.getAppSetting("OrderImageAutoCloseTime", Me.nUpDownTime.Text)
    '    End Sub
    '#End Region
    '''''导出到pdf中
    'Private Sub btnPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPDF.Click
    '    Dim oword As Word.Application
    '    Dim odoc As Word.Document
    '    Dim otable As Word.Table
    '    Dim opara1 As Word.Paragraph
    '    Dim opara2 As Word.Paragraph
    '    Dim opara3 As Word.Paragraph
    '    Dim opara4 As Word.Paragraph
    '    Dim orng As Word.Range
    '    Dim oshape As Word.InlineShape
    '    Dim ochart As Object
    '    Dim pos As Double
    '    '启动work
    '    oword = CreateObject("Work.application")
    '    oword.Visible = True
    '    odoc = oword.Documents.Add

    '    ''在文件的开头处插入一个段落
    '    opara1 = odoc.Content.Paragraphs.Add
    '    opara1.Range.Text = "标题一"
    '    opara1.Range.Font.Bold = True
    '    opara1.Format.SpaceAfter = 24  ''加24个空格
    '    opara1.Range.InsertParagraphAfter()

    '    ''在文件结尾插入一个段落
    '    opara2 = odoc.Content.Paragraphs.Add(odoc.Bookmarks.Item("\endoFdoc").Range)
    '    opara2.Range.Text = "标题二"
    '    opara2.Format.SpaceAfter = 6  ''加24个空格
    '    opara2.Range.InsertParagraphAfter()


    '    ''插入另外一段
    '    opara3 = odoc.Content.Paragraphs.Add(odoc.Bookmarks.Item("\endoFdoc").Range)
    '    opara3.Range.Text = "这个单纯的文字"
    '    opara3.Range.Font.Bold = False
    '    opara3.Format.SpaceAfter = 24  ''加24个空格
    '    opara3.Range.InsertParagraphAfter()

    '    ''插入表格3*5的表
    '    Dim r As Integer, c As Integer
    '    otable = odoc.Tables.Add(odoc.Bookmarks.Item("\endoFdoc").Range, 3, 5)
    '    otable.Range.ParagraphFormat.SpaceAfter = 6
    '    For r = 1 To 3
    '        For c = 1 To 5
    '            otable.Cell(r, c).Range.Text = "行" & r & "栏" & c
    '        Next
    '    Next
    '    otable.Rows.Item(1).Range.Font.Bold = True
    '    otable.Rows.Item(1).Range.Font.Italic = True
    '    ''在表格加文字
    '    opara4 = odoc.Content.Paragraphs.Add(odoc.Bookmarks.Item("\endoFdoc").Range)
    '    opara4.Range.InsertParagraphBefore()
    '    opara4.Range.Text = "这里是另外一个表格"
    '    opara4.Format.SpaceAfter = 24  ''加24个空格
    '    opara4.Range.InsertParagraphAfter()

    '    ''插入5:2的表格
    '    otable = odoc.Tables.Add(odoc.Bookmarks.Item("\endoFdoc").Range, 5, 2)
    '    otable.Range.ParagraphFormat.SpaceAfter = 6
    '    For r = 1 To 5
    '        For c = 1 To 2
    '            otable.Cell(r, c).Range.Text = "行" & r & "栏" & c
    '        Next
    '    Next
    '    ''更改栏1 与2 的宽度
    '    otable.Columns.Item(1).Width = oword.InchesToPoints(2)
    '    otable.Columns.Item(1).Width = oword.InchesToPoints(3)
    '    ''继续插入文字
    '    pos = oword.InchesToPoints(7)
    '    odoc.Bookmarks.Item("\endofdoc").Range.InsertParagraphAfter()
    '    Do
    '        orng = odoc.Bookmarks.Item("\endofdoc").Range
    '        orng.ParagraphFormat.SpaceAfter = 6
    '        orng.InsertAfter("一行文字")
    '        orng.InsertParagraphAfter()
    '    Loop While pos >= orng.Information(Word.WdInformation.wdVerticalPositionRelativeToPage)
    '    orng.Collapse(Word.WdCollapseDirection.wdCollapseEnd)
    '    orng.InsertBreak(Word.WdBreakType.wdLineBreak)
    '    orng.Collapse(Word.WdCollapseDirection.wdCollapseEnd)
    '    orng.InsertAfter("我们现在位于第二页。以下是我们的图：")
    '    orng.InsertParagraphAfter()

    '    orng = odoc.Bookmarks.Item("\endofdoc").Range
    '    orng.InsertParagraphAfter()
    '    orng.InsertAfter("结束")
    'End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm As New frmMsgBackMoney
        frm.init(_hi, _orderSeqHis)
        frm.ShowDialog()
    End Sub
End Class

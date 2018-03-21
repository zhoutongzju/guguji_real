Public Class Form1
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
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents lblPatientType As System.Windows.Forms.Label
    Friend WithEvents cboPatType As System.Windows.Forms.ComboBox
    Friend WithEvents txtPatID As System.Windows.Forms.TextBox
    Friend WithEvents lblPatID As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblOrderType As System.Windows.Forms.Label
    Friend WithEvents cboOrderType As System.Windows.Forms.ComboBox
    Friend WithEvents lblModality As System.Windows.Forms.Label
    Friend WithEvents cboModality As System.Windows.Forms.ComboBox
    Friend WithEvents cmdTest As System.Windows.Forms.Button
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtPatID = New System.Windows.Forms.TextBox
        Me.cmdTest = New System.Windows.Forms.Button
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.lblPatientType = New System.Windows.Forms.Label
        Me.cboPatType = New System.Windows.Forms.ComboBox
        Me.lblPatID = New System.Windows.Forms.Label
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker
        Me.dtpTo = New System.Windows.Forms.DateTimePicker
        Me.lblOrderType = New System.Windows.Forms.Label
        Me.cboOrderType = New System.Windows.Forms.ComboBox
        Me.lblModality = New System.Windows.Forms.Label
        Me.cboModality = New System.Windows.Forms.ComboBox
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtPatID
        '
        Me.txtPatID.Location = New System.Drawing.Point(16, 88)
        Me.txtPatID.Name = "txtPatID"
        Me.txtPatID.Size = New System.Drawing.Size(184, 21)
        Me.txtPatID.TabIndex = 0
        Me.txtPatID.Text = ""
        '
        'cmdTest
        '
        Me.cmdTest.Font = New System.Drawing.Font("宋体", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.cmdTest.Location = New System.Drawing.Point(16, 312)
        Me.cmdTest.Name = "cmdTest"
        Me.cmdTest.Size = New System.Drawing.Size(184, 72)
        Me.cmdTest.TabIndex = 1
        Me.cmdTest.Text = "测    试"
        '
        'DataGrid1
        '
        Me.DataGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(216, 16)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.Size = New System.Drawing.Size(632, 368)
        Me.DataGrid1.TabIndex = 2
        '
        'lblPatientType
        '
        Me.lblPatientType.AutoSize = True
        Me.lblPatientType.Location = New System.Drawing.Point(16, 24)
        Me.lblPatientType.Name = "lblPatientType"
        Me.lblPatientType.Size = New System.Drawing.Size(60, 17)
        Me.lblPatientType.TabIndex = 3
        Me.lblPatientType.Text = "病人类型:"
        '
        'cboPatType
        '
        Me.cboPatType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPatType.Location = New System.Drawing.Point(16, 40)
        Me.cboPatType.Name = "cboPatType"
        Me.cboPatType.Size = New System.Drawing.Size(184, 20)
        Me.cboPatType.TabIndex = 4
        '
        'lblPatID
        '
        Me.lblPatID.AutoSize = True
        Me.lblPatID.Location = New System.Drawing.Point(16, 72)
        Me.lblPatID.Name = "lblPatID"
        Me.lblPatID.Size = New System.Drawing.Size(35, 17)
        Me.lblPatID.TabIndex = 3
        Me.lblPatID.Text = "ID号:"
        '
        'dtpFrom
        '
        Me.dtpFrom.Location = New System.Drawing.Point(16, 136)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(144, 21)
        Me.dtpFrom.TabIndex = 6
        '
        'dtpTo
        '
        Me.dtpTo.Location = New System.Drawing.Point(56, 168)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(144, 21)
        Me.dtpTo.TabIndex = 6
        '
        'lblOrderType
        '
        Me.lblOrderType.AutoSize = True
        Me.lblOrderType.Location = New System.Drawing.Point(16, 200)
        Me.lblOrderType.Name = "lblOrderType"
        Me.lblOrderType.Size = New System.Drawing.Size(72, 17)
        Me.lblOrderType.TabIndex = 3
        Me.lblOrderType.Text = "检查单类型:"
        '
        'cboOrderType
        '
        Me.cboOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrderType.Location = New System.Drawing.Point(16, 218)
        Me.cboOrderType.Name = "cboOrderType"
        Me.cboOrderType.Size = New System.Drawing.Size(184, 20)
        Me.cboOrderType.TabIndex = 4
        '
        'lblModality
        '
        Me.lblModality.AutoSize = True
        Me.lblModality.Location = New System.Drawing.Point(16, 248)
        Me.lblModality.Name = "lblModality"
        Me.lblModality.Size = New System.Drawing.Size(35, 17)
        Me.lblModality.TabIndex = 3
        Me.lblModality.Text = "模态:"
        '
        'cboModality
        '
        Me.cboModality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboModality.Location = New System.Drawing.Point(16, 266)
        Me.cboModality.Name = "cboModality"
        Me.cboModality.Size = New System.Drawing.Size(184, 20)
        Me.cboModality.TabIndex = 4
        '
        'chkDateRange
        '
        Me.chkDateRange.Checked = True
        Me.chkDateRange.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDateRange.Location = New System.Drawing.Point(16, 112)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.TabIndex = 7
        Me.chkDateRange.Text = "日期范围:"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(864, 398)
        Me.Controls.Add(Me.chkDateRange)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.cboPatType)
        Me.Controls.Add(Me.lblPatientType)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.cmdTest)
        Me.Controls.Add(Me.txtPatID)
        Me.Controls.Add(Me.lblPatID)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.lblOrderType)
        Me.Controls.Add(Me.cboOrderType)
        Me.Controls.Add(Me.lblModality)
        Me.Controls.Add(Me.cboModality)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private hi As New maroland.RIS.SystemInterface.HISInterface

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTest.Click

        Dim dt As DataTable

        Dim a As String = "abc"


        Dim ass() As String = a.Split(";")


        If chkDateRange.Checked Then
            dt = hi.getHISOrderList(CType(cboPatType.SelectedItem, ComboboxItem).Value, _
                                                  txtPatID.Text, _
                                                  Format(dtpFrom.Value, "yyyy-MM-dd"), _
                                                  Format(dtpTo.Value, "yyyy-MM-dd"), _
                                                  CType(cboOrderType.SelectedItem, ComboboxItem).Value, _
                                                  cboModality.Text)
        Else
            dt = hi.getHISOrderList(CType(cboPatType.SelectedItem, ComboboxItem).Value, _
                                      txtPatID.Text, _
                                      "", _
                                      "", _
                                      CType(cboOrderType.SelectedItem, ComboboxItem).Value, _
                                      cboModality.Text)
        End If

        If dt Is Nothing Then
            MessageBox.Show("对不起，没有找到适合条件的结果。", _
                            "HIS Interface Test", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            DataGrid1.DataSource = Nothing
            Return
        End If

        DataGrid1.DataSource = dt

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim itmX As ComboboxItem

        ' fill patient type...
        ' -------------------------------------------------------------------------
        itmX = New ComboboxItem
        itmX.Text = "门诊病人"
        itmX.Value = "O"
        cboPatType.Items.Add(itmX)

        itmX = New ComboboxItem
        itmX.Text = "住院病人"
        itmX.Value = "I"
        cboPatType.Items.Add(itmX)

        itmX = New ComboboxItem
        itmX.Text = "急诊病人"
        itmX.Value = "E"
        cboPatType.Items.Add(itmX)

        itmX = New ComboboxItem
        itmX.Text = "体检病人"
        itmX.Value = "P"
        cboPatType.Items.Add(itmX)

        itmX = New ComboboxItem
        itmX.Text = "复查病人"
        itmX.Value = "F"
        cboPatType.Items.Add(itmX)

        itmX = New ComboboxItem
        itmX.Text = "外院病人"
        itmX.Value = "W"
        cboPatType.Items.Add(itmX)

        itmX = New ComboboxItem
        itmX.Text = "住院急诊"
        itmX.Value = "N"
        cboPatType.Items.Add(itmX)

        cboPatType.SelectedIndex = 0
        ' -------------------------------------------------------------------------

        ' fill order type...
        ' -------------------------------------------------------------------------
        itmX = New ComboboxItem
        itmX.Text = "手工申请单"
        itmX.Value = "1000"
        cboOrderType.Items.Add(itmX)

        itmX = New ComboboxItem
        itmX.Text = "电子申请单"
        itmX.Value = "1001"
        cboOrderType.Items.Add(itmX)

        cboOrderType.SelectedIndex = 0
        ' -------------------------------------------------------------------------

        ' fill modality...
        ' -------------------------------------------------------------------------
        cboModality.Items.Add("CR")
        cboModality.Items.Add("CT")
        cboModality.Items.Add("MR")
        cboModality.Items.Add("RF")
        cboModality.Items.Add("DX")
        cboModality.Items.Add("XA")
        cboModality.Items.Add("US")
        cboModality.Items.Add("ES")
        cboModality.Items.Add("NM")
        cboModality.Items.Add("OT")
        cboModality.SelectedIndex = 0
        ' -------------------------------------------------------------------------

    End Sub

    Private Sub chkDateRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDateRange.CheckedChanged

        dtpFrom.Enabled = chkDateRange.Checked
        dtpTo.Enabled = chkDateRange.Checked

    End Sub
End Class

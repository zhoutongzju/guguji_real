Imports maroland.LogManager
Imports System.Windows.Forms

Public Class frmHisBilling
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
    Friend WithEvents lblSumCharge As System.Windows.Forms.Label
    Friend WithEvents lvBilling As maroland.Base.CListView
    Friend WithEvents colPatName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colExamItem As System.Windows.Forms.ColumnHeader
    Friend WithEvents colChargeCode As System.Windows.Forms.ColumnHeader
    Friend WithEvents colChargeName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colChargeTime As System.Windows.Forms.ColumnHeader
    Friend WithEvents colSL As System.Windows.Forms.ColumnHeader
    Friend WithEvents colDJ As System.Windows.Forms.ColumnHeader
    Friend WithEvents colSum As System.Windows.Forms.ColumnHeader
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmHisBilling))
        Me.lblSumCharge = New System.Windows.Forms.Label
        Me.lvBilling = New maroland.Base.CListView
        Me.colPatName = New System.Windows.Forms.ColumnHeader
        Me.colExamItem = New System.Windows.Forms.ColumnHeader
        Me.colChargeCode = New System.Windows.Forms.ColumnHeader
        Me.colChargeName = New System.Windows.Forms.ColumnHeader
        Me.colChargeTime = New System.Windows.Forms.ColumnHeader
        Me.colSL = New System.Windows.Forms.ColumnHeader
        Me.colDJ = New System.Windows.Forms.ColumnHeader
        Me.colSum = New System.Windows.Forms.ColumnHeader
        Me.SuspendLayout()
        '
        'lblSumCharge
        '
        Me.lblSumCharge.AutoSize = True
        Me.lblSumCharge.Font = New System.Drawing.Font("Verdana", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSumCharge.Location = New System.Drawing.Point(8, 352)
        Me.lblSumCharge.Name = "lblSumCharge"
        Me.lblSumCharge.Size = New System.Drawing.Size(43, 21)
        Me.lblSumCharge.TabIndex = 3
        Me.lblSumCharge.Text = "合计:"
        '
        'lvBilling
        '
        Me.lvBilling.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvBilling.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lvBilling.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colPatName, Me.colExamItem, Me.colChargeCode, Me.colChargeName, Me.colChargeTime, Me.colSL, Me.colDJ, Me.colSum})
        Me.lvBilling.Font = New System.Drawing.Font("Verdana", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvBilling.FullRowSelect = True
        Me.lvBilling.GridLines = True
        Me.lvBilling.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvBilling.Location = New System.Drawing.Point(0, 0)
        Me.lvBilling.MultiSelect = False
        Me.lvBilling.Name = "lvBilling"
        Me.lvBilling.Size = New System.Drawing.Size(744, 352)
        Me.lvBilling.TabIndex = 4
        Me.lvBilling.View = System.Windows.Forms.View.Details
        '
        'colPatName
        '
        Me.colPatName.Text = "姓名"
        Me.colPatName.Width = 120
        '
        'colExamItem
        '
        Me.colExamItem.Text = "检查项目"
        Me.colExamItem.Width = 134
        '
        'colChargeCode
        '
        Me.colChargeCode.Text = "收费代码"
        Me.colChargeCode.Width = 81
        '
        'colChargeName
        '
        Me.colChargeName.Text = "收费名称"
        Me.colChargeName.Width = 100
        '
        'colChargeTime
        '
        Me.colChargeTime.Text = "收费时间"
        Me.colChargeTime.Width = 83
        '
        'colSL
        '
        Me.colSL.Text = "数量"
        '
        'colDJ
        '
        Me.colDJ.Text = "单价"
        '
        'colSum
        '
        Me.colSum.Text = "收费"
        '
        'frmHisBilling
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(744, 374)
        Me.Controls.Add(Me.lvBilling)
        Me.Controls.Add(Me.lblSumCharge)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHisBilling"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "收费细则"
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Function OpenDialog(ByVal dt As DataTable) As Boolean
        Try
            Dim sumCharge As Decimal = 0
            With lvBilling
                .Items.Clear()
                For Each row As DataRow In dt.Rows
                    Dim xItem As ListViewItem = New ListViewItem
                    xItem.Text = dt.Rows(0)("PatName").ToString() 'row.Item("PATNAME").ToString
                    xItem.SubItems.Add(row("ExamItem").ToString())  ''检查项目
                    xItem.SubItems.Add(row("ChargeCode").ToString)   ''
                    xItem.SubItems.Add(row("ChargeName").ToString)
                    xItem.SubItems.Add(row("ChargeTime").ToString)
                    xItem.SubItems.Add(row("ChargeNum").ToString)
                    xItem.SubItems.Add(row("ChargeUnitPrice"))
                    xItem.SubItems.Add((CInt(row("ChargeNum")) * CInt(row("ChargeUnitPrice"))).ToString)
                    .Items.Add(xItem)
                Next
                .AutoSizeColumn()
            End With

            lblSumCharge.Text = "合计收费金额: " & Format(sumCharge, "C")
            Me.ShowDialog()

            Return True
        Catch ex As Exception
            Logger.logError("查看HIS通费记录时发生错误", ex)
            Return False
        End Try
    End Function

End Class

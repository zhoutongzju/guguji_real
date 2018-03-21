Imports maroland.RIS.commonUtility
Imports maroland.RIS.Common

    Public Class frmMsgBackMoney
        Inherits maroland.Base.mlPopupWindow

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
        Friend WithEvents lblPrompt As System.Windows.Forms.Label
    Friend WithEvents TimerAutoClose As System.Windows.Forms.Timer
        Friend WithEvents imgQuestion As System.Windows.Forms.PictureBox
        Friend WithEvents imgInformation As System.Windows.Forms.PictureBox
        Friend WithEvents imgExclamation As System.Windows.Forms.PictureBox
        Friend WithEvents imgCritical As System.Windows.Forms.PictureBox
    Friend WithEvents cmdOK As maroland.Base.mlTextButton
    Friend WithEvents MlTextButton1 As maroland.Base.mlTextButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.imgQuestion = New System.Windows.Forms.PictureBox
        Me.lblPrompt = New System.Windows.Forms.Label
        Me.TimerAutoClose = New System.Windows.Forms.Timer(Me.components)
        Me.imgInformation = New System.Windows.Forms.PictureBox
        Me.imgExclamation = New System.Windows.Forms.PictureBox
        Me.imgCritical = New System.Windows.Forms.PictureBox
        Me.cmdOK = New maroland.Base.mlTextButton
        Me.MlTextButton1 = New maroland.Base.mlTextButton
        Me.SuspendLayout()
        '
        'imgQuestion
        '
        Me.imgQuestion.Location = New System.Drawing.Point(12, 36)
        Me.imgQuestion.Name = "imgQuestion"
        Me.imgQuestion.Size = New System.Drawing.Size(32, 32)
        Me.imgQuestion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgQuestion.TabIndex = 1
        Me.imgQuestion.TabStop = False
        '
        'lblPrompt
        '
        Me.lblPrompt.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrompt.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Me.lblPrompt.Location = New System.Drawing.Point(104, 72)
        Me.lblPrompt.Name = "lblPrompt"
        Me.lblPrompt.Size = New System.Drawing.Size(232, 17)
        Me.lblPrompt.TabIndex = 0
        Me.lblPrompt.Text = "警告：请确认是否允许病人退费！"
        Me.lblPrompt.UseMnemonic = False
        '
        'imgInformation
        '
        Me.imgInformation.BackColor = System.Drawing.Color.FromArgb(CType(232, Byte), CType(232, Byte), CType(232, Byte))
        Me.imgInformation.Location = New System.Drawing.Point(12, 36)
        Me.imgInformation.Name = "imgInformation"
        Me.imgInformation.Size = New System.Drawing.Size(32, 32)
        Me.imgInformation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgInformation.TabIndex = 12
        Me.imgInformation.TabStop = False
        '
        'imgExclamation
        '
        Me.imgExclamation.Location = New System.Drawing.Point(12, 36)
        Me.imgExclamation.Name = "imgExclamation"
        Me.imgExclamation.Size = New System.Drawing.Size(32, 32)
        Me.imgExclamation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgExclamation.TabIndex = 13
        Me.imgExclamation.TabStop = False
        '
        'imgCritical
        '
        Me.imgCritical.Location = New System.Drawing.Point(12, 36)
        Me.imgCritical.Name = "imgCritical"
        Me.imgCritical.Size = New System.Drawing.Size(32, 32)
        Me.imgCritical.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgCritical.TabIndex = 14
        Me.imgCritical.TabStop = False
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.Color.FromArgb(CType(232, Byte), CType(232, Byte), CType(232, Byte))
        Me.cmdOK.BorderStyle = maroland.Base.mlTextButton.emBorderStyle.Java
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOK.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.ForeColor = System.Drawing.Color.Black
        Me.cmdOK.HoverGradientColor2 = System.Drawing.Color.FromArgb(CType(104, Byte), CType(104, Byte), CType(104, Byte))
        Me.cmdOK.HoverGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.cmdOK.Location = New System.Drawing.Point(120, 120)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.NormalGradientColor1 = System.Drawing.Color.FromArgb(CType(249, Byte), CType(249, Byte), CType(249, Byte))
        Me.cmdOK.NormalGradientColor2 = System.Drawing.Color.DimGray
        Me.cmdOK.NormalGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.cmdOK.Size = New System.Drawing.Size(75, 28)
        Me.cmdOK.TabIndex = 3
        Me.cmdOK.Text = "确定[&O]"
        '
        'MlTextButton1
        '
        Me.MlTextButton1.BackColor = System.Drawing.Color.FromArgb(CType(232, Byte), CType(232, Byte), CType(232, Byte))
        Me.MlTextButton1.BorderStyle = maroland.Base.mlTextButton.emBorderStyle.Java
        Me.MlTextButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MlTextButton1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.MlTextButton1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MlTextButton1.ForeColor = System.Drawing.Color.Black
        Me.MlTextButton1.HoverGradientColor2 = System.Drawing.Color.FromArgb(CType(104, Byte), CType(104, Byte), CType(104, Byte))
        Me.MlTextButton1.HoverGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.MlTextButton1.Location = New System.Drawing.Point(224, 120)
        Me.MlTextButton1.Name = "MlTextButton1"
        Me.MlTextButton1.NormalGradientColor1 = System.Drawing.Color.FromArgb(CType(249, Byte), CType(249, Byte), CType(249, Byte))
        Me.MlTextButton1.NormalGradientColor2 = System.Drawing.Color.DimGray
        Me.MlTextButton1.NormalGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.MlTextButton1.Size = New System.Drawing.Size(75, 28)
        Me.MlTextButton1.TabIndex = 15
        Me.MlTextButton1.Text = "取消[&C]"
        '
        'frmMsgBackMoney
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(232, Byte), CType(232, Byte), CType(232, Byte))
        Me.ClientSize = New System.Drawing.Size(452, 176)
        Me.CloseButton = False
        Me.Controls.Add(Me.MlTextButton1)
        Me.Controls.Add(Me.imgExclamation)
        Me.Controls.Add(Me.imgInformation)
        Me.Controls.Add(Me.imgQuestion)
        Me.Controls.Add(Me.imgCritical)
        Me.Controls.Add(Me.lblPrompt)
        Me.Controls.Add(Me.cmdOK)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Moveable = True
        Me.Name = "frmMsgBackMoney"
        Me.Text = "maroland HIS"
        Me.WindowCaption = "maroland HIS"
        Me.Controls.SetChildIndex(Me.cmdOK, 0)
        Me.Controls.SetChildIndex(Me.lblPrompt, 0)
        Me.Controls.SetChildIndex(Me.imgCritical, 0)
        Me.Controls.SetChildIndex(Me.imgQuestion, 0)
        Me.Controls.SetChildIndex(Me.imgInformation, 0)
        Me.Controls.SetChildIndex(Me.imgExclamation, 0)
        Me.Controls.SetChildIndex(Me.MlTextButton1, 0)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private _hi As HISInterface
    Private _orderseq As String

    Public Sub init(ByRef hi As HISInterface, ByVal orderseq As String)
        _hi = hi
        _orderseq = orderseq
    End Sub


    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim b As Boolean = _hi.postRISOrderDeleted(_orderseq)
        Dim frm As New frmMessageBox
        If True = b Then
            frm.init("退费成功")
        Else
            frm.init("退费失败，未找到该标识，请联系HIS厂家")
        End If
        frm.ShowDialog()
        Me.Close()
    End Sub

    Private Sub MlTextButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MlTextButton1.Click
        Me.Close()
    End Sub
End Class

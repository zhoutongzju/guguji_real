Imports System.Xml
Imports System.Text
Imports System.Windows.Forms
Imports System.Data.OracleClient
Imports System
Imports maroland.RIS.SystemInterface.Common
Imports maroland.RIS.commonUtility
Imports maroland.RIS.commonUtility.globalHelper
Imports maroland.RIS.commonUtility.globalConst


Public Class frmPatientList
    Inherits System.Windows.Forms.Form

#Region " Windows ������������ɵĴ��� "

    Public Sub New()
        MyBase.New()

        '�õ����� Windows ���������������ġ�
        InitializeComponent()

        '�� InitializeComponent() ����֮������κγ�ʼ��

    End Sub

    '������д dispose ����������б�
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows ����������������
    Private components As System.ComponentModel.IContainer

    'ע��: ���¹����� Windows ����������������
    '����ʹ�� Windows ����������޸Ĵ˹��̡�
    '��Ҫʹ�ô���༭���޸�����
    Friend WithEvents colOrderDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents colPatName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colEmergency As System.Windows.Forms.ColumnHeader
    Friend WithEvents colWard As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMedicalID As System.Windows.Forms.ColumnHeader
    Friend WithEvents colAge As System.Windows.Forms.ColumnHeader
    Friend WithEvents colModality As System.Windows.Forms.ColumnHeader
    Friend WithEvents colSex As System.Windows.Forms.ColumnHeader
    Friend WithEvents colOrderDr As System.Windows.Forms.ColumnHeader
    Friend WithEvents colExamItem As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader21 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader22 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader23 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader24 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader25 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader26 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader27 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader28 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader29 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader30 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnView As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lvPatient As maroland.Base.CListView
    Friend WithEvents colOrderdt As System.Windows.Forms.ColumnHeader
    Friend WithEvents colName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colPatSex As System.Windows.Forms.ColumnHeader
    Friend WithEvents colPatID As System.Windows.Forms.ColumnHeader
    Friend WithEvents colModaltity As System.Windows.Forms.ColumnHeader
    Friend WithEvents colDoctor As System.Windows.Forms.ColumnHeader
    Friend WithEvents colExam As System.Windows.Forms.ColumnHeader
    Friend WithEvents colPatWard As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnBill As System.Windows.Forms.Button
    Friend WithEvents colBen As System.Windows.Forms.ColumnHeader
    Friend WithEvents colDept As System.Windows.Forms.ColumnHeader
    Friend WithEvents colPatBri As System.Windows.Forms.ColumnHeader
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPatientList))
        Me.colOrderDate = New System.Windows.Forms.ColumnHeader
        Me.colPatName = New System.Windows.Forms.ColumnHeader
        Me.colEmergency = New System.Windows.Forms.ColumnHeader
        Me.colWard = New System.Windows.Forms.ColumnHeader
        Me.colMedicalID = New System.Windows.Forms.ColumnHeader
        Me.colAge = New System.Windows.Forms.ColumnHeader
        Me.colModality = New System.Windows.Forms.ColumnHeader
        Me.colSex = New System.Windows.Forms.ColumnHeader
        Me.colOrderDr = New System.Windows.Forms.ColumnHeader
        Me.colExamItem = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader9 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader10 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader11 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader12 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader13 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader14 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader15 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader16 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader17 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader18 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader19 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader20 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader21 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader22 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader23 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader24 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader25 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader26 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader27 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader28 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader29 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader30 = New System.Windows.Forms.ColumnHeader
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lvPatient = New maroland.Base.CListView
        Me.colOrderdt = New System.Windows.Forms.ColumnHeader
        Me.colName = New System.Windows.Forms.ColumnHeader
        Me.colPatSex = New System.Windows.Forms.ColumnHeader
        Me.colPatBri = New System.Windows.Forms.ColumnHeader
        Me.colPatID = New System.Windows.Forms.ColumnHeader
        Me.colModaltity = New System.Windows.Forms.ColumnHeader
        Me.colDept = New System.Windows.Forms.ColumnHeader
        Me.colDoctor = New System.Windows.Forms.ColumnHeader
        Me.colExam = New System.Windows.Forms.ColumnHeader
        Me.colPatWard = New System.Windows.Forms.ColumnHeader
        Me.colBen = New System.Windows.Forms.ColumnHeader
        Me.btnView = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnBill = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'colOrderDate
        '
        Me.colOrderDate.Text = "����"
        Me.colOrderDate.Width = 73
        '
        'colPatName
        '
        Me.colPatName.Text = "��������"
        Me.colPatName.Width = 90
        '
        'colEmergency
        '
        Me.colEmergency.Text = "����"
        Me.colEmergency.Width = 80
        '
        'colWard
        '
        Me.colWard.Text = "��������"
        Me.colWard.Width = 90
        '
        'colMedicalID
        '
        Me.colMedicalID.Text = "����/סԺ��"
        Me.colMedicalID.Width = 120
        '
        'colAge
        '
        Me.colAge.Text = "����"
        '
        'colModality
        '
        Me.colModality.Text = "ģ̬"
        '
        'colSex
        '
        Me.colSex.Text = "�Ա�"
        '
        'colOrderDr
        '
        Me.colOrderDr.Text = "����ҽ��"
        Me.colOrderDr.Width = 80
        '
        'colExamItem
        '
        Me.colExamItem.Text = "�����Ŀ"
        Me.colExamItem.Width = 86
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "����"
        Me.ColumnHeader1.Width = 73
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "��������"
        Me.ColumnHeader2.Width = 90
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "����"
        Me.ColumnHeader3.Width = 80
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "��������"
        Me.ColumnHeader4.Width = 90
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "����/סԺ��"
        Me.ColumnHeader5.Width = 120
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "����"
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "ģ̬"
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "�Ա�"
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "����ҽ��"
        Me.ColumnHeader9.Width = 80
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "�����Ŀ"
        Me.ColumnHeader10.Width = 86
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "����"
        Me.ColumnHeader11.Width = 73
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "��������"
        Me.ColumnHeader12.Width = 90
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "����"
        Me.ColumnHeader13.Width = 80
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "��������"
        Me.ColumnHeader14.Width = 90
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "����/סԺ��"
        Me.ColumnHeader15.Width = 120
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "����"
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "ģ̬"
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "�Ա�"
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "����ҽ��"
        Me.ColumnHeader19.Width = 80
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "�����Ŀ"
        Me.ColumnHeader20.Width = 86
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "����"
        Me.ColumnHeader21.Width = 73
        '
        'ColumnHeader22
        '
        Me.ColumnHeader22.Text = "��������"
        Me.ColumnHeader22.Width = 90
        '
        'ColumnHeader23
        '
        Me.ColumnHeader23.Text = "����"
        Me.ColumnHeader23.Width = 80
        '
        'ColumnHeader24
        '
        Me.ColumnHeader24.Text = "��������"
        Me.ColumnHeader24.Width = 90
        '
        'ColumnHeader25
        '
        Me.ColumnHeader25.Text = "����/סԺ��"
        Me.ColumnHeader25.Width = 120
        '
        'ColumnHeader26
        '
        Me.ColumnHeader26.Text = "����"
        '
        'ColumnHeader27
        '
        Me.ColumnHeader27.Text = "ģ̬"
        '
        'ColumnHeader28
        '
        Me.ColumnHeader28.Text = "�Ա�"
        '
        'ColumnHeader29
        '
        Me.ColumnHeader29.Text = "����ҽ��"
        Me.ColumnHeader29.Width = 80
        '
        'ColumnHeader30
        '
        Me.ColumnHeader30.Text = "�����Ŀ"
        Me.ColumnHeader30.Width = 86
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lvPatient)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(968, 448)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "��ѡ����Ҫ�Ǽǵ����뵥"
        '
        'lvPatient
        '
        Me.lvPatient.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvPatient.BackColor = System.Drawing.Color.White
        Me.lvPatient.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colOrderdt, Me.colName, Me.colPatSex, Me.colPatBri, Me.colPatID, Me.colModaltity, Me.colDept, Me.colDoctor, Me.colExam, Me.colPatWard, Me.colBen})
        Me.lvPatient.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvPatient.FullRowSelect = True
        Me.lvPatient.GridLines = True
        Me.lvPatient.HideSelection = False
        Me.lvPatient.Location = New System.Drawing.Point(8, 16)
        Me.lvPatient.MultiSelect = False
        Me.lvPatient.Name = "lvPatient"
        Me.lvPatient.Size = New System.Drawing.Size(952, 424)
        Me.lvPatient.TabIndex = 1
        Me.lvPatient.View = System.Windows.Forms.View.Details
        '
        'colOrderdt
        '
        Me.colOrderdt.Text = "����"
        Me.colOrderdt.Width = 75
        '
        'colName
        '
        Me.colName.Text = "����"
        Me.colName.Width = 80
        '
        'colPatSex
        '
        Me.colPatSex.Text = "�Ա�"
        Me.colPatSex.Width = 50
        '
        'colPatBri
        '
        Me.colPatBri.Text = "��������"
        Me.colPatBri.Width = 100
        '
        'colPatID
        '
        Me.colPatID.Text = "����/סԺ��"
        Me.colPatID.Width = 120
        '
        'colModaltity
        '
        Me.colModaltity.Text = "����"
        '
        'colDept
        '
        Me.colDept.Text = "�ͼ����"
        Me.colDept.Width = 80
        '
        'colDoctor
        '
        Me.colDoctor.Text = "�ͼ�ҽ��"
        Me.colDoctor.Width = 80
        '
        'colExam
        '
        Me.colExam.Text = "�����Ŀ"
        Me.colExam.Width = 120
        '
        'colPatWard
        '
        Me.colPatWard.Text = "��������"
        Me.colPatWard.Width = 80
        '
        'colBen
        '
        Me.colBen.Text = "����"
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(616, 472)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(128, 23)
        Me.btnView.TabIndex = 2
        Me.btnView.Text = "�鿴���뵥[&Z]"
        Me.btnView.Visible = False
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(776, 472)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 24)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "ȷ��[&Y]"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(888, 472)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 24)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "ȡ��[&N]"
        '
        'btnBill
        '
        Me.btnBill.Location = New System.Drawing.Point(456, 472)
        Me.btnBill.Name = "btnBill"
        Me.btnBill.Size = New System.Drawing.Size(128, 23)
        Me.btnBill.TabIndex = 5
        Me.btnBill.Text = "�鿴�շ���ϸ[&C]"
        Me.btnBill.Visible = False
        '
        'frmPatientList
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(992, 510)
        Me.Controls.Add(Me.btnBill)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnView)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPatientList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "�Ǽ��б�"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " ���ñ������� "

    Private _dt As DataTable
    Private _sPatType As String
    Private _hi As HISInterface
    Private _temp As DataTable
    Private _his_id As String
    Private _sExamCode As String
    Private _moidality As String

    Public _nChoose As Integer = 0

#End Region

    Public Function getOrderList(ByRef dt As DataTable, _
                                 ByVal patType As String, _
                                 ByRef hi As HISInterface) As DataTable
        _dt = dt
        _hi = hi
        _sPatType = patType
        _temp = dt.Clone

        logger.logError("getOrderListģ̬" + dt.Rows(0)("MODALITY").ToString)
        _moidality = dt.Rows(0)("MODALITY").ToString

        If 1 = _nChoose Then
            lvPatient.MultiSelect = True
        Else
            lvPatient.MultiSelect = False
        End If

        fillHISOrderList(dt)
        Me.ShowDialog()
        Return _temp
    End Function

    Private Function fillHISOrderList(ByVal dt As DataTable) As Boolean
        Dim sExam(lvPatient.Columns.Count - 1) As String
        Dim lv As ListViewItem
        lvPatient.Items.Clear()
        Try
            lvPatient.BeginUpdate()
            logger.logError("��õ��ӵ�" + dt.Rows.Count.ToString + "��")
            For Each row As DataRow In dt.Rows
                Try
                    If Not Convert.IsDBNull(row.Item("ORDERDT")) AndAlso Not row.Item("ORDERDT") Is Nothing Then
                        sExam(colOrderdt.Index) = Format(CDate(row.Item("ORDERDT")), "yyyy-MM-dd HH:mm:ss")
                    Else
                        logger.logError("����ʱ��Ϊ�գ��޷���ʾ")
                    End If
                Catch ex As Exception
                    logger.logError("����ʱ��ת��ʧ�ܣ��޷���ʾ")
                End Try

                sExam(colName.Index) = row.Item("PATNAME").ToString.Trim

                If _sPatType = "P" Then
                    sExam(colModaltity.Index) = "���"
                    sExam(colPatID.Index) = row.Item("PHYSICALEXAMID").ToString.Trim
                    Me.btnBill.Visible = False
                    Me.btnView.Visible = False
                ElseIf _sPatType = "I" Then
                    sExam(Me.colPatID.Index) = row.Item("INPATIENTID").ToString.Trim
                    '�Ƿ���
                    If _sPatType = "N" Then
                        sExam(colModaltity.Index) = "סԺ����"
                    Else
                        sExam(colModaltity.Index) = "סԺ"
                    End If
                    sExam(Me.colPatWard.Index) = row.Item("WARD").ToString.Trim
                    sExam(colBen.Index) = row.Item("BEDNO").ToString.Trim
                    Me.btnBill.Visible = False
                ElseIf _sPatType = "O" Then
                    sExam(colPatID.Index) = row.Item("OUTPATIENTID").ToString.Trim
                    '�Ƿ���
                    If _sPatType = "E" Then
                        sExam(colModaltity.Index) = "���Ｑ��"
                    Else
                        sExam(colModaltity.Index) = "����"
                    End If
                End If
                If Not IsDBNull(row.Item("PATAGE")) Then
                    sExam(colPatBri.Index) = row.Item("PatBirthday").ToString.Trim
                Else
                    sExam(colPatBri.Index) = String.Empty
                End If

                sExam(colPatSex.Index) = _
                        getPatientSexByCode(getPatSexCodeByName(row.Item("PATSEX").ToString.Trim))
                sExam(Me.colDoctor.Index) = row.Item("ORDERDR").ToString.Trim
                'sExam(Me.colexamcode.Index) = row.Item("EXAMITEMID").ToString.Trim
                sExam(Me.colExam.Index) = row.Item("EXAMITEM").ToString.Trim
                sExam(Me.colDept.Index) = row.Item("CLINIC").ToString.Trim

                lv = New ListViewItem(sExam)
                If _sPatType = "N" Or _sPatType = "E" Then
                    lv.ForeColor = System.Drawing.Color.Red
                End If

                lv.Tag = row.Item("HIS_ID").ToString
                _his_id = row.Item("HIS_ID").ToString
                _sExamCode = row.Item("EXAMITEMID").ToString.Trim
                lvPatient.Items.Add(lv)
            Next
            lvPatient.AutoSizeColumn()
            lvPatient.EndUpdate()
            If lvPatient.Items.Count > 0 Then
                lvPatient.Items(0).Selected = True
                lvPatient.Focus()
            End If
            Return True
        Catch ex As Exception
            logger.logError("��ʾ���ӵ��б��쳣", ex)
            Return False
        End Try
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        _temp.Clear()
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        Try
            If (lvPatient.SelectedItems.Count = 0) Then
                MessageBox.Show("��ѡ��һ���������Ǽǲ�����", "�Ǽ���ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            _temp.Clear()

            Dim nSelItemCount As Integer = lvPatient.SelectedItems.Count
            Dim i As Integer = 0
            Dim dicHisID As New Hashtable
            For i = 0 To nSelItemCount - 1
                Dim rows As DataRow() = _dt.Select("HIS_ID='" & lvPatient.SelectedItems(i).Tag.ToString & "'")
                If rows Is Nothing OrElse rows.Length = 0 Then Return
                If dicHisID.ContainsKey(lvPatient.SelectedItems(i).Tag.ToString) = False Then
                    dicHisID.Add(lvPatient.SelectedItems(i).Tag.ToString, "hisID")
                    Dim iIndex As Integer = 0
                    For iIndex = 0 To rows.Length - 1
                        Dim row As DataRow = rows(iIndex)
                        Dim sArray() As String = row.Item("ExamItemID").ToString().Replace(",", ";").Replace("*", ";").Replace("��", ";").Replace("��", ";").Split(";")
                        Dim iCount As Integer
                        Dim sArrayExam() As String = row.Item("ExamItem").ToString().Replace(",", ";").Replace("*", ";").Replace("��", ";").Replace("��", ";").Split(";")
                        For iCount = 0 To sArray.Length - 1
                            Dim examitem As String
                            Dim rowNew As DataRow = _temp.NewRow
                            ' �ҵ�ƥ���RIS�����Ŀ���룬�滻
                            rowNew.ItemArray = row.ItemArray
                            rowNew("HIS_ID") = row.Item("his_id")
                            rowNew("EXAMITEMID") = sArray(iCount)
                            rowNew("EXAMITEM") = sArrayExam(iCount)
                            _temp.Rows.Add(rowNew)
                        Next
                    Next
                    
                End If
            Next
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("ȷ��ʧ��", ex.Message)
            Common.logger.logError("ȷ��ʧ��", ex)
        End Try
    End Sub

    Private Sub btnBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBill.Click
        _hi.GetCharge(lvPatient.SelectedItems(0).Tag.ToString, _sPatType, _moidality)
    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        _hi.viewApplication(_his_id)
    End Sub

    Private Sub lvPatient_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvPatient.DoubleClick
        btnOK_Click(sender, e)
    End Sub

    Private Sub lvPatient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvPatient.Click
        Dim rows As DataRow() = _dt.Select("HIS_ID='" & lvPatient.SelectedItems(0).Tag.ToString & "'")
        If rows Is Nothing Then Return
        Dim row As DataRow = rows(0)
        _his_id = row.Item("his_id")
    End Sub
End Class

Imports System.Configuration

Public Class Common

#Region " public shared consts "
    ' // ģ̬��������
    Public Const g_c_Modality_CR As String = "CR"
    Public Const g_c_Modality_DX As String = "DX"
    Public Const g_c_Modality_CT As String = "CT"
    Public Const g_c_Modality_MR As String = "MR"
    Public Const g_c_Modality_RG As String = "RG"
    Public Const g_c_Modality_RF As String = "RF"
    Public Const g_c_Modality_XA As String = "XA"
    Public Const g_c_Modality_US As String = "US"
    Public Const g_c_Modality_ES As String = "ES"
    Public Const g_c_Modality_OT As String = "OT"
    Public Const g_c_Modality_SC As String = "SC"
    Public Const g_c_Modality_NM As String = "NM"
    Public Const g_c_Modality_MG As String = "MG"

    ' // �Ա���������볣������
    Public Const g_c_Patient_Sex_Code_Male As String = "M"
    Public Const g_c_Patient_Sex_Code_Female As String = "F"
    Public Const g_c_Patient_Sex_Code_Unknown As String = "O"

    Public Const g_c_Patient_Sex_Name_Male As String = "��"
    Public Const g_c_Patient_Sex_Name_Female As String = "Ů"
    Public Const g_c_Patient_Sex_Name_Unknown As String = "δ֪"

    ' // ����������������볣������
    Public Const g_c_Patient_Type_Code_Outpatient As String = "O"
    Public Const g_c_Patient_Type_Code_Inpatient As String = "I"
    Public Const g_c_Patient_Type_Code_Emergency As String = "E"
    Public Const g_c_Patient_Type_Code_OtherHospital As String = "W"
    Public Const g_c_Patient_Type_Code_ReExamPatient As String = "F"
    Public Const g_c_Patient_Type_Code_PhisicalExam As String = "P"
    Public Const g_c_Patient_Type_Code_InpatientEmergency As String = "N"

    Public Const g_c_Patient_Type_Name_Outpatient As String = "���ﲡ��"
    Public Const g_c_Patient_Type_Name_Inpatient As String = "סԺ����"
    Public Const g_c_Patient_Type_Name_Emergency As String = "���ﲡ��"
    Public Const g_c_Patient_Type_Name_OtherHospital As String = "��Ժ����"
    Public Const g_c_Patient_Type_Name_ReExamPatient As String = "���鲡��"
    Public Const g_c_Patient_Type_Name_PhisicalExam As String = "��첡��"
    Public Const g_c_Patient_Type_Name_InpatientEmergency As String = "סԺ���ﲡ��"
    Public Const g_c_Patient_Type_Name_Unknown As String = "δ֪��Դ"

    Public Const g_c_Patient_Type_Name_Outpatient2 As String = "����"
    Public Const g_c_Patient_Type_Name_Inpatient2 As String = "סԺ"
    Public Const g_c_Patient_Type_Name_Emergency2 As String = "����"
    Public Const g_c_Patient_Type_Name_OtherHospital2 As String = "��Ժ"
    Public Const g_c_Patient_Type_Name_ReExamPatient2 As String = "����"
    Public Const g_c_Patient_Type_Name_PhisicalExam2 As String = "���"
    Public Const g_c_Patient_Type_Name_InpatientEmergency2 As String = "סԺ����"
    Public Const g_c_Patient_Type_Name_Unknown2 As String = "δ֪"
#End Region

#Region " public shared functions "
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' ��ȡApp.Config�������õĺ���
    ''' </summary>
    ''' <param name="keyName"></param>
    ''' <param name="defaultValue"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[fangx]	2006-8-23	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function getAppSetting(ByVal keyName As String, Optional ByVal defaultValue As String = Nothing) As String

        If keyName Is Nothing Then Return Nothing

        keyName = keyName.Trim

        If keyName.Trim.Length = 0 Then Return Nothing

        Dim settingValue As String = String.Empty

        Try
            settingValue = ConfigurationSettings.AppSettings(keyName)
        Catch ex As Exception
            ' do nothing here...
        End Try

        If settingValue Is Nothing Then
            If Not defaultValue Is Nothing Then
                Return defaultValue
            End If
        End If

        If settingValue.Length = 0 Then
            If Not defaultValue Is Nothing Then
                Return defaultValue
            End If
        Else
            Return settingValue
        End If

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' �ж�ָ���ַ����Ƿ������ָ����ArrayList��
    ''' </summary>
    ''' <param name="aArray">ָ����ArrayList</param>
    ''' <param name="sString">ָ���ַ���</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[fangx]	2005-11-17	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ExistInArray(ByRef aArray As ArrayList, ByVal sString As String) As Boolean

        Dim i As Integer

        For i = 0 To aArray.Count - 1
            If CType(aArray.Item(i), String) = sString Then
                Return True
                Exit For
            End If
        Next

        Return False

    End Function


    ''�����ת��
    Public Shared Function birthdayToAge(ByVal sBirthday As String, Optional ByVal sStartDate As String = "") As String

        On Error GoTo invalidBirthday

        sBirthday = sBirthday.Trim
        sStartDate = sStartDate.Trim
        If sBirthday.Length = 0 Then GoTo invalidBirthday
        If sStartDate.Length = 0 Then sStartDate = Format(Now, "yyyy-MM-dd")

        Dim ageYears As Integer

        ' �ж�����Ϸ���-�Ƿ�����ȷ�����ڸ�ʽ
        If CDate(sBirthday) = CDate("1900-01-01 00:00:00") Then GoTo invalidBirthday
        If CDate(sStartDate) = CDate("1900-01-01 00:00:00") Then GoTo invalidBirthday
        ' �ж�-�Ƿ������ʼʱ��
        If CDate(sBirthday) > CDate(sStartDate) Then GoTo invalidBirthday

        ' �õ�2��ʱ��Ĳ��
        ageYears = DateDiff("yyyy", CDate(sBirthday), CDate(sStartDate))
        ' �ж��Ƿ񳬹���ϵͳ������������
        If ageYears > CInt(getAppSetting("MaxAge_Years")) Then GoTo invalidBirthday

        Return ageYears.ToString

invalidBirthday:
        Return String.Empty

    End Function

#End Region

#Region " public shared object "
    ' a public log4net.Ilog for common call.
    Public Shared logger As maroland.LogManager.Logger = maroland.LogManager.Logger.Instance()
#End Region

    '�������ת��
    'Public Shared Function GetModality(ByVal modal As String) As String
    '    If modal Is Nothing Then Return ""
    '    If modal.Trim() = "CT" Then
    '        Return "CT"
    '    ElseIf modal.Trim() = "CR" Then
    '        Return "CR"
    '    ElseIf modal.Trim() = "DR" Then
    '        Return "DR"
    '    ElseIf modal.Trim() = "DX" Then
    '        Return "DR"
    '    ElseIf modal.Trim() = "ES" Then
    '        Return "ES"
    '    ElseIf modal.Trim() = "MR" Then
    '        Return "�Ź���"
    '    ElseIf modal.Trim() = "US" Then
    '        Return "B��"
    '    Else
    '        Return modal
    '    End If
    'End Function

End Class

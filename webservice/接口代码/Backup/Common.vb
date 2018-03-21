Imports System.Configuration

Public Class Common

#Region " public shared consts "
    ' // 模态常数定义
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

    ' // 性别名称与代码常数定义
    Public Const g_c_Patient_Sex_Code_Male As String = "M"
    Public Const g_c_Patient_Sex_Code_Female As String = "F"
    Public Const g_c_Patient_Sex_Code_Unknown As String = "O"

    Public Const g_c_Patient_Sex_Name_Male As String = "男"
    Public Const g_c_Patient_Sex_Name_Female As String = "女"
    Public Const g_c_Patient_Sex_Name_Unknown As String = "未知"

    ' // 病人类型名称与代码常数定义
    Public Const g_c_Patient_Type_Code_Outpatient As String = "O"
    Public Const g_c_Patient_Type_Code_Inpatient As String = "I"
    Public Const g_c_Patient_Type_Code_Emergency As String = "E"
    Public Const g_c_Patient_Type_Code_OtherHospital As String = "W"
    Public Const g_c_Patient_Type_Code_ReExamPatient As String = "F"
    Public Const g_c_Patient_Type_Code_PhisicalExam As String = "P"
    Public Const g_c_Patient_Type_Code_InpatientEmergency As String = "N"

    Public Const g_c_Patient_Type_Name_Outpatient As String = "门诊病人"
    Public Const g_c_Patient_Type_Name_Inpatient As String = "住院病人"
    Public Const g_c_Patient_Type_Name_Emergency As String = "急诊病人"
    Public Const g_c_Patient_Type_Name_OtherHospital As String = "外院病人"
    Public Const g_c_Patient_Type_Name_ReExamPatient As String = "复查病人"
    Public Const g_c_Patient_Type_Name_PhisicalExam As String = "体检病人"
    Public Const g_c_Patient_Type_Name_InpatientEmergency As String = "住院急诊病人"
    Public Const g_c_Patient_Type_Name_Unknown As String = "未知来源"

    Public Const g_c_Patient_Type_Name_Outpatient2 As String = "门诊"
    Public Const g_c_Patient_Type_Name_Inpatient2 As String = "住院"
    Public Const g_c_Patient_Type_Name_Emergency2 As String = "急诊"
    Public Const g_c_Patient_Type_Name_OtherHospital2 As String = "外院"
    Public Const g_c_Patient_Type_Name_ReExamPatient2 As String = "复查"
    Public Const g_c_Patient_Type_Name_PhisicalExam2 As String = "体检"
    Public Const g_c_Patient_Type_Name_InpatientEmergency2 As String = "住院急诊"
    Public Const g_c_Patient_Type_Name_Unknown2 As String = "未知"
#End Region

#Region " public shared functions "
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 获取App.Config参数设置的函数
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
    ''' 判断指定字符串是否存在于指定的ArrayList内
    ''' </summary>
    ''' <param name="aArray">指定的ArrayList</param>
    ''' <param name="sString">指定字符串</param>
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


    ''年龄的转换
    Public Shared Function birthdayToAge(ByVal sBirthday As String, Optional ByVal sStartDate As String = "") As String

        On Error GoTo invalidBirthday

        sBirthday = sBirthday.Trim
        sStartDate = sStartDate.Trim
        If sBirthday.Length = 0 Then GoTo invalidBirthday
        If sStartDate.Length = 0 Then sStartDate = Format(Now, "yyyy-MM-dd")

        Dim ageYears As Integer

        ' 判断输入合法性-是否是正确的日期格式
        If CDate(sBirthday) = CDate("1900-01-01 00:00:00") Then GoTo invalidBirthday
        If CDate(sStartDate) = CDate("1900-01-01 00:00:00") Then GoTo invalidBirthday
        ' 判断-是否大于起始时间
        If CDate(sBirthday) > CDate(sStartDate) Then GoTo invalidBirthday

        ' 得到2个时间的差距
        ageYears = DateDiff("yyyy", CDate(sBirthday), CDate(sStartDate))
        ' 判断是否超过了系统允许的最大年龄
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

    '检查类型转换
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
    '        Return "磁共振"
    '    ElseIf modal.Trim() = "US" Then
    '        Return "B超"
    '    Else
    '        Return modal
    '    End If
    'End Function

End Class

Imports mindray.FtpClient

Public Class FtpClientHelper

    Public Shared Function DownloadFile(ByRef remoteFile As String, ByRef localFile As String) As Boolean

        Try
            '读取ftp服务器配置：ip，用户名和密码
            Dim FtpServer As String = ""
            Dim FtpUser As String = ""
            Dim FtpPw As String = ""
            ParseConfigParams(FtpServer, FtpUser, FtpPw)
            Dim ret As Boolean = mindray.FtpClient.Helper.DownloadFile(remoteFile, localFile, FtpServer, FtpUser, FtpPw, 21)
            Return ret

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Shared Function Exists(ByRef fileName As String) As Boolean
        Try
            '读取ftp服务器配置：ip，用户名和密码
            Dim FtpServer As String = ""
            Dim FtpUser As String = ""
            Dim FtpPw As String = ""
            ParseConfigParams(FtpServer, FtpUser, FtpPw)
            Dim ret As Boolean = mindray.FtpClient.Helper.IsFileExist(fileName, FtpServer, FtpUser, FtpPw, 21)
            Return ret

        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Shared Function UploadFile(ByRef localFile As String, ByRef remoteFile As String) As Boolean

        Try
            '读取ftp服务器配置：ip，用户名和密码
            Dim FtpServer As String = ""
            Dim FtpUser As String = ""
            Dim FtpPw As String = ""
            ParseConfigParams(FtpServer, FtpUser, FtpPw)
            Dim ret As Boolean = mindray.FtpClient.Helper.UploadFileEx(localFile, remoteFile, FtpServer, FtpUser, FtpPw, 21)
            Return ret

        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Shared Function ParseConfigParams(ByRef ftpServer As String, ByRef ftpUser As String, ByRef ftpPw As String)
        Dim temp = System.Configuration.ConfigurationSettings.AppSettings("OPImageStorage").Trim
        Dim slash As Integer = InStrRev(temp, "\")
        ftpServer = Mid(temp, 3, slash - 3)
        ftpUser = System.Configuration.ConfigurationSettings.AppSettings("OPISAccessUser").Trim
        ftpPw = System.Configuration.ConfigurationSettings.AppSettings("OPISAccessPwd").Trim
    End Function
End Class

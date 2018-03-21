Public Class ComboboxItem

    Private mText As String = String.Empty
    Private mValue As String = String.Empty
    Private mCode As String = String.Empty
    Private mSRM As String = String.Empty
    Private _sTag As String = String.Empty

    Public Property Text() As String
        Get
            Return mText
        End Get
        Set(ByVal Value As String)
            mText = Value
        End Set
    End Property

    Public Property Value() As String
        Get
            Return mValue
        End Get
        Set(ByVal Value As String)
            mValue = Value
        End Set
    End Property

    Public Property Code() As String
        Get
            Return mCode
        End Get
        Set(ByVal Value As String)
            mCode = Value
        End Set
    End Property

    Public Property SRM() As String
        Get
            Return mSRM
        End Get
        Set(ByVal Value As String)
            mSRM = Value
        End Set
    End Property

    Public Property Tag() As String
        Get
            Return _sTag
        End Get
        Set(ByVal Value As String)
            _sTag = Value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return mText
    End Function

End Class

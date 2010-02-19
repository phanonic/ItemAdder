Public Class realms
    Public realmname As String
    Public realmlist As String
    Public realmid As String
    Public Shared Function createrealm(ByVal realmname As String, ByVal realmlist As String, Optional ByVal realmid As String = "-1") As realms
        Dim objrealms As New realms
        objrealms.realmname = realmname
        objrealms.realmlist = realmlist
        If realmid <> "-1" Then
            objrealms.realmid = realmid
        Else
            objrealms.realmid = "0"
        End If
        Return objrealms
    End Function
End Class

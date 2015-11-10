
Partial Class Master
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblCurrentUser.Text = Session("strUsername")
    End Sub

    Public Property CurrentUser() As String
        Get
            Return lblCurrentUser.Text
        End Get
        Set(ByVal value As String)
            lblCurrentUser.Text = value
        End Set
    End Property

    Protected Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        Session.Clear()
        Session.Abandon()
        Response.Redirect("Login.aspx")
    End Sub
End Class


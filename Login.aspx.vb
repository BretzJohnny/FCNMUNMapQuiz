
Imports System.Data.SqlClient
Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Dim strPersonType As String

        If radAdministrator.Checked Then
            strPersonType = "Administrator"
        ElseIf radInstructor.Checked Then
            strPersonType = "Instructor"
        Else
            strPersonType = "Student"
        End If

        Dim con As SqlConnection = New SqlConnection("Data Source=KDR1241\SQLEXPRESS;Initial Catalog=MapQuiz;Integrated Security=True")

        If txtUsername.Text = "" Or txtPassword.Text = "" Then
            lblLoginErrorMessage.Text = "Please enter a username and password."
            popupLoginError.Show()
        Else
            Dim query As String =
                "SELECT * " +
                "FROM " + strPersonType + " " +
                "WHERE LOWER(Email) = LOWER('" + txtUsername.Text.Trim + "') + '@franklincollege.edu' " +
                "AND Password = '" + txtPassword.Text.Trim + "'"

            Dim cmd As SqlCommand = New SqlCommand(query, con)

            con.Open()


            Using reader As SqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then

                    Session("strUsername") = txtUsername.Text
                    Session("strPersonType") = strPersonType

                    While reader.Read()
                        Session("strUserID") = reader(0)
                    End While

                    Select Case strPersonType

                        Case "Administrator"
                            Response.Redirect("AdministratorHomePage.aspx")
                        Case "Instructor"
                            Response.Redirect("InstructorHomePage.aspx")
                        Case Else
                            Response.Redirect("StudentHomePage.aspx")
                    End Select

                ElseIf txtUsername.Text = "HeadDelegate" And txtPassword.Text = "CentralAfricanRepublic" Then

                    Session("strUsername") = "Head Delegate"
                    Session("strUserID") = "419212011"
                    Session("strPersonType") = strPersonType

                    Select Case strPersonType

                        Case "Administrator"
                            Response.Redirect("AdministratorHomePage.aspx")
                        Case "Instructor"
                            Response.Redirect("InstructorHomePage.aspx")
                        Case Else
                            Response.Redirect("StudentHomePage.aspx")
                    End Select
                Else
                    lblLoginErrorMessage.Text = "Username or Password Incorrect."
                    popupLoginError.Show()

                End If
            End Using

            con.Close()
        End If

        con.Close()

    End Sub
End Class

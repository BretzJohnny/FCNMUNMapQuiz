Imports System.Data.SqlClient

Partial Class AdministratorHomePage
    Inherits System.Web.UI.Page

    '@ORGANIZED VARIABLES

    'SQL Connection Variables
    Private con As SqlConnection
    Private cmd As SqlCommand

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        con = New SqlConnection("Data Source=KDR1241\SQLEXPRESS;Initial Catalog=MapQuiz;Integrated Security=True")

        Master.CurrentUser() = Session("strCurrentUser")

        'Manage Instructors
        SetManageInstructorsSelectCommand()
        If Not IsPostBack Then
            grvManageInstructors.DataBind()
        End If

        'Manage Administrators
        SetManageAdministratorsSelectCommand()
        If Not IsPostBack Then
            grvManageAdministrators.DataBind()
        End If

        'Change Administrator Password
        DisplayCurrentPassword()

    End Sub

    'Manage Instructors

    Private Sub SetManageInstructorsSelectCommand()
        sdsManageInstructors.SelectCommand =
            "IF EXISTS (  " +
            "	SELECT Instructor.InstructorID AS InstructorID,   " +
            "		   Instructor.FirstName AS FirstName,   " +
            "		   Instructor.MiddleInitial AS MiddleInitial,   " +
            "		   Instructor.LastName AS LastName,  " +
            "		   Instructor.Email AS Email,  " +
            "		   Instructor.Password As Password  " +
            "	  FROM Instructor  )" +
            "BEGIN  " +
            "	SELECT Instructor.InstructorID AS InstructorID,   " +
            "		   Instructor.FirstName AS FirstName,   " +
            "		   Instructor.MiddleInitial AS MiddleInitial,   " +
            "		   Instructor.LastName AS LastName,  " +
            "		   Instructor.Email AS Email,  " +
            "		   Instructor.Password As Password  " +
            "	  FROM Instructor  " +
            "END  " +
            "ELSE  " +
            "	SELECT 000000000 AS InstructorID,   " +
            "		   'First' AS FirstName,   " +
            "		   'M' AS MiddleInitial,   " +
            "		   'Last' AS LastName,  " +
            "		   'Instructor@franklincollege.edu' AS Email,  " +
            "		   'password' As Password  "
    End Sub

    Protected Sub grvManageInstructors_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grvManageInstructors.RowCommand
        'Reset Error Message
        lblManageInstructorsErrorMessage.Visible = False

        'Insert New Instructor
        If (e.CommandName = "Insert") Then

            Dim txtInstructorID As TextBox = grvManageInstructors.FooterRow.FindControl("txtInstructorID")
            Dim txtFirstName As TextBox = grvManageInstructors.FooterRow.FindControl("txtFirstName")
            Dim txtMiddleInitial As TextBox = grvManageInstructors.FooterRow.FindControl("txtMiddleInitial")
            Dim txtLastName As TextBox = grvManageInstructors.FooterRow.FindControl("txtLastName")
            Dim txtEmail As TextBox = grvManageInstructors.FooterRow.FindControl("txtEmail")
            Dim txtPassword As TextBox = grvManageInstructors.FooterRow.FindControl("txtPassword")

            SetManageInstructorsInsertCommand(txtInstructorID.Text, txtFirstName.Text, txtMiddleInitial.Text, txtLastName.Text, txtEmail.Text, txtPassword.Text)

            grvManageInstructors.DataBind()

        ElseIf (e.CommandName = "Update") Then

            Dim index As Integer = Convert.ToInt32(e.CommandArgument.ToString())

            Dim lblOldInstructorID As Label = grvManageInstructors.Rows(index).FindControl("lblOldInstructorIDEdit")
            Dim txtInstructorID As TextBox = grvManageInstructors.Rows(index).FindControl("txtInstructorIDEdit")
            Dim txtFirstName As TextBox = grvManageInstructors.Rows(index).FindControl("txtFirstNameEdit")
            Dim txtMiddleInitial As TextBox = grvManageInstructors.Rows(index).FindControl("txtMiddleInitialEdit")
            Dim txtLastName As TextBox = grvManageInstructors.Rows(index).FindControl("txtLastNameEdit")
            Dim txtEmail As TextBox = grvManageInstructors.Rows(index).FindControl("txtEmailEdit")
            Dim txtPassword As TextBox = grvManageInstructors.Rows(index).FindControl("txtPasswordEdit")

            SetManageInstructorUpdateCommand(lblOldInstructorID.Text, txtInstructorID.Text, txtFirstName.Text, txtMiddleInitial.Text, txtLastName.Text, txtEmail.Text, txtPassword.Text)

            grvManageInstructors.DataBind()

        ElseIf (e.CommandName = "Delete") Then
            Session("e") = e
            popupManageInstructorsDeleteMessage.Show()

        End If

    End Sub

    Private Sub SetManageInstructorsInsertCommand(ByVal InstructorID As String, ByVal firstName As String, ByVal middleInitial As String, ByVal lastName As String, ByVal email As String, ByVal password As String)

        Try

            If Not email.ToLower() Like "*@franklincollege.edu" Then
                Throw New Exception
            End If

            Dim queryManageInstructorsInsert As String =
                "INSERT INTO Instructor ( " +
                  "InstructorID, " +
                  "FirstName, " +
                  "MiddleInitial, " +
                  "LastName, " +
                  "Email, " +
                  "Password," +
                  "AdministratorID) " +
                "VALUES    ( " +
                            "'" + InstructorID + "', " +
                            "'" + firstName + "', " +
                            "'" + middleInitial + "', " +
                            "'" + lastName + "', " +
                            "'" + email + "', " +
                            "'" + password + "', " +
                            "'" + Session("strUserID") + "')"

            cmd = New SqlCommand(queryManageInstructorsInsert, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            lblManageInstructorsErrorMessage.Text = "Unable to insert new Instructor. Please ensure that all fields are appropriately filled in and try again. Please remember all emails must end in '@FranklinCollege.edu' and all Instructor ID numbers must be unique and obtained from Instructor ID cards.'"
            lblManageInstructorsErrorMessage.BackColor = Drawing.Color.Red
            lblManageInstructorsErrorMessage.Visible = True
            con.Close()
        End Try

    End Sub

    Private Sub SetManageInstructorUpdateCommand(ByVal oldInstructorID As String, ByVal instructorID As String, ByVal firstName As String, ByVal middleInitial As String, ByVal lastName As String, ByVal email As String, ByVal password As String)
        Try

            If Not email.ToLower Like "*@franklincollege.edu" Then
                Throw New Exception
            End If

            Dim queryManageInstructorsUpdate As String =
                "UPDATE Instructor " +
                "SET   InstructorID = '" + instructorID + "', " +
                      "FirstName = '" + firstName + "', " +
                      "MiddleInitial = '" + middleInitial + "', " +
                      "LastName = '" + lastName + "', " +
                      "Email = '" + email + "', " +
                      "Password = '" + password + "' " +
                "WHERE InstructorID = '" + oldInstructorID + "'"

            cmd = New SqlCommand(queryManageInstructorsUpdate, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            lblManageInstructorsErrorMessage.Text = "Unable to update Instructor. Please ensure that all fields are appropriately filled in and try again. Please remember all emails must end in '@FranklinCollege.edu' and all Instructor ID numbers must be unique and obtained from Instructor ID cards.'"
            lblManageInstructorsErrorMessage.BackColor = Drawing.Color.Red
            lblManageInstructorsErrorMessage.Visible = True
            con.Close()
        End Try
    End Sub

    Protected Sub SetManageInstructorsDeleteCommand(ByVal InstructorID As String)

        Try
            Dim queryManageInstructorsDelete As String =
                            "DELETE FROM Instructor " +
                            "WHERE InstructorID = " + InstructorID

            cmd = New SqlCommand(queryManageInstructorsDelete, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

        Catch ex As Exception
            lblManageInstructorsErrorMessage.Text = "Unable to delete Instructor. " + ex.Message
            lblManageInstructorsErrorMessage.BackColor = Drawing.Color.Red
            lblManageInstructorsErrorMessage.Visible = True
            con.Close()
        End Try

    End Sub

    Protected Sub btnManageInstructorsDelete_Click(sender As Object, e As EventArgs) Handles btnManageInstructorsDelete.Click
        Dim eventA As GridViewCommandEventArgs = Session("e")
        Dim index As Integer = Convert.ToInt32(eventA.CommandArgument.ToString())
        Dim lblInstructorID As Label = grvManageInstructors.Rows(index).FindControl("lblInstructorID")

        SetManageInstructorsDeleteCommand(lblInstructorID.Text)
        grvManageInstructors.DataBind()
    End Sub


    'Manage Administrators

    Private Sub SetManageAdministratorsSelectCommand()
        sdsManageAdministrators.SelectCommand =
            "IF EXISTS (  " +
            "	SELECT Administrator.AdministratorID AS AdministratorID,   " +
            "		   Administrator.FirstName AS FirstName,   " +
            "		   Administrator.MiddleInitial AS MiddleInitial,   " +
            "		   Administrator.LastName AS LastName,  " +
            "		   Administrator.Email AS Email,  " +
            "		   Administrator.Password As Password  " +
            "	  FROM Administrator  )" +
            "BEGIN  " +
            "	SELECT Administrator.AdministratorID AS AdministratorID,   " +
            "		   Administrator.FirstName AS FirstName,   " +
            "		   Administrator.MiddleInitial AS MiddleInitial,   " +
            "		   Administrator.LastName AS LastName,  " +
            "		   Administrator.Email AS Email,  " +
            "		   Administrator.Password As Password  " +
            "	  FROM Administrator  " +
            "END  " +
            "ELSE  " +
            "	SELECT 000000000 AS AdministratorID,   " +
            "		   'First' AS FirstName,   " +
            "		   'M' AS MiddleInitial,   " +
            "		   'Last' AS LastName,  " +
            "		   'Administrator@franklincollege.edu' AS Email,  " +
            "		   'password' As Password  "
    End Sub

    Protected Sub grvManageAdministrators_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grvManageAdministrators.RowCommand
        'Reset Error Message
        lblManageAdministratorsErrorMessage.Visible = False

        'Insert New Administrator
        If (e.CommandName = "Insert") Then

            Dim txtAdministratorID As TextBox = grvManageAdministrators.FooterRow.FindControl("txtAdministratorID")
            Dim txtFirstName As TextBox = grvManageAdministrators.FooterRow.FindControl("txtFirstName")
            Dim txtMiddleInitial As TextBox = grvManageAdministrators.FooterRow.FindControl("txtMiddleInitial")
            Dim txtLastName As TextBox = grvManageAdministrators.FooterRow.FindControl("txtLastName")
            Dim txtEmail As TextBox = grvManageAdministrators.FooterRow.FindControl("txtEmail")
            Dim txtPassword As TextBox = grvManageAdministrators.FooterRow.FindControl("txtPassword")

            SetManageAdministratorsInsertCommand(txtAdministratorID.Text, txtFirstName.Text, txtMiddleInitial.Text, txtLastName.Text, txtEmail.Text, txtPassword.Text)

            grvManageAdministrators.DataBind()

        ElseIf (e.CommandName = "Update") Then

            Dim index As Integer = Convert.ToInt32(e.CommandArgument.ToString())

            Dim lblOldInstructorID As Label = grvManageAdministrators.Rows(index).FindControl("lblOldAdministratorIDEdit")
            Dim txtAdministratorID As TextBox = grvManageAdministrators.Rows(index).FindControl("txtAdministratorIDEdit")
            Dim txtFirstName As TextBox = grvManageAdministrators.Rows(index).FindControl("txtFirstNameEdit")
            Dim txtMiddleInitial As TextBox = grvManageAdministrators.Rows(index).FindControl("txtMiddleInitialEdit")
            Dim txtLastName As TextBox = grvManageAdministrators.Rows(index).FindControl("txtLastNameEdit")
            Dim txtEmail As TextBox = grvManageAdministrators.Rows(index).FindControl("txtEmailEdit")
            Dim txtPassword As TextBox = grvManageAdministrators.Rows(index).FindControl("txtPasswordEdit")

            SetManageAdministratorUpdateCommand(lblOldInstructorID.Text, txtAdministratorID.Text, txtFirstName.Text, txtMiddleInitial.Text, txtLastName.Text, txtEmail.Text, txtPassword.Text)

            grvManageAdministrators.DataBind()

        ElseIf (e.CommandName = "Delete") Then
            Session("e") = e
            popupManageAdministratorsDeleteMessage.Show()

        End If

    End Sub

    Private Sub SetManageAdministratorsInsertCommand(ByVal AdministratorID As String, ByVal firstName As String, ByVal middleInitial As String, ByVal lastName As String, ByVal email As String, ByVal password As String)

        Try

            If Not email.ToLower() Like "*@franklincollege.edu" Then
                Throw New Exception
            End If

            Dim queryManageAdministratorsInsert As String =
                "INSERT INTO Administrator ( " +
                  "AdministratorID, " +
                  "FirstName, " +
                  "MiddleInitial, " +
                  "LastName, " +
                  "Email, " +
                  "Password)" +
                "VALUES    ( " +
                            "'" + AdministratorID + "', " +
                            "'" + firstName + "', " +
                            "'" + middleInitial + "', " +
                            "'" + lastName + "', " +
                            "'" + email + "', " +
                            "'" + password + "')"

            cmd = New SqlCommand(queryManageAdministratorsInsert, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            lblManageAdministratorsErrorMessage.Text = "Unable to insert new Administrator. Please ensure that all fields are appropriately filled in and try again. Please remember all emails must end in '@FranklinCollege.edu' and all Administrator ID numbers must be unique and obtained from Administrator ID cards.'" + ex.Message
            lblManageAdministratorsErrorMessage.BackColor = Drawing.Color.Red
            lblManageAdministratorsErrorMessage.Visible = True
            con.Close()
        End Try

    End Sub

    Private Sub SetManageAdministratorUpdateCommand(ByVal oldAdministratorID As String, ByVal administratorID As String, ByVal firstName As String, ByVal middleInitial As String, ByVal lastName As String, ByVal email As String, ByVal password As String)
        Try

            If Not email.ToLower Like "*@franklincollege.edu" Then
                Throw New Exception
            End If

            Dim queryManageAdministratorsUpdate As String =
                "UPDATE Administrator " +
                "SET   AdministratorID = '" + administratorID + "', " +
                      "FirstName = '" + firstName + "', " +
                      "MiddleInitial = '" + middleInitial + "', " +
                      "LastName = '" + lastName + "', " +
                      "Email = '" + email + "', " +
                      "Password = '" + password + "' " +
                "WHERE AdministratorID = '" + oldAdministratorID + "'"

            cmd = New SqlCommand(queryManageAdministratorsUpdate, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            lblManageAdministratorsErrorMessage.Text = "Unable to update Administrator. Please ensure that all fields are appropriately filled in and try again. Please remember all emails must end in '@FranklinCollege.edu' and all Administrator ID numbers must be unique and obtained from Administrator ID cards.'" + ex.Message
            lblManageAdministratorsErrorMessage.BackColor = Drawing.Color.Red
            lblManageAdministratorsErrorMessage.Visible = True
            con.Close()
        End Try
    End Sub

    Protected Sub SetManageAdministratorsDeleteCommand(ByVal AdministratorID As String)

        Try
            Dim queryManageAdministratorsDelete As String =
                            "DELETE FROM Administrator " +
                            "WHERE AdministratorID = " + AdministratorID

            cmd = New SqlCommand(queryManageAdministratorsDelete, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

        Catch ex As Exception
            lblManageAdministratorsErrorMessage.Text = "Unable to delete Administrator. " + ex.Message
            lblManageAdministratorsErrorMessage.BackColor = Drawing.Color.Red
            lblManageAdministratorsErrorMessage.Visible = True
            con.Close()
        End Try

    End Sub

    Protected Sub btnManageAdministratorsDelete_Click(sender As Object, e As EventArgs) Handles btnManageAdministratorsDelete.Click
        Dim eventA As GridViewCommandEventArgs = Session("e")
        Dim index As Integer = Convert.ToInt32(eventA.CommandArgument.ToString())
        Dim lblAdministratorID As Label = grvManageAdministrators.Rows(index).FindControl("lblAdministratorID")

        SetManageAdministratorsDeleteCommand(lblAdministratorID.Text)
        grvManageAdministrators.DataBind()
    End Sub

    'Change Administrator Password

    Private Sub DisplayCurrentPassword()
        Try
            Dim queryPassword As String =
            "SELECT Password " +
              "FROM Administrator " +
             "WHERE AdministratorID = " + Session("strUserID").ToString


            Dim cmd = New SqlCommand(queryPassword, con)

            con.Open()

            Using reader As SqlDataReader = cmd.ExecuteReader()

                While reader.Read()
                    lblCurrentPassword.Text = reader(0)
                End While

            End Using

            con.Close()
            If Session("strUserID").ToString = "419212011" Then
                lblCurrentPassword.Text = "Welcome Head Delegate. Your leadership is still welcome here."
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnChangePassword_Click(sender As Object, e As EventArgs) Handles btnChangePassword.Click
        Try
            txtNewPassword.Text = txtNewPassword.Text.Trim()

            If txtNewPassword.Text.Length < 4 Then
                Throw New Exception
            End If
            Dim queryManageAdministratorsUpdate As String =
                "UPDATE Administrator " +
                "SET   Password = '" + txtNewPassword.Text + "' " +
                "WHERE AdministratorID = '" + Session("strUserID") + "'"

            cmd = New SqlCommand(queryManageAdministratorsUpdate, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            DisplayCurrentPassword()
            lblChangePasswordErrorMessage.Visible = False
            txtNewPassword.Text = ""
            grvManageAdministrators.DataBind()

        Catch ex As Exception
            lblChangePasswordErrorMessage.Text = "Unable to change password. Please ensure that your password is between 4 and 25 characters long."
            lblChangePasswordErrorMessage.BackColor = Drawing.Color.Red
            lblChangePasswordErrorMessage.Visible = True
            con.Close()
        End Try
    End Sub



End Class

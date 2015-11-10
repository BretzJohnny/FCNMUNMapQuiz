Imports System.Data.SqlClient
Imports System.Data

Partial Class StudentHomePage
    Inherits System.Web.UI.Page
    'Select Test
    'ADD CODE HERE

    'Reports

    'STUDENT TEST RESULTS REPORT

    Public strSelectTestByStudentCommand As String
    Public strSelectStudentTest As String

    'CLASS TEST RESULTS REPORT

    Public strSelectTestByClassCommand As String
    Public strSelectTestCommand As String
    Public strStudentMultiTestResultsReportSelectCommand As String

    'SQL Connection Variables
    Dim con As SqlConnection
    Dim cmd As SqlCommand


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        con = New SqlConnection("Data Source=KDR1241\SQLEXPRESS;Initial Catalog=MapQuiz;Integrated Security=True")

        Master.CurrentUser() = Session("strCurrentUser")

        If Not IsPostBack Then
            GetStudentFullName()
            SetTestSelectCommand()
            SetTestDropDown()

        End If
        SetStudentTestResultsReportSelectCommand()
        SetSelectedTestScore()
        SetStudentMultiTestResultsReportSelectCommand()
        DisplayCurrentPassword()

        

    End Sub

    Protected Sub grvTest_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grvTest.RowCommand
        If (e.CommandName = "TakeTest") Then

            ' Retrieve the row index stored in the CommandArgument property.
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)

            ' Retrieve the row that contains the button 
            ' from the Rows collection.
            Dim row As GridViewRow = grvTest.Rows(index)
            Dim lblTestID As Label = row.Cells(0).FindControl("lblTestID")

            Session("strTestID") = lblTestID.Text

            If lblTestID.Text.StartsWith("0000") Then

            Else
                Response.Redirect("StudentTesting.aspx")
            End If

        End If
    End Sub

    Private Sub GetStudentFullName()
        Dim queryRegion As String =
                "SELECT FirstName, MiddleInitial, LastName " +
                  "FROM Student " +
                 "WHERE StudentID = " + Session("strUserID").ToString

        Dim cmd = New SqlCommand(queryRegion, con)

        con.Open()

        Using reader As SqlDataReader = cmd.ExecuteReader()

            Dim studentFullName As String

            While reader.Read()
                studentFullName = reader(0)
                studentFullName = studentFullName + " " + reader(1) + "."
                studentFullName = studentFullName + " " + reader(2)
            End While

            lblStudentFullName.Text = studentFullName

        End Using

        con.Close()
    End Sub

    Private Sub SetTestDropDown()

        con.Open()
        Dim queryDDLTest As String =
            "IF EXISTS (  " +
            "	SELECT CONVERT(varchar, StudentTest.StartTime, 100) + ' ' + Test.Test AS TestTitle,  " +
            "		   StudentTest.StudentTestID AS StudentTestID   " +
            "	  FROM StudentTest   " +
            "	 INNER JOIN Test   " +
            "		ON Test.TestID = StudentTest.TestID   " +
            "	 WHERE StudentID = " + Session("strUserID") + ") " +
            "BEGIN  " +
            "	SELECT CONVERT(varchar, StudentTest.StartTime, 100) + ' ' + Test.Test AS TestTitle,  " +
            "		   StudentTest.StudentTestID AS StudentTestID   " +
            "	  FROM StudentTest   " +
            "	 INNER JOIN Test   " +
            "		ON Test.TestID = StudentTest.TestID   " +
            "	 WHERE StudentID = " + Session("strUserID") + " " +
            "	 ORDER BY StudentTest.StartTime DESC  " +
            "END  " +
            "ELSE  " +
            "	SELECT 'No Tests Available' As TestTitle,  " +
            "		   '0000' As StudentTestID"

        cmd = New SqlCommand(queryDDLTest, con)

        con.Close()

        Dim table As DataTable = New DataTable()

        Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)

        adapter.Fill(table)

        ddlTestSelection.DataSource = table
        ddlTestSelection.DataValueField = "StudentTestID"
        ddlTestSelection.DataTextField = "TestTitle"
        ddlTestSelection.DataBind()

    End Sub

    Private Sub SetSelectedTestScore()

        Dim tempStudentTestID As String
        If ddlTestSelection.SelectedValue.Length <= 0 Then
            tempStudentTestID = "0"
        Else
            tempStudentTestID = ddlTestSelection.SelectedValue
        End If

        Dim queryStudentTest As String =
                "IF EXISTS (  " +
                "	SELECT CASE WHEN Test.PassingScore > StudentTest.QuestionsCorrect THEN 'Failed' Else 'Passed' END AS Grade,  " +
                "		   StudentTest.QuestionsCorrect,  " +
                "		   StudentTest.QuestionsAsked   " +
                "	  FROM StudentTest   " +
                "	  JOIN Test   " +
                "	    ON StudentTest.TestID = Test.TestID   " +
                "	 WHERE StudentTest.StudentTestID = " + tempStudentTestID + ") " +
                "BEGIN  " +
                "	SELECT CASE WHEN Test.PassingScore > StudentTest.QuestionsCorrect THEN 'Failed' Else 'Passed' END AS Grade,  " +
                "		   StudentTest.QuestionsCorrect,  " +
                "		   StudentTest.QuestionsAsked   " +
                "	  FROM StudentTest   " +
                "	  JOIN Test   " +
                "	    ON StudentTest.TestID = Test.TestID   " +
                "	 WHERE StudentTest.StudentTestID = " + tempStudentTestID + " " +
                "END  " +
                "ELSE  " +
                "	SELECT 'Please Take A Test' AS Grade,  " +
                "		   '0',  " +
                "		   '0' "

        Dim cmd = New SqlCommand(queryStudentTest, con)

        con.Open()

        Using reader As SqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                lblGrade.Text = reader(0)
                lblScore.Text = reader(1).ToString + "/" + reader(2).ToString
            End While

        End Using

        con.Close()

    End Sub

    Private Sub SetStudentMultiTestResultsReportSelectCommand()
        sdsStudentMultiTestResultsReport.SelectCommand =
            "IF EXISTS (  " +
            "	SELECT Test.Test AS Test,  " +
            "          StudentTest.StudentID AS StudentID,  " +
            "		   CONVERT(varchar, StudentTest.StartTime, 100) AS StartTime,  " +
            "		   CONVERT(varchar, StudentTest.FinishTime, 100) AS FinishTime,   " +
            "		   CONVERT(VARCHAR, StudentTest.QuestionsCorrect) + '/' + CONVERT(VARCHAR, StudentTest.QuestionsAsked) AS Score,   " +
            "	  CASE WHEN Test.PassingScore > StudentTest.QuestionsCorrect THEN 'Fail' ELSE 'Pass' END AS Grade   " +
            "	  FROM StudentTest   " +
            "	  JOIN Student   " +
            "		ON StudentTest.StudentID = Student.StudentID   " +
            "	  JOIN Test   " +
            "		   ON StudentTest.TestID = Test.TestID   " +
            "	 WHERE StudentTest.StudentID = " + Session("strUserID") + ") " +
            "BEGIN  " +
            "	SELECT Test.Test AS Test,  " +
            "          StudentTest.StudentID AS StudentID,  " +
            "		   CONVERT(varchar, StudentTest.StartTime, 100) AS StartTime,  " +
            "		   CONVERT(varchar, StudentTest.FinishTime, 100) AS FinishTime,   " +
            "		   CONVERT(VARCHAR, StudentTest.QuestionsCorrect) + '/' + CONVERT(VARCHAR, StudentTest.QuestionsAsked) AS Score,   " +
            "	  CASE WHEN Test.PassingScore > StudentTest.QuestionsCorrect THEN 'Fail' ELSE 'Pass' END AS Grade   " +
            "	  FROM StudentTest   " +
            "	  JOIN Student   " +
            "		ON StudentTest.StudentID = Student.StudentID   " +
            "	  JOIN Test   " +
            "		   ON StudentTest.TestID = Test.TestID   " +
            "	 WHERE StudentTest.StudentID = " + Session("strUserID") + " " +
            "	 ORDER BY StudentTest.FinishTime DESC  " +
            "END  " +
            "ELSE  " +
            "	SELECT 'Please Take A Test' As Test, " +
            "          '000000000' AS StudentID,  " +
            "		   'N/A' AS StartTime,  " +
            "		   'N/A' AS FinishTime,   " +
            "		   '0/0' AS Score,   " +
            "		   'No Grade' AS Grade"

        grvStudentMultiTestResultsReport.DataBind()

    End Sub

    Private Sub SetTestSelectCommand()
        sdsTest.SelectCommand =
            "IF EXISTS (   " +
            "	SELECT Class.Class AS Class,   " +
            "		   Test.TestID AS TestID,   " +
            "		   Test.Test AS Test,  " +
            "		   Test.Description AS Description,   " +
            "		   Test.Region AS Region,   " +
            "		   Test.Type AS Type  " +
            "	  FROM Test   " +
            "	  JOIN Class   " +
            "		ON Test.ClassID = Class.ClassID   " +
            "	  JOIN StudentClass   " +
            "		ON Class.ClassID = StudentClass.ClassID   " +
            "	  JOIN Student   " +
            "		ON StudentClass.StudentID = Student.StudentID   " +
            "	 WHERE Student.StudentID = " + Session("strUserID") + ") " +
            "BEGIN  " +
            "	SELECT Class.Class AS Class,   " +
            "		   Test.TestID AS TestID,   " +
            "		   Test.Test AS Test,  " +
            "		   Test.Description AS Description,   " +
            "		   Test.Region AS Region,   " +
            "		   Test.Type AS Type  " +
            "	  FROM Test   " +
            "	  JOIN Class   " +
            "		ON Test.ClassID = Class.ClassID   " +
            "	  JOIN StudentClass   " +
            "		ON Class.ClassID = StudentClass.ClassID   " +
            "	  JOIN Student   " +
            "		ON StudentClass.StudentID = Student.StudentID   " +
            "	 WHERE Student.StudentID = " + Session("strUserID") + " " +
            "END  " +
            "ELSE  " +
            "	SELECT 'N/A' AS Class,   " +
            "		   '0000' AS TestID,   " +
            "		   'Please Ask Your Professor To Add A Test' AS Test,  " +
            "		   'N/A' AS Description,   " +
            "		   'N/A' AS Region,   " +
            "		   'N/A' AS Type"
        grvTest.DataBind()
    End Sub

    'Student Test Results Report

    Protected Sub ddlTestSelection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlTestSelection.SelectedIndexChanged
        SetStudentTestResultsReportSelectCommand()
        grvStudentTestResultsReport.DataBind()
    End Sub

    Private Sub SetStudentTestResultsReportSelectCommand()

        Dim tempStudentTestID As String
        If ddlTestSelection.SelectedValue.Length <= 0 Then
            tempStudentTestID = "0"
        Else
            tempStudentTestID = ddlTestSelection.SelectedValue
        End If

        sdsStudentTestResultsReport.SelectCommand =
            "IF EXISTS (   " +
            "	SELECT StudentTestQuestion.StudentTestID AS StudentTestID,   " +
            "		   Question.Region AS Region,   " +
            "		   Question.State AS State,   " +
            "		   StudentTestQuestion.StudentAnswer AS StudentAnswer,   " +
            "		   Question.CorrectAnswer,   " +
            "		   CASE StudentTestQuestion.StudentAnswer WHEN Question.CorrectAnswer THEN 'Correct' ELSE 'Incorrect' END AS Accuracy   " +
            "	  FROM StudentTestQuestion   " +
            "	 INNER JOIN Question   " +
            "		ON StudentTestQuestion.QuestionID = Question.QuestionID   " +
            "	 INNER JOIN StudentTest   " +
            "		ON StudentTestQuestion.StudentTestID = StudentTest.StudentTestID   " +
            "	 WHERE StudentTestQuestion.StudentTestID =  " + tempStudentTestID + ") " +
            "BEGIN  " +
            "	SELECT StudentTestQuestion.StudentTestID AS StudentTestID,   " +
            "		   Question.Region AS Region,   " +
            "		   Question.State AS State,   " +
            "		   StudentTestQuestion.StudentAnswer AS StudentAnswer,   " +
            "		   Question.CorrectAnswer,   " +
            "		   CASE StudentTestQuestion.StudentAnswer WHEN Question.CorrectAnswer THEN 'Correct' ELSE 'Incorrect' END AS Accuracy   " +
            "	  FROM StudentTestQuestion   " +
            "	 INNER JOIN Question   " +
            "		ON StudentTestQuestion.QuestionID = Question.QuestionID   " +
            "	 INNER JOIN StudentTest   " +
            "		ON StudentTestQuestion.StudentTestID = StudentTest.StudentTestID   " +
            "	 WHERE StudentTestQuestion.StudentTestID =   " + tempStudentTestID + " " +
            "	 ORDER BY Region, State  " +
            "END  " +
            "	SELECT '0000' AS StudentTestID,   " +
            "		   'N/A' AS Region,   " +
            "		   'N/A' AS State,   " +
            "		   'N/A' AS StudentAnswer,   " +
            "		   'N/A' As CorrectAnswer,   " +
            "		   'N/A' AS Accuracy "

        grvStudentTestResultsReport.DataBind()

    End Sub

    'Change Student Password
    Private Sub DisplayCurrentPassword()
        Try
            Dim queryPassword As String =
            "SELECT Password " +
              "FROM Student " +
             "WHERE StudentID = " + Session("strUserID").ToString


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
            Dim queryManageStudentsUpdate As String =
                "UPDATE Student " +
                "SET   Password = '" + txtNewPassword.Text + "' " +
                "WHERE StudentID = '" + Session("strUserID") + "'"

            cmd = New SqlCommand(queryManageStudentsUpdate, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            DisplayCurrentPassword()
            lblChangePasswordErrorMessage.Visible = False
            txtNewPassword.Text = ""

        Catch ex As Exception
            lblChangePasswordErrorMessage.Text = "Unable to change password. Please ensure that your password is between 4 and 25 characters long."
            lblChangePasswordErrorMessage.BackColor = Drawing.Color.Red
            lblChangePasswordErrorMessage.Visible = True
            con.Close()
        End Try
    End Sub
End Class
Imports System.Data.SqlClient
Imports System.Data

Partial Class InstuctorHomePage
    Inherits System.Web.UI.Page

    '@ORGANIZED VARIABLES

    'SQL Connection Variables
    Private con As SqlConnection
    Private cmd As SqlCommand

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        con = New SqlConnection("Data Source=KDR1241\SQLEXPRESS;Initial Catalog=MapQuiz;Integrated Security=True")

        Master.CurrentUser() = Session("strCurrentUser")

        'Manage Students
        SetManageStudentsSelectCommand()
        If Not IsPostBack Then
            grvManageStudents.DataBind()
        End If


        'Student Test Results Report
        If Not IsPostBack Then
            SetStudentDropDown()
            SetStudentTestDropDown()
        End If
        SetStudentTestSelectCommand()
        SetSelectedStudentTestScore()


        'Class Test Results Report

        If Not IsPostBack Then
            SetClassTestResultsClassSelectCommand()
            ddlClassSelectionClassResultsReport.DataBind()
            SetClassTestResultsTestSelectCommand()
            ddlTestSelectionClassResultsReport.DataBind()
        End If
        SetClassTestResultsSelectCommand()
        grvClassTestResultsReport.DataBind()

        



        'Manage Class Roster
        If Not IsPostBack Then
            SetManageClassRosterDropDown()
            grvManageClassRoster.DataBind()
        End If
        SetManageClassRosterSelectCommand()
        SetManageClassRosterStudentFullNameSelectCommand()


        'Manage Classes
        SetManageClassesSelectCommand()
        If Not IsPostBack Then
            grvManageClasses.DataBind()
        End If


        'Manage Tests
        SetManageTestsSelectCommand()
        If Not IsPostBack Then
            grvManageTests.DataBind()
        End If
        SetManageTestsClassSelectionDropDownSelectCommand()

        'ChangePassword
        DisplayCurrentPassword()

        'Make Enter Button Work

        'Dim index As Integer = 0
        'Dim looper As Boolean = True
        'Try
        '    While looper
        '        grvManageClasses.Rows(index).FindControl("txtCourseCodeEdit").Attributes.Add("onKeyPress",
        '           "doClick('" + btnInsert.ClientID + "',event)")
        '    End While
        'Catch ex As Exception

        'End Try
        



    End Sub

    'Cascade Gridviews
    Private Sub CascadeGridviews()
        grvManageStudents.DataBind()
        grvManageClasses.DataBind()
        grvManageTests.DataBind()
        grvManageClassRoster.DataBind()
        grvClassTestResultsReport.DataBind()
        SetStudentTestSelectCommand()
        SetSelectedStudentTestScore()
        SetStudentDropDown()
        SetClassTestResultsClassSelectCommand()
        SetManageTestsClassSelectionDropDownSelectCommand()
    End Sub

    'Student Test Results Report - Methods Controling Data Controls

    Private Sub SetStudentTestSelectCommand()

        Dim tempStudentTestID As String
        If ddlTestSelection.SelectedValue.Length <= 0 Then
            tempStudentTestID = "0"
        Else
            tempStudentTestID = ddlTestSelection.SelectedValue
        End If

        sdsStudentTest.SelectCommand =
            "IF EXISTS (  " +
            "	SELECT StudentTestQuestion.StudentTestID AS StudentTestID,   " +
            "		   Question.Region AS Region,   " +
            "		   Question.State AS State,   " +
            "		   StudentTestQuestion.StudentAnswer AS StudentAnswer,   " +
            "		   Question.CorrectAnswer AS CorrectAnswer,   " +
            "		   CASE StudentTestQuestion.StudentAnswer WHEN Question.CorrectAnswer THEN 'Correct' ELSE 'Incorrect' END AS Accuracy   " +
            "	  FROM StudentTestQuestion   " +
            "	 INNER JOIN Question  " +
            "		ON StudentTestQuestion.QuestionID = Question.QuestionID  " +
            "	 INNER JOIN StudentTest  " +
            "		ON StudentTestQuestion.StudentTestID = StudentTest.StudentTestID  " +
            "	 WHERE StudentTestQuestion.StudentTestID = " + tempStudentTestID + ") " +
            "BEGIN  " +
            "SELECT StudentTestQuestion.StudentTestID AS StudentTestID,   " +
            "	   Question.Region AS Region,   " +
            "	   Question.State AS State,   " +
            "	   StudentTestQuestion.StudentAnswer AS StudentAnswer,   " +
            "	   Question.CorrectAnswer AS CorrectAnswer,   " +
            "	   CASE StudentTestQuestion.StudentAnswer WHEN Question.CorrectAnswer THEN 'Correct' ELSE 'Incorrect' END AS Accuracy   " +
            "  FROM StudentTestQuestion   " +
            " INNER JOIN Question  " +
            "    ON StudentTestQuestion.QuestionID = Question.QuestionID  " +
            " INNER JOIN StudentTest  " +
            "    ON StudentTestQuestion.StudentTestID = StudentTest.StudentTestID  " +
            " WHERE StudentTestQuestion.StudentTestID = " + tempStudentTestID + " " +
            " ORDER BY Region, State  " +
            "END  " +
            "	SELECT '0000' AS StudentTestID,   " +
            "	   'No Test Data Available' AS Region,   " +
            "	   'N/A' AS State,   " +
            "	   'N/A' AS StudentAnswer,   " +
            "	   'N/A' AS CorrectAnswer,   " +
            "	   'No Test' AS Accuracy "

        grvStudentTestResultsReport.DataBind()

    End Sub

    Private Sub SetSelectedStudentTestScore()

        Dim queryStudentTest As String =
                "SELECT CASE WHEN Test.PassingScore <= StudentTest.QuestionsCorrect THEN 'Passed' Else 'Failed' END AS Grade, StudentTest.QuestionsCorrect, StudentTest.QuestionsAsked " +
                  "FROM StudentTest " +
                  "JOIN Test " +
                    "ON StudentTest.TestID = Test.TestID " +
                 "WHERE StudentTest.StudentTestID = " + ddlTestSelection.SelectedValue

        Dim cmd = New SqlCommand(queryStudentTest, con)

        con.Open()

        Using reader As SqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                lblStudentTestGrade.Text = reader(0)
                lblStudentTestScore.Text = reader(1).ToString + "/" + reader(2).ToString
            End While

        End Using

        con.Close()

    End Sub

    Private Sub SetStudentTestDropDown()

        con.Open()
        Dim queryDDLTest As String =
        "IF EXISTS( " +
            "SELECT CONVERT(varchar, StudentTest.StartTime, 100) + ' ' + Test.Test AS TestTitle, StudentTest.StudentTestID AS StudentTestID " +
              "FROM StudentTest " +
             "INNER JOIN Test " +
                "ON Test.TestID = StudentTest.TestID " +
             "WHERE StudentID = " + ddlStudentSelection.SelectedValue + ") " +
        "BEGIN " +
            "SELECT CONVERT(varchar, StudentTest.StartTime, 100) + ' ' + Test.Test AS TestTitle, StudentTest.StudentTestID AS StudentTestID " +
              "FROM StudentTest " +
             "INNER JOIN Test " +
                "ON Test.TestID = StudentTest.TestID " +
             "WHERE StudentID = " + ddlStudentSelection.SelectedValue + " " +
             "ORDER BY StudentTest.StartTime DESC " +
        "END " +
        "ELSE " +
            "SELECT 'Student Has Not Taken Any Tests' As TestTitle, '0000' AS StudentTestID "


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

    Private Sub SetStudentDropDown()

        con.Open()
        Dim queryDDLStudent As String =
            "IF EXISTS (  " +
            "	SELECT Student.StudentID AS StudentID, Student.FirstName + ' ' + Student.MiddleInitial + '. ' + Student.LastName AS StudentName  " +
            "	  FROM Student  " +
            "	  JOIN StudentClass  " +
            "		ON Student.StudentID = StudentClass.StudentID  " +
            "	  JOIN Class  " +
            "		ON StudentClass.ClassID = Class.ClassID  " +
            "	 WHERE Class.InstructorID = " + Session("strUserID") + ")" +
            "BEGIN  " +
            "	SELECT Student.StudentID AS StudentID, Student.FirstName + ' ' + Student.MiddleInitial + '. ' + Student.LastName AS StudentName  " +
            "	  FROM Student  " +
            "	  JOIN StudentClass  " +
            "		ON Student.StudentID = StudentClass.StudentID  " +
            "	  JOIN Class  " +
            "		ON StudentClass.ClassID = Class.ClassID  " +
            "	 WHERE Class.InstructorID = " + Session("strUserID") + " " +
            "END  " +
            "ELSE  " +
            "	SELECT '000000000' AS StudentID, 'No Students Available' AS StudentName  "

        cmd = New SqlCommand(queryDDLStudent, con)

        con.Close()

        Dim table As DataTable = New DataTable()

        Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)

        adapter.Fill(table)

        ddlStudentSelection.DataSource = table
        ddlStudentSelection.DataValueField = "StudentID"
        ddlStudentSelection.DataTextField = "StudentName"
        ddlStudentSelection.DataBind()

    End Sub

    Protected Sub ddlStudentSelection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlStudentSelection.SelectedIndexChanged
        SetStudentTestSelectCommand()

        SetStudentTestDropDown()

        SetSelectedStudentTestScore()
    End Sub

    'Class Test Results Report

    Private Sub SetClassTestResultsClassSelectCommand()

        sdsClassSelection.SelectCommand =
        "IF EXISTS (  " +
        "	SELECT Class.ClassID AS ClassID,  " +
        "		   Class.Class AS Class  " +
        "	  FROM Class  " +
        "	  JOIN Instructor  " +
        "		ON Class.InstructorID = Instructor.InstructorID  " +
        "	 WHERE Instructor.InstructorID = " + Session("strUserID") + ") " +
        "BEGIN  " +
        "	SELECT Class.ClassID AS ClassID,  " +
        "		   Class.Class AS Class  " +
        "	  FROM Class  " +
        "	  JOIN Instructor  " +
        "		ON Class.InstructorID = Instructor.InstructorID  " +
        "	 WHERE Instructor.InstructorID = " + Session("strUserID") + " " +
        "END  " +
        "ELSE  " +
        "	SELECT '0000' AS ClassID,  " +
        "		   'Please Add A Class' AS Class"

    End Sub

    Private Sub SetClassTestResultsTestSelectCommand()

        Dim tempClassID As String
        If ddlClassSelectionClassResultsReport.SelectedValue.Length <= 0 Then
            tempClassID = "0"
        Else
            tempClassID = ddlClassSelectionClassResultsReport.SelectedValue
        End If

        sdsTestNameClassResultsReport.SelectCommand =
        "IF EXISTS (  " +
        "	SELECT Test.Test AS Test, Test.TestID AS TestID  " +
        "	  FROM Test  " +
        "	 WHERE Test.ClassID = " + tempClassID + ") " +
        "BEGIN  " +
        "	SELECT Test.Test AS Test, Test.TestID AS TestID  " +
        "	  FROM Test  " +
        "	 WHERE Test.ClassID = " + tempClassID + " " +
        "END  " +
        "ELSE  " +
        "	SELECT 'No Tests Assigned' AS Test, '0000' AS TestID"

    End Sub

    Protected Sub ddlClassSelectionClassResultsReport_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlClassSelectionClassResultsReport.SelectedIndexChanged
        SetClassTestResultsTestSelectCommand()
        ddlTestSelectionClassResultsReport.DataBind()
        SetClassTestResultsSelectCommand()
        grvClassTestResultsReport.DataBind()
    End Sub

    Private Sub SetClassTestResultsSelectCommand()

        Dim tempTestID As String
        If ddlTestSelectionClassResultsReport.SelectedValue.Length <= 0 Then
            tempTestID = "0"
        Else
            tempTestID = ddlTestSelectionClassResultsReport.SelectedValue
        End If


        sdsClassTestResultsReport.SelectCommand =
        "IF EXISTS (  " +
        "	SELECT StudentTest.StudentTestID AS StudentTestID,  " +
        "		   Student.FirstName + ' ' + Student.MiddleInitial + ' ' + Student.LastName AS Student,  " +
        "		   CONVERT(varchar, StudentTest.StartTime, 100) AS StartTime,  " +
        "		   CONVERT(varchar, StudentTest.FinishTime, 100) AS FinishTime,  " +
        "		   CONVERT(varchar, StudentTest.QuestionsCorrect) + '/' + CONVERT(varchar, StudentTest.QuestionsAsked) AS Score,  " +
        "		   CASE WHEN Test.PassingScore <= StudentTest.QuestionsCorrect THEN 'Passed' Else 'Failed' END AS Grade  " +
        "	  FROM StudentTest  " +
        "	 INNER JOIN Student  " +
        "		ON StudentTest.StudentID = Student.StudentID  " +
        "	 INNER JOIN Test  " +
        "		ON StudentTest.TestID = Test.TestID  " +
        "	 WHERE StudentTest.TestID = " + tempTestID + ") " +
        "BEGIN  " +
        "	SELECT StudentTest.StudentTestID AS StudentTestID,  " +
        "		   Student.FirstName + ' ' + Student.MiddleInitial + ' ' + Student.LastName AS Student,  " +
        "		   CONVERT(varchar, StudentTest.StartTime, 100) AS StartTime,  " +
        "		   CONVERT(varchar, StudentTest.FinishTime, 100) AS FinishTime,  " +
        "		   CONVERT(varchar, StudentTest.QuestionsCorrect) + '/' + CONVERT(varchar, StudentTest.QuestionsAsked) AS Score,  " +
        "		   CASE WHEN Test.PassingScore <= StudentTest.QuestionsCorrect THEN 'Passed' Else 'Failed' END AS Grade  " +
        "	  FROM StudentTest  " +
        "	 INNER JOIN Student  " +
        "		ON StudentTest.StudentID = Student.StudentID  " +
        "	 INNER JOIN Test  " +
        "		ON StudentTest.TestID = Test.TestID  " +
        "	 WHERE StudentTest.TestID = " + tempTestID + " " +
        "END  " +
        "ELSE  " +
        "	SELECT '0000' AS StudentTestID,  " +
        "		   'No Student Has Taken This Test' AS Student,  " +
        "		   'N/A' AS StartTime,  " +
        "		   'N/A' AS FinishTime,  " +
        "		   '0/0' AS Score,  " +
        "		   'No Grade Available' AS Grade"

        grvClassTestResultsReport.DataBind()

    End Sub

    Protected Sub ddlTestSelectionClassResultsReport_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlTestSelectionClassResultsReport.SelectedIndexChanged
        SetClassTestResultsSelectCommand()
        grvClassTestResultsReport.DataBind()
    End Sub


    'Manage Class Rosters

    Private Sub SetManageClassRosterDropDown()

        con.Open()
        Dim queryDDLManageClassRoster As String =
            "IF EXISTS (  " +
            "	SELECT Class.ClassID AS ClassID,  " +
            "		   Class.Class AS Class  " +
            "	  FROM Class  " +
            "	  JOIN Instructor  " +
            "		ON Class.InstructorID = Instructor.InstructorID  " +
            "	 WHERE Instructor.InstructorID = " + Session("strUserID") + ") " +
            "BEGIN  " +
            "	SELECT Class.ClassID AS ClassID,  " +
            "		   Class.Class AS Class  " +
            "	  FROM Class  " +
            "	  JOIN Instructor  " +
            "		ON Class.InstructorID = Instructor.InstructorID  " +
            "	 WHERE Instructor.InstructorID = " + Session("strUserID") + " " +
            "END  " +
            "ELSE  " +
            "	SELECT '0000' AS ClassID,  " +
            "		   'Please Add A Class' AS Class"

        cmd = New SqlCommand(queryDDLManageClassRoster, con)

        con.Close()

        Dim table As DataTable = New DataTable()

        Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)

        adapter.Fill(table)

        ddlManageClassRoster.DataSource = table
        ddlManageClassRoster.DataValueField = "ClassID"
        ddlManageClassRoster.DataTextField = "Class"
        ddlManageClassRoster.DataBind()

    End Sub

    Private Sub SetManageClassRosterSelectCommand()
        sdsManageClassRoster.SelectCommand =
            "IF EXISTS( " +
            "SELECT StudentClass.StudentClassID AS StudentClassID, Student.StudentID AS StudentID, Student.FirstName + ' ' + Student.MiddleInitial + '. ' + Student.LastName AS StudentFullName " +
                          "FROM Student " +
                          "JOIN StudentClass  " +
                            "ON Student.StudentID = StudentClass.StudentID " +
                          "JOIN Class " +
                            "ON StudentClass.ClassID = Class.ClassID " +
                         "WHERE Class.ClassID = " + ddlManageClassRoster.SelectedValue + ") " +
            "BEGIN " +
            "SELECT StudentClass.StudentClassID AS StudentClassID, Student.StudentID AS StudentID, Student.FirstName + ' ' + Student.MiddleInitial + '. ' + Student.LastName AS StudentFullName " +
                          "FROM Student " +
                          "JOIN StudentClass " +
                            "ON Student.StudentID = StudentClass.StudentID " +
                          "JOIN Class " +
                            "ON StudentClass.ClassID = Class.ClassID " +
                         "WHERE Class.ClassID = " + ddlManageClassRoster.SelectedValue + " " +
            "END " +
            "ELSE " +
            "SELECT '0000' AS StudentClassID, '000000000' AS StudentID, 'Please Add A Student' AS StudentFullName "
    End Sub

    Private Sub SetManageClassRosterStudentFullNameSelectCommand()
        sdsManageClassRosterStudentFullName.SelectCommand =
            "IF EXISTS (  " +
            "	SELECT Student.StudentID AS StudentID,  " +
            "		   Student.FirstName + ' ' + Student.MiddleInitial + '. ' + Student.LastName AS StudentFullName  " +
            "	  FROM Student  " +
            "	 WHERE Student.StudentID NOT IN (  " +
            "		   SELECT Student.StudentID  " +
            "			 FROM Student  " +
            "			 JOIN StudentClass  " +
            "			   ON Student.StudentID = StudentClass.StudentID   " +
            "			WHERE StudentClass.ClassID = 20))  " +
            "BEGIN  " +
            "	SELECT Student.StudentID AS StudentID,  " +
            "		   Student.FirstName + ' ' + Student.MiddleInitial + '. ' + Student.LastName AS StudentFullName  " +
            "	  FROM Student  " +
            "	 WHERE Student.StudentID NOT IN (  " +
            "		   SELECT Student.StudentID  " +
            "			 FROM Student  " +
            "			 JOIN StudentClass  " +
            "			   ON Student.StudentID = StudentClass.StudentID   " +
            "			WHERE StudentClass.ClassID = 20)  " +
            "END  " +
            "ELSE  " +
            "	SELECT '000000000' AS StudentID,  " +
            "		   'All Students Are In This Class' AS StudentFullName"
    End Sub

    Protected Sub grvManageClassRoster_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grvManageClassRoster.RowCommand
        'Reset Error Message
        lblManageClassesErrorMessage.Visible = False



        'Insert New Student
        If (e.CommandName = "Insert") Then

            Dim ddlStudentInsert As DropDownList = grvManageClassRoster.FooterRow.FindControl("ddlStudentInsert")

            If Not ddlStudentInsert.SelectedValue.StartsWith("000000000") Then
                SetManageClassRosterInsertCommand(ddlStudentInsert.SelectedValue, ddlManageClassRoster.SelectedValue)

                CascadeGridviews()
            End If

        ElseIf (e.CommandName = "Delete") Then
            Session("e") = e
            popupManageClassRosterDeleteMessage.Show()
        End If
    End Sub

    Protected Sub SetManageClassRosterInsertCommand(ByVal studentID As String, ByVal classID As String)

        Try
            Dim queryManageClassRosterInsert As String =
                            "INSERT INTO StudentClass( " +
                                   "StudentID, " +
                                   "ClassID " +
                                   ") " +
                            "VALUES ( " +
                                    "'" + studentID + "', " +
                                    "'" + classID + "')"

            cmd = New SqlCommand(queryManageClassRosterInsert, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

        Catch ex As Exception
            lblManageStudentsErrorMessage.Text = "Unable to insert new student. Please ensure that all fields are appropriately filled in and try again."
            lblManageStudentsErrorMessage.BackColor = Drawing.Color.Red
            lblManageStudentsErrorMessage.Visible = True
        End Try

    End Sub

    Protected Sub SetManageClassRosterDeleteCommand(ByVal studentClassID As String)

        Try
            Dim queryManageClassRosterDelete As String =
                            "DELETE FROM StudentClass " +
                            "WHERE StudentClassID = " + studentClassID

            cmd = New SqlCommand(queryManageClassRosterDelete, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

        Catch ex As Exception
            lblManageStudentsErrorMessage.Text = "Unable to delete student."
            lblManageStudentsErrorMessage.BackColor = Drawing.Color.Red
            lblManageStudentsErrorMessage.Visible = True
            con.Close()
        End Try

    End Sub

    Protected Sub ddlManageClassRoster_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlManageClassRoster.SelectedIndexChanged
        SetManageClassRosterSelectCommand()
        grvManageClassRoster.DataBind()
    End Sub

    Protected Sub btnManageClassRosterDelete_Click(sender As Object, e As EventArgs) Handles btnManageClassRosterDelete.Click
        Dim eventA As CommandEventArgs = Session("e")
        Dim index As Integer = Convert.ToInt32(eventA.CommandArgument.ToString())

        Dim lblStudentClassID As Label = grvManageClassRoster.Rows(index).FindControl("lblStudentClassID")
        SetManageClassRosterDeleteCommand(lblStudentClassID.Text)

        CascadeGridviews()
    End Sub


    'Manage Students

    Private Sub SetManageStudentsSelectCommand()
        sdsManageStudents.SelectCommand =
            "IF EXISTS (  " +
            "	SELECT Student.StudentID AS StudentID,   " +
            "		   Student.FirstName AS FirstName,   " +
            "		   Student.MiddleInitial AS MiddleInitial,   " +
            "		   Student.LastName AS LastName,  " +
            "		   Student.Email AS Email,  " +
            "		   Student.Password As Password  " +
            "	  FROM Student  )" +
            "BEGIN  " +
            "	SELECT Student.StudentID AS StudentID,   " +
            "		   Student.FirstName AS FirstName,   " +
            "		   Student.MiddleInitial AS MiddleInitial,   " +
            "		   Student.LastName AS LastName,  " +
            "		   Student.Email AS Email,  " +
            "		   Student.Password As Password  " +
            "	  FROM Student  " +
            "END  " +
            "ELSE  " +
            "	SELECT 000000000 AS StudentID,   " +
            "		   'First' AS FirstName,   " +
            "		   'M' AS MiddleInitial,   " +
            "		   'Last' AS LastName,  " +
            "		   'Student@franklincollege.edu' AS Email,  " +
            "		   'password' As Password  "
    End Sub

    Protected Sub grvManageStudents_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grvManageStudents.RowCommand
        'Reset Error Message
        lblManageStudentsErrorMessage.Visible = False

        'Insert New Student
        If (e.CommandName = "Insert") Then

            Dim txtStudentID As TextBox = grvManageStudents.FooterRow.FindControl("txtStudentID")
            Dim txtFirstName As TextBox = grvManageStudents.FooterRow.FindControl("txtFirstName")
            Dim txtMiddleInitial As TextBox = grvManageStudents.FooterRow.FindControl("txtMiddleInitial")
            Dim txtLastName As TextBox = grvManageStudents.FooterRow.FindControl("txtLastName")
            Dim txtEmail As TextBox = grvManageStudents.FooterRow.FindControl("txtEmail")
            Dim txtPassword As TextBox = grvManageStudents.FooterRow.FindControl("txtPassword")

            SetManageStudentsInsertCommand(txtStudentID.Text, txtFirstName.Text, txtMiddleInitial.Text, txtLastName.Text, txtEmail.Text, txtPassword.Text)

            CascadeGridviews()
            SetManageClassRosterStudentFullNameSelectCommand()

        ElseIf (e.CommandName = "Update") Then

            Dim index As Integer = Convert.ToInt32(e.CommandArgument.ToString())

            Dim lblOldStudentID As Label = grvManageStudents.Rows(index).FindControl("lblOldStudentIDEdit")
            Dim txtStudentID As Label = grvManageStudents.Rows(index).FindControl("txtStudentIDEdit")
            Dim txtFirstName As TextBox = grvManageStudents.Rows(index).FindControl("txtFirstNameEdit")
            Dim txtMiddleInitial As TextBox = grvManageStudents.Rows(index).FindControl("txtMiddleInitialEdit")
            Dim txtLastName As TextBox = grvManageStudents.Rows(index).FindControl("txtLastNameEdit")
            Dim txtEmail As TextBox = grvManageStudents.Rows(index).FindControl("txtEmailEdit")
            Dim txtPassword As TextBox = grvManageStudents.Rows(index).FindControl("txtPasswordEdit")

            SetManageStudentUpdateCommand(lblOldStudentID.Text, txtStudentID.Text, txtFirstName.Text, txtMiddleInitial.Text, txtLastName.Text, txtEmail.Text, txtPassword.Text)

            grvManageStudents.DataBind()

        ElseIf (e.CommandName = "Delete") Then
            Session("e") = e
            popupManageStudentsDeleteMessage.Show()

        End If


    End Sub

    Private Sub SetManageStudentsInsertCommand(ByVal studentID As String, ByVal firstName As String, ByVal middleInitial As String, ByVal lastName As String, ByVal email As String, ByVal password As String)

        Try

            If Not email.ToLower() Like "*@franklincollege.edu" Then
                Throw New Exception
            End If

            Dim queryManageStudentsInsert As String =
                "INSERT INTO Student ( " +
                  "StudentID, " +
                  "FirstName, " +
                  "MiddleInitial, " +
                  "LastName, " +
                  "Email, " +
                  "Password) " +
                "VALUES    ( " +
                            "'" + studentID + "', " +
                            "'" + firstName + "', " +
                            "'" + middleInitial + "', " +
                            "'" + lastName + "', " +
                            "'" + email + "', " +
                            "'" + password + "')"

            cmd = New SqlCommand(queryManageStudentsInsert, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            lblManageStudentsErrorMessage.Text = "Unable to insert new student. Please ensure that all fields are appropriately filled in and try again. Please remember all emails must end in '@FranklinCollege.edu' and all Student ID numbers must be unique and obtained from Student ID cards.'"
            lblManageStudentsErrorMessage.BackColor = Drawing.Color.Red
            lblManageStudentsErrorMessage.Visible = True
            con.Close()
        End Try

    End Sub

    Private Sub SetManageStudentUpdateCommand(ByVal oldStudentID As String, ByVal studentID As String, ByVal firstName As String, ByVal middleInitial As String, ByVal lastName As String, ByVal email As String, ByVal password As String)
        Try

            If Not email.ToLower Like "*@franklincollege.edu" Then
                Throw New Exception
            End If

            Dim queryManageStudentsUpdate As String =
                "UPDATE Student " +
                "SET   StudentID = '" + studentID + "', " +
                      "FirstName = '" + firstName + "', " +
                      "MiddleInitial = '" + middleInitial + "', " +
                      "LastName = '" + lastName + "', " +
                      "Email = '" + email + "', " +
                      "Password = '" + password + "' " +
                "WHERE StudentID = '" + oldStudentID + "'"

            cmd = New SqlCommand(queryManageStudentsUpdate, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            lblManageStudentsErrorMessage.Text = "Unable to update student. Please ensure that all fields are appropriately filled in and try again. Please remember all emails must end in '@FranklinCollege.edu' and all Student ID numbers must be unique and obtained from Student ID cards.'"
            lblManageStudentsErrorMessage.BackColor = Drawing.Color.Red
            lblManageStudentsErrorMessage.Visible = True
            con.Close()
        End Try
    End Sub

    Protected Sub SetManageStudentsDeleteCommand(ByVal studentID As String)

        Try
            Dim queryManageStudentsDelete As String =
                            "DELETE FROM Student " +
                            "WHERE StudentID = " + studentID

            cmd = New SqlCommand(queryManageStudentsDelete, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

        Catch ex As Exception
            lblManageStudentsErrorMessage.Text = "Unable to delete student. " + ex.Message 
            lblManageStudentsErrorMessage.BackColor = Drawing.Color.Red
            lblManageStudentsErrorMessage.Visible = True
            con.Close()
        End Try

    End Sub

    Protected Sub btnManageStudentsDelete_Click(sender As Object, e As EventArgs) Handles btnManageStudentsDelete.Click
        Dim eventA As GridViewCommandEventArgs = Session("e")
        Dim index As Integer = Convert.ToInt32(eventA.CommandArgument.ToString())
        Dim lblClassID As Label = grvManageStudents.Rows(index).FindControl("lblStudentID")

        SetManageStudentsDeleteCommand(lblClassID.Text)
        CascadeGridviews()
        'SetManageClassRosterDropDown()
        'SetClassTestResultsClassSelectCommand()
        'ddlClassSelectionClassResultsReport.DataBind()
        'SetClassTestResultsTestSelectCommand()
        'ddlTestSelectionClassResultsReport.DataBind()
    End Sub

    'Manage Classes

    Protected Sub SetManageClassesSelectCommand()

        sdsManageClasses.SelectCommand =
            "IF EXISTS (  " +
            "	SELECT Class.ClassID AS ClassID,  " +
            "		   Class.Class AS Class,  " +
            "		   Class.Year AS Year,  " +
            "		   Class.Semester AS Semester,  " +
            "		   Class.CourseCode AS CourseCode,  " +
            "		   Class.InstructorID AS InstructorID,  " +
            "		   Instructor.Title + ' ' + Instructor.LastName AS Instructor  " +
            "	  FROM Class,  " +
            "		   Instructor  " +
            "	 WHERE Class.InstructorID = Instructor.InstructorID AND  " +
            "		   Instructor.InstructorID = " + Session("strUserID") + ") " +
            "BEGIN  " +
            "	SELECT Class.ClassID AS ClassID,  " +
            "		   Class.Class AS Class,  " +
            "		   Class.Year AS Year,  " +
            "		   Class.Semester AS Semester,  " +
            "		   Class.CourseCode AS CourseCode,  " +
            "		   Class.InstructorID AS InstructorID,  " +
            "		   Instructor.Title + ' ' + Instructor.LastName AS Instructor  " +
            "	  FROM Class,  " +
            "		   Instructor  " +
            "	 WHERE Class.InstructorID = Instructor.InstructorID AND  " +
            "		   Instructor.InstructorID = " + Session("strUserID") + " " +
            "END  " +
            "ELSE  " +
            "    SELECT '0000' AS ClassID,  " +
            "		   'Please Add A Class' AS Class,  " +
            "		   'Year' AS Year,  " +
            "		   'Semester' AS Semester,  " +
            "		   'Course Code' AS CourseCode,  " +
            "		   'InstructorID' AS InstructorID,  " +
            "		   'Mr. Instructor' AS Instructor  "

    End Sub

    Protected Sub grvManageClasses_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grvManageClasses.RowCommand
        'Reset Error Message
        lblManageClassesErrorMessage.Visible = False

        'Insert New Student
        If (e.CommandName = "Insert") Then

            Dim txtClass As TextBox = grvManageClasses.FooterRow.FindControl("txtClass")
            Dim txtYear As TextBox = grvManageClasses.FooterRow.FindControl("txtYear")
            Dim ddlSemester As DropDownList = grvManageClasses.FooterRow.FindControl("ddlSemesterInsert")
            Dim txtCourseCode As TextBox = grvManageClasses.FooterRow.FindControl("txtCourseCode")

            SetManageClassesInsertCommand(txtClass.Text, txtYear.Text, ddlSemester.SelectedValue, txtCourseCode.Text, Session("strUserID"))

            CascadeGridviews()
            SetManageClassRosterDropDown()
            SetClassTestResultsClassSelectCommand()
            ddlClassSelectionClassResultsReport.DataBind()
            SetClassTestResultsTestSelectCommand()
            ddlTestSelectionClassResultsReport.DataBind()

        ElseIf (e.CommandName = "Update") Then

            Dim index As Integer = Convert.ToInt32(e.CommandArgument.ToString())

            Dim lblClassID As Label = grvManageClasses.Rows(index).FindControl("lblClassIDEdit")
            Dim txtClass As TextBox = grvManageClasses.Rows(index).FindControl("txtClassEdit")
            Dim txtYear As TextBox = grvManageClasses.Rows(index).FindControl("txtYearEdit")
            Dim ddlSemester As DropDownList = grvManageClasses.Rows(index).FindControl("ddlSemesterEdit")
            Dim txtCourseCode As TextBox = grvManageClasses.Rows(index).FindControl("txtCourseCodeEdit")

            SetManageClassesUpdateCommand(lblClassID.Text, txtClass.Text, txtYear.Text, ddlSemester.SelectedValue, txtCourseCode.Text, Session("strUserID"))

            CascadeGridviews()
            SetManageClassRosterDropDown()
            SetClassTestResultsClassSelectCommand()
            ddlClassSelectionClassResultsReport.DataBind()
            SetClassTestResultsTestSelectCommand()
            ddlTestSelectionClassResultsReport.DataBind()

        ElseIf (e.CommandName = "Delete") Then

            Session("e") = e
            popupManageClassesDeleteMessage.Show()

        End If



    End Sub

    Protected Sub btnManageClassesDelete_Click(sender As Object, e As EventArgs) Handles btnManageClassesDelete.Click
        Dim eventA As GridViewCommandEventArgs = Session("e")
        Dim index As Integer = Convert.ToInt32(eventA.CommandArgument.ToString())
        Dim lblClassID As Label = grvManageClasses.Rows(index).FindControl("lblClassID")

        SetManageClassesDeleteCommand(lblClassID.Text)
        CascadeGridviews()
        SetManageClassRosterDropDown()
        SetClassTestResultsClassSelectCommand()
        ddlClassSelectionClassResultsReport.DataBind()
        SetClassTestResultsTestSelectCommand()
        ddlTestSelectionClassResultsReport.DataBind()
    End Sub

    Private Sub SetManageClassesInsertCommand(ByVal classTitle As String, ByVal year As String, ByVal semester As String, ByVal courseCode As String, ByVal instructorID As String)

        Try

            If Not courseCode Like "??? ###" Then
                Throw New Exception
            ElseIf Not year Like "####" Then
                Throw New Exception
            End If

            Dim queryManageClassesInsert As String =
                "INSERT INTO Class ( " +
                  "Class, " +
                  "Year, " +
                  "Semester, " +
                  "CourseCode, " +
                  "InstructorID) " +
                "VALUES    ( " +
                            "'" + classTitle + "', " +
                            "'" + year + "', " +
                            "'" + semester + "', " +
                            "'" + courseCode + "', " +
                            "'" + instructorID + "')"

            cmd = New SqlCommand(queryManageClassesInsert, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

        Catch ex As Exception
            lblManageClassesErrorMessage.Text = "Unable to insert new class. Please ensure that all fields are appropriately filled in and try again. Remember the year must be a four digit number and course code must be in 'ABC 123' Format."
            lblManageClassesErrorMessage.BackColor = Drawing.Color.Red
            lblManageClassesErrorMessage.Visible = True
            con.Close()
        End Try

    End Sub

    Private Sub SetManageClassesUpdateCommand(ByVal classID As String, ByVal classTitle As String, ByVal year As String, ByVal semester As String, ByVal courseCode As String, ByVal instructorID As String)
        Try

            If Not courseCode Like "??? ###" Then
                Throw New Exception
            ElseIf Not year Like "####" Then
                Throw New Exception
            End If

            Dim queryManageClassesUpdate As String =
                "UPDATE Class " +
                "   SET Class = '" + classTitle + "', " +
                       "Year = '" + year + "', " +
                       "Semester = '" + semester + "', " +
                       "CourseCode = '" + courseCode + "', " +
                       "InstructorID = '" + instructorID + "' " +
                 "WHERE ClassID = '" + classID + "'"

            cmd = New SqlCommand(queryManageClassesUpdate, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

        Catch ex As Exception
            lblManageClassesErrorMessage.Text = "Unable to update class. Please ensure that all fields are appropriately filled in and try again. Remember the year must be a four digit number and course code must be in 'ABC 123' Format."
            lblManageClassesErrorMessage.BackColor = Drawing.Color.Red
            lblManageClassesErrorMessage.Visible = True
            con.Close()
        End Try
    End Sub

    Protected Sub SetManageClassesDeleteCommand(ByVal classID As String)

        Try
            Dim queryManageClassesDelete As String =
                            "DELETE FROM Class " +
                            "WHERE ClassID = " + classID

            cmd = New SqlCommand(queryManageClassesDelete, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

        Catch ex As Exception
            lblManageClassesErrorMessage.Text = "Unable to delete class. Please remove all students from this class and try deleting again."
            lblManageClassesErrorMessage.BackColor = Drawing.Color.Red
            lblManageClassesErrorMessage.Visible = True
            con.Close()
        End Try

    End Sub

    'Manage Tests

    Protected Sub SetManageTestsSelectCommand()
        sdsManageTests.SelectCommand =
        "IF EXISTS (" +
            "SELECT Test.TestID AS TestID, " +
                   "Test.ClassID AS ClassID, " +
                   "Test.Test AS Test, " +
                   "Test.Description AS Description, " +
                   "Test.Region AS Region, " +
                   "Test.Type AS Type, " +
                   "Class.Class AS Class " +
              "FROM Test, " +
                   "Class " +
             "WHERE Test.ClassID = Class.ClassID " +
               "AND Class.InstructorID = " + Session("strUserID") + " " +
               ") " +
        "BEGIN " +
            "SELECT Test.TestID AS TestID, " +
                   "Test.ClassID AS ClassID, " +
                   "Test.Test AS Test, " +
                   "Test.Description AS Description, " +
                   "Test.Region AS Region, " +
                   "Test.Type AS Type, " +
                   "Class.Class AS Class " +
              "FROM Test, " +
                   "Class " +
             "WHERE Test.ClassID = Class.ClassID " +
               "AND Class.InstructorID = " + Session("strUserID") + " " +
        "END " +
        "ELSE " +
            "SELECT '0000' AS TestID, " +
                   "'0000' AS ClassID, " +
                   "'Test' AS Test, " +
                   "'Please Add A Test Description' AS Description, " +
                   "'Region' AS Region, " +
                   "'Type' AS Type, " +
                   "'Class' AS Class "

    End Sub

    Protected Sub grvManageTests_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grvManageTests.RowCommand
        'Reset Error Message
        lblManageTestsErrorMessage.Visible = False

        'Insert New Student
        If (e.CommandName = "Insert") Then

            Dim ddlClassIDInsert As DropDownList = grvManageTests.FooterRow.FindControl("ddlClassIDInsert")
            Dim txtTest As TextBox = grvManageTests.FooterRow.FindControl("txtTest")
            Dim txtDescription As TextBox = grvManageTests.FooterRow.FindControl("txtDescription")
            Dim ddlRegion As DropDownList = grvManageTests.FooterRow.FindControl("ddlRegionInsert")
            Dim ddlType As DropDownList = grvManageTests.FooterRow.FindControl("ddlTypeInsert")
            Dim passingScore As String = GetPassingScore(ddlRegion.SelectedValue)

            SetManageTestsInsertCommand(ddlClassIDInsert.SelectedValue, txtTest.Text, txtDescription.Text, ddlRegion.SelectedValue, ddlType.SelectedValue, passingScore)

            CascadeGridviews()

        ElseIf (e.CommandName = "Update") Then

            Dim index As Integer = Convert.ToInt32(e.CommandArgument.ToString())

            Dim lblTestID As Label = grvManageTests.Rows(index).FindControl("lblTestIDEdit")
            Dim ddlClassIDInsert As DropDownList = grvManageTests.Rows(index).FindControl("ddlClassIDEdit")
            Dim txtTest As TextBox = grvManageTests.Rows(index).FindControl("txtTestEdit")
            Dim txtDescription As TextBox = grvManageTests.Rows(index).FindControl("txtDescriptionEdit")
            Dim ddlRegion As DropDownList = grvManageTests.Rows(index).FindControl("ddlRegionEdit")
            Dim ddlType As DropDownList = grvManageTests.Rows(index).FindControl("ddlTypeEdit")
            Dim passingScore As String = GetPassingScore(ddlRegion.SelectedValue)

            SetManageTestsUpdateCommand(lblTestID.Text, ddlClassIDInsert.SelectedValue, txtTest.Text, txtDescription.Text, ddlRegion.SelectedValue, ddlType.SelectedValue, passingScore)

            CascadeGridviews()

        ElseIf (e.CommandName = "Delete") Then
            Session("e") = e
            popupManageTestsDeleteMessage.Show()

        End If

    End Sub

    Protected Function GetPassingScore(ByVal region As String) As String
        Dim passingScore As String
        Select Case region

            Case "Global"
                passingScore = 75
            Case "Africa"
                passingScore = 17
            Case "Asia"
                passingScore = 15
            Case "Caribbean"
                passingScore = 4
            Case "Europe"
                passingScore = 16
            Case "Middle East"
                passingScore = 6
            Case "North America"
                passingScore = 3
            Case "Oceania"
                passingScore = 4
            Case "South America"
                passingScore = 4
            Case Else
                passingScore = 100
        End Select
        Return passingScore
    End Function

    Protected Sub SetManageTestsInsertCommand(ByVal classID As String, ByVal test As String, ByVal description As String, ByVal region As String, ByVal type As String, ByVal passingScore As String)
        Try

            Dim queryManageTestsInsert As String =
                "INSERT INTO Test ( " +
                  "ClassID, " +
                  "Test, " +
                  "Description, " +
                  "Region, " +
                  "Type," +
                  "PassingScore) " +
                "VALUES    ( " +
                            "'" + classID + "', " +
                            "'" + test + "', " +
                            "'" + description + "', " +
                            "'" + region + "', " +
                            "'" + type + "', " +
                            "'" + passingScore + "')"

            cmd = New SqlCommand(queryManageTestsInsert, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

        Catch ex As Exception
            lblManageTestsErrorMessage.Text = "Unable to insert new test. Please ensure that all fields are appropriately filled in and try again."
            lblManageTestsErrorMessage.BackColor = Drawing.Color.Red
            lblManageTestsErrorMessage.Visible = True
            con.Close()
        End Try

    End Sub

    Private Sub SetManageTestsUpdateCommand(ByVal testID As String, ByVal classID As String, ByVal test As String, ByVal description As String, ByVal region As String, ByVal type As String, ByVal passingScore As String)
        Try

            Dim queryManageTestsUpdate As String =
                "UPDATE Test " +
                "   SET classID = '" + classID + "', " +
                       "Test = '" + test + "', " +
                       "Description = '" + description + "', " +
                       "Region = '" + region + "', " +
                       "Type = '" + type + "', " +
                       "PassingScore = '" + passingScore + "' " +
                 "WHERE TestID = '" + testID + "'"

            cmd = New SqlCommand(queryManageTestsUpdate, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

        Catch ex As Exception
            lblManageClassesErrorMessage.Text = "Unable to update test. Please ensure that all fields are appropriately filled in and try again."
            lblManageClassesErrorMessage.BackColor = Drawing.Color.Red
            lblManageClassesErrorMessage.Visible = True
            con.Close()
        End Try
    End Sub

    Private Sub SetManageTestsClassSelectionDropDownSelectCommand()
        sdsManageTestsClassSelectionDropDown.SelectCommand =
        "IF EXISTS (  " +
        "	SELECT Class.Class AS Class, Class.ClassID AS ClassID  " +
        "	  FROM Class  " +
        "	 WHERE Class.InstructorID = " + Session("strUserID") + ") " +
        "BEGIN  " +
        "	SELECT Class.Class AS Class, Class.ClassID AS ClassID  " +
        "	  FROM Class  " +
        "	 WHERE Class.InstructorID = " + Session("strUserID") + " " +
        "END  " +
        "ELSE  " +
        "	SELECT 'Please Add A Class' AS Class, '0000' AS ClassID"
    End Sub

    Protected Sub SetManageTestsDeleteCommand(ByVal testID As String)

        Try
            Dim queryManageClassesDelete As String =
                            "DELETE FROM Test " +
                            "WHERE TestID = " + testID

            cmd = New SqlCommand(queryManageClassesDelete, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

        Catch ex As Exception
            lblManageClassesErrorMessage.Text = "Unable to delete test. "
            lblManageClassesErrorMessage.BackColor = Drawing.Color.Red
            lblManageClassesErrorMessage.Visible = True
            con.Close()
        End Try

    End Sub

    Protected Sub btnManageTestsDelete_Click(sender As Object, e As EventArgs) Handles btnManageTestsDelete.Click
        Dim eventA As GridViewCommandEventArgs = Session("e")
        Dim index As Integer = Convert.ToInt32(eventA.CommandArgument.ToString())
        Dim lblTestID As Label = grvManageTests.Rows(index).FindControl("lblTestID")

        SetManageTestsDeleteCommand(lblTestID.Text)
        CascadeGridviews()
        SetManageClassRosterDropDown()
        SetClassTestResultsClassSelectCommand()
        ddlClassSelectionClassResultsReport.DataBind()
        SetClassTestResultsTestSelectCommand()
        ddlTestSelectionClassResultsReport.DataBind()
    End Sub

    'Change Instructor Password

    Private Sub DisplayCurrentPassword()
        Try
            Dim queryPassword As String =
            "SELECT Password " +
              "FROM Instructor " +
             "WHERE InstructorID = " + Session("strUserID").ToString


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
            Dim queryManageInstructorsUpdate As String =
                "UPDATE Instructor " +
                "SET   Password = '" + txtNewPassword.Text + "' " +
                "WHERE InstructorID = '" + Session("strUserID") + "'"

            cmd = New SqlCommand(queryManageInstructorsUpdate, con)
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

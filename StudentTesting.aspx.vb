
Imports System.Data.SqlClient
Imports System.Data

Partial Class StudentTesting
    Inherits System.Web.UI.Page

    Public doubleContinentScale As Double = 0.75

    Private numQuestionsAsked As String

    Private numQuestionsAfrica As Integer = 19
    Private numQuestionsAsia As Integer = 17
    Private numQuestionsCaribbean As Integer = 5
    Private numQuestionsEurope As Integer = 18
    Private numQuestionsMiddleEast As Integer = 7
    Private numQuestionsNorthAmerica As Integer = 4
    Private numQuestionsOceania As Integer = 5
    Private numQuestionsSouthAmerica As Integer = 5

    Private testID As String
    Private testRegion As String
    Private testType As String

    Private studentID As String

    Private studentTestID As String

    Private questionID As New List(Of String)
    Private questionCorrectAnswer As New List(Of String)
    Private questionRegion As New List(Of String)
    Private questionState As New List(Of String)

    Dim con As SqlConnection
    Dim cmd As SqlCommand

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        testID = Session("strTestID")
        studentID = Session("strUserID")

        con = New SqlConnection("Data Source=KDR1241\SQLEXPRESS;Initial Catalog=MapQuiz;Integrated Security=True")

        If Not IsPostBack Then

            GetTestAttributes()
            CreateStudentTest()
            GenerateQuestions()
            DisplayFirstQuestion()
            StoreVariableToSession()
            txtAnswer.Attributes.Add("onKeyPress",
                   "doClick('" + btnNext.ClientID + "',event)")


        End If

    End Sub

    Protected Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click

        questionID = Session("questionID")
        questionCorrectAnswer = Session("questionCorrectAnswer")
        questionRegion = Session("questionRegion")
        questionState = Session("questionState")

        studentTestID = Session("studentTestID")

        Dim Query As String
        Dim cmd As SqlCommand
        Dim con As SqlConnection = New SqlConnection("Data Source=KDR1241\SQLEXPRESS;Initial Catalog=MapQuiz;Integrated Security=True")

        Dim answerState As String = "No Answer"

        Dim currentQuestion As Integer = Session("currentQuestion")

        If txtAnswer.Text = "" Then
            txtAnswer.Text = "0"
        End If

        If Session("strTestType").StartsWith("Practice") Then

            'Get My Answer
            Dim queryRegion As String =
                "SELECT State " +
                  "FROM Question " +
                 "WHERE CorrectAnswer = " + txtAnswer.Text + "  " +
                   "AND Region = '" + questionRegion(currentQuestion) + "'"

            cmd = New SqlCommand(queryRegion, con)

            con.Open()

            Using reader As SqlDataReader = cmd.ExecuteReader()

                While reader.Read()
                    answerState = reader(0)
                End While

            End Using

            con.Close()

            'Implement Practice Test
            lblStudentAnswer.Text = "Your Answer:    " + txtAnswer.Text + "    " + answerState
            lblCorrectAnswer.Text = "Correct Answer: " + questionCorrectAnswer(currentQuestion) + "    " + questionState(currentQuestion)
            popupPracticeTest.Show()

        Else

            'Report Students Answers

            Query =
                "UPDATE StudentTestQuestion" +
                "   SET StudentAnswer = " + txtAnswer.Text + " " +
                " WHERE StudentTestID = " + studentTestID + " AND " +
                       "QuestionID = " + questionID(currentQuestion).ToString

            cmd = New SqlCommand(Query, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            'Increment Number of Questions Answered
            Session("questionsAsked") = Session("questionsAsked") + 1


            'Check for correct response
            If questionCorrectAnswer(currentQuestion) = txtAnswer.Text Then

                Session("questionsCorrect") = Session("questionsCorrect") + 1

            End If

            'Increment Current Question
            currentQuestion = currentQuestion + 1

            'If currentQuestion < questionRegion.Count - 1 Then
            '    btnNext.Text = "Finish"
            'End If

            If currentQuestion < questionRegion.Count Then

                SetMapImage(questionRegion.Item(currentQuestion))

                lblState.Text = questionState.Item(currentQuestion).ToString

                Session("currentQuestion") = currentQuestion

            Else

                'Update StudentTest with Final Test Results
                Query =
                "UPDATE StudentTest" +
                "   SET FinishTime = CURRENT_TIMESTAMP, " +
                       "QuestionsAsked = " + Session("questionsAsked").ToString + ", " +
                       "QuestionsCorrect = " + Session("questionsCorrect").ToString +
                " WHERE StudentTestID = " + studentTestID.ToString

                'MsgBox(Query, MsgBoxStyle.Exclamation, "TESTING 1... 2... 3...")

                cmd = New SqlCommand(Query, con)

                con.Open()

                cmd.ExecuteNonQuery()

                con.Close()

                Response.Redirect("StudentTestResults.aspx")

            End If

            txtAnswer.Text = ""

        End If

    End Sub

    Protected Sub GenerateAfricaQuestions()

        Dim queryAfrica As String =
            "SELECT TOP " + numQuestionsAfrica.ToString + " * " +
                "FROM Question " +
                "WHERE Region = 'Africa' " +
                "ORDER BY newid()"

        InsertQuestions(queryAfrica)

    End Sub

    Protected Sub GenerateAsiaQuestions()

        Dim queryAsia As String =
        "SELECT TOP " + numQuestionsAsia.ToString + " * " +
          "FROM Question " +
         "WHERE Region = 'Asia' " +
         "ORDER BY newid()"

        InsertQuestions(queryAsia)

    End Sub

    Protected Sub GenerateCaribbeanQuestions()

        Dim queryCaribbean As String =
        "SELECT TOP " + numQuestionsCaribbean.ToString + " * " +
          "FROM Question " +
         "WHERE Region = 'Caribbean' " +
         "ORDER BY newid()"

        InsertQuestions(queryCaribbean)

    End Sub

    Protected Sub GenerateEuropeQuestions()

        Dim queryEurope As String =
        "SELECT TOP " + numQuestionsEurope.ToString + " * " +
          "FROM Question " +
         "WHERE Region = 'Europe' " +
         "ORDER BY newid()"

        InsertQuestions(queryEurope)

    End Sub

    Protected Sub GenerateMiddleEastQuestions()

        Dim queryMiddleEast As String =
        "SELECT TOP " + numQuestionsMiddleEast.ToString + " * " +
          "FROM Question " +
         "WHERE Region = 'Middle East' " +
         "ORDER BY newid()"

        InsertQuestions(queryMiddleEast)

    End Sub

    Protected Sub GenerateNorthAmericaQuestions()

        Dim queryNorthAmerica As String =
        "SELECT TOP " + numQuestionsNorthAmerica.ToString + " * " +
          "FROM Question " +
         "WHERE Region = 'North America' " +
         "ORDER BY newid()"

        InsertQuestions(queryNorthAmerica)

    End Sub

    Protected Sub GenerateOceaniaQuestions()

        Dim queryOceania As String =
        "SELECT TOP " + numQuestionsOceania.ToString + " * " +
          "FROM Question " +
         "WHERE Region = 'Oceania' " +
         "ORDER BY newid()"

        InsertQuestions(queryOceania)

    End Sub

    Protected Sub GenerateSouthAmericaQuestions()

        Dim querySouthAmerica As String =
        "SELECT TOP " + numQuestionsSouthAmerica.ToString + " * " +
          "FROM Question " +
         "WHERE Region = 'South America' " +
         "ORDER BY newid()"

        InsertQuestions(querySouthAmerica)

    End Sub

    Protected Sub InsertQuestions(ByVal query As String)

        cmd = New SqlCommand(query, con)

        con.Open()

        Using reader As SqlDataReader = cmd.ExecuteReader()

            While reader.Read()

                Dim con2 As SqlConnection = New SqlConnection("Data Source=KDR1241\SQLEXPRESS;Initial Catalog=MapQuiz;Integrated Security=True")

                Dim questionID As String = reader(0).ToString

                Dim queryNewStudentTestQuestion As String =
                "INSERT INTO StudentTestQuestion ( " +
                             "StudentTestID, " +
                             "QuestionID)" +
                "VALUES (" +
                             "'" + studentTestID + "'," +
                             "'" + questionID + "')"

                Dim cmd2 As New SqlCommand(queryNewStudentTestQuestion, con2)

                con2.Open()

                cmd2.ExecuteNonQuery()

                con2.Close()

            End While

        End Using

        con.Close()

    End Sub

    Private Sub SetMapImage(region As String)

        Select Case region

            Case "Africa"
                imgRegion.ImageUrl = "~/Maps/Africa.gif"

            Case "Asia"
                imgRegion.ImageUrl = "~/Maps/Asia.gif"

            Case "Caribbean"
                imgRegion.ImageUrl = "~/Maps/Caribbean.gif"

            Case "Europe"
                imgRegion.ImageUrl = "~/Maps/Europe.gif"

            Case "Middle East"
                imgRegion.ImageUrl = "~/Maps/Middle East.gif"

            Case "North America"
                imgRegion.ImageUrl = "~/Maps/North America.gif"

            Case "Oceania"
                imgRegion.ImageUrl = "~/Maps/Oceania.gif"

            Case "South America"
                imgRegion.ImageUrl = "~/Maps/South America.gif"

        End Select

    End Sub

    Private Sub GetTestAttributes()
        Dim queryRegion As String =
                "SELECT Region, Test, Type " +
                  "FROM Test " +
                 "WHERE testID = " + testID

        Dim cmd = New SqlCommand(queryRegion, con)

        con.Open()

        Using reader As SqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                testRegion = reader(0)
                lblTestTitle.Text = reader(1)
                Session("strTestType") = reader(2)
            End While

        End Using

        con.Close()
    End Sub

    Private Sub CreateStudentTest()
        Dim queryStudentTest As String =
                "INSERT INTO StudentTest ( " +
                            "StudentID, " +
                            "TestID, " +
                            "StartTime) " +
                "VALUES		( " +
                            "'" + studentID + "', " +
                            testID + ", " +
                            "CURRENT_TIMESTAMP) "

        cmd = New SqlCommand(queryStudentTest, con)

        con.Open()

        cmd.ExecuteNonQuery()
        cmd.CommandText = "Select @@Identity"
        studentTestID = cmd.ExecuteScalar()

        con.Close()
    End Sub

    Private Sub GenerateQuestions()

        Select Case testRegion
            Case "Global"

                'Calculate Number of Questions Asked
                numQuestionsAsked = numQuestionsAfrica + numQuestionsAsia + numQuestionsCaribbean + numQuestionsEurope + numQuestionsMiddleEast + numQuestionsNorthAmerica + numQuestionsOceania + numQuestionsSouthAmerica

                GenerateAfricaQuestions()
                GenerateAsiaQuestions()
                GenerateCaribbeanQuestions()
                GenerateEuropeQuestions()
                GenerateMiddleEastQuestions()
                GenerateNorthAmericaQuestions()
                GenerateOceaniaQuestions()
                GenerateSouthAmericaQuestions()


            Case "Africa"
                numQuestionsAsked = numQuestionsAfrica
                GenerateAfricaQuestions()

            Case "Asia"
                numQuestionsAsked = numQuestionsAsia
                GenerateAsiaQuestions()

            Case "Caribbean"
                numQuestionsAsked = numQuestionsCaribbean
                GenerateCaribbeanQuestions()

            Case "Europe"
                numQuestionsAsked = numQuestionsEurope
                GenerateEuropeQuestions()

            Case "Middle East"
                numQuestionsAsked = numQuestionsMiddleEast
                GenerateMiddleEastQuestions()

            Case "North America"
                numQuestionsAsked = numQuestionsNorthAmerica
                GenerateNorthAmericaQuestions()

            Case "Oceania"
                numQuestionsAsked = numQuestionsOceania
                GenerateOceaniaQuestions()

            Case "South America"
                numQuestionsAsked = numQuestionsSouthAmerica
                GenerateSouthAmericaQuestions()

            Case Else

        End Select

    End Sub

    Private Sub DisplayFirstQuestion()

        Dim queryStudentTestQuestion As String =
            "SELECT * " +
              "FROM StudentTestQuestion " +
             "WHERE StudentTestID = '" + studentTestID + "'"

        cmd = New SqlCommand(queryStudentTestQuestion, con)

        con.Open()

        Using reader As SqlDataReader = cmd.ExecuteReader()

            While reader.Read()

                Dim con2 As SqlConnection = New SqlConnection("Data Source=KDR1241\SQLEXPRESS;Initial Catalog=MapQuiz;Integrated Security=True")

                'Determine the Region for the current question
                Dim query2 As String =
                    "SELECT * " +
                      "FROM Question " +
                     "WHERE QuestionID = '" + reader(2).ToString + "'"

                Dim cmd2 As SqlCommand = New SqlCommand(query2, con2)

                con2.Open()

                Using reader2 As SqlDataReader = cmd2.ExecuteReader()

                    While reader2.Read()

                        questionID.Add(reader2(0).ToString)
                        questionCorrectAnswer.Add(reader2(1).ToString)
                        questionRegion.Add(reader2(2).ToString)
                        questionState.Add(reader2(3).ToString)

                    End While

                End Using

                con2.Close()

            End While

        End Using

        con.Close()

        'imgRegion.Height = 580 * doubleContinentScale
        'imgRegion.Width = 642 * doubleContinentScale

        SetMapImage(questionRegion.Item(0))

        lblState.Text = questionState.Item(0).ToString
    End Sub

    Private Sub StoreVariableToSession()
        Session("currentQuestion") = 0

        Session("questionID") = questionID
        Session("questionCorrectAnswer") = questionCorrectAnswer
        Session("questionRegion") = questionRegion
        Session("questionState") = questionState

        Session("studentTestID") = studentTestID
        Session("testID") = testID
        Session("testRegion") = testRegion
        Session("studentID") = studentID

        Session("questionsAsked") = 0
        Session("questionsCorrect") = 0
    End Sub

    Protected Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        questionID = Session("questionID")
        questionCorrectAnswer = Session("questionCorrectAnswer")
        questionRegion = Session("questionRegion")
        questionState = Session("questionState")

        studentTestID = Session("studentTestID")


        'Report Students Answers

        Dim Query As String
        Dim cmd As SqlCommand
        Dim con As SqlConnection = New SqlConnection("Data Source=KDR1241\SQLEXPRESS;Initial Catalog=MapQuiz;Integrated Security=True")

        Dim currentQuestion As Integer = Session("currentQuestion")


        Query =
            "UPDATE StudentTestQuestion" +
            "   SET StudentAnswer = " + txtAnswer.Text + " " +
            " WHERE StudentTestID = " + studentTestID + " AND " +
                   "QuestionID = " + questionID(currentQuestion).ToString

        cmd = New SqlCommand(Query, con)

        con.Open()

        cmd.ExecuteNonQuery()

        con.Close()

        'Increment Number of Questions Answered
        Session("questionsAsked") = Session("questionsAsked") + 1



        'Check for correct response
        If questionCorrectAnswer(currentQuestion) = txtAnswer.Text Then

            Session("questionsCorrect") = Session("questionsCorrect") + 1

        End If

        'Increment Current Question
        currentQuestion = currentQuestion + 1

        If currentQuestion < questionRegion.Count Then

            SetMapImage(questionRegion.Item(currentQuestion))

            lblState.Text = questionState.Item(currentQuestion).ToString

            Session("currentQuestion") = currentQuestion

        Else

            'Update StudentTest with Final Test Results
            Query =
            "UPDATE StudentTest" +
            "   SET FinishTime = CURRENT_TIMESTAMP, " +
                   "QuestionsAsked = " + Session("questionsAsked").ToString + ", " +
                   "QuestionsCorrect = " + Session("questionsCorrect").ToString + " " +
            " WHERE StudentTestID = " + studentTestID.ToString

            'MsgBox(Query, MsgBoxStyle.Exclamation, "TESTING 1... 2... 3...")

            cmd = New SqlCommand(Query, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Response.Redirect("StudentTestResults.aspx")

        End If

        txtAnswer.Text = ""

    End Sub
End Class

Imports System.Data.SqlClient

Partial Class StudentTestResults
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim testID As String = Session("strTestID")
        Dim studentTestID As String = Session("studentTestID")

        Dim con As SqlConnection = New SqlConnection("Data Source=KDR1241\SQLEXPRESS;Initial Catalog=MapQuiz;Integrated Security=True")

        'Determine current test information
        Dim query As String =
            "SELECT Test.Test, " +
                   "StudentTest.StartTime, " +
                   "StudentTest.FinishTime " +
              "FROM Test, StudentTest " +
             "WHERE Test.testID = " + testID + " AND " +
                   "StudentTest.StudentTestID = " + studentTestID

        Dim cmd As SqlCommand = New SqlCommand(query, con)

        con.Open()

        Using reader As SqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                lblTestTitleResults.Text = reader(0)
                lblTestStartTime.Text = reader(1)
                lblTestFinishTime.Text = reader(2)
            End While

        End Using

        con.Close()

        lblTestResults.Text =
            Session("questionsCorrect").ToString + "/" + Session("questionsAsked").ToString

    End Sub

    Protected Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        Response.Redirect("StudentHomePage.aspx")
    End Sub
End Class

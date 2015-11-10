Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports AjaxControlToolkit
Imports System.Collections.Generic

<WebService([Namespace]:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<System.Web.Script.Services.ScriptService()> _
Public Class Service
    Inherits System.Web.Services.WebService
    <WebMethod()> _
    Public Function GetStudents(knownCategoryValues As String) As CascadingDropDownNameValue()
        Dim query As String = "SELECT Student.FirstName FROM [Student]"
        Dim countries As List(Of CascadingDropDownNameValue) = GetData(query)
        Return countries.ToArray()
    End Function

    <WebMethod()> _
    Public Function GetStates(knownCategoryValues As String) As CascadingDropDownNameValue()
        Dim country As String = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)("CountryId")
        Dim query As String = String.Format("SELECT StateName, StateId FROM States WHERE CountryId = {0}", country)
        Dim states As List(Of CascadingDropDownNameValue) = GetData(query)
        Return states.ToArray()
    End Function

    <WebMethod()> _
    Public Function GetCities(knownCategoryValues As String) As CascadingDropDownNameValue()
        Dim state As String = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)("StateId")
        Dim query As String = String.Format("SELECT CityName, CityId FROM Cities WHERE StateId = {0}", state)
        Dim cities As List(Of CascadingDropDownNameValue) = GetData(query)
        Return cities.ToArray()
    End Function

    Private Function GetData(query As String) As List(Of CascadingDropDownNameValue)
        Dim conString As String = ConfigurationManager.ConnectionStrings("MapQuizConnectionString").ConnectionString
        Dim cmd As New SqlCommand(query)
        Dim values As New List(Of CascadingDropDownNameValue)()
        Using con As New SqlConnection(conString)
            con.Open()
            cmd.Connection = con
            Using reader As SqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    values.Add(New CascadingDropDownNameValue() With { _
                     .name = reader(0).ToString(), _
                     .value = reader(1).ToString() _
                    })
                End While
                reader.Close()
                con.Close()
                Return values
            End Using
        End Using
    End Function
End Class
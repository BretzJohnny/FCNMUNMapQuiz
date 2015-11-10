<%@ Page Title="" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="InstructorHomePage.aspx.vb" Inherits="InstuctorHomePage" %>

<%@ MasterType VirtualPath="~/Master.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />

    <style type="text/css">

        .modalBackground
        {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
        .modalPopup
        {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 300px;
            height: 140px;
        }

        .MyTabStyle .ajax__tab_header {
            font-family: "Helvetica Neue", Arial, Sans-Serif;
            font-size: 12pt;
            font-weight: bold;
            display: block;
        }

            .MyTabStyle .ajax__tab_header .ajax__tab_outer {
                padding-left: 3px;
                margin-right: 3px;
                background-size: auto;
                border-spacing: 3px;
                background-image: url(../../Images/OldPaperNoEdge.gif);
                border-width: 15px;
                border-image: url(../../Images/OldPaper.gif) 85 58 stretch;
            }

            .MyTabStyle .ajax__tab_header .ajax__tab_inner {
                padding: 3px 10px 2px 0px;
            }

        /*.MyTabStyle .ajax_tab_active .ajax_tab_tab {
            color: #ff0000;
        }*/

        .MyTabStyle .ajax__tab_hover .ajax__tab_outer {
            background-color: #ff0000;
        }

        .MyTabStyle .ajax__tab_hover .ajax__tab_inner {
            color: #fff;
        }

        .MyTabStyle .ajax__tab_hover .ajax__tab_tab {
            color: #ffffff;
        }

        .MyTabStyle .ajax__tab_active .ajax__tab_outer {
            border-bottom-color: #ffffff;
            background-color: #04467f;
        }

        .MyTabStyle .ajax__tab_active .ajax__tab_inner {
            color: #04467f;
            border-color: #333;
        }

        .MyTabStyle .ajax__tab_active .ajax__tab_tab {
            color: #ffffff;
        }

        .MyTabStyle .ajax__tab_header .ajax__tab_outer {
            border-bottom-color: #ffffff;
            background-color: #04467f;
        }

        .MyTabStyle .ajax__tab_header .ajax__tab_inner {
            color: #fff;
            border-color: #333;
        }

        .MyTabStyle .ajax__tab_header .ajax__tab_tab {
            color: #ffffff;
        }

        /*.MyTabStyle .ajax__tab_inner .ajax__tab_tab {
            color: #ffffff;
        }*/

        .MyTabStyle .ajax__tab_body {
            font-family: verdana,tahoma,helvetica;
            font-size: 10pt;
            padding-left: 0;
            padding-right: 0;
            padding-top: 0;
            padding-bottom: 20pt;
            background-size: auto;
            border-spacing: 3px;
            background-image: url(../../Images/OldPaperNoEdge.gif);
            border-width: 20px;
            border-image: url(../../Images/OldPaper.gif) 85 58 stretch;
        }
    </style>

    <%--    <style type="text/css">
        .MyTabStyle .ajax__tab_header {
            font-family: "Helvetica Neue", Arial, Sans-Serif;
            font-size: 12pt;
            font-weight: bold;
            display: block;
        }

            .MyTabStyle .ajax__tab_header .ajax__tab_outer {
                border-color: #04467f;
                color: #39ff00;
                padding-left: 10px;
                margin-right: 3px;
                border: solid 1px #d7d7d7;
                background-color: #afb30f;
            }

            .MyTabStyle .ajax__tab_header .ajax__tab_inner {
                border-color: #ff0000;
                color: #ff0000;
                padding: 3px 10px 2px 0px;
            }

        /*.MyTabStyle .ajax_tab_active .ajax_tab_tab {
            color: #ff0000;
        }*/

        .MyTabStyle .ajax__tab_hover .ajax__tab_outer {
            background-color: #afb30f;
        }

        .MyTabStyle .ajax__tab_hover .ajax__tab_inner {
            color: #fff;
        }

        .MyTabStyle .ajax__tab_hover .ajax__tab_tab {
            color: #ffffff;
        }

        .MyTabStyle .ajax__tab_active .ajax__tab_outer {
            border-bottom-color: #ffffff;
            background-color: #04467f;
        }

        .MyTabStyle .ajax__tab_active .ajax__tab_inner {
            color: #04467f;
            border-color: #333;
        }

        .MyTabStyle .ajax__tab_active .ajax__tab_tab {
            color: #ffffff;
        }

        .MyTabStyle .ajax__tab_header .ajax__tab_outer {
            border-bottom-color: #ffffff;
            background-color: #04467f;
        }

        .MyTabStyle .ajax__tab_header .ajax__tab_inner {
            color: #fff;
            border-color: #333;
        }

        .MyTabStyle .ajax__tab_header .ajax__tab_tab {
            color: #ffffff;
        }

        /*.MyTabStyle .ajax__tab_inner .ajax__tab_tab {
            color: #ffffff;
        }*/

        .MyTabStyle .ajax__tab_body {
            font-family: verdana,tahoma,helvetica;
            font-size: 10pt;
            background-color: #fff;
            border-top-width: 0;
            border: solid 1px #d7d7d7;
            border-top-color: #ffffff;
        }
    </style>--%>

    <ajaxToolkit:ToolkitScriptManager runat="server" />
    <ajaxToolkit:TabContainer ID="container" runat="server" CssClass="MyTabStyle" UseVerticalStripPlacement="false">
        <ajaxToolkit:TabPanel ID="tabManageStudents" runat="server"
            CssClass="MyTabStyle"
            HeaderText="Students">
            <ContentTemplate>
                <asp:Table runat="server" HorizontalAlign="Center">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Table runat="server" Width="100%" SkinID="White">
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell>
                                        <asp:Label ID="lblStudentPageTitle" runat="server" Text="Manage Students" Font-Size="30pt" SkinID="White" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell>
                                        <asp:Label ID="lblManageStudentsErrorMessage" runat="server" Visible="false" Font-Size="14pt" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell>
                                        <asp:GridView ID="grvManageStudents" runat="server"
                                            AllowPaging="True"
                                            AllowSorting="True"
                                            AutoGenerateColumns="False"
                                            AutoGenerateDeleteButton="False"
                                            AutoGenerateEditButton="False"
                                            DataKeyNames="StudentID"
                                            DataSourceID="sdsManageStudents"
                                            PageSize="20"
                                            SkinID="gridViewSkin"
                                            ShowFooter="True">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Student ID" SortExpression="StudentID" Visible="false">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblOldStudentIDEdit" runat="server" Text='<%# Eval("StudentID")%>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblOldStudentID" runat="server"></asp:Label>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOldStudentID" runat="server" Text='<%# Bind("StudentID")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Student ID" SortExpression="StudentID">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="txtStudentIDEdit" runat="server" Text='<%# Eval("StudentID") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtStudentID" runat="server"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStudentID" runat="server" Text='<%# Bind("StudentID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="First Name" SortExpression="FirstName">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtFirstNameEdit" runat="server" Text='<%# Bind("FirstName") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Middle Initial" SortExpression="MiddleInitial">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtMiddleInitialEdit" runat="server" Text='<%# Bind("MiddleInitial")%>' Width="20" MaxLength="1"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtMiddleInitial" runat="server" Width="20" MaxLength="1"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("MiddleInitial") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Last Name" SortExpression="LastName">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtLastNameEdit" runat="server" Text='<%# Bind("LastName") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Franklin Email" SortExpression="Email">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtEmailEdit" runat="server" Text='<%# Bind("Email") %>' Width="100%"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtEmail" runat="server" Width="100%"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Password" SortExpression="Password">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtPasswordEdit" runat="server" Text='<%# Bind("Password") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Password") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <EditItemTemplate>
                                                        <asp:Button ID="btnUpdate" runat="server" CausesValidation="True"
                                                            CommandName="Update" Text="Update" Width="50pt" CommandArgument='<%# grvManageStudents.Rows.Count.ToString()%>' />
                                                        &nbsp;
                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="False"
                                                CommandName="Cancel" Text="Cancel" Width="50pt" />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Button ID="btnInsert" runat="server" CausesValidation="True"
                                                            CommandName="Insert" Text="Insert" Width="50pt" CommandArgument='<%# grvManageStudents.Rows.Count.ToString()%>' />
                                                        &nbsp;
                                            <asp:Button ID="btnCancelInsert" runat="server" CausesValidation="False"
                                                CommandName="Cancel" Text="Cancel" Width="50pt" />
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnEdit" runat="server" CausesValidation="True"
                                                            CommandName="Edit" Text="Edit" Width="50pt" />
                                                        &nbsp;
                                            <asp:Button ID="btnDelete" runat="server" CausesValidation="False"
                                                CommandName="Delete" Text="Delete" Width="50pt" CommandArgument='<%# grvManageStudents.Rows.Count.ToString()%>'/>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:SqlDataSource ID="sdsManageStudents" runat="server"
                                            ConnectionString="<%$ ConnectionStrings:MapQuizConnectionString %>"
                                            SelectCommand="SELECT TOP 1 * FROM Student"
                                            UpdateCommand="SELECT TOP 1 * FROM Student"
                                            DeleteCommand="SELECT TOP 1 * FROM Student"
                                            InsertCommand="SELECT TOP 1 * FROM Student"></asp:SqlDataSource>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="tabManageClasses" runat="server"
            CssClass="MyTabStyle"
            HeaderText="Classes">
            <ContentTemplate>
                <asp:Table runat="server" HorizontalAlign="Center">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Table runat="server" Width="100%" SkinID="White">
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell>
                                        <asp:Label ID="lblClassPageTitle" runat="server" Text="Manage Classes" Font-Size="30pt" SkinID="White" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell>
                                        <asp:Label ID="lblManageClassesErrorMessage" runat="server" Visible="false" Font-Size="14pt" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell>
                                        <asp:GridView ID="grvManageClasses" runat="server"
                                            AllowPaging="True"
                                            AllowSorting="True"
                                            AutoGenerateColumns="False"
                                            AutoGenerateDeleteButton="False"
                                            AutoGenerateEditButton="False"
                                            DataKeyNames="ClassID"
                                            DataSourceID="sdsManageClasses"
                                            PageSize="10"
                                            SkinID="gridViewSkin"
                                            ShowFooter="True">
                                            <Columns>
                                                <asp:TemplateField HeaderText="ClassID" SortExpression="ClassID" Visible="false">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblClassIDEdit" runat="server" Text='<%# Bind("ClassID")%>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblClassID" runat="server" Text='<%# Bind("ClassID")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Class" SortExpression="Class">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtClassEdit" runat="server" Text='<%# Bind("Class")%>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtClass" runat="server"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Class")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Year" SortExpression="Year">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtYearEdit" runat="server" Text='<%# Bind("Year")%>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtYear" runat="server" MaxLength="4"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Year")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Semester" SortExpression="Semester">
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlSemesterEdit" runat="server" SelectedValue='<%#Bind("Semester")%>'>
                                                            <asp:ListItem Text="Fall" Value="Fall"></asp:ListItem>
                                                            <asp:ListItem Text="Spring" Value="Spring"></asp:ListItem>
                                                            <asp:ListItem Text="Winter" Value="Winter"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList ID="ddlSemesterInsert" runat="server" SelectedValue='<%#Bind("Semester")%>'>
                                                            <asp:ListItem Text="Fall" Value="Fall"></asp:ListItem>
                                                            <asp:ListItem Text="Spring" Value="Spring"></asp:ListItem>
                                                            <asp:ListItem Text="Winter" Value="Winter"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Semester")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Course Code" SortExpression="CourseCode">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtCourseCodeEdit" runat="server" Text='<%# Bind("CourseCode")%>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtCourseCode" runat="server" MaxLength="7"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("CourseCode")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <EditItemTemplate>
                                                        <asp:Button ID="btnUpdate" runat="server" CausesValidation="True"
                                                            CommandName="Update" Text="Update" Width="50pt" CommandArgument='<%# grvManageClasses.Rows.Count.ToString()%>' />
                                                        &nbsp;
                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="False"
                                                CommandName="Cancel" Text="Cancel" Width="50pt" />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Button ID="btnInsert" runat="server" CausesValidation="True"
                                                            CommandName="Insert" Text="Insert" Width="50pt" />
                                                        &nbsp;
                                            <asp:Button ID="btnCancelInsert" runat="server" CausesValidation="False"
                                                CommandName="Cancel" Text="Cancel" Width="50pt" />
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnEdit" runat="server" CausesValidation="True"
                                                            CommandName="Edit" Text="Edit" Width="50pt" />
                                                        &nbsp;
                                            <asp:Button ID="btnDelete" runat="server" CausesValidation="False"
                                                CommandName="Delete" Text="Delete" Width="50pt" 
                                                CommandArgument='<%# grvManageClasses.Rows.Count.ToString()%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:SqlDataSource ID="sdsManageClasses" runat="server"
                                            ConnectionString="<%$ ConnectionStrings:MapQuizConnectionString %>"
                                            DeleteCommand="SELECT TOP 1 * FROM Student"
                                            UpdateCommand="SELECT TOP 1 * FROM Class"
                                            SelectCommand="SELECT TOP 1 * FROM Class"></asp:SqlDataSource>
                                        <%-- <asp:SqlDataSource ID="sdsInstructorID" runat="server"
                                            ConnectionString="<%$ ConnectionStrings:MapQuizConnectionString %>"
                                            SelectCommand="SELECT InstructorID, Title + ' ' + LastName AS Instructor FROM [Instructor]"></asp:SqlDataSource>--%>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="tabManageTests" runat="server"
            CssClass="MyTabStyle"
            HeaderText="Tests">
            <ContentTemplate>
                <asp:Table runat="server" HorizontalAlign="Center">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Table runat="server" Width="100%" SkinID="White">
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell>
                                        <asp:Label ID="lblTestPage" runat="server" Text="Manage Tests" Font-Size="30pt" SkinID="White" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell>
                                        <asp:Label ID="lblManageTestsErrorMessage" runat="server" Visible="false" Font-Size="14pt" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell HorizontalAlign="Center">
                                        <asp:Table runat="server">
<%--                                            <asp:TableRow>
                                                <asp:TableCell>
                                                    <asp:TextBox runat="server" ID="txtTestFilter" />
                                                </asp:TableCell><asp:TableCell>
                                                    <asp:Button runat="server" ID="btnTestFilter" Text="Fliter" />
                                                </asp:TableCell>
                                            </asp:TableRow>--%>
                                        </asp:Table>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell>
                                        <asp:GridView ID="grvManageTests" runat="server"
                                            AllowPaging="True"
                                            AllowSorting="True"
                                            AutoGenerateColumns="False"
                                            AutoGenerateDeleteButton="False"
                                            AutoGenerateEditButton="False"
                                            DataKeyNames="TestID"
                                            DataSourceID="sdsManageTests"
                                            PageSize="10"
                                            SkinID="gridViewSkin"
                                            ShowFooter="True">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Test ID" SortExpression="TestID" Visible="false">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblTestIDEdit" runat="server" Text='<%# Eval("TestID")%>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTestID" runat="server" Text='<%# Bind("TestID")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Class" SortExpression="Class">
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlClassIDEdit" runat="server" DataSourceID="sdsManageTestsClassSelectionDropDown"
                                                            DataTextField="Class" DataValueField="ClassID" />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList ID="ddlClassIDInsert" runat="server" DataSourceID="sdsManageTestsClassSelectionDropDown"
                                                            DataTextField="Class" DataValueField="ClassID" />
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Class")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Test" SortExpression="Test">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtTestEdit" runat="server" Text='<%# Bind("Test")%>' MaxLength="50" Width="98%"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtTest" runat="server" MaxLength="50" Width="98%"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTest" runat="server" Text='<%# Bind("Test")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Description" SortExpression="Description">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtDescriptionEdit" runat="server" Text='<%# Bind("Description")%>' MaxLength="250" Width="98%"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtDescription" runat="server" MaxLength="250" Width="98%"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField HeaderText="Asia Questions" SortExpression="AsiaQuestions">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtAsiaQuestions" runat="server" Text='<%# Bind("AsiaQuestions")%>' Enabled="false"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtAsiaQuestionsFooter" runat="server" Text='<%# Bind("AsiaQuestions")%>' Enabled="false"></asp:TextBox>
                                                        <ajaxToolkit:NumericUpDownExtender TargetControlID="txtAsiaQuestionsFooter" runat="server" Minimum="1" Maximum="55" Width="100"/>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAsiaQuestions" runat="server" Text='<%# Bind("AsiaQuestions")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Region" SortExpression="Region">
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlRegionEdit" runat="server" SelectedValue='<%#Bind("Region")%>'>
                                                            <asp:ListItem Text="Global" Value="Global"></asp:ListItem>
                                                            <asp:ListItem Text="Africa" Value="Africa"></asp:ListItem>
                                                            <asp:ListItem Text="Asia" Value="Asia"></asp:ListItem>
                                                            <asp:ListItem Text="Caribbean" Value="Caribbean"></asp:ListItem>
                                                            <asp:ListItem Text="Europe" Value="Europe"></asp:ListItem>
                                                            <asp:ListItem Text="Middle East" Value="Middle East"></asp:ListItem>
                                                            <asp:ListItem Text="North America" Value="North America"></asp:ListItem>
                                                            <asp:ListItem Text="Oceania" Value="Oceania"></asp:ListItem>
                                                            <asp:ListItem Text="South America" Value="South America"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList ID="ddlRegionInsert" runat="server" SelectedValue='<%#Bind("Type")%>'>
                                                            <asp:ListItem Text="Global" Value="Global"></asp:ListItem>
                                                            <asp:ListItem Text="Africa" Value="Africa"></asp:ListItem>
                                                            <asp:ListItem Text="Asia" Value="Asia"></asp:ListItem>
                                                            <asp:ListItem Text="Caribbean" Value="Caribbean"></asp:ListItem>
                                                            <asp:ListItem Text="Europe" Value="Europe"></asp:ListItem>
                                                            <asp:ListItem Text="Middle East" Value="Middle East"></asp:ListItem>
                                                            <asp:ListItem Text="North America" Value="North America"></asp:ListItem>
                                                            <asp:ListItem Text="Oceania" Value="Oceania"></asp:ListItem>
                                                            <asp:ListItem Text="South America" Value="South America"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRegion" runat="server" Text='<%# Bind("Region")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Type" SortExpression="Type">
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlTypeEdit" runat="server" SelectedValue='<%#Bind("Type")%>'>
                                                            <asp:ListItem Text="Official" Value="Official"></asp:ListItem>
                                                            <asp:ListItem Text="Practice" Value="Practice"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList ID="ddlTypeInsert" runat="server" SelectedValue='<%#Bind("Type")%>'>
                                                            <asp:ListItem Text="Official" Value="Official"></asp:ListItem>
                                                            <asp:ListItem Text="Practice" Value="Practice"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblType" runat="server" Text='<%# Bind("Type")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <EditItemTemplate>
                                                        <asp:Button ID="btnUpdate" runat="server" CausesValidation="True"
                                                            CommandName="Update" Text="Update" Width="50pt" CommandArgument='<%# grvManageTests.Rows.Count.ToString()%>' />
                                                        &nbsp;
                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="False"
                                                CommandName="Cancel" Text="Cancel" Width="50pt" />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Button ID="btnInsert" runat="server" CausesValidation="True"
                                                            CommandName="Insert" Text="Insert" Width="50pt" />
                                                        &nbsp;
                                            <asp:Button ID="btnCancelInsert" runat="server" CausesValidation="False"
                                                CommandName="Cancel" Text="Cancel" Width="50pt" />
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnEdit" runat="server" CausesValidation="True"
                                                            CommandName="Edit" Text="Edit" Width="50pt" />
                                                        &nbsp;
                                            <asp:Button ID="btnDelete" runat="server" CausesValidation="False"
                                                CommandName="Delete" Text="Delete" Width="50pt" CommandArgument='<%# grvManageTests.Rows.Count.ToString()%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>

                                        <asp:SqlDataSource ID="sdsManageTests" runat="server"
                                            ConnectionString="<%$ ConnectionStrings:MapQuizConnectionString %>"
                                            SelectCommand="SELECT Top 1 * FROM Test"
                                            UpdateCommand="SELECT Top 1 * FROM Test"
                                            DeleteCommand="SELECT TOP 1 * FROM Test"
                                            InsertCommand="SELECT Top 1 * From Test"></asp:SqlDataSource>
                                        <asp:SqlDataSource ID="sdsManageTestsClassSelectionDropDown" runat="server"
                                            ConnectionString="<%$ ConnectionStrings:MapQuizConnectionString %>"
                                            SelectCommand="SELECT ClassID, Class FROM [Class]"></asp:SqlDataSource>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="tabManageClassRoster" runat="server"
            CssClass="MyTabStyle"
            HeaderText="Class Rosters">
            <ContentTemplate>
                <asp:Table runat="server" HorizontalAlign="Center">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Table runat="server" Width="100%" SkinID="White">
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell>
                                        <asp:Label ID="lblManageClassRosterPageTitle" runat="server" Text="Manage Class Rosters" Font-Size="30pt" SkinID="White" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell HorizontalAlign="Center">
                                        <asp:Table runat="server">
                                            <asp:TableRow>
                                                <asp:TableCell>
                                        <asp:Label runat="server" Text="Select Class:" Font-Size="15pt" SkinID="White"/>
                                                </asp:TableCell>
                                                <asp:TableCell>
                                                    <asp:DropDownList ID="ddlManageClassRoster" runat="server" AutoPostBack="true" Font-Size="11pt" EnableViewState="true" />
                                                </asp:TableCell>
                                            </asp:TableRow>
                                        </asp:Table>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell>
                                        <asp:GridView ID="grvManageClassRoster" runat="server"
                                            AllowPaging="True"
                                            AllowSorting="True"
                                            AutoGenerateColumns="False"
                                            AutoGenerateDeleteButton="False"
                                            AutoGenerateEditButton="False"
                                            DataKeyNames="StudentID"
                                            DataSourceID="sdsManageClassRoster"
                                            PageSize="10"
                                            SkinID="gridViewSkin"
                                            ShowFooter="True"
                                            ShowHeaderWhenEmpty="true">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Student Class ID" SortExpression="StudentClassID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStudentClassID" runat="server" Text='<%# Bind("StudentClassID")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Student" SortExpression="StudentFullName">
                                                    <FooterTemplate>
                                                        <asp:DropDownList ID="ddlStudentInsert" runat="server" DataSourceID="sdsManageClassRosterStudentFullName"
                                                            DataTextField="StudentFullName" DataValueField="StudentID"
                                                            SelectedValue='<%# Bind("StudentID")%>' />
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStudentFullName" runat="server" Text='<%# Bind("StudentFullName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField HeaderText="Class" SortExpression="Class">
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlClassEdit" runat="server" DataSourceID="sdsClassName"
                                                            DataTextField="Class" DataValueField="ClassID"
                                                            SelectedValue='<%# Bind("ClassID")%>' />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList ID="ddlClassInsert" runat="server" DataSourceID="sdsClassName"
                                                            DataTextField="Class" DataValueField="ClassID"
                                                            SelectedValue='<%# Bind("StudentID")%>' />
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Class")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField ShowHeader="False">
                                                    <EditItemTemplate>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Button ID="btnInsert" runat="server" CausesValidation="True"
                                                            CommandName="Insert" Text="Insert" Width="50pt" />
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnDelete" runat="server" CausesValidation="False"
                                                            CommandName="Delete" Text="Delete" Width="50pt" CommandArgument='<%# grvManageClassRoster.Rows.Count.ToString()%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlStudentInsert" runat="server" DataSourceID="sdsManageClassRosterStudentFullName"
                                                                DataTextField="StudentFullName" DataValueField="StudentID"
                                                                SelectedValue='<%# Bind("StudentID")%>' />
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnInsert" runat="server" CausesValidation="True"
                                                                CommandName="Insert" Text="Insert" Width="50pt" />
                                                        </td>
                                                    </tr>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                        <asp:SqlDataSource ID="sdsManageClassRoster" runat="server"
                                            ConnectionString="<%$ ConnectionStrings:MapQuizConnectionString %>"
                                            DeleteCommand="SELECT TOP 1 * FROM Student"></asp:SqlDataSource>
                                        <asp:SqlDataSource ID="sdsClassName" runat="server"
                                            ConnectionString="<%$ ConnectionStrings:MapQuizConnectionString %>"
                                            SelectCommand="SELECT ClassID, Class FROM [Class]"></asp:SqlDataSource>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="tabStudentTestResultsReport" runat="server"
            CssClass="MyTabStyle"
            HeaderText="Student Test Results Report">
            <ContentTemplate>
                <asp:Table runat="server" HorizontalAlign="Center">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Table runat="server" Width="100%" SkinID="White">
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell>
                                        <asp:Label runat="server" Text="Student Test Results Report" Font-Size="30pt" SkinID="White" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell HorizontalAlign="Center">
                                        <asp:Table runat="server">
                                            <asp:TableRow>
                                                <asp:TableCell>
                                                    <asp:Table runat="server">
                                                        <asp:TableRow>
                                                            <asp:TableCell>
                                                                <asp:Label runat="server" Text="Student:" Font-Size="15pt" SkinID="White"/>
                                                            </asp:TableCell>
                                                            <asp:TableCell>
                                                                <asp:DropDownList ID="ddlStudentSelection" runat="server" Font-Size="11pt" AutoPostBack="true" EnableViewState="true" />
                                                            </asp:TableCell>
                                                        </asp:TableRow>
                                                        <asp:TableRow>
                                                            <asp:TableCell>
                                                                <asp:Label runat="server" Text="Grade:" Font-Size="15pt" SkinID="White"/>
                                                            </asp:TableCell>
                                                            <asp:TableCell>
                                                                <asp:Label ID="lblStudentTestGrade" runat="server" Text="No Grade Available" Font-Size="15pt" SkinID="White" />
                                                            </asp:TableCell>
                                                        </asp:TableRow>
                                                    </asp:Table>
                                                </asp:TableCell>
                                                <asp:TableCell>
                                                    <asp:Table runat="server">
                                                        <asp:TableRow>
                                                            <asp:TableCell>
                                                                <asp:Label runat="server" Text="Test:" Font-Size="15pt" SkinID="White"/>
                                                            </asp:TableCell>
                                                            <asp:TableCell>
                                                                <asp:DropDownList ID="ddlTestSelection" runat="server" Font-Size="11pt" AutoPostBack="true" EnableViewState="true" />
                                                            </asp:TableCell>
                                                        </asp:TableRow>
                                                        <asp:TableRow>
                                                            <asp:TableCell>
                                                                <asp:Label runat="server" Text="Score:" Font-Size="15pt" SkinID="White"/>
                                                            </asp:TableCell>
                                                            <asp:TableCell>
                                                                <asp:Label ID="lblStudentTestScore" runat="server" Text="No Test Selected" Font-Size="15pt" SkinID="White" />
                                                            </asp:TableCell>
                                                        </asp:TableRow>
                                                    </asp:Table>
                                                </asp:TableCell>
                                            </asp:TableRow>
                                        </asp:Table>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell>
                                        <asp:GridView ID="grvStudentTestResultsReport" runat="server"
                                            AllowPaging="True"
                                            AllowSorting="True"
                                            AutoGenerateColumns="False"
                                            AutoGenerateDeleteButton="False"
                                            AutoGenerateEditButton="False"
                                            DataKeyNames="StudentTestID"
                                            DataSourceID="sdsStudentTest"
                                            PageSize="10"
                                            SkinID="gridViewSkin"
                                            ShowFooter="False">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Region" SortExpression="Region">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRegion" runat="server" Text='<%# Bind("Region")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="State" SortExpression="State">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblState" runat="server" Text='<%# Bind("State")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Student Answer" SortExpression="StudentAnswer">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAnswer" runat="server" Text='<%# Bind("StudentAnswer")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Correct Answer" SortExpression="CorrectAnswer">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCorrectAnswer" runat="server" Text='<%# Bind("CorrectAnswer")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Accuracy" SortExpression="Accuracy">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAccuracy" runat="server" Text='<%# Bind("Accuracy")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:SqlDataSource ID="sdsStudentTest" runat="server"
                                            ConnectionString="<%$ ConnectionStrings:MapQuizConnectionString %>"
                                            SelectCommand="SELECT StudentTest.StudentTestID AS StudentTestID, Answer.TestQuestionNumber AS QuestionNumber, Answer.Correct AS Accuracy, Answer.Answer AS Answer, Question.State AS State, Question.CorrectAnswer AS CorrectAnswer FROM [StudentTest], [Answer], [Question] WHERE Answer.QuestionID = Question.QuestionID AND StudentTest.StudentTestID = Answer.StudentTestID"></asp:SqlDataSource>
                                        <asp:SqlDataSource ID="sdsTestName" runat="server"
                                            ConnectionString="<%$ ConnectionStrings:MapQuizConnectionString %>"></asp:SqlDataSource>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="tabClassTestResultsReport" runat="server"
            CssClass="MyTabStyle"
            HeaderText="Class Test Results Report">
            <ContentTemplate>
                <asp:Table runat="server" HorizontalAlign="Center">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Table runat="server" Width="100%" SkinID="White">
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell>
                <asp:Label runat="server" Text="Class Test Results Report" Font-Size="30pt" SkinID="White" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell HorizontalAlign="Center">
                                        <asp:Table runat="server">
                                            <asp:TableRow>
                                                <asp:TableCell>
                                                    <asp:Table runat="server">
                                                        <asp:TableRow>
                                                            <asp:TableCell>
                                        <asp:Label runat="server" Text="Class:" Font-Size="15pt" SkinID="White"/>
                                                            </asp:TableCell>
                                                            <asp:TableCell>
                                                                <asp:DropDownList ID="ddlClassSelectionClassResultsReport" runat="server" DataSourceID="sdsClassSelection" DataTextField="Class" DataValueField="ClassID" Font-Size="11pt" AutoPostBack="true" EnableViewState="true" ViewStateMode="Enabled" />
                                                            </asp:TableCell>
                                                        </asp:TableRow>
                                                    </asp:Table>
                                                </asp:TableCell>
                                                <asp:TableCell>
                                                    <asp:Table runat="server">
                                                        <asp:TableRow>
                                                            <asp:TableCell>
                                        <asp:Label runat="server" Text="Test:" Font-Size="15pt" SkinID="White"/>
                                                            </asp:TableCell>
                                                            <asp:TableCell>
                                                                <asp:DropDownList ID="ddlTestSelectionClassResultsReport" runat="server" DataSourceID="sdsTestNameClassResultsReport" DataTextField="Test" DataValueField="TestID" Font-Size="11pt" AutoPostBack="true" EnableViewState="true" ViewStateMode="Enabled" />
                                                            </asp:TableCell>
                                                        </asp:TableRow>
                                                    </asp:Table>
                                                </asp:TableCell>
                                            </asp:TableRow>
                                        </asp:Table>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell>
                                        <asp:GridView ID="grvClassTestResultsReport" runat="server"
                                            AllowPaging="True"
                                            AllowSorting="True"
                                            AutoGenerateColumns="False"
                                            AutoGenerateDeleteButton="False"
                                            AutoGenerateEditButton="False"
                                            DataKeyNames="StudentTestID"
                                            DataSourceID="sdsClassTestResultsReport"
                                            PageSize="15"
                                            SkinID="gridViewSkin"
                                            ShowFooter="False">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Student Name" SortExpression="Student">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStudent" runat="server" Text='<%# Bind("Student")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Start Time" SortExpression="StartTime">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStartTime" runat="server" Text='<%# Bind("StartTime")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Finish Time" SortExpression="FinishTime">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFinishTime" runat="server" Text='<%# Bind("FinishTime")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Score" SortExpression="Score">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblScoreByClass" runat="server" Text='<%# Bind("Score")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Grade" SortExpression="Grade">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGrade" runat="server" Text='<%# Bind("Grade")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:SqlDataSource ID="sdsClassSelection" runat="server"
                                            ConnectionString="<%$ ConnectionStrings:MapQuizConnectionString %>"></asp:SqlDataSource>
                                        <asp:SqlDataSource ID="sdsClassTestResultsReport" runat="server"
                                            ConnectionString="<%$ ConnectionStrings:MapQuizConnectionString %>"></asp:SqlDataSource>
                                        <asp:SqlDataSource ID="sdsTestNameClassResultsReport" runat="server"
                                            ConnectionString="<%$ ConnectionStrings:MapQuizConnectionString %>"></asp:SqlDataSource>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="tabChangeInstructorPassword" runat="server"
            CssClass="MyTabStyle"
            HeaderText="Change Password">
            <ContentTemplate>
                <asp:Table runat="server" HorizontalAlign="Center">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Table runat="server" HorizontalAlign="Center" Width="100%" SkinID="White">
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell HorizontalAlign="Center">
                                        <asp:Label runat="server" Text="Change Password" Font-Size="30pt" SkinID="White" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell>
                                        <asp:Label ID="lblChangePasswordErrorMessage" runat="server" Visible="false" Font-Size="14pt" />
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                            <asp:Table runat="server" HorizontalAlign="Center" Width="100%" SkinID="White">
                                <asp:TableRow HorizontalAlign="Left">
                                    <asp:TableCell HorizontalAlign="Right">
                                        <asp:Label ID="lblCurrentPasswordText" runat="server" Text="Current Password: " Font-Size="Large"/>
                                    </asp:TableCell>
                                    <asp:TableCell HorizontalAlign="Left">
                                        <asp:Label ID="lblCurrentPassword" runat="server" Font-Size="Large"/>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow HorizontalAlign="Right">
                                    <asp:TableCell HorizontalAlign="Right">
                                        <asp:Label ID="lblNewPassword" runat="server" Text="New Password: " Font-Size="Large" />
                                    </asp:TableCell>
                                    <asp:TableCell HorizontalAlign="Left">
                                        <asp:TextBox ID="txtNewPassword" runat="server" Font-Size="Large" />
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow HorizontalAlign="Center">
                        <asp:TableCell HorizontalAlign="Center">
                            <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" Font-Size="Large" />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>

    <asp:SqlDataSource ID="sdsStudentName" runat="server"
        ConnectionString="<%$ ConnectionStrings:MapQuizConnectionString %>"
        SelectCommand="SELECT Student.StudentID, Student.FirstName + ' ' + Student.MiddleInitial + '. ' + Student.LastName AS Student FROM [Student]"></asp:SqlDataSource>

    <asp:SqlDataSource ID="sdsManageClassRosterStudentFullName" runat="server" ConnectionString="<%$ ConnectionStrings:MapQuizConnectionString %>"></asp:SqlDataSource>


    <asp:HiddenField ID="hiddenField" runat="server" />
    <!-- Manage Classes Delete Extender -->
    <ajaxToolkit:ModalPopupExtender ID="popupManageClassesDeleteMessage" runat="server" PopupControlID="panelManageClassesPopup" TargetControlID="hiddenField"
        BackgroundCssClass="modalBackground">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="panelManageClassesPopup" runat="server" CssClass="modalPopup" align="center" style = "display:none">
        <br />
        <asp:Label ID="lblManageClassesDeleteMessage" runat="server" EnableTheming="false" ForeColor="Black" Text="Are you certain you want to delete this class? Deleting this class will delete all associated tests and student test results." /> <br />
        <br />
        <asp:Button ID="btnManageClassesDelete" runat="server" Text="Delete" />
        <asp:Button ID="btnManageClassesCancel" runat="server" Text="Cancel" />
    </asp:Panel>

        <!-- Manage Students Delete Extender -->
    <ajaxToolkit:ModalPopupExtender ID="popupManageStudentsDeleteMessage" runat="server" PopupControlID="panelManageStudentsPopup" TargetControlID="hiddenField"
        BackgroundCssClass="modalBackground">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="panelManageStudentsPopup" runat="server" CssClass="modalPopup" align="center" style = "display:none">
        <br />
        <asp:Label ID="lblManageStudentsDeleteMessage" runat="server" EnableTheming="false" ForeColor="Black" Text="Are you certain you want to delete this student? Deleting this student will delete all student test results associated with this student." /> <br />
        <br />
        <asp:Button ID="btnManageStudentsDelete" runat="server" Text="Delete" />
        <asp:Button ID="btnManageStudentsCancel" runat="server" Text="Cancel" />
    </asp:Panel>

            <!-- Manage Tests Delete Extender -->
    <ajaxToolkit:ModalPopupExtender ID="popupManageTestsDeleteMessage" runat="server" PopupControlID="panelManageTestsPopup" TargetControlID="hiddenField"
        BackgroundCssClass="modalBackground">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="panelManageTestsPopup" runat="server" CssClass="modalPopup" align="center" style = "display:none">
        <br />
        <asp:Label ID="lblManageTestsDeleteMessage" runat="server" EnableTheming="false" ForeColor="Black" Text="Are you certain you want to delete this test? Deleting this test will delete all student test results associated with this test." /> <br />
        <br />
        <asp:Button ID="btnManageTestsDelete" runat="server" Text="Delete" />
        <asp:Button ID="btnManageTestsCancel" runat="server" Text="Cancel" />
    </asp:Panel>

                <!-- Manage Class Roster Delete Extender -->
    <ajaxToolkit:ModalPopupExtender ID="popupManageClassRosterDeleteMessage" runat="server" PopupControlID="panelManageClassRosterPopup" TargetControlID="hiddenField"
        BackgroundCssClass="modalBackground">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="panelManageClassRosterPopup" runat="server" CssClass="modalPopup" align="center" style = "display:none">
        <asp:Label ID="lblManageClassRosterDeleteMessage" runat="server" EnableTheming="false" ForeColor="Black" Text="Are you certain you want to delete this student from this class? Deleting this student from this class will delete all test results associated with this student in this class." /> <br />
        <br />
        <asp:Button ID="btnManageClassRosterDelete" runat="server" Text="Delete" />
        <asp:Button ID="btnManageClassRosterCancel" runat="server" Text="Cancel" />
    </asp:Panel>


    <script type="text/javascript">
        function doClick(buttonName, e) {
            //the purpose of this function is to allow the enter key to 
            //point to the correct button to click.
            var key;

            if (window.event)
                key = window.event.keyCode;     //IE
            else
                key = e.which;     //firefox

            if (key == 13) {
                //Get the button the user wants to have clicked
                var btn = document.getElementById(buttonName);
                btn.click();
                if (btn != null) { //If we find the button click it
                    btn.click();
                    event.keyCode = 0
                }
            }
        }
    </script>


</asp:Content>


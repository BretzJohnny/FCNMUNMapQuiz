<%@ Page Title="" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="AdministratorHomePage.aspx.vb" Inherits="AdministratorHomePage" %>
<%@ MasterType VirtualPath="~/Master.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


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


    <ajaxToolkit:ToolkitScriptManager runat="server" />
    <ajaxToolkit:TabContainer ID="container" runat="server" CssClass="MyTabStyle" UseVerticalStripPlacement="false">
                <ajaxToolkit:TabPanel ID="tabManageInstructors" runat="server"
            CssClass="MyTabStyle"
            HeaderText="Manage Instructors">
            <ContentTemplate>
                <asp:Table runat="server" HorizontalAlign="Center">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Table runat="server" Width="100%" SkinID="White">
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell>
                                        <asp:Label ID="lblInstructorPageTitle" runat="server" Text="Manage Instructors" Font-Size="30pt" SkinID="White" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell>
                                        <asp:Label ID="lblManageInstructorsErrorMessage" runat="server" Visible="false" Font-Size="14pt" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell>
                                        <asp:GridView ID="grvManageInstructors" runat="server"
                                            AllowPaging="True"
                                            AllowSorting="True"
                                            AutoGenerateColumns="False"
                                            AutoGenerateDeleteButton="False"
                                            AutoGenerateEditButton="False"
                                            DataKeyNames="InstructorID"
                                            DataSourceID="sdsManageInstructors"
                                            PageSize="20"
                                            SkinID="gridViewSkin"
                                            ShowFooter="True">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Instructor ID" SortExpression="InstructorID" Visible="false">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblOldInstructorIDEdit" runat="server" Text='<%# Eval("InstructorID")%>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblOldInstructorID" runat="server"></asp:Label>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOldInstructorID" runat="server" Text='<%# Bind("InstructorID")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Instructor ID" SortExpression="InstructorID">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtInstructorIDEdit" runat="server" Text='<%# Eval("InstructorID")%>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtInstructorID" runat="server"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblInstructorID" runat="server" Text='<%# Bind("InstructorID")%>'></asp:Label>
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
                                                            CommandName="Update" Text="Update" Width="50pt" CommandArgument='<%# grvManageInstructors.Rows.Count.ToString()%>' />
                                                        &nbsp;
                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="False"
                                                CommandName="Cancel" Text="Cancel" Width="50pt" />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Button ID="btnInsert" runat="server" CausesValidation="True"
                                                            CommandName="Insert" Text="Insert" Width="50pt" CommandArgument='<%# grvManageInstructors.Rows.Count.ToString()%>' />
                                                        &nbsp;
                                            <asp:Button ID="btnCancelInsert" runat="server" CausesValidation="False"
                                                CommandName="Cancel" Text="Cancel" Width="50pt" />
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnEdit" runat="server" CausesValidation="True"
                                                            CommandName="Edit" Text="Edit" Width="50pt" />
                                                        &nbsp;
                                            <asp:Button ID="btnDelete" runat="server" CausesValidation="False"
                                                CommandName="Delete" Text="Delete" Width="50pt" CommandArgument='<%# grvManageInstructors.Rows.Count.ToString()%>'/>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:SqlDataSource ID="sdsManageInstructors" runat="server"
                                            ConnectionString="<%$ ConnectionStrings:MapQuizConnectionString %>"
                                            SelectCommand="SELECT TOP 1 * FROM Instructor"
                                            UpdateCommand="SELECT TOP 1 * FROM Instructor"
                                            DeleteCommand="SELECT TOP 1 * FROM Instructor"
                                            InsertCommand="SELECT TOP 1 * FROM Instructor"></asp:SqlDataSource>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="tabManageAdministrators" runat="server"
            CssClass="MyTabStyle"
            HeaderText="Manage Administrators">
            <ContentTemplate>
                <asp:Table runat="server" HorizontalAlign="Center">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Table runat="server" Width="100%" SkinID="White">
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell>
                                        <asp:Label ID="lblAdministratorPageTitle" runat="server" Text="Manage Administrators" Font-Size="30pt" SkinID="White" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell>
                                        <asp:Label ID="lblManageAdministratorsErrorMessage" runat="server" Visible="false" Font-Size="14pt" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell>
                                        <asp:GridView ID="grvManageAdministrators" runat="server"
                                            AllowPaging="True"
                                            AllowSorting="True"
                                            AutoGenerateColumns="False"
                                            AutoGenerateDeleteButton="False"
                                            AutoGenerateEditButton="False"
                                            DataKeyNames="AdministratorID"
                                            DataSourceID="sdsManageAdministrators"
                                            PageSize="20"
                                            SkinID="gridViewSkin"
                                            ShowFooter="True">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Administrator ID" SortExpression="AdministratorID" Visible="false">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblOldAdministratorIDEdit" runat="server" Text='<%# Eval("AdministratorID")%>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblOldAdministratorID" runat="server"></asp:Label>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOldAdministratorID" runat="server" Text='<%# Bind("AdministratorID")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Administrator ID" SortExpression="AdministratorID">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtAdministratorIDEdit" runat="server" Text='<%# Eval("AdministratorID")%>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtAdministratorID" runat="server"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAdministratorID" runat="server" Text='<%# Bind("AdministratorID")%>'></asp:Label>
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
                                                        <asp:TextBox ID="txtMiddleInitialEdit" runat="server" Text='<%# Bind("MiddleInitial")%>' Width="20"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtMiddleInitial" runat="server" Width="20"></asp:TextBox>
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
                                                <asp:TemplateField HeaderText="Email" SortExpression="Franklin Email">
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
                                                            CommandName="Update" Text="Update" Width="50pt" CommandArgument='<%# grvManageAdministrators.Rows.Count.ToString()%>' />
                                                        &nbsp;
                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="False"
                                                CommandName="Cancel" Text="Cancel" Width="50pt" />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Button ID="btnInsert" runat="server" CausesValidation="True"
                                                            CommandName="Insert" Text="Insert" Width="50pt" CommandArgument='<%# grvManageAdministrators.Rows.Count.ToString()%>' />
                                                        &nbsp;
                                            <asp:Button ID="btnCancelInsert" runat="server" CausesValidation="False"
                                                CommandName="Cancel" Text="Cancel" Width="50pt" />
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnEdit" runat="server" CausesValidation="True"
                                                            CommandName="Edit" Text="Edit" Width="50pt" />
                                                        &nbsp;
                                            <asp:Button ID="btnDelete" runat="server" CausesValidation="False"
                                                CommandName="Delete" Text="Delete" Width="50pt" CommandArgument='<%# grvManageAdministrators.Rows.Count.ToString()%>'/>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:SqlDataSource ID="sdsManageAdministrators" runat="server"
                                            ConnectionString="<%$ ConnectionStrings:MapQuizConnectionString %>"
                                            SelectCommand="SELECT TOP 1 * FROM Administrator"
                                            UpdateCommand="SELECT TOP 1 * FROM Administrator"
                                            DeleteCommand="SELECT TOP 1 * FROM Administrator"
                                            InsertCommand="SELECT TOP 1 * FROM Administrator"></asp:SqlDataSource>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="tabChangeAdministratorPassword" runat="server"
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

    <asp:HiddenField ID="hiddenField" runat="server" />
    <!-- Manage Instructors Delete Extender -->
    <ajaxToolkit:ModalPopupExtender ID="popupManageInstructorsDeleteMessage" runat="server" PopupControlID="panelManageInstructorsPopup" TargetControlID="hiddenField"
        BackgroundCssClass="modalBackground">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="panelManageInstructorsPopup" runat="server" CssClass="modalPopup" align="center" style = "display:none">
        <asp:Label ID="lblManageInstructorsDeleteMessage" runat="server" EnableTheming="false" ForeColor="Black" Text="Are you certain you want to delete this Instructor? Deleting this Instructor will delete all Instructor tests and test results associated with this Instructor." /> <br />
        <br />
        <asp:Button ID="btnManageInstructorsDelete" runat="server" Text="Delete" />
        <asp:Button ID="btnManageInstructorsCancel" runat="server" Text="Cancel" />
    </asp:Panel>

        <!-- Manage Administrators Delete Extender -->
    <ajaxToolkit:ModalPopupExtender ID="popupManageAdministratorsDeleteMessage" runat="server" PopupControlID="panelManageAdministratorsPopup" TargetControlID="hiddenField"
        BackgroundCssClass="modalBackground">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="panelManageAdministratorsPopup" runat="server" CssClass="modalPopup" align="center" style = "display:none">
        <asp:Label ID="lblManageAdministratorsDeleteMessage" runat="server" EnableTheming="false" ForeColor="Black" Text="Are you certain you want to delete this Administrator?" /> <br />
        <br />
        <asp:Button ID="btnManageAdministratorsDelete" runat="server" Text="Delete" />
        <asp:Button ID="btnManageAdministratorsCancel" runat="server" Text="Cancel" />
    </asp:Panel>

</asp:Content>


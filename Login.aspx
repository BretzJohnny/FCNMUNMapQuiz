<%@ Page Title="" Language="VB" MasterPageFile="~/NoHeaderMaster.master" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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
    <asp:SqlDataSource ID="sdsInstructorID" runat="server"
        ConnectionString="<%$ ConnectionStrings:MapQuizConnectionString %>"
        />

    <br />

    <asp:Table ID="Table1" runat="server" Width="100%" HorizontalAlign="Center" >
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center">
                <asp:Image id="image1" runat="server" ImageUrl="~/Images/FC_MUN_Logo_No_Text.gif" Width="450" Height="358"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center">
                <asp:label ID="lblTitle" runat="server" Text="FC MUN Map Quiz" Font-Size="25pt" Font-Bold="true" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell></asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center">
                <asp:Table ID="LoginTable" runat="server" >
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:RadioButton runat="server" ID="radAdministrator" Text="Administrator" GroupName="LoginGroup" />
                        </asp:TableCell>
                        <asp:TableCell HorizontalAlign="Center">
                            <asp:RadioButton runat="server" ID="radInstructor" Text="Instructor" GroupName="LoginGroup" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:RadioButton runat="server" ID="radStudent" Text="Student" GroupName="LoginGroup"  />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label runat="server" Text="Username:" Font-Size="Large" Font-Bold="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtUsername" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label runat="server" Text="Password:" Font-Size="Large" Font-Bold="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtPassword" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell></asp:TableCell></asp:TableRow>
        <asp:TableRow HorizontalAlign="Center">
            <asp:TableCell>
                <asp:Button ID="btnLogin" runat="server" Text="Login" Width="190pt" Height="30pt"/> 
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <!-- ModalPopupExtender -->
    <asp:HiddenField ID="hiddenField" runat="server" />
    <ajaxToolkit:ModalPopupExtender ID="popupLoginError" runat="server" PopupControlID="Panel1" TargetControlID="hiddenField"
        BackgroundCssClass="modalBackground">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center" style = "display:none">
        <br />
        <br />
        <asp:Label ID="lblLoginErrorMessage" runat="server" EnableTheming="false" ForeColor="Black" /> <br />
        <br />
        <asp:Button ID="btnOkay" runat="server" Text="Okay" />
    </asp:Panel>
    <!-- ModalPopupExtender -->

</asp:Content>
<%@ Page Title="" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="StudentTesting.aspx.vb" Inherits="StudentTesting" %>

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
            font-size: 0pt;
            font-weight: bold;
            display: block;
        }

            .MyTabStyle .ajax__tab_header .ajax__tab_outer {
                padding-left: 0px;
                margin-right: 0px;
                background-size: auto;
                border-spacing: 0px;
                background-image: url(../../Images/OldPaperNoEdge.gif);
                border-width: 0px;
                border-image: url(../../Images/OldPaper.gif) 85 58 stretch;
            }

            .MyTabStyle .ajax__tab_header .ajax__tab_inner {
                padding: 0px 0px 0px 0px;
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
            <ajaxToolkit:TabPanel ID="tabStudents" runat="server"
                CssClass="MyTabStyle"
                HeaderText="Testing">
                <ContentTemplate>
                    <asp:Table runat="server" HorizontalAlign="Center">
                        <asp:TableRow HorizontalAlign="Center">
                            <asp:TableCell>
                                <asp:Label ID="lblTestTitle" runat="Server" Text="Testing" Font-Size="30pt" Font-Style="Bold" SkinID="White" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow HorizontalAlign="Center">
                            <asp:TableCell>
                                <asp:Table runat="server" HorizontalAlign="Center">
                                    <asp:TableRow HorizontalAlign="Center">
                                        <asp:TableCell HorizontalAlign="Right">
                                            <asp:Image ID="imgRegion" runat="server" ImageUrl="~/Maps/Africa.gif" />
                                        </asp:TableCell>
                                        <asp:TableCell VerticalAlign="Top">
                                            <asp:Table runat="server" HorizontalAlign="Left">
                                                <asp:TableRow HorizontalAlign="Left">
                                                    <asp:TableCell>
                                                        <asp:Table runat="server" HorizontalAlign="Left">
                                                            <asp:TableRow>
                                                                <asp:TableCell>
                                                                    <asp:Label runat="server" Text="State: " Font-Size="15pt" Font-Style="Bold" SkinID="White" />
                                                                </asp:TableCell>
                                                                <asp:TableCell HorizontalAlign="Left">
                                                                    <asp:Label ID="lblState" runat="server" Text="Egypt" Font-Size="15pt" SkinID="White" />
                                                                </asp:TableCell>
                                                            </asp:TableRow>
                                                            <asp:TableRow>
                                                                <asp:TableCell>
                                                            <asp:Label runat="server" Text="Answer: " Font-Size="15pt" Font-Style="Bold" SkinID="White" />
                                                                </asp:TableCell>
                                                                <asp:TableCell HorizontalAlign="Left">
                                                                    <asp:TextBox ID="txtAnswer" runat="server" Width="30pt" SkinID="White" MaxLength="2" TabIndex="1"/>
                                                                </asp:TableCell>
                                                            </asp:TableRow>
                                                            <asp:TableRow>
                                                                <asp:TableCell HorizontalAlign="Left">
                                                                    <asp:Button ID="btnNext" runat="server" Text="Next" SkinID="White" TabIndex="2" />
                                                                        <!-- ModalPopupExtender -->
                                                                        <asp:HiddenField ID="hiddenField" runat="server" />
                                                                        <ajaxToolkit:ModalPopupExtender ID="popupPracticeTest" runat="server" PopupControlID="Panel1" TargetControlID="hiddenField"
                                                                            BackgroundCssClass="modalBackground">
                                                                        </ajaxToolkit:ModalPopupExtender>
                                                                        <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center" style = "display:none">
                                                                            <br />
                                                                            <br />
                                                                            <asp:Label ID="lblStudentAnswer" runat="server" EnableTheming="false" ForeColor="Black" /> <br />
                                                                            <asp:Label ID="lblCorrectAnswer" runat="server" EnableTheming="false" ForeColor="Black" /> <br />
                                                                            <br />
                                                                            <asp:Button ID="btnContinue" runat="server" Text="Continue" />
                                                                            <asp:Button ID="btnTryAgain" runat="server" Text="Try Again" />
                                                                        </asp:Panel>
                                                                        <!-- ModalPopupExtender -->
                                                                </asp:TableCell>
                                                            </asp:TableRow>
                                                            <asp:TableRow>
                                                                <asp:TableCell>

                                                                </asp:TableCell>
                                                            </asp:TableRow>
                                                        </asp:Table>
                                                    </asp:TableCell>
                                                </asp:TableRow>

                                            </asp:Table>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>

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


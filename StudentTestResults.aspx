<%@ Page Title="" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="StudentTestResults.aspx.vb" Inherits="StudentTestResults" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <style type="text/css">
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
        <ajaxToolkit:TabPanel ID="tabInstructors" runat="server"
            CssClass="MyTabStyle">
            <ContentTemplate>
                <asp:Table runat="server" HorizontalAlign="Center">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Table runat="server" Width="100%" SkinID="White">
                                <asp:TableRow HorizontalAlign="Center">
                                    <asp:TableCell>
                                        <asp:Label ID="lblTestTitleResults" runat="server" Text="Test Results" Font-Size="30pt" SkinID="White" />
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                            <asp:Table runat="server" Width="100%" SkinID="White">
                                <asp:TableRow>
                                    <asp:TableCell HorizontalAlign="Right">
                                        <asp:Label runat="server" Text="Started: " Font-Size="17pt" SkinID="White" />
                                    </asp:TableCell>
                                    <asp:TableCell HorizontalAlign="Left">
                                        <asp:Label ID="lblTestStartTime" runat="server" Text="Test Start Time" Font-Size="17pt" SkinID="White" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell HorizontalAlign="Right">
                                        <asp:Label runat="server" Text="Completed: " Font-Size="17pt" SkinID="White" />
                                    </asp:TableCell>
                                    <asp:TableCell HorizontalAlign="Left">
                                        <asp:Label ID="lblTestFinishTime" runat="server" Text="Test Start Time" Font-Size="17pt" SkinID="White" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell HorizontalAlign="Right">
                                        <asp:Label runat="server" Text="Score: " Font-Size="17pt" SkinID="White" />
                                    </asp:TableCell>
                                    <asp:TableCell HorizontalAlign="Left">
                                        <asp:Label ID="lblTestResults" runat="server" Text="Test Results" Font-Size ="17pt" SkinID="White" />
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                            <asp:Table runat="server" Width="100%" HorizontalAlign="Center">
                                <asp:TableRow>
                                    <asp:TableCell HorizontalAlign="Center">
                                        <asp:Button ID="btnContinue" runat="server" Text="Continue" Width="75%" Height="30pt"/>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>


</asp:Content>




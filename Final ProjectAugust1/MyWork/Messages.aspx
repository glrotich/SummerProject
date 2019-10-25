<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="Final_ProjectAugust1.MyWork.Messages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style3 {
        font-size: x-large;
        color: #CCCC00;
    }
    .auto-style5 {
            font-size: large;
            color: #009900;
            width: 153px;
        }
    .auto-style6 {
        height: 23px;
    }
    .auto-style7 {
        color: #009900;
        font-size: x-large;
    }
        .auto-style8 {
            font-size: large;
            color: #FF0066;
        }
        .auto-style9 {
            height: 23px;
            width: 153px;
        }
        .auto-style10 {
            width: 153px;
        }
        .auto-style11 {
            font-size: large;
            color: #009900;
        }
        .auto-style12 {
            font-size: large;
            color: #FF0000;
        }
        .auto-style13 {
            width: 153px;
            height: 33px;
        }
        .auto-style15 {
            height: 33px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p style="margin-left: 40px">
        <span class="auto-style7">Messages</span><br />
    </p>
    <p>
        <table style="width:100%;">
            <tr>
                <td class="auto-style9">
                    <asp:Label ID="Label1" runat="server" CssClass="auto-style8" Text="Label"></asp:Label>
&nbsp;&nbsp; is logged in</td>
                <td class="auto-style6"></td>
                <td class="auto-style6"></td>
            </tr>
            <tr>
                <td class="auto-style10"></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">Inbox:</td>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True">
                    </asp:GridView>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style10">&nbsp;</td>
                <td>
        <asp:Button ID="btnSelectDeleteM" runat="server" Text="Select &amp; Delete from Inbox" Width="280px" OnClick="btnSelectDeleteM_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style13"></td>
                <td class="auto-style15">
                    <asp:Label ID="Label2" runat="server" CssClass="auto-style12"></asp:Label>
                </td>
                <td class="auto-style15"></td>
            </tr>
            <tr>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style11">Send a message</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">Email&nbsp;To:</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">Message:</td>
                <td>
                    <asp:TextBox ID="txtMessage" runat="server" Height="108px" TextMode="MultiLine" Width="221px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style10">&nbsp;</td>
                <td>
                    <asp:Button ID="btnSubmitM" runat="server" OnClick="btnSubmitM_Click" Text="Send" Width="81px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnClearM" runat="server" Text="Clear" Width="60px" OnClick="btnClearM_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style10">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">Sent Box:</td>
                <td>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateSelectButton="True">
                    </asp:GridView>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>
                    <asp:Button ID="btnSelectDeleteS" runat="server" OnClick="btnSelectDeleteS_Click" Text="Select &amp; Delete from Sentbox" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>
                    <asp:Label ID="Label3" runat="server" CssClass="auto-style12"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </p>
    <p>
    </p>
    </asp:Content>

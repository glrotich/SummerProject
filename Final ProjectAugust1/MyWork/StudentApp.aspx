<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="StudentApp.aspx.cs" Inherits="Final_ProjectAugust1.MyWork.StudentApp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        height: 23px;
    }
    .auto-style2 {
        height: 26px;
    }
    .auto-style3 {
        height: 23px;
        font-size: large;
        color: #009900;
    }
    .auto-style5 {
        height: 26px;
        color: #009900;
        font-size: large;
            width: 205px;
        }
    .auto-style6 {
        font-size: large;
        color: #009900;
    }
    .auto-style7 {
        color: #009900;
    }
        .auto-style8 {
            height: 23px;
            font-size: large;
            color: #009900;
            width: 205px;
        }
        .auto-style9 {
            font-size: large;
            color: #009900;
            width: 205px;
        }
        .auto-style10 {
            width: 205px;
        }
        .auto-style11 {
            font-size: x-large;
        }
        .auto-style12 {
            font-size: large;
            color: #FF0066;
        }
        .auto-style13 {
            width: 100%;
        }
        .auto-style14 {
            font-size: large;
            color: #FF0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:Label ID="Label1" runat="server" Text="Please make an appointment" style="color: #009900" CssClass="auto-style11"></asp:Label>
        <br />
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" CssClass="auto-style12" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp; is logged in</p>
<asp:GridView ID="GridView4" runat="server" AutoGenerateSelectButton="True">
</asp:GridView>
<p>
        <asp:Button ID="btnSelectDelete" runat="server" OnClick="btnSelectDelete_Click" Text="Select &amp; Delete" Width="169px" />
    </p>
    <p>
        <table class="auto-style13">
            <tr>
                <td class="auto-style8">
        <asp:Label ID="Label4" runat="server" CssClass="auto-style14"></asp:Label>
                </td>
                <td class="auto-style1">
                    &nbsp;</td>
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td class="auto-style5">Appointment Time:</td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="DropDownList3" runat="server" Height="16px" Width="69px">
                        <asp:ListItem>00</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>45</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td class="auto-style10">&nbsp;</td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style10"><span class="auto-style7">A</span><span class="auto-style6">ppointment Date:</span></td>
                <td>
                    <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged1"></asp:Calendar>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">Appointment Reason:</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style10">&nbsp;</td>
                <td>
                    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Add Appt" style="height: 26px" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </p>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<p style="margin-left: 40px">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;
        </p>
    <p style="margin-left: 40px">
        &nbsp;</p>
    </asp:Content>

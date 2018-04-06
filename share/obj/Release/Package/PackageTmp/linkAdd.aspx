<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/MaterPage.master" AutoEventWireup="true" CodeBehind="linkAdd.aspx.cs" Inherits="share.linkAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphLeft" runat="server">
    <div style="padding-top: 100px; height: 500px">
        <table>
            <tr class="mt70" style="text-align: right">
                <td colspan="2">
                    <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/App_Themes/Image/GIF/add.gif" OnClick="btnAdd_Click" />
                </td>
            </tr>
            <tr class="mt45">
                <td class="w100">
                    <asp:Label ID="Label1" runat="server" Text="友情链接名"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="450px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtName" runat="server" ErrorMessage="名字不可为空" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="mt45">
                <td class="w100">
                    <asp:Label ID="Label2" runat="server" Text="友情链Url"></asp:Label></td>
                <td class="w400">
                    <asp:TextBox ID="txtUrl" runat="server" Width="450px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtUrl" runat="server" ForeColor="Red" ErrorMessage="地址不可为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="mt45">
                <td class="w100">
                    <asp:Label ID="Label3" runat="server" Text="友情链接说明"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtRemark" runat="server" Width="450px"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CphContent" runat="server">
</asp:Content>

<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication3._Default" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script src="Scripts/jquery-3.3.1.js"></script>
    <script>

        $(document).ready(function () {

            $('#btnAdd').click(function () {

                var fName = $('#txtFirstName1').val();
                var lName = $('#txtLastName1').val();
                var Phone = $('#txtPhoneNumber1').val();
                var Status = $('#txtStatus1').val();

                if (fName == '') {

                    $('#txtFirstName1').css('border-color', 'red');
                    return false;
                }
                else {
                    $('#txtFirstName1').css('border-color', '');
                }

                if (lName == '') {
                    $('#txtLastName1').css('border-color', 'red');
                    return false;
                }
                else {
                    $('#txtLastName1').css('border-color', '');
                }

                if (Phone == '') {
                    $('#txtPhoneNumber1').css('border-color', 'red');
                    return false;
                }
                else {
                    $('#txtPhoneNumber1').css('border-color', '');
                }

                if (Status == '') {
                    $('#txtStatus1').css('border-color', 'red');
                    return false;
                }
                else {
                    $('#txtStatus1').css('border-color', '');
                }
            });

            $('.GroupText').change(function (e) {
                var txtVal = $(this).val();
                var id = $(this).attr('id');

                if (txtVal != '') {
                    $('#' + id).css('border-color', '');
                }
            });

            $('#txtPhoneNumber1').keypress(function (e) {
                return AllowNumeric(e);
            });
            $('#txtPhoneNumber').keypress(function (e) {
                return AllowNumeric(e);
            });

        });

        function AllowNumeric(e) {
            if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                return false;
            }
            else
                return true;
        }

    </script>

    <asp:GridView Style="margin-top: 20px" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit"
        OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added." EnableModelValidation="False" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="FirstName" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="lblFirstNameName" runat="server" Text='<%# Eval("FirstName") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtFirstName" runat="server" Text='<%# Eval("FirstName") %>'></asp:TextBox>
                </EditItemTemplate>

                <ItemStyle Width="150px"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="LastName" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="lblLastName" runat="server" Text='<%# Eval("LastName") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtLastName" runat="server" Text='<%# Eval("LastName") %>'></asp:TextBox>
                </EditItemTemplate>

                <ItemStyle Width="150px"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PhoneNumber" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="lblPhoneNumber" runat="server" Text='<%# Eval("PhoneNumber") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtPhoneNumber" ClientIDMode="Static" runat="server" Text='<%# Eval("PhoneNumber") %>'></asp:TextBox>
                </EditItemTemplate>

                <ItemStyle Width="150px"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtStatus" runat="server" Text='<%# Eval("Status") %>'></asp:TextBox>
                </EditItemTemplate>

                <ItemStyle Width="150px"></ItemStyle>
            </asp:TemplateField>
            <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" ItemStyle-Width="150">
                <ItemStyle Width="150px"></ItemStyle>
            </asp:CommandField>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
        <tr>
            <td style="width: 150px">FirstName:<br />
                <asp:TextBox ID="txtFirstName1" CssClass="GroupText" ClientIDMode="Static" runat="server" Width="140" />

            </td>
            <td style="width: 150px">LastName:<br />
                <asp:TextBox ID="txtLastName1" CssClass="GroupText" ClientIDMode="Static" runat="server" Width="140" />

            </td>
            <td style="width: 150px">PhoneNumber:<br />
                <asp:TextBox ID="txtPhoneNumber1" CssClass="GroupText" ClientIDMode="Static" runat="server" Width="140" />

            </td>
            <td style="width: 150px">Status:<br />
                <asp:TextBox ID="txtStatus1" CssClass="GroupText" ClientIDMode="Static" runat="server" Width="140" />

            </td>
            <td style="width: 100px">
                <asp:Button ID="btnAdd" runat="server" ClientIDMode="Static" Text="Add" OnClick="Insert" OnClientClick="BlankDataValidation()" />
            </td>
        </tr>
    </table>

</asp:Content>

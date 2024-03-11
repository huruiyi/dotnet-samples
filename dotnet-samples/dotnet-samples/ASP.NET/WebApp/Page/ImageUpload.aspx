<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageUpload.aspx.cs" Inherits="WebApp.Page.ImageUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Personal Information</title>
    <style type="text/css">
        form {
            margin: 0 auto;
            width: 100%;
        }
        form div.main {
            margin: 0 auto;
            text-align: center
        }
        tr.trHead td {
            text-align: center
        }

        table ,table tr,table td {
            margin: 0 auto;
            border-collapse: collapse;
            border: 1px solid #0078d7;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <h2>OverView of Persons</h2>
            <asp:SqlDataSource ID="SqlDSPersonOverView" runat="server"
                ConnectionString="<%$ ConnectionStrings:db_PersonsConnectionString %>"
                SelectCommand="SELECT [Id], [PersonName] FROM [PersonInfo]"></asp:SqlDataSource>
            <asp:GridView
                ID="gvPersonOverView"
                runat="server"
                Width="70%"
                AutoGenerateColumns="False"
                DataKeyNames="Id"
                DataSourceID="SqlDSPersonOverView"
                OnSelectedIndexChanged="gvPersonOverView_SelectedIndexChanged"
                AllowPaging="True"
                AllowSorting="True">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="PersonName" HeaderText="PersonName" SortExpression="PersonName" />
                    <asp:CommandField ShowSelectButton="True" HeaderText="Click to see Details" SelectText="Details..." />
                </Columns>
                <EmptyDataTemplate>
                    No Data Available, Please Insert data with the help of the FormView...<br />
                </EmptyDataTemplate>
                <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:GridView>
        </div>
        <asp:FormView ID="fvPersonDetails" runat="server" Width="50%"
            DataSourceID="SqlDSPersonDetails"
            DataKeyNames="Id" DataMember="DefaultView"
            OnItemInserting="fvPersonDetails_ItemInserting"
            OnItemUpdating="fvPersonDetails_ItemUpdating"
            OnItemUpdated="fvPersonDetails_ItemUpdated"
            OnItemDeleted="fvPersonDetails_ItemDeleted"
            OnItemDeleting="fvPersonDetails_ItemDeleting"
            OnItemInserted="fvPersonDetails_ItemInserted"
            OnModeChanging="fvPersonDetails_ModeChanging">
            <ItemTemplate>
                <table width="100%">
                    <tr>
                        <th>Person Name:
                        </th>
                        <td colspan="2">
                            <%#Eval("PersonName") %>
                        </td>
                    </tr>
                    <tr>
                        <th>Person Image:
                        </th>
                        <td colspan="2">
                            <img src='/Handler/ImageHandler.ashx?id=<%#Eval("Id") %>' width="200" alt="" height="200" />
                        </td>
                    </tr>
                    <tr class="trHead">
                        <td>
                            <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" Text="Edit" />
                        </td>
                        <td>
                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure to delete it completely?');" />
                        </td>
                        <td>
                            <asp:LinkButton ID="lnkNew" runat="server" CommandName="New" Text="New" />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <EditItemTemplate>
                <table width="100%">
                    <tr>
                        <th>
                            Person Name:
                        </th>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" Text=' <%#Bind("PersonName") %>' MaxLength="20" />
                            <asp:RequiredFieldValidator ID="reqName" runat="server" ControlToValidate="txtName" ErrorMessage="Name is required!">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Person Image:
                        </th>
                        <td>
                            <asp:FileUpload ID="fupEditImage" runat="server" />
                            <asp:CustomValidator ID="cmvImageType" runat="server" ControlToValidate="fupEditImage" ErrorMessage="File is invalid!" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr class="trHead">
                        <td>
                            <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update" Text="Update" />
                        </td>
                        <td>
                            <asp:LinkButton ID="lnkCancel" runat="server" CommandName="Cancel" Text="Cancel" CausesValidation="False" />
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
            <InsertItemTemplate>
                <table width="100%">
                    <tr>
                        <th>Person Name:
                        </th>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" MaxLength="20" Text='<%#Bind("PersonName") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="Name is required!">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Person Image:
                        </th>
                        <td>
                            <asp:FileUpload ID="fupInsertImage" runat="server" />
                            <asp:CustomValidator ID="cmvImageType" runat="server" ControlToValidate="fupInsertImage" ErrorMessage="File is invalid!" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr class="trHead">
                        <td  >
                            <asp:LinkButton ID="lnkInsert" runat="server" CommandName="Insert" Text="Insert" />
                        </td>
                        <td >
                            <asp:LinkButton ID="lnkInsertCancel" runat="server" CommandName="Cancel" Text="Cancel" CausesValidation="False" />
                        </td>
                    </tr>
                </table>
            </InsertItemTemplate>
        </asp:FormView>
        <asp:SqlDataSource ID="SqlDSPersonDetails" runat="server"
            ConnectionString="<%$ ConnectionStrings:db_PersonsConnectionString %>"
            DeleteCommand="DELETE FROM PersonInfo WHERE (Id = @Id)"
            InsertCommand="INSERT INTO PersonInfo(PersonName, PersonImage, PersonImageType) VALUES (@PersonName, @PersonImage, @PersonImageType)"
            SelectCommand="SELECT [Id], [PersonName] FROM [PersonInfo] where id=@id"
            UpdateCommand="UPDATE PersonInfo SET PersonName = @PersonName, PersonImage = @PersonImage, PersonImageType = @PersonImageType WHERE (Id = @Id)">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="PersonName" Type="String" />
                <asp:Parameter Name="PersonImage" DbType="Binary" ConvertEmptyStringToNull="true" />
                <asp:Parameter Name="PersonImageType" Type="String" ConvertEmptyStringToNull="true" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="PersonName" Type="String" />
                <asp:Parameter Name="PersonImage" DbType="Binary" ConvertEmptyStringToNull="true" />
                <asp:Parameter Name="PersonImageType" Type="String" ConvertEmptyStringToNull="true" />
                <asp:Parameter Name="Id" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter Name="id" Type="Int32" ControlID="gvPersonOverView" PropertyName="SelectedValue" DefaultValue="0" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>

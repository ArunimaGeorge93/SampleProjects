<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExcelReader.aspx.cs" Inherits="ExamplesUsage.ExcelReader" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="table">
            <label>select Excel file :</label> <asp:FileUpload ID="fileSelect" runat="server" /> 
            <label>select bat file   :</label> <asp:FileUpload ID="FileUploader" runat="server" />
            <asp:Button ID="btnRead" runat="server" Text="ReadStart" OnClick="btnRead_Click" /> 
        </div>
       
        <div>
            
            <asp:TextBox ID="txtReader" runat="server" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div>
            <asp:GridView ID="Gvsplit" runat="server" ShowFooter="true" AutoGenerateColumns="true" BackColor="#99CCFF"></asp:GridView>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileReaderEx.aspx.cs" Inherits="ExamplesUsage.FileReaderEx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="fileSelect" runat="server" /> 
            <asp:Button ID="btnRead" runat="server" Text="ReadStart" OnClick="btnRead_Click" /> 
        </div>
        <div>
            <asp:FileUpload ID="FileUploader" runat="server" />
            <asp:Button ID="btnUploader" Text="Upload" OnClick="btnUploader_Click" runat="server" />
            <asp:Label ID="UploadStatusLabel" runat="server"></asp:Label>
        </div>
        <div>
            
            <asp:TextBox ID="txtReader" runat="server" TextMode="MultiLine"></asp:TextBox>
        </div>
    </form>
</body>
</html>

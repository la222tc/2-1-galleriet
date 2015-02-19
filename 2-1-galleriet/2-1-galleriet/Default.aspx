<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_2_1_galleriet.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Galleriet</h1>

        <asp:Panel ID="SuccessPanel" runat="server" Visible="false">
            <asp:Literal ID="SuccessLiteral" runat="server"></asp:Literal>
        </asp:Panel>

        <asp:Image ID="FullImage" runat="server" />
        <div id="thumbnails">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server">
                        <asp:Image ID="ThumbImage" runat="server" />
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    </form>
</body>
</html>

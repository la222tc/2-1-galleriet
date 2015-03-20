<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_2_1_galleriet.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Css/Style.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form1" runat="server">
    <div id="gallery">
        <h1>Galleriet</h1>
        <div id="gallerybox">
     <asp:PlaceHolder ID="SuccessPlaceHolder" runat="server" Visible="true">
         <div id="BorderSuccesBox">
             <div id="SuccesBox">
                 <asp:Label ID="SuccessLabel" runat="server" ></asp:Label>
                 <a href="#" id="Esc">X</a>     
             </div>
         </div>
        </asp:PlaceHolder> 

        <asp:PlaceHolder ID="ImagePlaceHolder" runat="server" Visible="false">
        <asp:Image ID="FullImage" runat="server" />
        </asp:PlaceHolder>

        <div id="thumbnails">
            <div id="nails">
                <asp:Repeater ID="Repeater1" runat="server"
                    ItemType="_2_1_galleriet.Model.Images"
                    SelectMethod="Repeater1_GetData">
                    <HeaderTemplate>
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <asp:HyperLink ID="ThumbImageHyperLink" runat="server"
                                NavigateUrl='<%# Item.FullImgUrl %>'  ImageUrl='<%# Item.ThumbImgUrl %>'>
                            </asp:HyperLink>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
            <fieldset>
                <legend>Ladda upp en bild</legend>
                <asp:ValidationSummary ID="PicValidationSummary" runat="server" HeaderText="Fel inträffade. Åtgärda felen och försök igen." />
                <asp:FileUpload ID="PicFileUpload" runat="server" />
                <asp:RequiredFieldValidator ID="PicRequiredFieldValidator" runat="server" ErrorMessage="Välj en bild" Display="Dynamic" ControlToValidate="PicFileUpload"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="PicRegularExpressionValidator" runat="server" ErrorMessage="Bildformatet måste vara gif, jpg eller png!" Display="Dynamic" ControlToValidate="PicFileUpload" ValidationExpression="^.*.(gif|jpg|png)$"></asp:RegularExpressionValidator>
                <asp:Button ID="UploadButton" runat="server" Text="Button" OnClick="UploadButton_Click" />
            </fieldset>

        </div>
    </div>
        <script src="Script/script.js" type="text/javascript"></script>
    </form>
</body>
</html>

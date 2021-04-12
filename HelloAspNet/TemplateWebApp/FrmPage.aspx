<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmPage.aspx.cs" Inherits="TemplateWebApp.FrmPage" %>

<%@ Register Src="~/Navigator.ascx" TagPrefix="nav" TagName="Navigator" %>
<%@ Register Src="~/Category.ascx" TagPrefix="ctl" TagName="Category" %>
<%@ Register Src="~/Catalog.ascx" TagPrefix="cat" TagName="Catalog" %>
<%@ Register Src="~/Copyright.ascx" TagPrefix="cpy" TagName="Copyright" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>웹사이트 뼈대</title>
    <link rel="stylesheet" type="text/css" href="Content/bootstrap.css" />
    <style>
        div {

        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-12" style="background-color: aquamarine">
                    <nav:Navigator runat="server" ID="NavMain" />
                </div>
            </div>
            <div class="row" style="height: 200px;">
                <div class="col-md-4" style="background-color: antiquewhite">
                    <ctl:Category runat="server" />
                </div>
                <div class="col-md-8" style="background-color: cadetblue">
                    <cat:Catalog runat="server" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-12" style="background-color: cornflowerblue">
                    <cpy:Copyright runat="server" ID="UcCopyright" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>

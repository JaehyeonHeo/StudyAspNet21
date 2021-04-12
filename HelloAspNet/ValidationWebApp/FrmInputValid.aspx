<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmInputValid.aspx.cs" Inherits="ValidationWebApp.FrmInputValid" %>

<%@ Register Src="~/Copyright.ascx" TagPrefix="uc1" TagName="Copyright" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>유효성 검사</title>
</head>
<body>
    <form id="form1" runat="server" method="post">
        <div>
            <asp:TextBox ID="TxtAge" runat="server" />
            <asp:RangeValidator ID="ValAge" runat="server" ControlToValidate="TxtAge"
                ErrorMessage="나이는 1~150사이의 정수입니다." MinimumValue="1" MaximumValue="150" Type="Integer"
                Display="Dynamic" SetFocusOnError="true" />
            <br />
            <asp:TextBox ID="TxtScore" runat="server" />
            <asp:RangeValidator ID="ValScore" runat="server" ControlToValidate="TxtScore"
                ErrorMessage="학점은 A~F입니다." MinimumValue="A" MaximumValue="F" Type="String"
                Display="Dynamic" SetFocusOnError="true" />
            <br />
            <asp:TextBox ID="TxtUserID" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ValUserID" runat="server" ControlToValidate="TxtUserID"
                ErrorMessage="아이디를 입력하세요" ForeColor="Red" Display="Dynamic" />
            (필수)
            <br />
            <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" />
            <asp:RequiredFieldValidator ID="ValPassword" runat="server" ControlToValidate="TxtPassword"
                ErrorMessage="암호를 입력하세요" ForeColor="Red" Display="Dynamic" />
            (필수)
            <br />
            <asp:TextBox ID="TxtConfirmPassword" runat="server" TextMode="Password" />
            <asp:RequiredFieldValidator ID="ValConfirmPassword" runat="server" ControlToValidate="TxtConfirmPassword"
                ErrorMessage="암호확인을 입력하세요" ForeColor="Red" Display="Dynamic" />
            (필수)
            <br />
            <asp:CompareValidator ID="ValComparePassword" runat="server" ControlToValidate="TxtPassword"
                ControlToCompare="TxtConfirmPassword" SetFocusOnError="true" ForeColor="DarkRed"
                ErrorMessage="암호가 일치하지 않습니다" Display="Dynamic" />
            <br />

            <%--이메일 유효성 확인 => 이메일 형식 확인--%> 
            <asp:TextBox ID="TxtEmail" runat="server" />
            <asp:RegularExpressionValidator ID="ValEmail" runat="server" ControlToValidate="TxtEmail"
                ErrorMessage="이메일을 정확히 입력하세요" Display="Dynamic" ForeColor="Red"
                ValidationExpression="\w+([-+.']\+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" /><br />

            <asp:Button ID="BtnLogin" runat="server" OnClick="BtnLogin_Click" Text="로그인" />
            <asp:ValidationSummary ID="ValSummary" runat="server" ShowMessageBox="false" 
                ShowSummary="true" DisplayMode="BulletList" />

        </div>
    </form>
    <uc1:Copyright runat="server" id="Copyright" />
</body>
</html>

<%@ page language="C#" autoeventwireup="true" inherits="_Default, App_Web_nfgzqgdm" %>

<%@ Register Namespace="EnterpriseLibrary.Validation.Integration.AspNet"
    TagPrefix="entlibvalidation" Assembly="EnterpriseLibrary.Validation.Integration.AspNet" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="Name" runat="server" Text="0123456789012345" />
            <entlibvalidation:PropertyProxyValidator ID="PropertyValidatorProxyControl" runat="server"
                SourceTypeName="DomainModel.DomainObject" PropertyName="Name" ControlToValidate="Name"
                SpecificationSource="Attributes" RulesetName="" />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Button" /></div>
    </form>
</body>
</html>

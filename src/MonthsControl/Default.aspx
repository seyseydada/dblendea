<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MonthsControl._Default" %>
<%@ Register TagPrefix="dbl" TagName="MonthsControl" Src="~/MonthsControl.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="default.css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<div id="month-control">
			<dbl:MonthsControl id="monthsCtl" runat="server"></dbl:MonthsControl>
			<asp:Button ID="btnSubmit" runat="server" Text="Submit" />
		</div>
		<div id="results">
			<asp:Label ID="lblIds" runat="server" Text="Selected month id's:"></asp:Label>
			<%= monthsCtl.SelectedMonthIds %>
			<br />
			<asp:Label ID="lblNames" runat="server" Text="Selected month names:"></asp:Label>
			<%= monthsCtl.SelectedMonthNames %>
		</div>
    </div>
    </form>
</body>
</html>

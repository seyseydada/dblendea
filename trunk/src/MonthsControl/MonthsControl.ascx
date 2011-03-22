<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MonthsControl.ascx.cs" Inherits="Controls.MonthsControl" %>

<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.4/jquery.min.js" ></script>
<script type="text/javascript" >
	jQuery(document).ready(function($)
	{
		$("#<%= txtMonths.ClientID %>").click(function()
		{
			var offset = $(this).position();
			var pTop = offset.top + 20;
			var pLeft = offset.left;

			// log("top", pTop, "left", pLeft);

			$("#<%= chkList.ClientID %>").css("top", pTop).css("left", pLeft).toggle();
			return false;
		});

		$("#<%= chkList.ClientID %>").click(function(e)
		{
			e.stopPropagation();
		});

		$("#<%= chkList.ClientID %> #<%= chkList.ClientID %>_0").click(function()
		{
			if ($(this).attr("checked"))
				$("#<%= chkList.ClientID %> input[type=checkbox]").attr("checked", "checked");
			else
				$("#<%= chkList.ClientID %> input[type=checkbox]").attr("checked", "");
		});

		$(document).click(function(e)
		{
			// log(e.target.id);
			$("#<%= chkList.ClientID %>").hide();
		});
	});
</script>

<asp:TextBox ID="txtMonths" runat="server" CssClass="select-box unselectable" Text="Select months" ReadOnly="true" unselectable="on"></asp:TextBox>

<asp:CheckBoxList ID="chkList" runat="server" AppendDataBoundItems="true" CssClass="items-panel multidropdown" style="display:none"
	DataSourceID="odsMonths" DataTextField="MonthName" DataValueField="MonthNumber">
	<asp:ListItem Value="0" Text="All months" Selected="False"></asp:ListItem>
</asp:CheckBoxList>

<asp:ObjectDataSource ID="odsMonths" runat="server" TypeName="Controls.MonthObject" SelectMethod="GenerateMonths">
</asp:ObjectDataSource>
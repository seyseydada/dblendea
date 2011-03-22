using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Controls
{
	public partial class MonthsControl : UserControl
	{
		public string SelectedMonthIds
		{
			get
			{
				object s = ViewState["selectedMonthIds"];

				if ( s == null )
					return "";

				return s.ToString();
			}
			set { ViewState["selectedMonthIds"] = value; }
		}

		public string SelectedMonthNames
		{
			get
			{
				object s = ViewState["selectedMonthNames"];

				if ( s == null )
					return "";

				return s.ToString();
			}
			set { ViewState["selectedMonthNames"] = value; }
		}

		protected void Page_Load( object sender, EventArgs e )
		{
			if ( !IsPostBack )
			{
				chkList.Items.SelectItems( SelectedMonthIds );
			}

			List< string > monthIds = chkList.Items
				.Cast< ListItem >()
				.Where( i => i.Selected && i.Value != "0" )
				.Select( s => s.Value ).ToList();

			SelectedMonthIds = monthIds.AsString( true );

			List< string > monthNames = chkList.Items
				.Cast< ListItem >()
				.Where( i => i.Selected && i.Value != "0" )
				.Select( s => s.Text )
				.ToList();

			SelectedMonthNames = monthNames.AsString();
		}
	}
}
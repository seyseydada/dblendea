using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Controls
{
	public static class Extensions
	{
		/// <summary>
		/// Adds quotes around a string. Useful for paths.
		/// </summary>
		/// <param name="aString"></param>
		/// <returns></returns>
		public static string InQuotes( this string aString )
		{
			return "\"" + aString + "\"";
		}

		public static void DisplayInConsole< T >( this IList< T > list )
		{
			foreach ( T element in list )
			{
				Console.WriteLine( element.ToString() );
			}
		}

		/// <summary>
		/// Selects all items of the ListItemCollection that are in the IdList.
		/// </summary>
		/// <param name="Items"></param>
		/// <param name="IdList">1,2,5,8</param>
		public static void SelectItems( this ListItemCollection Items, string IdList )
		{
			if ( string.IsNullOrEmpty( IdList ) )
				return;

			foreach ( ListItem item in Items )
			{
				if ( IdList.Contains( item.Value ) )
					item.Selected = true;
			}
		}

		#region Collections extensions

		public static IList< string > SelectedNames( this CheckBoxList checkBoxList )
		{
			if ( checkBoxList == null )
				return new List< string >();

			return checkBoxList.Items.Cast< ListItem >().Where( i => i.Selected ).Select( s => s.Text ).ToList();
		}

		public static IList< string > SelectedValues( this CheckBoxList checkBoxList )
		{
			if ( checkBoxList == null )
				return new List< string >();

			return checkBoxList.Items.Cast< ListItem >().Where( i => i.Selected ).Select( s => s.Value ).ToList();
		}

		public static string AsString( this string[] stringArray )
		{
			if ( stringArray == null || stringArray.Length == 0 )
				return "";

			StringBuilder sb = new StringBuilder();
			foreach ( string s in stringArray )
			{
				sb.AppendFormat( "{0}, ", s );
			}

			return sb.ToString().TrimEnd( ',', ' ' );
		}

		public static string AsString< T >( this List< T > list )
		{
			return AsString( list, false );
		}

		public static string AsString< T >( this List< T > list, bool trimSpaces )
		{
			if ( list == null || list.Count == 0 )
				return "";

			StringBuilder sb = new StringBuilder();
			foreach ( T s in list )
			{
				if ( trimSpaces )
					sb.AppendFormat( "{0},", s );
				else
					sb.AppendFormat( "{0}, ", s );
			}

			return sb.ToString().TrimEnd( ',', ' ' );
		}

		#endregion
	}
}
using System;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;

namespace Controls
{
	public class MonthObject
	{
		public MonthObject( int monthNumber, string monthName )
		{
			MonthNumber = monthNumber;
			MonthName = monthName;
		}

		public int MonthNumber { get; set; }
		public string MonthName { get; set; }

		public override string ToString ()
		{
			return MonthName;
		}

		public static IList< MonthObject > GenerateMonths()
		{
			IList< MonthObject > months = new List< MonthObject >( 12 );
			for ( int i = 1; i <= 12; i++ )
			{
				months.Add( new MonthObject( i, new DateTime( 2010, i, 1 ).ToString( "MMMM", CultureInfo.CreateSpecificCulture( "en-US" ) ) ) );
			}
			return months;
		}
	}

#if DEBUG

	[TestFixture]
	public class MonthObjectTests
	{

		[Test]
		public void GenerateMonths ()
		{
			IList<MonthObject> months = MonthObject.GenerateMonths();

			Assert.That( months.Count, Is.EqualTo( 12 ) );
			Assert.That( months[0].MonthNumber, Is.EqualTo( 1 ) );
			Assert.That( months[1].MonthName, Is.EqualTo( "February" ) );

			months.DisplayInConsole();
		}
	}

#endif
}
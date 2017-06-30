using DllColorSchemes.Model;
using DllColorSchemes.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DllColorSchemes.Data
{
	/// <summary>
	/// Generate data here.
	/// </summary>
	internal static class Generate
	{
		/// <summary>
		/// Create and return a list of 'SchemeColor' objects.  
		/// Each instance defines colors to be used in one color scheme.
		/// </summary>
		/// <returns></returns>
		internal static List<SchemeColors> SchemeColors()
		{
			List<SchemeColors> schemeColorsList = null;

			try
			{
				schemeColorsList = new List<SchemeColors>();

				schemeColorsList.Add(CreateColorScheme1());
				schemeColorsList.Add(CreateColorScheme2());
				schemeColorsList.Add(CreateColorScheme3());
				schemeColorsList.Add(CreateColorScheme4());
				schemeColorsList.Add(CreateColorScheme5());
				schemeColorsList.Add(CreateColorScheme6());
				schemeColorsList.Add(CreateColorScheme7());
				schemeColorsList.Add(CreateColorScheme8());
				schemeColorsList.Add(CreateColorScheme9());
				schemeColorsList.Add(CreateColorScheme10());
				schemeColorsList.Add(CreateColorScheme11());
				schemeColorsList.Add(CreateColorScheme12());
				schemeColorsList.Add(CreateColorScheme13());
				schemeColorsList.Add(CreateColorScheme14());
			}
			catch (Exception ex)
			{
				// Log error and continue.
				ErrorHandler.Log(ex);
			}
			return schemeColorsList;
		}

		/// <summary>
		/// Setup the colors that comprise a color scheme.
		/// </summary>
		private static SchemeColors CreateColorScheme1()
		{
			SchemeColors aScheme = new SchemeColors();
			aScheme.Background1 = CreateColor(255, 255, 255);
			aScheme.Background2 = CreateColor(200, 200, 230);
			aScheme.Foreground1 = CreateColor(0, 0, 30);
			aScheme.Foreground2 = CreateColor(0, 0, 0);
			aScheme.MouseOverColor = CreateColor(255, 0, 0);

			return aScheme;
		}

		/// <summary>
		/// Setup the colors that comprise a color scheme.
		/// </summary>
		private static SchemeColors CreateColorScheme2()
		{
			SchemeColors aScheme = new SchemeColors();
			aScheme.Background1 = CreateColor(200, 200, 200);
			aScheme.Background2 = CreateColor(160, 160, 160);
			aScheme.Foreground1 = CreateColor(70, 70, 70);
			aScheme.Foreground2 = CreateColor(30, 30, 30);
			aScheme.MouseOverColor = CreateColor(140, 140, 0);

			return aScheme;
		}

		/// <summary>
		/// Setup the colors that comprise a color scheme.
		/// </summary>
		private static SchemeColors CreateColorScheme3()
		{
			SchemeColors aScheme = new SchemeColors();
			aScheme.Background1 = CreateColor(150, 150, 150);
			aScheme.Background2 = CreateColor(60, 60, 60);
			aScheme.Foreground1 = CreateColor(0, 20, 20);
			aScheme.Foreground2 = CreateColor(255, 255, 255);
			aScheme.MouseOverColor = CreateColor(200, 200, 0);

			return aScheme;
		}

		/// <summary>
		/// Setup the colors that comprise a color scheme.
		/// </summary>
		private static SchemeColors CreateColorScheme4()
		{
			SchemeColors aScheme = new SchemeColors();
			aScheme.Background1 = CreateColor(0, 0, 0);
			aScheme.Background2 = CreateColor(0, 0, 170);
			aScheme.Foreground1 = CreateColor(255, 255, 0);
			aScheme.Foreground2 = CreateColor(255, 255, 255);
			aScheme.MouseOverColor = Colors.Lime;

			return aScheme;
		}

		/// <summary>
		/// Setup the colors that comprise a color scheme.
		/// </summary>
		private static SchemeColors CreateColorScheme5()
		{
			SchemeColors aScheme = new SchemeColors();
			aScheme.Background1 = Colors.LightGreen;
			aScheme.Background2 = Colors.LightCyan;
			aScheme.Foreground1 = Colors.Blue;
			aScheme.Foreground2 = Colors.Green;
			aScheme.MouseOverColor = Colors.Blue;

			return aScheme;
		}

		/// <summary>
		/// Setup the colors that comprise a color scheme.
		/// </summary>
		private static SchemeColors CreateColorScheme6()
		{
			SchemeColors aScheme = new SchemeColors();
			aScheme.Background1 = CreateColor(0, 100, 20);
			aScheme.Background2 = CreateColor(0, 80, 20);
			aScheme.Foreground1 = CreateColor(200, 220, 220);
			aScheme.Foreground2 = Colors.Yellow;
			aScheme.MouseOverColor = Colors.Green;

			return aScheme;
		}

		/// <summary>
		/// Setup the colors that comprise a color scheme.
		/// </summary>
		private static SchemeColors CreateColorScheme7()
		{
			SchemeColors aScheme = new SchemeColors();
			aScheme.Background1 = Colors.LightBlue;
			aScheme.Background2 = Colors.LightSlateGray;
			aScheme.Foreground1 = Colors.Black;
			aScheme.Foreground2 = Colors.White;
			aScheme.MouseOverColor = Colors.LimeGreen;

			return aScheme;
		}

		/// <summary>
		/// Setup the colors that comprise a color scheme.
		/// </summary>
		private static SchemeColors CreateColorScheme8()
		{
			SchemeColors aScheme = new SchemeColors();
			aScheme.Background1 = CreateColor(0, 20, 100);
			aScheme.Background2 = CreateColor(90, 90, 90);
			aScheme.Foreground1 = CreateColor(55, 255, 55);
			aScheme.Foreground2 = CreateColor(255, 240, 240);
			aScheme.MouseOverColor = CreateColor(120, 190, 200);

			return aScheme;
		}

		/// <summary>
		/// Setup the colors that comprise a color scheme.
		/// </summary>
		private static SchemeColors CreateColorScheme9()
		{
			SchemeColors aScheme = new SchemeColors();
			aScheme.Background1 = CreateColor(200, 180, 180);
			//aScheme.Background2 = CreateColor(200, 160, 200);
			aScheme.Background2 = CreateColor(200, 220, 220);
			aScheme.Foreground1 = CreateColor(0, 0, 255);
			aScheme.Foreground2 = CreateColor(0, 60, 0);
			aScheme.MouseOverColor = CreateColor(240, 10, 10);

			return aScheme;
		}

		/// <summary>
		/// Setup the colors that comprise a color scheme.
		/// </summary>
		private static SchemeColors CreateColorScheme10()
		{
			SchemeColors aScheme = new SchemeColors();
			aScheme.Background1 = CreateColor(150, 150, 110);
			aScheme.Background2 = CreateColor(150, 100, 80);
			aScheme.Foreground1 = CreateColor(70, 20, 0);
			aScheme.Foreground2 = CreateColor(10, 10, 0);
			aScheme.MouseOverColor = CreateColor(100, 250, 150);

			return aScheme;
		}

		/// <summary>
		/// Setup the colors that comprise a color scheme.
		/// </summary>
		private static SchemeColors CreateColorScheme11()
		{
			SchemeColors aScheme = new SchemeColors();
			aScheme.Background1 = CreateColor(195, 195, 120);
			aScheme.Background2 = CreateColor(240, 240, 120);
			aScheme.Foreground1 = CreateColor(90, 20, 90);
			aScheme.Foreground2 = CreateColor(0, 70, 90);
			aScheme.MouseOverColor = CreateColor(20, 200, 30);

			return aScheme;
		}

		/// <summary>
		/// Setup the colors that comprise a color scheme.
		/// </summary>
		private static SchemeColors CreateColorScheme12()
		{
			SchemeColors aScheme = new SchemeColors();
			aScheme.Background1 = CreateColor(185, 205, 140);
			aScheme.Background2 = CreateColor(240, 210, 170);
			aScheme.Foreground1 = CreateColor(120, 50, 120);
			aScheme.Foreground2 = Colors.Black;
			aScheme.MouseOverColor = CreateColor(25, 220, 40);

			return aScheme;
		}

		/// <summary>
		/// Setup the colors that comprise a color scheme.
		/// </summary>
		private static SchemeColors CreateColorScheme13()
		{
			SchemeColors aScheme = new SchemeColors();
			aScheme.Background1 = CreateColor(85, 20, 40);
			aScheme.Background2 = CreateColor(40, 30, 40);
			aScheme.Foreground1 = CreateColor(220, 255, 200);
			aScheme.Foreground2 = CreateColor(255, 90, 200);
			aScheme.MouseOverColor = Colors.Red;

			return aScheme;
		}

		/// <summary>
		/// Setup the colors that comprise a color scheme.
		/// </summary>
		private static SchemeColors CreateColorScheme14()
		{
			SchemeColors aScheme = new SchemeColors();
			aScheme.Background1 = Colors.DimGray;
			aScheme.Background2 = Colors.DarkSlateGray;
			aScheme.Foreground1 = Colors.Yellow;
			aScheme.Foreground2 = Colors.LightGreen;
			aScheme.MouseOverColor = Colors.Lime;

			return aScheme;
		}

		/// <summary>
		/// Create and return a Color using the requested R G B values.
		/// </summary>
		/// <returns>A Color</returns>
		private static Color CreateColor(byte inR, byte inG, byte inB)
		{
			return new Color()
			{
				A = 255,
				R = inR,
				G = inG,
				B = inB
			};
		}

	}
}

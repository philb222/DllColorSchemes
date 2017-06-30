using DllColorSchemes.Data;
using DllColorSchemes.Extensions;
using DllColorSchemes.Model;
using DllColorSchemes.Utilities;
using DllColorSchemes.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace DllColorSchemes.ViewModel
{
	/// <summary>
	/// Provide support for a 'Color Scheme Choice' Window.
	/// </summary>
	public class ViewModel_ColorScheme
	{
		#region Constructor

		public ViewModel_ColorScheme(Style inToolTipStyle, Style inExtButtonStyle)
		{
			// Reference styles we need for creating UI elements.
			mToolTipStyle = inToolTipStyle;
			mExtButtonStyle = inExtButtonStyle;
		}
		#endregion

		#region Fields

		private Style mToolTipStyle;
		private Style mExtButtonStyle;
		private OfferColorScheme sampleScheme;
		private ToolTip mToolTip;
		private ResourceManager mRM = new ResourceManager("DllColorSchemes.Properties.Resources",
										typeof(ViewModel_ColorScheme).Assembly);
		#endregion

		#region Internal Method to Setup List of Color Schemes

		/// <summary>
		/// Create a list of color scheme objects. Each object has a Canvas element
		/// with embedded UI elements that advertise what a color scheme would look like.
		/// </summary>
		/// <returns>List of color scheme objects</returns>
		internal List<OfferColorScheme> SetupColorSchemes()
		{
			List<OfferColorScheme> colorSchemeList = null;

			try
			{
				// Init the list to return.
				colorSchemeList = new List<OfferColorScheme>();

				SetupCommonToolTip();

				// Generate a temporary list of scheme colors.
				List<SchemeColors> schemeColors = Generate.SchemeColors();

				int schemeNumber = 1;

				// Generate a list of color scheme objects to return.
				foreach (var scheme in schemeColors)
				{
					sampleScheme = new OfferColorScheme(
									scheme.Background1, scheme.Background2,
									scheme.Foreground1, scheme.Foreground2,
									scheme.MouseOverColor, mExtButtonStyle,
									mToolTip, schemeNumber++);

					colorSchemeList.Add(sampleScheme);
				}
			}
			catch (Exception ex)
			{
				// Log error and continue.
				ErrorHandler.Log(ex);
			}
			// Return the list.
			return colorSchemeList;
		}

		/// <summary>
		/// Setup the tooltip used when hovering over a color scheme object.
		/// </summary>
		private void SetupCommonToolTip()
		{
			mToolTip = new ToolTip();
			mToolTip.Style = mToolTipStyle;

			// Text = 'Choose color scheme'
			mToolTip.Content = (string)mRM.GetString("ChooseScheme");
		}

		#endregion


	}
}

using DllColorSchemes.Extensions;
using DllColorSchemes.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DllColorSchemes.Model
{
	/// <summary>
	/// This internal class is used to create a group of UI elements on a Canvas element that 
	/// will advertise how a color scheme will look in general. Once created, the internal caller 
	/// can access the Canvas (and other elements) to create a final UI presentation to the external caller.
	/// </summary>
	public class OfferColorScheme
	{
		#region Constructor
		public OfferColorScheme(Color inBackground1, Color inBackground2,
								Color inForeground1, Color inForeground2,
								Color inMouseOver, Style inExtButtonStyle,
								ToolTip inToolTip, int inColorSchemeNumber)
		{
			// If missing inputs, throw an exception.
			if (inBackground1 == null || inBackground2 == null ||
				inForeground1 == null || inForeground2 == null ||
				inMouseOver == null || inExtButtonStyle == null ||
				inToolTip == null || inColorSchemeNumber < 1)
			{
				throw new ArgumentNullException();
			}

			// Else save the inputs, creates brushes from the colors, and create a color scheme.
			else
			{
				tempColorScheme = new ColorScheme();
				tempColorScheme.Background1 = inBackground1;
				tempColorScheme.Background2 = inBackground2;
				tempColorScheme.Foreground1 = inForeground1;
				tempColorScheme.Foreground2 = inForeground2;
				tempColorScheme.MouseOverColor = inMouseOver;

				tempColorScheme.CreateBrushes();

				extButtonStyle = inExtButtonStyle;
				mToolTip = inToolTip;
				ColorSchemeNumber = inColorSchemeNumber;

				CreateColorSchemeSample(ColorSchemeNumber);
			}
		}
		#endregion

		#region Fields (Internal for the caller, and Private)

		internal int ColorSchemeNumber;
		internal Canvas aCanvas;
		internal ExtButton aButton;
		internal ColorScheme tempColorScheme;

		private ResourceManager mRM = new ResourceManager("DllColorSchemes.Properties.Resources",
									typeof(OfferColorScheme).Assembly);

		private Grid aGrid;
		private Style extButtonStyle;
		private ToolTip mToolTip;
		#endregion

		#region Private Methods
		// Populate a 'Canvas' control with UI objects using colors provided via the Constructor.
		// The caller can then place the 'Canvas' where they want in their UI.
		private void CreateColorSchemeSample(int inColorSchemeNumber)
		{
			// Create a button for which the user can click to choose the color scheme.
			// Create the button first because it covers the entire Canvas, so the Canvas will use its height + width.

			// The ExtButton type offers the extra 'mouseover color' property, so even that is part of the
			// chosen color scheme.
			try
			{
				aButton = new ExtButton();
				aButton.Style = extButtonStyle;

				// The background is transparent so the user sees the following colored UI controls.
				aButton.Background = new SolidColorBrush(Colors.Transparent);

				aButton.Margin = new Thickness(0, 0, 0, 0);
				aButton.BorderThickness = new Thickness(5, 5, 5, 5);
				aButton.Height = 200;
				aButton.Width = 200;
				aButton.Cursor = Cursors.Hand;
				aButton.HorizontalContentAlignment = HorizontalAlignment.Center;
				aButton.ToolTip = mToolTip;
				aButton.MouseOverBackground = tempColorScheme.MouseOverBrush;

				aCanvas = new Canvas();
				aCanvas.Margin = new Thickness(10, 10, 10, 10);
				aCanvas.Height = aButton.Height - 5;
				aCanvas.Width = aButton.Width - 5;
				aCanvas.Background = tempColorScheme.BackgroundSolidBrush1;

				// Simulate a main menustrip
				aGrid = new Grid();
				aGrid.Background = tempColorScheme.BackgroundSolidBrush2;
				aGrid.Margin = new Thickness(5, 5, 0, 0);
				aGrid.MinHeight = 30;
				aGrid.Width = 190;

				// Simulate a toolStrip for a main menu
				aGrid.Children.Add(ToolStripForBackground1AndForeground1());

				aCanvas.Children.Add(LabelForBackgroundLinearBrush1());
				aCanvas.Children.Add(TextBoxForBackground2AndForeground2());
				aCanvas.Children.Add(LabelForBackgroundLinearyBrush2());

				// Simulate buttons to use Radial Brushes
				aCanvas.Children.Add(ButtonForBackgroundRadial1());
				aCanvas.Children.Add(ButtonForBackgroundRadial2());

				// Simulate button for solid brushes Background2 and Foreground2
				aCanvas.Children.Add(ButtonForBackground2AndForeGround2());

				aCanvas.Children.Add(aGrid);
				aCanvas.Children.Add(aButton);
			}
			catch (Exception ex)
			{
				// Log the error
				ErrorHandler.Log(ex);
			}
		}

		/// <summary>
		/// Create a TooStrip looking textbox to demonstrate Background1 and Foreground1 brushes.
		/// </summary>
		/// <returns>A textbox</returns>
		private TextBox ToolStripForBackground1AndForeground1()
		{
			return new TextBox()
			{
				Background = tempColorScheme.BackgroundSolidBrush1,
				Foreground = tempColorScheme.ForegroundBrush1,
				Margin = new Thickness(10, 3, 0, 3),
				VerticalContentAlignment = VerticalAlignment.Center,
				HorizontalAlignment = HorizontalAlignment.Left,
				IsReadOnly = true,
				MinHeight = 20,
				MaxWidth = 180,

				// Text = 'File   Options' to look like a menu
				Text = mRM.GetString("FileOptions") as string
			};
		}

		/// <summary>
		/// Create a button looking textbox to show off BackgroundRadialBrush1.
		/// </summary>
		/// <returns>A textbox.</returns>
		private TextBox ButtonForBackgroundRadial1()
		{
			return new TextBox()
			{
				Background = tempColorScheme.BackgroundRadialBrush1,
				Foreground = tempColorScheme.ForegroundBrush1,
				Margin = new Thickness(20, 155, 0, 0),
				IsReadOnly = true,
				MinHeight = 24,
				MinWidth = 50,
				HorizontalContentAlignment = HorizontalAlignment.Center,
				VerticalContentAlignment = VerticalAlignment.Center,
				// Text = 'Test'
				Text = mRM.GetString("Test") as string
			};
		}

		/// <summary>
		/// Create a button looking textbox to show off BackgroundRadialBrush2.
		/// </summary>
		/// <returns>A textbox.</returns>
		private TextBox ButtonForBackgroundRadial2()
		{
			return new TextBox()
			{
				Background = tempColorScheme.BackgroundRadialBrush2,
				Foreground = tempColorScheme.ForegroundBrush2,
				Margin = new Thickness(75, 155, 0, 0),
				IsReadOnly = true,
				MinHeight = 24,
				MinWidth = 50,
				HorizontalContentAlignment = HorizontalAlignment.Center,
				VerticalContentAlignment = VerticalAlignment.Center,
				// Text = 'Test'
				Text = mRM.GetString("Test") as string
			};
		}

		/// <summary>
		/// Create a button looking textbox to show off Background1 and Foreground1 brushes.
		/// </summary>
		/// <returns>A textbox.</returns>
		private TextBox ButtonForBackground2AndForeGround2()
		{
			return new TextBox()
			{
				Background = tempColorScheme.BackgroundSolidBrush2,
				Foreground = tempColorScheme.ForegroundBrush2,
				Margin = new Thickness(130, 155, 0, 0),
				IsReadOnly = true,
				MinHeight = 24,
				MinWidth = 50,
				HorizontalContentAlignment = HorizontalAlignment.Center,
				VerticalContentAlignment = VerticalAlignment.Center,
				// Text = 'Test'
				Text = mRM.GetString("Test") as string
			};
		}

		/// <summary>
		/// Create a label to demonstrate BackgroundLinearBrush2
		/// </summary>
		/// <returns></returns>
		private Label LabelForBackgroundLinearyBrush2()
		{
			return new Label()
			{
				Background = tempColorScheme.BackgroundLinearBrush2,
				Height = 20,
				Width = 180,
				Margin = new Thickness(10d, 120d, 0d, 0d)
			};
		}

		/// <summary>
		/// Create a text box to demonstrate background2 and foreground2 brushes.
		/// </summary>
		/// <returns>A textbox</returns>
		private TextBox TextBoxForBackground2AndForeground2()
		{
			return new TextBox()
			{
				Background = tempColorScheme.BackgroundSolidBrush2,
				Foreground = tempColorScheme.ForegroundBrush2,
				Margin = new Thickness(7.5d, 75d, 0d, 0d),
				IsReadOnly = true,
				MinHeight = 40,
				MaxWidth = 195,
				TextWrapping = TextWrapping.Wrap,

				// Text = 'The quick brown fox jumped over the lazy dog.'
				Text = mRM.GetString("QuickBrownFox") as string
			};
		}

		/// <summary>
		/// Create a label to demonstrate BackgroundLinearBrush1
		/// </summary>
		/// <returns></returns>
		private Label LabelForBackgroundLinearBrush1()
		{
			return new Label()
			{
				Background = tempColorScheme.BackgroundLinearBrush1,
				Height = 20,
				Width = 180,
				Margin = new Thickness(10d, 50d, 0d, 0d)
			};
		}
		#endregion

	}
}

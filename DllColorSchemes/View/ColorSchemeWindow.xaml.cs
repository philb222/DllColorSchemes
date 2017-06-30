using DllColorSchemes.Model;
using DllColorSchemes.Utilities;
using DllColorSchemes.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DllColorSchemes.View
{
	/// <summary>
	/// Interaction logic for ColorSchemeWindow.xaml
	/// 
	/// Provide a list of color schemes for the caller to choose from.
	/// The caller-provided 'ColorScheme' object gets updated with the chosen color scheme.
	/// Then the caller can use / bind their UI to colors / brushes from that 'ColorScheme' object.
	/// </summary>
	public partial class ColorSchemeWindow : WindowBase
	{
		#region Constructor
		public ColorSchemeWindow(ColorScheme inColorScheme)
		{
			InitializeComponent();

			// Save the caller's color scheme object. It gets updated with color/brushes later.
			mCallersColorScheme = inColorScheme;

			// Reference styles we'll use when presenting the color scheme choices.
			mToolTipStyle = (Style)this.Resources["ToolTipStyle"];
			mExtButtonStyle = (Style)this.Resources["ExtButtonStyle"];

			// Create the view model and assign it to our data context here.
			mViewModel = new ViewModel_ColorScheme(mToolTipStyle, mExtButtonStyle);
			this.DataContext = mViewModel;
		}
		#endregion

		#region Private fields

		private ColorScheme mCallersColorScheme;
		private ViewModel_ColorScheme mViewModel;
		private Style mToolTipStyle;
		private Style mExtButtonStyle;
		private List<OfferColorScheme> mColorSchemes;
		private CommandBinding mColorSchemeButton;

		#endregion

		#region RoutedUICommand for selecting a color scheme
		private static readonly RoutedUICommand mSelectColorScheme_Command = new RoutedUICommand("Select a color scheme",
								"SelectColorScheme", typeof(ColorSchemeWindow));

		public static RoutedUICommand SelectColorScheme
		{
			get { return mSelectColorScheme_Command; }
		}
		#endregion

		#region Window Loaded Event
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			e.Handled = true;

			try
			{
				this.Title = mRM.GetString("ChooseColorScheme");
				labQuit.Content = mRM.GetString("Quit");

				// Setup a command for color scheme buttons to use.
				mColorSchemeButton = new CommandBinding();
				mColorSchemeButton.Command = SelectColorScheme;
				mColorSchemeButton.Executed += ExecuteSaveScheme;
				this.CommandBindings.Add(mColorSchemeButton);

				// Add color schemes to the UI
				ShowColorSchemes();
			}
			catch (Exception ex)
			{
				// Log error, show user-friendly error message, and close.
				string errorMessage = ErrorHandler.Log(ex);

				MessageBox.Show(errorMessage, mRM.GetString("Error"), MessageBoxButton.OK, MessageBoxImage.Error);
				this.Close();
			}
		}

		/// <summary>
		/// Show a group of color schemes in the UI. Each scheme is enveloped by a button.
		/// Each button gets wired up to receive its scheme number. That way when the user
		/// clicks on a 'scheme / button', the executed handling (see ExecuteSaveScheme below) 
		/// knows which scheme number was selected.
		/// </summary>
		private void ShowColorSchemes()
		{
			try
			{
				// Get a list of color scheme objects.
				mColorSchemes = mViewModel.SetupColorSchemes();

				// For each color scheme...
				foreach (OfferColorScheme scheme in mColorSchemes)
				{
					// Have each button provide its 'number' during the RoutedCommand handling.
					scheme.aButton.Command = SelectColorScheme;
					scheme.aButton.CommandParameter = scheme.ColorSchemeNumber;

					// Add the canvas of objects to our UI.
					MainPanel.Children.Add(scheme.aCanvas);
				}
			}
			catch (Exception ex)
			{
				// Log error, show user-friendly error message, and close.
				string errorMessage = ErrorHandler.Log(ex);

				MessageBox.Show(errorMessage, mRM.GetString("Error"), MessageBoxButton.OK, MessageBoxImage.Error);
				this.Close();
			}
		}
		#endregion

		#region Save a chosen Color Scheme

		/// <summary>
		/// Respond to the user 'clicking' on a color scheme button / command by:
		/// 1. Update the caller's 'ColorScheme' object's public properties with the chosen colors.
		/// 2. Update the caller's 'ColorScheme' object's with brushes created from the chosen colors.
		/// 3. Close this window - we're done.
		/// </summary>
		public void ExecuteSaveScheme(object sender, ExecutedRoutedEventArgs e)
		{
			try
			{
				// Reference the chosen temporary 'Offer Color Scheme' object.
				int colorSchemeIndex = (int)e.Parameter - 1;
				OfferColorScheme offerScheme = mColorSchemes[colorSchemeIndex];

				// Copy the colors into the caller's object.
				mCallersColorScheme.Background1 = offerScheme.tempColorScheme.Background1;
				mCallersColorScheme.Background2 = offerScheme.tempColorScheme.Background2;
				mCallersColorScheme.Foreground1 = offerScheme.tempColorScheme.Foreground1;
				mCallersColorScheme.Foreground2 = offerScheme.tempColorScheme.Foreground2;
				mCallersColorScheme.MouseOverColor = offerScheme.tempColorScheme.MouseOverColor;

				// Create the brushes in the caller's object too.
				mCallersColorScheme.CreateBrushes();

				this.Close();
			}
			catch (Exception ex)
			{
				// Log error, show user-friendly error message, and close.
				string errorMessage = ErrorHandler.Log(ex);

				MessageBox.Show(errorMessage, mRM.GetString("Error"), MessageBoxButton.OK, MessageBoxImage.Error);
				this.Close();
			}
		}
		#endregion

		#region Button Quit and Closing events
		private void btnQuit_Click(object sender, RoutedEventArgs e)
		{
			e.Handled = true;

			this.Close();
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (mColorSchemeButton != null)
			{
				mColorSchemeButton.Executed -= ExecuteSaveScheme;
			}
		}
		#endregion


	}
}

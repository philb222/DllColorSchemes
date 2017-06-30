using DllColorSchemes.APIs;
using DllColorSchemes.Model;
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
using TestColorSchemes.Utilities;

namespace TestColorSchemes
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void btnColorSchemes_Click(object sender, RoutedEventArgs e)
		{
			ColorScheme ourScheme = (ColorScheme)Application.Current.Resources["ColorSchemeBinder"];
			Window aWindow = ColorSchemeAPI.GetColorSchemeWindow(ourScheme);
			aWindow.ShowDialog();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			if (!ErrorHandler.CheckService())
			{
				MessageBox.Show("The local error service is not available - need to run it.", 
					"Error", MessageBoxButton.OK, MessageBoxImage.Error);

				this.Close();
			}
		}
	}
}

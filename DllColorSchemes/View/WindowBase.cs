using DllColorSchemes.Utilities;
using System;
using System.Drawing;
using System.Resources;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace DllColorSchemes.View
{
	/// <summary>
	/// For a base for windows used.
	/// </summary>
	public class WindowBase : Window
	{
		protected ResourceManager mRM = new ResourceManager("DllColorSchemes.Properties.Resources", 
										typeof(WindowBase).Assembly);

		#region Constructor
		public WindowBase()
		{
			try
			{
				// Set the 'Icon' for all windows.
				Icon tempIcon = (Icon)mRM.GetObject("ProgramIcon");
				Icon = Imaging.CreateBitmapSourceFromHIcon(
					   tempIcon.Handle,
					   Int32Rect.Empty,
					   BitmapSizeOptions.FromEmptyOptions());
			}
			catch (Exception ex)
			{
				// Log the exception
				ErrorHandler.Log(ex);
			}
		}
		#endregion

	}
}

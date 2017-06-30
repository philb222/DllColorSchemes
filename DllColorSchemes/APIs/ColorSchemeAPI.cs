using DllColorSchemes.Model;
using DllColorSchemes.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DllColorSchemes.APIs
{
	public static class ColorSchemeAPI
	{
		/// <summary>
		/// This class is the 'entry point' for using this Color Scheme DLL. Steps are:
		/// 
		/// 1. Prior to using this API, external callers each have a Model / "ColorScheme" object  which they use 
		///    for colors and brushes in their UI via bindings. Each ColorScheme provides access to several colors and brushes,
		///    which the caller optionally uses in UI bindings for background, foreground, etc. properties of UI elements.
		/// 2. Caller passes their ColorScheme instance here, which provides them with a special UI / Window of color scheme choices.
		/// 3. Caller issues the ShowDialog() on the window object returned from here.
		/// 4. Caller chooses a color scheme from the window. This causes the window to close, and 
		///    their "ColorScheme" object is now updated with colors and brushes for the requested color scheme.
		///    The "ColorScheme" class implements INotifyPropertyChanged for its colors and brushes. This means UI element(s) 
		///    bound to these properties will be updated visually.
		///    
		///		NOTE: This DLL requires the "Local Error Service" (a WCF service hosted in another WPF application) to be running.
		///			  All unexpected errors are sent their for logging and user notification.
		/// </summary>
		/// <param name="callersColorScheme"></param>
		/// <returns>A Window filled with color scheme choices.</returns>
		public static Window GetColorSchemeWindow(ColorScheme callersColorScheme)
		{
			return new ColorSchemeWindow(callersColorScheme);
		}
	}
}

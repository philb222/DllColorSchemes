using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DllColorSchemes.Extensions
{
	/// <summary>
	/// Extend the Button control with a "MouseOverBackground" DependencyProperty.
	/// This is used by a special 'style' with the key 'ExtButtonStyle'.
	/// </summary>
	public class ExtButton : Button
	{
		public static readonly DependencyProperty MouseOverBackgroundProperty =
			   DependencyProperty.Register("MouseOverBackground",
			   typeof(Brush),
			   typeof(ExtButton),
			   new FrameworkPropertyMetadata(new SolidColorBrush(Colors.White), FrameworkPropertyMetadataOptions.AffectsRender));

		public static Brush GetMouseOverBackground(UIElement e)
		{
			return (Brush)e.GetValue(MouseOverBackgroundProperty);
		}

		public static void SetMouseOverBackground(UIElement e, Brush value)
		{
			e.SetValue(MouseOverBackgroundProperty, value);
		}

		public Brush MouseOverBackground
		{
			get { return (Brush)GetValue(MouseOverBackgroundProperty); }

			set { SetValue(MouseOverBackgroundProperty, value); }
		}
	}
}

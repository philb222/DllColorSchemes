using DllColorSchemes.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DllColorSchemes.Model
{
	/// <summary>
	/// This class is used by:
	/// 1. An external caller creates an instance of this class. This class provides properties regarding the
	///    currently selected colors for a color scheme. The user binds these properties to their UI / XAML.
	/// 2. The external caller then calls the APIs/ColorSchemeAPI.GetColorSchemeWindow('their ColorScheme object') to 
	///    get a window of color scheme choices.
	/// 3. The chosen color scheme results with properties of this class to be updated, which updates the caller's
	///    UI via INotifyPropertyChanged.
	/// </summary>
	public class ColorScheme : INotifyPropertyChanged
	{
		#region Constructor
		public ColorScheme()
		{
			// Setup default colors...
			_Background1 = Properties.Settings.Default.Background1;
			_Background2 = Properties.Settings.Default.Background2;

			_Foreground1 = Properties.Settings.Default.Foreground1;
			_Foreground2 = Properties.Settings.Default.Foreground2;

			_MouseOverColor = Properties.Settings.Default.MouseOverColor;

			CreateBrushes();
		}
		#endregion

		#region Internal and Private Create Brushes Method
		/// <summary>
		/// Create brush objects from the colors set.
		/// UI's can then bind to brushes and/or colors.
		/// </summary>
		internal void CreateBrushes()
		{
			CreateBackgroundSolidBrushes();

			CreateBackgroundLinearBrush1();
			CreateBackgroundLinearBrush2();

			CreateBackgroundRadialBrush1();
			CreateBackgroundRadialBrush2();

			CreateForegroundBrushes();
			CreateMouseOverBrush();
		}
		#endregion

		#region Private Create Background Solid Brushes

		private void CreateBackgroundSolidBrushes()
		{
			SolidColorBrush aBrush = new SolidColorBrush()
			{
				Color = Background1
			};
			BackgroundSolidBrush1 = aBrush;

			aBrush = new SolidColorBrush()
			{
				Color = Background2
			};
			BackgroundSolidBrush2 = aBrush;
		}
		#endregion

		#region Private Create Background Linear Gradient Brush1

		/// <summary>
		/// Create a background linear brush using 3 gradient stops that use:
		/// 1. Background1 color
		/// 2. Background2 color
		/// 3. Background1 color
		/// </summary>
		private void CreateBackgroundLinearBrush1()
		{
			GradientStop gradStop;
			LinearGradientBrush aBrush = new LinearGradientBrush()
			{
				StartPoint = new Point(0, 1),
				EndPoint = new Point(1, 1)
			};

			// Create and add gradient stop 1
			gradStop = new GradientStop()
			{
				Color = Background1,
				Offset = 0d
			};
			aBrush.GradientStops.Add(gradStop);

			// Create and add gradient stop 2
			gradStop = new GradientStop()
			{
				Color = Background2,
				Offset = 0.5d
			};
			aBrush.GradientStops.Add(gradStop);

			// Create and add gradient stop 3
			gradStop = new GradientStop()
			{
				Color = Background1,
				Offset = 1d
			};
			aBrush.GradientStops.Add(gradStop);

			BackgroundLinearBrush1 = aBrush;
		}
		#endregion

		#region Private Create Background Linear Gradient Brush2

		/// <summary>
		/// Create a background linear brush using 3 gradient stops that use:
		/// 1. Background2 color
		/// 2. Background1 color
		/// 3. Background2 color
		/// </summary>
		private void CreateBackgroundLinearBrush2()
		{
			GradientStop gradStop;
			LinearGradientBrush aBrush = new LinearGradientBrush()
			{
				StartPoint = new Point(0, 1),
				EndPoint = new Point(1, 1)
			};

			// Create and add gradient stop 1
			gradStop = new GradientStop()
			{
				Color = Background2,
				Offset = 0d
			};
			aBrush.GradientStops.Add(gradStop);

			// Create and add gradient stop 2
			gradStop = new GradientStop()
			{
				Color = Background1,
				Offset = 0.5d
			};
			aBrush.GradientStops.Add(gradStop);

			// Create and add gradient stop 3
			gradStop = new GradientStop()
			{
				Color = Background2,
				Offset = 1d
			};
			aBrush.GradientStops.Add(gradStop);

			BackgroundLinearBrush2 = aBrush;
		}
		#endregion

		#region Private Create Background Radial Gradient Brush1

		/// <summary>
		/// Create a background radial brush using 2 gradient stops that use:
		/// 1. Background1 color
		/// 2. Background2 color
		/// </summary>
		private void CreateBackgroundRadialBrush1()
		{
			GradientStop gradStop;
			RadialGradientBrush aBrush = new RadialGradientBrush()
			{
				Center = new Point(0.5, 0.5),
				RadiusX = 0.5d,
				RadiusY = 0.5d
			};

			// Create and add gradient stop 1
			gradStop = new GradientStop()
			{
				Color = Background1,
				Offset = 0d
			};
			aBrush.GradientStops.Add(gradStop);

			// Create and add gradient stop 2
			gradStop = new GradientStop()
			{
				Color = Background2,
				Offset = 1d
			};
			aBrush.GradientStops.Add(gradStop);

			BackgroundRadialBrush1 = aBrush;
		}
		#endregion

		#region Private Create Background Radial Gradient Brush2

		/// <summary>
		/// Create a background radial brush using 2 gradient stops that use:
		/// 1. Background2 color
		/// 2. Background1 color
		/// </summary>
		private void CreateBackgroundRadialBrush2()
		{
			GradientStop gradStop;
			RadialGradientBrush aBrush = new RadialGradientBrush()
			{
				Center = new Point(0.5, 0.5),
				RadiusX = 0.5d,
				RadiusY = 0.5d
			};

			// Create and add gradient stop 1
			gradStop = new GradientStop()
			{
				Color = Background2,
				Offset = 0d
			};
			aBrush.GradientStops.Add(gradStop);

			// Create and add gradient stop 2
			gradStop = new GradientStop()
			{
				Color = Background1,
				Offset = 1d
			};
			aBrush.GradientStops.Add(gradStop);

			BackgroundRadialBrush2 = aBrush;
		}
		#endregion

		#region Private Create Foreground Brushes

		private void CreateForegroundBrushes()
		{
			SolidColorBrush aBrush = new SolidColorBrush()
			{
				Color = Foreground1
			};
			ForegroundBrush1 = aBrush;

			aBrush = new SolidColorBrush()
			{
				Color = Foreground2
			};
			ForegroundBrush2 = aBrush;
		}
		#endregion

		#region Private Create MouseOverBrush

		private void CreateMouseOverBrush()
		{
			SolidColorBrush aBrush = new SolidColorBrush()
			{
				Color = MouseOverColor
			};
			MouseOverBrush = aBrush;
		}
		#endregion

		#region Implement INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged([CallerMemberName] String propertyName = null)
		{
			if (PropertyChanged != null && propertyName != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		#endregion

		#region Properties
		private Color _Background1;
		public Color Background1
		{
			get { return _Background1; }
			set
			{
				if (value != _Background1)
				{
					_Background1 = value;
					NotifyPropertyChanged();
				}
			}
		}
		private Color _Background2;
		public Color Background2
		{
			get { return _Background2; }
			set
			{
				if (value != _Background2)
				{
					_Background2 = value;
					NotifyPropertyChanged();
				}
			}
		}

		private Color _Foreground1;
		public Color Foreground1
		{
			get { return _Foreground1; }
			set
			{
				if (value != _Foreground1)
				{
					_Foreground1 = value;
					NotifyPropertyChanged();
				}
			}
		}

		private Color _Foreground2;
		public Color Foreground2
		{
			get { return _Foreground2; }
			set
			{
				if (value != _Foreground2)
				{
					_Foreground2 = value;
					NotifyPropertyChanged();
				}
			}
		}

		private Color _MouseOverColor;
		public Color MouseOverColor
		{
			get { return _MouseOverColor; }
			set
			{
				if (value != _MouseOverColor)
				{
					_MouseOverColor = value;
					NotifyPropertyChanged();
				}
			}
		}

		private SolidColorBrush _BackgroundSolidBrush1;
		public SolidColorBrush BackgroundSolidBrush1
		{
			get { return _BackgroundSolidBrush1; }

			set
			{
				if (value != _BackgroundSolidBrush1)
				{
					_BackgroundSolidBrush1 = value;
					NotifyPropertyChanged();
				}
			}
		}

		private SolidColorBrush _BackgroundSolidBrush2;
		public SolidColorBrush BackgroundSolidBrush2
		{
			get { return _BackgroundSolidBrush2; }

			set
			{
				if (value != _BackgroundSolidBrush2)
				{
					_BackgroundSolidBrush2 = value;
					NotifyPropertyChanged();
				}
			}
		}

		private LinearGradientBrush _BackgroundLinearBrush1;
		public LinearGradientBrush BackgroundLinearBrush1
		{
			get { return _BackgroundLinearBrush1; }

			set
			{
				if (value != _BackgroundLinearBrush1)
				{
					_BackgroundLinearBrush1 = value;
					NotifyPropertyChanged();
				}
			}
		}

		private LinearGradientBrush _BackgroundLinearBrush2;
		public LinearGradientBrush BackgroundLinearBrush2
		{
			get { return _BackgroundLinearBrush2; }

			set
			{
				if (value != _BackgroundLinearBrush2)
				{
					_BackgroundLinearBrush2 = value;
					NotifyPropertyChanged();
				}
			}
		}

		private RadialGradientBrush _BackgroundRadialBrush1;
		public RadialGradientBrush BackgroundRadialBrush1
		{
			get { return _BackgroundRadialBrush1; }

			set
			{
				if (value != _BackgroundRadialBrush1)
				{
					_BackgroundRadialBrush1 = value;
					NotifyPropertyChanged();
				}
			}
		}

		private RadialGradientBrush _BackgroundRadialBrush2;
		public RadialGradientBrush BackgroundRadialBrush2
		{
			get { return _BackgroundRadialBrush2; }

			set
			{
				if (value != _BackgroundRadialBrush2)
				{
					_BackgroundRadialBrush2 = value;
					NotifyPropertyChanged();
				}
			}
		}

		private SolidColorBrush _ForegroundBrush1;
		public SolidColorBrush ForegroundBrush1
		{
			get { return _ForegroundBrush1; }

			set
			{
				if (value != _ForegroundBrush1)
				{
					_ForegroundBrush1 = value;
					NotifyPropertyChanged();
				}
			}
		}

		private SolidColorBrush _ForegroundBrush2;
		public SolidColorBrush ForegroundBrush2
		{
			get { return _ForegroundBrush2; }

			set
			{
				if (value != _ForegroundBrush2)
				{
					_ForegroundBrush2 = value;
					NotifyPropertyChanged();
				}
			}
		}

		private SolidColorBrush _MouseOverBrush;
		public SolidColorBrush MouseOverBrush
		{
			get { return _MouseOverBrush; }

			set
			{
				if (value != _MouseOverBrush)
				{
					_MouseOverBrush = value;
					NotifyPropertyChanged();
				}
			}
		}
		#endregion


	}
}

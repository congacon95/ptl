using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace PTL.View.Components
{
	/// <summary>
	/// Interaction logic for Slider_Value.xaml
	/// </summary>
	public partial class Slider_Value : UserControl, INotifyPropertyChanged
	{
		public Slider_Value()
		{
			InitializeComponent();
		}
		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public int Value
		{
			get { return (int)GetValue(ValueProperty); }
			set { SetValue(ValueProperty, value); OnPropertyChanged(nameof(Value)); }
		}

		// Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty ValueProperty =
				DependencyProperty.Register("Value", typeof(int), typeof(Slider_Value), new PropertyMetadata(0));


		public string Text
		{
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty TextProperty =
				DependencyProperty.Register("Text", typeof(string), typeof(Slider_Value), new PropertyMetadata(""));




		public int Maximum
		{
			get { return (int)GetValue(MaximumProperty); }
			set { SetValue(MaximumProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Maximum.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty MaximumProperty =
				DependencyProperty.Register("Maximum", typeof(int), typeof(Slider_Value), new PropertyMetadata(48));




		public int Minimum
		{
			get { return (int)GetValue(MinimumProperty); }
			set { SetValue(MinimumProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Min.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty MinimumProperty =
				DependencyProperty.Register("Minimum", typeof(int), typeof(Slider_Value), new PropertyMetadata(0));







	}
}

using System.Windows;
using System.Windows.Controls;

namespace PTL.View.Components
{
	/// <summary>
	/// Interaction logic for TextBox_Info.xaml
	/// </summary>
	public partial class TextBox_Info : UserControl
	{
		public TextBox_Info()
		{
			InitializeComponent();
		}



		public string Value
		{
			get { return (string)GetValue(ValueProperty); }
			set { SetValue(ValueProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty ValueProperty =
				DependencyProperty.Register("Value", typeof(string), typeof(TextBox_Info), new PropertyMetadata(""));



		public string Text
		{
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty TextProperty =
				DependencyProperty.Register("Text", typeof(string), typeof(TextBox_Info), new PropertyMetadata(""));



		public bool IsChecked
		{
			get { return (bool)GetValue(IsCheckedProperty); }
			set { SetValue(IsCheckedProperty, value); }
		}

		// Using a DependencyProperty as the backing store for IsChecked.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty IsCheckedProperty =
				DependencyProperty.Register("IsChecked", typeof(bool), typeof(TextBox_Info), new PropertyMetadata(false));



	}
}

using System.Windows;
using System.Windows.Controls;

namespace PTL.View.Components
{
	/// <summary>
	/// Interaction logic for TextBoxs.xaml
	/// </summary>
	public partial class TextBoxs : UserControl
	{
		public TextBoxs()
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
				DependencyProperty.Register("Value", typeof(string), typeof(TextBoxs), new PropertyMetadata(""));

	}
}

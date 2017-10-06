using PTL.ViewModel;
using System.Windows.Controls;

namespace PTL.View.MainWindow
{
	/// <summary>
	/// Interaction logic for Settings.xaml
	/// </summary>
	public partial class Settings : UserControl
	{
		public Settings()
		{
			InitializeComponent();
		}

		private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if(App.d is null || App.d.l is null)
				return;
			var id = (sender as ComboBox).SelectedIndex;
			App.d.l = id == 0 ? new Language(0) :
				id == 1 ? new Language(1) :
				id == 2 ? new Language(2) : App.d.l;
		}

		private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			if ((bool)chb_hook.IsChecked)
			{

				App.mh.UnHook();
				App.kh.UnHook();
			}
			else
			{

				App.mh.Hook();
				App.kh.Hook();
			}
		}
	}
}

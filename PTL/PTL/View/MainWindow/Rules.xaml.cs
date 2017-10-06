using System.Windows.Controls;

namespace PTL.View.MainWindow
{
	/// <summary>
	/// Interaction logic for Rules.xaml
	/// </summary>
	public partial class Rules : UserControl
	{
		public Rules()
		{
			InitializeComponent();
			ViewModel.ActionState.Bound = API.Get_All_Screens_Bound();
		}
	}
}

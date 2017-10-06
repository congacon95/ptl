using System;
using System.Windows;
using System.Windows.Controls;
using PTL.View.MainWindow;
namespace PTL
{
	/// <summary>
	/// Main UI window which controls how the program work
	/// </summary>
	public partial class MainWindow : Window
	{
		public IntPtr HWND { get; set; }
		public MainWindow()
		{
			App.main = this;
			InitializeComponent();
			App.SetupApp();
			//mainMenu_Click(mainMenu, null);
			SizeChanged += (s, e) =>
			{
				if(App.d.st.IsStickyMainWindow)
					App.d.st.RESIZE.Execute(null);
				API.Log($"Resize window to {Width}");
			};
			menu_Click(menu, null);
			Loaded += (s, e) =>
			{
				HWND = new System.Windows.Interop.WindowInteropHelper(this).Handle;
				API.Log($"Main window's HWND = {HWND}");
				App.d.st.IsOn = App.d.st.IsOn;
				App.d.st.IsBlurMain = App.d.st.IsBlurMain;
				App.d.st.IsBlurOverlay = App.d.st.IsBlurOverlay;
				App.d.st.IsBlurFloat = App.d.st.IsBlurFloat;
			};
		}

		private void CheckOne(CheckBox sender, StackPanel grid)
		{
			foreach(CheckBox chb in grid.Children)
				chb.IsChecked = false;
			sender.IsChecked = true;
		}

		private void menu_Click(object sender, RoutedEventArgs e)
		{
			var parent = sender as StackPanel;
			var child = e is null ? parent.Children[0] as CheckBox : e.Source as CheckBox;
			CheckOne(child, parent);
			var id = parent.Children.IndexOf(child);
			label_main.Content = child.ToolTip;
			SwitchContent(id);
			sv_content.Height = Height - nav.Height - menu.Height ;
		}

		public int ViewID = 1;
		private void SwitchContent(int id)
		{
			if(id == ViewID)
				return;
			ViewID = id;
			content.Children.Clear();
			UserControl currentView =
				id == 0 ? new Settings() :
				id == 1 ? new Mouse() :
				id == 2 ? new WindowInfo() :
				id == 3 ? new CornerSetups() :
				id == 4 ? new Rules() :
				id == 5 ? new Keyboard() :
				id == 6 ? new About() :
				new UserControl();
			content.Children.Add(currentView);
			App.Add_LButtonUp(App.d.st.IsOn);
		}
	}
}

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static PTL.App;
namespace PTL.View
{
	/// <summary>
	/// Interaction logic for FloatWindow.xaml
	/// </summary>
	public partial class FloatWindow : Window
	{
		double CornerDistance
		{
			get { return st.Corner_Distance - 1; }
		}
		double ScreenWidth
		{
			get
			{
				return System.Windows.Forms.Screen.FromPoint(System.Windows.Forms.Cursor.Position).WorkingArea.Width;
			}
		}
		double ScreenHeight
		{
			get
			{
				return System.Windows.Forms.Screen.FromPoint(System.Windows.Forms.Cursor.Position).WorkingArea.Height;
			}
		}
		static bool IsMouseDrag = false;
		static bool IsMoveToCursor = false;
		public IntPtr HWND { get; private set; }
		public FloatWindow()
		{
			InitializeComponent();
			Width = 40;
			Height = 40;
			Left = -30000;
			Top = -30000;
			Show();
			HWND = new System.Windows.Interop.WindowInteropHelper(this).Handle;
			API.Log($"Float window's HWND = {HWND}");
		}


		void Window_SizeChanged(Object sender, SizeChangedEventArgs e)
		{
			Show();
			if(Width == 40 && Height == 40)
			{
				if(IsMouseDrag)
					st.IsDrag = IsMouseDrag;
				if(IsMoveToCursor)
					st.IsMoveToCursor = IsMoveToCursor;
				btn_ShowCornerSetup.Visibility = Visibility.Visible;
				LayoutRoot.Visibility = Visibility.Collapsed;
			}
			else
			{
				CurrentChb.IsChecked = false;
				IsMouseDrag = st.IsDrag;
				IsMoveToCursor = st.IsMoveToCursor;
				btn_ShowCornerSetup.Visibility = Visibility.Collapsed;
				LayoutRoot.Visibility = Visibility.Visible;
			}
		}


		static CheckBox CurrentChb = new CheckBox();
		public void GetCornnerSetup(Object sender, RoutedEventArgs e)
		{
			try
			{
				//if (e.Source is CheckBox)
				//{
				//    CurrentChb.IsChecked = false;
				//    CurrentChb = e.Source as CheckBox;
				//    CurrentChb.IsChecked = true;
				//    csvm.Setup.ID = GetCurrentChbIndex(CurrentChb as CheckBox, 
				//        csvm.Setup.Cols, csvm.Setup.Rows);
				//    if (csvm.Setup.ID >= 0)
				//    {
				//        window._State = csvm.Setup.SelectedPart.ToRect;
				//        window.ShowWindow_State("MouseDrag",
				//            settings.IsMouseCorner,
				//            window.hWnd,
				//            window._State,
				//            window.ScreenFromHwnd,
				//            window.Size,
				//            window.Flag);
				//    }
				//    btn_ShowCornerSetUp_Click(null, null);
				//}
			}
			catch(Exception ea) { Console.WriteLine(ea); }
		}
		void GetCornnerSetup(int CornerID)
		{
			try
			{
				Console.WriteLine("\t-> GetCornnerSetup -> " + CornerID);
				if(CornerID >= 0)
				{
					//window._State = csvm.Setup.Parts[CornerID].ToRect;
					window.ShowWindow_State("GetCornnerSetup -> ",
							st.IsCorner,
							window._Handle,
							window._State,
							window.Screen,
							window.Size,
							window.Flag);
				}
			}
			catch(Exception ea) { Console.WriteLine(ea); }
		}

		public CheckBox GetCheckBoxFromID(int ID, int Cols, int Rows)
		{
			if(ID < 4)
				return LayoutRoot.Children[ID] as CheckBox;
			if(ID < 4 + Cols)
				return TopCorner.Children[ID - 4] as CheckBox;
			if(ID < 4 + Cols + Rows)
				return LeftCorner.Children[ID - 4 - Cols] as CheckBox;
			if(ID < 4 + Cols + Rows * 2)
				return RightCorner.Children[ID - 4 - Cols - Rows] as CheckBox;
			return BottomCorner.Children[ID - 4 - Cols - Rows * 2] as CheckBox;
		}

		int GetCurrentChbIndex(CheckBox chb, int Cols, int Rows)
		{
			int ID = LayoutRoot.Children.IndexOf(chb);
			if(ID != -1)
				return ID;
			ID = TopCorner.Children.IndexOf(chb);
			if(ID >= 0)
				return 4 + ID;
			ID = BottomCorner.Children.IndexOf(chb);
			if(ID >= 0)
				return 4 + Cols + 2 * Rows + ID;
			ID = LeftCorner.Children.IndexOf(chb);
			if(ID >= 0)
				return 4 + Cols + ID;
			ID = RightCorner.Children.IndexOf(chb);
			if(ID >= 0)
				return 4 + Cols + Rows + ID;
			return -1;
		}

		int WIDTH = 200;
		int HEIGHT = 120;

		void btn_ShowCornerSetup_Click(Object sender, RoutedEventArgs e)
		{
			btn_ShowCornerSetup.IsChecked = true;
			Visibility = Visibility.Visible;
			switch(st.ID_FloatPos)
			{
				case 0:
					break;
				case 1:
					Left -= (WIDTH - Width);
					break;
				case 2:
					Top -= (HEIGHT - Height);
					break;
				case 3:
					Left -= (WIDTH - Width);
					Top -= (HEIGHT - Height);
					break;
				default:
					break;
			}
			Height = HEIGHT;
			Width = WIDTH;
			IsMouseDrag = st.IsDrag;
			IsMoveToCursor = st.IsMoveToCursor;
			CurrentChb.IsChecked = false;
			//CurrentChb = GetCheckBoxFromID(csvm.Setup.ID,
			//    csvm.Setup.Cols, csvm.Setup.Rows);
			CurrentChb.IsChecked = true;
		}

		private void Button_Click(Object sender, RoutedEventArgs e)
		{
			window.ShowWindow_State("MouseDrag",
					st.IsCorner,
					window.Handle,
					window._State,
					window.Get_Next_Screen(true),
					window.Size,
					window.Flag);
		}

		private void Window_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if(e.ChangedButton == MouseButton.Left)
				DragMove();
		}
	}
}

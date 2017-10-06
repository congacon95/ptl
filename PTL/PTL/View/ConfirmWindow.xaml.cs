using System;
using System.Windows;
using System.Windows.Controls;

namespace PTL.View
{
	/// <summary>
	/// Interaction logic for ConfirmWindow.xaml
	/// </summary>
	public partial class ConfirmWindow : Window
	{
		public IntPtr HWND { get; private set; }
		public ConfirmWindow()
		{
			InitializeComponent();
			Left = -30000;
			Top = -30000;
			Show();
			HWND = new System.Windows.Interop.WindowInteropHelper(this).Handle;
			API.Log($"Confirm window's HWND = {HWND}");
		}

		public void btnYes_Click(object sender, RoutedEventArgs args)
		{
			try
			{
				Hide();
				API.ShowWindow(App.overlay.HWND, API.SWC.Hide);
				if(btnYes.Equals(sender as Button))
				{
					App.window.Close();
				}
			}
			catch(Exception e) { API.Log(e); }

		}
	}
}

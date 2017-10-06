using System;
using System.Windows;

namespace PTL.View
{
	/// <summary>
	/// Interaction logic for OverlayWindow.xaml
	/// </summary>
	public partial class OverlayWindow : Window
	{
		public IntPtr HWND { get; private set; }
		public OverlayWindow()
		{
			InitializeComponent();
			Left = -30000;
			Top = -30000;
			Show();
			HWND = new System.Windows.Interop.WindowInteropHelper(this).Handle;
			API.Log($"Overlay window's HWND = {HWND}");
		}
	}
}

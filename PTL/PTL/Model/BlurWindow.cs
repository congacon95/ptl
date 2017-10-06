using System;
using System.Runtime.InteropServices;
using System.Windows;

namespace PTL.Model
{
	/// <summary>
	/// Allow support for blur background.
	/// </summary>
	class BlurWindow
	{
		[DllImport("user32.dll")]
		internal static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);
		[StructLayout(LayoutKind.Sequential)]
		internal struct WindowCompositionAttributeData
		{
			public WindowCompositionAttribute Attribute;
			public IntPtr Data;
			public int SizeOfData;
		}
		internal enum WindowCompositionAttribute
		{
			// ...
			WCA_ACCENT_POLICY = 19
			// ...
		}
		internal enum AccentState
		{
			ACCENT_DISABLED = 0,
			ACCENT_ENABLE_GRADIENT = 1,
			ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
			ACCENT_ENABLE_BLURBEHIND = 3,
			ACCENT_INVALID_STATE = 4
		}
		[StructLayout(LayoutKind.Sequential)]
		internal struct AccentPolicy
		{
			public AccentState AccentState;
			public int AccentFlags;
			public int GradientColor;
			public int AnimationId;
		}
		public static void Blur(Window wnd, bool isBlur)
		{
			var windowHelper = new System.Windows.Interop.WindowInteropHelper(wnd);
			var accent = new AccentPolicy();
			var accentStructSize = Marshal.SizeOf(accent);
			accent.AccentState = isBlur ? AccentState.ACCENT_ENABLE_BLURBEHIND : AccentState.ACCENT_DISABLED;

			var accentPtr = Marshal.AllocHGlobal(accentStructSize);
			Marshal.StructureToPtr(accent, accentPtr, false);

			var data = new WindowCompositionAttributeData();
			data.Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY;
			data.SizeOfData = accentStructSize;
			data.Data = accentPtr;

			SetWindowCompositionAttribute(windowHelper.Handle, ref data);
			Marshal.FreeHGlobal(accentPtr);
		}
	}
}

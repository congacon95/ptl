using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;

namespace PTL
{
	public class Hook
	{
		public delegate IntPtr HookHandler(int nCode, IntPtr wParam, IntPtr lParam);
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr SetWindowsHookEx(int idHook, HookHandler lpfn, IntPtr hMod, uint dwThreadId);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool UnhookWindowsHookEx(IntPtr hhk);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr GetModuleHandle(string lpModuleName);
	}
	public class KeyHook : Hook
	{
		#region Hook Messages
		const int WH_KEYBOARD_LL = 13;
		const int WM_KEYDOWN = 0x100;
		const int WM_SYSKEYDOWN = 0x104;
		const int WM_KEYUP = 0x101;
		const int WM_SYSKEYUP = 0x105;
		#endregion

		#region Callback Events
		public delegate void Event(Keys key);
		public event Event KeyDown;
		public event Event KeyUp;
		#endregion

		private IntPtr CallBack(int nCode, IntPtr wParam, IntPtr lParam)
		{
			if(nCode >= 0)
			{
				switch(wParam.ToInt32())
				{
					case WM_KEYDOWN:
					case WM_SYSKEYDOWN:
						KeyDown?.Invoke((Keys)Marshal.ReadInt32(lParam));
						break;

					case WM_KEYUP:
					case WM_SYSKEYUP:
						KeyUp?.Invoke((Keys)Marshal.ReadInt32(lParam));
						break;
				}
			}
			return CallNextHookEx(hookID, nCode, wParam, lParam);
		}
		private IntPtr hookID = IntPtr.Zero;
		private HookHandler callBack;
		public void Hook()
		{
			API.Log("Keyboard_Hook()");
			callBack = CallBack;
			using(ProcessModule module = Process.GetCurrentProcess().MainModule)
				hookID = SetWindowsHookEx(WH_KEYBOARD_LL, callBack, GetModuleHandle(module.ModuleName), 0);
		}
		public void UnHook()
		{
			API.Log("Keyboard_UnHook()");
			if(hookID == IntPtr.Zero)
				return;

			UnhookWindowsHookEx(hookID);
			hookID = IntPtr.Zero;
		}
		~KeyHook() { UnHook(); }
	}
	public class MouseHook : Hook
	{
		#region Hook Messages
		const int WH_MOUSE_LL = 14;
		const int WM_MBUTTONDBLCLK = 0x0209;
		const int WM_MOUSEMOVE = 0x0200;

		const int WM_LBUTTONDOWN = 0x0201;
		const int WM_LBUTTONUP = 0x0202;
		const int WM_LBUTTONDBLCLK = 0x0203;
		const int WM_RBUTTONDOWN = 0x0204;
		const int WM_RBUTTONUP = 0x0205;

		const int WM_MOUSEWHEEL = 0x020A;
		const int WM_MBUTTONDOWN = 0x0207;
		const int WM_MBUTTONUP = 0x0208;

		const int WM_XButtonDOWN = 0x020B;
		public const int X1BUTTIONDOWN = 65536;
		public const int X2BUTTIONDOWN = 131072;
		#endregion

		#region Callback Events
		/// <summary>
		/// Callback event output 
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct MouseCursor
		{
			public System.Drawing.Point Position;
			public uint Data, flags, TotalEventCount;
			public int dwExtraInfo, dwExtraInfo2, dwExtraInfo3, dwExtraInfo4, KeyID;
		}
		public delegate void Event(MouseCursor E);
		public event Event LButtonUp;
		public event Event MouseWheel;
		public event Event XButtonDown;
		//public event Event CallEverytime;
		//public event Event LButton;
		//public event Event LButtonDown;
		//public event Event RButtonDown;
		//public event Event RButtonUp;
		//public event Event MouseMove;
		//public event Event DoubleClick;
		//public event Event MButtonDown;
		//public event Event MButtonUp;
		#endregion

		private IntPtr CallBack(int nCode, IntPtr wParam, IntPtr lParam)
		{
			if(nCode >= 0)
			{
				MouseCursor ParseArg = (MouseCursor)Marshal.PtrToStructure(lParam, typeof(MouseCursor));
				ParseArg.KeyID = (int)wParam;
				////MSLLHOOKSTRUCT ParseArg2 = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(wParam, typeof(MSLLHOOKSTRUCT));
				//if (CallEverytime != null && WM_wParam != WM_MOUSEMOVE)
				//    CallEverytime(ParseArg);
				switch(wParam.ToInt32())
				{
					case WM_LBUTTONUP:
						LButtonUp?.Invoke(ParseArg);
						break;
					case WM_MOUSEWHEEL:
						MouseWheel?.Invoke(ParseArg);
						break;
					case WM_XButtonDOWN:
						XButtonDown?.Invoke(ParseArg);
						break;
						//case WM_LBUTTONDOWN:
						//    if (LButtonDown != null)
						//        LButtonDown(ParseArg); break;
						//case WM_RBUTTONDOWN:
						//    if (RButtonDown != null)
						//        RButtonDown(ParseArg); break;
						//case WM_RBUTTONUP:
						//    if (RButtonUp != null)
						////        RButtonUp(ParseArg); break;
						//case WM_MOUSEMOVE:
						//    if (MouseMove != null)
						//        MouseMove(ParseArg); break;
						//case WM_LBUTTONDBLCLK:
						//    if (DoubleClick != null)
						//DoubleClick(ParseArg); break;
						//case WM_MBUTTONDOWN:
						//    if (MButtonDown != null)
						//        MButtonDown(ParseArg); break;
						//case WM_MBUTTONUP:
						//    if (MButtonUp != null)
						//        MButtonUp(ParseArg); break;
				}
			}
			return CallNextHookEx(hookID, nCode, wParam, lParam);
		}
		private IntPtr hookID = IntPtr.Zero;
		private HookHandler callBack;
		public void Hook()
		{
			API.Log("Mouse_Hook()");
			callBack = CallBack;
			using(ProcessModule module = Process.GetCurrentProcess().MainModule)
				hookID = SetWindowsHookEx(WH_MOUSE_LL, callBack, GetModuleHandle(module.ModuleName), 0);
		}
		public void UnHook()
		{
			API.Log("Mouse_UnHook()");
			if(hookID == IntPtr.Zero)
				return;

			UnhookWindowsHookEx(hookID);
			hookID = IntPtr.Zero;
		}
		~MouseHook() { UnHook(); }
	}
}

using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Text;
using System.Diagnostics;
using static PTL.App;
using PTL.Model;
using System.Windows.Forms;
using System.IO;

namespace PTL
{
	/// <summary>
	/// Static class that contain all the low level API funtion and static funtions that commonly use across the app.
	/// </summary>
	public static class API
	{
		#region Win API[StructLayout(LayoutKind.Sequential)]
		public struct RECT
		{
			public int Left, Top, Right, Bottom;

			public RECT(int left, int top, int right, int bottom)
			{
				Left = left;
				Top = top;
				Right = right;
				Bottom = bottom;
			}

			public RECT(System.Drawing.Rectangle r) : this(r.Left, r.Top, r.Right, r.Bottom) { }

			public int X
			{
				get { return Left; }
				set { Right -= (Left - value); Left = value; }
			}

			public int Y
			{
				get { return Top; }
				set { Bottom -= (Top - value); Top = value; }
			}

			public int Height
			{
				get { return Bottom - Top; }
				set { Bottom = value + Top; }
			}

			public int Width
			{
				get { return Right - Left; }
				set { Right = value + Left; }
			}

			public System.Drawing.Point Location
			{
				get { return new System.Drawing.Point(Left, Top); }
				set { X = value.X; Y = value.Y; }
			}

			public System.Drawing.Size Size
			{
				get { return new System.Drawing.Size(Width, Height); }
				set { Width = value.Width; Height = value.Height; }
			}

			public static implicit operator System.Drawing.Rectangle(RECT r)
			{
				return new System.Drawing.Rectangle(r.Left, r.Top, r.Width, r.Height);
			}

			public static implicit operator RECT(System.Drawing.Rectangle r)
			{
				return new RECT(r);
			}

			public static bool operator ==(RECT r1, RECT r2)
			{
				return r1.Equals(r2);
			}

			public static bool operator !=(RECT r1, RECT r2)
			{
				return !r1.Equals(r2);
			}

			public bool Equals(RECT r)
			{
				return r.Left == Left && r.Top == Top && r.Right == Right && r.Bottom == Bottom;
			}

			public override bool Equals(object obj)
			{
				if (obj is RECT)
					return Equals((RECT)obj);
				else if (obj is System.Drawing.Rectangle)
					return Equals(new RECT((System.Drawing.Rectangle)obj));
				return false;
			}

			public override int GetHashCode()
			{
				return ((System.Drawing.Rectangle)this).GetHashCode();
			}

			public override string ToString()
			{
				return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{{Left={0},Top={1},Right={2},Bottom={3}}}", Left, Top, Right, Bottom);
			}
		}
		[StructLayout(LayoutKind.Sequential)]
		public struct WINDOWINFO
		{
			public uint cbSize;
			public uint dwStyle;
			public uint dwExStyle;
			public Rectangle rcWindow;
			public Rectangle rcClient;
			public uint dwWindowStatus;
			public uint cxWindowBorders;
			public uint cyWindowBorders;
			public ushort atomWindowType;
			public ushort wCreatorVersion;

			public WINDOWINFO(Boolean? filler) : this()   // Allows automatic initialization of "cbSize" with "new WINDOWINFO(null/true/false)".
			{
				cbSize = (UInt32)(Marshal.SizeOf(typeof(WINDOWINFO)));
			}
			public override string ToString()
			{
				return $"cbSize : {cbSize}\ndwStyle : {dwStyle}\n" +
					 $"dwExStyle : {dwExStyle}\ndwWindowStatus : {dwWindowStatus}\n" +
					 $"rcWindow : {rcWindow}\nrcClient : {rcClient}\n" +
					 $"cxWindowBorders : {cxWindowBorders}\ncyWindowBorders : {cyWindowBorders}\n" +
					 $"atomWindowType : {atomWindowType}\nwCreatorVersion : {wCreatorVersion}\n";
			}
		}
		[return: MarshalAs(UnmanagedType.Bool)]
		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool GetWindowInfo(IntPtr hwnd, ref WINDOWINFO pwi);

		[DllImport("user32.dll")]
		public static extern IntPtr GetForegroundWindow();

		[DllImport("user32.dll")]
		public static extern int GetSystemMetrics(int systemMetric);


		//ShowWindowCommands
		public enum SWC
		{
			/// <summary>
			/// Hides the window and activates another window.
			/// </summary>
			Hide = 0,
			/// <summary>
			/// Activates and displays a window. If the window is minimized or 
			/// maximized, the system restores it to its original size and position.
			/// An application should specify this flag when displaying the window 
			/// for the first time.
			/// </summary>
			Normal = 1,
			/// <summary>
			/// Activates the window and displays it as a minimized window.
			/// </summary>
			ShowMinimized = 2,
			/// <summary>
			/// Maximizes the specified window.
			/// </summary>
			Maximize = 3, // is this the right value?
										/// <summary>
										/// Activates the window and displays it as a maximized window.
										/// </summary>       
			ShowMaximized = 3,
			/// <summary>
			/// Displays a window in its most recent size and position. This value 
			/// is similar to <see cref="Win32.ShowWindowCommand.Normal"/>, except 
			/// the window is not activated.
			/// </summary>
			ShowNoActivate = 4,
			/// <summary>
			/// Activates the window and displays it in its current size and position. 
			/// </summary>
			Show = 5,
			/// <summary>
			/// Minimizes the specified window and activates the next top-level 
			/// window in the Z order.
			/// </summary>
			Minimize = 6,
			/// <summary>
			/// Displays the window as a minimized window. This value is similar to
			/// <see cref="Win32.ShowWindowCommand.ShowMinimized"/>, except the 
			/// window is not activated.
			/// </summary>
			ShowMinNoActive = 7,
			/// <summary>
			/// Displays the window in its current size and position. This value is 
			/// similar to <see cref="Win32.ShowWindowCommand.Show"/>, except the 
			/// window is not activated.
			/// </summary>
			ShowNA = 8,
			/// <summary>
			/// Activates and displays the window. If the window is minimized or 
			/// maximized, the system restores it to its original size and position. 
			/// An application should specify this flag when restoring a minimized window.
			/// </summary>
			Restore = 9,
			/// <summary>
			/// Sets the show state based on the SW_* value specified in the 
			/// STARTUPINFO structure passed to the CreateProcess function by the 
			/// program that started the application.
			/// </summary>
			ShowDefault = 10,
			/// <summary>
			///  <b>Windows 2000/XP:</b> Minimizes a window, even if the thread 
			/// that owns the window is not responding. This flag should only be 
			/// used when minimizing windows from a different thread.
			/// </summary>
			ForceMinimize = 11
		}
		/// <summary>
		/// Given a window's handler and SWC flag.<para/>
		/// Perform specific action to that window
		/// according the given flag.<para/>
		/// Use this funtion to show/hide window
		/// instead of using build in Show/Hide 
		/// funtion <para/>of Window class because it 
		/// won't allow calling across multiple
		/// tasks/threads.
		/// </summary>
		/// <param name="HWND"></param>
		/// <param name="nCmdShow"></param>
		/// <returns></returns>
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ShowWindow(IntPtr HWND, SWC nCmdShow);

		public static bool ShowWindow(IntPtr handle, bool isShow)
		{
			return ShowWindow(handle, isShow ? SWC.Show : SWC.Hide);
		}

		[return: MarshalAs(UnmanagedType.Bool)]
		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		public static extern bool PostMessage(IntPtr HWND, uint Msg, IntPtr wParam, IntPtr lParam);


		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr HWND, int Msg, IntPtr wParam, IntPtr lParam);

		public static string Get_Full_Path(string file_name)
		{
			return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file_name);
		}
		#endregion


		#region Get Window Info
		public static bool Validate_Handle(IntPtr handle)
		{
			if (handle == IntPtr.Zero) return false;
			if (handle == main.HWND)
			{
				return !st.IsCaptureWindowInfo;
			}
			if (handle == overlay.HWND)
			{

				ShowWindow(handle, SWC.Hide);
				return false;
			}
			if (handle == floatWnd.HWND)
			{

				return false;
			}
			return true;
		}
		public static IntPtr Get_Handle(int repeat)
		{
			IntPtr handle = IntPtr.Zero;
			while (repeat > 0)
			{
				System.Threading.Thread.Sleep(20);
				repeat--;
				handle = GetForegroundWindow();
				if (handle != IntPtr.Zero &&
						handle != floatWnd.HWND &&
						handle != overlay.HWND)
					break;
			}
			st.IsOverlayOpen = handle == overlay.HWND;
			return handle;
		}


		private static StringBuilder buffer = new StringBuilder(255);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int GetWindowText(IntPtr handle, StringBuilder buffer, int max_buffer_size);
		public static string Get_Title(IntPtr handle)
		{
			GetWindowText(handle, buffer, buffer.Capacity);
			return buffer.ToString();
		}

		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		public static extern int GetClassName(IntPtr handle, StringBuilder buffer, int max_buffer_size);
		public static string Get_Class(IntPtr handle)
		{
			GetClassName(handle, buffer, buffer.Capacity);
			return buffer.ToString();
		}

		[DllImport("user32.dll", SetLastError = true)]
		public static extern uint GetWindowThreadProcessId(IntPtr handle, out uint process_id);
		public static string Get_Process_Name(IntPtr handle)
		{
			GetWindowThreadProcessId(handle, out uint process_id);
			return (Process.GetProcessById((int)process_id)).ProcessName;
		}

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool GetWindowRect(IntPtr hwnd, out System.Drawing.Rectangle rectangle);
		public static Rectangle Get_State(IntPtr hwnd)
		{
			GetWindowRect(hwnd, out Rectangle state);
			state.Width -= state.Left;
			state.Height -= state.Top;
			return state;
		}

		/// <summary>
		/// Check if two wnd object has the same title, class and process name.
		/// <param name="other_wnd"></param>
		/// <returns></returns>
		public static bool Equals(this MyWindow wnd, MyWindow other_wnd)
		{
			return wnd.Process.Equals(other_wnd.Process) &&
							wnd.Class.Equals(other_wnd.Class) &&
							wnd.Title.Equals(other_wnd.Title);
		}
		/// <summary>
		/// Get the index of the window in the WindowsData that 
		/// has the same title, class and filename.
		/// </summary>
		/// <param name="list_wnd"></param>
		/// <param name="Wnd"></param>
		/// <returns></returns>
		public static int IndexOfWindow(
			this System.Collections.Generic.List<MyWindow> list_wnd, MyWindow Wnd)
		{
			foreach (MyWindow wnd in list_wnd)
				if (Equals(Wnd, wnd))
					return list_wnd.IndexOf(wnd);
			return -1;
		}

		public static Rectangle Get_All_Screens_Bound()
		{
			Rectangle rect = new Rectangle(0, 0, 0, 0);
			int right = 0, bottom = 0;
			foreach (Screen scr in Screen.AllScreens)
			{
				rect.X = rect.Left > scr.Bounds.Left ? scr.Bounds.Left : rect.Left;
				rect.Y = rect.Top > scr.Bounds.Top ? scr.Bounds.Top : rect.Top;

				right = right < scr.Bounds.Right ? scr.Bounds.Right : right;
				bottom = bottom < scr.Bounds.Bottom ? scr.Bounds.Bottom : bottom;
			}
			rect.Width = right - rect.Left;
			rect.Height = bottom - rect.Top;
			API.Log($"All screens bound: {rect}");
			return rect;
		}

		public class HideArea
		{
			public int Top { get; set; }
			public int Border { get; set; }
			public int Bottom { get; set; }
			public HideArea()
			{
				Top = Border = Bottom = 0;
			}
			public HideArea(int top, int border, int bottom)
			{
				Top = top;
				Border = border;
				Bottom = bottom;
			}
		}
		public static Rectangle Trim(this Rectangle state, HideArea size)
		{
			return state.Trim(size.Top, size.Border, size.Bottom);
		}
		public static Rectangle Trim(this Rectangle state,
									int top = 0, int border = 0, int bottom = 0)
		{
			return new Rectangle(
							state.Left - border, state.Top - top,
							state.Width + 2 * border,
							state.Height + top + border + bottom);
		}

		public static void Copy(ref Rectangle rect, Rectangle other)
		{
			rect = new Rectangle(other.Location, other.Size);
		}

		/// <summary>
		/// Calculate window position.
		/// </summary>
		/// <param name="screen"></param>
		/// <param name="_state"></param>
		/// <returns></returns>
		public static Point Calc_Pos(this Rectangle screen, Rectangle _state)
		{
			return new Point(
				screen.Left + screen.Width * _state.X / st.Size_Grid,
				screen.Top + screen.Height * _state.Y / st.Size_Grid);
		}
		/// <summary>
		/// Calculate window size.
		/// </summary>
		/// <param name="screen"></param>
		/// <param name="_state"></param>
		/// <returns></returns>
		public static Size Calc_Size(this Rectangle screen, Rectangle _state)
		{
			return new Size(
				screen.Width * _state.Width / st.Size_Grid,
				screen.Height * _state.Height / st.Size_Grid);
		}


		public enum Flags : uint
		{
			/// <summary>If the calling thread and the thread that owns the window are attached to different input queues, 
			/// the system posts the request to the thread that owns the window. This prevents the calling thread from 
			/// blocking its execution while other threads process the request.</summary>
			/// <remarks>SWP_ASYNCWINDOWPOS</remarks>
			AsynchronousWindowPosition = 0x4000,
			/// <summary>Prevents generation of the WM_SYNCPAINT message.</summary>
			/// <remarks>SWP_DEFERERASE</remarks>
			DeferErase = 0x2000,
			/// <summary>Draws a frame (defined in the window's class description) around the window.</summary>
			/// <remarks>SWP_DRAWFRAME</remarks>
			DrawFrame = 0x0020,
			/// <summary>Applies new frame styles set using the SetWindowLong function. Sends a WM_NCCALCSIZE message to 
			/// the window, even if the window's size is not being changed. If this flag is not specified, WM_NCCALCSIZE 
			/// is sent only when the window's size is being changed.</summary>
			/// <remarks>SWP_FRAMECHANGED</remarks>
			FrameChanged = 0x0020,
			/// <summary>Hides the window.</summary>
			/// <remarks>SWP_HIDEWINDOW</remarks>
			HideWindow = 0x0080,
			/// <summary>Does not activate the window. If this flag is not set, the window is activated and moved to the 
			/// top of either the topmost or non-topmost group (depending on the setting of the HWNDInsertAfter 
			/// parameter).</summary>
			/// <remarks>SWP_NOACTIVATE</remarks>
			DoNotActivate = 0x0010,
			/// <summary>Discards the entire contents of the client area. If this flag is not specified, the valid 
			/// contents of the client area are saved and copied back into the client area after the window is sized or 
			/// repositioned.</summary>
			/// <remarks>SWP_NOCOPYBITS</remarks>
			DoNotCopyBits = 0x0100,
			/// <summary>Retains the current position (ignores X and Y parameters).</summary>
			/// <remarks>SWP_NOMOVE</remarks>
			IgnoreMove = 0x0002,
			/// <summary>Does not change the owner window's position in the Z order.</summary>
			/// <remarks>SWP_NOOWNERZORDER</remarks>
			DoNotChangeOwnerZOrder = 0x0200,
			/// <summary>Does not redraw changes. If this flag is set, no repainting of any kind occurs. This applies to 
			/// the client area, the nonclient area (including the title bar and scroll bars), and any part of the parent 
			/// window uncovered as a result of the window being moved. When this flag is set, the application must 
			/// explicitly invalidate or redraw any parts of the window and parent window that need redrawing.</summary>
			/// <remarks>SWP_NOREDRAW</remarks>
			DoNotRedraw = 0x0008,
			/// <summary>Same as the SWP_NOOWNERZORDER flag.</summary>
			/// <remarks>SWP_NOREPOSITION</remarks>
			DoNotReposition = 0x0200,
			/// <summary>Prevents the window from receiving the WM_WINDOWPOSCHANGING message.</summary>
			/// <remarks>SWP_NOSENDCHANGING</remarks>
			DoNothing = 0x0400,
			/// <summary>
			/// Retains the current size (ignores the cx and cy parameters).</summary>
			/// <remarks>SWP_NOSIZE</remarks>
			IgnoreResize = 0x0001,
			/// <summary>Retains the current Z order (ignores the HWNDInsertAfter parameter).</summary>
			/// <remarks>SWP_NOZORDER</remarks>
			IgnoreZOrder = 0x0004,
			/// <summary>Displays the window.</summary>
			/// <remarks>SWP_SHOWWINDOW</remarks>
			ShowWindow = 0x0040,
		}
		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool SetWindowPos(IntPtr HWND, IntPtr HWNDInsertAfter, int X, int Y, int cx, int cy, Flags uFlags);

		public static bool SetWindowPos(IntPtr handle, Rectangle state)
		{
			//API.ShowWindow(overlay.HWND, SWC.Hide);
			API.ShowWindow(handle, SWC.Normal);
			return SetWindowPos(handle, IntPtr.Zero,
							state.Left, state.Top,
							state.Width, state.Height,
							Flags.AsynchronousWindowPosition);
		}

		/// <summary>
		/// Return 0 or 1 if key is down else return -3....
		/// </summary>
		/// <param name="vKey"></param>
		/// <returns></returns>
		[DllImport("user32.dll")]
		public static extern short GetAsyncKeyState(Keys vKey);
		public static bool IsKeyDown(Keys Key)
		{
			short keyState = GetAsyncKeyState(Key);
			return (keyState != 0 && keyState != 1);
		}
		public static bool CtrlCheck(bool isTrue, bool isDisable, bool isEnable)
		{
			return isTrue && ((!isDisable && !isEnable) ||
			(isDisable && !IsKeyDown(Keys.ControlKey)) ||
			(isEnable && IsKeyDown(Keys.ControlKey)));
		}


		public static void Log(string str)
		{
			if (str is null) Log($"Log failed! {nameof(str)} is null.");
			Debug.WriteLine(str);
		}
		public static void Log(object obj)
		{
			if (obj is null) Log($"Log failed! {nameof(obj)} is null.");
			Log(obj.ToString());
		}
		#endregion
	}
}

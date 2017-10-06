using PTL.Model;
using PTL.View;
using PTL.ViewModel;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using static PTL.API;
using static PTL.MouseHook;

namespace PTL
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : System.Windows.Application
	{
		/// <summary>
		/// App data.
		/// </summary>
		public static Data d { get; set; }

		public static Settings st { get { return d.st; } }
		/// <summary>
		/// Taskbar Icon.
		/// </summary>
		public static NotifyIcon tbIcon { get; set; }
		public static MainWindow main { get; set; }
		public static OverlayWindow overlay { get; set; }
		public static FloatWindow floatWnd { get; set; }
		public static ConfirmWindow confirm { get; set; }
		public static MyWindow window { get; set; }
		/// <summary>
		/// Mouse Hook.
		/// </summary>
		public static MouseHook mh { get; set; }
		/// <summary>
		/// Keyboard Hook.
		/// </summary>
		public static KeyHook kh { get; set; }
		public static Task mt { get; set; }
		public static Task kt { get; set; }
		public static App app { get; set; }
		public static IntPtr hhook;
		/// <summary>
		/// A window application object that live all the time and can create/delete windows.
		/// </summary>
		public App()
		{
			app = this;
			Log("Start App");
			AppDomain.CurrentDomain.UnhandledException += (s, args) =>
			{
				Exception e = (Exception)args.ExceptionObject;
				API.Log($"Sender:  {s}");
				API.Log($"Message: {e.Message}");
				API.Log($"IsTerminating:   {args.IsTerminating}");
				API.Log($"ExceptionObject: {args.ExceptionObject}");
			};
			// Listen for name change changes across all processes/threads on current desktop...
			hhook = SetWinEventHook(EVENT_MIN,
				EVENT_MAX,
				IntPtr.Zero, procDelegate, 0, 0, WINEVENT_OUTOFCONTEXT);

			// MessageBox provides the necessary mesage loop that SetWinEventHook requires.
			// In real-world code, use a regular message loop (GetMessage/TranslateMessage/
			// DispatchMessage etc or equivalent.)
			Log("Tracking name changes on HWNDs, close message box to exit.");


		}
		#region test
		delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType,
		 IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr
			 hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess,
			 uint idThread, uint dwFlags);

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		static extern bool UnhookWinEvent(IntPtr hWinEventHook);

		// Need to ensure delegate is not collected while we're using it,
		// storing it in a class field is simplest way to do this.
		static WinEventDelegate procDelegate = new WinEventDelegate(WinEventProc);
		static void WinEventProc(IntPtr hWinEventHook, uint eventType,
		 IntPtr handle, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
		{
			// filter out non-HWND namechanges... (eg. items within a listbox)
			if (idObject != 0 || idChild != 0)
			{
				return;
			}
			string title = API.Get_Title(handle);
			if (d is null) return;
			st.IsDragging = false;
			if (title.Length != 4) return;
			if (title.Equals("Drag"))
				st.IsDragging = true;
		}
		[System.Runtime.InteropServices.DllImport("user32.dll", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
		public static extern IntPtr GetParent(IntPtr hWnd);

		const uint WINEVENT_OUTOFCONTEXT = 0x0000; // Events are ASYNC

		const uint WINEVENT_SKIPOWNTHREAD = 0x0001; // Don't call back for events on installer's thread

		const uint WINEVENT_SKIPOWNPROCESS = 0x0002; // Don't call back for events on installer's process

		const uint WINEVENT_INCONTEXT = 0x0004; // Events are SYNC, this causes your dll to be injected into every process

		const uint EVENT_MIN = 0x00000001;

		const uint EVENT_MAX = 0x7FFFFFFF;

		const uint EVENT_SYSTEM_SOUND = 0x0001;

		const uint EVENT_SYSTEM_ALERT = 0x0002;

		const uint EVENT_SYSTEM_FOREGROUND = 0x0003;

		const uint EVENT_SYSTEM_MENUSTART = 0x0004;

		const uint EVENT_SYSTEM_MENUEND = 0x0005;

		const uint EVENT_SYSTEM_MENUPOPUPSTART = 0x0006;

		const uint EVENT_SYSTEM_MENUPOPUPEND = 0x0007;

		const uint EVENT_SYSTEM_CAPTURESTART = 0x0008;

		const uint EVENT_SYSTEM_CAPTUREEND = 0x0009;

		const uint EVENT_SYSTEM_MOVESIZESTART = 0x000A;

		const uint EVENT_SYSTEM_MOVESIZEEND = 0x000B;

		const uint EVENT_SYSTEM_CONTEXTHELPSTART = 0x000C;

		const uint EVENT_SYSTEM_CONTEXTHELPEND = 0x000D;

		const uint EVENT_SYSTEM_DRAGDROPSTART = 0x000E;

		const uint EVENT_SYSTEM_DRAGDROPEND = 0x000F;

		const uint EVENT_SYSTEM_DIALOGSTART = 0x0010;

		const uint EVENT_SYSTEM_DIALOGEND = 0x0011;

		const uint EVENT_SYSTEM_SCROLLINGSTART = 0x0012;

		const uint EVENT_SYSTEM_SCROLLINGEND = 0x0013;

		const uint EVENT_SYSTEM_SWITCHSTART = 0x0014;

		const uint EVENT_SYSTEM_SWITCHEND = 0x0015;

		const uint EVENT_SYSTEM_MINIMIZESTART = 0x0016;

		const uint EVENT_SYSTEM_MINIMIZEEND = 0x0017;

		const uint EVENT_SYSTEM_DESKTOPSWITCH = 0x0020;

		const uint EVENT_SYSTEM_END = 0x00FF;

		const uint EVENT_OEM_DEFINED_START = 0x0101;

		const uint EVENT_OEM_DEFINED_END = 0x01FF;

		const uint EVENT_UIA_EVENTID_START = 0x4E00;

		const uint EVENT_UIA_EVENTID_END = 0x4EFF;

		const uint EVENT_UIA_PROPID_START = 0x7500;

		const uint EVENT_UIA_PROPID_END = 0x75FF;

		const uint EVENT_CONSOLE_CARET = 0x4001;

		const uint EVENT_CONSOLE_UPDATE_REGION = 0x4002;

		const uint EVENT_CONSOLE_UPDATE_SIMPLE = 0x4003;

		const uint EVENT_CONSOLE_UPDATE_SCROLL = 0x4004;

		const uint EVENT_CONSOLE_LAYOUT = 0x4005;

		const uint EVENT_CONSOLE_START_APPLICATION = 0x4006;

		const uint EVENT_CONSOLE_END_APPLICATION = 0x4007;

		const uint EVENT_CONSOLE_END = 0x40FF;

		const uint EVENT_OBJECT_CREATE = 0x8000; // hwnd ID idChild is created item

		const uint EVENT_OBJECT_DESTROY = 0x8001; // hwnd ID idChild is destroyed item

		const uint EVENT_OBJECT_SHOW = 0x8002; // hwnd ID idChild is shown item

		const uint EVENT_OBJECT_HIDE = 0x8003; // hwnd ID idChild is hidden item

		const uint EVENT_OBJECT_REORDER = 0x8004; // hwnd ID idChild is parent of zordering children

		const uint EVENT_OBJECT_FOCUS = 0x8005; // hwnd ID idChild is focused item

		const uint EVENT_OBJECT_SELECTION = 0x8006; // hwnd ID idChild is selected item (if only one), or idChild is OBJID_WINDOW if complex

		const uint EVENT_OBJECT_SELECTIONADD = 0x8007; // hwnd ID idChild is item added

		const uint EVENT_OBJECT_SELECTIONREMOVE = 0x8008; // hwnd ID idChild is item removed

		const uint EVENT_OBJECT_SELECTIONWITHIN = 0x8009; // hwnd ID idChild is parent of changed selected items

		const uint EVENT_OBJECT_STATECHANGE = 0x800A; // hwnd ID idChild is item w/ state change

		const uint EVENT_OBJECT_LOCATIONCHANGE = 0x800B; // hwnd ID idChild is moved/sized item

		const uint EVENT_OBJECT_NAMECHANGE = 0x800C; // hwnd ID idChild is item w/ name change

		const uint EVENT_OBJECT_DESCRIPTIONCHANGE = 0x800D; // hwnd ID idChild is item w/ desc change

		const uint EVENT_OBJECT_VALUECHANGE = 0x800E; // hwnd ID idChild is item w/ value change

		const uint EVENT_OBJECT_PARENTCHANGE = 0x800F; // hwnd ID idChild is item w/ new parent

		const uint EVENT_OBJECT_HELPCHANGE = 0x8010; // hwnd ID idChild is item w/ help change

		const uint EVENT_OBJECT_DEFACTIONCHANGE = 0x8011; // hwnd ID idChild is item w/ def action change

		const uint EVENT_OBJECT_ACCELERATORCHANGE = 0x8012; // hwnd ID idChild is item w/ keybd accel change

		const uint EVENT_OBJECT_INVOKED = 0x8013; // hwnd ID idChild is item invoked

		const uint EVENT_OBJECT_TEXTSELECTIONCHANGED = 0x8014; // hwnd ID idChild is item w? test selection change

		const uint EVENT_OBJECT_CONTENTSCROLLED = 0x8015;

		const uint EVENT_SYSTEM_ARRANGMENTPREVIEW = 0x8016;

		const uint EVENT_OBJECT_END = 0x80FF;

		const uint EVENT_AIA_START = 0xA000;

		const uint EVENT_AIA_END = 0xAFFF;
		#endregion
		/// <summary>
		/// Initialize all window, load settings, assign data context,
		/// start keyboard and mouse hook tasks.
		/// </summary>
		public static void SetupApp()
		{
			Log("SetupApp");
			Log("Initialize windows");
			overlay = new OverlayWindow();
			floatWnd = new FloatWindow();
			confirm = new ConfirmWindow();
			tbIcon = new NotifyIcon
			{
				Visible = true,
				ContextMenu = new ContextMenu(new MenuItem[] { new MenuItem(), new MenuItem() })
			};

			Log("Initialize hooks");
			mh = new MouseHook();
			kh = new KeyHook();

			Log("Initialize data");
			d = new Data();

			app.SetupNotifyIcon();

			window = new MyWindow();
			main.DataContext = overlay.DataContext =
			floatWnd.DataContext = confirm.DataContext = d;
			Log("Initialize event loops");
			mt = (new Task(OnLButtonDown));
			mt.Start();
			kt = (new Task(OnKeyDown));
			kt.Start();
			mh.LButtonUp += (esa) => { d.st.Counter++; };
		}
		public static void Add_BackgroundTaskAndHook(bool isOn)
		{
			if (isOn)
			{
				mh.UnHook();
				kh.UnHook();
				mh.Hook();
				kh.Hook();
			}
			else
			{
				mh.UnHook();
				kh.UnHook();
			}
		}


		/// <summary>
		/// Unhook, save settings, dispose windows and taskbar 
		/// icon, shutdown app.
		/// </summary>
		public static void CloseApp()
		{
			d.SaveData();
			_IsAlive = false;
			mt.Wait();
			kt.Wait();
			UnhookWinEvent(hhook);
			mh.UnHook();
			kh.UnHook();
			tbIcon.ContextMenu = null;
			tbIcon.Visible = false;
			app.Shutdown();
		}

		#region NotifyIcon

		/// <summary>
		/// This funtion had to be call after langue object 
		/// is loaded and before settings object's initialization.
		/// </summary>
		public void SetupNotifyIcon()
		{
			Log("SetupNotificationIcon()");
			tbIcon.BalloonTipTitle = d.l.App_Name;
			tbIcon.BalloonTipText = d.l.Icon_Intro;
			tbIcon.ShowBalloonTip(2000, d.l.App_Name, $"By {d.l.App_Name}", ToolTipIcon.Info);
			tbIcon.Click += (s, e) => { main.Visibility = main.IsVisible ? Visibility.Hidden : Visibility.Visible; };

			tbIcon.ContextMenu.MenuItems[0].Click += (s, e) => { d.st.IsOn = !d.st.IsOn; };
			tbIcon.ContextMenu.MenuItems[1].Text = d.l.Exit;
			tbIcon.ContextMenu.MenuItems[1].Click += (s, e) => { CloseApp(); };
		}

		/// <summary>
		/// Change taskbar icon when app is pause/resume.
		/// </summary>
		/// <param name="isOn"></param>
		public static void SwitchIcon(bool isOn)
		{
			if (d is null || d.l is null)
				return;
			if (isOn)
			{
				tbIcon.Icon = PTL.Properties.Resources.NotifyIcon_On;
				tbIcon.ContextMenu.MenuItems[0].Text = d.l.Running;
			}
			else
			{
				tbIcon.Icon = PTL.Properties.Resources.NotifyIcon_Off;
				tbIcon.ContextMenu.MenuItems[0].Text = d.l.Stop;
			}
			main.Icon = IconFromHandle(tbIcon.Icon.Handle);
			Log("Taskbar's icon changed");
		}
		/// <summary>
		/// Given an incon handler.<para/>
		/// Return a bitmap source image of the icon.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public static BitmapSource IconFromHandle(IntPtr handle)
		{
			return Imaging.CreateBitmapSourceFromHIcon(
			handle,
			Int32Rect.Empty,
			BitmapSizeOptions.FromEmptyOptions());
		}
		#endregion

		static bool _IsAlive = true;
		public static int Interval_Main = 50;
		public static int Interval_Numpad = 50;
		#region Background Tasks
		/// <summary>
		/// Background task that capture mouse 
		/// left click every interval ms.
		/// </summary>
		static async void OnLButtonDown()
		{
			while (_IsAlive)
			{
				try
				{
					if (!st.IsOn)
						await Task.Delay(2000);
					else
					{
						await Task.Delay(Interval_Main);
						window.LButtonClick();
					}
				}
				catch (Exception e) { API.Log(e); }
			}
		}
		/// <summary>
		/// Background task that capture hotkey 
		/// input every interval ms.
		/// </summary>
		static async void OnKeyDown()
		{
			while (_IsAlive)
			{
				try
				{
					if (!st.IsOn)
						await Task.Delay(2000);
					else
					{
						await Task.Delay(Interval_Numpad);
						window.ArrowKeyDown();
						window.NumpadKeyDown();
					}
				}
				catch (Exception e) { Log(e); }
			}
		}
		#endregion

		#region Low Level Mouse Hook
		/// <summary>
		/// Remove the event to prevent duplication then 
		/// add it again later if needed.
		/// </summary>
		/// <param name="isEnableEvent"></param>
		public static void Add_LButtonUp(bool isEnableEvent = false)
		{
			if (main.ViewID != 4) return;
			if (mh is null || d is null)
				return;
			Log("Remove LButtonUp");
			mh.LButtonUp -= _LButtonUp;
			st.IsCaptureWindowInfo = false;
			d.r.Rule = null;
			if (main is null ||
				!main.IsVisible ||
				!isEnableEvent)
				return;
			Log("Add LButtonUp");
			mh.LButtonUp += _LButtonUp;
			st.IsCaptureWindowInfo = true;
		}
		/// <summary>
		/// Capture window info when mouse click on window.
		/// </summary>
		/// <param name="Cursor"></param>
		static void _LButtonUp(MouseCursor Cursor)
		{
			if (GetForegroundWindow() == main.HWND)
				return;
			if (!Validate_Handle(window.Handle))
				return;

			d.r.Rule = d.r.Find(window);
			window.Extract(d.r.Rule);
			//Settings.CSVM.Setup.SelectedPart = new CornerPart(window._State);
			//if (App.RulesVM.RuleList.IndexOf(RuleViewModel.SelectedRule) >= 0) ;
		}

		/// <summary>
		/// Remove the event to prevent duplication then 
		/// add it again later if needed.
		/// </summary>
		/// <param name="isEnableEvent"></param>
		public static void Add_MouseWheel(bool isEnableEvent)
		{
			if (mh is null)
				return;
			Log("Removed MouseWheel");
			mh.MouseWheel -= _Wheel;
			if (!isEnableEvent)
				return;
			Log("Added MouseWheel");
			mh.MouseWheel += _Wheel;
		}

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern IntPtr WindowFromPoint(System.Drawing.Point p);
		const int WHEEL_UP = 7864320;
		static void _Wheel(MouseCursor Cursor)
		{
			try
			{
				// get the class name of the current window that mouse cursor is hovering over.
				string wnd_class = Get_Class(WindowFromPoint(Cursor.Position));

				// in case mouse cursor is hovering over window
				// taskbar which has the the class name bellow.
				if (wnd_class.Equals("ToolbarWindow32") ||
						wnd_class.Equals("MSTaskListWClass") &&
						st.IsScroll_Volume)
				{
					// scroll up
					if (Cursor.Data == WHEEL_UP)
					{
						for (int i = 0; i < st.Volume_Step; i++)
							SendMessage(overlay.HWND, 0x319, overlay.HWND, (IntPtr)0xA0000);
					}
					else
					// scroll down
					{
						for (int i = 0; i < st.Volume_Step; i++)
							SendMessage(overlay.HWND, 0x319, overlay.HWND, (IntPtr)0x90000);
					}
				}
				else
				// in case mouse wheel is scrolling while ShiftKey or RButton is down
				if (IsKeyDown(Keys.ShiftKey) && st.IsScroll_SwitchScreen)
				{
					Screen scr = window.Screen;
					Screen nextScr = (Cursor.Data == WHEEL_UP) ?
						window.Get_Next_Screen(true) : window.Get_Next_Screen(true, true);
					window.State = Get_State(window.Handle);
					window.State.X = nextScr.Bounds.Left + window.State.Left - scr.Bounds.Left;
					window.State.Y = nextScr.Bounds.Top + window.State.Top - scr.Bounds.Top;
					if (st.IsMoveToCursor)
					{
						window.Set_State(window.Handle, window.State, window.Screen,
							log: "Change position mouse wheel");
					}
				}
				else
				if (IsKeyDown(Keys.RButton) && st.IsScroll_AddWidth)
				{
					window._State = window.Get__State(Get_State(window.Handle), window.Size);
					// scroll up
					if (Cursor.Data == WHEEL_UP)
					{
						window._State.Width++;
					}
					else
					// scroll down
					{
						window._State.Width--;
					}
					window.Set_State(window.Handle, window._State, window.Screen, window.Flag, log: "Wheel");
				}
			}
			catch (Exception e) { Log("_MouseWheel error"); Log(e); }
		}

		/// <summary>
		/// Remove the event to prevent duplication then 
		/// add it again later if needed.
		/// </summary>
		/// <param name="isEnableEvent"></param>
		public static void Add_XButtonDown(bool isEnableEvent)
		{
			if (mh is null)
				return;
			Log("Remove XButtonDown");
			mh.XButtonDown -= _XButton;
			if (!isEnableEvent)
				return;
			mh.XButtonDown += _XButton;
			Log("Add XButtonDown");
		}
		/// <summary>
		/// Close or minimize window when mouse XButton is click.
		/// </summary>
		/// <param name="Cursor"></param>
		static void _XButton(MouseCursor Cursor)
		{
			try
			{
				if (Cursor.Data != X2BUTTIONDOWN)
					return;
				if (!CtrlCheck(st.IsXButton, st.IsXButton1, st.IsXButton2))
					return;
				window.Get_Info(Get_Handle(20));
				if (window.Flag.Equals(Flags.DoNothing))
					return;
				if (st.IsMinimize)
				{
					if (IsKeyDown(Keys.RButton))
					{
						IsShowConfirmForm(Cursor.Position);
					}
					else
					{
						if (Get_State(window.Handle).X != -32000)
							ShowWindow(window.Handle, SWC.Minimize);
						else
							ShowWindow(window._Handle, SWC.Show);
					}
				}
				else
				if (!IsShowConfirmForm(Cursor.Position))
				{
					window.Close();
				}
			}
			catch (Exception e) { Log(e); }
		}

		static bool IsShowConfirmForm(System.Drawing.Point CurPos)
		{
			if (st.IsConfirm)
			{
				if (st.IsDragPreview)
				{
					API.ShowWindow(overlay.HWND, API.SWC.Show);
					window.State = Get_State(window.Handle);
					API.SetWindowPos(overlay.HWND, window.State);
				}
				else
					API.ShowWindow(overlay.HWND, SWC.Hide);
				if (confirm is null)
				{
					confirm = new ConfirmWindow()
					{
						Visibility = Visibility.Visible,
						Left = CurPos.X - confirm.Width / 2 + 20,
						Top = CurPos.Y - confirm.Height + 20,
						Topmost = true
					};
				}
				else
				{
					confirm.Close();
					API.ShowWindow(overlay.HWND, SWC.Hide);
				}
			}
			return false;
		}
		#endregion
	}
}

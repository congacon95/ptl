using System;
using System.Collections.Generic;
using PTL.Model;
using System.Diagnostics;
using System.Windows;
using PTL.ViewModel.Utility;
using Newtonsoft.Json;

namespace PTL.ViewModel
{
	/// <summary>
	/// One big object that contain all Setting stuff.<para/>
	/// Boolean value start with 'Is'. Example: 'IsSomeThing'.<para/>
	/// Interger/Double/Float are word seperate by underscore character '_'.
	/// Example: 'Some_Field_Name'.
	/// </summary>
	public class Settings : BindableBase
	{
		/// <summary>
		/// Initialize new Settings object with default value.
		/// </summary>
		public Settings()
		{
			IsFinishLoaded = false;
			API.Log("new Settings.");
			IsOn =
			IsTopmost =
			IsStartWithWindow =
			IsAutoHide =
			IsAppearance =
			IsSupport =
			IsCorner =
			IsDrag =
			IsDragPreview =
			IsCornerPreview =
			IsScroll_Volume =
			IsScroll_AddWidth =
			IsScroll_SwitchScreen =
			IsTitle =
			IsBorder =
			IsHideFullScreenAppBorder =
			IsBottom =
			IsMoveToCursor =
			IsNumpad =
			IsArrowKey =
			IsXButton =
			IsFormat =
			IsMoveToCursorKeep_State =
			IsMoveToCursor_Taskbar =
			IsBlurMain =
			IsBlurOverlay =
			IsMergeScreen =
			IsCaptureWindowInfo =
			true;
			IsRememberState =
			IsConfirm =
			false;

			Volume_Step = VOLUME_STEP;
			Corner_Distance = CORNER_DISTANCE;
			Corner_Sensitive = CORNER_SENSITIVE;
			Interval_Numpad = INTERVAL_NUMPAD;
			Interval_Main = INTERVAL_MAIN;
			Opacity_Main = OPACITY_MAIN;
			Opacity_Menu = OPACITY_MENU;
			Opacity_Overlay = OPACITY_OVERLAY;
			Border_Overlay = BORDER_OVERLAY;
			Drag_Distance = DRAG_DISTANCE;
			Size_Top = SIZE_TOP;
			Size_Border = SIZE_BORDER;
			Size_App_Top = SIZE_APP_TOP;
			Size_Bottom = SIZE_BOTTOM;
			Size_Grid = SIZE_GRID;
			AddedX =
			AddedY =
			AddedWidth =
			AddedHeight = 1;

			IsFinishLoaded = true;
		}
		#region NAVIGATION BAR
		[JsonIgnore]
		public CMD EXIT { get; set; } = new CMD((p) =>
		{
			App.CloseApp();
		});
		[JsonIgnore]
		public CMD MINIMIZE { get; set; } = new CMD((p) =>
		{
			App.main.Visibility = Visibility.Hidden;
		});
		[JsonIgnore]
		public CMD RESIZE { get; set; } = new CMD((p) =>
		{
			var screen = MyWindow.Screen_Cursor.WorkingArea;
			App.main.Width = screen.Width > 1920 ? screen.Width * 3 / 16 : 360;
			App.main.Height = screen.Height;
			App.main.Top = screen.Top;
			App.main.Left = screen.Right - App.main.Width;
		});
		#endregion
		#region  GENERAL SETTINGS
		public bool IsOn
		{
			get { return Get<bool>(); }
			set
			{
				Set(value);
				App.SwitchIcon(value);
				App.Add_BackgroundTaskAndHook(value);
				App.Add_MouseWheel(value && IsScroll_Volume);
				App.Add_XButtonDown(value && IsXButton);
				App.Add_LButtonUp(value);
			}
		}
		public bool IsTopmost
		{
			get { return Get<bool>(); }
			set
			{
				Set(value);
				App.main.Topmost = value;
			}
		}
		public bool IsDragging { get { return Get<bool>(); } set { Set(value); } }

		public bool IsStartWithWindow { get { return Get<bool>(); } set { Set(value); } }
		public bool IsAutoHide { get { return Get<bool>(); } set { Set(value); } }
		public bool IsStickyMainWindow
		{
			get { return Get<bool>(); }
			set
			{
				Set(value);
				if (value && RESIZE != null)
					RESIZE.Execute(null);
			}
		}

		public int Interval_Main
		{
			get { return Get<int>(); }
			set
			{
				Set(value);
				App.Interval_Main = value * 10;
			}
		}

		[JsonIgnore]
		const int INTERVAL_MAIN = 5;
		[JsonIgnore]
		public CMD RESET_INTERVAL_MAIN { get; set; } = new CMD((p) =>
		{
			App.st.Interval_Main = INTERVAL_MAIN; // multiply factor: 10
		});
		#endregion
		#region APPEARANCE
		public int ID_FloatPos { get { return Get<int>(); } set { Set(value); } }
		public bool IsAppearance { get { return Get<bool>(); } set { Set(value); } }
		public bool IsBlurMain
		{
			get { return Get<bool>(); }
			set
			{
				Set(value);
				BlurWindow.Blur(App.main, value);
			}
		}
		public bool IsBlurOverlay
		{
			get { return Get<bool>(); }
			set
			{
				Set(value);
				BlurWindow.Blur(App.overlay, value);
			}
		}
		public bool IsBlurFloat
		{
			get { return Get<bool>(); }
			set
			{
				Set(value);
				BlurWindow.Blur(App.floatWnd, value);
			}
		}

		public double Opacity_Main { get { return Get<double>(); } set { Set(value); } }
		public double Opacity_Menu { get { return Get<double>(); } set { Set(value); } }
		public double Opacity_Overlay { get { return Get<double>(); } set { Set(value); } }
		public int Border_Overlay
		{
			get { return Get<int>(); }
			set
			{
				Set(value);
				IsEnableMouseDragBorder = value != 0;
			}
		}

		[JsonIgnore]
		const double OPACITY_MAIN = 0.8;
		[JsonIgnore]
		const double OPACITY_MENU = 0.7;
		[JsonIgnore]
		const double OPACITY_OVERLAY = 0.6;
		[JsonIgnore]
		const int BORDER_OVERLAY = 1;

		[JsonIgnore]
		public CMD RESET_OPACITY_MAIN { get; set; } = new CMD((p) =>
		{
			App.st.Opacity_Main = OPACITY_MAIN;
		});
		[JsonIgnore]
		public CMD RESET_OPACITY_MENU { get; set; } = new CMD((p) =>
		{
			App.st.Opacity_Menu = OPACITY_MENU;
		});
		[JsonIgnore]
		public CMD RESET_OPACITY_OVERLAY { get; set; } = new CMD((p) =>
		{
			App.st.Opacity_Overlay = OPACITY_OVERLAY;
		});
		[JsonIgnore]
		public CMD RESET_BORDER_OVERLAY { get; set; } = new CMD((p) =>
		{
			App.st.Border_Overlay = BORDER_OVERLAY;
		});
		#endregion
		#region MOUSE
		public bool IsCorner { get { return Get<bool>(); } set { Set(value); } }
		public int Corner_Distance
		{
			get { return Get<int>(); }
			set
			{
				Set(value);
			}
		}
		public int Corner_Sensitive { get { return Get<int>(); } set { Set(value); } }

		public bool IsDrag { get { return Get<bool>(); } set { Set(value); } }
		public bool IsDragPreview { get { return Get<bool>(); } set { Set(value); } }
		public bool IsCornerPreview { get { return Get<bool>(); } set { Set(value); } }

		public bool IsScroll_SwitchScreen { get { return Get<bool>(); } set { Set(value); } }

		public bool IsScroll_AddWidth { get { return Get<bool>(); } set { Set(value); } }

		public int Drag_Distance { get { return Get<int>(); } set { Set(value); } }

		public bool IsScroll_Volume
		{
			get { return Get<bool>(); }
			set
			{
				Set(value);
				App.Add_MouseWheel(IsOn && value);
			}
		}
		public int Volume_Step { get { return Get<int>(); } set { Set(value); } }

		public bool IsXButton
		{
			get { return Get<bool>(); }
			set
			{
				Set(value);
				App.Add_XButtonDown(IsOn && value);
			}
		}
		public bool IsMinimize { get { return Get<bool>(); } set { Set(value); } }
		public bool IsConfirm { get { return Get<bool>(); } set { Set(value); } }
		[JsonIgnore]
		const int CORNER_DISTANCE = 22;
		[JsonIgnore]
		const int CORNER_SENSITIVE = 6;
		[JsonIgnore]
		const int DRAG_DISTANCE = 0;
		[JsonIgnore]
		const int VOLUME_STEP = 1;
		[JsonIgnore]
		public CMD RESET_CORNER_DISTANCE { get; set; } = new CMD((p) =>
		{
			App.st.Corner_Distance = CORNER_DISTANCE;
		});
		[JsonIgnore]
		public CMD RESET_CORNER_SENSITIVE { get; set; } = new CMD((p) =>
		{
			App.st.Corner_Sensitive = CORNER_SENSITIVE; //multiply factor: 10
		});
		[JsonIgnore]
		public CMD RESET_DRAG_DISTANCE { get; set; } = new CMD((p) =>
		{
			App.st.Drag_Distance = DRAG_DISTANCE;
		});
		[JsonIgnore]
		public CMD RESET_VOLUME_STEP { get; set; } = new CMD((p) =>
		{
			App.st.Volume_Step = VOLUME_STEP;
		});
		#endregion
		#region WINDOW'S INFOMATION
		public bool IsTitle
		{
			get { return Get<bool>(); }
			set
			{
				Set(value);
				if (value)
				{
					Size_Top = SIZE_TOP;
					Size_App_Top = SIZE_APP_TOP;
				}
				else
				{
					Size_Top = 0;
					Size_App_Top = 0;
				}
			}
		}
		public int Size_Top
		{
			get
			{
				return Get<int>() + SIZE_TOP;
			}
			set
			{
				Set(value - SIZE_TOP);
				OnPropertyChanged(nameof(UI_TitleSize));
				OnPropertyChanged(nameof(UI_TitleSize_Margin));
			}
		}
		public int Size_App_Top { get { return Get<int>(); } set { Set(value); } }

		public bool IsBorder
		{
			get { return Get<bool>(); }
			set
			{
				Set(value);
				Size_Border = value ? SIZE_BORDER : 0;
			}
		}
		public int Size_Border
		{
			get { return Get<int>() + SIZE_BORDER; }
			set { Set(value - SIZE_BORDER); }
		}
		public bool IsHideFullScreenAppBorder { get { return Get<bool>(); } set { Set(value); } }

		public bool IsBottom
		{
			get { return Get<bool>(); }
			set
			{
				Set(value);
				Size_Bottom = value ? SIZE_BOTTOM : 0;
			}
		}
		public int Size_Bottom { get { return Get<int>(); } set { Set(value); } }

		[JsonIgnore]
		const int SIZE_BOTTOM = 0;
		[JsonIgnore]
		const int SIZE_APP_TOP = 31;
		[JsonIgnore]
		int SIZE_TOP { get { return (API.GetSystemMetrics(29) - SIZE_APP_TOP) / 2 + 26; } }
		[JsonIgnore]
		int SIZE_BORDER { get { return API.GetSystemMetrics(32) + API.GetSystemMetrics(92) - 1; } }
		[JsonIgnore]
		int UI_TitleSize { get { return Size_Top / 3 + 90; } }
		[JsonIgnore]
		Thickness UI_TitleSize_Margin { get { return new Thickness(0, -UI_TitleSize + 90, 0, 0); } }

		[JsonIgnore]
		public CMD RESET_SIZE_TOP { get; set; } = new CMD((p) =>
		{
			App.st.Size_Top = App.st.SIZE_TOP;
		});
		[JsonIgnore]
		public CMD RESET_SIZE_APP_TOP { get; set; } = new CMD((p) =>
		{
			App.st.Size_App_Top = SIZE_APP_TOP;
		});
		[JsonIgnore]
		public CMD RESET_SIZE_BORDER { get; set; } = new CMD((p) =>
		{
			App.st.Size_Border = App.st.SIZE_BORDER;
		});
		[JsonIgnore]
		public CMD RESET_SIZE_BOTTOM { get; set; } = new CMD((p) =>
		{
			App.st.Size_Bottom = SIZE_BOTTOM;
		});


		[JsonIgnore]
		const string REG_EXE = "regedit.exe";
		[JsonIgnore]
		const string REG_BORDER_NORMAL = @"REG\BD_NORMAL.reg";
		[JsonIgnore]
		const string REG_BORDER_THIN = @"REG\BD_THIN.reg";
		[JsonIgnore]
		const string REG_SCROLLBAR_NORMAL = @"REG\SB_NORMAL.reg";
		[JsonIgnore]
		const string REG_SCROLLBAR_THIN = @"REG\SB_THIN.reg";

		[JsonIgnore]
		public CMD SCROLLBAR_NORMAL { get; set; } = new CMD((p) =>
		{
			REG_EDIT(REG_SCROLLBAR_NORMAL);
		});
		[JsonIgnore]
		public CMD SCROLLBAR_THIN { get; set; } = new CMD((p) =>
		{
			REG_EDIT(REG_SCROLLBAR_THIN);
		});
		[JsonIgnore]
		public CMD BORDER_NORMAL { get; set; } = new CMD((p) =>
		{
			REG_EDIT(REG_BORDER_NORMAL);
		});
		[JsonIgnore]
		public CMD BORDER_THIN { get; set; } = new CMD((p) =>
		{
			REG_EDIT(REG_BORDER_THIN);
		});
		[JsonIgnore]
		public CMD LAUNCH_URL { get; set; } = new CMD((p) =>
		{
			Process.Start(p.ToString());
		});
		public static void REG_EDIT(string path)
		{
			Process.Start(REG_EXE, API.Get_Full_Path(path)).WaitForExit();
		}
		#endregion
		#region DISPLAYS

		public bool IsMergeScreen { get { return Get<bool>(); } set { Set(value); } }
		public bool IsMoveToCursor { get { return Get<bool>(); } set { Set(value); } }
		public bool IsMoveToCursorKeep_State { get { return Get<bool>(); } set { Set(value); } }
		public bool IsMoveToCursor_Taskbar { get { return Get<bool>(); } set { Set(value); } }
		public bool IsFormat { get { return Get<bool>(); } set { Set(value); } }
		public bool IsCaptureWindowInfo { get { return Get<bool>(); } set { Set(value); } }
		#endregion
		#region NUMPAD
		public bool IsNumpad { get { return Get<bool>(); } set { Set(value); } }
		public int Interval_Numpad
		{
			get { return Get<int>(); }
			set
			{
				Set(value);
				App.Interval_Numpad = value * 20;
			}
		}
		public int AddedWidth { get { return Get<int>(); } set { Set(value); } }
		public int AddedHeight { get { return Get<int>(); } set { Set(value); } }
		public bool IsNumpadSwitchScreen { get { return Get<bool>(); } set { Set(value); } }
		public bool IsNumpadBlockInput { get { return Get<bool>(); } set { Set(value); } }
		public bool IsNumpadCtrlToDisable { get { return Get<bool>(); } set { Set(value); if (value) IsNumpadCtrlToEnable = false; } }
		public bool IsNumpadCtrlToEnable { get { return Get<bool>(); } set { Set(value); if (value) IsNumpadCtrlToDisable = false; } }

		[JsonIgnore]
		const int INTERVAL_NUMPAD = 10;
		[JsonIgnore]
		public CMD RESET_INTERVAL_NUMPAD { get; set; } = new CMD((p) =>
		{
			App.st.Interval_Numpad = INTERVAL_NUMPAD;
		});
		#region ARROW KEY

		public bool IsArrowKey { get { return Get<bool>(); } set { Set(value); } }
		public int AddedX { get { return Get<int>(); } set { Set(value); } }
		public int AddedY { get { return Get<int>(); } set { Set(value); } }
		public bool IsArrowBlockInput { get { return Get<bool>(); } set { Set(value); } }

		public bool IsArrowCtrlToDisable { get { return Get<bool>(); } set { Set(value); if (IsArrowCtrlToDisable) IsArrowCtrlToEnable = false; } }
		public bool IsArrowCtrlToEnable { get { return Get<bool>(); } set { Set(value); if (IsArrowCtrlToEnable) IsArrowCtrlToDisable = false; } }
		#endregion

		#endregion
		#region Const
		const int SIZE_GRID = 48;


		#endregion
		#region Commands
		[JsonIgnore]
		public CMD cmd_Reset_FrameGrid { get; set; } = new CMD((p) =>
		{
			App.st.Size_Grid = SIZE_GRID;
		});
		#endregion
		#region Booleans
		public bool IsSupport { get { return Get<bool>(); } set { Set(value); } }

		public bool IsRememberState { get { return Get<bool>(); } set { Set(value); } }
		public bool IsFinishLoaded { get { return Get<bool>(); } set { Set(value); } }
		public bool IsShowFloatWindow
		{
			get { return Get<bool>(); }
			set
			{
				Set(value);
				if (App.floatWnd is null)
					return;
				API.ShowWindow(App.floatWnd.HWND, value ? API.SWC.Hide : API.SWC.Show);
			}
		}
		public bool IsXButton1 { get { return Get<bool>(); } set { Set(value); if (IsXButton1) IsXButton2 = false; } }
		public bool IsXButton2 { get { return Get<bool>(); } set { Set(value); if (IsXButton2) IsXButton1 = false; } }
		public bool IsMoveToCursor1 { get { return Get<bool>(); } set { Set(value); if (IsMoveToCursor1) IsMoveToCursor2 = false; } }
		public bool IsMoveToCursor2 { get { return Get<bool>(); } set { Set(value); if (IsMoveToCursor2) IsMoveToCursor1 = false; } }
		public bool IsTitle1 { get { return Get<bool>(); } set { Set(value); } }
		public bool IsTitle2 { get { return Get<bool>(); } set { Set(value); } }
		public bool IsMouseDrag1 { get { return Get<bool>(); } set { Set(value); if (IsMouseDrag1) IsMouseDrag2 = false; } }
		public bool IsMouseDrag2 { get { return Get<bool>(); } set { Set(value); if (IsMouseDrag2) IsMouseDrag1 = false; } }
		public bool IsMouseCorner1 { get { return Get<bool>(); } set { Set(value); if (IsMouseCorner1) IsMouseCorner2 = false; } }
		public bool IsMouseCorner2 { get { return Get<bool>(); } set { Set(value); if (IsMouseCorner2) IsMouseCorner1 = false; } }
		public bool IsRememberState1 { get { return Get<bool>(); } set { Set(value); } }
		public bool IsRememberState2 { get { return Get<bool>(); } set { Set(value); } }
		public bool IsRememberState3 { get { return Get<bool>(); } set { Set(value); } }
		public bool IsRememberState4 { get { return Get<bool>(); } set { Set(value); } }
		public bool IsRememberState5 { get { return Get<bool>(); } set { Set(value); } }
		public bool IsEnableAnimation { get { return Get<bool>(); } set { Set(value); } }
		public bool IsOverlayOpen { get { return Get<bool>(); } set { Set(value); } }
		#endregion

		#region Ints
		public int Size_Grid
		{
			get
			{
				int i = Get<int>();
				return i == 0 ? SIZE_GRID : i;
			}
			set
			{
				Set(value == 0 ? SIZE_GRID : value);
			}
		}
		public int Counter
		{
			get { return Get<int>(); }
			set
			{
				Set(value);
				if (value == 0)
					API.Log("reset counter");
			}
		}

		public bool IsEnableMouseDragBorder
		{
			get { return Get<bool>(); }
			set
			{
				if (!Set(value))
					return;
				Border_Overlay = value ? 1 : 0;
			}
		}

		public int LoadTime { get { return Get<int>(); } set { Set(value); } }
		public int ExitTime { get { return Get<int>(); } set { Set(value); } }
		#endregion

		public List<MyWindow> WindowData { get { return Get<List<MyWindow>>(); } set { Set(value); } }
		public bool AddWindow(String s, MyWindow _Wnd, bool chb_IsRememberState)
		{
			if (_Wnd.ID == -2 || !chb_IsRememberState)
				return false;

			if (_Wnd.ID == -1)
			{
				if (_Wnd.Title.Length < 1 ||
				_Wnd.Class.Length < 1 ||
				_Wnd.State.Width < 200 ||
				_Wnd.State.Height < 200)
					return false;
				WindowData.Add(_Wnd);
				API.Log("Window Added From " + s);
				return true;
			}

			WindowData[App.window.ID]._State = _Wnd._State;
			API.Log("Window State Changed From " + s);
			return false;
		}


	}
}

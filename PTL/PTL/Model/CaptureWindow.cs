using PTL.ViewModel;
using System;
using System.Drawing;
using System.Windows.Forms;
using static PTL.API;
using static PTL.App;

namespace PTL.Model
{

	public class MyWindow
	{
		public IntPtr Handle { get; private set; } = IntPtr.Zero;
		public IntPtr _Handle { get; private set; } = IntPtr.Zero;
		public string Title { get; private set; } = "";
		public string Class { get; private set; } = "";
		public string Process { get; private set; } = "";
		public Rectangle State = new Rectangle(),
										_State = new Rectangle();
		public Rule Rule { get; private set; } = null;
		public HideArea Size { get; private set; } = new HideArea();
		public Flags Flag { get; private set; } = Flags.AsynchronousWindowPosition;
		public int ID { get; private set; } = -1;

		public MyWindow()
		{
			Handle = _Handle = GetForegroundWindow();
		}
		public override string ToString()
		{
			return $"Get Window Info: \n\tHWND:\t{Handle}\n\tbdSize:{Size.Border}\n" +
						$"\tttSize:{Size.Top}\n\tbtSize:{Size.Bottom}\n\tTitle:\t{Title}\n" +
						$"\tClass:\t{Class}\n\tFName:\t{Process}.exe\n\tFlag:\t{Flag}\n" +
						$"\tID:  \t{ID}/{st.WindowData.Capacity}\n\t_State:\t{_State.ToString()}\n" +
						$"\tState:\t{State.ToString()}\n\tCurScr:\t{Screen.WorkingArea.ToString()}";
		}

		/// <summary>
		/// Screen from window's handle.
		/// </summary>
		public Screen Screen { get { return Screen.FromHandle(Handle); } }
		public static Screen Screen_Cursor
		{
			get { return Screen.FromPoint(Cursor.Position); }
		}

		public void Get_Info(IntPtr handle)
		{
			Title = Get_Title(handle);
			Class = Get_Class(handle);
			Process = Get_Process_Name(handle);
			Log($"\t Process: {Process}.exe - {Title}");

			Rule = d.r.Find(this);
			Extract(Rule);
			Check_Flag(State);
		}
		public void Extract(Rule rule)
		{
			Title = rule.Title.B ? rule.Title.V : Title;
			Class = rule.Class.B ? rule.Class.V : Class;
			Process = rule.Process.B ? rule.Process.V : Process;
			Size.Top = rule.Top.B ? rule.Top.V :
				Process.Equals("ApplicationFrameHost") ? st.Size_App_Top : st.Size_Top;
			Size.Border = rule.Border.B ? rule.Border.V : st.Size_Border;
			Size.Bottom = rule.Bottom.B ? rule.Bottom.V : st.Size_Bottom;
			State = rule.State.B ? rule.State.V.ToRect() : Get_State(Handle);
			_State = rule._State.B ? rule._State.V.ToRect() : Get__State(State, Size);
			Flag = rule.IsIgnore ? Flags.DoNothing :
										rule.IsNoResize ? Flags.IgnoreResize :
										Flags.AsynchronousWindowPosition;
		}
		void Check_Flag(Rectangle state)
		{
			if (state.Width == Screen.Bounds.Width &&
					state.Height == Screen.Bounds.Height)
				Flag = Flags.DoNothing;
		}

		public bool Get_Window_Info(bool isHandle, bool isMoveToCursor)
		{
			Handle = isHandle ? Get_Handle(20) : GetForegroundWindow();
			if (!Validate_Handle(Handle))
			{
				Handle = _Handle;
				return false;
			}
			if (!_Handle.Equals(Handle))
			{
				Get_Info(Handle);

				if (!Apply(Rule))
					if (isMoveToCursor)
						Move_To_Cursor();
				Format_State();
				_Handle = Handle;
				Show_Float_Button(State);
			}
			return true;
		}

		bool Apply(Rule rule)
		{
			if (Rule._State.B)
				return Set_State(Handle, Rule._State.V.ToRect(), Screen, log: "Apply Rule._State");
			else
			if (Rule.State.B)
				return Set_State(Handle, Rule.State.V.ToRect(), Screen, log: "Apply Rule.State");
			//else
			//if (ID != -1 && st.IsRememberState)
			//	ShowWindow(nameof(st.IsRememberState), st.WindowData[ID].State);
			return false;
		}

		bool Format_State(int threshold = 2)
		{
			if (!st.IsFormat) return false;
			var _state = new Rectangle(_State.Location, _State.Size);
			if (_state.Height > st.Size_Grid - threshold)
				_state.Height = st.Size_Grid;
			if (_state.Width > st.Size_Grid - threshold)
				_state.Width = st.Size_Grid;

			if (_state.Left < threshold)
				_state.X = 0;
			else
			if (_state.Right > st.Size_Grid - threshold)
				_state.X = st.Size_Grid - _state.Width;

			if (_state.Y < threshold)
				_state.Y = 0;
			else
			if (_state.Bottom > st.Size_Grid - threshold)
				_state.Y = st.Size_Grid - _state.Height;

			if (_State.Equals(_state))
				return false;
			_State = _state;
			return Set_State(Handle, _State, Screen, log: $"Format State to: {_State}");
		}
		/// <summary>
		/// Move current window to the screen where mouse click on its taskbar icon.
		/// </summary>
		bool Move_To_Cursor()
		{
			// check whether this feature setting is enable or not
			if (!CtrlCheck(st.IsMoveToCursor,
				st.IsMoveToCursor1, st.IsMoveToCursor2))
				return false;

			// return false if mouse cursor is on the 
			// same screen where the current foreground window is located.
			if (Screen.DeviceName.Equals(Screen_Cursor.DeviceName))
				return false;
			// return false if mouse cursor is not inside the taskbar region
			if (Screen_Cursor.WorkingArea.Contains(Cursor.Position))
				return false;
			// return false if the window has been minimized
			if (Get_State(_Handle).Height < 100)
				return false;

			if (st.IsMoveToCursorKeep_State)
			{
				_State = Get__State(State, Size);
				Set_State(Handle, _State, Screen_Cursor, log: "Move window to cursor keep relative state");
			}
			else
			{
				State.X = Screen_Cursor.Bounds.Left - Screen.Bounds.Left + State.Left;
				State.Y = Screen_Cursor.Bounds.Top - Screen.Bounds.Top + State.Top;
				Set_State(Handle, _State, Screen, log: "Move window to cursor only");
			}
			//if (IsRememberState5)
			//	AddWindow("MoveToCursor", Wnd, IsRememberState);
			//API.Log("\tTo: " + State);
			return true;
		}

		//bool Move_To_Taskbar_Icon()
		//{
		//	if (!st.IsMoveToCursor_Taskbar)
		//		return false;
		//	if (_State.Height != st.Size_Grid)
		//		return false;
		//	if (_State.Width != st.Size_Grid / 3)
		//		return false;
		//	var cursorPos = Cursor.Position;
		//	var currentScr = Screen.FromPoint(cursorPos);
		//	if (!currentScr.WorkingArea.Contains(cursorPos))
		//		return false;

		//	_State.X = (int)((cursorPos.X - currentScr.WorkingArea.Left)
		//	* st.Size_Grid / (double)currentScr.WorkingArea.Width);
		//	_State.X = CheckInt(_State.X);
		//	_State.Y = (int)((cursorPos.Y - currentScr.WorkingArea.Top)
		//	* st.Size_Grid / (double)currentScr.WorkingArea.Height);
		//	_State.Y = CheckInt(_State.Y);
		//	ShowWindow_State("MoveToTaskbarIcon", true, _State);
		//	return true;
		//}
		//int CheckInt(int x)
		//{
		//	return (int)((x < st.Size_Grid / 3f) ? 0 :
		//			(x > st.Size_Grid * 2 / 3f) ? st.Size_Grid :
		//			(st.Size_Grid - _State.Width) / 2f);
		//}

		/// <summary>
		/// Get window's _State relative to the screen
		/// that contains current window.
		/// </summary>
		public Rectangle Get__State(Rectangle rawState, HideArea size)
		{
			Rectangle _state = rawState.Trim(-size.Top, -size.Border, -size.Bottom);
			Rectangle screen = Screen.WorkingArea;
			return new Rectangle(
				(int)Math.Round((_state.Left - screen.Left) * st.Size_Grid / (double)screen.Width),
				(int)Math.Round((_state.Top - screen.Top) * st.Size_Grid / (double)screen.Height),
				(int)Math.Round(_state.Width * st.Size_Grid / (double)screen.Width),
				(int)Math.Round(_state.Height * st.Size_Grid / (double)screen.Height));
		}

		/// <summary>
		/// Given a relative state, screen size and useless area size.<para/>
		/// Return a new calculated in pixel of window's postion and size.
		/// </summary>
		/// <param name="_state"></param>
		/// <param name="screen"></param>
		/// <param name="size"></param>
		/// <returns></returns>
		Rectangle Calc_State(Rectangle _state, Rectangle screen, HideArea size)
		{
			Rectangle state = State;
			if (Flag.Equals(Flags.IgnoreResize))
			{
				state = Get_State(Handle);
				state.Location = screen.Calc_Pos(_state);
				return state;
			}

			//if (Rule._State.B)
			//{
			//	_state					= Rule._State.V.ToRect();
			//	state.Size			= screen.Calc_Size(_state);
			//	state.Location	= screen.Calc_Pos(_state);
			//	return state.Trim(size);
			//}
			//if (Rule.State.B)
			//{
			//	return Rule.State.V.ToRect();
			//}

			if (_state.Width > 2 &&
					_state.Height > 2)
			{
				state.Size = screen.Calc_Size(_state);
				state.Location = screen.Calc_Pos(_state);
				state = state.Trim(size);
			}
			else
			{
				state.Location = screen.Calc_Pos(_state);
			}
			return state;
		}

		public Screen Get_Next_Screen(bool isNextScreen, bool isReverse = false)
		{
			if (!isNextScreen)
				return Screen;
			for (int i = 0; i < Screen.AllScreens.Length; i++)
			{
				if (Screen.AllScreens[i].Equals(Screen))
				{
					if (i == Screen.AllScreens.Length - 1 && !isReverse)
						return Screen.AllScreens[0];
					else
					if (i == 0 && isReverse)
						return Screen.AllScreens[Screen.AllScreens.Length - 1];
					else
						return Screen.AllScreens[i -1];
				}
			}
			return Screen.AllScreens[0];
		}


		int Show_Float_Button(Rectangle state)
		{
			if (!st.IsShowFloatWindow)
			{
				API.ShowWindow(floatWnd.HWND, SWC.Hide);
				return -1;
			}
			if (Handle == floatWnd.HWND)
				return -2;
			if (Handle == IntPtr.Zero)
				return -3;
			if (st.IsOverlayOpen)
				return -4;
			if (Rule.IsIgnore)
				return -5;

			int left = 0;
			int top = 0;
			var scr = Screen.WorkingArea;
			switch (st.ID_FloatPos)
			{
				case 0:
					left = state.Left < scr.Left ? scr.Left : state.Left;
					top = state.Top < scr.Top ? scr.Top : state.Top;
					break;
				case 1:
					left = state.Right > scr.Right ? scr.Right : state.Right;
					left -= 44;
					top = state.Top < scr.Top ? scr.Top : state.Top;
					break;
				case 2:
					left = state.Left < scr.Left ? scr.Left : state.Left;
					top = state.Bottom > scr.Bottom ? scr.Bottom : state.Bottom;
					top -= 40;
					break;
				case 3:
					left = state.Right > scr.Right ? scr.Right : state.Right;
					left -= 44;
					top = state.Bottom > scr.Bottom ? scr.Bottom : state.Bottom;
					top -= 40;
					break;
			}
			API.ShowWindow(floatWnd.HWND, API.SWC.Show);
			SetWindowPos(floatWnd.HWND, IntPtr.Zero, left, top, 40, 40, Flags.AsynchronousWindowPosition);
			return 1;
		}

		public static Rectangle Check_Bound(Rectangle state, Rectangle screen, HideArea size)
		{
			screen = screen.Trim(size);
			if (state.Width > screen.Width) state.Width = screen.Width;
			if (state.Height > screen.Height) state.Height = screen.Height;

			if (state.Left < screen.Left) state.X = screen.Left;
			else
			if (state.Right > screen.Right) state.X = screen.Right - state.Width;

			if (state.Top < screen.Top ||
					state.Height > screen.Height) state.Y = screen.Top;
			else
			if (state.Bottom > screen.Bottom) state.Y = screen.Bottom - state.Height;

			if (state.Width >= screen.Width &&
					state.Height >= screen.Height &&
					st.IsHideFullScreenAppBorder)
			{
				state.Y--;
				state.X--;
				state.Height += 2;
				state.Width += 2;
				//if (st.IsMergeScreen)
				//{
				//    state.Width = _Rule.Real.State.MaximumWidth + 2 * Size.Border;
				//    state.Height = _Rule.Real.State.MaximumHeight + Size.Top + Size.Bottom;
				//    state.X = screen.Left - Size.Border;
				//    state.Y = screen.Top - Size.Top;
				//}
			}
			return state;
		}
		public bool ShowWindow(String sender, bool controler,
		IntPtr hwnd, Rectangle newState, Screen screen, HideArea size, Flags flag)
		{
			if (!controler)
				return false;
			if (newState.Width < 100 ||
				newState.Height < 200 ||
				flag.Equals(Flags.DoNothing))
				return false;

			newState = Check_Bound(newState, screen.WorkingArea, size);
			State = Get_State(hwnd);
			if (State == newState)
				return false;

			if (flag.Equals(Flags.IgnoreResize))
			{
				State.X = newState.X;
				State.Y = newState.Y;
			}
			else
				State = newState;

			SetWindowPos(hwnd, State);

			Show_Float_Button(State);
			return true;
		}

		public bool ShowWindow_State(String sender, bool _Controler,
			IntPtr _HWND, Rectangle _state, Screen screen, HideArea Size, Flags _Flag)
		{
			return ShowWindow(sender, _Controler,
			_HWND, Calc_State(_state, screen.WorkingArea, Size), screen, Size, _Flag);
		}



		public bool Set_State(IntPtr handle, Rectangle state,
					Screen screen, Flags flag = Flags.AsynchronousWindowPosition,
					string log = null)
		{
			Log(log);
			if (flag.Equals(Flags.AsynchronousWindowPosition))
				flag = Flag;
			if (flag.Equals(Flags.DoNothing))
				return false;
			// state is _State
			if (state.Width <= st.Size_Grid &&
					state.Height <= st.Size_Grid)
			{
				state = Calc_State(state, screen.WorkingArea, Size);
			}
			if (state.Width < 100 ||
					state.Height < 200)
				return false;
			
			if (Get_State(handle).Equals(state))
				return false;

			if (flag.Equals(Flags.IgnoreResize))
			{
				state.Width = State.Width;
				state.Height = State.Height;
			}
			state = Check_Bound(state, screen.WorkingArea, Size);
			return SetWindowPos(handle, state);
		}


		public void Close()
		{
			Close(_Handle);
		}
		public void Close(IntPtr hwnd)
		{
			try
			{
				if (!st.IsOn ||
						!Validate_Handle(hwnd) ||
						Flag.Equals(Flags.DoNothing) ||
						hwnd == main.HWND)
					return;
				Log("Close Window : " + _Handle + " -> " + Title);
				// uint 16 is for closing window.
				PostMessage(_Handle, (uint)16, IntPtr.Zero, IntPtr.Zero);
				_Handle = GetForegroundWindow();
				API.ShowWindow(overlay.HWND, SWC.Hide);
			}
			catch (Exception ea) { Log(ea); }
		}

		bool IsWndContainsCursor(Point startPos, int Padding)
		{
			State = Get_State(Handle);
			return State
				.Trim(-Size.Top + Padding, -Size.Border + Padding, -Size.Bottom)
				.Contains(startPos);
		}
		bool IsScrContainsCursor(Point startPos, int distance)
		{
			return Screen.FromPoint(startPos)
				.WorkingArea
				.Trim(-distance, -distance, 0)
				.Contains(startPos);
		}

		public void LButtonClick()
		{
			Get_Window_Info(false, false);
			if (!IsKeyDown(Keys.LButton))
				return;
			Get_Window_Info(true, true);
			Log($"LButton Down: {st.Counter}");
			Point startPos = Cursor.Position;
			if (!IsWndContainsCursor(startPos, st.Drag_Distance - 25) ||
				!IsScrContainsCursor(startPos, st.Corner_Distance) ||
				Flag == Flags.DoNothing)
			{
				while (IsKeyDown(Keys.LButton))
					System.Threading.Thread.Sleep(100);
				return;
			}

			API.Log("\tStart:");
			_drag = new Rectangle(-1,-1,-1,-1);
			_corner = new Rectangle(_State.Location, _State.Size);
			bool is_drag = false, is_corner = false;
			while (IsKeyDown(Keys.LButton) && !st.IsDragging)
			{
				System.Threading.Thread.Sleep(10);
				if (IsWndContainsCursor(Cursor.Position, st.Drag_Distance - 25))
				{
					_drag = new Rectangle(_State.Location, _State.Size);
					_corner = new Rectangle(_State.Location, _State.Size);
					API.ShowWindow(overlay.HWND, SWC.Hide);
					Show_Float_Button(Get_State(Handle));
					continue;
				}
				_State = Get__State(State, Size);
				// Mouse-Corner
				if (CtrlCheck(st.IsCorner, st.IsMouseCorner1, st.IsMouseCorner2))
				{
					is_corner = On_Mouse_Corner();
					if (is_corner)
					{
						Rectangle rect = d.cs.Setup.Selected.ToRect();
						if (rect.Equals(_corner))
							continue;
						_corner = rect;
						if (st.IsCornerPreview)
							API.ShowWindow(overlay.HWND, SWC.Show);
						Set_State(st.IsCornerPreview ? overlay.HWND : Handle,
							_corner,
							Screen_Cursor,
							st.IsCornerPreview ? Flags.AsynchronousWindowPosition : Flag,
							$"Corner from {_State} to {_corner}");
						continue;
					}
				}

				// Mouse-Drag
				if (CtrlCheck(st.IsDrag, st.IsMouseDrag1, st.IsMouseDrag2))
				{
					is_drag = false;
					// calculate the mouse position relative to the screen working area.
					Point cursor = Cursor.Position;
					Screen screen = Screen.FromPoint(cursor);
					// raw relative cursor position.
					int _X = (cursor.X - screen.WorkingArea.Left) * st.Size_Grid / screen.WorkingArea.Width;
					int _Y = (cursor.Y - screen.WorkingArea.Top) * st.Size_Grid / screen.WorkingArea.Height;

					// calculate the top-left corner of the window to move to
					// acording to cursor' relative position
					_X = (cursor.X < State.X) ? _X :
						(cursor.X > State.Right) ? _X - _State.Width + 1 : _State.X;

					_Y = (cursor.Y < State.Y) ? _Y :
						(cursor.Y > State.Bottom) ? _Y - _State.Height + 1 : _State.Y;

					//
					if (_X == _State.X &&
							_Y == _State.Y)
						is_drag = false;
					else
					{
						if (_X == _drag.X &&
								_Y == _drag.Y)
						{
							is_drag = true;
						}
						else
						{
							_drag.X = _X;
							_drag.Y = _Y;
							_drag.Size = _State.Size;
							if (st.IsDragPreview)
								API.ShowWindow(overlay.HWND, SWC.Show);
							Set_State(st.IsDragPreview ? overlay.HWND : Handle,
								_drag, Screen_Cursor,
								st.IsDragPreview ? Flags.AsynchronousWindowPosition : 
								Flags.IgnoreResize,
								$"Drag from {_State} to {_drag}");
						}
					}
				}
			}
			API.Log("\tEnd:");

			if (is_corner)
				Set_State(Handle, _corner, Screen_Cursor, 
					log: $"Corner from {_State} to {_corner}");
			else
			if (is_drag)
				Set_State(Handle, _drag, Screen_Cursor,
					log: $"Drag from {_State} to {_drag}");
			API.ShowWindow(overlay.HWND, SWC.Hide);
		}

		Rectangle _drag = new Rectangle();
		Rectangle _corner = new Rectangle();
		/// <summary>
		/// Get the coresponding corner setup when mouse cursor
		/// is dragged and hold at screen corner.
		/// </summary>
		/// <param name="Distance"></param>
		/// <returns></returns>
		public MyRect Get_Corner(int Distance)
		{
			Point cur = Cursor.Position;
			Screen scr = Screen.FromPoint(cur);
			string setupName = d.dp.GetSetupName(scr.DeviceName);
			d.cs.Setup = d.cs.FindSetup(setupName);
			//API.Log($"Device Name: {scr.DeviceName} - Setup Name: { setupName}");
			int cx = cur.X - scr.WorkingArea.Left;
			int width = scr.WorkingArea.Width;
			if (cur.Y <= scr.WorkingArea.Top + Distance)
			{
				if (cur.X <= scr.WorkingArea.Left + Distance)
					return d.cs.Setup.TopLeft;
				if (cur.X >= scr.WorkingArea.Right - Distance)
					return d.cs.Setup.TopRight;
				return d.cs.Setup.Top[cx * d.cs.Setup.Top.Count / width];
			}

			if (cur.Y >= scr.WorkingArea.Bottom - Distance)
			{
				if (cur.X <= scr.WorkingArea.Left + Distance)
					return d.cs.Setup.BottomLeft;
				if (cur.X >= scr.WorkingArea.Right - Distance)
					return d.cs.Setup.BottomRight;
				return d.cs.Setup.Bottom[cx * d.cs.Setup.Bottom.Count / width];
			}
			cx = (cur.Y - scr.WorkingArea.Top);
			width = scr.WorkingArea.Height;
			if (cur.X <= scr.WorkingArea.Left + Distance)
			{
				return d.cs.Setup.Left[cx * d.cs.Setup.Left.Count / width];
			}

			if (cur.X >= scr.WorkingArea.Right - Distance)
			{
				return d.cs.Setup.Right[cx * d.cs.Setup.Right.Count / width];
			}
			return null;
		}

		/// <summary>
		/// Delay mouse corner action to prevent unwanted trigger when
		/// drag window across screens.
		/// </summary>
		/// <returns></returns>
		public bool On_Mouse_Corner()
		{
			MyRect part = Get_Corner(st.Corner_Distance);
			if (part is null)
				return false;
			System.Threading.Thread.Sleep(st.Corner_Sensitive * 10);
			part = Get_Corner(st.Corner_Distance);
			if (part is null) return false;
			d.cs.Setup.Selected = part;
			return true;
		}
		//if (IsMouseCornerActive && IsRememberState1)
		//	AddWindow("MouseCornerActive", Thread_Mouse_LButton.Window, IsRememberState);
		//if (IsMouseDragActive && IsRememberState2)
		//	AddWindow("MouseDragActive", Thread_Mouse_LButton.Window, IsRememberState);
		public void ArrowKeyDown()
		{
			if (!CtrlCheck(st.IsArrowKey, st.IsArrowCtrlToDisable, st.IsArrowCtrlToEnable))
				return;

			Point offset = new Point
			{
				X = IsKeyDown(Keys.Left) ? -st.AddedX :
						IsKeyDown(Keys.Right) ? st.AddedX : 0,
				Y = IsKeyDown(Keys.Up) ? -st.AddedY :
						IsKeyDown(Keys.Down) ? st.AddedY : 0
			};

			if (offset.X == 0 && offset.Y == 0)
				return;

			_State.X += offset.X;
			_State.Y += offset.Y;
			Screen screen = Screen;
			if (_State.X <= -st.AddedX)
			{
				_State.X = st.Size_Grid - _State.Width;
				screen = Get_Next_Screen(true);
			}
			else
			if (_State.X >= st.Size_Grid - _State.Width + st.AddedX)
			{
				_State.X = 0;
				screen = Get_Next_Screen(true);
			}
			if (_State.Y <= -st.AddedY)
			{
				_State.Y = st.Size_Grid - _State.Height;
			}
			else
			if (_State.Y >= st.Size_Grid - _State.Height + st.AddedY)
			{
				_State.Y = 0;
			}
			Set_State(Handle, _State, screen: screen, log: "Arrow Key");
			//if (IsRememberState4)
			//	AddWindow("ArrowKey", Thread_Mouse_LButton.Window, IsRememberState);
		}
		public void Numpad_Calc_Key()
		{
			int X = IsKeyDown(Keys.Multiply) ? st.AddedWidth :
							IsKeyDown(Keys.Divide) ? -st.AddedWidth : 0,
					Y = IsKeyDown(Keys.Add) ? st.AddedHeight :
							IsKeyDown(Keys.Subtract) ? -st.AddedHeight : 0;
			if (X == 0 && Y == 0)
				return;

			_State = Get__State(Get_State(Handle), Size);
			_State.Width += X;
			_State.Height += Y;
			Set_State(Handle, _State, Screen, Flag, log: "Numpad +-*/");
		}
		public void Numpad_Number_Key()
		{
			Point offset =
				IsKeyDown(Keys.NumPad1) ? new Point(0, st.Size_Grid) :
				IsKeyDown(Keys.NumPad2) ? new Point(st.Size_Grid / 2, st.Size_Grid) :
				IsKeyDown(Keys.NumPad3) ? new Point(st.Size_Grid, st.Size_Grid) :
				IsKeyDown(Keys.NumPad4) ? new Point(0, st.Size_Grid / 2) :
				IsKeyDown(Keys.NumPad5) ? new Point(st.Size_Grid / 2, st.Size_Grid / 2) :
				IsKeyDown(Keys.NumPad6) ? new Point(st.Size_Grid, st.Size_Grid / 2) :
				IsKeyDown(Keys.NumPad7) ? new Point(0, 0) :
				IsKeyDown(Keys.NumPad8) ? new Point(st.Size_Grid / 2, 0) :
				IsKeyDown(Keys.NumPad9) ? new Point(st.Size_Grid, 0) :
				new Point(0, 0);

			if (offset.X == 0 && offset.Y == 0)
				return;
			Screen screen = st.IsNumpadSwitchScreen ? Get_Next_Screen(true) : Screen;
			_State = Get__State(Get_State(Handle), Size);
			_State.Location = offset;
			_State.X -= _State.Width / 2;
			_State.Y -= _State.Height / 2;
			State = Calc_State(_State, screen.WorkingArea, Size);
			Set_State(Handle, _State, screen, log: "Numpad number key down");
		}
		public void NumpadKeyDown()
		{
			if (!CtrlCheck(st.IsNumpad, st.IsNumpadCtrlToDisable, st.IsNumpadCtrlToEnable))
				return;
			Numpad_Calc_Key();
			//if (IsRememberState3)
			//	AddWindow("Numpad", Thread_Mouse_LButton.Window, IsRememberState);
			Numpad_Number_Key();
			//if (st.IsRememberState3)
			//	AddWindow("Numpad", this, st.IsRememberState);
		}
	}
}

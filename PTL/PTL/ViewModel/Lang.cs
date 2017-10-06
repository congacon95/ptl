using PTL.ViewModel.Utility;

namespace PTL.ViewModel
{
	/// <summary>
	/// Language view model that make support multiple language easier.
	/// </summary>
	public class Language : BindableBase
	{
		public Language()
		{
			AssignData(0);
		}
		/// <summary>
		/// Initialize new Language object with default value.
		/// </summary>
		public Language(int id)
		{
			API.Log("new Language");
			ID = id;
			//AssignData(id);
		}

		public int ID { get { return Get<int>(); } set { Set(value); } }
		public string App_Name { get { return Get<string>(); } set { Set(value); } }
		public string Exit { get { return Get<string>(); } set { Set(value); } }
		public string Icon_Tooltip { get { return Get<string>(); } set { Set(value); } }
		public string Icon_Intro { get { return Get<string>(); } set { Set(value); } }
		public string Start { get { return Get<string>(); } set { Set(value); } }
		public string Running { get { return Get<string>(); } set { Set(value); } }
		public string Stop { get { return Get<string>(); } set { Set(value); } }

		//public string IsOn { get { return Get<string>(); } set { Set(value); } }
		//public string IsTopmost { get { return Get<string>(); } set { Set(value); } }
		//public string IsStartWithWindow { get { return Get<string>(); } set { Set(value); } }
		//public string IsAutoHide { get { return Get<string>(); } set { Set(value); } }
		//public string IsBlurMain { get { return Get<string>(); } set { Set(value); } }
		//public string IsBlurOverlay { get { return Get<string>(); } set { Set(value); } }
		//public string IsBlurFloat { get { return Get<string>(); } set { Set(value); } }
		//public string IsTitle { get { return Get<string>(); } set { Set(value); } }
		//public string IsAppearance { get { return Get<string>(); } set { Set(value); } }
		//public string IsSupport { get { return Get<string>(); } set { Set(value); } }
		//public string IsFullScreen { get { return Get<string>(); } set { Set(value); } }
		//public string IsBottom { get { return Get<string>(); } set { Set(value); } }
		//public string IsBorder { get { return Get<string>(); } set { Set(value); } }

		//public string IsCorner { get { return Get<string>(); } set { Set(value); } }
		//public string IsDrag { get { return Get<string>(); } set { Set(value); } }
		//public string IsShowOverlay { get { return Get<string>(); } set { Set(value); } }
		//public string IsWheel { get { return Get<string>(); } set { Set(value); } }

		public string Top_Left { get { return Get<string>(); } set { Set(value); } }
		public string Top_Right { get { return Get<string>(); } set { Set(value); } }
		public string Bottom_Left { get { return Get<string>(); } set { Set(value); } }
		public string Bottom_Right { get { return Get<string>(); } set { Set(value); } }
		public void AssignData(int id)
		{
			if(id == 0)
			{
				//App_Name = "PTL";
				//Icon_Intro = "Make window easier to use";
				//Start = "Start";
				//Exit = "Exit";
				//Running = "App is running | Click to stop";
				//Stop = "App was stopped | Click to resume";
				//IsOn = "Background Tasks";
				//IsSupport = "IsSupport";
				//IsWheel = "Scroll on taskbar to change volume";
				//IsTopmost = "Topmost";
				//IsStartWithWindow = "Start with window";
				//IsAutoHide = "Auto hide when out of focus";
				//IsBlurMain = "Blur main window";
				//IsBlurOverlay = "Blur overlay window";
				//IsBlurFloat = "Blur floating button";
				//IsTitle = "Overlap title bar";
				//IsBottom = "Overlap bottom";
				//IsBorder = "Overlap border";
				//IsAppearance = "Beautiful Appreance";
				//IsFullScreen = "Hide border when fullscreen";
				//IsCorner = "Active screen corner";
				//IsDrag = "Drag to move window";
				//IsShowOverlay = "Show overlay window";
				//Top_Left = "Top-Left";
				//Top_Right = "Top-Right";
				//Bottom_Left = "Bottom-Left";
				//Bottom_Right = "Bottom-Right";
			}
		}
	}
}

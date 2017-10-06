using PTL.ViewModel.Utility;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace PTL.ViewModel
{
	public class DisplayVM : BindableBase
	{
		public DisplayVM()
		{
			Displays = new ObservableCollection<Display>();
		}
		public Display Selected { get { return Get<Display>(); } set { Set(value); } }

		/// <summary>
		/// List of display object that determine what corner setup to use on each screen.
		/// </summary>
		public ObservableCollection<Display> Displays { get { return Get<ObservableCollection<Display>>(); } set { Set(value); } }

		public void FindCurrentDisplay()
		{
			Screen screen = Screen.FromPoint(Cursor.Position);
			foreach(Display dp in Displays)
			{
				if(screen.DeviceName.Equals(dp.DeviceName))
					Selected = dp;
			}
		}
		public string GetSetupName(string displayName)
		{
			foreach(Display dp in Displays)
			{
				if(dp.DeviceName.Equals(displayName))
					return dp.SetupName;
			}
			return Selected.SetupName;
		}

		public void Check(CornerSetupVM cs)
		{
			if(Displays.Count == Screen.AllScreens.Length)
			{
				API.Log("Display model loaded properly");
			}
			else
			{
				API.Log("Load display model failed! Constructing new one.");
				foreach(Screen screen in Screen.AllScreens)
				{
					Displays.Add(new Display { DeviceName = screen.DeviceName,
						SetupName = cs.Setups[0].Name });
				}
			}
		}

		public override string ToString()
		{
			string s = "";
			foreach(Display dp in Displays)
				s += $"Device Name: {dp.DeviceName} - Setup Name: { dp.SetupName}\n";
			return s;
		}
	}

	public class Display : BindableBase
	{
		public string DeviceName { get { return Get<string>(); } set { Set(value); } }
		public string SetupName { get { return Get<string>(); } set { Set(value); } }
		//public int SelectedID
		//{
		//	get { return Get<int>(); }
		//	set
		//	{
		//		Set(value);
		//		if(value < 0 || App.d is null || value >= App.d.cs.Setups.Count)
		//			return;
		//		Setup = App.d.cs.Setups[value];
		//	}
		//}
	}
}

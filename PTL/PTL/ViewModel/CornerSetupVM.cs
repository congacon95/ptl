using System.Collections.ObjectModel;
using PTL.ViewModel.Utility;
using System.Drawing;
using System.Windows.Forms;
using static PTL.App;
using static PTL.API;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PTL.ViewModel
{
	/// <summary>
	/// A view model cover rectangle object that support binding and animation.
	/// </summary>
	public class MyRect : BindableBase
	{
		public MyRect()
		{
			Left = Top = 0;
			Width = Height = d is null || d.st is null ? 48 : d.st.Size_Grid;
		}
		public MyRect(int left, int top, int width, int height)
		{
			Left = left;
			Top = top;
			Width = width;
			Height = height;
		}
		public int Left
		{
			get { return Get<int>(); }
			set
			{
				Set(value);
				OnPropertyChanged(nameof(_Left));
			}
		}
		public int Top
		{
			get { return Get<int>(); }
			set
			{
				Set(value);
				OnPropertyChanged(nameof(_Top));
			}
		}
		public int Width
		{
			get { return Get<int>(); }
			set
			{
				Set(value);
				OnPropertyChanged(nameof(_Width));
				OnPropertyChanged(nameof(_Left));
			}
		}
		public int Height
		{
			get { return Get<int>(); }
			set
			{
				Set(value);
				OnPropertyChanged(nameof(_Height));
				OnPropertyChanged(nameof(_Top));
			}
		}

		public bool Equal(MyRect other)
		{
			return Left.Equals(other.Left) && Top.Equals(other.Top) &&
				Width.Equals(other.Width) && Height.Equals(other.Height);
		}
		// for displaying correct window preview size and position.
		[JsonIgnore]
		public static double WIDTH = 320, HEIGHT = 170;
		[JsonIgnore]
		public double _Left
		{
			get
			{
				double left = Left * WIDTH / d.st.Size_Grid;
				return left + _Width > WIDTH ? WIDTH - _Width : left;
			}
		}
		[JsonIgnore]
		public double _Top
		{
			get
			{
				double top = Top * HEIGHT / d.st.Size_Grid;
				return top + _Height > HEIGHT ? HEIGHT - _Height : top;
			}
		}
		[JsonIgnore]
		public double _Width { get { return Width * WIDTH / d.st.Size_Grid; } }
		[JsonIgnore]
		public double _Height { get { return Height * HEIGHT / d.st.Size_Grid; } }
		public Rectangle ToRect()
		{
			return new Rectangle(Left, Top, Width, Height);
		}
		public override string ToString()
		{
			return $"Left: {Left}, Top: {Top}, Width: {Width}, Height: {Height}";
		}
	}
	/// <summary>
	/// Corner setup model that specify how to move and resize
	/// a window when mouse-corner action was trigger.
	/// </summary>
	public class CornerSetup
	{
		public string Name { get; set; }
		public List<MyRect> Top { get; set; }
		public List<MyRect> Bottom { get; set; }
		public List<MyRect> Left { get; set; }
		public List<MyRect> Right { get; set; }

		public MyRect Selected { get; set; }
		public MyRect TopLeft { get; set; }
		public MyRect TopRight { get; set; }
		public MyRect BottomLeft { get; set; }
		public MyRect BottomRight { get; set; }

		public CornerSetup()
		{
			Top = new List<MyRect>();
			Bottom = new List<MyRect>();
			Left = new List<MyRect>();
			Right = new List<MyRect>();
			TopLeft = new MyRect(0, 0, 24, 24);
			TopRight = new MyRect(48, 0, 24, 24);
			BottomLeft = new MyRect(0, 48, 24, 24);
			BottomRight = new MyRect(48, 48, 24, 24);
			Selected = TopLeft;
			Name = "Default";
			Log("new CornerSetup");
		}

		public CornerSetup(string name, double left, double top, double right, double bottom)
		{
			Name = name;
			Top = GenList(top);
			Left = GenList(left);
			Bottom = GenList(bottom);
			Right = GenList(right);
			TopLeft = new MyRect(0, 0, 24, 24);
			TopRight = new MyRect(48, 0, 24, 24);
			BottomLeft = new MyRect(0, 48, 24, 24);
			BottomRight = new MyRect(48, 48, 24, 24);
			Selected = TopLeft;
			Log($"new CornerSetup :{name} -> Left:{left}, Top:{top}, Right:{right}, Bottom:{bottom} ");
		}

		public static CornerSetup Default()
		{
			CornerSetup st = new CornerSetup();
			st.Reset();
			st.Selected = st.Top[1];
			return st;
		}

		public void Reset(int id = 0)
		{
			if (id == 1)
			{

				Top = new List<MyRect> {
					new MyRect(0, 0, 24, 48),
					new MyRect(0, 0, 48, 48),
					new MyRect(48, 0, 24, 48) };
				Bottom = new List<MyRect> {
					new MyRect(0, 48, 32, 48),
					new MyRect(0, 48, 48, 32),
					new MyRect(48, 48, 32, 48) };
				Left = new List<MyRect> {
					new MyRect(0, 0, 48, 16),
					new MyRect(0, 16, 48, 16),
					new MyRect(0, 48, 48, 16) };
				Right = new List<MyRect> {
					new MyRect(48, 0, 48, 24),
					new MyRect(48, 0, 48, 32),
					new MyRect(48, 24, 48, 24) };
				Selected = Top[1];
				return;
			}
			Top = new List<MyRect> {
					new MyRect(0, 0, 16, 48),
					new MyRect(0, 0, 48, 48),
					new MyRect(48, 0, 16, 48) };
			Bottom = new List<MyRect> {
					new MyRect(0, 48, 32, 48),
					new MyRect(3, 48, 42, 48),
					new MyRect(48, 48, 32, 48) };
			Left = new List<MyRect> {
					new MyRect(0, 0, 12, 48),
					new MyRect(0, 0, 24, 48),
					new MyRect(0, 0, 36, 48) };
			Right = new List<MyRect> {
					new MyRect(48, 0, 12, 48),
					new MyRect(48, 0, 24, 48),
					new MyRect(48, 0, 36, 48) };
			Selected = Top[1];
		}

		public List<MyRect> GenList(double count)
		{
			List<MyRect> list = new List<MyRect>();
			for (int i = 0; i < count; i++)
			{
				list.Add(new MyRect());
			}
			return list;
		}
		/// <summary>
		/// Given a corner name return the data list of corner part on that screen side.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public List<MyRect> GetList(string name)
		{
			return name == "Top" ? Top :
				name == "Bottom" ? Bottom :
				name == "Left" ? Left :
				name == "Right" ? Right : null;
		}
	}
	/// <summary>
	/// A view model that contain a list of all corner setup.
	/// </summary>
	public class CornerSetupVM : BindableBase
	{
		public CornerSetupVM()
		{
			Log("new CornerSetupVM");
			Setups = new ObservableCollection<CornerSetup>();
			Setup = new CornerSetup();
		}
		public ObservableCollection<CornerSetup> Setups { get { return Get<ObservableCollection<CornerSetup>>(); } set { Set(value); } }
		public CornerSetup Setup { get { return Get<CornerSetup>(); } set { Set(value); } }

		public CornerSetup FindSetup(string setupName)
		{
			foreach (CornerSetup st in Setups)
				if (st.Name.Equals(setupName))
					return st;
			return Setup;
		}


		#region Commands
		public CMD OnSaveAsDefault { get; set; } = new CMD((param1) =>
		{
			//IO.SaveData(DataPath.CornersetupsDefault, GetData());
		});
		public CMD ADD_CORNER_PART { get; set; } = new CMD((param1) =>
		{
			//IO.SaveData(DataPath.CornersetupsDefault, GetData());
		});
		public CMD OnRestoreDefault { get; set; } = new CMD((param1) =>
		{ //LoadData(DataPath.CornersetupsDefault);
		});
		#endregion
	}
}

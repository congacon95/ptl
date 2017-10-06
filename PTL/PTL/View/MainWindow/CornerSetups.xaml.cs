using PTL.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using static PTL.App;

namespace PTL.View.MainWindow
{
	/// <summary>
	/// Interaction logic for CornerSetups.xaml
	/// </summary>
	public partial class CornerSetups : UserControl
	{
		public CornerSetups()
		{
			InitializeComponent();

			if (d is null || d.cs is null)
				return;
			load_displays();
			load_new_setup();
			setup_changed();
		}

		public void load_cbb_setups()
		{
			API.Log("Load SetupsList");
			cbb_setups.Items.Clear();
			foreach (CornerSetup st in d.cs.Setups)
			{
				cbb_setups.Items.Add(new ComboBoxItem { Content = st.Name });
			}
		}
		public void load_setup()
		{
			API.Log("Load Setup");
			load_setup_parts(Top, d.cs.Setup.Top);
			load_setup_parts(Bottom, d.cs.Setup.Bottom);
			load_setup_parts(Left, d.cs.Setup.Left);
			load_setup_parts(Right, d.cs.Setup.Right);
			var chb = Top.Children[Top.Children.Count / 2] as CheckBox;
			enable_one_part(chb);
		}
		private void load_setup_parts(UniformGrid grid, List<MyRect> data)
		{
			grid.Children.Clear();
			foreach (MyRect rect in data)
			{
				grid.Children.Add(new CheckBox());
			}
		}
		public CheckBox chb_last { get; set; }

		private void enable_one_part(CheckBox chb)
		{
			if (chb_last != null)
				chb_last.IsChecked = false;
			chb_last = chb;
			int id = setup_view.Children.IndexOf(chb);
			var setup = d.cs.Setup;
			// if the user click on corner checkbox
			if (id >= 0)
			{
				d.cs.Setup.Selected =
					id == 0 ? setup.TopLeft :
					id == 1 ? setup.TopRight :
					id == 2 ? setup.BottomLeft :
					id == 3 ? setup.BottomRight :
					setup.Selected;
				disable_add_remove_button(false);
			}
			else
			{
				disable_add_remove_button(true);
				UniformGrid grid = VisualTreeHelper.GetParent(chb) as UniformGrid;
				id = grid.Children.IndexOf(chb);

				List<MyRect> list = d.cs.Setup.GetList(grid.Name);
				if (list is null) return;
				d.cs.Setup.Selected = list[id];
			}
			chb_last.IsChecked = true;
			btn_preview.Content = d.cs.Setup.Selected.ToString();
			spn_part_info.DataContext = btn_preview.DataContext = d.cs.Setup.Selected;
		}
		private void disable_add_remove_button(bool isEnable)
		{
			(dpn_btn.Children[0] as Button).IsEnabled = isEnable;
			(dpn_btn.Children[1] as Button).IsEnabled = isEnable;
		}


		private void load_new_setup(CornerSetup cs = null, CheckBox chb = null)
		{
			if (cs != null)
			{
				d.cs.Setup = cs;
			}

			load_cbb_setups();
			load_setup();
			spn_add_setup.Visibility = Visibility.Collapsed;
			foreach (CheckBox cb in cv.Children)
				cb.IsChecked = false;
			if (chb is null) return;
			chb.IsChecked = true;

			int idx1 = chb.Content.ToString().IndexOf("Setup: ");
			int idx2 = chb.Content.ToString().IndexOf("Location: ");
			string str = chb.Content.ToString();
			chb.Content = str.Remove(idx1, idx2 - idx1).Insert(idx1,
				$"Setup: {cs.Name}\n");

		}
		private void sl_corner_distance_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			if (d is null) return;
			if (chb_last is null) return;

			MyRect.WIDTH = setup_view.Width - st.Corner_Distance * 2;
			MyRect.HEIGHT = setup_view.Height - st.Corner_Distance * 2;
			d.cs.Setup.Selected.Width = d.cs.Setup.Selected.Width;
			d.cs.Setup.Selected.Height = d.cs.Setup.Selected.Height;
		}
		private void load_displays()
		{
			API.Log("load_displays");
			double WIDTH = setup_view.Width = Main.Width;
			double HEIGHT = Main.Width;
			setup_view.Height = setup_view.Width * 9 / 16;
			MyRect.WIDTH = setup_view.Width - st.Corner_Distance * 2;
			MyRect.HEIGHT = setup_view.Height - st.Corner_Distance * 2;
			System.Drawing.Rectangle bound = API.Get_All_Screens_Bound();
			HEIGHT = bound.Height * WIDTH / bound.Width;
			cv.Width = WIDTH;
			cv.Height = HEIGHT;
			cv.Children.Clear();
			foreach (System.Windows.Forms.Screen scr in System.Windows.Forms.Screen.AllScreens)
			{
				CheckBox demo_scr = new CheckBox
				{
					Content = $"Device Name: {scr.DeviceName}\n" +
										$"Setup: {d.cs.FindSetup(d.dp.GetSetupName(scr.DeviceName)).Name}\n" +
										$"Location: {scr.Bounds.Location}\n" +
										$"Size: {scr.Bounds.Size} \n",
					Width = scr.Bounds.Width / (double)bound.Width * WIDTH,
					Height = scr.Bounds.Height / (double)bound.Height * HEIGHT
				};
				demo_scr.Click += demo_screen_selected;
				cv.Children.Add(demo_scr);
				Canvas.SetLeft(demo_scr, (scr.Bounds.Left - bound.Left) / (double)bound.Width * WIDTH);
				Canvas.SetTop(demo_scr, Math.Round((scr.Bounds.Top - bound.Top) / (double)bound.Height * HEIGHT));
				if (HEIGHT - demo_scr.Height > 2)
					demo_scr.Height -= 2;
			}
			demo_screen_selected();
		}

		private void demo_screen_selected(object sender = null, RoutedEventArgs e = null)
		{
			CheckBox demo_scr = (sender is null) ? cv.Children[0] as CheckBox : sender as CheckBox;
			API.Log($"demo_screen_selected : { demo_scr.Content}");
			Display dp = d.dp.Selected;
			foreach (Display dp2 in d.dp.Displays)
			{
				if (demo_scr.Content.ToString().Contains(dp2.DeviceName))
				{
					dp = dp2;
					load_new_setup(d.cs.FindSetup(dp2.SetupName), demo_scr);
				}
			}
			demo_scr.IsChecked = true;
			CornerSetup cs = d.cs.FindSetup(dp.SetupName);
			int id = d.cs.Setups.IndexOf(cs);
			cbb_setups.SelectedIndex = id;
		}

		private void corner_part_selected(object sender, RoutedEventArgs e)
		{
			try
			{
				// when user click on one of the checkboxes
				if (e.Source is CheckBox)
				{
					enable_one_part(e.Source as CheckBox);
				}
				else // when user click on the demo window button or the canvas
				{

				}
			}
			catch (Exception ex)
			{
				API.Log(ex);
			}
		}


		private void setup_changed(object sender = null, SelectionChangedEventArgs e = null)
		{
			if (d is null)
				return;
			if (d.cs.Setups.Count == 1)
				btn_remove.IsEnabled = false;
			if (cbb_setups.SelectedIndex < 0 ||
				cbb_setups.SelectedIndex >= d.cs.Setups.Count)
				return;
			foreach (CheckBox chb in cv.Children)
				if ((bool)chb.IsChecked)
				{
					foreach (Display dp in d.dp.Displays)
					{
						if (chb.Content.ToString().Contains(dp.DeviceName))
						{
							load_new_setup(d.cs.Setups[cbb_setups.SelectedIndex], chb);
							dp.SetupName = d.cs.Setup.Name;
							API.Log(d.dp.ToString());
						}
					}
				}
		}

		private void load_default_setup(object sender, RoutedEventArgs e)
		{
			foreach (CheckBox chb in cv.Children)
				if ((bool)chb.IsChecked)
				{
					foreach (Display dp in d.dp.Displays)
					{
						if (chb.Content.ToString().Contains(dp.DeviceName))
						{
							CornerSetup st = d.cs.FindSetup(dp.SetupName);
							st.Reset((sender as Button).ToolTip.ToString().Contains("Vertical") ? 1 : 0);
							load_new_setup(st, chb);
							API.Log(d.dp.ToString());
						}
					}
				}
			chb_last = null;
			enable_one_part(Top.Children[1] as CheckBox);
		}
		/// <summary>
		/// Add new corner part to the list
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void add_part(object sender, RoutedEventArgs e)
		{
			if (chb_last is null ||
				setup_view.Children.IndexOf(chb_last) >= 0)
				return;

			UniformGrid grid = VisualTreeHelper.GetParent(chb_last) as UniformGrid;
			if (grid is null)
				return;
			int id = grid.Children.IndexOf(chb_last);

			List<MyRect> list = d.cs.Setup.GetList(grid.Name);
			if (list is null)
				return;

			list.Insert(id + 1, new MyRect());
			chb_last.IsChecked = false;
			chb_last = new CheckBox();
			grid.Children.Insert(id + 1, chb_last);
			chb_last.IsChecked = true;
			enable_one_part(chb_last);
		}


		/// <summary>
		/// Remove current selected corner part
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void remove_part(object sender, RoutedEventArgs e)
		{
			if (chb_last is null ||
				setup_view.Children.IndexOf(chb_last) >= 0)
				return;
			UniformGrid grid = VisualTreeHelper.GetParent(chb_last) as UniformGrid;
			if (grid is null || grid.Children.Count == 1)
				return;
			int id = grid.Children.IndexOf(chb_last);

			List<MyRect> list = d.cs.Setup.GetList(grid.Name);
			if (list is null)
				return;

			list.Remove(list[id]);
			grid.Children.RemoveAt(id);
			chb_last = grid.Children[id - 1 < 0 ? 0 : id - 1] as CheckBox;
			enable_one_part(chb_last);
		}


		private void add_new_setup(object sender, RoutedEventArgs e)
		{
			if (!btn_add_new_setup.IsEnabled)
				return;
			CornerSetup newSetup = new CornerSetup(d.cs.Setup.Name,
		sl_Left.Value, sl_Top.Value, sl_Right.Value, sl_Bottom.Value);

			d.cs.Setups.Add(newSetup);
			load_new_setup(newSetup, cv.Children[0] as CheckBox);
		}


		private void setup_name_changed(object sender, TextChangedEventArgs e)
		{
			foreach (CornerSetup st in d.cs.Setups)
				if (tb_setup_name.Text.Equals(st.Name))
				{
					btn_add_new_setup.IsEnabled = false;
					return;
				}
			btn_add_new_setup.IsEnabled = true;
		}


		private void add_setup(object sender, RoutedEventArgs e)
		{
			load_new_setup(CornerSetup.Default());
			spn_add_setup.Visibility = Visibility.Visible;
			sl_Bottom.Value = sl_Left.Value = sl_Right.Value = sl_Top.Value = 3;
			int st_id = d.cs.Setups.Count;
			foreach (CornerSetup cs in d.cs.Setups)
				if (cs.Name.Equals($"SETUP[{st_id}]"))
					st_id++;
			tb_setup_name.Text = d.cs.Setup.Name = $"SETUP[{st_id}]";
			btn_remove.IsEnabled = true;
		}

		private void remove_setup(object sender, RoutedEventArgs e)
		{
			d.cs.Setups.Remove(d.cs.Setup);
			if (d.cs.Setups.Count == 1)
				btn_remove.IsEnabled = false;
			d.cs.Setup = d.cs.Setups[d.cs.Setups.Count - 1];
			load_new_setup(d.cs.Setup);
		}

	}
}

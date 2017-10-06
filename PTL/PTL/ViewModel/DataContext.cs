using Newtonsoft.Json;
using PTL.ViewModel.Utility;
using System;
using System.IO;
using static PTL.API;
namespace PTL.ViewModel
{
	public class Data : BindableBase
	{
		public Data()
		{
			Log("Load Data");
			//l = Load<Language>(nameof(Language));
			l = l is null ? new Language(0) : l;
			st = Load<Settings>(nameof(Settings));
			st = st is null ? new Settings() : st;
			cs = Load<CornerSetupVM>(nameof(CornerSetupVM));
			cs = cs is null ? new CornerSetupVM() : cs;
			if(cs.Setups.Count == 0)
				cs.Setups.Add(cs.Setup);
			dp = Load<DisplayVM>(nameof(DisplayVM));
			dp = dp is null ? new DisplayVM() : dp;
			// new some code to deal with display view model when things break
			// and the object model doen't load properly
			dp.Check(cs);
			r = Load<RulesVM>(nameof(RulesVM));
			r = r is null ? new RulesVM() : r;
		}

		public void SaveData()
		{
			Save(nameof(Language), l);
			Save(nameof(RulesVM), r);
			Save(nameof(Settings), st);
			Save(nameof(DisplayVM), dp);
			Save(nameof(CornerSetupVM), cs);
			Save(nameof(Data), this);
		}

		/// <summary>
		/// Language.
		/// </summary>
		public Language l { get { return Get<Language>(); } set { Set(value); } }

		/// <summary>
		/// Settings.
		/// </summary>
		public Settings st { get { return Get<Settings>(); } set { Set(value); } }

		/// <summary>
		/// Corner Setups View Model.
		/// </summary>
		public CornerSetupVM cs { get { return Get<CornerSetupVM>(); } set { Set(value); } }

		/// <summary>
		/// Displays View Model.
		/// </summary>
		public DisplayVM dp { get { return Get<DisplayVM>(); } set { Set(value); } }

		/// <summary>
		/// Rule List View Model.
		/// </summary>
		public RulesVM r { get { return Get<RulesVM>(); } set { Set(value); } }

		#region Save/Load data
		/// <summary>
		/// Given a file name and a file type.
		/// Read json file from the path and deserialize 
		/// the object into that given type.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="file_name"></param>
		/// <returns></returns>
		public static T Load<T>(string file_name)
		{
			try
			{
				String path = $"{Get_Full_Path(file_name)}.json";
				Log($"Load {file_name} from {path}");
				if (!File.Exists(path))
				{
					Log($"{file_name} not exist!");
					//get data from backup file in case the given file name doesn't exist.
					throw new IOException();
					//path = $"{GetPath($"backup/{fileName}")}.json";
				}
				return JsonConvert.DeserializeObject<T>(File.ReadAllLines(path)[0]);
			}
			catch (Exception e)
			{
				Log($"Message: {e.Message}");
				Log($"Source: {e.Source}");
				Log($"StackTrace: {e.StackTrace}");
				return default(T);
			}
		}
		/// <summary>
		/// Given a file name and a object.
		/// Serialize the object and save it as json file.
		/// </summary>
		/// <param name="file_name"></param>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static bool Save(string file_name, object obj)
		{
			try
			{
				String path = $"{Get_Full_Path(file_name)}.json";
				File.WriteAllText(path, JsonConvert.SerializeObject(obj));

				Log($"Save {file_name} to {path}");
				return true;
			}
			catch (Exception e)
			{
				Log($"Message: {e.Message}");
				Log($"Source: {e.Source}");
				Log($"StackTrace: {e.StackTrace}");
				return false;
			}
		}
		#endregion
	}
}

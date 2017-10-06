using Newtonsoft.Json;
using System.Collections.ObjectModel;
using PTL.ViewModel.Utility;

namespace PTL.ViewModel
{
	public class RulesVM : BindableBase
	{
		public RulesVM()
		{
			API.Log("new RulesVM");
			Rules = new ObservableCollection<Rule>();
			Rule = new Rule();
		}

		#region Public Properties
		/// <summary>
		/// Current selecteted rule.
		/// </summary>
		public Rule Rule { get { return Get<Rule>(); } set { Set(value); } }

		/// <summary>
		/// Rule list.
		/// </summary>
		public ObservableCollection<Rule> Rules { get { return Get<ObservableCollection<Rule>>(); } set { Set(value); } }
		public int ID { get { return Rules.IndexOf(Rule); } }


		public Rule Find(Model.MyWindow myWindow)
		{
			var _rule = new Rule(myWindow);
			foreach (Rule rule in Rules)
			{
				if (_rule.Equals(rule))
				{
					API.Log("Found Rule:" + _rule.Process.V);
					rule.Extends(_rule);
					return rule;
				}
			}
			return _rule;
		}

		#endregion

		#region Commands
		[JsonIgnore]
		public CMD UP { get; set; } = new CMD((p) =>
		{
			int id = App.d.r.ID;
			if (id > 3)
			{
				App.d.r.Rules.Move(id, id - 1);
			}
		});
		[JsonIgnore]
		public CMD DOWN { get; set; } = new CMD((p) =>
		{
			int id = App.d.r.ID;
			if (id > 2 && id < App.d.r.Rules.Count - 1)
			{
				App.d.r.Rules.Move(id, id + 1);
			}
		});
		[JsonIgnore]
		public CMD TOP { get; set; } = new CMD((p) =>
		{
			int id = App.d.r.ID;
			if (id > 2)
			{
				App.d.r.Rules.Move(id, 3);
			}
		});
		[JsonIgnore]
		public CMD BOTTOM { get; set; } = new CMD((p) =>
		{
			int id = App.d.r.ID;
			if (id > 2)
			{
				App.d.r.Rules.Move(id, App.d.r.Rules.Count - 1);
			}
		});
		[JsonIgnore]
		public CMD ADD { get; set; } = new CMD((p) =>
		{
			App.d.r.Rules.Add(App.d.r.Rule.Clone());
		});
		[JsonIgnore]
		public CMD DUPLICATE { get; set; } = new CMD((p) =>
		{
			App.d.r.Rules.Add(App.d.r.Rule.Clone());
		});
		[JsonIgnore]
		public CMD DELETE { get; set; } = new CMD((p) =>
		{
			int id = App.d.r.ID;
			App.d.r.Rules.RemoveAt(id);
			if (App.d.r.Rules.Count == 0)
				return;
			App.d.r.Rule = App.d.r.Rules[id - 1];
		});
		[JsonIgnore]
		public CMD DEFAULT { get; set; }
		#endregion
	}
}
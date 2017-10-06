using System.Drawing;
using PTL.Model;
using PTL.ViewModel.Utility;

namespace PTL.ViewModel
{
	/// <summary>
	/// A string-boolean pair that used to 
	/// identity different window.
	/// </summary>
	public class Condition : BindableBase
	{
		/// <summary>
		/// String Value.
		/// </summary>
		public string V { get { return Get<string>(); } set { Set(value); } }
		/// <summary>
		/// Boolean.
		/// </summary>
		public bool B { get { return Get<bool>(); } set { Set(value); } }
		public Condition(string v = "", bool b = false)
		{
			V = v;
			B = b;
		}
		public Condition(Condition condition)
		{
			V = condition.V;
			B = condition.B;
		}
		public bool Compare(Condition other, bool isEqual = true)
		{
			if (!other.B) return true;
			if (isEqual)
				return V.Equals(other.V);
			else
				return V.Contains(other.V);
		}
	}
	/// <summary>
	/// A int-boolean pair that determine what 
	/// to do with matching window.
	/// </summary>
	public class Action : BindableBase
	{
		/// <summary>
		/// Integer Value.
		/// </summary>
		public int V { get { return Get<int>(); } set { Set(value); } }
		/// <summary>
		/// Boolean.
		/// </summary>
		public bool B { get { return Get<bool>(); } set { Set(value); } }
		public Action(int v = 0, bool b = false)
		{
			V = v;
			this.B = b;
		}
		public Action(Action action)
		{
			V = action.V;
			B = action.B;
		}
	}

	/// <summary>
	/// A WndRect-boolean pair that determine 
	/// the state of the window.
	/// </summary>
	public class ActionState : BindableBase
	{
		/// <summary>
		/// Rectangle Value.
		/// </summary>
		public MyRect V { get { return Get<MyRect>(); } set { Set(value); } }
		/// <summary>
		/// Boolean.
		/// </summary>
		public bool B { get { return Get<bool>(); } set { Set(value); } }
		public ActionState(Rectangle v = new Rectangle(), bool b = false)
		{
			V = new MyRect(v.X, v.Y, v.Width, v.Height);
			B = b;
			if (Bound.Width == 0) Bound = API.Get_All_Screens_Bound();
		}
		public ActionState(ActionState actionState)
		{
			V = actionState.V;
			B = actionState.B;
		}
		public static Rectangle Bound { get; set; }
	}

	/// <summary>
	/// Override rule that make change to 
	/// the window state beforehand.
	/// </summary>
	public class Rule : BindableBase
	{
		public Condition Title { get { return Get<Condition>(); } set { Set(value); } }
		public Condition Class { get { return Get<Condition>(); } set { Set(value); } }
		public Condition Process { get { return Get<Condition>(); } set { Set(value); } }

		public bool Equals(Rule rule)
		{
			return Title.Compare(rule.Title, false) &&
							Class.Compare(rule.Class, true) &&
							Process.Compare(rule.Process, true);
		}

		public bool IsIgnore { get { return Get<bool>(); } set { Set(value); } }
		public bool IsNoResize { get { return Get<bool>(); } set { Set(value); } }

		public Action Top { get { return Get<Action>(); } set { Set(value); } }
		public Action Border { get { return Get<Action>(); } set { Set(value); } }
		public Action Bottom { get { return Get<Action>(); } set { Set(value); } }
		public int ID { get { return Get<int>(); } set { Set(value); } }

		public ActionState _State { get { return Get<ActionState>(); } set { Set(value); } }
		public ActionState State { get { return Get<ActionState>(); } set { Set(value); } }

		/// <summary>
		/// Create a new rule object.
		/// </summary>
		public Rule()
		{
			Title = new Condition();
			Class = new Condition();
			Process = new Condition();
			Top = new Action();
			Border = new Action();
			Bottom = new Action();
			_State = new ActionState();
			State = new ActionState();
			IsIgnore = false;
			IsNoResize = false;
			ID = -1;
		}

		/// <summary>
		/// Create a new rule base on a given window.
		/// </summary>
		/// <param name="window"></param>
		public Rule(MyWindow window)
		{
			Title = new Condition(window.Title);
			Class = new Condition(window.Class);
			Process = new Condition(window.Process);
			Top = new Action(window.Size.Top);
			Border = new Action(window.Size.Border);
			Bottom = new Action(window.Size.Bottom);
			_State = new ActionState(window._State);
			State = new ActionState(window.State);
		}

		public void Extends(Rule rule)
		{
			Title.V = Title.B ? Title.V : rule.Title.V;
			Class.V = Class.B ? Class.V : rule.Class.V;
			Process.V = Process.B ? Process.V : rule.Process.V;
			Top.V = Top.B ? Top.V : rule.Top.V;
			Border.V = Border.B ? Border.V : rule.Border.V;
			Bottom.V = Bottom.B ? Bottom.V : rule.Bottom.V;
			_State.V = _State.B ? _State.V : rule._State.V;
			State.V = State.B ? State.V : rule.State.V;
		}


		/// <summary>
		/// Deep copy a given rule.
		/// </summary>
		/// <param name="rule"></param>
		public void Copy(Rule rule)
		{
			Title = new Condition(rule.Title);
			Class = new Condition(rule.Class);
			Process = new Condition(rule.Process);
			Top = new Action(rule.Top);
			Border = new Action(rule.Border);
			Bottom = new Action(rule.Bottom);
			_State = new ActionState(rule._State);
			State = new ActionState(rule.State);
		}
		/// <summary>
		/// Clone with deep copy.
		/// </summary>
		/// <param name="rule"></param>
		/// <returns></returns>
		public Rule Clone()
		{
			Rule newRule = new Rule();
			newRule.Copy(this);
			return newRule;
		}
	}
}

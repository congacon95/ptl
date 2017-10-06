using System;
using System.Diagnostics;
using System.Windows.Input;

namespace PTL.ViewModel.Utility
{
	/// <summary>
	/// Relay command that replace onclick event.
	/// </summary>
	public class CMD : ICommand
	{
		#region Fields 
		readonly Action<object> _execute;
		readonly Predicate<object> _canExecute;
		#endregion // Fields 
		#region Constructors 
		public CMD(Action<object> execute) : this(null, execute) { }
		public CMD(Predicate<object> canExecute, Action<object> execute)
		{
			_canExecute = canExecute;
			_execute = execute ?? throw new ArgumentNullException("execute");
		}
		#endregion // Constructors 
		#region ICommand Members 
		[DebuggerStepThrough]
		public bool CanExecute(object parameter)
		{
			return _canExecute == null ? true : _canExecute(parameter);
		}
		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}
		public void Execute(object parameter) { _execute(parameter); }
		#endregion // ICommand Members 
	}
}

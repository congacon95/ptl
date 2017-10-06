using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PTL.ViewModel.Utility
{
	public abstract class BindableBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private readonly Dictionary<string, object> _Dict = new Dictionary<string, object>();

		protected virtual void OnPropertyChanged(string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		protected T Get<T>([CallerMemberName] string propertyName = null)
		{
			try
			{
				if(_Dict.TryGetValue(propertyName, out object value))
					return (T)value;
				return default(T);
			}
			catch(Exception e)
			{
				API.Log($"ERROR: OnPropertyChanged -> Get<T>({propertyName})");
				API.Log(e);
				return default(T);
			}
		}

		protected bool Set<T>(T newValue, [CallerMemberName] string propertyName = null)
		{
			if(propertyName == null)
				throw new ArgumentNullException("propertyName");

			if(EqualityComparer<T>.Default.Equals(newValue, Get<T>(propertyName)))
				return false;
			
			_Dict[propertyName] = newValue;
			OnPropertyChanged(propertyName);
			return true;
		}
	}
}

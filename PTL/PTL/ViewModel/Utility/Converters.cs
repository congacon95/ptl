using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PTL.ViewModel.Utility
{
	public class AddAll : IMultiValueConverter
	{
		public object Convert(object[] ints, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			double i = 0;
			foreach(object o in ints)
			{
				i += System.Convert.ToInt32(ints);
			}
			return i;
		}
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
	public class MultiMarginConverter : IMultiValueConverter
	{
		public object Convert(object[] ints, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return new Thickness(System.Convert.ToDouble(ints[0]),
													 System.Convert.ToDouble(ints[1]),
													 System.Convert.ToDouble(ints[2]),
													 System.Convert.ToDouble(ints[3]));
		}

		public Object[] ConvertBack(Object value, Type[] targetTypes, Object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
	public class BooleanToVisibility : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool IsChecked = System.Convert.ToBoolean(value);
			System.Convert.ToBoolean(parameter);
			if(parameter != null && !System.Convert.ToBoolean(parameter))
				IsChecked = !IsChecked;
			return IsChecked ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value.Equals(Visibility.Visible) ? true : false;
		}
	}
	public class Multiply : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (System.Convert.ToDouble(value) * System.Convert.ToDouble(parameter));
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (System.Convert.ToDouble(value) / System.Convert.ToDouble(parameter));
		}
	}
	public class DivideByFactor : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (System.Convert.ToDouble(value) / System.Convert.ToDouble(parameter));
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (System.Convert.ToDouble(value) * System.Convert.ToDouble(parameter));
		}
	}
	public class SubtractBy : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (System.Convert.ToDouble(parameter) - System.Convert.ToDouble(value));
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (-System.Convert.ToDouble(parameter) + System.Convert.ToDouble(value));
		}
	}
	public class Subtract : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return System.Convert.ToDouble(value) - System.Convert.ToDouble(parameter);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return System.Convert.ToDouble(value) + System.Convert.ToDouble(parameter);
		}
	}
	public class Add : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (System.Convert.ToDouble(parameter) + System.Convert.ToDouble(value));
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (System.Convert.ToDouble(parameter) - System.Convert.ToDouble(value));
		}
	}
	public class NotNotNot : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return !System.Convert.ToBoolean(value);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return !System.Convert.ToBoolean(value);
		}
	}
	public class ToState : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (System.Convert.ToDouble(value) / 48f * System.Convert.ToDouble(parameter));
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}

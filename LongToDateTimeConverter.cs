using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp1 // Defining a namespace called "WeatherApp1".
{
    public class LongToDateTimeConverter : IValueConverter // Defining a public class called "LongToDateTimeConverter" that implements the IValueConverter interface.
    {
        private DateTime _time = new DateTime(1970, 1, 1, 0, 0, 0, 0); // Declaring a private DateTime variable called "_time" and initializing it to the epoch time.

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) // Implementing the Convert method of the IValueConverter interface.
        {
            long dateTime = (long)value; // Casting the input value to a long and assigning it to the "dateTime" variable.
            return $"{_time.AddSeconds(dateTime).ToString()} UTC"; // Adding the number of seconds to the epoch time and returning it as a string in the UTC format.
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) // Implementing the ConvertBack method of the IValueConverter interface.
        {
            throw new NotImplementedException(); // Throwing a NotImplementedException as this method is not implemented.
        }
    }
}

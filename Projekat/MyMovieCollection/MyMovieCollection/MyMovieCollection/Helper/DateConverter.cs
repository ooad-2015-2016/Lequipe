using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovieCollection.MyMovieCollection.Helper
{
    class DateConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTimeOffset df = DateTime.SpecifyKind(((DateTime)value), DateTimeKind.Utc);
            return df;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return ((DateTimeOffset)value).DateTime;
        }
    }
}

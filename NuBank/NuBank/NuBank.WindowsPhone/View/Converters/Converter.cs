using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace NuBank.View
{
    public class ConvertValueToReal : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            double db = (double)((int)value) / 100;
            return String.Format(new CultureInfo("pt-BR"), "{0:C}", db);
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }

    public class ConvertDate : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime date = DateTime.ParseExact(value.ToString(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            
            return String.Format("VENCIMENTO {0}/{1}", date.Day, date.Month);
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }

    public class ConvertStatusInColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {

            string color = "blue";
            switch((string)value)
            {
                case "overdue":
                    color = "#7ED321";
                    break;
                case "closed":
                    color = "#E5615C";
                    break;
                case "open":
                    color = "#40AAB9";
                    break;
                case "future":
                    color = "#F5A623";
                    break;
            }

            return color;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }

    public class ConvertDatetoMonthBill : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime date = DateTime.ParseExact(value.ToString(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

            string month = string.Empty;
            switch (date.Month)
            {
                case 1:
                    month = "JANEIRO";
                    break;
                case 2:
                    month = "FEVEREIRO";
                    break;
                case 3:
                    month = "MARÇO";
                    break;
                case 4:
                    month = "ABRIL";
                    break;
                case 5:
                    month = "MAIO";
                    break;
                case 6:
                    month = "JUNHO";
                    break;
                case 7:
                    month = "JULHO";
                    break;
                case 8:
                    month = "AGOSTO";
                    break;
                case 9:
                    month = "SETEMBRO";
                    break;
                case 10:
                    month = "OUTUBRO";
                    break;
                case 11:
                    month = "NOVEMBRO";
                    break;
                case 12:
                    month = "DEZEMBRO";
                    break;
            }

            return month;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }

    public class ConvertPaidedBill : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if ((string)value == "overdue")
                return "Visible";
            else
                return "Collapsed";
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }

    public class ConvertCloseddBill : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if ((string)value == "closed")
                return "Visible";
            else
                return "Collapsed";
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }

    public class ConvertGerarBoleto : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if ((string)value == "open")
                return "Visible";
            else
                return "Collapsed";
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }

    public class ConvertDateFormat : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime date = DateTime.ParseExact(value.ToString(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

            return String.Format("{0}/{1}/{2}", date.Day, date.Month, date.Year);
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }

    public class ConvertGridState : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {

            string grid = string.Empty;
            switch ((string)value)
            {
                case "overdue":
                case "open":
                    grid = "3";
                    break;
                case "closed":
                    grid = "4";
                    break;
                case "future":
                    grid = "2";
                    break;
            }

            return grid;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }

    public class ConvertButtonGerarBoleto : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {

            string grid = string.Empty;
            switch ((string)value)
            {
                case "overdue":
                case "future":
                case "closed":
                    grid = "3";
                    break;
                case "open":
                    grid = "2";
                    break;
            }

            return grid;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}

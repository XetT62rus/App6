using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace App6
{
    class WeatherControl:DependencyObject
    {
        private string windDirection;
        private int windSpeed;
        private enum Precipiation
        {
            sunny,
            cloudy,
            rain,
            snow
        }
        public string WindDirection { get; set; }
        public int WindSpeed { get; set; }
        public WeatherControl(string winddir,int windsp)
        {
            this.WindDirection = winddir;
            this.WindSpeed = windsp;
        }
        public static readonly DependencyProperty TempProperty;
        public int Temp
        {
            get => (int)GetValue(TempProperty);
            set => SetValue(TempProperty, value);
        }
        static WeatherControl()
        {
            TempProperty = DependencyProperty.Register(
                nameof(Temp),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsParentMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemp)),
                new ValidateValueCallback(ValidateTemp));
        }
        private static bool ValidateTemp(object value)
        {
            int v = (int)(value);
            if(v>=-50 && v<=50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static object CoerceTemp(DependencyObject d,object baseValue)
        {
            int v = (int)baseValue;
            if (v >= -50 && v <= 50)
            {
                return v;
            }
            else
            {
                return null;
            }
        }
    }
}

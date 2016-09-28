using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App4.Controls
{
    public class CircleImage : Image
    {
        public static readonly BindableProperty BorderThicknessProperty =
          BindableProperty.Create<CircleImage, int>(
            p => p.BorderThickness, 0);

        public int BorderThickness
        {
            get { return (int)GetValue(BorderThicknessProperty); }
            set { SetValue(BorderThicknessProperty, value); }
        }

        public static readonly BindableProperty BorderColorProperty =
          BindableProperty.Create<CircleImage, Color>(
            p => p.BorderColor, Color.White);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty FillColorProperty =
          BindableProperty.Create<CircleImage, Color>(
            p => p.FillColor, Color.Transparent);

        public Color FillColor
        {
            get { return (Color)GetValue(FillColorProperty); }
            set { SetValue(FillColorProperty, value); }
        }



        public event EventHandler RelisePlanet;
        public void DoRelisePlanet(int x, int y)
        {
            EventHandler eh = RelisePlanet;
            if (eh != null)
                eh(this, new EventArgs_XY(x, y));
        }

        
        public event EventHandler DownPlanet;
        public void DoDownPlanet(int x, int y)
        {
            EventHandler eh = DownPlanet;
            if (eh != null)
                eh(this, new EventArgs_XY(x, y));
        }

    }


    public class EventArgs_XY : EventArgs
    {
        public int argX { get; set; }
        public int argY { get; set; }
        public EventArgs_XY(int x, int y)
        {
            argX = x;
            argY = y;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App4.Pages
{
    public enum Position
    {
        Top = 1,
        Bottom,
        Left,
        Right
    }

    public partial class Page2 : ContentPage
    {
        private int Pos;

        public Page2()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            DropimgAnywere();
        }

        private async Task DropimgAnywere()
        {
            Random r = new Random();
            uint timeRandom = (uint)r.Next(10, 200);
            int choise = r.Next(1, 10);

            timeRandom = 500;

            do
            {
                if (timeRandom % 2 == 0)
                {
                    if (choise % 2 == 0)
                    {
                        if (Pos != (int)Position.Bottom)
                        {
                            Pos = (int)Position.Bottom;
                            await Earth.TranslateTo(0, (Height - Earth.Height) / 2, timeRandom, Easing.Linear); 
                        }
                    }
                    else
                    {
                        if (Pos != (int)Position.Top)
                        {
                            Pos = (int)Position.Top;
                            await Earth.TranslateTo(0, ((Height - Earth.Height) / 2) * -1, timeRandom, Easing.Linear); 
                        }
                    }
                }
                else
                {
                    if (choise % 2 == 0)
                    {
                        if (Pos != (int)Position.Right)
                        {
                            Pos = (int)Position.Right;
                            await Earth.TranslateTo((Width - Earth.Width) / 2, 0, timeRandom, Easing.Linear); 
                        }
                    }
                    else
                    {
                        if (Pos != (int)Position.Left)
                        {
                            Pos = (int)Position.Left;
                            await Earth.TranslateTo(((Width - Earth.Width) / 2) * -1, 0, timeRandom, Easing.Linear); 
                        }
                    }
                }

                if(timeRandom > 60)
                    timeRandom = timeRandom - (uint)r.Next(1, 10);

                choise = r.Next(1, 10);

            } while (true);

        }
    }
}

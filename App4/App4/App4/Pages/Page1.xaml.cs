using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App4.Controls;
using App4.ViewModels;
using Xamarin.Forms;

namespace App4.Pages
{
    public partial class Page1 : ContentPage
    {
        private bool IsDroped = false;
        public PlanetVM PlanetVm { get; set; }
        public Page1()
        {
            PlanetVm = new PlanetVM();
            this.BindingContext = PlanetVm;
            
            InitializeComponent();
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            FlyByCircleMoon();
            FlyByCircleUfo();
            FlyWithRotate();
            
        }

        private async Task FlyByCircleMoon()
        {
            int radius = 70;
            int countToches = 60;
            uint timeForStep = 100;

            double zoom = 1;

            int i = 1;
            do
            {
                if (i > 30)
                {
                    radius ++;
                    zoom = zoom + 0.1;
                }
                else
                {
                    radius --;
                    zoom = zoom - 0.1;
                }


                double size = radius / (i % 5 == 0 ? 15 : 30);
                double radians = i * 2 * Math.PI / countToches;
                double x = 0 + radius * Math.Sin(radians) - size / 2;
                double y = 0 - radius * Math.Cos(radians) - size / 2;

                //await AllLayout.TranslateTo(x, y, timeForStep, Easing.Linear);
                await Moon.TranslateTo(x, y, timeForStep, Easing.Linear);
                await Moon.ScaleTo(zoom, 100, Easing.Linear);



                if (i == 60)
                {
                    i = 0;
                }

                i++;

            } while (true);

        }

        private async Task FlyByCircleUfo()
        {
            int radius = 100;
            int countToches = 50;
            uint timeForStep = 100;
            
            int i = 1;
            do
            {
                double size = radius/(i%5 == 0 ? 15 : 30);
                double radians = i * 2 * Math.PI / countToches;
                double x = 0 + radius*Math.Sin(radians) - size/2;
                double y = 0 - radius*Math.Cos(radians + radians) - size/2;
                
                //await AllLayout.TranslateTo(x, y, timeForStep, Easing.Linear);
                await Ufo.TranslateTo(x, y, timeForStep, Easing.Linear);

                i++;

            } while (true);
            
        }

        

        private async Task FlyWithRotate()
        {
            
            do
            {
                await Earth.RotateTo(360, 2500, Easing.Linear);
                await Earth.RotateTo(0, 5, Easing.Linear);

            } while (true);
        }

        


        private async void CircleImage_1_OnRelisePlanet(object sender, EventArgs e)
        {
            //doDropimg();
            var ev = e as EventArgs_XY;
                var difX = ev.argX;
                var difY = ev.argY;

            int mainHeight = (int)(Height - Earth.Height);
            int mainWidth = (int)(Width - Earth.Width);

            bool IsBounce = false;
            bool IsSecondX = false;

            int difX2 = 0;

            if (difX > mainWidth)
            {
                difX2 = (mainWidth - difX) / 2;

                difX = mainWidth;
                //IsBounce = true;
            }
            if (difX < 0)
            {
                difX = 0;
                IsBounce = true;
            }

            if (difY > mainHeight)
            {
                difY = mainHeight;
                IsBounce = true;
            }
            if (difY < 0)
            {
                difY = 0;
                IsBounce = true;
            }


            var r = new Rectangle(difX, difY, 100, 100);
            if (IsBounce)
            {
                await Earth.LayoutTo(r, 500, Easing.BounceOut);
            }
            else
            {
                await Earth.LayoutTo(r, 500, Easing.Linear);
            }

            if (difX2 != 0)
            {
                var r2 = new Rectangle(difX2, difY, 100, 100);
                await Earth.LayoutTo(r2, 500, Easing.Linear);
            }

            //if ((CircleImage_1.TranslationY + difY) > 0)
            //    if (mainHeight < (CircleImage_1.TranslationY + difY))
            //        difY = mainHeight;

            //if ((CircleImage_1.TranslationY + difY) < 0)
            //    if (mainHeight < ((CircleImage_1.TranslationY + difY) * +1))
            //        difY = mainHeight * -1;

            //if ((CircleImage_1.TranslationX + difX) > 0)
            //    if (mainWidth < (CircleImage_1.TranslationX + difX))
            //        difX = mainWidth;

            //if ((CircleImage_1.TranslationX + difX) < 0)
            //    if (mainWidth < ((CircleImage_1.TranslationX + difX) * +1))
            //        difX = mainWidth * -1;

            Debug.WriteLine("--------- difX = " + difX);
            Debug.WriteLine("--------- difY = " + difY);

            //await CircleImage_1.TranslateTo(difX, difY, 2000, Easing.Linear);

            Debug.WriteLine("--------- CircleImage_1.X = " + Earth.X);
            Debug.WriteLine("--------- CircleImage_1.Y = " + Earth.Y);

            //await Task.Delay(2000);

            //var r2 = new Rectangle(mainWidth / 2, mainHeight / 2, 100, 100);
            //await CircleImage_1.LayoutTo(r2, 500, Easing.BounceOut);


            await Task.Delay(2000);
            var r3 = new Rectangle(mainWidth / 2, mainHeight / 2, 100, 100);
            await Earth.LayoutTo(r3, 1000, Easing.BounceOut);
        }

        private void CircleImage_1_OnDownPlanet(object sender, EventArgs eventArgs)
        {
            //var e = eventArgs as EventArgs_XY;

            
            //if (e != null)
            //{
            //    var difX = e.argX;
            //    var difY = e.argY;

            //    while (Height > difY)
            //    {
            //        difY = difY + difY;
            //    }

            //    while (Width > difX)
            //    {
            //        difX = difX + difX;
            //    }


            //    CircleImage_1.TranslateTo(difX, difY, 3000, Easing.BounceOut);

            //    //CircleImage_1.TranslateTo(CircleImage_1.TranslationX, (Height - CircleImage_1.Height) / 2, 2000, Easing.BounceOut);

            //    //CircleImage_1.TranslateTo(e.argX * 0.1, e.argY * 0.1, 50, Easing.Linear);
            //}
        }
    }
}

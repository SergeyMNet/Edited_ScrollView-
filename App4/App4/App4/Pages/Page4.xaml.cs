using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App4.Pages
{
    public partial class Page4 : ContentPage
    {
        private bool isRotate;
        private bool isFly;
        private bool isScale;



        public Page4()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            FlyByCircleEarth();
        }


        private async Task FlyWithRotate()
        {
            while (isRotate)
            {
                await Earth.RotateTo(360, 2500, Easing.Linear);
                await Earth.RotateTo(0, 5, Easing.Linear);
            }
        }

        private async Task FlyByCircleEarth()
        {
            int radius = 100;
            int countToches = 60;
            uint timeForStep = 100;
            
            int i = 1;
            do
            { 
                double size = radius / (i % 5 == 0 ? 15 : 30);
                double radians = i * 2 * Math.PI / countToches;
                double x = 0 + radius * Math.Sin(radians) - size / 2;
                double y = 0 - radius * Math.Cos(radians) - size / 2;

                while (!isFly)
                {
                    await Task.Delay(100);
                }

                await Earth.TranslateTo(x, y, timeForStep, Easing.Linear);
            
                if (i == 60)
                {
                    i = 0;
                }

                i++;
            }
            while (true);

        }

        private async Task FlyWithScale()
        {
            while (isScale)
            {
                await Earth.ScaleTo(0.5, 2500, Easing.Linear);
                await Earth.ScaleTo(1.2, 3500, Easing.Linear);
            }
        }




        private void Button1_OnClicked(object sender, EventArgs e)
        {
            isRotate = !isRotate;
            FlyWithRotate();
        }

        private void Button2_OnClicked(object sender, EventArgs e)
        {
            isFly = !isFly;
        }

        private void Button3_OnClicked(object sender, EventArgs e)
        {
            isScale = !isScale;
            FlyWithScale();
        }
    }
}

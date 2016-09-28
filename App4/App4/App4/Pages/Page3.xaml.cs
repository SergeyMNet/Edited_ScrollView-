using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App4.ViewModels;
using Xamarin.Forms;

namespace App4.Pages
{
    public partial class Page3 : ContentPage
    {
        public PlanetVM PlanetVm { get; set; }
        public Page3()
        {
            PlanetVm = new PlanetVM();
            this.BindingContext = PlanetVm;
            InitializeComponent();

            PlanetVm.ClickPlanet += DoDropimg;
        }


        private bool IsDroped = false;
        private void DoDropimg(object sender, EventArgs e)
        {
            if (!IsDroped)
            {
                Dropimg();
                IsDroped = true;
            }
            else
            {
                TakeUp();
                IsDroped = false;
            }
        }

        private async Task Dropimg()
        {
            await Earth.TranslateTo(0, (Height - Earth.Height) / 2, 1000, Easing.BounceOut);

        }
        private async Task TakeUp()
        {
            await Earth.TranslateTo(0, 0, 1000, Easing.BounceOut);
        }
    }
}

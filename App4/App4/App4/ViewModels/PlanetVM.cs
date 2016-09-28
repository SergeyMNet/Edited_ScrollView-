using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App4.ViewModels
{
    public class PlanetVM
    {
        public Command ClickCommand { get; set; }

        public PlanetVM()
        {
            ClickCommand = new Command(ClickHeandler);
        }

        private void ClickHeandler(object obj)
        {
            DoClickPlanet();
        }



        public event EventHandler ClickPlanet;
        public void DoClickPlanet()
        {
            EventHandler eh = ClickPlanet;
            if (eh != null)
                eh(this, EventArgs.Empty);
        }
    }
}

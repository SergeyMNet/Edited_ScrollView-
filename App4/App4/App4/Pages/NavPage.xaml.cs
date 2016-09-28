using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App4.Pages
{
    public partial class NavPage : ContentPage
    {
        public NavPage()
        {
            InitializeComponent();
        }

        private void Button1_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page1());

        }

        private void Button2_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page2());
        }

        private void Button3_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page3());
        }

        private void Button4_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page4());
        }

        private void Button5_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page5());
        }
    }
}

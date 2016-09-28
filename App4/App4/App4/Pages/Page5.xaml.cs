using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App4.Controls;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using App4.Enums;
using App4.Model;
using App4.ViewModels;

namespace App4.Pages
{
    public partial class Page5 : ContentPage
    {
        public ScrollVM ScrollVm { get; set; }
        public Page5()
        {
            InitializeComponent();
            ScrollVm = new ScrollVM();
            //this.BindingContext = ScrollVm;
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            foreach (var item in ScrollVm.Items)
            {
                var mod = (DataTemplate)Application.Current.Resources["ItemTemplate"];
                var content = mod.CreateContent() as FrameTouchListner;
                content.BindingContext = item;
                content.TouchEvent += FrameTouchListner_OnTouchEvent; //+= item.TouchListner();

                //var content = new FrameTouchListner();
                //content.BindingContext = item;

                MainLayout.Children.Add(content);
            }
        }
        
        
        /// <summary>
        /// Touch event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FrameTouchListner_OnTouchEvent(object sender, EventArgs e)
        {
            if (!IsBusy)
            {
                IsBusy = true;

                var a = e as EvArg;
                var frame = sender as FrameTouchListner;

                if (frame != null)
                {
                    // ignore the weak touch
                    if (a.Val > 10 || a.Val < -10)
                    {
                        if (a.Val > 0)
                        {
                            if (frame.TranslationX == -50)
                            {
                                await UnSelectElement(frame);
                                frame.StatusItem = (int) StatusItem.Default;
                            }
                            else
                            {
                                await DeleteElement(frame);
                                frame.StatusItem = (int)StatusItem.Removed;
                            }
                        }
                        else
                        {
                            await SelectElement(frame);
                            frame.StatusItem = (int)StatusItem.Selected;
                        }
                    }
                }
                IsBusy = false;
            }
        }



        private async Task UnSelectElement(FrameTouchListner frame)
        {
            await frame.TranslateTo(0, 0, 500, Easing.BounceOut);
        }

        private async Task SelectElement(FrameTouchListner frame)
        {
            await frame.TranslateTo(-50, 0, 100, Easing.Linear);
        }

        private async Task DeleteElement(FrameTouchListner frame)
        {
            await Task.WhenAll(
                           frame.TranslateTo(500, 0, 800, Easing.Linear),
                           frame.FadeTo(0, 500, Easing.Linear)
                           );
        }
        


        #region Menu

        private int menuCheckrd = 0;
        private void Menu1_OnTapped(object sender, EventArgs e)
        {
            if (menuCheckrd != 1)
            {
                menuCheckrd = 1;
                BoxView_1.Opacity = 1;
                BoxView_2.Opacity = 0;

                ScrollVm.IsShowAll = true;
            }

        }

        private void Menu2_OnTapped(object sender, EventArgs e)
        {
            if (menuCheckrd != 2)
            {
                menuCheckrd = 2;
                BoxView_1.Opacity = 0;
                BoxView_2.Opacity = 1;

                ScrollVm.IsShowAll = false;
            }
        } 

        #endregion
    }
}

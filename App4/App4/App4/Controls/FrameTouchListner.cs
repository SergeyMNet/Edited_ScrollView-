using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App4.Controls
{
    public class FrameTouchListner : Frame
    {
        

        public FrameTouchListner()
        {
            //Label l = new Label();

            //l.FontSize = 30;
            //l.FontAttributes = FontAttributes.Bold;
            //l.HorizontalOptions = LayoutOptions.Center;
            //l.VerticalOptions = LayoutOptions.Center;
            //l.TextColor = Color.White;
            //l.SetBinding(Label.TextProperty, "Title");

            
            //BoxView bx = new BoxView();
            //bx.Color = Color.White;
            //bx.HeightRequest = 3;
            //bx.WidthRequest = 100;
            //bx.HorizontalOptions = LayoutOptions.Center;
            //bx.VerticalOptions = LayoutOptions.Center;
            //bx.SetBinding(BoxView.IsVisibleProperty, "IsDone");

            //this.Content = new Grid()
            //{
            //    Children =
            //    {
            //        l,
            //        bx
            //    }
            //};
        }



        public static readonly BindableProperty ItemIdProperty =
         BindableProperty.Create<FrameTouchListner, Int32>(p => p.ItemId, 0);
        public int ItemId
        {
            get { return (int)GetValue(ItemIdProperty); }
            set { SetValue(ItemIdProperty, value); }
        }


        public static readonly BindableProperty StatusItemProperty =
         BindableProperty.Create<FrameTouchListner, Int32>(
             p => p.ItemId, 0, BindingMode.TwoWay);
        public int StatusItem
        {
            get { return (int)GetValue(StatusItemProperty); }
            set { SetValue(StatusItemProperty, value); }
        }


        public static readonly BindableProperty WorkflowItemProperty =
         BindableProperty.Create<FrameTouchListner, Int32>(
             p => p.ItemId, 0, BindingMode.TwoWay);
        public int WorkflowItem
        {
            get { return (int)GetValue(WorkflowItemProperty); }
            set { SetValue(WorkflowItemProperty, value); }
        }





        public static readonly BindableProperty IsCheckedProperty =
         BindableProperty.Create<FrameTouchListner, bool>(
           p => p.IsChecked, false);

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }


        


        public float? XTouch { get; set; }

        public event EventHandler TouchEvent;
        public void DoTouchEvent(float? xtouch)
        {
            XTouch = xtouch;
            EventHandler eh = TouchEvent;
            if (eh != null)
                eh(this, new EvArg(xtouch));
        }
    }

    public class EvArg : EventArgs
    {
        public EvArg(float? par)
        {
            this.Val = par;
        }
        public float? Val { get; set; }
    }
}
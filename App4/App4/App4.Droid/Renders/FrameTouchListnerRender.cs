using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App4.Controls;
using App4.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(FrameTouchListner), typeof(FrameTouchListnerRender))]
namespace App4.Droid.Renders
{
    public class FrameTouchListnerRender : FrameRenderer
    {
        private FrameTouchListner MainElement;

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            MainElement = Element as FrameTouchListner;
        }
        


        private static float _start;
        private static float _end;

        public override bool DispatchTouchEvent(MotionEvent e)
        {
            switch (e.Action)
            {
                case MotionEventActions.Down:
                    _start = e.GetX();
                    break;

                case MotionEventActions.Move:

                    _end = e.GetX();
                    float difference = _end - _start;

                    MainElement.DoTouchEvent((difference / 10));
                    break;
            }

            return base.DispatchTouchEvent(e);
        }
    }
}
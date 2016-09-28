using System;
using System.Collections.Generic;
using System.Text;
using App4.Controls;
using App4.iOS.Renders;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(FrameTouchListner), typeof(FrameTouchListnerRender))]
namespace App4.iOS.Renders
{
    public class FrameTouchListnerRender : FrameRenderer
    {
        FrameTouchListner MainElement => (FrameTouchListner)Element;
        private float difference;

        
        
        public override void TouchesMoved(NSSet touches, UIEvent evt)
        {
            base.TouchesMoved(touches, evt);
            
            // get the touch
            UITouch touch = touches.AnyObject as UITouch;
            if (touch != null)
            {
                // move the shape
                difference = (float)touch.PreviousLocationInView(this).X - (float)touch.LocationInView(this).X;
                System.Diagnostics.Debug.WriteLine("--------------dif = " + difference);
            }
        }

        public override void TouchesEnded(NSSet touches, UIEvent evt)
        {
            base.TouchesEnded(touches, evt);
            
            // get the touch
            UITouch touch = touches.AnyObject as UITouch;
            if (touch != null)
            {
                MainElement.DoTouchEvent((difference / 10));
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            if (Element == null)
                return;
        }
    }
}

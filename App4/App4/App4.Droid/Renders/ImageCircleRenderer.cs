using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App4.Controls;
using App4.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CircleImage), typeof(ImageCircleRenderer))]
namespace App4.Droid.Renders
{
    /// <summary>
    /// ImageCircle Implementation
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ImageCircleRenderer : ImageRenderer
    {
        CircleImage MainElement => (CircleImage)Element;
        

        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public async static void Init()
        {
            var temp = DateTime.Now;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                //Only enable hardware accelleration on lollipop
                if ((int)Android.OS.Build.VERSION.SdkInt < 21)
                {
                    SetLayerType(LayerType.Software, null);
                }

            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == CircleImage.BorderColorProperty.PropertyName ||
              e.PropertyName == CircleImage.BorderThicknessProperty.PropertyName ||
              e.PropertyName == CircleImage.FillColorProperty.PropertyName)
            {
                this.Invalidate();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="child"></param>
        /// <param name="drawingTime"></param>
        /// <returns></returns>
        protected override bool DrawChild(Canvas canvas, Android.Views.View child, long drawingTime)
        {
            try
            {

                var radius = Math.Min(Width, Height) / 2;

                var borderThickness = (float)((CircleImage)Element).BorderThickness;

                int strokeWidth = 0;

                if (borderThickness > 0)
                {
                    var logicalDensity = Xamarin.Forms.Forms.Context.Resources.DisplayMetrics.Density;
                    strokeWidth = (int)Math.Ceiling(borderThickness * logicalDensity + .5f);
                }

                radius -= strokeWidth / 2;




                var path = new Path();
                path.AddCircle(Width / 2.0f, Height / 2.0f, radius, Path.Direction.Ccw);


                canvas.Save();
                canvas.ClipPath(path);



                var paint = new Paint();
                paint.AntiAlias = true;
                paint.SetStyle(Paint.Style.Fill);
                paint.Color = ((CircleImage)Element).FillColor.ToAndroid();
                canvas.DrawPath(path, paint);
                paint.Dispose();


                var result = base.DrawChild(canvas, child, drawingTime);

                canvas.Restore();

                path = new Path();
                path.AddCircle(Width / 2, Height / 2, radius, Path.Direction.Ccw);


                if (strokeWidth > 0.0f)
                {
                    paint = new Paint();
                    paint.AntiAlias = true;
                    paint.StrokeWidth = strokeWidth;
                    paint.SetStyle(Paint.Style.Stroke);
                    paint.Color = ((CircleImage)Element).BorderColor.ToAndroid();
                    canvas.DrawPath(path, paint);
                    paint.Dispose();
                }

                path.Dispose();
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Unable to create circle image: " + ex);
            }

            return base.DrawChild(canvas, child, drawingTime);
        }




















        private static float? _startRawX;
        private float _startingX;

        private static float startX;
        private static float endX;


        private static float? _startRawY;
        private float _startingY;

        private static float startY;
        private static float endY;



        float differenceX;
        float differenceY;

        /// <summary>
        /// Обработчик прикосновения
        /// </summary>
        /// <param name="e"> координаты прикосновения </param>
        /// <returns></returns>
        public override bool OnTouchEvent(MotionEvent e)
        {
            if (_startRawX == null)
            {
                _startRawX = e.RawX;
                _startingX = GetX();

                _startRawY = e.RawY;
                _startingY = GetY();
            }
            
            switch (e.Action)
            {
                case MotionEventActions.Down:
                    startX = e.GetX();
                    startY = e.GetY();
                    break;

                case MotionEventActions.Move:

                    endX = e.GetX();
                    differenceX = endX - startX;
                    
                    endY = e.GetY();
                    differenceY = endY - startY;


                    //this.TranslationX = differenceX;
                    //this.TranslationY = differenceY;

                    MainElement.DoDownPlanet((int)differenceX, (int)differenceY);


                    break;

                case MotionEventActions.Up:
                    //this.TranslationX = _startingX;
                    //this.TranslationY = _startingY;

                    //MainElement.DoRelisePlanet((int)differenceX, (int)differenceY);
                    MainElement.DoRelisePlanet((int)endX, (int)endY);

                    //Animate().X(_startingX).Start();
                    //Animate().Y(_startingY).Start();
                    break;

                default:
                    break;
            }
            return true;
        }
    }
}
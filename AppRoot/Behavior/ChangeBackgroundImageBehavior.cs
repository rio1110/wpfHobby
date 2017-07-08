using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Behavior
{
    public class ChangeBackgroundImageBehavior
    {
        public static readonly DependencyProperty NormalBackgroundImageProperty =
        DependencyProperty.RegisterAttached("NormalBackgroundImage", typeof(ImageSource), typeof(ChangeBackgroundImageBehavior));

        public static readonly DependencyProperty PressedBackgroundImageProperty =
            DependencyProperty.RegisterAttached("PressedBackgroundImage", typeof(ImageSource), typeof(ChangeBackgroundImageBehavior));

        public static ImageSource GetNormalBackgroundImage(DependencyObject obj)
        {
            return (ImageSource)obj.GetValue(NormalBackgroundImageProperty);
        }

        public static void SetNormalBackgroundImage(DependencyObject obj, ImageSource value)
        {
            obj.SetValue(NormalBackgroundImageProperty, value);
        }

        public static ImageSource GetPressedBackgroundImage(DependencyObject obj)
        {
            return (ImageSource)obj.GetValue(PressedBackgroundImageProperty);
        }

        public static void SetPressedBackgroundImage(DependencyObject obj, ImageSource value)
        {
            obj.SetValue(PressedBackgroundImageProperty, value);
        }
    }
}

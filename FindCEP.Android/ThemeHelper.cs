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
using FindCEP.Styles;
using Xamarin.Forms;
using static FindCEP.App;

[assembly: Dependency(typeof(FindCEP.Droid.ThemeHelper))]
namespace FindCEP.Droid
{
    public class ThemeHelper : IAppTheme
    {
        public void SetAppTheme(App.Theme theme)
        {
            SetTheme(theme);
        }
        void SetTheme(Theme mode)
        {
            if (mode == Theme.Dark)
            {
                if (App.AppTheme == Theme.Dark)
                    return;
                App.Current.Resources = new TemaEscuro();
            }
            else
            {
                if (App.AppTheme != Theme.Dark)
                    return;
                App.Current.Resources = new TemaClaro();
            }
            App.AppTheme = mode;
        }
    }
}
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace April_Exam
{
    public partial class App : Application
    {
        public static int Input1;
        public static int Input2;
        public static ListItem[] ListItems;
        public static ulong total;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

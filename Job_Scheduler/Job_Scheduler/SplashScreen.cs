using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Job_Scheduler
{
   public class SplashScreen : ContentPage
    {
        // image variable
        Image splashImage;

        public SplashScreen()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            // layout object
            var sub = new AbsoluteLayout();
            splashImage = new Image
            {
                Source = "splashscreenLogo.png",// image source
                WidthRequest = 100,
                HeightRequest = 100 // size
            };
            // setting layout
            AbsoluteLayout.SetLayoutFlags(splashImage, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashImage, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            sub.Children.Add(splashImage);
            this.BackgroundColor = Color.White;
            this.Content = sub;
        }
        // on appera function which handles the splash screen animation effect
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await splashImage.ScaleTo(18, 2500); //time consuming process such as  initialization
            await splashImage.ScaleTo(5, 3200, Easing.Linear);// first perameter is the scale size and 2nd is the time in miliseconds
            Application.Current.MainPage = new NavigationPage(new MainPage());// after splash screen it gets nevigated to main page
        }
    }
}

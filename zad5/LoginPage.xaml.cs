using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace zad5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage :ContentPage
    {
        public LoginPage ()
        {
            InitializeComponent( );         
            var welcomeLabel = new Label
            {
                StyleId = "header",
                Text = "Добро пожаловать",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            var usernameEntry = new Entry
            {
                Placeholder = "Ваш логин",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                StyleId = "styleforIvansk"

            };

            var passwordEntry = new Entry
            {
                Placeholder = "Ваш пароль",
                IsPassword = true,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                StyleId = "styleforIvansk"
            };

            var rememberMeRadioButton = new RadioButton
            {
                Content = "Запомнить меня",
                HorizontalOptions = LayoutOptions.Start,
                BackgroundColor = Color.White,
                
                
                
            };

            var signInButton = new Button
            {
                Text = "Войти",
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            var signInLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    rememberMeRadioButton,
                    signInButton,
                    new Label{ Text = "Я забыл!", HorizontalOptions = LayoutOptions.End }
                }
            };

            var errorMessageLabel = new Label
            {
                TextColor = Color.Red,
                HorizontalOptions = LayoutOptions.Center
            };
            var moneyBut = new Button
            {
                Text = "Деньги",
                HorizontalOptions = LayoutOptions.FillAndExpand,

            };

            moneyBut.Clicked += (sender, e) =>
            {
                string username = usernameEntry.Text;
                Navigation.PushAsync(new Money(username));
            };

            signInButton.Clicked += (sender, e) =>
            {

                if ( string.IsNullOrWhiteSpace(usernameEntry.Text) || string.IsNullOrWhiteSpace(passwordEntry.Text) )
                {
                    errorMessageLabel.Text = "Введите логин и пароль";
                }
                else
                {

                    string username = usernameEntry.Text;
                    string password = passwordEntry.Text;


                    Navigation.PushAsync(new MainPage(username));
                }
            };


            var stackLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(30),
                Children =
                {
                    welcomeLabel,
                    usernameEntry,
                    passwordEntry,
                    signInButton,
                    errorMessageLabel,
                    rememberMeRadioButton,
                    signInLayout,
                    moneyBut


                }
            };


            Content = stackLayout;



        }
    }
}
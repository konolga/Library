//using System.Linq;
using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using static Library.App;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Library
{
    /// <summary>
    ///     First page related to user login, reset password, create account. Admin also login from this page.
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private void LoginClick(object sender, RoutedEventArgs e)
        {
            //do check username and password
            //do forward to the library page
            var username = UsernameSignInBox.Text;
            if (userManager.Login(username, PasswordSignInBox.Text))
            {
                if (userManager.IssAdmin(username)) //check if admin or not
                    Frame.Navigate(typeof(AdminPage1)); //login to admin library page
                else
                    Frame.Navigate(typeof(UserPage1)); //login to user library page
            }
            else
            {
                MessageBlock.Visibility = Visibility.Visible;
                MessageBlock.Text = "Wrong data submitted";
                MessageBlock.Foreground = new SolidColorBrush(Colors.Crimson);
            }
        }

        private void ForgotPasswordClick(object sender, RoutedEventArgs e)
        {
            LoginPanel.Visibility = Visibility.Collapsed;
            CreateAccountPanel.Visibility = Visibility.Collapsed;
            ResetPasswordPanel.Visibility = Visibility.Visible;
        }

        private void ResetPasswordClick(object sender, RoutedEventArgs e)
        {
            var username = UsernameResetBox.Text;
            ;
            if (userManager.ConfirmUser(username, IDResetBox.Text,
                Convert.ToDateTime(DOBResetBox.Date.ToString("MM,dd,yyyy"))))
            {
                ResetPasswordPanel.Visibility = Visibility.Collapsed;
                SetNewPasswordPanel.Visibility = Visibility.Visible;
                MessageBlock.Visibility = Visibility.Collapsed;
            }
            else
            {
                MessageBlock.Visibility = Visibility.Visible;
                MessageBlock.Text = "Wrong data submitted, try again!";
                MessageBlock.Foreground = new SolidColorBrush(Colors.Crimson);
            }
        }

        private void SetNewPasswordClick(object sender, RoutedEventArgs e)
        {
            if (userManager.ResetPassword(userManager.GetCurrentUser(), PasswordResetBox.Text))
            {
                SetNewPasswordPanel.Visibility = Visibility.Collapsed;
                LoginPanel.Visibility = Visibility.Visible;
                MessageBlock.Text = "Password changed successfully!";
                MessageBlock.Foreground = new SolidColorBrush(Colors.RoyalBlue);
                UsernameSignInBox.Text = "";
                PasswordSignInBox.Text = "";
            }
        }

        private void SignupClick(object sender, RoutedEventArgs e)
        {
            if (userManager.CreateUser(UsernameSignUpBox.Text, PasswordSignUpBox.Text, false, IDSignUpBox.Text,
                Convert.ToDateTime(DOBSignUpBox.Date.ToString("MM,dd,yyyy"))))
            {
                CreateAccountPanel.Visibility = Visibility.Collapsed;
                MessageBlock.Foreground = new SolidColorBrush(Colors.RoyalBlue);
                MessageBlock.Text = "User created successfully!";

            }
            else
                MessageBlock.Text = "User already exists, you may login or reset password";
                MessageBlock.Foreground = new SolidColorBrush(Colors.Crimson);
        }
    }
}
using System;
using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using ClassLibrary;
using static Library.App;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Library
{

    /// <summary>
    ///    //Hereunder all methods related to the buttons at Admin Page (search, reset password, create user)
    /// </summary>
    public sealed partial class AdminPage1 : Page
    {
        private List<User> _searchResultList = new List<User>();
        private DateTimeOffset defaultDate = DateTimeOffset.Parse("01/01/1917");
        public AdminPage1()
        {
            InitializeComponent();
            pageTitle.Text = App.userManager.GetCurrentUser().Username + ", welcome to the Library!";
        }

        private void DisplayUsers(List<User> searchResultList)
        {
            if (ListUsers.Items != null)
            {
                ListUsers.ItemsSource = null;
            }
            ListUsers.ItemsSource = searchResultList;
        }

        private void Exit_Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage)); //Go to main page
        }

        private void Users_All_Show_Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            _searchResultList = userManager.ShowAllUsers();
            DisplayUsers(_searchResultList);
        }

        private void Reset_Password_Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

            User user = userManager.ShowAllUsers().Find(
                delegate(User delUser)
                {
                    return delUser == ListUsers.SelectedItem;
                });

            userManager.ResetPassword(user, "default");
            DisplayUsers(_searchResultList);
        }

        private void Create_Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            CreateFormGrid.Visibility=Visibility.Visible;
            SearchFormdGrid.Visibility = Visibility.Collapsed;
        }

        private void Create_User_Click(object sender, RoutedEventArgs e)
        {
            if (userManager.CreateUser(UsernameSignUpBox.Text, PasswordSignUpBox.Text, false, IDSignUpBox.Text,
                Convert.ToDateTime(DOBSignUpBox.Date.ToString("MM,dd,yyyy"))))
            {
                FreeText.Text = "User created successfully";
                FreeText.Foreground = new SolidColorBrush(Colors.RoyalBlue);
            }
            else
            {
                FreeText.Text = "User already exists";
                FreeText.Foreground = new SolidColorBrush(Colors.Crimson);
            }
            DisplayUsers(userManager.ShowAllUsers());
        }

        private void Remove_Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

            User user = userManager.ShowAllUsers().Find(
                delegate (User delUser)
                {
                    return delUser == ListUsers.SelectedItem;
                });

            userManager.DeleteUser(user.Username);
            DisplayUsers(userManager.ShowAllUsers());
        }

        private void Search_Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            CreateFormGrid.Visibility = Visibility.Collapsed;
            SearchFormdGrid.Visibility = Visibility.Visible;

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var caseSwitch = "Nothing";
            _searchResultList.Clear();
            var _nameSearchResultList = new List<User>();
            var _dateSearchResultList = new List<User>();
            var _IdSearchResultList = new List<User>();

            _nameSearchResultList = userManager.SearchUserByUsername(SearchByNameBox.Text);
            _dateSearchResultList = userManager.SearchUserByDate(Convert.ToDateTime(SearchByDateBox.Date.ToString("MM,dd,yyyy")));
            _IdSearchResultList = userManager.SearchUserById(SearchByIdBox.Text);

            if (SearchByNameBox.Text != "" && SearchByDateBox.Date.Date != defaultDate.Date &&
                SearchByIdBox.Text != "")
                caseSwitch = "NameDateId";
            else if (SearchByNameBox.Text != "" && SearchByDateBox.Date.Date != defaultDate.Date)
                caseSwitch = "NameDate";
            else if (!SearchByDateBox.Date.Date.Equals(defaultDate.Date) && SearchByIdBox.Text != "")
                caseSwitch = "DateId";
            else if (SearchByNameBox.Text != "" && SearchByIdBox.Text != "")
                caseSwitch = "NameId";
            else if (SearchByNameBox.Text != "")
                caseSwitch = "NameOnly";
            else if (SearchByDateBox.Date.Date != defaultDate.Date)
                caseSwitch = "DateOnly";
            else if (SearchByIdBox.Text != "")
                caseSwitch = "IdOnly";

            switch (caseSwitch)
            {
                case "nothing":
                    break;
                case "NameDateId":

                    foreach (var itemN in _nameSearchResultList)
                        foreach (var itemD in _dateSearchResultList)
                            foreach (var itemC in _IdSearchResultList)
                                if (itemN.GetHashCode() == itemD.GetHashCode() &&
                                    itemD.GetHashCode() == itemC.GetHashCode())
                                    _searchResultList.Add(itemN);
                    break;


                case "NameDate":
                    foreach (var itemN in _nameSearchResultList)
                        foreach (var itemD in _dateSearchResultList)
                            if (itemN.GetHashCode() == itemD.GetHashCode())
                                _searchResultList.Add(itemN);
                    break;


                case "DateId":
                    foreach (var itemD in _dateSearchResultList)
                        foreach (var itemC in _IdSearchResultList)
                            if (
                                itemD.GetHashCode() == itemC.GetHashCode())
                                _searchResultList.Add(itemD);
                    break;


                case "NameId":
                    foreach (var itemN in _nameSearchResultList)
                        foreach (var itemC in _IdSearchResultList)
                            if (itemN.GetHashCode() == itemC.GetHashCode())
                                _searchResultList.Add(itemN);
                    break;


                case "NameOnly":
                    _searchResultList = _nameSearchResultList;
                    break;

                case "DateOnly":
                    _searchResultList = _dateSearchResultList;
                    break;

                case "IdOnly":
                    _searchResultList = _IdSearchResultList;
                    break;
            }
            DisplayUsers(_searchResultList);
        }

    }
}
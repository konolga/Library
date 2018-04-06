using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ClassLibrary;
using static Library.App;



namespace Library
{
    /// <summary>
    ///     //Hereunder all methods related to the buttons at userpage (rearch, take item, retun, exit etc.)
    /// </summary>
    public sealed partial class UserPage1 : Page
    {
        private List<AbstractItem> _searchResultList = new List<AbstractItem>();
        private DateTimeOffset defaultDate = DateTimeOffset.Parse("01/01/1917");

        public UserPage1()
        {
            InitializeComponent();
            pageTitle.Text = userManager.GetCurrentUser().Username + ", welcome to the Library!";
            SearchByDateBox.Date = defaultDate;
            GenreComboBox.Items.Add("Book");
            GenreComboBox.Items.Add("Journal");
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            SearchFormdGrid.Visibility = Visibility.Visible;
        }

        private void GenreComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CategoryComboBox.Items.Clear();
            //var genre = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
            string genre = GenreComboBox.SelectedItem.ToString();
            if (genre == "Book")
                foreach (var item in Enum.GetValues(typeof(Book.Category)))
                    CategoryComboBox.Items.Add(item);
            else if (genre == "Journal")
                foreach (var item in Enum.GetValues(typeof(Journal.Category)))
                    CategoryComboBox.Items.Add(item);
        }

        private void DisplayLibraryItems(List<AbstractItem> searchResultList)
        {
            if (ListItems.Items != null)
            {
                ListItems.ItemsSource=null;
            }
            ListItems.ItemsSource = searchResultList;

            //foreach (AbstractItem item in searchResultList)
            // {
            //     ListItems.Items.Add(" Name:'" + item.Name + "', Quantity:" + item.Quantity);

            // }
        }

        private void DisplayUserItems(List<AbstractItem> userItemsList)
        {
            if (UserItems.Items != null)
            {
                UserItems.ItemsSource = null;
            }
            UserItems.ItemsSource = userItemsList;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var caseSwitch = "Nothing";
            _searchResultList.Clear();
            var _nameSearchResultList = new List<AbstractItem>();
            var _dateSearchResultList = new List<AbstractItem>();
            var _categorySearchResultList = new List<AbstractItem>();

            _nameSearchResultList = libraryManager.SearchItemByName(SearchByNameBox.Text);
            _dateSearchResultList =
                libraryManager.SearchItemByPrintDate(
                    Convert.ToDateTime(SearchByDateBox.Date.ToString("MM,dd,yyyy")));
            if (GenreComboBox.SelectedItem != null)
            {
                if (CategoryComboBox.SelectedItem != null)
                {
                    _categorySearchResultList =
                        //new List<AbstractItem>(libraryManager.SearchItemByCategory(GenreComboBox.SelectedItem.ToString(), CategoryComboBox.SelectedItem.ToString()));
                        libraryManager.SearchItemByCategory(GenreComboBox.SelectedItem.ToString(), CategoryComboBox.SelectedItem.ToString());

                    if (SearchByNameBox.Text != "" && SearchByDateBox.Date.Date != defaultDate.Date &&
                        CategoryComboBox.SelectedItem != null)
                        caseSwitch = "NameDateCategory";
                    else if (SearchByNameBox.Text != "" && SearchByDateBox.Date.Date != defaultDate.Date)
                        caseSwitch = "NameDate";
                    else if (!SearchByDateBox.Date.Date.Equals(defaultDate.Date) && CategoryComboBox.SelectedItem != null)
                        caseSwitch = "DateCategory";
                    else if (SearchByNameBox.Text != "" && CategoryComboBox.SelectedItem != null)
                        caseSwitch = "NameCategory";
                    else if (SearchByNameBox.Text != "")
                        caseSwitch = "NameOnly";
                    else if (SearchByDateBox.Date.Date != defaultDate.Date)
                        caseSwitch = "DateOnly";
                    else if (CategoryComboBox.SelectedItem != null)
                        caseSwitch = "CategoryOnly";
                }
            }

            switch (caseSwitch)
            {
                case "nothing":
                    break;

                case "NameDateCategory":
                    foreach (var itemN in _nameSearchResultList)
                    foreach (var itemD in _dateSearchResultList)
                    foreach (var itemC in _categorySearchResultList)
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

                case "DateCategory":
                    foreach (var itemD in _dateSearchResultList)
                    foreach (var itemC in _categorySearchResultList)
                        if (
                            itemD.GetHashCode() == itemC.GetHashCode())
                            _searchResultList.Add(itemD);
                    break;

                case "NameCategory":

                    foreach (var itemN in _nameSearchResultList)
                    foreach (var itemC in _categorySearchResultList)
                        if (itemN.GetHashCode() == itemC.GetHashCode())
                            _searchResultList.Add(itemN);
                    break;

                case "NameOnly":
                    _searchResultList = _nameSearchResultList;
                    break;

                case "DateOnly":
                    _searchResultList = _dateSearchResultList;
                    break;

                case "CategoryOnly":
                    _searchResultList = _categorySearchResultList;
                    break;
            }
            DisplayLibraryItems(_searchResultList);
        }

        private void Take_Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in _searchResultList)
                if (item.Equals(ListItems.SelectedItem))
                    libraryManager.TakeItem(item);
            DisplayLibraryItems(_searchResultList); //update search result list with smaller quantity
            DisplayUserItems(libraryManager.SearchAllTakenItems());
        }

        private void Return_Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in libraryManager.SearchAllTakenItems())
                if (item.Equals(UserItems.SelectedItem))
                    libraryManager.ReturnItem(item);
            DisplayLibraryItems(_searchResultList); //update search result list with smaller quantity
            DisplayUserItems(libraryManager.SearchAllTakenItems());
        }

        private void Journals_All_Show_Button_Click(object sender, RoutedEventArgs e)
        {
            _searchResultList = libraryManager.ShowAllJournals();
            DisplayLibraryItems(_searchResultList);
        }

        private void Books_All_Show_Button_Click(object sender, RoutedEventArgs e)
        {
            _searchResultList = libraryManager.ShowAllBooks();
            DisplayLibraryItems(_searchResultList);
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage)); //Go to main page
        }
    }
}
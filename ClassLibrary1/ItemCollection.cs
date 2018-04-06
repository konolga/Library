using System;
using System.Collections.Generic;
using System.Linq;


namespace ClassLibrary
{
    /// <summary>
    ///     //Implementing all methods from IManageLibrary interface. 
    /// </summary>
    public class ItemCollection : IManageLibrary

    {
        static List<AbstractItem> _items = new List<AbstractItem>();
        static List<AbstractItem> _takenItems = new List<AbstractItem>();

        public List<AbstractItem> SearchItemByName(string name)
        {
            List<AbstractItem> searchResult = new List<AbstractItem>();
            foreach (AbstractItem item in _items)
            {
                if (item.Name.Equals(name))
                {
                    searchResult.Add(item);
                }

            }
            return searchResult;
        }

        public List<AbstractItem> SearchItemByPrintDate(DateTime printDate)
        {
            List<AbstractItem> searchResult = new List<AbstractItem>();
            foreach (AbstractItem item in _items)
            {
                if (item.Printdate.Equals(printDate))
                {
                    searchResult.Add(item);
                }
            }
            return searchResult;
        }

        public List<AbstractItem> SearchItemByCategory(string genre, string category)
        {
            List<AbstractItem> searchResult = new List<AbstractItem>();
            if (genre == "Book")
            {
                foreach (Book item in _items.OfType<Book>())
                {
                    if (item.category.ToString().Equals(category))
                    {
                        searchResult.Add(item);
                    }
                }
            }
            else if (genre.Equals("Journal"))
            {
                foreach (Journal item in _items.OfType<Journal>())
                {
                    if (item.category.ToString().Equals(category))
                    {
                        searchResult.Add(item);
                    }
                }
            }

            return searchResult;
        }

        public List<AbstractItem> SearchAllTakenItems()
        {
            if (_takenItems != null)
            {
                _takenItems.Clear();
            }
            foreach (AbstractItem item in _items)
            {
                if (item.QtNotAvaliable > 0)
                {
                    _takenItems.Add(item);
                }
            }
            return _takenItems;
        }

        public void TakeItem(AbstractItem itemToTake)
        {
                foreach (AbstractItem item in _items)
                {
                    if (item.Equals(itemToTake)&&item.QtAvaliable > 0)
                    {
                        item.QtAvaliable--;
                        item.QtNotAvaliable++;
                    }
               }
        }

        public void ReturnItem(AbstractItem itemToReturn)
        {
            foreach (AbstractItem item in _items)
            {
                if (item.Equals(itemToReturn) && itemToReturn.QtNotAvaliable > 0)
                {
                    item.QtAvaliable++;
                    item.QtNotAvaliable--;
                }
            }
        }

        public void AddNewBook(int quantity, string name, DateTime printdate, Book.Category category)
        {
            Book book = new Book(quantity, name, printdate, category);
            _items.Add(book);
        }

        public void AddNewJournal(int quantity, string name, DateTime printdate, Journal.Category category)
        {
            Journal journal = new Journal(quantity, name, printdate, category);
            _items.Add(journal);
        }

        public List<AbstractItem> ShowAllItems()
        {
            return _items;
        }

        public List<AbstractItem> ShowAllJournals()
        {
            List<AbstractItem> searchResult = new List<AbstractItem>();
            foreach (Journal item in _items.OfType<Journal>())
            {
                searchResult.Add(item);
            }
            return searchResult;
        }

        public List<AbstractItem> ShowAllBooks()
        {
            List<AbstractItem> searchResult = new List<AbstractItem>();
            foreach (Book item in _items.OfType<Book>())
            {
                searchResult.Add(item);
            }
            return searchResult;
        }
    }
}

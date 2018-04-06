using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    ///     interface to manage library 
    /// </summary>
    interface IManageLibrary
    {
        List<AbstractItem> SearchItemByName(string name);

        List<AbstractItem> SearchItemByPrintDate(DateTime printDate);

        List<AbstractItem> SearchItemByCategory(string genre, string category);

        List<AbstractItem> SearchAllTakenItems();

        void TakeItem(AbstractItem itemToTake);

        void ReturnItem(AbstractItem itemToReturn);

        void AddNewBook(int quantity, string name, DateTime printdate, Book.Category category);

        void AddNewJournal(int quantity, string name, DateTime printdate, Journal.Category category);

        List<AbstractItem> ShowAllItems();

        List<AbstractItem> ShowAllJournals();

        List<AbstractItem> ShowAllBooks();

    }
}

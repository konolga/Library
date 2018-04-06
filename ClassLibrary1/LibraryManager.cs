using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    ///     //Library itself. Also Library manager inherits ItemCollection with all methods.
    /// </summary>
    public class LibraryManager:ItemCollection
    {
        public LibraryManager() : base()
        {

            AddNewBook(2, "alfa", new DateTime(2017,01,01), Book.Category.Cooking);
            AddNewBook(3, "beta", new DateTime(2016, 01, 01), Book.Category.Reading);
            AddNewBook(4, "gamma", new DateTime(2015, 01, 01), Book.Category.Textbook);
            AddNewBook(2, "delta", new DateTime(2017, 01, 01), Book.Category.Cooking);
            AddNewBook(3, "epsilon", new DateTime(2016, 01, 01), Book.Category.Reading);
            AddNewBook(4, "zeta", new DateTime(2015, 01, 01), Book.Category.Textbook);

            AddNewJournal(2, "eta", new DateTime(2017, 01, 01), Journal.Category.Cooking);
            AddNewJournal(3, "theta", new DateTime(2016, 01, 01), Journal.Category.Design);
            AddNewJournal(4, "iota", new DateTime(2015, 01, 01), Journal.Category.Politics);
            AddNewJournal(2, "kappa", new DateTime(2017, 01, 01), Journal.Category.Cooking);
            AddNewJournal(3, "lambda", new DateTime(2016, 01, 01), Journal.Category.Design);
            AddNewJournal(4, "mu", new DateTime(2015, 01, 01), Journal.Category.Politics);

            List<AbstractItem> listOfItems = ShowAllItems();
        }
    }
}

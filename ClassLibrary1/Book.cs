using System;

namespace ClassLibrary
{
    public  class Book:AbstractItem
    {

        private Guid _isbn;
        private Category _category;

        public Guid ISBN
        {
            get { return this._isbn; }
            set { this._isbn  =value;}
    }


        public Category category
        {
            get { return this._category; }
            set { this._category = value; }
        }

        public enum Category
        {
            Textbook = 0,
            Reading = 1,
            Cooking = 2
        }


        public Book (int quantity, string name, DateTime printdate, Category category):base(quantity, name, printdate)
        {
            this._isbn=Guid.NewGuid();
            this._category = category;
        }


    }
}

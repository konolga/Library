using System;

namespace ClassLibrary
{
    public abstract class AbstractItem
    {

        private int _quantity;
        private string _name;
        private DateTime _printdate;
        private int _qtAvaliable;
        private int _qtNotAvaliable;

        public int Quantity { get { return this._quantity; } set { this._quantity = value; }  }
        public string Name { get { return this._name; } set { this._name = value; } }
        public DateTime Printdate { get { return this._printdate; } set { this._printdate = value; } }

        public int QtAvaliable { get { return this._qtAvaliable; } set { this._qtAvaliable = value; } }
        public int QtNotAvaliable { get { return this._qtNotAvaliable; } set { this._qtNotAvaliable = value; } }

        public AbstractItem (int quantity, string name, DateTime printdate)
        {
            this._quantity = quantity;
            this._name = name;
            this._printdate=printdate;
            _qtAvaliable = quantity;
            _qtNotAvaliable = 0;

        }
    }
}

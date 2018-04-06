using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Journal:AbstractItem 
    {
        private Category _category;
        public Category category
        {
            get { return this._category; }
            set { this._category = value; }
        }

        public enum Category
        {
            Politics=0,
            Design=1,
            Cooking=2
        }

        public Journal(int quantity, string name, DateTime printdate, Category category) : base(quantity, name, printdate)
        {
            this._category = category;

        }


    }
}

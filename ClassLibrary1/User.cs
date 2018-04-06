using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
   public class User
    {
        private string _username;
        private string _password;
        private bool _isAdmin;
        private string _id;
        private DateTime _dateOfBirth;

        public string Username
        {
            get
            {
                return this._username;
            }
            set
            {
                this._username = value;
            }
        }


        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                this._password = value;
            }
        }


        public bool IsAdmin
        {
            get
            {
                return this._isAdmin;
            }
            set
            {
                this._isAdmin = value;
            }
        }

        public string ID
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return this._dateOfBirth;
            }
            set
            {
                this._dateOfBirth = value;
            }
        }

        public User()
        {
            
        }

        public User(string username, string password, bool isAdmin, string id, DateTime dateOfBirth)
        {
            this._username=username;
            this._password=password;
            this._isAdmin = isAdmin;
            this._id = id;
            this._dateOfBirth = dateOfBirth;
        }
    }
}

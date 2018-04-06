using System;
using System.Collections.Generic;

namespace ClassLibrary
{

    /// <summary>
    ///     //Implementing all methods from IManageUsers interface. 
    /// </summary>
    /// 
    public class UserCollection : IManageUsers

    {

     static List<User> _users = new List<User>();
    public User currentUser = new User();


    public bool ConfirmUser(string userName, string id, DateTime dateOfBirth)
        {
            User user = _users.Find(
                delegate (User delUser)
                {
                    return delUser.Username == userName;
                }
            );
            if (user != null) //user found
            {
                if (user.ID == id && user.DateOfBirth == dateOfBirth)
                {
                    currentUser = user;
                    return true; //all details are confirmed
                }
            }
            return false;
        }

        public bool CreateUser(string userName, string password, bool isAdmin, string id, DateTime dateOfBirth)
        {
            if (!ConfirmUser(userName, id, dateOfBirth)) //user with same details not found
            {
                User user = new User(userName, password, isAdmin, id, dateOfBirth);
                _users.Add(user);
                currentUser = user;
                return true;
            }
            else return false; //user is already in database
        }

        public bool DeleteUser(string userName)
        {
            User user = _users.Find(
                delegate (User delUser)
                {
                    return delUser.Username == userName;
                }
            );
            if (user != null) //user found
            {
                _users.Remove(user);
                return true; //user found and removed
            }
            else return false; //user not found
        }

        public bool Login(string userName, string password)
        {
            User user = _users.Find(
                delegate (User delUser)
                {
                    return delUser.Username == userName;
                }
            );
            if (user != null) //user found
            {
                if (user.Password == password)
                {
                    currentUser = user;
                    return true; //correct password provided
                }
            }
            return false;
        }

        public bool ResetPassword(User user, string newPassword)
        {

            if (user != null) //user found, password changed
            {
                user.Password = newPassword;
                return true;
            }
            else //user not found, password wasn't changed
            {
                return false;
            }
        }

        public bool IssAdmin(string userName)
        {
            User user = _users.Find(
                delegate (User delUser)
                {
                    return delUser.Username == userName;
                }
            );
            if (user != null) //user found
            {
                return user.IsAdmin; //user found
            }
            else return false; //user not found
        }

        public User GetCurrentUser()
        {
            return currentUser;
        }

        public List<User> ShowAllUsers()
        {
            List<User> searchResult = new List<User>();
            foreach (User user in _users)
            {
                if (!user.IsAdmin)
                {
                    searchResult.Add(user);
                }
            }
            return searchResult;
        }

        public List<User> SearchUserByUsername(string username)
        {
            List<User> searchResult = new List<User>();
            foreach (User user in _users)
            {
                if (user.Username.Equals(username))
                {
                    searchResult.Add(user);
                }

            }
            return searchResult;
        }

        public List<User> SearchUserByDate(DateTime date)
        {
            List<User> searchResult = new List<User>();
            foreach (User user in _users)
            {
                if (user.DateOfBirth.Equals(date))
                {
                    searchResult.Add(user);
                }
            }
            return searchResult;
        }

        public List<User> SearchUserById(string id)
        {
            List<User> searchResult = new List<User>();
            foreach (User user in _users)
            {
                if (user.ID.Equals(id))
                {
                    searchResult.Add(user);
                }
            }
            return searchResult;

        }

    }
}

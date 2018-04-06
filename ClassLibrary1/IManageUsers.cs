using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    ///     interface to manage users 
    /// </summary>
    interface IManageUsers
    {

        bool ResetPassword(User user, string newPassword);

        bool Login(string userName, string password);

        bool CreateUser(string userName, string password, bool isAdmin, string id, DateTime dateOfBirth);

        bool ConfirmUser(string userName, string id, DateTime dateOfBirth);

        bool DeleteUser(string userName);

        User GetCurrentUser();

        List <User> ShowAllUsers();

        bool IssAdmin(string userName);

        List<User> SearchUserByUsername(string username);

        List<User> SearchUserByDate(DateTime date);

        List<User> SearchUserById(string id);
    }
}

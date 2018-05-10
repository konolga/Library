using System;
using System.Collections.Generic;


namespace ClassLibrary
{
    /// <summary>
    ///     Data about all current users. Also UserManager inherits UserCollection with all methods.
    /// </summary>
    public class UserManager: UserCollection
    {
        public UserManager() : base()
        {
            List < User > listOfUsers= new List<User>();
            CreateUser("1", "1", false, "125124", new DateTime(2008, 04, 14));
            CreateUser("user2", "user2", false, "125124", new DateTime(2008, 04, 14));
            CreateUser("admin", "admin", true, "125126", new DateTime(2008, 04, 14));
            CreateUser("user3", "user3", false, "125124", new DateTime(2008, 04, 14));
            CreateUser("user", "user", false, "125124", new DateTime(2008,04,14));
           
        }
    }
}

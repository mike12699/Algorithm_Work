using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class ArraysandDictionaries
    {
        Users user1;
        Users user2;
        Users user3;


        //Calls over all of the variables listed in class "Users"
        public ArraysandDictionaries()
        {
            user1 = new Users()
            {
                UserID = 1,
                FirstName = "Michael",
                LastName = "Bobs"
            };

            user2 = new Users()
            {
                UserID = 2,
                FirstName = "John",
                LastName = "Doe"
            };

            user3 = new Users()
            {
                UserID = 3,
                FirstName = "Jack",
                LastName = "Thomas"
            };
        }

        
        //Calls over a dictionary of users in class "Users"
        public void DictionaryFunction()
        {
            var users = new Dictionary<int, Users>();
            users.Add(user1.UserID, user1);
            users.Add(user2.UserID, user2);
            users.Add(user3.UserID, user3);

            foreach (var user in users)
            {
                Console.WriteLine($"User: {user.Key} {user.Value.FirstName} {user.Value.LastName}");
            }
        }


        //Calls over an array of users in class "Users"
        public void ArrayFunction()
        {
            Users[] users = new Users[3];

            users[0] = user1;
            users[1] = user2;
            users[2] = user3;

            for (int i = 0; i < 3; i++)
            {
                var user = users[i];
                Console.WriteLine($"User: {user.UserID} {user.FirstName} {user.LastName}");
            }
        }
    }


    //Variables to be listed for the Users
    public class Users
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

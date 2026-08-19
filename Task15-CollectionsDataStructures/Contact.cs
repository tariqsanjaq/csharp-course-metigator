using System;
using System.Collections.Generic;
using System.Text;

namespace Task15_CollectionsDataStructures
{
    internal class Contact
    {
        private readonly int _id;
        private  string _name;
        private string _email;
        private string _city;

        public int Id { get { return _id; } }
        public string Name { get { return _name; } private set { _name = value; } }
        public string Email { get { return _email; } private set { _email = value; } }
        public string City { get { return _city; } private set { _city = value; } }

        public Contact(int id, string name, string email, string city)
        {
           _id = id;
            Name = name;
            Email = email;
            City = city;
            
        }

        public override string ToString()
        {
            return $"id : {Id} , name : {Name} , email : {Email} , city : {City}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is Contact other)
            {
                return string.Equals(Email, other.Email, StringComparison.OrdinalIgnoreCase) ;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(Email);
        }

    }
}

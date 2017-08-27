using System;

namespace ClassLibrary1
{
    [Serializable]
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int age { get; set; }

        public Person(string i, string s, int k)
        {
            FirstName = i;
            LastName = s;
            age = k;
        }
    }
}

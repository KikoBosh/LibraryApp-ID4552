using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryAppConcept.Models
{
    public class Client
    {
        

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string LibraryId { get; set; }

        public Client() { }


        public Client(int id, string name, int age, string libraryId)
        {
            Id = id;
            Name = name;
            Age = age;
            LibraryId = libraryId;
        }
    }
}
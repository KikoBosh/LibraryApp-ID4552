using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryAppConcept.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Photo { get; set; }
        public int YearOfPublishing { get; set; }

        public Book() { }

        public Book(int id, string name, string author, string photo, int yearOfPublishing)
        {
            Id = id;
            Name = name;
            Author = author;
            Photo = photo;
            YearOfPublishing = yearOfPublishing;
        }
    }
}

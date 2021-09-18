﻿namespace Core.Entities
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Pages { get; set; }
        public string Isbn { get; set; }
        public Author Author { get; set; }
        public Publisher Publisher { get; set; }
    }
}
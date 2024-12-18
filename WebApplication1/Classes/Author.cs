﻿using System.Diagnostics.Eventing.Reader;
using static System.Reflection.Metadata.BlobBuilder;

namespace WebApplication1.Classes
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
    }
}

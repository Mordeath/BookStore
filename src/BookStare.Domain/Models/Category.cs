﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BookStare.Domain.Models
{
    public class Category : Entity
    {
        public string Name { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}

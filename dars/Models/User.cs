﻿using System;

namespace dars.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return Id + " " + FirstName + " " + LastName + " " + Age + " " + Email;
        }
    }
}

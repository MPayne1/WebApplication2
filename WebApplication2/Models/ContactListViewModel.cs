﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class ContactListViewModel
    {
        public int NumberOfContacts { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}

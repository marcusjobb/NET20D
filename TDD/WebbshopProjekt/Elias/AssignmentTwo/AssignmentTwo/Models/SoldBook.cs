﻿using System;

namespace AssignmentTwo.Models
{
    public class SoldBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }
        public DateTime PurchasedDate { get; set; }
        public int UserId { get; set; }
    }
}
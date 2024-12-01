﻿namespace HenriksHobbyLager.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public int Stock { get; set; } = 0;
        public string Category { get; set; } = string.Empty;
        public DateTime Created { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}

using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class Demand
    {
        public int Id { get; set; }

        public Urgency Urgency { get; set; }
        public string ProcessNumber { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

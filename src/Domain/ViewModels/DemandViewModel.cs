using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.ViewModels
{
    public class DemandViewModel
    {
        public int Id { get; set; }

        public Urgency Urgency { get; set; }
        public string ProcessNumber { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }

        public int? CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}

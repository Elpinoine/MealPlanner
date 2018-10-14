using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MealPlanner.Models
{
    public class Plan
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public List<Food> Foods { get; set; }

        public string Notes { get; set; }
    }
}

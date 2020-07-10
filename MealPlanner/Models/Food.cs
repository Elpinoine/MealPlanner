using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealPlanner.Models
{
    public class Food
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public ICollection<Category> Categories { get; set; }
        // TODO: Add an image or a list of images
    }
}

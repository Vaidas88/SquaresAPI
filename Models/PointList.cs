using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresAPI.Models
{
    public class PointList
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Point> Points { get; set; }
    }
}

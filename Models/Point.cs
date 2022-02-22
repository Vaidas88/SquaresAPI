using System.ComponentModel.DataAnnotations;

namespace SquaresAPI.Models
{
    public class Point
    {
        public int Id { get; set; }

        [Required]
        [Range(-5000, 5000)]
        public int X { get; set; }

        [Required]
        [Range(-5000, 5000)]
        public int Y { get; set; }

        public List<PointList> PointLists { get; set; }
    }
}

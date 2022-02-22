using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresAPI.Dtos
{
    public class PointListDto
    {
        public string Name { get; set; }

        public List<ListPointDto> Points { get; set; }
    }
}

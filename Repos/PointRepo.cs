using Microsoft.EntityFrameworkCore;
using SquaresAPI.Data;
using SquaresAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresAPI.Repos
{
    public class PointRepo
    {
        private DataContext _context;

        public PointRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Point>> GetAll()
        {
            return await _context.Points.ToListAsync();
        }

        public async Task<Point> Insert(Point point)
        {
            _context.Points.Add(point);
            await _context.SaveChangesAsync();
            return point;
        }

        public async Task<Point> GetByXY(int x, int y)
        {
            return await _context.Points.FirstOrDefaultAsync(p => p.X == x && p.Y == y);
        }
    }
}

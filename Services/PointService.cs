using SquaresAPI.Dtos;
using SquaresAPI.Models;
using SquaresAPI.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresAPI.Services
{
    public class PointService
    {
        private PointRepo _pointRepo;

        public PointService(PointRepo pointRepo)
        {
            _pointRepo = pointRepo;
        }

        public async Task<List<PointDto>> GetAll()
        {
            var points = await _pointRepo.GetAll();
            var pointDtos = new List<PointDto>();

            points.ForEach(point => pointDtos.Add(new PointDto()
            {
                Id = point.Id,
                X = point.X,
                Y = point.Y
            }));

            return pointDtos;
        }

        public async Task<PointDto> Insert(PointInsertDto pointInsertDto)
        {
            if (await this.PointExists(pointInsertDto.X, pointInsertDto.Y))
            {
                throw new DuplicateEntryException("Point already exists.");
            }

            var insertedPoint = await _pointRepo.Insert(new Point()
            {
                X = pointInsertDto.X,
                Y = pointInsertDto.Y
            });

            return new PointDto()
            {
                Id = insertedPoint.Id,
                X = insertedPoint.X,
                Y = insertedPoint.Y
            };
        }

        public async Task Import(IFormFile file)
        {
            if (file.Length > 0)
            {
                await ConvertFileToList(file);
            }
        }

        private async Task ConvertFileToList(IFormFile file)
        {
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                string fileLine;
                PointListDto pointList = new PointListDto()
                {
                    Name = file.Name,
                    Points = new List<ListPointDto>()
                };

                while ((fileLine = await reader.ReadLineAsync()) != null)
                {
                    pointList.Points.Add(ConvertLineToListPointDto(fileLine));
                }
            }
        }

        private ListPointDto ConvertLineToListPointDto(string point)
        {
            point = point.Trim();
            var points = point.Split(" ", 2);

            return new ListPointDto()
            {
                X = Convert.ToInt32(points[0]),
                Y = Convert.ToInt32(points[1])
            };
        }

        private async Task<bool> PointExists(int x, int y)
        {
            var pointExists = await _pointRepo.GetByXY(x, y);

            if (pointExists != null)
            {
                return true;
            }

            return false;
        }
    }
}

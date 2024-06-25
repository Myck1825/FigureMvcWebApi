using FigureMvcWebApi.Model.Controllers.ModelLayer.Figure.Database;
using FigureMvcWebApi.Model.Controllers.ModelLayer.Figure.Models;
using FigureMvcWebApi.Model.Controllers.ModelLayer.Figure.Requests;
using FigureMvcWebApi.Model.Database.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace FigureMvcWebApi.Model.Database.Repository
{
    public class RectangleRepository : Repository<Rectangle>
    {
        public RectangleRepository(FigureDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<RectangleResultModek> GetList(int x1, int y1, int x2, int y2, int skip = 0, int take = 0)
        {
            SqlParameter[] sqlParamList = new SqlParameter[6]
            {
                new SqlParameter {ParameterName = "@x1", Value = x1},
                new SqlParameter {ParameterName = "@y1", Value = y1},
                new SqlParameter {ParameterName = "@x2", Value = x2},
                new SqlParameter {ParameterName = "@y2", Value = y2},
                new SqlParameter {ParameterName = "@skip", Value = skip},
                new SqlParameter {ParameterName = "@take", Value = take}
            };
            var result = _dbContext.Database.SqlQuery<RectangleResultModek>("exec dbo.sp_Intersect_Procedure @x1, @y1, @x2, @y2, @skip, @take", sqlParamList);
            return result.ToList();
        }
    }
}

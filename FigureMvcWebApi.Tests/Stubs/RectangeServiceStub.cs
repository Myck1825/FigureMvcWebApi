using FigureMvcWebApi.Model.Controllers.ModelLayer.Figure.Models;
using FigureMvcWebApi.Model.Controllers.ModelLayer.Figure.Requests;
using FigureMvcWebApi.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FigureMvcWebApi.Model.Controllers.Services;

namespace FigureMvcWebApi.Tests.Stubs
{
    public class RectangeServiceStub : IRectangleService
    {
        public Task<AOResult<FigureResponse>> GetRectangleByIntersectSegment(SegmentRequest request)
        {
            var aoResult = new AOResult<FigureResponse>();
            aoResult.SetSuccess(new FigureResponse
            {
                TotalCount = 1,
                RectangleList = new List<RectangleModel>
                    {
                        new RectangleModel
                        {
                            Id = Guid.NewGuid(),
                            PointA = new PointModel { X = 3, Y = 1 },
                            PointB = new PointModel { X = 3, Y = 4 },
                            PointD = new PointModel { X = 5, Y = 4 },
                            PointC = new PointModel { X = 5, Y = 1 }
                        }
                    }
            });
            return Task.FromResult(aoResult);
        }
    }
}

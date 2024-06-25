using AutoMapper;
using FigureMvcWebApi.Model.Controllers.ModelLayer.Figure.Database;
using FigureMvcWebApi.Model.Controllers.ModelLayer.Figure.Models;
using FigureMvcWebApi.Model.Database.Entities;

namespace FigureMvcWebApi.Model.Database
{
    public class EntityToModelProfile : Profile
    {
        public EntityToModelProfile()
        {
            CreateMap<Point, PointModel>();
            CreateMap<Rectangle, RectangleModel>()
                .ForMember(x => x.PointA, x => x.MapFrom(y => y.PointA))
                .ForMember(x => x.PointB, x => x.MapFrom(y => y.PointB))
                .ForMember(x => x.PointD, x => x.MapFrom(y => y.PointD))
                .ForMember(x => x.PointC, x => x.MapFrom(y => y.PointC));
            CreateMap<RectangleResultModel, RectangleModel>()
                .ForMember(x => x.PointA, x => x.MapFrom(y => new PointModel { X = y.PointA_X, Y = y.PointA_Y }))
                .ForMember(x => x.PointB, x => x.MapFrom(y => new PointModel { X = y.PointB_X, Y = y.PointB_Y }))
                .ForMember(x => x.PointD, x => x.MapFrom(y => new PointModel { X = y.PointD_X, Y = y.PointD_Y }))
                .ForMember(x => x.PointC, x => x.MapFrom(y => new PointModel { X = y.PointC_X, Y = y.PointC_Y }));
        }
    }
}

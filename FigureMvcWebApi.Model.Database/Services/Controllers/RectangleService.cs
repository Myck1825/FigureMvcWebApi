using AutoMapper;
using FigureMvcWebApi.Model.Controllers.ModelLayer.Figure.Models;
using FigureMvcWebApi.Model.Controllers.ModelLayer.Figure.Requests;
using FigureMvcWebApi.Model.Controllers.Services;
using FigureMvcWebApi.Model.Database.Entities;
using FigureMvcWebApi.Model.Database.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureMvcWebApi.Model.Database.Services.Controllers
{
    public class RectangleService : BaseService, IRectangleService
    {
        private readonly RectangleRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:FigureMvcWebApi.Model.Database.Services.Controllers.RectangleService"/> class.
        /// </summary>
        /// <param name="repository"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public RectangleService(IMapper mapper,
            RectangleRepository repository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<AOResult<FigureResponse>> GetRectangleByIntersectSegment(SegmentRequest request)
        => await BaseInvokeAsync<FigureResponse>(async (aoResult) =>
        {
            var rectangleList = _repository.GetList(request.A.X, request.A.Y, request.B.X, request.B.Y, request.Skip, request.Take);

            aoResult.SetSuccess(new FigureResponse
            {
                TotalCount = rectangleList.Any() ? rectangleList.First().CountRow : 0,
                RectangleList = rectangleList.Select(x => _mapper.Map<RectangleModel>(x)).ToList(),
            });
        });
    }
}

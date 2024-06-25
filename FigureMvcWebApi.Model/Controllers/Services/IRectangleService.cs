using FigureMvcWebApi.Model.Controllers.ModelLayer.Figure.Models;
using FigureMvcWebApi.Model.Controllers.ModelLayer.Figure.Requests;
using System.Threading.Tasks;

namespace FigureMvcWebApi.Model.Controllers.Services
{
    public interface IRectangleService : IFigureService
    {
        Task<AOResult<FigureResponse>> GetRectangleByIntersectSegment(SegmentRequest request);
    }
}

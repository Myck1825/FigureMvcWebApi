using System;

namespace FigureMvcWebApi.Model.Database.Repository
{
    public interface IEntity
    {
        /// <summary>
        /// ID of entity
        /// </summary>
        Guid Id { get; set; }
    }
}

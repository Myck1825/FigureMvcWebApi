using FigureMvcWebApi.Model.Database.Repository;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FigureMvcWebApi.Model.Database.Entities
{
    public abstract class BaseEntity : IEntity
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    }
}

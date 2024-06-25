using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FigureMvcWebApi.Model.Controllers.ModelLayer
{
    public class BaseModelForListRequest
    {
        private int _take;

        [JsonIgnore]
        public int Skip 
        { 
            get
            {
                return _take * (PageNumber - 1);
            }
        }

        [Range(0, int.MaxValue)]
        public int PageNumber { get; set; } = 1;

        [Range(0, int.MaxValue)]
        public int Take
        {
            get 
            {
                return _take;
            }
            set 
            {
                _take = value; 
            } 
        }
    }
}
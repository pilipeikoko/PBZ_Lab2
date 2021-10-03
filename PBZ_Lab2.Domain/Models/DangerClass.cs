using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;

namespace PBZ_Lab2.Domain.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DangerClass
    {
        [Display(Name = "dangerous")] Dangeroues = 0,
        [Display(Name = "safe")] Safe = 2,
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBZ_Lab2.Domain.Models
{
    public class TechParameters : Entity<Guid>
    {
        public ICollection<BackgroundConcentrationAndDate> BackgroundConcentrationAndDate { get; set; }
        public ICollection<WastewaterConcentrationAndDate> WastewaterConcentrationAndDate { get; set; }
        public float Diameter { get; set; }
        public float MinimalVelocity { get; set; }
        public float Waste { get; set; }
        public float Angle { get; set; }
        public float DistanceUp { get; set; }
        public float DistanceBank { get; set; }
        public float DistanceBoard { get; set; }
        public float KNK { get; set; }
        public ICollection<PdkAndDate> PdkAndDate { get; set; }
    }
}

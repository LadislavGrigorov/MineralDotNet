using MineralDotNet.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineralDotNet.Models
{
    public class Color : DeletableEntity
    {
        public Color()
        {
            this.Minerals = new HashSet<Mineral>();
        }
        
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Mineral> Minerals { get; set; }
    }
}

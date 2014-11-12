namespace MineralDotNet.Models
{
    using MineralDotNet.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SpecificClass : DeletableEntity
    {
        public SpecificClass()
        {
            this.Minerals = new HashSet<Mineral>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Mineral> Minerals { get; set; }
    }
}

using MineralDotNet.Contracts;
namespace MineralDotNet.Models
{
    public class Mineral : DeletableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Formula { get; set; }

        public int Hardness { get; set; }

        public int SpecificClassId { get; set; }

        public virtual SpecificClass SpecificClass { get; set;}

        public int ColorId { get; set; }

        public virtual Color Color { get; set; }

        public Lustre Lustre { get; set; }

        public Diaphaneity Diaphaneity { get; set; }

        public double SpecificGravity { get; set; }

        public int Cleavage { get; set; }


    }
}

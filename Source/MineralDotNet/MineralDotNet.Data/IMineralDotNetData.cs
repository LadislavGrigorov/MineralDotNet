using MineralDotNet.Contracts;
using MineralDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineralDotNet.Data
{
    
    public interface IMineralDotNetData
    {
        IMineralDotNetDbContext Context { get; }

        IDeletableEntityRepository<Mineral> Minerals { get; }

        IDeletableEntityRepository<Color> Colors { get; }

        IDeletableEntityRepository<SpecificClass> SpecificClasses { get; }

        IRepository<User> Users { get; }

        int SaveChanges();
    }
}

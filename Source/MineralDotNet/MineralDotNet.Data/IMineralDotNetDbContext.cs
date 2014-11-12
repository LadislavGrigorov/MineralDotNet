namespace MineralDotNet.Data
{
    using MineralDotNet.Models;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IMineralDotNetDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Mineral> Minerals { get; set; }

        IDbSet<Color> Colors { get; set; }

        IDbSet<SpecificClass> SpecificClasses { get; set; }

        DbContext DbContext { get; }

        int SaveChanges();

        void Dispose();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}

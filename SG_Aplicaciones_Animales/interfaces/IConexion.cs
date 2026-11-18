using Aplicaciones_Animales.entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Aplicaciones_Animales.interfaces
{
    public interface IConexion
    {
        DbSet<Animales>? Animales { get; set; }
        
        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}

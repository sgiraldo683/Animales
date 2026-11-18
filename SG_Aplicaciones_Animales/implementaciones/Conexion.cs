using Aplicaciones_Animales.entidades;
using Aplicaciones_Animales.nucleo;
using Microsoft.EntityFrameworkCore;
using Aplicaciones_Animales.interfaces;

namespace Aplicaciones_Animales.implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatosGenerales.StringConexion()!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Animales>? Animales { get; set; }
    }
}

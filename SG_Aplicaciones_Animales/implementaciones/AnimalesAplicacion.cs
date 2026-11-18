using Aplicaciones_Animales.entidades;
using Microsoft.EntityFrameworkCore;

namespace Aplicaciones_Animales.interfaces
{
    public class AnimalesAplicacion : IAnimalesAplicacion
    {
        private IConexion IConexion;

        public AnimalesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Animales Actualizar(Animales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Animales>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Animales Borrar(Animales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Animales!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Animales> Buscar(Animales entidad)
        {
            return this.IConexion.Animales!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }

        public List<Animales> Consultar()
        {
            return this.IConexion.Animales!.Take(5).ToList();
        }

        public Animales Insertar(Animales entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Animales!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Animales entidad)
        {
            return string.IsNullOrEmpty(entidad.Codigo) ||
                string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Pais) ||
                entidad.Activo == true ;
                
        }
    }
}
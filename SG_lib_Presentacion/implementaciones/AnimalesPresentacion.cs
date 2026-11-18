using Aplicaciones_Animales.entidades;
using Aplicaciones_Animales.interfaces;
using presentaciones_Animales.interfaces;

namespace Aplicaciones_Animales.implementaciones
{
    public class AnimalesPresentacion : IAnimalesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public AnimalesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Animales Actualizar(Animales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Animales>(
                "Asignaciones/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Animales Borrar(Animales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Animales>(
                "Asignaciones/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Animales> Buscar(Animales entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Animales>>(
                "Asignaciones/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Animales> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Animales>>(
                "Asignaciones/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Animales Insertar(Animales entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Animales>(
                "Asignaciones/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Animales entidad)
        {
            return string.IsNullOrEmpty(entidad.Codigo) ||
                string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Pais) ||
                entidad.Activo == false;
                
        }
    }
}
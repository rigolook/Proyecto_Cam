using Proyecto_Cam.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace Proyecto_Cam.Dato
{
    public class VehiculoAdmin
    {
        //muestra todos los datos de nuestra lista o lo que se encuentran en vehiculo
        public List<vehiculo> Mostrar()
        {
            using (proyectoEntities contexto = new proyectoEntities())
            {
                return contexto.vehiculo.AsNoTracking().ToList();
            }
        }
        //agregar un vehiculo sus datos
        public void Agregar(vehiculo modelo)
        {

            try
            {
                using (proyectoEntities contexto = new proyectoEntities())
                {
                    contexto.vehiculo.Add(modelo);
                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public void Editar(vehiculo vVehiculo)
        {
            try
            {
                using (proyectoEntities contexto = new proyectoEntities())
                {
                    contexto.Entry(vVehiculo).State = EntityState.Modified; 
                    contexto.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Eliminar(int vId)
        {
            try
            {
                using (proyectoEntities contexto = new proyectoEntities())
                {
                    contexto.vehiculo.Remove(contexto.vehiculo.Single
                        (v => v.Id == vId));
                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<vehiculo> buscarId(int vId)
        {
            try
            {
                using (proyectoEntities contexto = new proyectoEntities())
                {
                        
                    return contexto.vehiculo.Where(v => v.Id == vId).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        //      <>      para su uso

        public List<vehiculo> buscarNombre(string vMarca)
        {
            try
            {
                using (proyectoEntities contexto = new proyectoEntities())
                {

                    return contexto.vehiculo.Where(v => v.marca.Contains(vMarca)).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

    }
}

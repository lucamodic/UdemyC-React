using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesosDatos.Context;
using AccesosDatos.Models;

namespace AccesosDatos.Operaciones;

public class CalificacionDAO
{
    ProyectoContext contexto = new ProyectoContext();

    public List<Calificacion> seleccionar (int id)
    { 
        var calificaciones = contexto.Calificacions.Where(c => c.MatriculaId == id).ToList();
        return calificaciones;
    }

    public bool insertar(Calificacion calif)
    {
        try
        {
            contexto.Calificacions.Add(calif);
            contexto.SaveChanges();
            return true;
        }
        catch (Exception ex) {
            return false;
        }
    }

    public bool eliminar(int id)
    {
        try
        {
            var calificacion = contexto.Calificacions.Where(c => c.Id == id).FirstOrDefault();
            if(calificacion == null) return false;
            contexto.Calificacions.Remove(calificacion);
            contexto.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}

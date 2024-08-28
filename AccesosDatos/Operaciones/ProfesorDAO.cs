using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesosDatos.Context;
using AccesosDatos.Models;

namespace AccesosDatos.Operaciones;

public class ProfesorDAO
{
    public ProyectoContext contexto = new ProyectoContext();

    public Profesor login(string usuario, string pass)
    {
        var profesor = contexto.Profesors.Where(p => p.Usuario == usuario && p.Pass == pass).FirstOrDefault();
        return profesor;
    }
}

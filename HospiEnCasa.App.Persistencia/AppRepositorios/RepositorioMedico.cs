using System;
using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
     public class RepositorioMedico : IRepositorioMedico
     {
          private readonly AppContext _appContext = new AppContext(); //recomendable por seguridad
          Medico IRepositorioMedico.AddMedico(Medico medico)
          {
            var medicoAdicionado= _appContext.Medicos.Add(medico);
            _appContext.SaveChanges(); //Se deben guardar los cambios
            return medicoAdicionado.Entity; 
          }
     }
}
// implementa la interfaz 
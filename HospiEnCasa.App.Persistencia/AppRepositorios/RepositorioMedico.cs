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

          IEnumerable<Medico> IRepositorioMedico.GetAllMedicos()
          {
            return _appContext.Medicos;
          }

          Medico IRepositorioMedico.GetMedico(int idMedico)
          {
               return _appContext.Medicos.FirstOrDefault(m => m.Id == idMedico);//retorna lo que encuentra
          }

     }
}
// implementa la interfaz 
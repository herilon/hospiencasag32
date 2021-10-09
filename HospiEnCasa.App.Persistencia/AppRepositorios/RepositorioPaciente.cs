using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioPaciente : IRepositorioPaciente
    {
        private readonly AppContext _appContext = new AppContext(); //recomendable por seguridad
        Paciente IRepositorioPaciente.AddPaciente(Paciente paciente)
        {
            var pacienteAdicionado = _appContext.Pacientes.Add(paciente);
            _appContext.SaveChanges(); //Se deben guardar los cambios
            return pacienteAdicionado.Entity;
        }

        void IRepositorioPaciente.DeletePaciente(int idPaciente)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);//p es el primero que encuentra. Recorre todos los elementos de la tabla
            if (pacienteEncontrado == null)
                return;
            _appContext.Pacientes.Remove(pacienteEncontrado);
            _appContext.SaveChanges();//Se deben guardar los cambios
        }

        IEnumerable<Paciente> IRepositorioPaciente.GetAllPacientes()
        {
            return _appContext.Pacientes;

        }

        Paciente IRepositorioPaciente.GetPaciente(int idPaciente)
        {
            var paciente = _appContext.Pacientes
                                .Where(p => p.Id == idPaciente)
                                .Include(p => p.Medico)
                                .Include(p => p.SignosVitales)
                                .FirstOrDefault();
            return paciente;        
        }

        Paciente IRepositorioPaciente.UpdatePaciente(Paciente paciente)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == paciente.Id);
            //No se busca el idPaciente, se busca el paciente.Id
            if (pacienteEncontrado != null)
            {
                pacienteEncontrado.Nombre = paciente.Nombre;
                pacienteEncontrado.Apellidos = paciente.Apellidos;
                pacienteEncontrado.NumeroTelefono = paciente.NumeroTelefono;
                pacienteEncontrado.Genero = paciente.Genero;
                pacienteEncontrado.Direccion = paciente.Direccion;
                pacienteEncontrado.Latitud = paciente.Latitud;
                pacienteEncontrado.Longitud = paciente.Longitud;
                pacienteEncontrado.Ciudad = paciente.Ciudad;
                pacienteEncontrado.FechaNacimiento = paciente.FechaNacimiento;
                _appContext.SaveChanges();
            }
            return pacienteEncontrado; //retorna el paciente encontrado

        }
        
        Medico IRepositorioPaciente.AsignarMedico(int idPaciente, int idMedico)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
            if (pacienteEncontrado != null)
            {
                var medicoEncontrado = _appContext.Medicos.FirstOrDefault(m => m.Id == idMedico);
                if (medicoEncontrado != null)
                {
                    pacienteEncontrado.Medico = medicoEncontrado;
                    _appContext.SaveChanges();
                }
                return medicoEncontrado;
            }
            return null;
        }

        public SignoVital AsignarSignoVital(int idPaciente, SignoVital signoVital)
        {
            var pacienteEncontrado = _appContext.Pacientes
                                        .Where(p => p.Id == idPaciente)
                                        .Include(p => p.SignosVitales)
                                        .FirstOrDefault();
            if (pacienteEncontrado != null)
            {
                pacienteEncontrado.SignosVitales.Add(signoVital);
                _appContext.SaveChanges();
                return signoVital;
            }
            return null;
        }
        public IEnumerable<Paciente> GetPacientesGenero(int genero)
        {
            return _appContext.Pacientes
                        .Where(p => p.Genero == (Genero)genero);
        }
        public IEnumerable<Paciente> SearchPacientes(string nombre)
        {
            return _appContext.Pacientes
                        .Where(p => p.Nombre.Contains(nombre));
        }
    }


}
// implementa la interfaz 
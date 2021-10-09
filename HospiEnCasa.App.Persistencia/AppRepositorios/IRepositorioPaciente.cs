using System;
using System.Collections.Generic;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public interface IRepositorioPaciente
    {
        IEnumerable<Paciente> GetAllPacientes(); //método que me retorna todos los pacientes
        Paciente AddPaciente(Paciente paciente);
        Paciente UpdatePaciente(Paciente paciente);
        void DeletePaciente(int idPaciente);
        Paciente GetPaciente(int idPaciente);
        Medico AsignarMedico(int idPaciente, int idMedico);
        public SignoVital AsignarSignoVital(int idPaciente, SignoVital signoVital);
        public IEnumerable<Paciente> GetPacientesGenero(int genero);
        public IEnumerable<Paciente> SearchPacientes(string nombre);
    }
}
//Interfaz: Conjunto de métodos-encabezados de los métodos- No tienen implementación
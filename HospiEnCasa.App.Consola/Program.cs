using System;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;
using System.Collections.Generic;

namespace HospiEnCasa.App.Consola
{
    class Program
    {
        private static IRepositorioPaciente _repoPaciente = new RepositorioPaciente(new Persistencia.AppContext());
        private static IRepositorioMedico _repoMedico = new RepositorioMedico(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //AddPaciente();
            //BuscarPaciente(1);
            //mostrarPacientes();
            //AddMedico();
            AsignarMedico();
        }
        private static void AddPaciente()
        {
            var paciente = new Paciente
            {
                Nombre = "Pepito",
                Apellidos = "Perez",
                NumeroTelefono = "3152152014",
                Genero = Genero.Masculino,
                Direccion = "cra 41 22-20 sur",
                Ciudad = "Cali",
                Longitud = 5.07F,
                Latitud = 75.52F,
                FechaNacimiento = new DateTime(1990, 04, 12)
            };
            _repoPaciente.AddPaciente(paciente);
        }
        private static void BuscarPaciente(int idPaciente)
        {
            var paciente = _repoPaciente.GetPaciente(idPaciente);
            Console.WriteLine("Nombre: " + paciente.Nombre + " " + paciente.Apellidos + "  Género: " + paciente.Genero);
        }

        private static void mostrarPacientes()
        {
            IEnumerable<Paciente> pacientes = _repoPaciente.GetAllPacientes();
            foreach (var paciente in pacientes)
            {
                Console.WriteLine("Nombre: " + paciente.Nombre + " " + paciente.Apellidos + "  Género: " + paciente.Genero);
            }
        }

        private static void AddMedico()
        {
            var medico = new Medico
            {
                Nombre = "Charlie",
                Apellidos = "Garcia",
                NumeroTelefono = "3152152014",
                Genero = Genero.Masculino,
                Especialidad = "Internista",
                Codigo = "1234ac",
                RegistroRethus = "abc123"
            };
            _repoMedico.AddMedico(medico);
        }

        private static void AsignarMedico()
        {
            var medico = _repoPaciente.AsignarMedico(1, 3);
            Console.WriteLine(medico.Nombre + " " + medico.Apellidos);
        }

    }
}
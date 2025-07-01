using ClinicaGoF.Application.DTOs.InputModels;
using ClinicaGoF.Application.Services.Interfaces;
using ClinicaGoF.Domain.Entities;

namespace ClinicaGoF.Application.Services;

public class CompatibilidadeTipoConsultaValidator : BaseValidator
{
    public override bool Validate(Consulta consulta, Paciente paciente, Medico medico)
    {
        // Supondo que ConsultaInputModel tenha um campo TipoConsulta (Online/Presencial)
        // E que Medico tenha uma lista de tipos de consulta que ele pode atender
        // Para simplificar, vamos assumir que todos os médicos podem atender a ambos os tipos por enquanto
        // E que a consulta tem um campo TipoConsulta

        // if (consulta.TipoConsulta == TipoConsulta.Online && !medico.PodeAtenderOnline)
        // {
        //     Console.WriteLine("Erro de validação: Médico não pode atender consultas online.");
        //     return false;
        // }
        // if (consulta.TipoConsulta == TipoConsulta.Presencial && !medico.PodeAtenderPresencial)
        // {
        //     Console.WriteLine("Erro de validação: Médico não pode atender consultas presenciais.");
        //     return false;
        // }

        return base.Validate(consulta, paciente, medico);
    }
}


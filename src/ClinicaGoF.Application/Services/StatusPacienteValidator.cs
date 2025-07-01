using ClinicaGoF.Application.Services.Interfaces;
using ClinicaGoF.Domain.Entities;

namespace ClinicaGoF.Application.Services;

public class StatusPacienteValidator : BaseValidator
{
    public override bool Validate(Consulta consulta, Paciente paciente, Medico medico)
    {
        if (paciente == null || !paciente.Ativo)
        {
            Console.WriteLine("Erro de validação: Paciente inativo ou não encontrado.");
            return false;
        }
        // Adicionar lógica para verificar se o paciente está regularizado, se houver um campo para isso
        return base.Validate(consulta, paciente, medico);
    }
}


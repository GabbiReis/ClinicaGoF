
using ClinicaGoF.Application.Services.Interfaces;
using ClinicaGoF.Domain.Entities;

namespace ClinicaGoF.Application.Services;

public class DocumentacaoObrigatoriaValidator : BaseValidator
{
    public override bool Validate(Consulta consulta, Paciente paciente, Medico medico)
    {
        // Exemplo: verificar se o paciente tem um documento de identidade válido cadastrado
        if (string.IsNullOrWhiteSpace(paciente.Documento))
        {
            Console.WriteLine("Erro de validação: Documento do paciente não fornecido.");
            return false;
        }
        return base.Validate(consulta, paciente, medico);
    }
}


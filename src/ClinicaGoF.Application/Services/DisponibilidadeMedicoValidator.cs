using ClinicaGoF.Application.Services.Interfaces;
using ClinicaGoF.Domain.Entities;
using ClinicaGoF.Domain.Repository.Interfaces;

namespace ClinicaGoF.Application.Services;

public class DisponibilidadeMedicoValidator : BaseValidator
{
    private readonly IRepository<Consulta> _consultaRepo;

    public DisponibilidadeMedicoValidator(IRepository<Consulta> consultaRepo)
    {
        _consultaRepo = consultaRepo;
    }

    public override bool Validate(Consulta consulta, Paciente paciente, Medico medico)
    {
        var consultasDoMedico = _consultaRepo.GetAllAsync().Result.Where(c => c.MedicoId == consulta.MedicoId);
        if (consultasDoMedico.Any(c => c.DataHora == consulta.DataHora))
        {
            Console.WriteLine("Erro de validação: Médico não disponível no horário selecionado.");
            return false;
        }
        return base.Validate(consulta, paciente, medico);
    }
}


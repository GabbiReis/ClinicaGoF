using ClinicaGoF.Domain.Entities;

namespace ClinicaGoF.Application.Services.Interfaces;

public interface IAgendaValidator
{
    bool Validate(Consulta consulta, Paciente paciente, Medico medico);
    IAgendaValidator SetNext(IAgendaValidator nextValidator);
}




public abstract class BaseValidator : IAgendaValidator
{
    private IAgendaValidator _nextValidator;

    public IAgendaValidator SetNext(IAgendaValidator nextValidator)
    {
        _nextValidator = nextValidator;
        return nextValidator;
    }

    public virtual bool Validate(Consulta consulta, Paciente paciente, Medico medico)
    {
        if (_nextValidator != null)
        {
            return _nextValidator.Validate(consulta, paciente, medico);
        }
        return true;
    }
}


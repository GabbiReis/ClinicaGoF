using ClinicaGoF.Domain.Entities;

namespace ClinicaGoF.Application.Services;

public abstract class ConsultaTemplate
{
    protected Consulta _consulta;
    protected Paciente _paciente;
    protected Medico _medico;

    public ConsultaTemplate(Consulta consulta, Paciente paciente, Medico medico)
    {
        _consulta = consulta;
        _paciente = paciente;
        _medico = medico;
    }

    public void ProcessarConsulta()
    {
        PreConsulta();
        ExecutarConsulta();
        FinalizarConsulta();
    }

    protected abstract void PreConsulta();
    protected abstract void ExecutarConsulta();
    protected abstract void FinalizarConsulta();
}


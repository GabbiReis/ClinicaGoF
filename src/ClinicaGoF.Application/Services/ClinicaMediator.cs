using ClinicaGoF.Application.Services.Interfaces;
using ClinicaGoF.Domain.Entities;
using ClinicaGoF.Domain.Repository.Interfaces;

namespace ClinicaGoF.Application.Services;

public class ClinicaMediator : IMediator
{
    private readonly IRepository<Consulta> _consultaRepo;
    private readonly IRepository<Paciente> _pacienteRepo;
    private readonly IRepository<Medico> _medicoRepo;

    public ClinicaMediator(IRepository<Consulta> consultaRepo, IRepository<Paciente> pacienteRepo, IRepository<Medico> medicoRepo)
    {
        _consultaRepo = consultaRepo;
        _pacienteRepo = pacienteRepo;
        _medicoRepo = medicoRepo;
    }

    public void Notificar(string evento, object data)
    {
        switch (evento)
        {
            case "ConsultaAgendada":
                HandleConsultaAgendada(data as Consulta);
                break;
            case "ConsultaCancelada":
                HandleConsultaCancelada(data as Consulta);
                break;
            // Outros eventos podem ser adicionados aqui
            default:
                Console.WriteLine($"Evento desconhecido: {evento}");
                break;
        }
    }

    private void HandleConsultaAgendada(Consulta consulta)
    {
        if (consulta == null) return;

        Console.WriteLine($"[Mediator] Notificação: Consulta agendada para {consulta.DataHora} com o médico {consulta.MedicoId} e paciente {consulta.PacienteId}.");
        // Lógica para notificar outros módulos:
        // 1. Notificação: Enviar confirmação ao paciente e médico.
        // 2. Faturamento: Registrar pré-faturamento ou informações para futura cobrança.
        // 3. Prontuário: Criar um registro inicial no prontuário do paciente.
    }

    private void HandleConsultaCancelada(Consulta consulta)
    {
        if (consulta == null) return;

        Console.WriteLine($"[Mediator] Notificação: Consulta cancelada para {consulta.DataHora} com o médico {consulta.MedicoId} e paciente {consulta.PacienteId}.");
        // Lógica para notificar outros módulos:
        // 1. Notificação: Enviar aviso de cancelamento.
        // 2. Faturamento: Ajustar faturamento.
        // 3. Prontuário: Registrar o cancelamento.
    }
}


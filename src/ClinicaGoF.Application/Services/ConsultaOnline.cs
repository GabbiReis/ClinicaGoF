
using ClinicaGoF.Domain.Entities;

namespace ClinicaGoF.Application.Services;

public class ConsultaOnline : ConsultaTemplate
{
    public ConsultaOnline(Consulta consulta, Paciente paciente, Medico medico) : base(consulta, paciente, medico) { }

    protected override void PreConsulta()
    {
        Console.WriteLine($"[Consulta Online] Preparando para a consulta de {_paciente.Nome} com {_medico.Nome} via videoconferência.");
        // Lógica específica para pré-consulta online (ex: enviar link da reunião, verificar conexão)
    }

    protected override void ExecutarConsulta()
    {
        Console.WriteLine($"[Consulta Online] Realizando a consulta online de {_paciente.Nome} com {_medico.Nome}.");
        // Lógica específica para execução da consulta online
    }

    protected override void FinalizarConsulta()
    {
        Console.WriteLine($"[Consulta Online] Finalizando a consulta online de {_paciente.Nome} com {_medico.Nome}. Registrando observações: {_consulta.Observacoes}");
        // Lógica específica para finalização da consulta online (ex: enviar resumo por email, feedback)
    }
}


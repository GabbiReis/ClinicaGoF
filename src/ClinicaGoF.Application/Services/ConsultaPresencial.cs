using ClinicaGoF.Domain.Entities;

namespace ClinicaGoF.Application.Services;

public class ConsultaPresencial : ConsultaTemplate
{
    public ConsultaPresencial(Consulta consulta, Paciente paciente, Medico medico) : base(consulta, paciente, medico) { }

    protected override void PreConsulta()
    {
        Console.WriteLine($"[Consulta Presencial] Preparando para a consulta de {_paciente.Nome} com {_medico.Nome} no local físico.");
        // Lógica específica para pré-consulta presencial (ex: verificar sala, equipamentos)
    }

    protected override void ExecutarConsulta()
    {
        Console.WriteLine($"[Consulta Presencial] Realizando a consulta presencial de {_paciente.Nome} com {_medico.Nome}.");
        // Lógica específica para execução da consulta presencial
    }

    protected override void FinalizarConsulta()
    {
        Console.WriteLine($"[Consulta Presencial] Finalizando a consulta presencial de {_paciente.Nome} com {_medico.Nome}. Registrando observações: {_consulta.Observacoes}");
        // Lógica específica para finalização da consulta presencial (ex: emitir recibo, agendar retorno)
    }
}


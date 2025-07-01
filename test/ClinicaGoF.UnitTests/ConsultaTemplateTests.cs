using Xunit;
using ClinicaGoF.Application.Services;
using ClinicaGoF.Domain.Entities;
using System;

public class ConsultaTemplateTests
{
    [Fact]
    public void ConsultaPresencial_ProcessarConsulta_ShouldCallAllSteps()
    {
        // Arrange
        var consulta = new Consulta { Observacoes = "Observações da consulta presencial" };
        var paciente = new Paciente { Nome = "Paciente Teste" };
        var medico = new Medico { Nome = "Dr. Teste" };
        var consultaPresencial = new ConsultaPresencial(consulta, paciente, medico);

        // Act & Assert (Verificar a saída do console, que é a forma mais simples de testar neste caso)
        // Em um cenário real, usaríamos mocks para verificar chamadas de métodos internos.
        var stringWriter = new System.IO.StringWriter();
        Console.SetOut(stringWriter);

        consultaPresencial.ProcessarConsulta();

        var output = stringWriter.ToString();
        Assert.Contains("[Consulta Presencial] Preparando para a consulta de Paciente Teste com Dr. Teste no local físico.", output);
        Assert.Contains("[Consulta Presencial] Realizando a consulta presencial de Paciente Teste com Dr. Teste.", output);
        Assert.Contains("[Consulta Presencial] Finalizando a consulta presencial de Paciente Teste com Dr. Teste. Registrando observações: Observações da consulta presencial", output);
    }

    [Fact]
    public void ConsultaOnline_ProcessarConsulta_ShouldCallAllSteps()
    {
        // Arrange
        var consulta = new Consulta { Observacoes = "Observações da consulta online" };
        var paciente = new Paciente { Nome = "Paciente Teste" };
        var medico = new Medico { Nome = "Dr. Teste" };
        var consultaOnline = new ConsultaOnline(consulta, paciente, medico);

        // Act & Assert
        var stringWriter = new System.IO.StringWriter();
        Console.SetOut(stringWriter);

        consultaOnline.ProcessarConsulta();

        var output = stringWriter.ToString();
        Assert.Contains("[Consulta Online] Preparando para a consulta de Paciente Teste com Dr. Teste via videoconferência.", output);
        Assert.Contains("[Consulta Online] Realizando a consulta online de Paciente Teste com Dr. Teste.", output);
        Assert.Contains("[Consulta Online] Finalizando a consulta online de Paciente Teste com Dr. Teste. Registrando observações: Observações da consulta online", output);
    }
}


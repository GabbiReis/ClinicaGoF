using Xunit;
using ClinicaGoF.Domain.Entities;
using System;
using System.IO;

public class ConsultaStateTests : IDisposable
{
    private readonly TextWriter _originalConsoleOut;

    public ConsultaStateTests()
    {
        _originalConsoleOut = Console.Out;
    }

    public void Dispose()
    {
        Console.SetOut(_originalConsoleOut);
    }

    [Fact]
    public void Consulta_InitialStateIsAgendada()
    {
        // Arrange
        var consulta = new Consulta();

        // Assert
        Assert.IsType<EstadoAgendada>(GetConsultaState(consulta));
    }

    [Fact]
    public void AgendadaState_CanTransitionToConfirmada()
    {
        // Arrange
        var consulta = new Consulta();
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        consulta.Confirmar();
        stringWriter.Flush();

        // Assert
        Assert.IsType<EstadoConfirmada>(GetConsultaState(consulta));
        Assert.Contains("Confirmando consulta...", stringWriter.ToString());
        Assert.Contains($"Estado da consulta {consulta.Id} mudou para EstadoConfirmada", stringWriter.ToString());
    }

    [Fact]
    public void ConfirmadaState_CanTransitionToEmAndamento()
    {
        // Arrange
        var consulta = new Consulta();
        consulta.Confirmar(); // Change to Confirmada state
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        consulta.Iniciar();
        stringWriter.Flush();

        // Assert
        Assert.IsType<EstadoEmAndamento>(GetConsultaState(consulta));
        Assert.Contains("Iniciando consulta...", stringWriter.ToString());
        Assert.Contains($"Estado da consulta {consulta.Id} mudou para EstadoEmAndamento", stringWriter.ToString());
    }

    [Fact]
    public void EmAndamentoState_CanTransitionToFinalizada()
    {
        // Arrange
        var consulta = new Consulta();
        consulta.Confirmar();
        consulta.Iniciar(); // Change to EmAndamento state
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        consulta.Finalizar();
        stringWriter.Flush();

        // Assert
        Assert.IsType<EstadoFinalizada>(GetConsultaState(consulta));
        Assert.Contains("Finalizando consulta...", stringWriter.ToString());
        Assert.Contains($"Estado da consulta {consulta.Id} mudou para EstadoFinalizada", stringWriter.ToString());
    }

    [Fact]
    public void AnyState_CanTransitionToCancelada()
    {
        // Arrange
        var consulta = new Consulta(); // Agendada state
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        consulta.Cancelar();
        stringWriter.Flush();

        // Assert
        Assert.IsType<EstadoCancelada>(GetConsultaState(consulta));
        Assert.Contains("Cancelando consulta...", stringWriter.ToString());
        Assert.Contains($"Estado da consulta {consulta.Id} mudou para EstadoCancelada", stringWriter.ToString());

        // Test from another state (e.g., Confirmada)
        consulta = new Consulta();
        consulta.Confirmar();
        stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        consulta.Cancelar();
        stringWriter.Flush();
        Assert.IsType<EstadoCancelada>(GetConsultaState(consulta));
    }

    [Fact]
    public void FinalizadaState_CannotTransitionToOtherStates()
    {
        // Arrange
        var consulta = new Consulta();
        consulta.Confirmar();
        consulta.Iniciar();
        consulta.Finalizar(); // Change to Finalizada state
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        consulta.Agendar();
        consulta.Confirmar();
        consulta.Iniciar();
        consulta.Cancelar();
        stringWriter.Flush();

        // Assert
        Assert.IsType<EstadoFinalizada>(GetConsultaState(consulta));
        Assert.Contains("Consulta finalizada, não pode ser agendada.", stringWriter.ToString());
        Assert.Contains("Consulta finalizada, não pode ser confirmada.", stringWriter.ToString());
        Assert.Contains("Consulta finalizada, não pode ser iniciada.", stringWriter.ToString());
        Assert.Contains("Consulta finalizada, não pode ser cancelada.", stringWriter.ToString());
    }

    [Fact]
    public void CanceladaState_CannotTransitionToOtherStates()
    {
        // Arrange
        var consulta = new Consulta();
        consulta.Cancelar(); // Change to Cancelada state
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        consulta.Agendar();
        consulta.Confirmar();
        consulta.Iniciar();
        consulta.Finalizar();
        stringWriter.Flush();

        // Assert
        Assert.IsType<EstadoCancelada>(GetConsultaState(consulta));
        Assert.Contains("Consulta cancelada, não pode ser agendada novamente.", stringWriter.ToString());
        Assert.Contains("Consulta cancelada, não pode ser confirmada.", stringWriter.ToString());
        Assert.Contains("Consulta cancelada, não pode ser iniciada.", stringWriter.ToString());
        Assert.Contains("Consulta cancelada, não pode ser finalizada.", stringWriter.ToString());
    }

    // Helper method to get the private _estadoAtual field using reflection
    private IEstadoConsulta GetConsultaState(Consulta consulta)
    {
        var field = typeof(Consulta).GetField("_estadoAtual", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        return (IEstadoConsulta)field.GetValue(consulta);
    }
}


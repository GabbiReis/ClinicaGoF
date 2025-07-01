using Xunit;
using ClinicaGoF.Domain.Entities;
using ClinicaGoF.Application.Services;
using System;
using System.Linq;

public class ProntuarioMementoTests
{
    [Fact]
    public void Prontuario_SalvarEstado_ShouldCreateMementoWithCurrentObservations()
    {
        // Arrange
        var prontuario = new Prontuario("Observação inicial.");

        // Act
        var memento = prontuario.SalvarEstado();

        // Assert
        Assert.Equal("Observação inicial.", memento.GetObservacoes());
        Assert.True(memento.GetDate() <= DateTime.Now);
    }

    [Fact]
    public void Prontuario_RestaurarEstado_ShouldRestorePreviousObservations()
    {
        // Arrange
        var prontuario = new Prontuario("Observação inicial.");
        var memento = prontuario.SalvarEstado();

        prontuario.Observacoes = "Nova observação.";

        // Act
        prontuario.RestaurarEstado(memento);

        // Assert
        Assert.Equal("Observação inicial.", prontuario.Observacoes);
    }

    [Fact]
    public void ProntuarioCaretaker_AdicionarMemento_ShouldAddMementoToHistory()
    {
        // Arrange
        var caretaker = new ProntuarioCaretaker();
        var prontuario = new Prontuario("Observação 1.");
        var memento1 = prontuario.SalvarEstado();

        // Act
        caretaker.AdicionarMemento(memento1);

        // Assert
        Assert.Single(caretaker.GetHistorico());
        Assert.Equal(memento1, caretaker.GetHistorico().First());
    }

    [Fact]
    public void ProntuarioCaretaker_GetMemento_ShouldReturnCorrectMementoByIndex()
    {
        // Arrange
        var caretaker = new ProntuarioCaretaker();
        var prontuario = new Prontuario("Observação 1.");
        caretaker.AdicionarMemento(prontuario.SalvarEstado());

        prontuario.Observacoes = "Observação 2.";
        caretaker.AdicionarMemento(prontuario.SalvarEstado());

        // Act
        var retrievedMemento = caretaker.GetMemento(0);

        // Assert
        Assert.Equal("Observação 1.", retrievedMemento.GetObservacoes());
    }

    [Fact]
    public void ProntuarioCaretaker_GetMemento_ShouldThrowExceptionForInvalidIndex()
    {
        // Arrange
        var caretaker = new ProntuarioCaretaker();
        var prontuario = new Prontuario("Observação 1.");
        caretaker.AdicionarMemento(prontuario.SalvarEstado());

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => caretaker.GetMemento(10));
    }

    [Fact]
    public void FullMementoScenario_ShouldSaveAndRestoreMultipleStates()
    {
        // Arrange
        var prontuario = new Prontuario("Primeira observação.");
        var caretaker = new ProntuarioCaretaker();

        // Save initial state
        caretaker.AdicionarMemento(prontuario.SalvarEstado());

        // Change and save state 2
        prontuario.Observacoes = "Segunda observação.";
        caretaker.AdicionarMemento(prontuario.SalvarEstado());

        // Change and save state 3
        prontuario.Observacoes = "Terceira observação.";
        caretaker.AdicionarMemento(prontuario.SalvarEstado());

        // Act - Restore to state 1
        prontuario.RestaurarEstado(caretaker.GetMemento(0));
        Assert.Equal("Primeira observação.", prontuario.Observacoes);

        // Act - Restore to state 2
        prontuario.RestaurarEstado(caretaker.GetMemento(1));
        Assert.Equal("Segunda observação.", prontuario.Observacoes);

        // Act - Restore to state 3
        prontuario.RestaurarEstado(caretaker.GetMemento(2));
        Assert.Equal("Terceira observação.", prontuario.Observacoes);
    }
}


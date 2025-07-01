using Xunit;
using Moq;
using ClinicaGoF.Application.Services;
using ClinicaGoF.Domain.Entities;
using ClinicaGoF.Domain.Repository.Interfaces;
using System;
using System.Threading.Tasks;

public class ClinicaMediatorTests
{
    [Fact]
    public void Notificar_ConsultaAgendada_ShouldWriteToConsole()
    {
        // Arrange
        var mockConsultaRepo = new Mock<IRepository<Consulta>>();
        var mockPacienteRepo = new Mock<IRepository<Paciente>>();
        var mockMedicoRepo = new Mock<IRepository<Medico>>();

        var mediator = new ClinicaMediator(mockConsultaRepo.Object, mockPacienteRepo.Object, mockMedicoRepo.Object);
        var consulta = new Consulta { Id = Guid.NewGuid(), DataHora = DateTime.Now, MedicoId = Guid.NewGuid(), PacienteId = Guid.NewGuid() };

        var stringWriter = new System.IO.StringWriter();
        Console.SetOut(stringWriter);

        // Act
        mediator.Notificar("ConsultaAgendada", consulta);

        // Assert
        var output = stringWriter.ToString();
        Assert.Contains($"[Mediator] Notificação: Consulta agendada para {consulta.DataHora} com o médico {consulta.MedicoId} e paciente {consulta.PacienteId}.", output);
    }

    [Fact]
    public void Notificar_ConsultaCancelada_ShouldWriteToConsole()
    {
        // Arrange
        var mockConsultaRepo = new Mock<IRepository<Consulta>>();
        var mockPacienteRepo = new Mock<IRepository<Paciente>>();
        var mockMedicoRepo = new Mock<IRepository<Medico>>();

        var mediator = new ClinicaMediator(mockConsultaRepo.Object, mockPacienteRepo.Object, mockMedicoRepo.Object);
        var consulta = new Consulta { Id = Guid.NewGuid(), DataHora = DateTime.Now, MedicoId = Guid.NewGuid(), PacienteId = Guid.NewGuid() };

        var stringWriter = new System.IO.StringWriter();
        Console.SetOut(stringWriter);

        // Act
        mediator.Notificar("ConsultaCancelada", consulta);

        // Assert
        var output = stringWriter.ToString();
        Assert.Contains($"[Mediator] Notificação: Consulta cancelada para {consulta.DataHora} com o médico {consulta.MedicoId} e paciente {consulta.PacienteId}.", output);
    }

    [Fact]
    public void Notificar_UnknownEvent_ShouldWriteToConsole()
    {
        // Arrange
        var mockConsultaRepo = new Mock<IRepository<Consulta>>();
        var mockPacienteRepo = new Mock<IRepository<Paciente>>();
        var mockMedicoRepo = new Mock<IRepository<Medico>>();

        var mediator = new ClinicaMediator(mockConsultaRepo.Object, mockPacienteRepo.Object, mockMedicoRepo.Object);
        var data = new object();

        var stringWriter = new System.IO.StringWriter();
        Console.SetOut(stringWriter);

        // Act
        mediator.Notificar("EventoDesconhecido", data);

        // Assert
        var output = stringWriter.ToString();
        Assert.Contains("Evento desconhecido: EventoDesconhecido", output);
    }
}


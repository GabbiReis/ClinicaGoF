using Xunit;
using Moq;
using ClinicaGoF.Application.Services.Interfaces;
using ClinicaGoF.Application.Services;
using ClinicaGoF.Domain.Entities;
using ClinicaGoF.Domain.Repository.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

public class AgendaValidatorTests
{
    [Fact]
    public async Task DisponibilidadeMedicoValidator_ShouldReturnFalse_WhenMedicoIsNotAvailable()
    {
        // Arrange
        var mockConsultaRepo = new Mock<IRepository<Consulta>>();
        var medicoId = Guid.NewGuid();
        var pacienteId = Guid.NewGuid();
        var dataHora = DateTime.Now.AddHours(1);

        mockConsultaRepo.Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(new List<Consulta>
            {
                new Consulta { MedicoId = medicoId, DataHora = dataHora }
            });

        var validator = new DisponibilidadeMedicoValidator(mockConsultaRepo.Object);
        var consulta = new Consulta { MedicoId = medicoId, DataHora = dataHora };
        var paciente = new Paciente { Id = pacienteId, Ativo = true, Documento = "123" };
        var medico = new Medico { Id = medicoId, Nome = "Dr. Teste" };

        // Act
        var result = validator.Validate(consulta, paciente, medico);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public async Task DisponibilidadeMedicoValidator_ShouldReturnTrue_WhenMedicoIsAvailable()
    {
        // Arrange
        var mockConsultaRepo = new Mock<IRepository<Consulta>>();
        var medicoId = Guid.NewGuid();
        var pacienteId = Guid.NewGuid();
        var dataHora = DateTime.Now.AddHours(1);

        mockConsultaRepo.Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(new List<Consulta>());

        var validator = new DisponibilidadeMedicoValidator(mockConsultaRepo.Object);
        var consulta = new Consulta { MedicoId = medicoId, DataHora = dataHora };
        var paciente = new Paciente { Id = pacienteId, Ativo = true, Documento = "123" };
        var medico = new Medico { Id = medicoId, Nome = "Dr. Teste" };

        // Act
        var result = validator.Validate(consulta, paciente, medico);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void StatusPacienteValidator_ShouldReturnFalse_WhenPacienteIsInactive()
    {
        // Arrange
        var validator = new StatusPacienteValidator();
        var consulta = new Consulta();
        var paciente = new Paciente { Ativo = false };
        var medico = new Medico();

        // Act
        var result = validator.Validate(consulta, paciente, medico);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void StatusPacienteValidator_ShouldReturnTrue_WhenPacienteIsActive()
    {
        // Arrange
        var validator = new StatusPacienteValidator();
        var consulta = new Consulta();
        var paciente = new Paciente { Ativo = true, Documento = "123" };
        var medico = new Medico();

        // Act
        var result = validator.Validate(consulta, paciente, medico);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void DocumentacaoObrigatoriaValidator_ShouldReturnFalse_WhenDocumentoIsMissing()
    {
        // Arrange
        var validator = new DocumentacaoObrigatoriaValidator();
        var consulta = new Consulta();
        var paciente = new Paciente { Ativo = true, Documento = "" };
        var medico = new Medico();

        // Act
        var result = validator.Validate(consulta, paciente, medico);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void DocumentacaoObrigatoriaValidator_ShouldReturnTrue_WhenDocumentoIsPresent()
    {
        // Arrange
        var validator = new DocumentacaoObrigatoriaValidator();
        var consulta = new Consulta();
        var paciente = new Paciente { Ativo = true, Documento = "12345" };
        var medico = new Medico();

        // Act
        var result = validator.Validate(consulta, paciente, medico);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ChainOfResponsibility_ShouldStopOnFirstFailure()
    {
        // Arrange
        var medicoId = Guid.NewGuid();
        var dataHora = DateTime.Now.AddHours(1);

        var mockConsultaRepo = new Mock<IRepository<Consulta>>();
        mockConsultaRepo.Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(new List<Consulta> { new Consulta { MedicoId = medicoId, DataHora = dataHora } });

        var validator1 = new DisponibilidadeMedicoValidator(mockConsultaRepo.Object);
        var validator2 = new StatusPacienteValidator();
        var validator3 = new DocumentacaoObrigatoriaValidator();

        validator1.SetNext(validator2);
        validator2.SetNext(validator3);

        var consulta = new Consulta { MedicoId = medicoId, DataHora = dataHora }; // Medico is NOT available
        var paciente = new Paciente { Ativo = true, Documento = "123" };
        var medico = new Medico { Id = medicoId }; // Ensure medicoId matches

        // Act
        var result = validator1.Validate(consulta, paciente, medico);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void ChainOfResponsibility_ShouldPassAllValidators_WhenAllAreValid()
    {
        // Arrange
        var mockConsultaRepo = new Mock<IRepository<Consulta>>();
        mockConsultaRepo.Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(new List<Consulta>()); // Medico is available

        var validator1 = new DisponibilidadeMedicoValidator(mockConsultaRepo.Object);
        var validator2 = new StatusPacienteValidator();
        var validator3 = new DocumentacaoObrigatoriaValidator();

        validator1.SetNext(validator2);
        validator2.SetNext(validator3);

        var consulta = new Consulta { MedicoId = Guid.NewGuid(), DataHora = DateTime.Now.AddHours(1) };
        var paciente = new Paciente { Ativo = true, Documento = "123" };
        var medico = new Medico();

        // Act
        var result = validator1.Validate(consulta, paciente, medico);

        // Assert
        Assert.True(result);
    }
}


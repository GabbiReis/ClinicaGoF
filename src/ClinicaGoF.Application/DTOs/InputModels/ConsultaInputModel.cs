using ClinicaGoF.Domain.Entities;

namespace ClinicaGoF.Application.DTOs.InputModels;

public record ConsultaInputModel(Guid PacienteId, Guid MedicoId, DateTime DataHora, string Observacoes, TipoConsulta TipoConsulta);



namespace ClinicaGoF.Application.DTOs.ViewModels;

public record ConsultaViewModel(Guid Id, Guid PacienteId, string NomePaciente, string NomeMedico, DateTime DataHora, string Observacoes);


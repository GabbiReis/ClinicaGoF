namespace ClinicaGoF.Application.DTOs.InputModels;

public record struct PacienteInputModel(string Nome, string Documento, DateTime DataNascimento);
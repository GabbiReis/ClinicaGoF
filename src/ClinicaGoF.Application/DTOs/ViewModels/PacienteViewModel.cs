namespace ClinicaGoF.Application.DTOs.ViewModels
{
    public record struct PacienteViewModel(Guid id, string Nome, string Documento, DateTime DataNascimento, DateTime DataCadastro);
}

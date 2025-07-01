using ClinicaGoF.Application.DTOs.InputModels;
using ClinicaGoF.Application.DTOs.ViewModels;

namespace ClinicaGoF.Application.Services.Interfaces;

public interface IPacienteService
{
    Task<IEnumerable<PacienteViewModel>> ListarAsync();
    Task<PacienteViewModel?> ObterPorDocumentoAsync(string documento);
    Task CadastrarAsync(PacienteInputModel paciente);
}
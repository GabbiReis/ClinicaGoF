using ClinicaGoF.Application.DTOs.InputModels;
using ClinicaGoF.Application.DTOs.ViewModels;

namespace ClinicaGoF.Application.Services.Interfaces;
public interface IConsultaService
{
    Task<IEnumerable<ConsultaViewModel>> ListarAsync();
    Task<IEnumerable<ConsultaViewModel>> ListarPorPacienteAsync(Guid pacienteId);
    Task<IEnumerable<ConsultaViewModel>> ListarPorDocumentoPacienteAsync(string documento);
    Task<IEnumerable<ConsultaViewModel>> ListarPorCrmMedicoAsync(string crm);
    Task<IEnumerable<ConsultaViewModel>> ListarPorIntervaloAsync(DateTime inicio, DateTime fim);
    Task AgendarAsync(ConsultaInputModel input);
}
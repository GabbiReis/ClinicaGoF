using ClinicaGoF.Application.DTOs.InputModels;
using ClinicaGoF.Application.DTOs.ViewModels;

namespace ClinicaGoF.Application.Services.Interfaces;
public interface IMedicoService
{
    Task<IEnumerable<MedicoViewModel>> ListarAsync();
    Task<MedicoViewModel?> ObterPorCrmAsync(string crm);
    Task CadastrarAsync(MedicoInputModel medico);
}
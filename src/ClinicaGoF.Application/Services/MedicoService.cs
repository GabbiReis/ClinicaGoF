using ClinicaGoF.Application.DTOs.InputModels;
using ClinicaGoF.Application.DTOs.ViewModels;
using ClinicaGoF.Application.Services.Interfaces;
using ClinicaGoF.Domain.Entities;
using ClinicaGoF.Domain.Repository.Interfaces;

namespace ClinicaGoF.Application.Services;

public class MedicoService : IMedicoService
{
    private readonly IRepository<Medico> _repository;

    public MedicoService(IRepository<Medico> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<MedicoViewModel>> ListarAsync()
    {
        var medicos = await _repository.GetAllAsync();
        return medicos.Select(m => new MedicoViewModel(m.Id, m.Nome, m.CRM, m.Especialidade));
    }

    public async Task<MedicoViewModel?> ObterPorCrmAsync(string crm)
    {
        var medicos = await _repository.GetAllAsync();
        var medico = medicos.FirstOrDefault(m => m.CRM == crm);
        return medico is null ? null : new MedicoViewModel(medico.Id, medico.Nome, medico.CRM, medico.Especialidade);
    }

    public async Task CadastrarAsync(MedicoInputModel input)
    {
        var medico = new Medico
        {
            Id = Guid.NewGuid(),
            Nome = input.Nome,
            CRM = input.CRM,
            Especialidade = input.Especialidade
        };

        await _repository.AddAsync(medico);
    }
}
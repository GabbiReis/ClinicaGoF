using ClinicaGoF.Application.DTOs.InputModels;
using ClinicaGoF.Application.DTOs.ViewModels;
using ClinicaGoF.Application.Services.Interfaces;
using ClinicaGoF.Domain.Entities;
using ClinicaGoF.Domain.Repository.Interfaces;

namespace ClinicaGoF.Application.Services;

public class PacienteService : IPacienteService
{
    private readonly IRepository<Paciente> _repository;

    public PacienteService(IRepository<Paciente> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PacienteViewModel>> ListarAsync()
    {
        var pacientes = await _repository.GetAllAsync();

        return pacientes.Select(p => new PacienteViewModel(
            p.Id,
            p.Nome,
            p.Documento,
            p.DataNascimento,
            p.DataCadastro
        ));
    }

    public async Task<PacienteViewModel?> ObterPorDocumentoAsync(string documento)
    {
        var pacientes = await _repository.GetAllAsync();
        var paciente = pacientes.FirstOrDefault(p => p.Documento == documento);

        if (paciente is null) return null;

        return new PacienteViewModel(
            paciente.Id,
            paciente.Nome,
            paciente.Documento,
            paciente.DataNascimento,
            paciente.DataCadastro
        );
    }

    public async Task CadastrarAsync(PacienteInputModel input)
    {
        var paciente = new Paciente
        {
            Id = Guid.NewGuid(),
            Nome = input.Nome,
            Documento = input.Documento,
            DataNascimento = input.DataNascimento,
        };

        await _repository.AddAsync(paciente);
    }
}

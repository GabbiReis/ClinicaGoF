using ClinicaGoF.Application.DTOs.InputModels;
using ClinicaGoF.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaGoF.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PacienteController : ControllerBase
{
    private readonly IPacienteService _pacienteService;

    public PacienteController(IPacienteService pacienteService)
    {
        _pacienteService = pacienteService;
    }

    /// <summary>
    /// Lista todos os pacientes cadastrados.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var pacientes = await _pacienteService.ListarAsync();
        return Ok(pacientes);
    }

    /// <summary>
    /// Retorna um paciente pelo seu documento (CPF).
    /// </summary>
    /// <param name="documento">Documento do paciente</param>
    [HttpGet("{documento}")]
    public async Task<IActionResult> GetByDocumento(string documento)
    {
        var paciente = await _pacienteService.ObterPorDocumentoAsync(documento);
        return paciente is null ? NotFound() : Ok(paciente);
    }

    /// <summary>
    /// Cadastra um novo paciente.
    /// </summary>
    /// <param name="paciente">Dados do novo paciente</param>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PacienteInputModel paciente)
    {
        await _pacienteService.CadastrarAsync(paciente);
        return CreatedAtAction(nameof(GetByDocumento), new { paciente.Documento }, paciente);
    }
}
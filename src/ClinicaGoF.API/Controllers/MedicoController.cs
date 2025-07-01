using ClinicaGoF.Application.DTOs.InputModels;
using ClinicaGoF.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaGoF.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MedicoController : ControllerBase
{
    private readonly IMedicoService _medicoService;

    public MedicoController(IMedicoService medicoService)
    {
        _medicoService = medicoService;
    }

    /// <summary>
    /// Lista todos os médicos cadastrados.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var medicos = await _medicoService.ListarAsync();
        return Ok(medicos);
    }

    /// <summary>
    /// Retorna um médico pelo seu CRM.
    /// </summary>
    /// <param name="crm">CRM do médico</param>
    [HttpGet("{crm}")]
    public async Task<IActionResult> GetByCrm(string crm)
    {
        var medico = await _medicoService.ObterPorCrmAsync(crm);
        return medico is null ? NotFound() : Ok(medico);
    }

    /// <summary>
    /// Cadastra um novo médico.
    /// </summary>
    /// <param name="medico">Dados do novo médico</param>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] MedicoInputModel medico)
    {
        await _medicoService.CadastrarAsync(medico);
        return CreatedAtAction(nameof(GetByCrm), new { medico.CRM }, medico);
    }
}
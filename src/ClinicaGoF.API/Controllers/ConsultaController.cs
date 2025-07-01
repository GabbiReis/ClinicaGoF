using ClinicaGoF.Application.DTOs.InputModels;
using ClinicaGoF.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaGoF.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConsultaController : ControllerBase
{
    private readonly IConsultaService _consultaService;

    public ConsultaController(IConsultaService consultaService)
    {
        _consultaService = consultaService;
    }

    /// <summary>
    /// Lista todas as consultas cadastradas.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var consultas = await _consultaService.ListarAsync();
        return Ok(consultas);
    }

    /// <summary>
    /// Lista todas as consultas de um paciente pelo seu ID.
    /// </summary>
    /// <param name="pacienteId">ID do paciente</param>
    [HttpGet("paciente/{pacienteId}")]
    public async Task<IActionResult> GetByPaciente(Guid pacienteId)
    {
        var consultas = await _consultaService.ListarPorPacienteAsync(pacienteId);
        return Ok(consultas);
    }

    /// <summary>
    /// Lista consultas de um paciente pelo documento (CPF).
    /// </summary>
    /// <param name="documento">Documento do paciente</param>
    [HttpGet("paciente/documento/{documento}")]
    public async Task<IActionResult> GetByDocumento(string documento)
    {
        var consultas = await _consultaService.ListarPorDocumentoPacienteAsync(documento);
        return Ok(consultas);
    }

    /// <summary>
    /// Lista consultas de um médico pelo CRM.
    /// </summary>
    /// <param name="crm">CRM do médico</param>
    [HttpGet("medico/crm/{crm}")]
    public async Task<IActionResult> GetByCrm(string crm)
    {
        var consultas = await _consultaService.ListarPorCrmMedicoAsync(crm);
        return Ok(consultas);
    }

    /// <summary>
    /// Lista consultas agendadas dentro de um intervalo de datas.
    /// </summary>
    /// <param name="inicio">Data inicial</param>
    /// <param name="fim">Data final</param>
    [HttpGet("intervalo")]
    public async Task<IActionResult> GetByIntervalo([FromQuery] DateTime inicio, [FromQuery] DateTime fim)
    {
        var consultas = await _consultaService.ListarPorIntervaloAsync(inicio, fim);
        return Ok(consultas);
    }

    /// <summary>
    /// Agenda uma nova consulta.
    /// </summary>
    /// <param name="input">Dados da nova consulta</param>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ConsultaInputModel input)
    {
        await _consultaService.AgendarAsync(input);
        return Ok();
    }
}
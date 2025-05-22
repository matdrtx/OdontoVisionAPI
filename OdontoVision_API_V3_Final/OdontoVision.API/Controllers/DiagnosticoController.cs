using Microsoft.AspNetCore.Mvc;
using OdontoVision.Application.DTOs;
using OdontoVision.Application.Services;

[ApiController]
[Route("api/[controller]")]
public class DiagnosticoController : ControllerBase
{
    private readonly DiagnosticoService _diagnosticoService;

    public DiagnosticoController(DiagnosticoService diagnosticoService)
    {
        _diagnosticoService = diagnosticoService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var diagnosticos = _diagnosticoService.GetAllDiagnosticos();
        return Ok(diagnosticos);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var diagnostico = _diagnosticoService.GetDiagnosticoById(id);
        if (diagnostico == null) return NotFound();
        return Ok(diagnostico);
    }

    [HttpPost]
    public IActionResult Create([FromBody] DiagnosticoDTO dto)
    {
        _diagnosticoService.CreateDiagnostico(dto);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] DiagnosticoDTO dto)
    {
        _diagnosticoService.UpdateDiagnostico(id, dto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _diagnosticoService.DeleteDiagnostico(id);
        return Ok();
    }
}

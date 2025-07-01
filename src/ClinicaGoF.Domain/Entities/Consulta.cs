namespace ClinicaGoF.Domain.Entities;

public enum TipoConsulta
{
    Presencial,
    Online
}

public class Consulta
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid PacienteId { get; set; }
    public Guid MedicoId { get; set; }
    public DateTime DataHora { get; set; }
    public string Observacoes { get; set; } = string.Empty;
    public TipoConsulta TipoConsulta { get; set; }

    private IEstadoConsulta _estadoAtual;

    public Consulta()
    {
        _estadoAtual = new EstadoAgendada(); // Estado inicial
    }

    public void MudarEstado(IEstadoConsulta novoEstado)
    {
        _estadoAtual = novoEstado;
        Console.WriteLine($"Estado da consulta {Id} mudou para {_estadoAtual.GetType().Name}");
    }

    public void Agendar()
    {
        _estadoAtual.Agendar(this);
    }

    public void Confirmar()
    {
        _estadoAtual.Confirmar(this);
    }

    public void Iniciar()
    {
        _estadoAtual.Iniciar(this);
    }

    public void Finalizar()
    {
        _estadoAtual.Finalizar(this);
    }

    public void Cancelar()
    {
        _estadoAtual.Cancelar(this);
    }
}


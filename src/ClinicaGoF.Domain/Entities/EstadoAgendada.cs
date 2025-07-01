using ClinicaGoF.Domain.Entities;

namespace ClinicaGoF.Domain.Entities;

public class EstadoAgendada : IEstadoConsulta
{
    public void Agendar(Consulta consulta)
    {
        Console.WriteLine("Consulta já está agendada.");
    }

    public void Confirmar(Consulta consulta)
    {
        Console.WriteLine("Confirmando consulta...");
        consulta.MudarEstado(new EstadoConfirmada());
    }

    public void Iniciar(Consulta consulta)
    {
        Console.WriteLine("Não é possível iniciar uma consulta agendada. Primeiro confirme.");
    }

    public void Finalizar(Consulta consulta)
    {
        Console.WriteLine("Não é possível finalizar uma consulta agendada.");
    }

    public void Cancelar(Consulta consulta)
    {
        Console.WriteLine("Cancelando consulta...");
        consulta.MudarEstado(new EstadoCancelada());
    }
}


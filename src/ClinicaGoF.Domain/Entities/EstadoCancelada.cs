
using ClinicaGoF.Domain.Entities;

namespace ClinicaGoF.Domain.Entities;

public class EstadoCancelada : IEstadoConsulta
{
    public void Agendar(Consulta consulta)
    {
        Console.WriteLine("Consulta cancelada, não pode ser agendada novamente.");
    }

    public void Confirmar(Consulta consulta)
    {
        Console.WriteLine("Consulta cancelada, não pode ser confirmada.");
    }

    public void Iniciar(Consulta consulta)
    {
        Console.WriteLine("Consulta cancelada, não pode ser iniciada.");
    }

    public void Finalizar(Consulta consulta)
    {
        Console.WriteLine("Consulta cancelada, não pode ser finalizada.");
    }

    public void Cancelar(Consulta consulta)
    {
        Console.WriteLine("Consulta já está cancelada.");
    }
}



using ClinicaGoF.Domain.Entities;

namespace ClinicaGoF.Domain.Entities;

public class EstadoFinalizada : IEstadoConsulta
{
    public void Agendar(Consulta consulta)
    {
        Console.WriteLine("Consulta finalizada, não pode ser agendada.");
    }

    public void Confirmar(Consulta consulta)
    {
        Console.WriteLine("Consulta finalizada, não pode ser confirmada.");
    }

    public void Iniciar(Consulta consulta)
    {
        Console.WriteLine("Consulta finalizada, não pode ser iniciada.");
    }

    public void Finalizar(Consulta consulta)
    {
        Console.WriteLine("Consulta já está finalizada.");
    }

    public void Cancelar(Consulta consulta)
    {
        Console.WriteLine("Consulta finalizada, não pode ser cancelada.");
    }
}


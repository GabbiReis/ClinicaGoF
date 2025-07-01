
using ClinicaGoF.Domain.Entities;

namespace ClinicaGoF.Domain.Entities;

public class EstadoEmAndamento : IEstadoConsulta
{
    public void Agendar(Consulta consulta)
    {
        Console.WriteLine("Consulta em andamento, não pode ser agendada.");
    }

    public void Confirmar(Consulta consulta)
    {
        Console.WriteLine("Consulta em andamento, já confirmada.");
    }

    public void Iniciar(Consulta consulta)
    {
        Console.WriteLine("Consulta já está em andamento.");
    }

    public void Finalizar(Consulta consulta)
    {
        Console.WriteLine("Finalizando consulta...");
        consulta.MudarEstado(new EstadoFinalizada());
    }

    public void Cancelar(Consulta consulta)
    {
        Console.WriteLine("Não é possível cancelar uma consulta em andamento. Primeiro finalize.");
    }
}


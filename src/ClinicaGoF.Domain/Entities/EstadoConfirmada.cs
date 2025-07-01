
using ClinicaGoF.Domain.Entities;

namespace ClinicaGoF.Domain.Entities;

public class EstadoConfirmada : IEstadoConsulta
{
    public void Agendar(Consulta consulta)
    {
        Console.WriteLine("Consulta já está confirmada, não pode ser agendada novamente.");
    }

    public void Confirmar(Consulta consulta)
    {
        Console.WriteLine("Consulta já está confirmada.");
    }

    public void Iniciar(Consulta consulta)
    {
        Console.WriteLine("Iniciando consulta...");
        consulta.MudarEstado(new EstadoEmAndamento());
    }

    public void Finalizar(Consulta consulta)
    {
        Console.WriteLine("Não é possível finalizar uma consulta confirmada. Primeiro inicie.");
    }

    public void Cancelar(Consulta consulta)
    {
        Console.WriteLine("Cancelando consulta...");
        consulta.MudarEstado(new EstadoCancelada());
    }
}


using ClinicaGoF.Domain.Entities;

namespace ClinicaGoF.Domain.Entities;

public interface IEstadoConsulta
{
    void Agendar(Consulta consulta);
    void Confirmar(Consulta consulta);
    void Iniciar(Consulta consulta);
    void Finalizar(Consulta consulta);
    void Cancelar(Consulta consulta);
}


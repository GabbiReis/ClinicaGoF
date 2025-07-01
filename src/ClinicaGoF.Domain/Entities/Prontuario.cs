using ClinicaGoF.Domain.Entities;

namespace ClinicaGoF.Domain.Entities;

public class Prontuario
{
    public string Observacoes { get; set; }

    public Prontuario(string observacoes)
    {
        Observacoes = observacoes;
    }

    public ProntuarioMemento SalvarEstado()
    {
        return new ProntuarioMemento(Observacoes);
    }

    public void RestaurarEstado(ProntuarioMemento memento)
    {
        Observacoes = memento.GetObservacoes();
    }
}


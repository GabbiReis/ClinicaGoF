
using ClinicaGoF.Domain.Entities;

namespace ClinicaGoF.Application.Services;

public class ProntuarioCaretaker
{
    private readonly List<ProntuarioMemento> _historico = new List<ProntuarioMemento>();

    public void AdicionarMemento(ProntuarioMemento memento)
    {
        _historico.Add(memento);
    }

    public ProntuarioMemento GetMemento(int index)
    {
        if (index < 0 || index >= _historico.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Índice fora do intervalo.");
        }
        return _historico[index];
    }

    public IEnumerable<ProntuarioMemento> GetHistorico() => _historico;
}


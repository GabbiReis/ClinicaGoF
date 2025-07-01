using ClinicaGoF.Domain.Entities;

namespace ClinicaGoF.Domain.Entities;

public class ProntuarioMemento
{
    private readonly string _observacoes;
    private readonly DateTime _dataHoraCriacao;

    public ProntuarioMemento(string observacoes)
    {
        _observacoes = observacoes;
        _dataHoraCriacao = DateTime.Now;
    }

    public string GetObservacoes() => _observacoes;
    public DateTime GetDate() => _dataHoraCriacao;
}


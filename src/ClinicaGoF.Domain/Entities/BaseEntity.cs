namespace ClinicaGoF.Domain.Entities;

public class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime DataCadastro { get; private set; }
    public DateTime DataAtualizao { get; private set; }
    public string Usuario { get; set; } = string.Empty;

    public void SetDataCadastro()
    {
        DataCadastro = DateTime.UtcNow;
    }

    public void SetDataAtualizacao()
    {
        DataAtualizao = DateTime.UtcNow;
    }

    public void SetUsuario(string usuario)
    {
        Usuario = usuario;
    }
}

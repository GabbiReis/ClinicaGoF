namespace ClinicaGoF.Domain.Entities;

public class Medico : BaseEntity
{
    public string Nome { get; set; } = string.Empty;
    public string CRM { get; set; } = string.Empty;
    public string Especialidade { get; set; } = string.Empty;
}
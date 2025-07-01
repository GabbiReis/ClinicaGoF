using ClinicaGoF.Domain.Entities;

namespace ClinicaGoF.Application.Services.Interfaces;

public interface IMediator
{
    void Notificar(string evento, object data);
}


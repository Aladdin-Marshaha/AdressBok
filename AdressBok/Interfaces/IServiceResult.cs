using AdressBok.Enums;

namespace AdressBok.Interfaces;

public interface IServiceResult
{
    object Result { get; set; }
    ServiceStatus Status { get; set; }
}

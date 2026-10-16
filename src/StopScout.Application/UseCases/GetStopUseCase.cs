using StopScout.Application.Abstractions;
using StopScout.Domain.Entities;

namespace StopScout.Application.UseCases;

public sealed class GetStopUseCase
{
    private readonly IStopCatalog _catalog;

    public GetStopUseCase(IStopCatalog catalog)
    {
        _catalog = catalog;
    }

    public Task<Stop?> ExecuteAsync(int stopId, CancellationToken cancellationToken = default)
    {
        return _catalog.GetByIdAsync(stopId, cancellationToken);
    }
}

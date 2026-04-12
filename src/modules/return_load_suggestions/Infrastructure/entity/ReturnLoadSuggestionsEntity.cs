using transporte.src.modules.loads.Infrastructure.entity;

namespace transporte.src.modules.return_load_suggestions.Infrastructure.entity;

public sealed class ReturnLoadSuggestionsEntity
{
    public Guid Id { get; set; }

    public Guid LoadId { get; set; }

    public Guid SuggestedLoadId { get; set; }

    public decimal Score { get; set; }

    public LoadsEntity Load { get; set; } = null!;

    public LoadsEntity SuggestedLoad { get; set; } = null!;
}

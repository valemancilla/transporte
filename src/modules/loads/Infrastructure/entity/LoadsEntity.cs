using transporte.src.modules.bids.Infrastructure.entity;
using transporte.src.modules.chat_rooms.Infrastructure.entity;
using transporte.src.modules.cities_municipalities.Infrastructure.entity;
using transporte.src.modules.load_details.Infrastructure.entity;
using transporte.src.modules.load_images.Infrastructure.entity;
using transporte.src.modules.load_status_history.Infrastructure.entity;
using transporte.src.modules.persons.Infrastructure.entity;
using transporte.src.modules.return_load_suggestions.Infrastructure.entity;
using transporte.src.modules.trips.Infrastructure.entity;
using transporte.src.modules.type_load.Infrastructure.entity;

namespace transporte.src.modules.loads.Infrastructure.entity;

public sealed class LoadsEntity
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    public Guid TypeLoadId { get; set; }

    public Guid OriginCityId { get; set; }

    public Guid DestinationCityId { get; set; }

    public string? OriginAddress { get; set; }

    public string? DestinationAddress { get; set; }

    public string? DestinationCoords { get; set; }

    public decimal Weight { get; set; }

    public decimal Volume { get; set; }

    public decimal Price { get; set; }

    public Guid LoadStatusId { get; set; }

    public DateTime? PickupTime { get; set; }

    public PersonsEntity Customer { get; set; } = null!;

    public TypeLoadEntity TypeLoad { get; set; } = null!;

    public CitiesMunicipalitiesEntity OriginCity { get; set; } = null!;

    public CitiesMunicipalitiesEntity DestinationCity { get; set; } = null!;

    public ICollection<TripsEntity> Trips { get; set; } = new List<TripsEntity>();

    public ICollection<BidsEntity> Bids { get; set; } = new List<BidsEntity>();

    public ICollection<ReturnLoadSuggestionsEntity> ReturnLoadSuggestionsAsSource { get; set; } = new List<ReturnLoadSuggestionsEntity>();

    public ICollection<ReturnLoadSuggestionsEntity> ReturnLoadSuggestionsAsTarget { get; set; } = new List<ReturnLoadSuggestionsEntity>();

    public ICollection<LoadDetailsEntity> LoadDetails { get; set; } = new List<LoadDetailsEntity>();

    public ICollection<LoadImagesEntity> LoadImages { get; set; } = new List<LoadImagesEntity>();

    public ICollection<LoadStatusHistoryEntity> LoadStatusHistories { get; set; } = new List<LoadStatusHistoryEntity>();

    public ICollection<ChatRoomsEntity> ChatRooms { get; set; } = new List<ChatRoomsEntity>();
}

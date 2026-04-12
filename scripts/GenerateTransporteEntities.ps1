# Genera Entity + EntityConfiguration para todos los modulos (transporte).
$ErrorActionPreference = "Stop"
$root = (Resolve-Path (Join-Path $PSScriptRoot "..")).Path
$modulesRoot = Join-Path $root "src\modules"

function Write-TextFile([string]$Path, [string]$Content) {
    $dir = Split-Path $Path -Parent
    if (-not (Test-Path $dir)) { New-Item -ItemType Directory -Path $dir -Force | Out-Null }
    [System.IO.File]::WriteAllText($Path, $Content, [System.Text.UTF8Encoding]::new($false))
}

# Definiciones: FolderName, ClassName, TableName, Properties (lineas C# de propiedades publicas)
$defs = @(
    @{ F = "persons"; C = "PersonsEntity"; T = "persons"; P = @"
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string IdNum { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Guid PersonStatusId { get; set; }
    public DateTime CreatedAt { get; set; }
"@; CFG = @"
        builder.Property(x => x.FirstName).HasColumnName("first_name").HasMaxLength(80).IsRequired();
        builder.Property(x => x.LastName).HasColumnName("last_name").HasMaxLength(80).IsRequired();
        builder.Property(x => x.IdNum).HasColumnName("id_num").HasMaxLength(20).IsRequired();
        builder.Property(x => x.Phone).HasColumnName("phone").HasMaxLength(20).IsRequired();
        builder.Property(x => x.Email).HasColumnName("email").HasMaxLength(120).IsRequired();
        builder.Property(x => x.PersonStatusId).HasColumnName("person_status_id").IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
"@ }
    @{ F = "auth_credentials"; C = "AuthCredentialsEntity"; T = "auth_credentials"; P = @"
    public Guid Id { get; set; }
    public Guid PersonId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public DateTime? LastLogin { get; set; }
    public int FailedAttempts { get; set; }
    public bool IsActive { get; set; }
"@; CFG = @"
        builder.Property(x => x.PersonId).HasColumnName("person_id").IsRequired();
        builder.Property(x => x.Email).HasColumnName("email").HasMaxLength(120).IsRequired();
        builder.Property(x => x.PasswordHash).HasColumnName("password_hash").HasColumnType("text").IsRequired();
        builder.Property(x => x.LastLogin).HasColumnName("last_login");
        builder.Property(x => x.FailedAttempts).HasColumnName("failed_attempts").IsRequired();
        builder.Property(x => x.IsActive).HasColumnName("is_active").IsRequired();
"@ }
    @{ F = "auth_sessions"; C = "AuthSessionsEntity"; T = "auth_sessions"; P = @"
    public Guid Id { get; set; }
    public Guid PersonId { get; set; }
    public string SessionToken { get; set; } = string.Empty;
    public DateTime ExpiresAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? IpAddress { get; set; }
"@; CFG = @"
        builder.Property(x => x.PersonId).HasColumnName("person_id").IsRequired();
        builder.Property(x => x.SessionToken).HasColumnName("session_token").HasColumnType("text").IsRequired();
        builder.Property(x => x.ExpiresAt).HasColumnName("expires_at").IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
        builder.Property(x => x.IpAddress).HasColumnName("ip_address").HasMaxLength(45);
"@ }
    @{ F = "audit_log"; C = "AuditLogEntity"; T = "audit_log"; P = @"
    public Guid Id { get; set; }
    public Guid PersonId { get; set; }
    public string Action { get; set; } = string.Empty;
    public string TableName { get; set; } = string.Empty;
    public Guid RecordId { get; set; }
    public string? OldValues { get; set; }
    public string? NewValues { get; set; }
    public string? IpAddress { get; set; }
    public string? UserAgent { get; set; }
    public DateTime CreatedAt { get; set; }
"@; CFG = @"
        builder.Property(x => x.PersonId).HasColumnName("person_id").IsRequired();
        builder.Property(x => x.Action).HasColumnName("action").HasMaxLength(50).IsRequired();
        builder.Property(x => x.TableName).HasColumnName("table_name").HasMaxLength(50).IsRequired();
        builder.Property(x => x.RecordId).HasColumnName("record_id").IsRequired();
        builder.Property(x => x.OldValues).HasColumnName("old_values").HasColumnType("json");
        builder.Property(x => x.NewValues).HasColumnName("new_values").HasColumnType("json");
        builder.Property(x => x.IpAddress).HasColumnName("ip_address").HasMaxLength(45);
        builder.Property(x => x.UserAgent).HasColumnName("user_agent").HasColumnType("text");
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
"@ }
    @{ F = "vehicles"; C = "VehiclesEntity"; T = "vehicles"; P = @"
    public Guid Id { get; set; }
    public string Plate { get; set; } = string.Empty;
    public Guid TypeVehicleId { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public string Color { get; set; } = string.Empty;
    public Guid OwnerId { get; set; }
    public string ChassisNumber { get; set; } = string.Empty;
    public Guid VehicleStatusId { get; set; }
"@; CFG = @"
        builder.Property(x => x.Plate).HasColumnName("plate").HasMaxLength(10).IsRequired();
        builder.Property(x => x.TypeVehicleId).HasColumnName("type_vehicle_id").IsRequired();
        builder.Property(x => x.Brand).HasColumnName("brand").HasMaxLength(50).IsRequired();
        builder.Property(x => x.Model).HasColumnName("model").HasMaxLength(50).IsRequired();
        builder.Property(x => x.Year).HasColumnName("year").IsRequired();
        builder.Property(x => x.Color).HasColumnName("color").HasMaxLength(30).IsRequired();
        builder.Property(x => x.OwnerId).HasColumnName("owner_id").IsRequired();
        builder.Property(x => x.ChassisNumber).HasColumnName("chassis_number").HasMaxLength(50).IsRequired();
        builder.Property(x => x.VehicleStatusId).HasColumnName("vehicle_status_id").IsRequired();
"@ }
    @{ F = "documents_drivers"; C = "DocumentsDriversEntity"; T = "documents_drivers"; P = @"
    public Guid Id { get; set; }
    public Guid DriverId { get; set; }
    public Guid TypeDocumentId { get; set; }
    public string DocumentNumber { get; set; } = string.Empty;
    public DateOnly? ExpirationDate { get; set; }
    public string? FileUrl { get; set; }
    public Guid DocumentStatusId { get; set; }
"@; CFG = @"
        builder.Property(x => x.DriverId).HasColumnName("driver_id").IsRequired();
        builder.Property(x => x.TypeDocumentId).HasColumnName("type_document_id").IsRequired();
        builder.Property(x => x.DocumentNumber).HasColumnName("document_number").HasMaxLength(50).IsRequired();
        builder.Property(x => x.ExpirationDate).HasColumnName("expiration_date");
        builder.Property(x => x.FileUrl).HasColumnName("file_url").HasColumnType("text");
        builder.Property(x => x.DocumentStatusId).HasColumnName("document_status_id").IsRequired();
"@ }
    @{ F = "loads"; C = "LoadsEntity"; T = "loads"; P = @"
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
"@; CFG = @"
        builder.Property(x => x.CustomerId).HasColumnName("customer_id").IsRequired();
        builder.Property(x => x.TypeLoadId).HasColumnName("type_load_id").IsRequired();
        builder.Property(x => x.OriginCityId).HasColumnName("origin_city_id").IsRequired();
        builder.Property(x => x.DestinationCityId).HasColumnName("destination_city_id").IsRequired();
        builder.Property(x => x.OriginAddress).HasColumnName("origin_address").HasColumnType("text");
        builder.Property(x => x.DestinationAddress).HasColumnName("destination_address").HasColumnType("text");
        builder.Property(x => x.DestinationCoords).HasColumnName("destination_coords").HasColumnType("text");
        builder.Property(x => x.Weight).HasColumnName("weight").HasColumnType("decimal(10,2)").IsRequired();
        builder.Property(x => x.Volume).HasColumnName("volume").HasColumnType("decimal(10,2)").IsRequired();
        builder.Property(x => x.Price).HasColumnName("price").HasColumnType("decimal(15,2)").IsRequired();
        builder.Property(x => x.LoadStatusId).HasColumnName("load_status_id").IsRequired();
        builder.Property(x => x.PickupTime).HasColumnName("pickup_time");
"@ }
    @{ F = "trips"; C = "TripsEntity"; T = "trips"; P = @"
    public Guid Id { get; set; }
    public Guid LoadId { get; set; }
    public Guid VehicleId { get; set; }
    public Guid DriverId { get; set; }
    public decimal FinalPrice { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public Guid TripStatusId { get; set; }
"@; CFG = @"
        builder.Property(x => x.LoadId).HasColumnName("load_id").IsRequired();
        builder.Property(x => x.VehicleId).HasColumnName("vehicle_id").IsRequired();
        builder.Property(x => x.DriverId).HasColumnName("driver_id").IsRequired();
        builder.Property(x => x.FinalPrice).HasColumnName("final_price").HasColumnType("decimal(15,2)").IsRequired();
        builder.Property(x => x.StartTime).HasColumnName("start_time");
        builder.Property(x => x.EndTime).HasColumnName("end_time");
        builder.Property(x => x.TripStatusId).HasColumnName("trip_status_id").IsRequired();
"@ }
    @{ F = "credit_wallet"; C = "CreditWalletEntity"; T = "credit_wallet"; P = @"
    public Guid Id { get; set; }
    public Guid PersonId { get; set; }
    public decimal Balance { get; set; }
    public DateTime LastUpdate { get; set; }
"@; CFG = @"
        builder.Property(x => x.PersonId).HasColumnName("person_id").IsRequired();
        builder.Property(x => x.Balance).HasColumnName("balance").HasColumnType("decimal(15,2)").IsRequired();
        builder.Property(x => x.LastUpdate).HasColumnName("last_update").IsRequired();
"@ }
    @{ F = "payments"; C = "PaymentsEntity"; T = "payments"; P = @"
    public Guid Id { get; set; }
    public Guid PaymentProviderId { get; set; }
    public Guid PersonId { get; set; }
    public string ExternalReference { get; set; } = string.Empty;
    public decimal AmountMoney { get; set; }
    public DateTime CreatedAt { get; set; }
"@; CFG = @"
        builder.Property(x => x.PaymentProviderId).HasColumnName("payment_provider_id").IsRequired();
        builder.Property(x => x.PersonId).HasColumnName("person_id").IsRequired();
        builder.Property(x => x.ExternalReference).HasColumnName("external_reference").HasMaxLength(255).IsRequired();
        builder.Property(x => x.AmountMoney).HasColumnName("amount_money").HasColumnType("decimal(15,2)").IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
"@ }
    @{ F = "chat_messages"; C = "ChatMessagesEntity"; T = "chat_messages"; P = @"
    public Guid Id { get; set; }
    public Guid ChatRoomId { get; set; }
    public Guid SenderId { get; set; }
    public string MessageContent { get; set; } = string.Empty;
    public bool IsRead { get; set; }
    public DateTime CreatedAt { get; set; }
"@; CFG = @"
        builder.Property(x => x.ChatRoomId).HasColumnName("chat_room_id").IsRequired();
        builder.Property(x => x.SenderId).HasColumnName("sender_id").IsRequired();
        builder.Property(x => x.MessageContent).HasColumnName("message_content").HasColumnType("text").IsRequired();
        builder.Property(x => x.IsRead).HasColumnName("is_read").IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
"@ }
    @{ F = "notifications"; C = "NotificationsEntity"; T = "notifications"; P = @"
    public Guid Id { get; set; }
    public Guid PersonId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public Guid NotificationTypeId { get; set; }
    public bool IsRead { get; set; }
    public DateTime CreatedAt { get; set; }
"@; CFG = @"
        builder.Property(x => x.PersonId).HasColumnName("person_id").IsRequired();
        builder.Property(x => x.Title).HasColumnName("title").HasMaxLength(150).IsRequired();
        builder.Property(x => x.Body).HasColumnName("body").HasColumnType("text").IsRequired();
        builder.Property(x => x.NotificationTypeId).HasColumnName("notification_type_id").IsRequired();
        builder.Property(x => x.IsRead).HasColumnName("is_read").IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
"@ }
)

# Lookups estandar: id, name, description
$lookupFolders = @(
    "person_status","type_load","type_vehicles","type_documents","documents_status","payment_statuses",
    "payment_providers","notification_type","message_type","companies_status","dispute_status","reason_disputes",
    "subscription_status","subscription_type","transaction_types","roles","status_bids","status_trip",
    "vehicles_status","document_category"
)
$lookupClass = @{
    "person_status" = "PersonStatusEntity"; "type_load" = "TypeLoadEntity"; "type_vehicles" = "TypeVehiclesEntity"
    "type_documents" = "TypeDocumentsEntity"; "documents_status" = "DocumentsStatusEntity"; "payment_statuses" = "PaymentStatusesEntity"
    "payment_providers" = "PaymentProvidersEntity"; "notification_type" = "NotificationTypeEntity"; "message_type" = "MessageTypeEntity"
    "companies_status" = "CompaniesStatusEntity"; "dispute_status" = "DisputeStatusEntity"; "reason_disputes" = "ReasonDisputesEntity"
    "subscription_status" = "SubscriptionStatusEntity"; "subscription_type" = "SubscriptionTypeEntity"; "transaction_types" = "TransactionTypesEntity"
    "roles" = "RolesEntity"; "status_bids" = "StatusBidsEntity"; "status_trip" = "StatusTripEntity"
    "vehicles_status" = "VehiclesStatusEntity"; "document_category" = "DocumentCategoryEntity"
}

foreach ($f in $lookupFolders) {
    $c = $lookupClass[$f]
    $t = $f
    $defs += @{
        F = $f; C = $c; T = $t
        P = @"
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
"@
        CFG = @"
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasColumnName("description").HasColumnType("text");
"@
    }
}

# assignment_role (ya existe clase AssignmentEntity)
$defs += @{ F = "assignment_role"; C = "AssignmentEntity"; T = "assignment_role"; P = @"
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
"@; CFG = @"
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(50).IsRequired();
        builder.Property(x => x.Description).HasColumnName("description").HasColumnType("text");
"@ }

# Resto de tablas inferidas
$more = @(
    @{ F = "bids"; C = "BidsEntity"; T = "bids"; P = @"
    public Guid Id { get; set; }
    public Guid LoadId { get; set; }
    public Guid DriverId { get; set; }
    public decimal Amount { get; set; }
    public Guid StatusBidsId { get; set; }
    public DateTime CreatedAt { get; set; }
"@; CFG = @"
        builder.Property(x => x.LoadId).HasColumnName("load_id").IsRequired();
        builder.Property(x => x.DriverId).HasColumnName("driver_id").IsRequired();
        builder.Property(x => x.Amount).HasColumnName("amount").HasColumnType("decimal(15,2)").IsRequired();
        builder.Property(x => x.StatusBidsId).HasColumnName("status_bids_id").IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
"@ }
    @{ F = "chat_rooms"; C = "ChatRoomsEntity"; T = "chat_rooms"; P = @"
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public Guid? LoadId { get; set; }
    public DateTime CreatedAt { get; set; }
"@; CFG = @"
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(150);
        builder.Property(x => x.LoadId).HasColumnName("load_id");
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
"@ }
    @{ F = "chat_participants"; C = "ChatParticipantsEntity"; T = "chat_participants"; P = @"
    public Guid ChatRoomId { get; set; }
    public Guid PersonId { get; set; }
    public DateTime JoinedAt { get; set; }
"@; CFG = @"
        builder.HasKey(x => new { x.ChatRoomId, x.PersonId });
        builder.Property(x => x.ChatRoomId).HasColumnName("chat_room_id").IsRequired();
        builder.Property(x => x.PersonId).HasColumnName("person_id").IsRequired();
        builder.Property(x => x.JoinedAt).HasColumnName("joined_at").IsRequired();
"@ }
    @{ F = "countries"; C = "CountriesEntity"; T = "countries"; P = @"
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string IsoCode { get; set; } = string.Empty;
"@; CFG = @"
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.IsoCode).HasColumnName("iso_code").HasMaxLength(3).IsRequired();
"@ }
    @{ F = "states_regions"; C = "StatesRegionsEntity"; T = "states_regions"; P = @"
    public Guid Id { get; set; }
    public Guid CountryId { get; set; }
    public string Name { get; set; } = string.Empty;
"@; CFG = @"
        builder.Property(x => x.CountryId).HasColumnName("country_id").IsRequired();
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
"@ }
    @{ F = "cities_municipalities"; C = "CitiesMunicipalitiesEntity"; T = "cities_municipalities"; P = @"
    public Guid Id { get; set; }
    public Guid StateRegionId { get; set; }
    public string Name { get; set; } = string.Empty;
"@; CFG = @"
        builder.Property(x => x.StateRegionId).HasColumnName("state_region_id").IsRequired();
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(120).IsRequired();
"@ }
    @{ F = "city_pricing_rules"; C = "CityPricingRulesEntity"; T = "city_pricing_rules"; P = @"
    public Guid Id { get; set; }
    public Guid CityId { get; set; }
    public decimal BasePrice { get; set; }
    public string? RuleJson { get; set; }
"@; CFG = @"
        builder.Property(x => x.CityId).HasColumnName("city_id").IsRequired();
        builder.Property(x => x.BasePrice).HasColumnName("base_price").HasColumnType("decimal(15,2)").IsRequired();
        builder.Property(x => x.RuleJson).HasColumnName("rule_json").HasColumnType("json");
"@ }
    @{ F = "company_documents"; C = "CompanyDocumentsEntity"; T = "company_documents"; P = @"
    public Guid Id { get; set; }
    public Guid CompanyId { get; set; }
    public Guid TypeDocumentId { get; set; }
    public Guid DocumentStatusId { get; set; }
    public string? FileUrl { get; set; }
    public DateOnly? ExpirationDate { get; set; }
"@; CFG = @"
        builder.Property(x => x.CompanyId).HasColumnName("company_id").IsRequired();
        builder.Property(x => x.TypeDocumentId).HasColumnName("type_document_id").IsRequired();
        builder.Property(x => x.DocumentStatusId).HasColumnName("document_status_id").IsRequired();
        builder.Property(x => x.FileUrl).HasColumnName("file_url").HasColumnType("text");
        builder.Property(x => x.ExpirationDate).HasColumnName("expiration_date");
"@ }
    @{ F = "company_vehicles"; C = "CompanyVehiclesEntity"; T = "company_vehicles"; P = @"
    public Guid CompanyId { get; set; }
    public Guid VehicleId { get; set; }
"@; CFG = @"
        builder.HasKey(x => new { x.CompanyId, x.VehicleId });
        builder.Property(x => x.CompanyId).HasColumnName("company_id").IsRequired();
        builder.Property(x => x.VehicleId).HasColumnName("vehicle_id").IsRequired();
"@ }
    @{ F = "credit_transactions"; C = "CreditTransactionsEntity"; T = "credit_transactions"; P = @"
    public Guid Id { get; set; }
    public Guid CreditWalletId { get; set; }
    public Guid TransactionTypeId { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
"@; CFG = @"
        builder.Property(x => x.CreditWalletId).HasColumnName("credit_wallet_id").IsRequired();
        builder.Property(x => x.TransactionTypeId).HasColumnName("transaction_type_id").IsRequired();
        builder.Property(x => x.Amount).HasColumnName("amount").HasColumnType("decimal(15,2)").IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
"@ }
    @{ F = "disputes"; C = "DisputesEntity"; T = "disputes"; P = @"
    public Guid Id { get; set; }
    public Guid TripId { get; set; }
    public Guid DisputeStatusId { get; set; }
    public Guid ReasonDisputesId { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; }
"@; CFG = @"
        builder.Property(x => x.TripId).HasColumnName("trip_id").IsRequired();
        builder.Property(x => x.DisputeStatusId).HasColumnName("dispute_status_id").IsRequired();
        builder.Property(x => x.ReasonDisputesId).HasColumnName("reason_disputes_id").IsRequired();
        builder.Property(x => x.Notes).HasColumnName("notes").HasColumnType("text");
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
"@ }
    @{ F = "documents_customers"; C = "DocumentsCustomersEntity"; T = "documents_customers"; P = @"
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Guid TypeDocumentId { get; set; }
    public string DocumentNumber { get; set; } = string.Empty;
    public DateOnly? ExpirationDate { get; set; }
    public string? FileUrl { get; set; }
    public Guid DocumentStatusId { get; set; }
"@; CFG = @"
        builder.Property(x => x.CustomerId).HasColumnName("customer_id").IsRequired();
        builder.Property(x => x.TypeDocumentId).HasColumnName("type_document_id").IsRequired();
        builder.Property(x => x.DocumentNumber).HasColumnName("document_number").HasMaxLength(50).IsRequired();
        builder.Property(x => x.ExpirationDate).HasColumnName("expiration_date");
        builder.Property(x => x.FileUrl).HasColumnName("file_url").HasColumnType("text");
        builder.Property(x => x.DocumentStatusId).HasColumnName("document_status_id").IsRequired();
"@ }
    @{ F = "documents_vehicles"; C = "DocumentsVehiclesEntity"; T = "documents_vehicles"; P = @"
    public Guid Id { get; set; }
    public Guid VehicleId { get; set; }
    public Guid TypeDocumentId { get; set; }
    public string DocumentNumber { get; set; } = string.Empty;
    public DateOnly? ExpirationDate { get; set; }
    public string? FileUrl { get; set; }
    public Guid DocumentStatusId { get; set; }
"@; CFG = @"
        builder.Property(x => x.VehicleId).HasColumnName("vehicle_id").IsRequired();
        builder.Property(x => x.TypeDocumentId).HasColumnName("type_document_id").IsRequired();
        builder.Property(x => x.DocumentNumber).HasColumnName("document_number").HasMaxLength(50).IsRequired();
        builder.Property(x => x.ExpirationDate).HasColumnName("expiration_date");
        builder.Property(x => x.FileUrl).HasColumnName("file_url").HasColumnType("text");
        builder.Property(x => x.DocumentStatusId).HasColumnName("document_status_id").IsRequired();
"@ }
    @{ F = "drivers"; C = "DriversEntity"; T = "drivers"; P = @"
    public Guid Id { get; set; }
    public Guid PersonId { get; set; }
    public string LicenseNumber { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
"@; CFG = @"
        builder.Property(x => x.PersonId).HasColumnName("person_id").IsRequired();
        builder.Property(x => x.LicenseNumber).HasColumnName("license_number").HasMaxLength(50).IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
"@ }
    @{ F = "drivers_vehicles"; C = "DriversVehiclesEntity"; T = "drivers_vehicles"; P = @"
    public Guid DriverId { get; set; }
    public Guid VehicleId { get; set; }
"@; CFG = @"
        builder.HasKey(x => new { x.DriverId, x.VehicleId });
        builder.Property(x => x.DriverId).HasColumnName("driver_id").IsRequired();
        builder.Property(x => x.VehicleId).HasColumnName("vehicle_id").IsRequired();
"@ }
    @{ F = "load_details"; C = "LoadDetailsEntity"; T = "load_details"; P = @"
    public Guid Id { get; set; }
    public Guid LoadId { get; set; }
    public string DetailKey { get; set; } = string.Empty;
    public string DetailValue { get; set; } = string.Empty;
"@; CFG = @"
        builder.Property(x => x.LoadId).HasColumnName("load_id").IsRequired();
        builder.Property(x => x.DetailKey).HasColumnName("detail_key").HasMaxLength(100).IsRequired();
        builder.Property(x => x.DetailValue).HasColumnName("detail_value").HasColumnType("text").IsRequired();
"@ }
    @{ F = "load_images"; C = "LoadImagesEntity"; T = "load_images"; P = @"
    public Guid Id { get; set; }
    public Guid LoadId { get; set; }
    public string Url { get; set; } = string.Empty;
    public int SortOrder { get; set; }
"@; CFG = @"
        builder.Property(x => x.LoadId).HasColumnName("load_id").IsRequired();
        builder.Property(x => x.Url).HasColumnName("url").HasColumnType("text").IsRequired();
        builder.Property(x => x.SortOrder).HasColumnName("sort_order").IsRequired();
"@ }
    @{ F = "load_status_history"; C = "LoadStatusHistoryEntity"; T = "load_status_history"; P = @"
    public Guid Id { get; set; }
    public Guid LoadId { get; set; }
    public Guid LoadStatusId { get; set; }
    public DateTime ChangedAt { get; set; }
"@; CFG = @"
        builder.Property(x => x.LoadId).HasColumnName("load_id").IsRequired();
        builder.Property(x => x.LoadStatusId).HasColumnName("load_status_id").IsRequired();
        builder.Property(x => x.ChangedAt).HasColumnName("changed_at").IsRequired();
"@ }
    @{ F = "person_plans"; C = "PersonPlansEntity"; T = "person_plans"; P = @"
    public Guid Id { get; set; }
    public Guid PersonId { get; set; }
    public Guid PlanId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
"@; CFG = @"
        builder.Property(x => x.PersonId).HasColumnName("person_id").IsRequired();
        builder.Property(x => x.PlanId).HasColumnName("plan_id").IsRequired();
        builder.Property(x => x.StartDate).HasColumnName("start_date").IsRequired();
        builder.Property(x => x.EndDate).HasColumnName("end_date");
"@ }
    @{ F = "person_roles"; C = "PersonRolesEntity"; T = "person_roles"; P = @"
    public Guid PersonId { get; set; }
    public Guid RoleId { get; set; }
"@; CFG = @"
        builder.HasKey(x => new { x.PersonId, x.RoleId });
        builder.Property(x => x.PersonId).HasColumnName("person_id").IsRequired();
        builder.Property(x => x.RoleId).HasColumnName("role_id").IsRequired();
"@ }
    @{ F = "person_transport"; C = "PersonTransportEntity"; T = "person_transport"; P = @"
    public Guid PersonId { get; set; }
    public Guid TransportCompanyId { get; set; }
"@; CFG = @"
        builder.HasKey(x => new { x.PersonId, x.TransportCompanyId });
        builder.Property(x => x.PersonId).HasColumnName("person_id").IsRequired();
        builder.Property(x => x.TransportCompanyId).HasColumnName("transport_company_id").IsRequired();
"@ }
    @{ F = "plans"; C = "PlansEntity"; T = "plans"; P = @"
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string BillingPeriod { get; set; } = string.Empty;
"@; CFG = @"
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Price).HasColumnName("price").HasColumnType("decimal(15,2)").IsRequired();
        builder.Property(x => x.BillingPeriod).HasColumnName("billing_period").HasMaxLength(50).IsRequired();
"@ }
    @{ F = "price_history"; C = "PriceHistoryEntity"; T = "price_history"; P = @"
    public Guid Id { get; set; }
    public Guid PlanId { get; set; }
    public decimal Amount { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
"@; CFG = @"
        builder.Property(x => x.PlanId).HasColumnName("plan_id").IsRequired();
        builder.Property(x => x.Amount).HasColumnName("amount").HasColumnType("decimal(15,2)").IsRequired();
        builder.Property(x => x.ValidFrom).HasColumnName("valid_from").IsRequired();
        builder.Property(x => x.ValidTo).HasColumnName("valid_to");
"@ }
    @{ F = "ratings"; C = "RatingsEntity"; T = "ratings"; P = @"
    public Guid Id { get; set; }
    public Guid TripId { get; set; }
    public Guid RaterPersonId { get; set; }
    public Guid RatedPersonId { get; set; }
    public int Score { get; set; }
    public string? Comment { get; set; }
    public DateTime CreatedAt { get; set; }
"@; CFG = @"
        builder.Property(x => x.TripId).HasColumnName("trip_id").IsRequired();
        builder.Property(x => x.RaterPersonId).HasColumnName("rater_person_id").IsRequired();
        builder.Property(x => x.RatedPersonId).HasColumnName("rated_person_id").IsRequired();
        builder.Property(x => x.Score).HasColumnName("score").IsRequired();
        builder.Property(x => x.Comment).HasColumnName("comment").HasColumnType("text");
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
"@ }
    @{ F = "return_load_suggestions"; C = "ReturnLoadSuggestionsEntity"; T = "return_load_suggestions"; P = @"
    public Guid Id { get; set; }
    public Guid LoadId { get; set; }
    public Guid SuggestedLoadId { get; set; }
    public decimal Score { get; set; }
"@; CFG = @"
        builder.Property(x => x.LoadId).HasColumnName("load_id").IsRequired();
        builder.Property(x => x.SuggestedLoadId).HasColumnName("suggested_load_id").IsRequired();
        builder.Property(x => x.Score).HasColumnName("score").HasColumnType("decimal(10,4)").IsRequired();
"@ }
    @{ F = "subscriptions"; C = "SubscriptionsEntity"; T = "subscriptions"; P = @"
    public Guid Id { get; set; }
    public Guid PersonId { get; set; }
    public Guid PlanId { get; set; }
    public Guid SubscriptionStatusId { get; set; }
    public Guid SubscriptionTypeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
"@; CFG = @"
        builder.Property(x => x.PersonId).HasColumnName("person_id").IsRequired();
        builder.Property(x => x.PlanId).HasColumnName("plan_id").IsRequired();
        builder.Property(x => x.SubscriptionStatusId).HasColumnName("subscription_status_id").IsRequired();
        builder.Property(x => x.SubscriptionTypeId).HasColumnName("subscription_type_id").IsRequired();
        builder.Property(x => x.StartDate).HasColumnName("start_date").IsRequired();
        builder.Property(x => x.EndDate).HasColumnName("end_date");
"@ }
    @{ F = "transport_companies"; C = "TransportCompaniesEntity"; T = "transport_companies"; P = @"
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? TaxId { get; set; }
    public Guid CompaniesStatusId { get; set; }
"@; CFG = @"
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(150).IsRequired();
        builder.Property(x => x.TaxId).HasColumnName("tax_id").HasMaxLength(50);
        builder.Property(x => x.CompaniesStatusId).HasColumnName("companies_status_id").IsRequired();
"@ }
    @{ F = "travel_scale"; C = "TravelScaleEntity"; T = "travel_scale"; P = @"
    public Guid Id { get; set; }
    public Guid TripId { get; set; }
    public decimal WeightKg { get; set; }
    public string? LocationNote { get; set; }
    public DateTime RecordedAt { get; set; }
"@; CFG = @"
        builder.Property(x => x.TripId).HasColumnName("trip_id").IsRequired();
        builder.Property(x => x.WeightKg).HasColumnName("weight_kg").HasColumnType("decimal(12,2)").IsRequired();
        builder.Property(x => x.LocationNote).HasColumnName("location_note").HasColumnType("text");
        builder.Property(x => x.RecordedAt).HasColumnName("recorded_at").IsRequired();
"@ }
    @{ F = "trip_checkpoints"; C = "TripCheckpointsEntity"; T = "trip_checkpoints"; P = @"
    public Guid Id { get; set; }
    public Guid TripId { get; set; }
    public int Sequence { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public DateTime CheckpointTime { get; set; }
    public string? Notes { get; set; }
"@; CFG = @"
        builder.Property(x => x.TripId).HasColumnName("trip_id").IsRequired();
        builder.Property(x => x.Sequence).HasColumnName("sequence").IsRequired();
        builder.Property(x => x.Latitude).HasColumnName("latitude").HasColumnType("decimal(10,7)").IsRequired();
        builder.Property(x => x.Longitude).HasColumnName("longitude").HasColumnType("decimal(10,7)").IsRequired();
        builder.Property(x => x.CheckpointTime).HasColumnName("checkpoint_time").IsRequired();
        builder.Property(x => x.Notes).HasColumnName("notes").HasColumnType("text");
"@ }
    @{ F = "trip_status_history"; C = "TripStatusHistoryEntity"; T = "trip_status_history"; P = @"
    public Guid Id { get; set; }
    public Guid TripId { get; set; }
    public Guid TripStatusId { get; set; }
    public DateTime ChangedAt { get; set; }
"@; CFG = @"
        builder.Property(x => x.TripId).HasColumnName("trip_id").IsRequired();
        builder.Property(x => x.TripStatusId).HasColumnName("trip_status_id").IsRequired();
        builder.Property(x => x.ChangedAt).HasColumnName("changed_at").IsRequired();
"@ }
)

foreach ($m in $more) { $defs += $m }

foreach ($d in $defs) {
    $ns = "transporte.src.modules.$($d.F).Infrastructure.entity"
    $cfgClass = "$($d.C)Configuration"
    $entityPath = Join-Path $modulesRoot "$($d.F)\Infrastructure\entity\$($d.C).cs"
    $cfgPath = Join-Path $modulesRoot "$($d.F)\Infrastructure\entity\$cfgClass.cs"

    $idCfg = if ($d.C -eq "ChatParticipantsEntity" -or $d.C -eq "CompanyVehiclesEntity" -or $d.C -eq "PersonRolesEntity" -or $d.C -eq "PersonTransportEntity" -or $d.C -eq "DriversVehiclesEntity") { "" } else { @"
        builder.Property(x => x.Id).HasColumnName("id");
"@ }

    $entityBody = @"
namespace $ns;

public sealed class $($d.C)
{
$($d.P)
}
"@

    $keyLine = if ($d.C -match "ChatParticipantsEntity|CompanyVehiclesEntity|PersonRolesEntity|PersonTransportEntity|DriversVehiclesEntity") { "" } else { "        builder.HasKey(x => x.Id);`n" }

    $cfgBody = @"
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace $ns;

public sealed class $cfgClass : IEntityTypeConfiguration<$($d.C)>
{
    public void Configure(EntityTypeBuilder<$($d.C)> builder)
    {
        builder.ToTable("$($d.T)");
$keyLine$idCfg
$($d.CFG)
    }
}
"@
    Write-TextFile $entityPath $entityBody
    Write-TextFile $cfgPath $cfgBody
}

Write-Host "Generadas entidades en $modulesRoot"

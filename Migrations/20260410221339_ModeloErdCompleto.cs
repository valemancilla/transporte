using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace transporte.Migrations
{
    /// <inheritdoc />
    public partial class ModeloErdCompleto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trip_assignments_persons_person_id",
                table: "trip_assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicles_transport_companies_company_id",
                table: "vehicles");

            migrationBuilder.DropIndex(
                name: "IX_trip_assignments_person_id",
                table: "trip_assignments");

            migrationBuilder.DropIndex(
                name: "IX_vehicles_company_id",
                table: "vehicles");

            migrationBuilder.AddColumn<Guid>(
                name: "driver_id",
                table: "trip_assignments",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "vehicle_id",
                table: "trip_assignments",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.Sql(
                """
                UPDATE trip_assignments ta
                INNER JOIN drivers d ON d.person_id = ta.person_id
                SET ta.driver_id = d.id
                """);

            migrationBuilder.Sql(
                """
                UPDATE trip_assignments ta
                INNER JOIN trips t ON t.id = ta.trip_id
                SET ta.vehicle_id = t.vehicle_id
                """);

            migrationBuilder.Sql(
                "UPDATE trip_assignments SET driver_id = (SELECT id FROM drivers LIMIT 1) WHERE driver_id IS NULL");

            migrationBuilder.Sql(
                "UPDATE trip_assignments SET vehicle_id = (SELECT id FROM vehicles LIMIT 1) WHERE vehicle_id IS NULL");

            migrationBuilder.DropColumn(
                name: "person_id",
                table: "trip_assignments");

            migrationBuilder.AddColumn<Guid>(
                name: "owner_id",
                table: "vehicles",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.Sql(
                """
                UPDATE vehicles v
                INNER JOIN transport_companies c ON c.id = v.company_id
                INNER JOIN persons p ON p.company_id = c.id
                SET v.owner_id = p.id
                """);

            migrationBuilder.Sql(
                "UPDATE vehicles SET owner_id = (SELECT id FROM persons LIMIT 1) WHERE owner_id IS NULL");

            migrationBuilder.DropColumn(
                name: "company_id",
                table: "vehicles");

            migrationBuilder.AlterColumn<Guid>(
                name: "driver_id",
                table: "trip_assignments",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "vehicle_id",
                table: "trip_assignments",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "owner_id",
                table: "vehicles",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "document_category_id",
                table: "type_documents",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "city_id",
                table: "travel_scale",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "legal_representative_person_id",
                table: "transport_companies",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "payment_id",
                table: "subscriptions",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "external_reference",
                table: "payments",
                type: "varchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "reporter_person_id",
                table: "disputes",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.Sql(
                """
                UPDATE disputes d
                INNER JOIN trips t ON t.id = d.trip_id
                INNER JOIN drivers dr ON dr.id = t.driver_id
                SET d.reporter_person_id = dr.person_id
                """);

            migrationBuilder.Sql(
                "UPDATE disputes SET reporter_person_id = (SELECT id FROM persons LIMIT 1) WHERE reporter_person_id = '00000000-0000-0000-0000-000000000000'");

            migrationBuilder.AlterColumn<Guid>(
                name: "trip_id",
                table: "chat_rooms",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "load_id",
                table: "chat_rooms",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "message_type_id",
                table: "chat_messages",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "company_drivers",
                columns: table => new
                {
                    company_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    driver_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company_drivers", x => new { x.company_id, x.driver_id });
                    table.ForeignKey(
                        name: "FK_company_drivers_drivers_driver_id",
                        column: x => x.driver_id,
                        principalTable: "drivers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_company_drivers_transport_companies_company_id",
                        column: x => x.company_id,
                        principalTable: "transport_companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_type_documents_document_category_id",
                table: "type_documents",
                column: "document_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_trip_status_history_trip_id",
                table: "trip_status_history",
                column: "trip_id");

            migrationBuilder.CreateIndex(
                name: "IX_trip_status_history_trip_status_id",
                table: "trip_status_history",
                column: "trip_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_trip_checkpoints_trip_id",
                table: "trip_checkpoints",
                column: "trip_id");

            migrationBuilder.CreateIndex(
                name: "IX_trip_assignments_driver_id",
                table: "trip_assignments",
                column: "driver_id");

            migrationBuilder.CreateIndex(
                name: "IX_travel_scale_city_id",
                table: "travel_scale",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_travel_scale_trip_id",
                table: "travel_scale",
                column: "trip_id");

            migrationBuilder.CreateIndex(
                name: "IX_transport_companies_legal_representative_person_id",
                table: "transport_companies",
                column: "legal_representative_person_id");

            migrationBuilder.CreateIndex(
                name: "IX_subscriptions_payment_id",
                table: "subscriptions",
                column: "payment_id");

            migrationBuilder.CreateIndex(
                name: "IX_subscriptions_person_id",
                table: "subscriptions",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_subscriptions_plan_id",
                table: "subscriptions",
                column: "plan_id");

            migrationBuilder.CreateIndex(
                name: "IX_subscriptions_subscription_status_id",
                table: "subscriptions",
                column: "subscription_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_subscriptions_subscription_type_id",
                table: "subscriptions",
                column: "subscription_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_states_regions_country_id",
                table: "states_regions",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_return_load_suggestions_load_id",
                table: "return_load_suggestions",
                column: "load_id");

            migrationBuilder.CreateIndex(
                name: "IX_return_load_suggestions_suggested_load_id",
                table: "return_load_suggestions",
                column: "suggested_load_id");

            migrationBuilder.CreateIndex(
                name: "IX_ratings_rated_person_id",
                table: "ratings",
                column: "rated_person_id");

            migrationBuilder.CreateIndex(
                name: "IX_ratings_rater_person_id",
                table: "ratings",
                column: "rater_person_id");

            migrationBuilder.CreateIndex(
                name: "IX_ratings_trip_id",
                table: "ratings",
                column: "trip_id");

            migrationBuilder.CreateIndex(
                name: "IX_price_history_plan_id",
                table: "price_history",
                column: "plan_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_transport_transport_company_id",
                table: "person_transport",
                column: "transport_company_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_roles_role_id",
                table: "person_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_plans_person_id",
                table: "person_plans",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_plans_plan_id",
                table: "person_plans",
                column: "plan_id");

            migrationBuilder.CreateIndex(
                name: "IX_load_status_history_load_id",
                table: "load_status_history",
                column: "load_id");

            migrationBuilder.CreateIndex(
                name: "IX_load_images_load_id",
                table: "load_images",
                column: "load_id");

            migrationBuilder.CreateIndex(
                name: "IX_load_details_load_id",
                table: "load_details",
                column: "load_id");

            migrationBuilder.CreateIndex(
                name: "IX_drivers_vehicles_vehicle_id",
                table: "drivers_vehicles",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_documents_vehicles_document_status_id",
                table: "documents_vehicles",
                column: "document_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_documents_vehicles_type_document_id",
                table: "documents_vehicles",
                column: "type_document_id");

            migrationBuilder.CreateIndex(
                name: "IX_documents_vehicles_vehicle_id",
                table: "documents_vehicles",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_documents_drivers_document_status_id",
                table: "documents_drivers",
                column: "document_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_documents_drivers_driver_id",
                table: "documents_drivers",
                column: "driver_id");

            migrationBuilder.CreateIndex(
                name: "IX_documents_drivers_type_document_id",
                table: "documents_drivers",
                column: "type_document_id");

            migrationBuilder.CreateIndex(
                name: "IX_documents_customers_customer_id",
                table: "documents_customers",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_documents_customers_document_status_id",
                table: "documents_customers",
                column: "document_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_documents_customers_type_document_id",
                table: "documents_customers",
                column: "type_document_id");

            migrationBuilder.CreateIndex(
                name: "IX_disputes_dispute_status_id",
                table: "disputes",
                column: "dispute_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_disputes_reason_disputes_id",
                table: "disputes",
                column: "reason_disputes_id");

            migrationBuilder.CreateIndex(
                name: "IX_disputes_reporter_person_id",
                table: "disputes",
                column: "reporter_person_id");

            migrationBuilder.CreateIndex(
                name: "IX_disputes_trip_id",
                table: "disputes",
                column: "trip_id");

            migrationBuilder.CreateIndex(
                name: "IX_company_vehicles_vehicle_id",
                table: "company_vehicles",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_company_documents_company_id",
                table: "company_documents",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_company_documents_document_status_id",
                table: "company_documents",
                column: "document_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_company_documents_type_document_id",
                table: "company_documents",
                column: "type_document_id");

            migrationBuilder.CreateIndex(
                name: "IX_city_pricing_rules_city_id",
                table: "city_pricing_rules",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_cities_municipalities_state_region_id",
                table: "cities_municipalities",
                column: "state_region_id");

            migrationBuilder.CreateIndex(
                name: "IX_chat_rooms_load_id",
                table: "chat_rooms",
                column: "load_id");

            migrationBuilder.CreateIndex(
                name: "IX_chat_messages_message_type_id",
                table: "chat_messages",
                column: "message_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_audit_log_person_id",
                table: "audit_log",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_company_drivers_driver_id",
                table: "company_drivers",
                column: "driver_id");

            migrationBuilder.AddForeignKey(
                name: "FK_audit_log_persons_person_id",
                table: "audit_log",
                column: "person_id",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_chat_messages_message_type_message_type_id",
                table: "chat_messages",
                column: "message_type_id",
                principalTable: "message_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_chat_rooms_loads_load_id",
                table: "chat_rooms",
                column: "load_id",
                principalTable: "loads",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_cities_municipalities_states_regions_state_region_id",
                table: "cities_municipalities",
                column: "state_region_id",
                principalTable: "states_regions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_city_pricing_rules_cities_municipalities_city_id",
                table: "city_pricing_rules",
                column: "city_id",
                principalTable: "cities_municipalities",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_company_documents_documents_status_document_status_id",
                table: "company_documents",
                column: "document_status_id",
                principalTable: "documents_status",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_company_documents_transport_companies_company_id",
                table: "company_documents",
                column: "company_id",
                principalTable: "transport_companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_company_documents_type_documents_type_document_id",
                table: "company_documents",
                column: "type_document_id",
                principalTable: "type_documents",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_company_vehicles_transport_companies_company_id",
                table: "company_vehicles",
                column: "company_id",
                principalTable: "transport_companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_company_vehicles_vehicles_vehicle_id",
                table: "company_vehicles",
                column: "vehicle_id",
                principalTable: "vehicles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_disputes_dispute_status_dispute_status_id",
                table: "disputes",
                column: "dispute_status_id",
                principalTable: "dispute_status",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_disputes_persons_reporter_person_id",
                table: "disputes",
                column: "reporter_person_id",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_disputes_reason_disputes_reason_disputes_id",
                table: "disputes",
                column: "reason_disputes_id",
                principalTable: "reason_disputes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_disputes_trips_trip_id",
                table: "disputes",
                column: "trip_id",
                principalTable: "trips",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_documents_customers_documents_status_document_status_id",
                table: "documents_customers",
                column: "document_status_id",
                principalTable: "documents_status",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_documents_customers_persons_customer_id",
                table: "documents_customers",
                column: "customer_id",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_documents_customers_type_documents_type_document_id",
                table: "documents_customers",
                column: "type_document_id",
                principalTable: "type_documents",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_documents_drivers_documents_status_document_status_id",
                table: "documents_drivers",
                column: "document_status_id",
                principalTable: "documents_status",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_documents_drivers_drivers_driver_id",
                table: "documents_drivers",
                column: "driver_id",
                principalTable: "drivers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_documents_drivers_type_documents_type_document_id",
                table: "documents_drivers",
                column: "type_document_id",
                principalTable: "type_documents",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_documents_vehicles_documents_status_document_status_id",
                table: "documents_vehicles",
                column: "document_status_id",
                principalTable: "documents_status",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_documents_vehicles_type_documents_type_document_id",
                table: "documents_vehicles",
                column: "type_document_id",
                principalTable: "type_documents",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_documents_vehicles_vehicles_vehicle_id",
                table: "documents_vehicles",
                column: "vehicle_id",
                principalTable: "vehicles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_drivers_vehicles_drivers_driver_id",
                table: "drivers_vehicles",
                column: "driver_id",
                principalTable: "drivers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_drivers_vehicles_vehicles_vehicle_id",
                table: "drivers_vehicles",
                column: "vehicle_id",
                principalTable: "vehicles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_load_details_loads_load_id",
                table: "load_details",
                column: "load_id",
                principalTable: "loads",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_load_images_loads_load_id",
                table: "load_images",
                column: "load_id",
                principalTable: "loads",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_load_status_history_loads_load_id",
                table: "load_status_history",
                column: "load_id",
                principalTable: "loads",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_person_plans_persons_person_id",
                table: "person_plans",
                column: "person_id",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_person_plans_plans_plan_id",
                table: "person_plans",
                column: "plan_id",
                principalTable: "plans",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_person_roles_persons_person_id",
                table: "person_roles",
                column: "person_id",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_person_roles_roles_role_id",
                table: "person_roles",
                column: "role_id",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_person_transport_persons_person_id",
                table: "person_transport",
                column: "person_id",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_person_transport_transport_companies_transport_company_id",
                table: "person_transport",
                column: "transport_company_id",
                principalTable: "transport_companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_price_history_plans_plan_id",
                table: "price_history",
                column: "plan_id",
                principalTable: "plans",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ratings_persons_rated_person_id",
                table: "ratings",
                column: "rated_person_id",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ratings_persons_rater_person_id",
                table: "ratings",
                column: "rater_person_id",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ratings_trips_trip_id",
                table: "ratings",
                column: "trip_id",
                principalTable: "trips",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_return_load_suggestions_loads_load_id",
                table: "return_load_suggestions",
                column: "load_id",
                principalTable: "loads",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_return_load_suggestions_loads_suggested_load_id",
                table: "return_load_suggestions",
                column: "suggested_load_id",
                principalTable: "loads",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_states_regions_countries_country_id",
                table: "states_regions",
                column: "country_id",
                principalTable: "countries",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_subscriptions_payments_payment_id",
                table: "subscriptions",
                column: "payment_id",
                principalTable: "payments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_subscriptions_persons_person_id",
                table: "subscriptions",
                column: "person_id",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_subscriptions_plans_plan_id",
                table: "subscriptions",
                column: "plan_id",
                principalTable: "plans",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_subscriptions_subscription_status_subscription_status_id",
                table: "subscriptions",
                column: "subscription_status_id",
                principalTable: "subscription_status",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_subscriptions_subscription_type_subscription_type_id",
                table: "subscriptions",
                column: "subscription_type_id",
                principalTable: "subscription_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_transport_companies_persons_legal_representative_person_id",
                table: "transport_companies",
                column: "legal_representative_person_id",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_travel_scale_cities_municipalities_city_id",
                table: "travel_scale",
                column: "city_id",
                principalTable: "cities_municipalities",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_travel_scale_trips_trip_id",
                table: "travel_scale",
                column: "trip_id",
                principalTable: "trips",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_trip_assignments_drivers_driver_id",
                table: "trip_assignments",
                column: "driver_id",
                principalTable: "drivers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_trip_assignments_vehicles_vehicle_id",
                table: "trip_assignments",
                column: "vehicle_id",
                principalTable: "vehicles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_trip_checkpoints_trips_trip_id",
                table: "trip_checkpoints",
                column: "trip_id",
                principalTable: "trips",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_trip_status_history_status_trip_trip_status_id",
                table: "trip_status_history",
                column: "trip_status_id",
                principalTable: "status_trip",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_trip_status_history_trips_trip_id",
                table: "trip_status_history",
                column: "trip_id",
                principalTable: "trips",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_type_documents_document_category_document_category_id",
                table: "type_documents",
                column: "document_category_id",
                principalTable: "document_category",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicles_persons_owner_id",
                table: "vehicles",
                column: "owner_id",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_audit_log_persons_person_id",
                table: "audit_log");

            migrationBuilder.DropForeignKey(
                name: "FK_chat_messages_message_type_message_type_id",
                table: "chat_messages");

            migrationBuilder.DropForeignKey(
                name: "FK_chat_rooms_loads_load_id",
                table: "chat_rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_cities_municipalities_states_regions_state_region_id",
                table: "cities_municipalities");

            migrationBuilder.DropForeignKey(
                name: "FK_city_pricing_rules_cities_municipalities_city_id",
                table: "city_pricing_rules");

            migrationBuilder.DropForeignKey(
                name: "FK_company_documents_documents_status_document_status_id",
                table: "company_documents");

            migrationBuilder.DropForeignKey(
                name: "FK_company_documents_transport_companies_company_id",
                table: "company_documents");

            migrationBuilder.DropForeignKey(
                name: "FK_company_documents_type_documents_type_document_id",
                table: "company_documents");

            migrationBuilder.DropForeignKey(
                name: "FK_company_vehicles_transport_companies_company_id",
                table: "company_vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_company_vehicles_vehicles_vehicle_id",
                table: "company_vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_disputes_dispute_status_dispute_status_id",
                table: "disputes");

            migrationBuilder.DropForeignKey(
                name: "FK_disputes_persons_reporter_person_id",
                table: "disputes");

            migrationBuilder.DropForeignKey(
                name: "FK_disputes_reason_disputes_reason_disputes_id",
                table: "disputes");

            migrationBuilder.DropForeignKey(
                name: "FK_disputes_trips_trip_id",
                table: "disputes");

            migrationBuilder.DropForeignKey(
                name: "FK_documents_customers_documents_status_document_status_id",
                table: "documents_customers");

            migrationBuilder.DropForeignKey(
                name: "FK_documents_customers_persons_customer_id",
                table: "documents_customers");

            migrationBuilder.DropForeignKey(
                name: "FK_documents_customers_type_documents_type_document_id",
                table: "documents_customers");

            migrationBuilder.DropForeignKey(
                name: "FK_documents_drivers_documents_status_document_status_id",
                table: "documents_drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_documents_drivers_drivers_driver_id",
                table: "documents_drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_documents_drivers_type_documents_type_document_id",
                table: "documents_drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_documents_vehicles_documents_status_document_status_id",
                table: "documents_vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_documents_vehicles_type_documents_type_document_id",
                table: "documents_vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_documents_vehicles_vehicles_vehicle_id",
                table: "documents_vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_drivers_vehicles_drivers_driver_id",
                table: "drivers_vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_drivers_vehicles_vehicles_vehicle_id",
                table: "drivers_vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_load_details_loads_load_id",
                table: "load_details");

            migrationBuilder.DropForeignKey(
                name: "FK_load_images_loads_load_id",
                table: "load_images");

            migrationBuilder.DropForeignKey(
                name: "FK_load_status_history_loads_load_id",
                table: "load_status_history");

            migrationBuilder.DropForeignKey(
                name: "FK_person_plans_persons_person_id",
                table: "person_plans");

            migrationBuilder.DropForeignKey(
                name: "FK_person_plans_plans_plan_id",
                table: "person_plans");

            migrationBuilder.DropForeignKey(
                name: "FK_person_roles_persons_person_id",
                table: "person_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_person_roles_roles_role_id",
                table: "person_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_person_transport_persons_person_id",
                table: "person_transport");

            migrationBuilder.DropForeignKey(
                name: "FK_person_transport_transport_companies_transport_company_id",
                table: "person_transport");

            migrationBuilder.DropForeignKey(
                name: "FK_price_history_plans_plan_id",
                table: "price_history");

            migrationBuilder.DropForeignKey(
                name: "FK_ratings_persons_rated_person_id",
                table: "ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_ratings_persons_rater_person_id",
                table: "ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_ratings_trips_trip_id",
                table: "ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_return_load_suggestions_loads_load_id",
                table: "return_load_suggestions");

            migrationBuilder.DropForeignKey(
                name: "FK_return_load_suggestions_loads_suggested_load_id",
                table: "return_load_suggestions");

            migrationBuilder.DropForeignKey(
                name: "FK_states_regions_countries_country_id",
                table: "states_regions");

            migrationBuilder.DropForeignKey(
                name: "FK_subscriptions_payments_payment_id",
                table: "subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_subscriptions_persons_person_id",
                table: "subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_subscriptions_plans_plan_id",
                table: "subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_subscriptions_subscription_status_subscription_status_id",
                table: "subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_subscriptions_subscription_type_subscription_type_id",
                table: "subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_transport_companies_persons_legal_representative_person_id",
                table: "transport_companies");

            migrationBuilder.DropForeignKey(
                name: "FK_travel_scale_cities_municipalities_city_id",
                table: "travel_scale");

            migrationBuilder.DropForeignKey(
                name: "FK_travel_scale_trips_trip_id",
                table: "travel_scale");

            migrationBuilder.DropForeignKey(
                name: "FK_trip_assignments_drivers_driver_id",
                table: "trip_assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_trip_assignments_vehicles_vehicle_id",
                table: "trip_assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_trip_checkpoints_trips_trip_id",
                table: "trip_checkpoints");

            migrationBuilder.DropForeignKey(
                name: "FK_trip_status_history_status_trip_trip_status_id",
                table: "trip_status_history");

            migrationBuilder.DropForeignKey(
                name: "FK_trip_status_history_trips_trip_id",
                table: "trip_status_history");

            migrationBuilder.DropForeignKey(
                name: "FK_type_documents_document_category_document_category_id",
                table: "type_documents");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicles_persons_owner_id",
                table: "vehicles");

            migrationBuilder.DropTable(
                name: "company_drivers");

            migrationBuilder.DropIndex(
                name: "IX_type_documents_document_category_id",
                table: "type_documents");

            migrationBuilder.DropIndex(
                name: "IX_trip_status_history_trip_id",
                table: "trip_status_history");

            migrationBuilder.DropIndex(
                name: "IX_trip_status_history_trip_status_id",
                table: "trip_status_history");

            migrationBuilder.DropIndex(
                name: "IX_trip_checkpoints_trip_id",
                table: "trip_checkpoints");

            migrationBuilder.DropIndex(
                name: "IX_trip_assignments_driver_id",
                table: "trip_assignments");

            migrationBuilder.DropIndex(
                name: "IX_travel_scale_city_id",
                table: "travel_scale");

            migrationBuilder.DropIndex(
                name: "IX_travel_scale_trip_id",
                table: "travel_scale");

            migrationBuilder.DropIndex(
                name: "IX_transport_companies_legal_representative_person_id",
                table: "transport_companies");

            migrationBuilder.DropIndex(
                name: "IX_subscriptions_payment_id",
                table: "subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_subscriptions_person_id",
                table: "subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_subscriptions_plan_id",
                table: "subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_subscriptions_subscription_status_id",
                table: "subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_subscriptions_subscription_type_id",
                table: "subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_states_regions_country_id",
                table: "states_regions");

            migrationBuilder.DropIndex(
                name: "IX_return_load_suggestions_load_id",
                table: "return_load_suggestions");

            migrationBuilder.DropIndex(
                name: "IX_return_load_suggestions_suggested_load_id",
                table: "return_load_suggestions");

            migrationBuilder.DropIndex(
                name: "IX_ratings_rated_person_id",
                table: "ratings");

            migrationBuilder.DropIndex(
                name: "IX_ratings_rater_person_id",
                table: "ratings");

            migrationBuilder.DropIndex(
                name: "IX_ratings_trip_id",
                table: "ratings");

            migrationBuilder.DropIndex(
                name: "IX_price_history_plan_id",
                table: "price_history");

            migrationBuilder.DropIndex(
                name: "IX_person_transport_transport_company_id",
                table: "person_transport");

            migrationBuilder.DropIndex(
                name: "IX_person_roles_role_id",
                table: "person_roles");

            migrationBuilder.DropIndex(
                name: "IX_person_plans_person_id",
                table: "person_plans");

            migrationBuilder.DropIndex(
                name: "IX_person_plans_plan_id",
                table: "person_plans");

            migrationBuilder.DropIndex(
                name: "IX_load_status_history_load_id",
                table: "load_status_history");

            migrationBuilder.DropIndex(
                name: "IX_load_images_load_id",
                table: "load_images");

            migrationBuilder.DropIndex(
                name: "IX_load_details_load_id",
                table: "load_details");

            migrationBuilder.DropIndex(
                name: "IX_drivers_vehicles_vehicle_id",
                table: "drivers_vehicles");

            migrationBuilder.DropIndex(
                name: "IX_documents_vehicles_document_status_id",
                table: "documents_vehicles");

            migrationBuilder.DropIndex(
                name: "IX_documents_vehicles_type_document_id",
                table: "documents_vehicles");

            migrationBuilder.DropIndex(
                name: "IX_documents_vehicles_vehicle_id",
                table: "documents_vehicles");

            migrationBuilder.DropIndex(
                name: "IX_documents_drivers_document_status_id",
                table: "documents_drivers");

            migrationBuilder.DropIndex(
                name: "IX_documents_drivers_driver_id",
                table: "documents_drivers");

            migrationBuilder.DropIndex(
                name: "IX_documents_drivers_type_document_id",
                table: "documents_drivers");

            migrationBuilder.DropIndex(
                name: "IX_documents_customers_customer_id",
                table: "documents_customers");

            migrationBuilder.DropIndex(
                name: "IX_documents_customers_document_status_id",
                table: "documents_customers");

            migrationBuilder.DropIndex(
                name: "IX_documents_customers_type_document_id",
                table: "documents_customers");

            migrationBuilder.DropIndex(
                name: "IX_disputes_dispute_status_id",
                table: "disputes");

            migrationBuilder.DropIndex(
                name: "IX_disputes_reason_disputes_id",
                table: "disputes");

            migrationBuilder.DropIndex(
                name: "IX_disputes_reporter_person_id",
                table: "disputes");

            migrationBuilder.DropIndex(
                name: "IX_disputes_trip_id",
                table: "disputes");

            migrationBuilder.DropIndex(
                name: "IX_company_vehicles_vehicle_id",
                table: "company_vehicles");

            migrationBuilder.DropIndex(
                name: "IX_company_documents_company_id",
                table: "company_documents");

            migrationBuilder.DropIndex(
                name: "IX_company_documents_document_status_id",
                table: "company_documents");

            migrationBuilder.DropIndex(
                name: "IX_company_documents_type_document_id",
                table: "company_documents");

            migrationBuilder.DropIndex(
                name: "IX_city_pricing_rules_city_id",
                table: "city_pricing_rules");

            migrationBuilder.DropIndex(
                name: "IX_cities_municipalities_state_region_id",
                table: "cities_municipalities");

            migrationBuilder.DropIndex(
                name: "IX_chat_rooms_load_id",
                table: "chat_rooms");

            migrationBuilder.DropIndex(
                name: "IX_chat_messages_message_type_id",
                table: "chat_messages");

            migrationBuilder.DropIndex(
                name: "IX_audit_log_person_id",
                table: "audit_log");

            migrationBuilder.DropColumn(
                name: "document_category_id",
                table: "type_documents");

            migrationBuilder.DropColumn(
                name: "driver_id",
                table: "trip_assignments");

            migrationBuilder.DropColumn(
                name: "city_id",
                table: "travel_scale");

            migrationBuilder.DropColumn(
                name: "legal_representative_person_id",
                table: "transport_companies");

            migrationBuilder.DropColumn(
                name: "payment_id",
                table: "subscriptions");

            migrationBuilder.DropColumn(
                name: "reporter_person_id",
                table: "disputes");

            migrationBuilder.DropColumn(
                name: "load_id",
                table: "chat_rooms");

            migrationBuilder.DropColumn(
                name: "message_type_id",
                table: "chat_messages");

            migrationBuilder.RenameColumn(
                name: "owner_id",
                table: "vehicles",
                newName: "company_id");

            migrationBuilder.RenameIndex(
                name: "IX_vehicles_owner_id",
                table: "vehicles",
                newName: "IX_vehicles_company_id");

            migrationBuilder.RenameColumn(
                name: "vehicle_id",
                table: "trip_assignments",
                newName: "person_id");

            migrationBuilder.RenameIndex(
                name: "IX_trip_assignments_vehicle_id",
                table: "trip_assignments",
                newName: "IX_trip_assignments_person_id");

            migrationBuilder.AlterColumn<string>(
                name: "external_reference",
                table: "payments",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(120)",
                oldMaxLength: 120)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<Guid>(
                name: "trip_id",
                table: "chat_rooms",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_trip_assignments_persons_person_id",
                table: "trip_assignments",
                column: "person_id",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicles_transport_companies_company_id",
                table: "vehicles",
                column: "company_id",
                principalTable: "transport_companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace transporte.Migrations
{
    /// <inheritdoc />
    public partial class RelacionesErd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "load_id",
                table: "chat_rooms");

            migrationBuilder.RenameColumn(
                name: "owner_id",
                table: "vehicles",
                newName: "company_id");

            migrationBuilder.RenameColumn(
                name: "person_id",
                table: "payments",
                newName: "wallet_id");

            migrationBuilder.AddColumn<Guid>(
                name: "destination_city_id",
                table: "trips",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "origin_city_id",
                table: "trips",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "city_id",
                table: "transport_companies",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "company_id",
                table: "persons",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "payment_status_id",
                table: "payments",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "trip_id",
                table: "chat_rooms",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "vehicle_id",
                table: "bids",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "trip_assignments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    trip_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    person_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    assignment_role_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trip_assignments", x => x.id);
                    table.ForeignKey(
                        name: "FK_trip_assignments_assignment_role_assignment_role_id",
                        column: x => x.assignment_role_id,
                        principalTable: "assignment_role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trip_assignments_persons_person_id",
                        column: x => x.person_id,
                        principalTable: "persons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trip_assignments_trips_trip_id",
                        column: x => x.trip_id,
                        principalTable: "trips",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_company_id",
                table: "vehicles",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_type_vehicle_id",
                table: "vehicles",
                column: "type_vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_vehicle_status_id",
                table: "vehicles",
                column: "vehicle_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_trips_destination_city_id",
                table: "trips",
                column: "destination_city_id");

            migrationBuilder.CreateIndex(
                name: "IX_trips_driver_id",
                table: "trips",
                column: "driver_id");

            migrationBuilder.CreateIndex(
                name: "IX_trips_load_id",
                table: "trips",
                column: "load_id");

            migrationBuilder.CreateIndex(
                name: "IX_trips_origin_city_id",
                table: "trips",
                column: "origin_city_id");

            migrationBuilder.CreateIndex(
                name: "IX_trips_trip_status_id",
                table: "trips",
                column: "trip_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_trips_vehicle_id",
                table: "trips",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_transport_companies_city_id",
                table: "transport_companies",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_transport_companies_companies_status_id",
                table: "transport_companies",
                column: "companies_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_persons_company_id",
                table: "persons",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_persons_person_status_id",
                table: "persons",
                column: "person_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_payments_payment_provider_id",
                table: "payments",
                column: "payment_provider_id");

            migrationBuilder.CreateIndex(
                name: "IX_payments_payment_status_id",
                table: "payments",
                column: "payment_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_payments_wallet_id",
                table: "payments",
                column: "wallet_id");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_notification_type_id",
                table: "notifications",
                column: "notification_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_person_id",
                table: "notifications",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_loads_customer_id",
                table: "loads",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_loads_destination_city_id",
                table: "loads",
                column: "destination_city_id");

            migrationBuilder.CreateIndex(
                name: "IX_loads_origin_city_id",
                table: "loads",
                column: "origin_city_id");

            migrationBuilder.CreateIndex(
                name: "IX_loads_type_load_id",
                table: "loads",
                column: "type_load_id");

            migrationBuilder.CreateIndex(
                name: "IX_drivers_person_id",
                table: "drivers",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_credit_wallet_person_id",
                table: "credit_wallet",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_credit_transactions_credit_wallet_id",
                table: "credit_transactions",
                column: "credit_wallet_id");

            migrationBuilder.CreateIndex(
                name: "IX_credit_transactions_transaction_type_id",
                table: "credit_transactions",
                column: "transaction_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_chat_rooms_trip_id",
                table: "chat_rooms",
                column: "trip_id");

            migrationBuilder.CreateIndex(
                name: "IX_chat_participants_person_id",
                table: "chat_participants",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_chat_messages_chat_room_id",
                table: "chat_messages",
                column: "chat_room_id");

            migrationBuilder.CreateIndex(
                name: "IX_chat_messages_sender_id",
                table: "chat_messages",
                column: "sender_id");

            migrationBuilder.CreateIndex(
                name: "IX_bids_driver_id",
                table: "bids",
                column: "driver_id");

            migrationBuilder.CreateIndex(
                name: "IX_bids_load_id",
                table: "bids",
                column: "load_id");

            migrationBuilder.CreateIndex(
                name: "IX_bids_status_bids_id",
                table: "bids",
                column: "status_bids_id");

            migrationBuilder.CreateIndex(
                name: "IX_bids_vehicle_id",
                table: "bids",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_auth_sessions_person_id",
                table: "auth_sessions",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_auth_credentials_person_id",
                table: "auth_credentials",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_trip_assignments_assignment_role_id",
                table: "trip_assignments",
                column: "assignment_role_id");

            migrationBuilder.CreateIndex(
                name: "IX_trip_assignments_person_id",
                table: "trip_assignments",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_trip_assignments_trip_id",
                table: "trip_assignments",
                column: "trip_id");

            migrationBuilder.AddForeignKey(
                name: "FK_auth_credentials_persons_person_id",
                table: "auth_credentials",
                column: "person_id",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_auth_sessions_persons_person_id",
                table: "auth_sessions",
                column: "person_id",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_bids_drivers_driver_id",
                table: "bids",
                column: "driver_id",
                principalTable: "drivers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_bids_loads_load_id",
                table: "bids",
                column: "load_id",
                principalTable: "loads",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_bids_status_bids_status_bids_id",
                table: "bids",
                column: "status_bids_id",
                principalTable: "status_bids",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_bids_vehicles_vehicle_id",
                table: "bids",
                column: "vehicle_id",
                principalTable: "vehicles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_chat_messages_chat_rooms_chat_room_id",
                table: "chat_messages",
                column: "chat_room_id",
                principalTable: "chat_rooms",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_chat_messages_persons_sender_id",
                table: "chat_messages",
                column: "sender_id",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_chat_participants_chat_rooms_chat_room_id",
                table: "chat_participants",
                column: "chat_room_id",
                principalTable: "chat_rooms",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_chat_participants_persons_person_id",
                table: "chat_participants",
                column: "person_id",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_chat_rooms_trips_trip_id",
                table: "chat_rooms",
                column: "trip_id",
                principalTable: "trips",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_credit_transactions_credit_wallet_credit_wallet_id",
                table: "credit_transactions",
                column: "credit_wallet_id",
                principalTable: "credit_wallet",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_credit_transactions_transaction_types_transaction_type_id",
                table: "credit_transactions",
                column: "transaction_type_id",
                principalTable: "transaction_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_credit_wallet_persons_person_id",
                table: "credit_wallet",
                column: "person_id",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_drivers_persons_person_id",
                table: "drivers",
                column: "person_id",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_loads_cities_municipalities_destination_city_id",
                table: "loads",
                column: "destination_city_id",
                principalTable: "cities_municipalities",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_loads_cities_municipalities_origin_city_id",
                table: "loads",
                column: "origin_city_id",
                principalTable: "cities_municipalities",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_loads_persons_customer_id",
                table: "loads",
                column: "customer_id",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_loads_type_load_type_load_id",
                table: "loads",
                column: "type_load_id",
                principalTable: "type_load",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_notification_type_notification_type_id",
                table: "notifications",
                column: "notification_type_id",
                principalTable: "notification_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_persons_person_id",
                table: "notifications",
                column: "person_id",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_payments_credit_wallet_wallet_id",
                table: "payments",
                column: "wallet_id",
                principalTable: "credit_wallet",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_payments_payment_providers_payment_provider_id",
                table: "payments",
                column: "payment_provider_id",
                principalTable: "payment_providers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_payments_payment_statuses_payment_status_id",
                table: "payments",
                column: "payment_status_id",
                principalTable: "payment_statuses",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_persons_person_status_person_status_id",
                table: "persons",
                column: "person_status_id",
                principalTable: "person_status",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_persons_transport_companies_company_id",
                table: "persons",
                column: "company_id",
                principalTable: "transport_companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_transport_companies_cities_municipalities_city_id",
                table: "transport_companies",
                column: "city_id",
                principalTable: "cities_municipalities",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_transport_companies_companies_status_companies_status_id",
                table: "transport_companies",
                column: "companies_status_id",
                principalTable: "companies_status",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_trips_cities_municipalities_destination_city_id",
                table: "trips",
                column: "destination_city_id",
                principalTable: "cities_municipalities",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_trips_cities_municipalities_origin_city_id",
                table: "trips",
                column: "origin_city_id",
                principalTable: "cities_municipalities",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_trips_drivers_driver_id",
                table: "trips",
                column: "driver_id",
                principalTable: "drivers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_trips_loads_load_id",
                table: "trips",
                column: "load_id",
                principalTable: "loads",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_trips_status_trip_trip_status_id",
                table: "trips",
                column: "trip_status_id",
                principalTable: "status_trip",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_trips_vehicles_vehicle_id",
                table: "trips",
                column: "vehicle_id",
                principalTable: "vehicles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicles_transport_companies_company_id",
                table: "vehicles",
                column: "company_id",
                principalTable: "transport_companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicles_type_vehicles_type_vehicle_id",
                table: "vehicles",
                column: "type_vehicle_id",
                principalTable: "type_vehicles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicles_vehicles_status_vehicle_status_id",
                table: "vehicles",
                column: "vehicle_status_id",
                principalTable: "vehicles_status",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_auth_credentials_persons_person_id",
                table: "auth_credentials");

            migrationBuilder.DropForeignKey(
                name: "FK_auth_sessions_persons_person_id",
                table: "auth_sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_bids_drivers_driver_id",
                table: "bids");

            migrationBuilder.DropForeignKey(
                name: "FK_bids_loads_load_id",
                table: "bids");

            migrationBuilder.DropForeignKey(
                name: "FK_bids_status_bids_status_bids_id",
                table: "bids");

            migrationBuilder.DropForeignKey(
                name: "FK_bids_vehicles_vehicle_id",
                table: "bids");

            migrationBuilder.DropForeignKey(
                name: "FK_chat_messages_chat_rooms_chat_room_id",
                table: "chat_messages");

            migrationBuilder.DropForeignKey(
                name: "FK_chat_messages_persons_sender_id",
                table: "chat_messages");

            migrationBuilder.DropForeignKey(
                name: "FK_chat_participants_chat_rooms_chat_room_id",
                table: "chat_participants");

            migrationBuilder.DropForeignKey(
                name: "FK_chat_participants_persons_person_id",
                table: "chat_participants");

            migrationBuilder.DropForeignKey(
                name: "FK_chat_rooms_trips_trip_id",
                table: "chat_rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_credit_transactions_credit_wallet_credit_wallet_id",
                table: "credit_transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_credit_transactions_transaction_types_transaction_type_id",
                table: "credit_transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_credit_wallet_persons_person_id",
                table: "credit_wallet");

            migrationBuilder.DropForeignKey(
                name: "FK_drivers_persons_person_id",
                table: "drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_loads_cities_municipalities_destination_city_id",
                table: "loads");

            migrationBuilder.DropForeignKey(
                name: "FK_loads_cities_municipalities_origin_city_id",
                table: "loads");

            migrationBuilder.DropForeignKey(
                name: "FK_loads_persons_customer_id",
                table: "loads");

            migrationBuilder.DropForeignKey(
                name: "FK_loads_type_load_type_load_id",
                table: "loads");

            migrationBuilder.DropForeignKey(
                name: "FK_notifications_notification_type_notification_type_id",
                table: "notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_notifications_persons_person_id",
                table: "notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_payments_credit_wallet_wallet_id",
                table: "payments");

            migrationBuilder.DropForeignKey(
                name: "FK_payments_payment_providers_payment_provider_id",
                table: "payments");

            migrationBuilder.DropForeignKey(
                name: "FK_payments_payment_statuses_payment_status_id",
                table: "payments");

            migrationBuilder.DropForeignKey(
                name: "FK_persons_person_status_person_status_id",
                table: "persons");

            migrationBuilder.DropForeignKey(
                name: "FK_persons_transport_companies_company_id",
                table: "persons");

            migrationBuilder.DropForeignKey(
                name: "FK_transport_companies_cities_municipalities_city_id",
                table: "transport_companies");

            migrationBuilder.DropForeignKey(
                name: "FK_transport_companies_companies_status_companies_status_id",
                table: "transport_companies");

            migrationBuilder.DropForeignKey(
                name: "FK_trips_cities_municipalities_destination_city_id",
                table: "trips");

            migrationBuilder.DropForeignKey(
                name: "FK_trips_cities_municipalities_origin_city_id",
                table: "trips");

            migrationBuilder.DropForeignKey(
                name: "FK_trips_drivers_driver_id",
                table: "trips");

            migrationBuilder.DropForeignKey(
                name: "FK_trips_loads_load_id",
                table: "trips");

            migrationBuilder.DropForeignKey(
                name: "FK_trips_status_trip_trip_status_id",
                table: "trips");

            migrationBuilder.DropForeignKey(
                name: "FK_trips_vehicles_vehicle_id",
                table: "trips");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicles_transport_companies_company_id",
                table: "vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicles_type_vehicles_type_vehicle_id",
                table: "vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicles_vehicles_status_vehicle_status_id",
                table: "vehicles");

            migrationBuilder.DropTable(
                name: "trip_assignments");

            migrationBuilder.DropIndex(
                name: "IX_vehicles_company_id",
                table: "vehicles");

            migrationBuilder.DropIndex(
                name: "IX_vehicles_type_vehicle_id",
                table: "vehicles");

            migrationBuilder.DropIndex(
                name: "IX_vehicles_vehicle_status_id",
                table: "vehicles");

            migrationBuilder.DropIndex(
                name: "IX_trips_destination_city_id",
                table: "trips");

            migrationBuilder.DropIndex(
                name: "IX_trips_driver_id",
                table: "trips");

            migrationBuilder.DropIndex(
                name: "IX_trips_load_id",
                table: "trips");

            migrationBuilder.DropIndex(
                name: "IX_trips_origin_city_id",
                table: "trips");

            migrationBuilder.DropIndex(
                name: "IX_trips_trip_status_id",
                table: "trips");

            migrationBuilder.DropIndex(
                name: "IX_trips_vehicle_id",
                table: "trips");

            migrationBuilder.DropIndex(
                name: "IX_transport_companies_city_id",
                table: "transport_companies");

            migrationBuilder.DropIndex(
                name: "IX_transport_companies_companies_status_id",
                table: "transport_companies");

            migrationBuilder.DropIndex(
                name: "IX_persons_company_id",
                table: "persons");

            migrationBuilder.DropIndex(
                name: "IX_persons_person_status_id",
                table: "persons");

            migrationBuilder.DropIndex(
                name: "IX_payments_payment_provider_id",
                table: "payments");

            migrationBuilder.DropIndex(
                name: "IX_payments_payment_status_id",
                table: "payments");

            migrationBuilder.DropIndex(
                name: "IX_payments_wallet_id",
                table: "payments");

            migrationBuilder.DropIndex(
                name: "IX_notifications_notification_type_id",
                table: "notifications");

            migrationBuilder.DropIndex(
                name: "IX_notifications_person_id",
                table: "notifications");

            migrationBuilder.DropIndex(
                name: "IX_loads_customer_id",
                table: "loads");

            migrationBuilder.DropIndex(
                name: "IX_loads_destination_city_id",
                table: "loads");

            migrationBuilder.DropIndex(
                name: "IX_loads_origin_city_id",
                table: "loads");

            migrationBuilder.DropIndex(
                name: "IX_loads_type_load_id",
                table: "loads");

            migrationBuilder.DropIndex(
                name: "IX_drivers_person_id",
                table: "drivers");

            migrationBuilder.DropIndex(
                name: "IX_credit_wallet_person_id",
                table: "credit_wallet");

            migrationBuilder.DropIndex(
                name: "IX_credit_transactions_credit_wallet_id",
                table: "credit_transactions");

            migrationBuilder.DropIndex(
                name: "IX_credit_transactions_transaction_type_id",
                table: "credit_transactions");

            migrationBuilder.DropIndex(
                name: "IX_chat_rooms_trip_id",
                table: "chat_rooms");

            migrationBuilder.DropIndex(
                name: "IX_chat_participants_person_id",
                table: "chat_participants");

            migrationBuilder.DropIndex(
                name: "IX_chat_messages_chat_room_id",
                table: "chat_messages");

            migrationBuilder.DropIndex(
                name: "IX_chat_messages_sender_id",
                table: "chat_messages");

            migrationBuilder.DropIndex(
                name: "IX_bids_driver_id",
                table: "bids");

            migrationBuilder.DropIndex(
                name: "IX_bids_load_id",
                table: "bids");

            migrationBuilder.DropIndex(
                name: "IX_bids_status_bids_id",
                table: "bids");

            migrationBuilder.DropIndex(
                name: "IX_bids_vehicle_id",
                table: "bids");

            migrationBuilder.DropIndex(
                name: "IX_auth_sessions_person_id",
                table: "auth_sessions");

            migrationBuilder.DropIndex(
                name: "IX_auth_credentials_person_id",
                table: "auth_credentials");

            migrationBuilder.DropColumn(
                name: "destination_city_id",
                table: "trips");

            migrationBuilder.DropColumn(
                name: "origin_city_id",
                table: "trips");

            migrationBuilder.DropColumn(
                name: "city_id",
                table: "transport_companies");

            migrationBuilder.DropColumn(
                name: "company_id",
                table: "persons");

            migrationBuilder.DropColumn(
                name: "payment_status_id",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "trip_id",
                table: "chat_rooms");

            migrationBuilder.DropColumn(
                name: "vehicle_id",
                table: "bids");

            migrationBuilder.RenameColumn(
                name: "company_id",
                table: "vehicles",
                newName: "owner_id");

            migrationBuilder.RenameColumn(
                name: "wallet_id",
                table: "payments",
                newName: "person_id");

            migrationBuilder.AddColumn<Guid>(
                name: "load_id",
                table: "chat_rooms",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");
        }
    }
}

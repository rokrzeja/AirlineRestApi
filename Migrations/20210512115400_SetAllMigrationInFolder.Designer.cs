﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using project.Models;

namespace project.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20210512115400_SetAllMigrationInFolder")]
    partial class SetAllMigrationInFolder
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("project.Models.Airplane", b =>
                {
                    b.Property<int>("airplaneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("airplane_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("businessClassCapacity")
                        .HasColumnType("int")
                        .HasColumnName("business_class_capacity");

                    b.Property<string>("code")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("dateOfLastService")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_of_last_service");

                    b.Property<int>("economyClassCapacity")
                        .HasColumnType("int")
                        .HasColumnName("economy_class_capacity");

                    b.Property<int>("firstClassCapacity")
                        .HasColumnType("int")
                        .HasColumnName("first_class_capacity");

                    b.Property<string>("fullName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("full_name");

                    b.Property<double>("hoursFlown")
                        .HasColumnType("float")
                        .HasColumnName("hours_flown");

                    b.Property<string>("manufacturer")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("productionYear")
                        .HasColumnType("int")
                        .HasColumnName("production_year");

                    b.Property<int>("range")
                        .HasColumnType("int");

                    b.Property<string>("shortcut")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("airplaneId");

                    b.ToTable("Airplane", "c");
                });

            modelBuilder.Entity("project.Models.Arrival", b =>
                {
                    b.Property<int>("arrivalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("arrival_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("airport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("airportShortcut")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("airport_shortcut");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("country")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("arrivalId");

                    b.ToTable("Arrival", "c");
                });

            modelBuilder.Entity("project.Models.Associations.StewardLanguageAssociation", b =>
                {
                    b.Property<int>("stewardLanguageAssociationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("steward_language_association_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("employeeId")
                        .HasColumnType("int")
                        .HasColumnName("employee_id");

                    b.Property<int>("languageId")
                        .HasColumnType("int")
                        .HasColumnName("language_id");

                    b.HasKey("stewardLanguageAssociationId");

                    b.HasIndex("employeeId");

                    b.HasIndex("languageId");

                    b.ToTable("Steward_Language_Association", "c");
                });

            modelBuilder.Entity("project.Models.Client", b =>
                {
                    b.Property<int>("clientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("client_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("birthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("birth_date");

                    b.Property<string>("birthPlace")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("birth_place");

                    b.Property<int>("documentNumber")
                        .HasMaxLength(100)
                        .HasColumnType("int")
                        .HasColumnName("document_number");

                    b.Property<string>("email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("first_name");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("last_name");

                    b.Property<int>("personalId")
                        .HasColumnType("int")
                        .HasColumnName("personal_id");

                    b.Property<string>("placeOfResidance")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("place_of_residance");

                    b.Property<string>("sex")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("telephoneNumber")
                        .HasColumnType("int")
                        .HasColumnName("telephone_number");

                    b.HasKey("clientId");

                    b.ToTable("Client", "c");
                });

            modelBuilder.Entity("project.Models.Departure", b =>
                {
                    b.Property<int>("departureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("arrival_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("airport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("airportShortcut")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("airport_shortcut");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("country")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("departureId");

                    b.ToTable("Departure", "c");
                });

            modelBuilder.Entity("project.Models.Employee", b =>
                {
                    b.Property<int>("employeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("employee_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("basicSalary")
                        .HasColumnType("float")
                        .HasColumnName("basic_salary");

                    b.Property<DateTime>("birthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("birth_date");

                    b.Property<string>("birthPlace")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("birth_place");

                    b.Property<string>("email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("first_name");

                    b.Property<string>("formerEmployer")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("former_employer");

                    b.Property<DateTime>("hireDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("hire_date");

                    b.Property<double>("hourlyRate")
                        .HasColumnType("float")
                        .HasColumnName("hourly_rate");

                    b.Property<double>("hoursFlown")
                        .HasColumnType("float")
                        .HasColumnName("hours_flown");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("last_name");

                    b.Property<int>("personalId")
                        .HasColumnType("int")
                        .HasColumnName("personal_id");

                    b.Property<string>("placeOfResidance")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("place_of_residance");

                    b.Property<string>("sex")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("telephoneNumber")
                        .HasColumnType("int")
                        .HasColumnName("telephone_number");

                    b.HasKey("employeeId");

                    b.ToTable("Employee", "c");
                });

            modelBuilder.Entity("project.Models.Flight", b =>
                {
                    b.Property<int>("flightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("flight_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("airplaneId")
                        .HasColumnType("int");

                    b.Property<double>("airportTax")
                        .HasColumnType("float")
                        .HasColumnName("airport_tax");

                    b.Property<int>("arrivalId")
                        .HasColumnType("int");

                    b.Property<int>("departureId")
                        .HasColumnType("int");

                    b.Property<double>("fixedCost")
                        .HasColumnType("float")
                        .HasColumnName("fixed_cost");

                    b.Property<string>("flightNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("flight_number");

                    b.HasKey("flightId");

                    b.HasIndex("airplaneId");

                    b.HasIndex("arrivalId");

                    b.HasIndex("departureId");

                    b.ToTable("Flight", "c");
                });

            modelBuilder.Entity("project.Models.FlightInstance", b =>
                {
                    b.Property<int>("flightInstanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("flight_instance_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("arrivalDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("arrival_date");

                    b.Property<DateTime>("departureDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("departure_date");

                    b.Property<int>("flightId")
                        .HasColumnType("int");

                    b.Property<int>("flightNumber")
                        .HasColumnType("int");

                    b.Property<int>("ticketPrice")
                        .HasColumnType("int")
                        .HasColumnName("ticket_price");

                    b.HasKey("flightInstanceId");

                    b.HasIndex("flightId");

                    b.ToTable("Flight_Instance", "c");
                });

            modelBuilder.Entity("project.Models.FlightInstanceEmployeeAssociation", b =>
                {
                    b.Property<int>("flightInstanceEmployeeAssociationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("flight_instance_employee_association_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("employeeId")
                        .HasColumnType("int")
                        .HasColumnName("employee_Id");

                    b.Property<int>("flightInstanceId")
                        .HasColumnType("int")
                        .HasColumnName("flight_instance_id");

                    b.HasKey("flightInstanceEmployeeAssociationId");

                    b.HasIndex("employeeId");

                    b.HasIndex("flightInstanceId");

                    b.ToTable("Flight_Instance_Employee_Association", "c");
                });

            modelBuilder.Entity("project.Models.Language", b =>
                {
                    b.Property<int>("languageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("language_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("language")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("languageId");

                    b.ToTable("Language", "c");
                });

            modelBuilder.Entity("project.Models.Reservation", b =>
                {
                    b.Property<int>("reservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("reservation_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("clientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateOfPurchase")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_of_purchase");

                    b.Property<bool>("extraLuggage")
                        .HasColumnType("bit")
                        .HasColumnName("extra_luggage");

                    b.Property<string>("flightClass")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("flight_class");

                    b.Property<int>("flightInstanceId")
                        .HasColumnType("int");

                    b.HasKey("reservationId");

                    b.HasIndex("clientId");

                    b.HasIndex("flightInstanceId");

                    b.ToTable("Reservation", "c");
                });

            modelBuilder.Entity("project.Models.Pilot", b =>
                {
                    b.HasBaseType("project.Models.Employee");

                    b.Property<string>("rank")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.ToTable("Pilot", "c");
                });

            modelBuilder.Entity("project.Models.Steward", b =>
                {
                    b.HasBaseType("project.Models.Employee");

                    b.Property<bool>("bonus")
                        .HasColumnType("bit");

                    b.ToTable("Steward", "c");
                });

            modelBuilder.Entity("project.Models.Associations.StewardLanguageAssociation", b =>
                {
                    b.HasOne("project.Models.Steward", "steward")
                        .WithMany("stewardLanguageList")
                        .HasForeignKey("employeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("project.Models.Language", "language")
                        .WithMany("stewardLanguageList")
                        .HasForeignKey("languageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("language");

                    b.Navigation("steward");
                });

            modelBuilder.Entity("project.Models.Flight", b =>
                {
                    b.HasOne("project.Models.Airplane", "airplane")
                        .WithMany("flights")
                        .HasForeignKey("airplaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("project.Models.Arrival", "arrival")
                        .WithMany("flights")
                        .HasForeignKey("arrivalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("project.Models.Departure", "departure")
                        .WithMany("flights")
                        .HasForeignKey("departureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("airplane");

                    b.Navigation("arrival");

                    b.Navigation("departure");
                });

            modelBuilder.Entity("project.Models.FlightInstance", b =>
                {
                    b.HasOne("project.Models.Flight", "flight")
                        .WithMany("flightInstances")
                        .HasForeignKey("flightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("flight");
                });

            modelBuilder.Entity("project.Models.FlightInstanceEmployeeAssociation", b =>
                {
                    b.HasOne("project.Models.Employee", "employee")
                        .WithMany("FlightInstanceEmployeelist")
                        .HasForeignKey("employeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("project.Models.FlightInstance", "flightInstance")
                        .WithMany("FlightInstanceEmployeelist")
                        .HasForeignKey("flightInstanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employee");

                    b.Navigation("flightInstance");
                });

            modelBuilder.Entity("project.Models.Reservation", b =>
                {
                    b.HasOne("project.Models.Client", "client")
                        .WithMany("reservations")
                        .HasForeignKey("clientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("project.Models.FlightInstance", "flightInstance")
                        .WithMany("reservations")
                        .HasForeignKey("flightInstanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("client");

                    b.Navigation("flightInstance");
                });

            modelBuilder.Entity("project.Models.Pilot", b =>
                {
                    b.HasOne("project.Models.Employee", null)
                        .WithOne()
                        .HasForeignKey("project.Models.Pilot", "employeeId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("project.Models.Steward", b =>
                {
                    b.HasOne("project.Models.Employee", null)
                        .WithOne()
                        .HasForeignKey("project.Models.Steward", "employeeId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("project.Models.Airplane", b =>
                {
                    b.Navigation("flights");
                });

            modelBuilder.Entity("project.Models.Arrival", b =>
                {
                    b.Navigation("flights");
                });

            modelBuilder.Entity("project.Models.Client", b =>
                {
                    b.Navigation("reservations");
                });

            modelBuilder.Entity("project.Models.Departure", b =>
                {
                    b.Navigation("flights");
                });

            modelBuilder.Entity("project.Models.Employee", b =>
                {
                    b.Navigation("FlightInstanceEmployeelist");
                });

            modelBuilder.Entity("project.Models.Flight", b =>
                {
                    b.Navigation("flightInstances");
                });

            modelBuilder.Entity("project.Models.FlightInstance", b =>
                {
                    b.Navigation("FlightInstanceEmployeelist");

                    b.Navigation("reservations");
                });

            modelBuilder.Entity("project.Models.Language", b =>
                {
                    b.Navigation("stewardLanguageList");
                });

            modelBuilder.Entity("project.Models.Steward", b =>
                {
                    b.Navigation("stewardLanguageList");
                });
#pragma warning restore 612, 618
        }
    }
}

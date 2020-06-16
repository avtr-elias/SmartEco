﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SmartEcoAPI.Data;

namespace SmartEcoAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("SmartEcoAPI.Models.AActivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("ActivityType");

                    b.Property<string>("AdditionalInformationKK");

                    b.Property<string>("AdditionalInformationRU");

                    b.Property<int>("EventId");

                    b.Property<decimal>("ImplementationPercentage");

                    b.Property<int>("TargetId");

                    b.Property<int>("TargetTerritoryId");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("TargetId");

                    b.HasIndex("TargetTerritoryId");

                    b.ToTable("AActivity");
                });

            modelBuilder.Entity("SmartEcoAPI.Models.DataProvider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("DataProvider");
                });

            modelBuilder.Entity("SmartEcoAPI.Models.EcomonMonitoringPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("EastLongitude");

                    b.Property<decimal>("NorthLatitude");

                    b.Property<int>("Number");

                    b.HasKey("Id");

                    b.ToTable("EcomonMonitoringPoint");
                });

            modelBuilder.Entity("SmartEcoAPI.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NameEN");

                    b.Property<string>("NameKK");

                    b.Property<string>("NameRU");

                    b.HasKey("Id");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("SmartEcoAPI.Models.KATO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AreaType");

                    b.Property<string>("Code");

                    b.Property<int>("EgovId");

                    b.Property<int>("Level");

                    b.Property<string>("NameKK");

                    b.Property<string>("NameRU");

                    b.Property<int?>("ParentEgovId");

                    b.HasKey("Id");

                    b.ToTable("KATO");
                });

            modelBuilder.Entity("SmartEcoAPI.Models.KazHydrometAirPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdditionalInformation");

                    b.Property<decimal>("EastLongitude");

                    b.Property<string>("Name");

                    b.Property<decimal>("NorthLatitude");

                    b.Property<int>("Number");

                    b.HasKey("Id");

                    b.ToTable("KazHydrometAirPost");
                });

            modelBuilder.Entity("SmartEcoAPI.Models.KazHydrometSoilPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdditionalInformation");

                    b.Property<decimal>("EastLongitude");

                    b.Property<string>("Name");

                    b.Property<decimal>("NorthLatitude");

                    b.Property<int>("Number");

                    b.HasKey("Id");

                    b.ToTable("KazHydrometSoilPost");
                });

            modelBuilder.Entity("SmartEcoAPI.Models.LEDScreen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("EastLongitude");

                    b.Property<int>("MonitoringPostId");

                    b.Property<string>("Name");

                    b.Property<decimal>("NorthLatitude");

                    b.Property<int?>("Number");

                    b.HasKey("Id");

                    b.HasIndex("MonitoringPostId");

                    b.ToTable("LEDScreen");
                });

            modelBuilder.Entity("SmartEcoAPI.Models.Layer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GeoServerName");

                    b.Property<string>("GeoServerWorkspace");

                    b.Property<int?>("Hour");

                    b.Property<int?>("KATOId");

                    b.Property<int?>("MeasuredParameterId");

                    b.Property<string>("NameEN");

                    b.Property<string>("NameKK");

                    b.Property<string>("NameRU");

                    b.Property<int?>("PollutionEnvironmentId");

                    b.Property<int?>("Season");

                    b.HasKey("Id");

                    b.HasIndex("KATOId");

                    b.HasIndex("MeasuredParameterId");

                    b.HasIndex("PollutionEnvironmentId");

                    b.ToTable("Layer");
                });

            modelBuilder.Entity("SmartEcoAPI.Models.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTimeEnd");

                    b.Property<DateTime>("DateTimeStart");

                    b.Property<decimal>("EastLongitude");

                    b.Property<decimal>("NorthLatitude");

                    b.Property<int>("Number");

                    b.HasKey("Id");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("SmartEcoAPI.Models.MeasuredData", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Averaged");

                    b.Property<DateTime?>("DateTime");

                    b.Property<long?>("Ecomontimestamp_ms");

                    b.Property<int?>("MaxValueDay");

                    b.Property<int?>("MaxValueMonth");

                    b.Property<decimal?>("MaxValuePerMonth");

                    b.Property<decimal?>("MaxValuePerYear");

                    b.Property<int>("MeasuredParameterId");

                    b.Property<int?>("MonitoringPostId");

                    b.Property<int?>("Month");

                    b.Property<int?>("PollutionSourceId");

                    b.Property<decimal?>("Value");

                    b.Property<int?>("Year");

                    b.HasKey("Id");

                    b.HasIndex("MeasuredParameterId");

                    b.HasIndex("MonitoringPostId");

                    b.HasIndex("PollutionSourceId");

                    b.ToTable("MeasuredData");
                });

            modelBuilder.Entity("SmartEcoAPI.Models.MeasuredParameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EcomonCode");

                    b.Property<string>("KazhydrometCode");

                    b.Property<decimal?>("MPCDailyAverage");

                    b.Property<decimal?>("MPCMaxSingle");

                    b.Property<int?>("MeasuredParameterUnitId");

                    b.Property<string>("NameEN");

                    b.Property<string>("NameKK");

                    b.Property<string>("NameRU");

                    b.Property<string>("NameShortEN");

                    b.Property<string>("NameShortKK");

                    b.Property<string>("NameShortRU");

                    b.Property<string>("OceanusCode");

                    b.HasKey("Id");

                    b.HasIndex("MeasuredParameterUnitId");

                    b.ToTable("MeasuredParameter");
                });

            modelBuilder.Entity("SmartEcoAPI.Models.MeasuredParameterUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NameEN");

                    b.Property<string>("NameKK");

                    b.Property<string>("NameRU");

                    b.HasKey("Id");

                    b.ToTable("MeasuredParameterUnit");
                });

            modelBuilder.Entity("SmartEcoAPI.Models.MonitoringPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdditionalInformation");

                    b.Property<bool>("Automatic");

                    b.Property<int>("DataProviderId");

                    b.Property<decimal>("EastLongitude");

                    b.Property<int?>("KazhydrometID");

                    b.Property<string>("MN");

                    b.Property<string>("Name");

                    b.Property<decimal>("NorthLatitude");

                    b.Property<int>("Number");

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("PollutionEnvironmentId");

                    b.Property<int?>("ProjectId");

                    b.Property<bool>("TurnOnOff");

                    b.HasKey("Id");

                    b.HasIndex("DataProviderId");

                    b.HasIndex("PollutionEnvironmentId");

                    b.HasIndex("ProjectId");

                    b.ToTable("MonitoringPost");
                });

            modelBuilder.Entity("SmartEcoAPI.Models.MonitoringPostMeasuredParameters", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal?>("Coefficient");

                    b.Property<decimal?>("Max");

                    b.Property<decimal?>("MaxMeasuredValue");

                    b.Property<int>("MeasuredParameterId");

                    b.Property<decimal?>("Min");

                    b.Property<decimal?>("MinMeasuredValue");

                    b.Property<int>("MonitoringPostId");

                    b.HasKey("Id");

                    b.HasIndex("MeasuredParameterId");

                    b.HasIndex("MonitoringPostId");

                    b.ToTable("MonitoringPostMeasuredParameters");
                });

            modelBuilder.Entity("SmartEcoAPI.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("Role");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("SmartEcoAPI.Models.Pollutant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NameEN");

                    b.Property<string>("NameKK");

                    b.Property<string>("NameRU");

                    b.HasKey("Id");

                    b.ToTable("Pollutant");
                });

            modelBuilder.Entity("SmartEcoAPI.Models.PollutionEnvironment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NameEN");

                    b.Property<string>("NameKK");

                    b.Property<string>("NameRU");

                    b.HasKey("Id");

                    b.ToTable("PollutionEnvironment");
                });

            modelBuilder.Entity("SmartEcoAPI.Models.PollutionSource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("EastLongitude");

                    b.Property<string>("Name");

                    b.Property<decimal>("NorthLatitude");

                    b.HasKey("Id");

                    b.ToTable("PollutionSource");
                });

            modelBuilder.Entity("SmartEcoAPI.Models.PollutionSourceData", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTime");

                    b.Property<int>("PollutantId");

                    b.Property<int>("PollutionSourceId");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("PollutantId");

                    b.HasIndex("PollutionSourceId");

                    b.ToTable("PollutionSourceData");
                });

            modelBuilder.Entity("SmartEcoAPI.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("SmartEcoAPI.Models.Target", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MeasuredParameterUnitId");

                    b.Property<string>("NameEN");

                    b.Property<string>("NameKK");

                    b.Property<string>("NameRU");

                    b.Property<int>("PollutionEnvironmentId");

                    b.Property<bool>("TypeOfAchievement");

                    b.HasKey("Id");

                    b.HasIndex("MeasuredParameterUnitId");

                    b.HasIndex("PollutionEnvironmentId");

                    b.ToTable("Target");
                });

            modelBuilder.Entity("SmartEcoAPI.Models.TargetTerritory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdditionalInformationKK");

                    b.Property<string>("AdditionalInformationRU");

                    b.Property<string>("GISConnectionCode");

                    b.Property<int?>("KATOId");

                    b.Property<int?>("KazHydrometSoilPostId");

                    b.Property<int?>("MonitoringPostId");

                    b.Property<string>("NameKK");

                    b.Property<string>("NameRU");

                    b.Property<int>("TerritoryTypeId");

                    b.HasKey("Id");

                    b.HasIndex("KATOId");

                    b.HasIndex("KazHydrometSoilPostId");

                    b.HasIndex("MonitoringPostId");

                    b.HasIndex("TerritoryTypeId");

                    b.ToTable("TargetTerritory");
                });

            modelBuilder.Entity("SmartEcoAPI.Models.TargetValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdditionalInformationKK");

                    b.Property<string>("AdditionalInformationRU");

                    b.Property<int>("TargetId");

                    b.Property<int>("TargetTerritoryId");

                    b.Property<bool>("TargetValueType");

                    b.Property<decimal>("Value");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("TargetId");

                    b.HasIndex("TargetTerritoryId");

                    b.ToTable("TargetValue");
                });

            modelBuilder.Entity("SmartEcoAPI.Models.TerritoryType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdditionalInformationEN");

                    b.Property<string>("AdditionalInformationKK");

                    b.Property<string>("AdditionalInformationRU");

                    b.Property<string>("NameEN");

                    b.Property<string>("NameKK");

                    b.Property<string>("NameRU");

                    b.HasKey("Id");

                    b.ToTable("TerritoryType");
                });

            modelBuilder.Entity("SmartEcoAPI.Models.AActivity", b =>
                {
                    b.HasOne("SmartEcoAPI.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SmartEcoAPI.Models.Target", "Target")
                        .WithMany()
                        .HasForeignKey("TargetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SmartEcoAPI.Models.TargetTerritory", "TargetTerritory")
                        .WithMany()
                        .HasForeignKey("TargetTerritoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SmartEcoAPI.Models.LEDScreen", b =>
                {
                    b.HasOne("SmartEcoAPI.Models.MonitoringPost", "MonitoringPost")
                        .WithMany()
                        .HasForeignKey("MonitoringPostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SmartEcoAPI.Models.Layer", b =>
                {
                    b.HasOne("SmartEcoAPI.Models.KATO", "KATO")
                        .WithMany()
                        .HasForeignKey("KATOId");

                    b.HasOne("SmartEcoAPI.Models.MeasuredParameter", "MeasuredParameter")
                        .WithMany()
                        .HasForeignKey("MeasuredParameterId");

                    b.HasOne("SmartEcoAPI.Models.PollutionEnvironment", "PollutionEnvironment")
                        .WithMany()
                        .HasForeignKey("PollutionEnvironmentId");
                });

            modelBuilder.Entity("SmartEcoAPI.Models.MeasuredData", b =>
                {
                    b.HasOne("SmartEcoAPI.Models.MeasuredParameter", "MeasuredParameter")
                        .WithMany()
                        .HasForeignKey("MeasuredParameterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SmartEcoAPI.Models.MonitoringPost", "MonitoringPost")
                        .WithMany()
                        .HasForeignKey("MonitoringPostId");

                    b.HasOne("SmartEcoAPI.Models.PollutionSource", "PollutionSource")
                        .WithMany()
                        .HasForeignKey("PollutionSourceId");
                });

            modelBuilder.Entity("SmartEcoAPI.Models.MeasuredParameter", b =>
                {
                    b.HasOne("SmartEcoAPI.Models.MeasuredParameterUnit", "MeasuredParameterUnit")
                        .WithMany()
                        .HasForeignKey("MeasuredParameterUnitId");
                });

            modelBuilder.Entity("SmartEcoAPI.Models.MonitoringPost", b =>
                {
                    b.HasOne("SmartEcoAPI.Models.DataProvider", "DataProvider")
                        .WithMany()
                        .HasForeignKey("DataProviderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SmartEcoAPI.Models.PollutionEnvironment", "PollutionEnvironment")
                        .WithMany()
                        .HasForeignKey("PollutionEnvironmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SmartEcoAPI.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("SmartEcoAPI.Models.MonitoringPostMeasuredParameters", b =>
                {
                    b.HasOne("SmartEcoAPI.Models.MeasuredParameter", "MeasuredParameter")
                        .WithMany()
                        .HasForeignKey("MeasuredParameterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SmartEcoAPI.Models.MonitoringPost", "MonitoringPost")
                        .WithMany()
                        .HasForeignKey("MonitoringPostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SmartEcoAPI.Models.PollutionSourceData", b =>
                {
                    b.HasOne("SmartEcoAPI.Models.Pollutant", "Pollutant")
                        .WithMany()
                        .HasForeignKey("PollutantId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SmartEcoAPI.Models.PollutionSource", "PollutionSource")
                        .WithMany()
                        .HasForeignKey("PollutionSourceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SmartEcoAPI.Models.Target", b =>
                {
                    b.HasOne("SmartEcoAPI.Models.MeasuredParameterUnit", "MeasuredParameterUnit")
                        .WithMany()
                        .HasForeignKey("MeasuredParameterUnitId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SmartEcoAPI.Models.PollutionEnvironment", "PollutionEnvironment")
                        .WithMany()
                        .HasForeignKey("PollutionEnvironmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SmartEcoAPI.Models.TargetTerritory", b =>
                {
                    b.HasOne("SmartEcoAPI.Models.KATO", "KATO")
                        .WithMany()
                        .HasForeignKey("KATOId");

                    b.HasOne("SmartEcoAPI.Models.KazHydrometSoilPost", "KazHydrometSoilPost")
                        .WithMany()
                        .HasForeignKey("KazHydrometSoilPostId");

                    b.HasOne("SmartEcoAPI.Models.MonitoringPost", "MonitoringPost")
                        .WithMany()
                        .HasForeignKey("MonitoringPostId");

                    b.HasOne("SmartEcoAPI.Models.TerritoryType", "TerritoryType")
                        .WithMany()
                        .HasForeignKey("TerritoryTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SmartEcoAPI.Models.TargetValue", b =>
                {
                    b.HasOne("SmartEcoAPI.Models.Target", "Target")
                        .WithMany()
                        .HasForeignKey("TargetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SmartEcoAPI.Models.TargetTerritory", "TargetTerritory")
                        .WithMany()
                        .HasForeignKey("TargetTerritoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

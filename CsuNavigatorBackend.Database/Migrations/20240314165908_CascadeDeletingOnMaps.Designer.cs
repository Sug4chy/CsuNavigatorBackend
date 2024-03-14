﻿// <auto-generated />
using System;
using CsuNavigatorBackend.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CsuNavigatorBackend.Database.Migrations
{
    [DbContext(typeof(NavigatorDbContext))]
    [Migration("20240314165908_CascadeDeletingOnMaps")]
    partial class CascadeDeletingOnMaps
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CsuNavigatorBackend.Domain.Entities.Edge", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("LastlyEditedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("MapId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("Point1Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("Point2Id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MapId");

                    b.HasIndex("Point1Id");

                    b.HasIndex("Point2Id");

                    b.ToTable("Edge", (string)null);
                });

            modelBuilder.Entity("CsuNavigatorBackend.Domain.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ApplicationImageType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("LastlyEditedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("FileName")
                        .IsUnique();

                    b.ToTable("Image", (string)null);
                });

            modelBuilder.Entity("CsuNavigatorBackend.Domain.Entities.Map", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<Guid?>("ImageId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("LastlyEditedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ImageId")
                        .IsUnique();

                    b.HasIndex("OrganizationId");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Map", (string)null);
                });

            modelBuilder.Entity("CsuNavigatorBackend.Domain.Entities.MarkerPoint", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastlyEditedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("MapAsPointWithoutEdgeId")
                        .HasColumnType("uuid");

                    b.Property<string>("MarkerType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("X")
                        .HasColumnType("double precision");

                    b.Property<double>("Y")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("MapAsPointWithoutEdgeId");

                    b.ToTable("MarkerPoint", (string)null);
                });

            modelBuilder.Entity("CsuNavigatorBackend.Domain.Entities.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("LastlyEditedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Organization", (string)null);
                });

            modelBuilder.Entity("CsuNavigatorBackend.Domain.Entities.Profile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AvatarId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("LastlyEditedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AvatarId")
                        .IsUnique();

                    b.ToTable("Profile", (string)null);
                });

            modelBuilder.Entity("CsuNavigatorBackend.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CurrentRefreshToken")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastlyEditedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ProfileId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("RefreshTokenExpiration")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId")
                        .IsUnique();

                    b.HasIndex("Username");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("OrganizationProfile", b =>
                {
                    b.Property<Guid>("AllowedOrganizationsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("WorkersProfilesId")
                        .HasColumnType("uuid");

                    b.HasKey("AllowedOrganizationsId", "WorkersProfilesId");

                    b.HasIndex("WorkersProfilesId");

                    b.ToTable("OrganizationWorkers", (string)null);
                });

            modelBuilder.Entity("CsuNavigatorBackend.Domain.Entities.Edge", b =>
                {
                    b.HasOne("CsuNavigatorBackend.Domain.Entities.Map", "Map")
                        .WithMany("Edges")
                        .HasForeignKey("MapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CsuNavigatorBackend.Domain.Entities.MarkerPoint", "Point1")
                        .WithMany("EdgesAsPoint1")
                        .HasForeignKey("Point1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CsuNavigatorBackend.Domain.Entities.MarkerPoint", "Point2")
                        .WithMany("EdgesAsPoint2")
                        .HasForeignKey("Point2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Map");

                    b.Navigation("Point1");

                    b.Navigation("Point2");
                });

            modelBuilder.Entity("CsuNavigatorBackend.Domain.Entities.Map", b =>
                {
                    b.HasOne("CsuNavigatorBackend.Domain.Entities.Image", "Image")
                        .WithOne("Map")
                        .HasForeignKey("CsuNavigatorBackend.Domain.Entities.Map", "ImageId");

                    b.HasOne("CsuNavigatorBackend.Domain.Entities.Organization", "Organization")
                        .WithMany("Maps")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("CsuNavigatorBackend.Domain.Entities.MarkerPoint", b =>
                {
                    b.HasOne("CsuNavigatorBackend.Domain.Entities.Map", "MapAsPointWithoutEdge")
                        .WithMany("PointsWithoutEdges")
                        .HasForeignKey("MapAsPointWithoutEdgeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("MapAsPointWithoutEdge");
                });

            modelBuilder.Entity("CsuNavigatorBackend.Domain.Entities.Profile", b =>
                {
                    b.HasOne("CsuNavigatorBackend.Domain.Entities.Image", "Avatar")
                        .WithOne("Profile")
                        .HasForeignKey("CsuNavigatorBackend.Domain.Entities.Profile", "AvatarId");

                    b.Navigation("Avatar");
                });

            modelBuilder.Entity("CsuNavigatorBackend.Domain.Entities.User", b =>
                {
                    b.HasOne("CsuNavigatorBackend.Domain.Entities.Profile", "Profile")
                        .WithOne("User")
                        .HasForeignKey("CsuNavigatorBackend.Domain.Entities.User", "ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("OrganizationProfile", b =>
                {
                    b.HasOne("CsuNavigatorBackend.Domain.Entities.Organization", null)
                        .WithMany()
                        .HasForeignKey("AllowedOrganizationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CsuNavigatorBackend.Domain.Entities.Profile", null)
                        .WithMany()
                        .HasForeignKey("WorkersProfilesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CsuNavigatorBackend.Domain.Entities.Image", b =>
                {
                    b.Navigation("Map");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("CsuNavigatorBackend.Domain.Entities.Map", b =>
                {
                    b.Navigation("Edges");

                    b.Navigation("PointsWithoutEdges");
                });

            modelBuilder.Entity("CsuNavigatorBackend.Domain.Entities.MarkerPoint", b =>
                {
                    b.Navigation("EdgesAsPoint1");

                    b.Navigation("EdgesAsPoint2");
                });

            modelBuilder.Entity("CsuNavigatorBackend.Domain.Entities.Organization", b =>
                {
                    b.Navigation("Maps");
                });

            modelBuilder.Entity("CsuNavigatorBackend.Domain.Entities.Profile", b =>
                {
                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}

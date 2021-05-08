﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Context;

namespace Persistence.Migrations.MoviesDB
{
    [DbContext(typeof(MoviesDBContext))]
    [Migration("20210507165636_AddMovieModels")]
    partial class AddMovieModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("Domain.Entity.Actor", b =>
                {
                    b.Property<int>("ActorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("ActorID");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ActorId");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("Domain.Entity.Crew", b =>
                {
                    b.Property<int>("CrewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("CrewID");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("CrewId");

                    b.ToTable("Crew");
                });

            modelBuilder.Entity("Domain.Entity.Director", b =>
                {
                    b.Property<int>("DirectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("DirectorID");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("DirectorId");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("Domain.Entity.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("MovieID");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Genres")
                        .HasColumnType("TEXT");

                    b.Property<string>("Keywords")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("LocalTitle")
                        .HasColumnType("TEXT");

                    b.Property<string>("Overview")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Popularity")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan?>("RunTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tagline")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ViewCount")
                        .HasColumnType("INTEGER");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Domain.Entity.MovieActor", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ActorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CastOrder")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CharacterName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.HasKey("MovieId", "ActorId")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("ActorId");

                    b.ToTable("MovieActor");
                });

            modelBuilder.Entity("Domain.Entity.MovieCrew", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CrewId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.HasKey("MovieId", "CrewId")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("CrewId");

                    b.ToTable("MovieCrew");
                });

            modelBuilder.Entity("Domain.Entity.MovieDirector", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DirectorId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.HasKey("MovieId", "DirectorId")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("DirectorId");

                    b.ToTable("MovieDirector");
                });

            modelBuilder.Entity("Domain.Entity.Actor", b =>
                {
                    b.OwnsOne("Domain.Entity.Gender", "Gender", b1 =>
                        {
                            b1.Property<int>("ActorId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Name")
                                .HasColumnType("TEXT")
                                .HasColumnName("Gender");

                            b1.HasKey("ActorId");

                            b1.ToTable("Actors");

                            b1.WithOwner()
                                .HasForeignKey("ActorId");
                        });

                    b.OwnsOne("Domain.Entity.Image", "Image", b1 =>
                        {
                            b1.Property<int>("ActorId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("ImageUrl")
                                .IsRequired()
                                .HasColumnType("TEXT")
                                .HasColumnName("ImageUrl");

                            b1.HasKey("ActorId");

                            b1.ToTable("Actors");

                            b1.WithOwner()
                                .HasForeignKey("ActorId");
                        });

                    b.Navigation("Gender");

                    b.Navigation("Image")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.Crew", b =>
                {
                    b.OwnsOne("Domain.Entity.Department", "Department", b1 =>
                        {
                            b1.Property<int>("CrewId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("TEXT")
                                .HasColumnName("Department");

                            b1.HasKey("CrewId");

                            b1.ToTable("Crew");

                            b1.WithOwner()
                                .HasForeignKey("CrewId");
                        });

                    b.OwnsOne("Domain.Entity.Image", "Image", b1 =>
                        {
                            b1.Property<int>("CrewId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("ImageUrl")
                                .IsRequired()
                                .HasColumnType("TEXT")
                                .HasColumnName("ImageUrl");

                            b1.HasKey("CrewId");

                            b1.ToTable("Crew");

                            b1.WithOwner()
                                .HasForeignKey("CrewId");
                        });

                    b.Navigation("Department")
                        .IsRequired();

                    b.Navigation("Image")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.Director", b =>
                {
                    b.OwnsOne("Domain.Entity.Image", "Image", b1 =>
                        {
                            b1.Property<int>("DirectorId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("ImageUrl")
                                .IsRequired()
                                .HasColumnType("TEXT")
                                .HasColumnName("ImageUrl");

                            b1.HasKey("DirectorId");

                            b1.ToTable("Directors");

                            b1.WithOwner()
                                .HasForeignKey("DirectorId");
                        });

                    b.Navigation("Image")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.Movie", b =>
                {
                    b.OwnsOne("Domain.Entity.Image", "Image", b1 =>
                        {
                            b1.Property<int>("MovieId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("ImageUrl")
                                .IsRequired()
                                .HasColumnType("TEXT")
                                .HasColumnName("ImageUrl");

                            b1.HasKey("MovieId");

                            b1.ToTable("Movies");

                            b1.WithOwner()
                                .HasForeignKey("MovieId");
                        });

                    b.OwnsOne("Domain.Entity.Language", "Language", b1 =>
                        {
                            b1.Property<int>("MovieId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("TEXT")
                                .HasColumnName("Language");

                            b1.HasKey("MovieId");

                            b1.ToTable("Movies");

                            b1.WithOwner()
                                .HasForeignKey("MovieId");
                        });

                    b.OwnsOne("Domain.Entity.Video", "Video", b1 =>
                        {
                            b1.Property<int>("MovieId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("VideoUrl")
                                .IsRequired()
                                .HasColumnType("TEXT")
                                .HasColumnName("VideoUrl");

                            b1.HasKey("MovieId");

                            b1.ToTable("Movies");

                            b1.WithOwner()
                                .HasForeignKey("MovieId");
                        });

                    b.Navigation("Image")
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("Video");
                });

            modelBuilder.Entity("Domain.Entity.MovieActor", b =>
                {
                    b.HasOne("Domain.Entity.Actor", "Actor")
                        .WithMany("MovieActors")
                        .HasForeignKey("ActorId")
                        .HasConstraintName("FK_MovieActor_Actors")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.Movie", "Movie")
                        .WithMany("MovieActors")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("FK_MovieActor_Movies")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Domain.Entity.MovieCrew", b =>
                {
                    b.HasOne("Domain.Entity.Crew", "Crew")
                        .WithMany("MovieCrew")
                        .HasForeignKey("CrewId")
                        .HasConstraintName("FK_MovieCrew_Crew")
                        .IsRequired();

                    b.HasOne("Domain.Entity.Movie", "Movie")
                        .WithMany("MovieCrew")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("FK_MovieCrew_Movies")
                        .IsRequired();

                    b.Navigation("Crew");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Domain.Entity.MovieDirector", b =>
                {
                    b.HasOne("Domain.Entity.Director", "Director")
                        .WithMany("MovieDirectors")
                        .HasForeignKey("DirectorId")
                        .HasConstraintName("FK_MovieDirector_Directors")
                        .IsRequired();

                    b.HasOne("Domain.Entity.Movie", "Movie")
                        .WithMany("MovieDirectors")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("FK_MovieDirector_Movies")
                        .IsRequired();

                    b.Navigation("Director");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Domain.Entity.Actor", b =>
                {
                    b.Navigation("MovieActors");
                });

            modelBuilder.Entity("Domain.Entity.Crew", b =>
                {
                    b.Navigation("MovieCrew");
                });

            modelBuilder.Entity("Domain.Entity.Director", b =>
                {
                    b.Navigation("MovieDirectors");
                });

            modelBuilder.Entity("Domain.Entity.Movie", b =>
                {
                    b.Navigation("MovieActors");

                    b.Navigation("MovieCrew");

                    b.Navigation("MovieDirectors");
                });
#pragma warning restore 612, 618
        }
    }
}

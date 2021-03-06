﻿// <auto-generated />
using Ballit.Core.Models;
using Ballit.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Ballit.Data.Migrations
{
    [DbContext(typeof(BallitContext))]
    partial class BallitContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ballit.Core.Models.Comment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("CommentId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<long>("CreatedByUserId");

                    b.Property<long?>("PostId");

                    b.Property<string>("Text");

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<long?>("UpdatedByUserId");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("PostId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Ballit.Core.Models.CommentVote", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<long>("CommentIdId");

                    b.Property<int>("Value");

                    b.HasKey("UserId");

                    b.HasIndex("CommentIdId");

                    b.ToTable("CommentVotes");
                });

            modelBuilder.Entity("Ballit.Core.Models.Post", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Domain");

                    b.Property<string>("Sub");

                    b.Property<string>("Text");

                    b.Property<string>("ThumbUrl");

                    b.Property<string>("Title");

                    b.Property<string>("Url");

                    b.Property<string>("UrlTitle");

                    b.HasKey("Id");

                    b.HasIndex("Sub");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("Ballit.Core.Models.PostVote", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<long>("PostId");

                    b.Property<int>("Value");

                    b.HasKey("UserId");

                    b.HasIndex("PostId");

                    b.ToTable("PostVotes");
                });

            modelBuilder.Entity("Ballit.Core.Models.Subballit", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("UserId");

                    b.HasKey("Name");

                    b.HasIndex("UserId");

                    b.ToTable("Subballits");
                });

            modelBuilder.Entity("Ballit.Core.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Ballit.Core.Models.Comment", b =>
                {
                    b.HasOne("Ballit.Core.Models.Comment")
                        .WithMany("Comments")
                        .HasForeignKey("CommentId");

                    b.HasOne("Ballit.Core.Models.Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("Ballit.Core.Models.CommentVote", b =>
                {
                    b.HasOne("Ballit.Core.Models.Comment", "Comment")
                        .WithMany("Votes")
                        .HasForeignKey("CommentIdId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Ballit.Core.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Ballit.Core.Models.Post", b =>
                {
                    b.HasOne("Ballit.Core.Models.Subballit", "Subballit")
                        .WithMany()
                        .HasForeignKey("Sub");
                });

            modelBuilder.Entity("Ballit.Core.Models.PostVote", b =>
                {
                    b.HasOne("Ballit.Core.Models.Post", "Post")
                        .WithMany("Votes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Ballit.Core.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Ballit.Core.Models.Subballit", b =>
                {
                    b.HasOne("Ballit.Core.Models.User")
                        .WithMany("Subscriptions")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}

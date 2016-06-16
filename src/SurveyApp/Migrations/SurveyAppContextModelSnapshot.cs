using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SurveyApp.Models;

namespace SurveyApp.Migrations
{
    [DbContext(typeof(SurveyAppContext))]
    partial class SurveyAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SurveyApp.Models.Age", b =>
                {
                    b.Property<int>("AgeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Display");

                    b.HasKey("AgeId");

                    b.ToTable("Age");
                });

            modelBuilder.Entity("SurveyApp.Models.Answer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AnswerText");

                    b.Property<int>("QuestionId");

                    b.HasKey("AnswerId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("SurveyApp.Models.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("QuestionText");

                    b.Property<int>("SurveyId");

                    b.HasKey("QuestionId");

                    b.HasIndex("SurveyId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("SurveyApp.Models.Sex", b =>
                {
                    b.Property<int>("SexId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Display");

                    b.HasKey("SexId");

                    b.ToTable("Sex");
                });

            modelBuilder.Entity("SurveyApp.Models.Survey", b =>
                {
                    b.Property<int>("SurveyId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("SurveyId");

                    b.ToTable("Survey");
                });

            modelBuilder.Entity("SurveyApp.Models.SurveyUser", b =>
                {
                    b.Property<int>("SurveyUserId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AgeId");

                    b.Property<int>("SexId");

                    b.HasKey("SurveyUserId");

                    b.HasIndex("AgeId");

                    b.HasIndex("SexId");

                    b.ToTable("SurveyUser");
                });

            modelBuilder.Entity("SurveyApp.Models.UserAnswer", b =>
                {
                    b.Property<int>("UserAnswerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AnswerId");

                    b.Property<int>("SurveyUserId");

                    b.HasKey("UserAnswerId");

                    b.HasIndex("AnswerId");

                    b.HasIndex("SurveyUserId");

                    b.ToTable("UserAnswer");
                });

            modelBuilder.Entity("SurveyApp.Models.Answer", b =>
                {
                    b.HasOne("SurveyApp.Models.Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SurveyApp.Models.Question", b =>
                {
                    b.HasOne("SurveyApp.Models.Survey")
                        .WithMany()
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SurveyApp.Models.SurveyUser", b =>
                {
                    b.HasOne("SurveyApp.Models.Age")
                        .WithMany()
                        .HasForeignKey("AgeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SurveyApp.Models.Sex")
                        .WithMany()
                        .HasForeignKey("SexId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SurveyApp.Models.UserAnswer", b =>
                {
                    b.HasOne("SurveyApp.Models.Answer")
                        .WithMany()
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SurveyApp.Models.SurveyUser")
                        .WithMany()
                        .HasForeignKey("SurveyUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}

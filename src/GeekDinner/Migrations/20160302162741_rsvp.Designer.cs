using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using GeekDinner.Infrastructure;

namespace GeekDinner.Migrations
{
    [DbContext(typeof(GeekDinnerDbContext))]
    [Migration("20160302162741_rsvp")]
    partial class rsvp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GeekDinner.Core.Dinner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("ContactPhone")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("Country");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<DateTime>("EventDate");

                    b.Property<string>("HostedBy")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<int?>("MaxAttendees");

                    b.Property<TimeSpan>("RsvpDeadline");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Id");
                });

            modelBuilder.Entity("GeekDinner.Core.Rsvp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<int?>("DinnerId");

                    b.Property<string>("EmailAddress");

                    b.Property<bool>("IsWaitlist");

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("GeekDinner.Core.Rsvp", b =>
                {
                    b.HasOne("GeekDinner.Core.Dinner")
                        .WithMany()
                        .HasForeignKey("DinnerId");
                });
        }
    }
}

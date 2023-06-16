using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WebIssueManagementApp.Models;

namespace WebIssueManagementApp.Data
{
  public class ManagementIssueContext : DbContext
  {
    public DbSet<User> Users { get; set; }
    public DbSet<Issue> Issues { get; set; }
    public DbSet<Attachment> Attachments { get; set; }

    public ManagementIssueContext(DbContextOptions<ManagementIssueContext> options) : base(options) { } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      ConfigureEntityUser(modelBuilder.Entity<User>());
      ConfigureEntityIssue(modelBuilder.Entity<Issue>());
      ConfigureEntityAttachment(modelBuilder.Entity<Attachment>());
    }

    private void ConfigureEntityUser(EntityTypeBuilder<User> buildUser)
    {
      buildUser
        .Property(b => b.Name)
        .IsRequired()
        .HasMaxLength(50)
        .HasColumnType("varchar(50)");

      buildUser
        .Property(b => b.Email)
        .IsRequired()
        .HasMaxLength(200)
        .HasColumnType("varchar(200)");

      buildUser
        .Property(b => b.Password)
        .IsRequired()
        .HasMaxLength(100)
        .HasColumnType("varchar(100)");

      buildUser.HasData(
        new User
        { 
          Id = 1, 
          Name = "admin",
          Email = "admin@issuemanager.com", 
          Password = "teste@123" 
        });
    }

    private void ConfigureEntityIssue(EntityTypeBuilder<Issue> buildIssues)
    {
      buildIssues
        .Property(b => b.DataBase)
        .HasMaxLength(20)
        .HasColumnType("varchar(30)");

      buildIssues
        .Property(b => b.Server)
        .HasMaxLength(30)
        .HasColumnType("varchar(30)");

      buildIssues
        .Property(b => b.UrlIssue)
        .HasMaxLength(200)
        .HasColumnType("varchar(200)");

      buildIssues
        .Property(b => b.Text)
        .HasColumnType("varchar(max)");

      buildIssues
        .Property(b => b.Abstract)
        .HasColumnType("varchar(100)");
      //doc: https://docs.microsoft.com/pt-br/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key
      //Sem propriedade de navegação
      //buildIssues
      //  .HasOne<User>(u => u.User)
      //  .WithMany()
      //  .HasForeignKey(fk => fk.IdUser);
      buildIssues
      .HasOne<User>()
      .WithMany()
      .HasForeignKey(fk => fk.IdUser);
    }


    private void ConfigureEntityAttachment(EntityTypeBuilder<Attachment> buildAttachment)
    {
      buildAttachment
        .Property(b => b.FileName)
        .HasMaxLength(100)
        .HasColumnType("varchar(100)");

      buildAttachment
        .Property(b => b.ContentType)
        .HasMaxLength(150)
        .HasColumnType("varchar(150)");

      buildAttachment
       .HasOne<Issue>()
       .WithMany(b => b.ListAttachment)
       .HasForeignKey(fk => fk.IdIssue);
    }
  }
}

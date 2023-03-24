namespace Database;

public partial class ParsethingContext : DbContext
{
    public ParsethingContext() { }

    public virtual DbSet<Developer> Developers { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<TaskExecutor> TaskExecutors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        _ = optionsBuilder.UseSqlServer(ProjectProperties.Resources.ConnectionString);
    }
}
using Microsoft.EntityFrameworkCore;

namespace OopModel;

public class dbCtx : DbContext
{
    static readonly string conStr;
    public DbSet<Unggas> unggass { get; set; }
    public DbSet<KakiEmpat> kakiempats { get; set; }
    static dbCtx()
    {
        conStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OOPDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
    }
    public dbCtx(DbContextOptions<dbCtx> opsi) : base(opsi)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(conStr);
        //base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder mb)
    {
        //base.OnModelCreating(mb);





    }
}

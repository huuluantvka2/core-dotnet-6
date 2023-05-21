namespace Data.Infracstructure
{
    public interface IDbFactory : IDisposable
    {
        BuildDbContext Init();
    }
}

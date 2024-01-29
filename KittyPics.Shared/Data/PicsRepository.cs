using System.Data.SqlClient;
using Dapper;
using KittyPics.Shared;
using MySql.Data.MySqlClient;

namespace KittyPics.Shared.Data;

public class PicsRepository : IPicsRepository, IDisposable
{
    private readonly MySqlConnection cn;
    public PicsRepository(ConnectionStrings connectionStrings)
    {
        cn = new MySqlConnection(connectionStrings.Default);
    }

    public IEnumerable<Pic> GetRandomPics(int count)
    {
        const string q = "SELECT * FROM Pics P ORDER BY RAND() LIMIT @count";
        return cn.Query<Pic>(q,new {count});
    }

    public void Vote(int picId)
    {
        const string q = "UPDATE Pics SET Votes = Votes + 1 WHERE PicID = @picId";
        cn.Query(q, new {picId});
    }

    public void Dispose()
    {
        cn.Dispose();
    }
}

public interface IPicsRepository
{
    public IEnumerable<Pic> GetRandomPics(int count);
    void Vote(int picId);
}
namespace gregSharp.Repositories;

public class HousesRepository
{
    private readonly IDbConnection _db;


    public HousesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal House CreateHouse(House houseData)
    {
        string sql = @"
        INSERT INTO houses
        (bedrooms, bathrooms, levels, year, price, description, imgUrl)
        VALUES
        (@bedrooms, @bathrooms, @levels, @year, @price, @description, @imgUrl)

        ";
        int id = _db.ExecuteScalar<int>(sql, houseData);
        houseData.Id = id;
        return houseData;
    }
    internal List<House> Get()
    {
        string sql = @"
            SELECT
             *
             FROM houses;
            ";
        List<House> houses = _db.Query<House>(sql).ToList();
        return houses;
    }

    internal bool Update(House original)
    {
        string sql = @"
    UPDATE houses
        SET
        bedrooms = @bedrooms,
        bathrooms = @bathrooms,
        levels = @levels,
        year = @year,
        price = @price,
        description = @description,
        imgUrl = @imgUrl
        WHERE id = @id;
    ";
        int rows = _db.Execute(sql, original);
        return rows > 0;
    }
    internal House Get(int id)
    {
        string sql = @"
    SELECT
    *
    FROM houses
    WHERE id = @id;
    ";
        House house = _db.Query<House>(sql, new { id }).FirstOrDefault();
        return house;
    }
}

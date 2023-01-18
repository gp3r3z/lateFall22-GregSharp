namespace gregSharp.Services;

public class HousesService
{
    private readonly HousesRepository _repo;

    public HousesService(HousesRepository repo)
    {
        _repo = repo;
    }
    internal House CreateHouse(House houseData)
    {
        House house = _repo.CreateHouse(houseData);
        return house;
    }
    internal List<House> Get()
    {
        List<House> houses = _repo.Get();
        return houses;
    }
    internal House Get(int id)
    {
        House house = _repo.Get(id);
        if (house == null)
        {
            throw new Exception("no house by that id");
        }
        return house;
    }
    internal House Update(House houseUpdate, int id)
    {
        House original = Get(id);
        Console.WriteLine("Here is the original " + original.Id);
        original.Bedrooms = houseUpdate.Bedrooms ?? original.Bedrooms;
        original.Bathrooms = houseUpdate.Bathrooms ?? original.Bathrooms;
        original.Levels = houseUpdate.Levels ?? original.Levels;

        // NOTE don't forget make your numbers nullable in your model
        original.Year = houseUpdate.Year ?? original.Year;
        original.Price = houseUpdate.Price ?? original.Price;
        original.Description = houseUpdate.Description ?? original.Description;
        original.ImgUrl = houseUpdate.ImgUrl ?? original.ImgUrl;

        bool edited = _repo.Update(original);
        if (edited == false)
        {
            throw new Exception("House was not edited");
        }
        return original;
    }
}

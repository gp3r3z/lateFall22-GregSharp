namespace gregSharp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
  private readonly CarsService _carsService;

  public CarsController(CarsService carsService)
  {
    _carsService = carsService;
  }

  [HttpGet]
  public ActionResult<List<Car>> Get()
  {
    try
    {
      List<Car> cars = _carsService.Get();
      return Ok(cars);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}")]
  public ActionResult<Car> Get(int id)
  {
    try
    {
      Car car = _carsService.Get(id);
      return Ok(car);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  public ActionResult<Car> Create([FromBody] Car carData)
  {
    try
    {
      Car car = _carsService.Create(carData);
      return Ok(car);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{id}")]
  public ActionResult<Car> Update([FromBody] Car carUpdate, int id)
  {
    try
    {
      Car car = _carsService.Update(carUpdate, id);
      return Ok(car);

    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
     
    }
  }

  [HttpDelete("{id}")]
  public ActionResult<string> Remove(int id)
  {
    try
    {
      string message = _carsService.Remove(id);
      return Ok(message);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
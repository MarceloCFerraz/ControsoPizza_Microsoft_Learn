using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;


[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController()
    {}


    [HttpGet]
    public ActionResult<List<Pizza>> GetAll()
    {
        return PizzaService.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        ActionResult result = NotFound();
        Pizza? pizza = PizzaService.Get(id);

        if (pizza is not null)
        {
            result = Ok(pizza);
        }

        return result;
    }

    
}
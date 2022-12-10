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

    [HttpPost]
    public ActionResult<Pizza> Post([FromBody] Pizza pizzaFromBody)
    {
        Pizza result = PizzaService.Add(pizzaFromBody);
        return CreatedAtAction
        (
            nameof(Get),
            new {id = result.Id},
            result
        );
    }

    [HttpPut("{id}")]
    public ActionResult<Pizza> Put(
        int id,
        [FromBody] Pizza pizzaFromBody
    )
    {
        ActionResult result = NotFound();

        if(PizzaService.Update(id, pizzaFromBody))
        {
            result = NoContent();
        }

        return result;
    }

    [HttpDelete("{id}")]
    public ActionResult<Pizza> Delete(int id)
    {
        ActionResult result = NotFound();

        if (PizzaService.Delete(id))
        {
            result = NoContent();
        }

        return result;
    }
}
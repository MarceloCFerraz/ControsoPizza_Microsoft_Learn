using ContosoPizza.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Services;

public static class PizzaService
{
    static List<Pizza> Pizzas { get; }
    static int nextId = 3;

    static PizzaService()
    {
        Pizzas = new List<Pizza> 
        {
            new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false},
            new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true}
        };
    }

    public static List<Pizza> GetAll()
    {
        return Pizzas;
    }

    public static Pizza? Get(int id)
    {
        return Pizzas.FirstOrDefault(pizza => pizza.Id == id);
    }

    public static Pizza Add(Pizza pizza)
    {
        pizza.Id = nextId ++;
        Pizzas.Add(pizza);
        return pizza;
    }

    public static bool Update(int id, Pizza pizza)
    {
        bool result = false;
        pizza.Id = id;
        var temp = Pizzas.FindIndex(p => p.Id == id);

        if (temp != -1)
        {
            Pizzas[id-1] = pizza;
            result = true;
        }

        return result;
    }

    public static bool Delete(int id)
    {
        bool result = false;

        Pizza? pizza = Get(id);

        if (pizza != null)
        {
            Pizzas.RemoveAt(id-1);
            result = true;
        }

        return result;
    }
}
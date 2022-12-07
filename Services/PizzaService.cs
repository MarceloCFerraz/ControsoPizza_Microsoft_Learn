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

    public static void Add(Pizza pizza)
    {
        pizza.Id = nextId ++;
        Pizzas.Add(pizza);
    }

    public static void Update(Pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);

        if (index != -1)
        {
            Pizzas[index] = pizza;
        }
    }

    public static void Delete(int id)
    {
        Pizza? pizza = Get(id);

        if (pizza != null)
        {
            Pizzas.RemoveAt(id);
        }
    }
}
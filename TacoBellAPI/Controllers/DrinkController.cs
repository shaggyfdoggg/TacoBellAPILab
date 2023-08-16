using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using TacoBellAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TacoBellAPI.Controllers
{
    [Route("api/[controller]")]
    public class DrinkController : Controller
    {
        private TacoBellDbContext dbContext = new TacoBellDbContext();

        // /api/Drink
        [HttpGet]

        public List<Drink> GetAll()
        {
            return dbContext.Drinks.ToList();
        }

        // api/Drink/slushie?s=true 
        [HttpGet("slushie")]
        public List<Drink> GetSlushieDrink(bool s)
        {
            return dbContext.Drinks.Where(d => d.Slushie == s).ToList();
        }

        //api/Drink?name=Pepsi&cost=1&slushie=false
        [HttpPost]
        public Drink AddDrink(string name, float cost, bool slushie)
        {
            Drink newDrink = new Drink();
            newDrink.Name = name;
            newDrink.Cost = cost;
            newDrink.Slushie = slushie;
            dbContext.Drinks.Add(newDrink);
            dbContext.SaveChanges();

            return newDrink;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TacoBellAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TacoBellAPI.Controllers
{
    [Route("api/[controller]")]
    public class BurritoController : Controller
    {
        private TacoBellDbContext dbContext = new TacoBellDbContext();

        // /api/Burrito
        [HttpGet]
        public List<Burrito> GetAll()
        {
            return dbContext.Burritos.ToList();
        }

        // /api/api/Burrito/bean?b=true
        [HttpGet("bean")]
        public List<Burrito> GetBeanBurrito(bool b)
        {
                return dbContext.Burritos.Where(r => r.Bean == b).ToList();
            
        }

        // api/Burrito?name={name}&cost=2.5&bean=true
        [HttpPost]
        public Burrito AddBurrito(string name, float cost, bool bean)
        {
            Burrito newBurrito = new Burrito();
            newBurrito.Name = name;
            newBurrito.Cost = cost;
            newBurrito.Bean = bean;
            dbContext.Burritos.Add(newBurrito);
            dbContext.SaveChanges();

            return newBurrito;
        }

        //api/Burrito/Delete/4
        [HttpDelete("Delete/{Id}")]
        public Burrito DeleteBurrito(int Id)
        {
            Burrito b = dbContext.Burritos.FirstOrDefault(b => b.Id == Id);
            dbContext.Burritos.Remove(b);
            dbContext.SaveChanges();

            return b;
        }

        [HttpPatch("{Id}")]
        public Burrito UpdateAge(int Id, float cost)
        {
            Burrito b = dbContext.Burritos.FirstOrDefault(b => b.Id == Id);
            b.Cost = cost;
            dbContext.Burritos.Update(b);
            dbContext.SaveChanges();

            return b;
        }
    }
}


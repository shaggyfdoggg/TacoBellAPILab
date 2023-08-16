using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TacoBellAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TacoBellAPI.Controllers
{
    [Route("api/[controller]")]
    public class TacoController : Controller
    {
        private TacoBellDbContext dbContext = new TacoBellDbContext();

        // /api/Taco
        [HttpGet]
        public List<Taco> GetAll()
        {
            return dbContext.Tacos.ToList();
        }

        //

        //api/Taco/dorito? d = true
        [HttpGet("dorito")]
        public List<Taco> GetDoritoTaco(bool d)
        {
              return dbContext.Tacos.Where(t => t.Dorito == d).ToList();

        }
        

    }
    
}


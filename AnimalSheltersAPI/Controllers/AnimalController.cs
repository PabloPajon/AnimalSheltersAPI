using AnimalSheltersAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimalSheltersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly animalshelterdbContext _context;

        public AnimalController(animalshelterdbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("AnimalsGet")]
        public async Task<List<Animal>> AnimalsGet()
        {
                return await _context.Animals.ToListAsync();
        }

        #region SimpleSearch

        [HttpGet("id={animalId}")]
        [Route("IdGet")]
        public ActionResult<Animal> IdGet(long id)
        {
            var results =  _context.Animals.Where(x => x.AnimalId == id);
            if (results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpGet("shelter={shelter}")]
        [Route("ShelterGet")]
        public ActionResult<Animal> ShelterGet(string shelter)
        {
            var results = _context.Animals.Include(b=>b.Shelter).Where(x => x.Shelter.Name == shelter);
            if (results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpGet("specie={specie}")]
        [Route("SpeciesGet")]
        public async Task<ActionResult<List<Animal>>> SpeciesGet(string species)
        {
            var results =  await _context.Animals.Where(x => x.Specie == species).ToListAsync();
            if (results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpGet("race={race}")]
        [Route("RaceGet")]
        public async Task<ActionResult<List<Animal>>> RaceGet(string race)
        {
            var results = await _context.Animals.Where(x => x.Race == race).ToListAsync();
            if (results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpGet("name={name}")]
        [Route("NameGet")]
        public async Task<ActionResult<List<Animal>>> NameGet(string name)
        {
            var results = await _context.Animals.Where(x => x.Name == name).ToListAsync();
            if (results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpGet("sex={sex}")]
        [Route("SexGet")]
        public async Task<ActionResult<List<Animal>>> SexGet(string sex)
        {
            var results = await _context.Animals.Where(x => x.Sex == sex).ToListAsync();
            if (results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpGet("age={age}")]
        [Route("AgeGet")]
        public async Task<ActionResult<List<Animal>>> AgeGet(string age)
        {
            var results = await _context.Animals.Where(x => x.Age == age).ToListAsync();
            if (results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }
        #endregion

        #region AdvanceSearch

        [HttpGet("specie={specie}&age={age}")]
        [Route("SpecieAndAgeGet")]
        public async Task<ActionResult<List<Animal>>> SpecieAndAgeGet(string specie,string age)
        {
            var results = await _context.Animals.Where(x => (x.Age == age) && (x.Specie == specie)).ToListAsync();
            if (results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }
        [HttpGet("specie={specie}&race={race}")]
        [Route("SpecieAndRaceGet")]
        public async Task<ActionResult<List<Animal>>> SpecieAndRaceGet(string specie, string race)
        {
            var results = await _context.Animals.Where(x => (x.Race == race) && (x.Specie == specie)).ToListAsync();
            if (results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpGet("specie={specie}&sex={sex}")]
        [Route("SpecieAndSexGet")]
        public async Task<ActionResult<List<Animal>>> SpecieAndSexGet(string specie, string sex)
        {
            var results = await _context.Animals.Where(x => (x.Sex == sex) && (x.Specie == specie)).ToListAsync();
            if (results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpGet("sex={sex}&age={age}")]
        [Route("SexAndAgeGet")]
        public async Task<ActionResult<List<Animal>>> SexAndAgeGet(string sex, string age)
        {
            var results = await _context.Animals.Where(x => (x.Age == age) && (x.Sex == sex)).ToListAsync();
            if (results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpGet("race={race}&age={age}")]
        [Route("RaceAndAgeGet")]
        public async Task<ActionResult<List<Animal>>> RaceAndAgeGet(string race, string age)
        {
            var results = await _context.Animals.Where(x => (x.Age == age) && (x.Race == race)).ToListAsync();
            if (results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }


        [HttpGet("race={race}&sex={sex}")]
        [Route("RaceAndSexGet")]
        public async Task<ActionResult<List<Animal>>> RaceAndSexGet(string race, string sex)
        {
            var results = await _context.Animals.Where(x => (x.Sex == sex) && (x.Race == race)).ToListAsync();
            if (results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpGet("specie={specie}&race={race}&age={age}")]
        [Route("SpecieRaceAndAgeGet")]
        public async Task<ActionResult<List<Animal>>> SpecieRaceAndAgeGet(string specie,string race, string age)
        {
            var results = await _context.Animals.Where(x => (x.Age == age) && (x.Race == race) && (x.Specie == specie)).ToListAsync();
            if (results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpGet("specie={specie}&race={race}&sex{sex}")]
        [Route("SpecieRaceAndSexGet")]
        public async Task<ActionResult<List<Animal>>> SpecieRaceAndSexGet(string specie, string race, string sex)
        {
            var results = await _context.Animals.Where(x => (x.Sex == sex) && (x.Race == race) && (x.Specie == specie)).ToListAsync();
            if (results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpGet("specie={specie}&age={age}&sex={sex}")]
        [Route("SpecieAgeAndSexGet")]
        public async Task<ActionResult<List<Animal>>> SpecieAgeAndSexGet(string specie, string age, string sex)
        {
            var results = await _context.Animals.Where(x => (x.Sex == sex) && (x.Age == age) && (x.Specie == specie)).ToListAsync();
            if (results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpGet("race={race}&age={age}&sex={sex}")]
        [Route("RaceAgeAndSexGet")]
        public async Task<ActionResult<List<Animal>>> RaceAgeAndSexGet(string race, string age, string sex)
        {
            var results = await _context.Animals.Where(x => (x.Sex == sex) && (x.Age == age) && (x.Race == race)).ToListAsync();
            if (results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpGet("specie={specie}&race={race}&age={age}&sex={sex}")]
        [Route("AnimalsDataGet")]
        public async Task<ActionResult<List<Animal>>> AnimalsDataGet([FromQuery]string specie, [FromQuery] string race , [FromQuery] string age, [FromQuery] string sex)
        {
            var results = await _context.Animals.Where(x => (x.Sex == sex) && (x.Age == age) && (x.Specie == specie) && (x.Race == race)).ToListAsync();
            if (results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }


        #endregion

       

        #region POST
        [HttpPost("specie={specie}&race={race}&name={name}&age={age}&state={state}&sex={sex}&owner={owner}")]
        [Route("AnimalPost")]
        public async Task<ActionResult> AnimalPost([FromQuery] string specie, [FromQuery] string race, [FromQuery] string name, [FromQuery] string age, [FromQuery] string state, [FromQuery] string sex, [FromQuery] int owner)
        {
            Console.WriteLine("e");
            
            try
            {
                _context.Database.ExecuteSqlRaw("INSERT INTO ANIMAL (specie,race,name,age,state,sex,shelterId) SELECT {0}, {1}, {2}, {3}, {4}, {5}, shelterID FROM SHELTER WHERE owner={6}", specie,race,name,age,state,sex,owner);
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
            return Ok();
        }


        [HttpPost("name={name}")]
        [Route("ShelterPost")]
        public async Task<ActionResult<string>> ShelterPost([FromQuery] string name)
        {
            Random rnd = new Random();
            bool test = false;
            string owner= rnd.Next(50000).ToString();
            while (test != true)
            {
                var connection =  await _context.Shelters.Where(x => x.Owner == owner).ToListAsync();
                if (connection.Count == 0)
                { 
                    test = true;
                }
                else
                {
                    owner = rnd.Next(50000).ToString();
                }
            }
            var shelter = new Shelter()
            {
                Name = name,
                Owner = owner
            };
            try
            {
                _context.Add(shelter);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
            return Ok(owner);
        }
        #endregion

        #region DELETE

        [HttpDelete("id={id}&owner={owner}")]
        [Route("AnimalDelete")]
        public async Task<ActionResult> AnimalDelete([FromQuery] int id, [FromQuery] int owner)
        {

            try
            {
                _context.Database.ExecuteSqlRaw("DELETE ANIMAL FROM ANIMAL AS t1 INNER JOIN SHELTER AS t2 ON t1.shelterId=t2.shelterID WHERE t1.AnimalID={0} AND t2.owner={1}", id, owner);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
            return Ok();
        }

        #endregion

        #region PUT

        [HttpDelete("id={id}&owner={owner}&state={state}")]
        [Route("AnimalPut")]
        public async Task<ActionResult> AnimalPut([FromQuery] int id, [FromQuery] string owner, [FromQuery] string state)
        {

            try
            {
                
                var updater = (from p in _context.Animals
                               join e in _context.Shelters
                               on p.ShelterId equals e.ShelterId
                               where e.Owner == owner && p.AnimalId == id
                               select new
                               {
                                   p,e
                               });

                foreach (var a in updater)
                {
                    a.p.State = state;
                }
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
            return Ok();
        }

        #endregion
    }
}

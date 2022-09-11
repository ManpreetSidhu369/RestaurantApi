using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ILogger<ReservationsController> _logger;
        private static List<MenuItem> menuItems = new List<MenuItem>();

        private static List<Reservations> reservations = new List<Reservations>();
        public ReservationsController(ILogger<ReservationsController> logger)

        {
            _logger = logger;
            reservations = new List<Reservations>
            {
            new Reservations
            {
                Id = 1,
                Name = "Bob Loblow",
                Date = DateTime.Now,
                menuItems = new List<MenuItem>
                {
                   new MenuItem
                   {
                       Id = 1,
                   Name= "Spaghetti",
                   Price=14.99

                }
                }
            },



            
                new Reservations
                {
                    Id = 2,
                    Name = "Manpreet",
                    Date = DateTime.Now,
                    menuItems = new List<MenuItem>
                {
                   new MenuItem
                   {
                       Id = 2,
                   Name= "Samosa",
                   Price= 10.20

                }
                }



               }    

            };

            logger.Log(LogLevel.Information, $"The reservation is intialized with {reservations[0].menuItems.Count} menu items");
    }

    
            
                
            
  
         
                
           
        // GET: api/<RestaurantController>
        [HttpGet]
        public IEnumerable<Reservations> Get()
        {
            return reservations;
            
        }

        // GET api/<RestaurantController>/5
        [HttpGet("{id:int}")]
        public Reservations Get(int id)
        {
            return reservations.FirstOrDefault(r => r.Id == id) ?? new Reservations();
        }
        [HttpGet("{name}")]
        public Reservations Get(string name)
        {
            return reservations.FirstOrDefault(r => r.Name == name) ?? new Reservations();
        }

        // POST api/<RestaurantController>
        [HttpPost]
        public Reservations Post([FromBody] Reservations reservation)
        {
            reservations.Add(reservation);
            return reservation;
        }

        // PUT api/<RestaurantController>/5
        [HttpPut("{id}")]
        public Reservations    Put(int id, [FromBody] Reservations reservation)
        {
            var res = reservations.FirstOrDefault(r => r.Id == id);
            var menu = menuItems.FirstOrDefault(m=>m.Id==id);
            res.Name = reservation.Name;
            res.Date = reservation.Date;
          
            return reservation;
            

        }

        // DELETE api/<RestaurantController>/5
        [HttpDelete("{id}")]
        public Reservations Delete(int id)
        {
            var res = reservations.FirstOrDefault(r => r.Id == id);
            reservations.Remove(res);
            return res;
        }
    }
}

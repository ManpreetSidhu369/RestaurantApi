using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {

        private readonly ILogger<MenuController> _logger;
        private static List<MenuItem> menuItems = new List<MenuItem>();
        public MenuController(ILogger<MenuController> logger)
        {
            _logger = logger;
            menuItems = new List<MenuItem>
            {
                new MenuItem
                {
                    Id = 1,
                    Name = "Spaghetti",
                    Price = 14.99
                },
             new MenuItem
             {
                 Id = 2,
                 Name = "Noodles",
                 Price = 10.50
             }
             };
            logger.Log(LogLevel.Information, $"There are  {menuItems.Count} menu items");
        }

        

        // GET: api/<MenuController>
        [HttpGet]
        public IEnumerable<MenuItem> Get()
        {
            
            return menuItems;
        }

        // GET api/<MenuController>/5
        [HttpGet("{id:int}")]
        public MenuItem Get(int id)
        {
            return menuItems.FirstOrDefault(m => m.Id == id) ?? new MenuItem();
        }
        [HttpGet("{name}")]
        public MenuItem Get(string name)
        {
            return menuItems.FirstOrDefault(m => m.Name == name) ?? new MenuItem();
        }

        // POST api/<MenuController>
        [HttpPost]
        public MenuItem Post([FromBody] MenuItem menuItem)
        {
             
            
            menuItems.Add(menuItem);
            return menuItem;
                
        }

        // PUT api/<MenuController>/5
        [HttpPut("{id}")]
        public MenuItem Put(int id, [FromBody] MenuItem menuItem)
        {
            var menus = menuItems.FirstOrDefault(m => m.Id == id);
            menus.Name = menuItem.Name;
            menus.Price = menuItem.Price;
            return menuItem;
        }

        // DELETE api/<MenuController>/5
        [HttpDelete("{id}")]
        public MenuItem Delete(int id)
        {
            var menus = menuItems.Find(m => m.Id == id);
            menuItems.Remove(menus);
            return menus;
            
        }
    }
}

namespace RestaurantApi
{
    public class Reservations
    {
        public int  Id { get; set; }
        public string   Name { get; set; }    
        public DateTime Date { get; set; }
        public List<MenuItem> menuItems { get; set; }
    }
}

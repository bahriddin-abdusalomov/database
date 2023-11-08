namespace Entity.Relations.Models
{
    public class Cars
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<PersonCars> CarsPerson { get; set; }
    }
}

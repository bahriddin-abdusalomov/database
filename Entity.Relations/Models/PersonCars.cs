namespace Entity.Relations.Models
{
    public class PersonCars
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int CarsId { get; set; }

        public Person Person { get; set; }
        public Cars Cars { get; set; }
    }
}


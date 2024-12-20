namespace ExomineAPI.Models
{
    public class Governor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int ColonyId { get; set; }
        public bool Active { get; set; }
    }
}

namespace ExomineAPI.Models.DTOs
{
    public class GovernorDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int ColonyId { get; set; }
        public bool Active { get; set; }
        public ColonyDTO? Colony { get; set; }
    }
}

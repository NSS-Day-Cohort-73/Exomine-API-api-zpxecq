namespace ExomineAPI.Models.DTOs
{
    public class MineralDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        // Nullable Quantity field to be populated on GET
        public int? Quantity { get; set; }
    }
}

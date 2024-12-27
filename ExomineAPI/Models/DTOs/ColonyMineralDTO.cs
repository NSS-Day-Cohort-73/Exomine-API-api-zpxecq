namespace ExomineAPI.Models.DTOs
{
    public class ColonyMineralDTO
    {
        public int Id { get; set; }
        public int ColonyId { get; set; }
        public int MineralId { get; set; }
        public int Quantity { get; set; }

        // Expanded data
        public ColonyDTO? Colony { get; set; }
        public MineralDTO? Mineral { get; set; }
    }
}

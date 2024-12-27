namespace ExomineAPI.Models.DTOs
{
    public class FacilityMineralDTO
    {
        public int Id { get; set; }
        public int FacilityId { get; set; }
        public int MineralId { get; set; }
        public int Quantity { get; set; }

        // Expanded data
        public FacilityDTO? Facility { get; set; }
        public MineralDTO? Mineral { get; set; }
    }
}

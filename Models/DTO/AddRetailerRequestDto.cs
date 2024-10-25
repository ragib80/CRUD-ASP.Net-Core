namespace RetailerAPI.Models.DTO
{
    public class AddRetailerRequestDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
    }
}

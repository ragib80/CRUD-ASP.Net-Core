namespace RetailerAPI.Models.DTO
{
    public class UpdateRetailerRequestDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
    }
}

namespace RetailerAPI.Models.DTO
{
    public class RetailerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
    }
}

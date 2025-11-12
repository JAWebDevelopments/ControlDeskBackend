namespace ControlDesk.Application.DTOs
{
    public  class TokenDto
    {
        public required string Issuer { get; set; }
        public required string Audience { get; set; }
        public required string SigningKey { get; set; }
    }
}

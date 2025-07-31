namespace Ecommerce.Application.Models.Token
{
    public class JwtSetting
    {
        public string? Key { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public Double DurationInMinutes { get; set; }
        public TimeSpan ExpireTime { get; set; }
    }
}   
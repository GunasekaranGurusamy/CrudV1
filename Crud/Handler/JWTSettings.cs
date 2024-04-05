namespace Crud.Handler
{
    public class JWTSettings
    {
        public string KEY { get; set; }
        public int Expire { get; set; }
        public int RefreshTokenExpire { get; set; }
    }
}

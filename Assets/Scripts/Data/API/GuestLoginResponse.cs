namespace Teenpatti.Data.API
{
    public class GuestLoginResponse
    {
        public bool success;
        public string message;
        public GuestLoginData data;
        public string accessToken;
        public string refreshToken;
    }
}

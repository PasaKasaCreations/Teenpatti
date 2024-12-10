
namespace Teenpatti.Data.API
{
    public class RefreshLoginResponse
    {
        public bool success;
        public string message;
        public Data data;

        public class Data
        {
            public string accessToken;
            public string refreshToken;
        }
    }
}

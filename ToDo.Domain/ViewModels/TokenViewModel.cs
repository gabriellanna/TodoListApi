namespace ToDo.Domain.ViewModels
{
    public class TokenViewModel
    {
        public TokenViewModel(
            bool authenticated,
            string created,
            string expiration,
            string accessToken,
            object dados
            )
        {
            Authenticated = authenticated;
            Created = created;
            Expiration = expiration;
            AccessToken = accessToken;
            Dados = dados;
        }
        public bool Authenticated { get; set; }
        public string Created { get; set; }
        public string Expiration { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public virtual object Dados { get; set; }
    }
}
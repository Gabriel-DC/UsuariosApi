using Microsoft.AspNetCore.Authorization;

namespace UsuariosApi.Authorization.Policies
{
    public class MinimumAgePolicy : IAuthorizationRequirement
    {
        public int MinimumAge { get; set; }
        public MinimumAgePolicy(int minimumAge)
        {
            MinimumAge = minimumAge;
        }
    }
}

using Microsoft.AspNetCore.Identity;

namespace Todo.Contracts
{
    public interface IJwtGenerator
    {
        string GenerateJwtToken(IdentityUser identityUser, IEnumerable<string> roles);
    }
}

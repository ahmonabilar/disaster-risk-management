using Microsoft.AspNetCore.Identity;

namespace Drm.Data.Entities
{
    public class DrmUser: IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class DrmRole : IdentityRole<int>
    {
    }
}

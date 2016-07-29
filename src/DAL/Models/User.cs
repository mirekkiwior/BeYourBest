using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DAL.Models
{
    public class User : IdentityUser
    {
        public virtual List<Category> Categories { get; set; }
    }
}

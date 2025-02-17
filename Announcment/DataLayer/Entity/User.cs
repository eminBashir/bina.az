using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entity
{
    public class User : IdentityUser<string>
    {
        public DateTime CreateDate { get; set; }
        public ICollection<Announcment> Announcments { get; set;}

    }
}

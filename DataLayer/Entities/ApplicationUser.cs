using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DataLayer.Entities
{


    // Add profile data for application users by adding properties to the ApplicationUser class
    [Table("ApplicationUser")]
    public class ApplicationUser : IdentityUser
    {
        [DisplayName("کد ملی")]
        [StringLength(500)]
        public string NationalCode { get; set; }
    }
}

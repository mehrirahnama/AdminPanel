using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminDashboardProject
{
    public class AdminDBContext: DbContext
    {
        public AdminDBContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<Users> Users { get; set; }
    }
}

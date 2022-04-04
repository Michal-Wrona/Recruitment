using Microsoft.EntityFrameworkCore;
using Recruitment.Core.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Core.DbAccess
{
    public class RecruitmentDbContext:DbContext
    {
        public RecruitmentDbContext(DbContextOptions<RecruitmentDbContext> options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}

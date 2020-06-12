using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebHocTiengAnh.Models
{
    public class DbContextFactory : IDesignTimeDbContextFactory<DBcontext>
    {
        public DBcontext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var con = configuration.GetConnectionString("WebEng");
            var optionsBuilder = new DbContextOptionsBuilder<DBcontext>();
            optionsBuilder.UseSqlServer(con);

            return new DBcontext(optionsBuilder.Options);
        }
    }
}

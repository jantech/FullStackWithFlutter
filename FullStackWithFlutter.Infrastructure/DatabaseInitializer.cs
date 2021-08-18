using FullStackWithFlutter.Core.Interfaces;
using FullStackWithFlutter.Core.Models;
using FullStackWithFlutter.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackWithFlutter.Infrastructure
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly ApplicationDbContext _dbContext;
        public DatabaseInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SeedSampleData()
        {
           await _dbContext.Database.EnsureCreatedAsync().ConfigureAwait(false);

           if (!_dbContext.AppUsers.Any())
           {
                var testUser1 = new AppUser
                {
                    FullName = "Test User 1",
                    MobileNumber = "+91000000001",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "SeedSampleData"
                };

                var testUser2 = new AppUser
                {
                    FullName = "Test User 2",
                    MobileNumber = "+91000000002",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "SeedSampleData"
                };

                _dbContext.AppUsers.Add(testUser1);
                _dbContext.AppUsers.Add(testUser2);

                await _dbContext.SaveChangesAsync();
            }

        }
    }
}
 
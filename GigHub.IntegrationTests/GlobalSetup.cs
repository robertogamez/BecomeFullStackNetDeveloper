using GigHub.Core.Models;
using GigHub.Persistence;
using NUnit.Framework;
using System.Data.Entity.Migrations;
using System.Linq;

namespace GigHub.IntegrationTests
{
    [SetUpFixture]
    public class GlobalSetUp
    {
        [SetUp]
        public void SetUp()
        {
            MigrateToDbLatestVersion();

            Seed();
        }

        private static void MigrateToDbLatestVersion()
        {
            var configuration = new Migrations.Configuration();
            var migrator = new DbMigrator(configuration);
            migrator.Update();
        }

        public void Seed()
        {
            var context = new ApplicationDbContext();

            if (context.Users.Any())
            {
                return;
            }

            context.Users.Add(new ApplicationUser
            {
                Name = "user1",
                Email = "-",
                UserName = "user1",
                PasswordHash = "-"
            });
            context.Users.Add(new ApplicationUser
            {
                Name = "user2",
                Email = "-",
                UserName = "user2",
                PasswordHash = "-"
            });

            context.SaveChanges();
        }
    }
}

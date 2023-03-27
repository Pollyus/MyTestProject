using Microsoft.EntityFrameworkCore;
using TestAppData;

namespace Coordinator.Services
{
    //Сервис автоматической миграции бд
    public class ServiceDatabase
    {
        public void ApdrateDb()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TestAppContext>();

            var options = optionsBuilder
                .UseNpgsql("NewTest_db")
                .Options; 

            using (var context = new TestAppContext(options))
            {
                context.Database.Migrate();
            }
        }
    }
}

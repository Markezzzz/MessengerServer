using MessengerServer.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MessengerServer
{
    class Program
    {
        static void Main()
        {
            var optionsBuilder = new DbContextOptionsBuilder<MessengerContext>();
            var options = optionsBuilder
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=messengerserverdb;Trusted_Connection=True;")
                .Options;
            var context = new MessengerContext(options);
            var messageRepository = new MessageRepository(context);
            var userRepository = new UserRepository(context);
            var contactRepository = new ContactRepository(context, userRepository);
        }
    }
}
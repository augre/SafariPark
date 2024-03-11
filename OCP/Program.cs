using System.Linq;

namespace OCP
{
    class Program
    {
        static void Main(string[] args)
        {
            var userManager = new UserManager();

            // BA: - We need to get all admins
            // You: - No problem
            var admins = userManager.GetUsers(new AdminFilter());

            // BA: - We need to get all premium users as well
            // You: - Easy
            var premiumUsers = userManager.GetUsers(new PremiumUserFilter());

            // BA: - We need to get all premium users and admins together
            // You: - Weeeelll... OK....
            var adminsAndPremiumUsers = userManager.GetUsers(new AdminFilter()).Concat(userManager.GetUsers(new PremiumUserFilter())); // You begin to realize your code smells

            // BA: - We need to get all users that are not admins and premiums
            // You: - Got it
            var simpleUsers = userManager.GetUsers(new SimpleUserFilter());

            // BA: - We need to get all users that are not admins and premiums
            // You: "Ummm... How do I call it? GetSimpleUsersWhosSubscriptionHasExpired?". - Done!
            var expiries = userManager.GetUsers(new ExpiredSubscriptionFilter());

            // BA: - We need a custom filter that allows end user to filter users in a way he likes
            // You: "%$#%!&??@!!!!!". - I need time to re-write the code.
        }
    }
}

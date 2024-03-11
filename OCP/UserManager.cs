using OCP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OCP
{
    public class UserManager
    {
        protected readonly IUserStore userStore = new UserStore();

        public IEnumerable<User> GetUsers(IUserFilter userFilter) => userFilter.Filter(this.userStore.Users);
    }

    public interface IUserFilter
    {
	    IEnumerable<User> Filter(IEnumerable<User> users);
    }

    public class AdminFilter : IUserFilter
    {
	    public IEnumerable<User> Filter(IEnumerable<User> users) => users.Where(u => u.Role == Roles.Admin).ToArray();
    }

    public class PremiumUserFilter : IUserFilter
    {
	    public IEnumerable<User> Filter(IEnumerable<User> users) => users.Where(u => u.IsPremiumUser && u.Subscription.IsActive).ToArray();
    }

    public class SimpleUserFilter : IUserFilter
    {
	    public IEnumerable<User> Filter(IEnumerable<User> users) => users.Where(u => u.Role != Roles.Admin && !u.IsPremiumUser).ToArray();
    }

    public class ExpiredSubscriptionFilter : IUserFilter
    {
	    public IEnumerable<User> Filter(IEnumerable<User> users) => throw new NotImplementedException();
    }


}

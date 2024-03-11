using System.Security.Principal;

namespace MVC.Sample.Models
{
    public class MemberPrincipal : MemberInfo, IPrincipal
    {
        public MemberPrincipal(string memberName)
        {
            this.Identity = new GenericIdentity(memberName);
        }

        public IIdentity Identity
        {
            get;
            private set;
        }

        public bool IsInRole(string role)
        {
            if (this.AllRoles.Contains(role))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
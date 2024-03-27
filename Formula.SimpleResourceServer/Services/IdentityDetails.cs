using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Formula.SimpleResourceServer
{
    public class IdentityDetails
    {
        protected IHttpContextAccessor _httpContextAccessor = null;
        protected ClaimsPrincipal _user = null;

        public IdentityDetails(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._user = httpContextAccessor.HttpContext.User;
        }

        protected bool _userIdFetched = false;
        protected string _userId = null;
        public string UserId
        {
            get
            {
                if (!this._userIdFetched)
                {
                    this._userIdFetched = true;
                    if (this._user != null)
                    {
                        this._userId = this._user.FindFirstValue(ClaimTypes.NameIdentifier);
                    }
                }
                return this._userId;
            }
        }

        protected bool _emailFetched = false;
        protected string _email = null;
        public string Email
        {
            get
            {
                if (!this._emailFetched)
                {
                    this._emailFetched = true;
                    if (this._user != null)
                    {
                        this._email = this._user.FindFirstValue(ClaimTypes.Email);
                    }
                }
                return this._email;
            }
        }

        protected bool _rolesFetched = false;
        protected List<string> _roles = null;
        public List<string> Roles
        {
            get
            {
                if (!this._rolesFetched)
                {
                    this._rolesFetched = true;
                    if (this._user != null)
                    {
                        this._roles = this._user.FindAll(ClaimTypes.Role).Select(i => i.Value).ToList();
                    }
                }
                return this._roles;
            }
        }

        public bool HasRole(string role)
        {
            var hasRole = false;

            if (this.Roles != null & this.Roles.Count() > 0)
            {
                hasRole = this.Roles.Contains(role);
            }

            return hasRole;
        }
    }
}
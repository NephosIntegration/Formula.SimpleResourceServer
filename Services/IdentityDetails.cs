using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

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

        protected Boolean _userIdFetched = false;
        protected String _userId = null;
        public String UserId 
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

        protected Boolean _emailFetched = false;
        protected String _email = null;
        public String Email 
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

        protected Boolean _rolesFetched = false;
        protected List<String> _roles = null;
        public List<String> Roles 
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
    }
}
﻿using Krola.Domain.Authorization;

namespace Krola.Web.Api.Core.Specifications
{
    public sealed class UserSpecification : BaseSpecification<User>
    {
        public UserSpecification(string identityId) : base(u => u.IdentityId==identityId)
        {
            AddInclude(u => u.RefreshTokens);
        }
    }
}

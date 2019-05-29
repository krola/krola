﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Krola.Web.Api.Core.Interfaces.Gateways.Repositories
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        List<string> IncludeStrings { get; }
    }
}

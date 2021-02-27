using ApplicationCore.Paging;
using Ardalis.Specification;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ApplicationCore.Specifications.GenericSpecifications
{
    public sealed class GetSpecfication<T> : Specification<T> where T : IAggregateRoot
    {
        public GetSpecfication(Expression<Func<T, bool>> criteria, List<Expression<Func<T, object>>> includes)
        {
            if (criteria != null)
                Query.Where(criteria);

            if (includes != null)
                includes.ForEach(i => Query.Include(i));
        }
    }
}

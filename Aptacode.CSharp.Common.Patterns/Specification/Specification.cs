﻿using System;
using System.Linq.Expressions;

namespace Aptacode.CSharp.Common.Patterns.Specification
{
    public abstract class Specification<T>
    {
        public bool IsSatisfiedBy(T entity)
        {
            var predicate = ToExpression().Compile();
            return predicate(entity);
        }

        public abstract Expression<Func<T, bool>> ToExpression();
    }
}
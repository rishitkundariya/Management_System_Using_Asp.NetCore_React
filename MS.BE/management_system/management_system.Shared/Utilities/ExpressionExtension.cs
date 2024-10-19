using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace management_system.Shared.Utilities
{
        public static class ExpressionExtensions
        {
        public static Expression<Func<TEntity, bool>> Add<TEntity>(this Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, bool>> condition)
        {
            try
            {
                var toInvoke = Expression.Invoke(condition, expression.Parameters);
                return Expression.Lambda<Func<TEntity, bool>>(Expression.AndAlso(expression.Body, toInvoke), expression.Parameters);
            }
            catch
            {
                return Expression.Lambda<Func<TEntity, bool>>(Expression.AndAlso(expression, condition));
            }

        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
            {
                if (left == null) return right;
                var and = Expression.OrElse(left.Body, right.Body);
                return Expression.Lambda<Func<T, bool>>(and, left.Parameters.Single());
            }
        }
}

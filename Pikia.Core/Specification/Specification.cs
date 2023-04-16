using Pikia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pikia.Core.Specification
{
    public class Specification<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get ; set ; } = new List<Expression<Func<T, object>>> ();
        public Expression<Func<T, object>> OrderBy { get ; set ; }
        public Expression<Func<T, object>> OrderByDesc { get; set; }

        public Specification()
        {

        }

        public Specification(Expression<Func<T, bool>> _Criteria)
        {
            Criteria = _Criteria;
        }

        public void AddOrderBy(Expression<Func<T, Object>> orderByExperssion)
        {
            OrderBy = orderByExperssion;
        }
        public void AddOrderByDesc(Expression<Func<T, Object>> orderByDescExperssion)
        {
            OrderBy = orderByDescExperssion;
        }

    }
}

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace DSW.Database.Repository
{
    public class SqlCePredicateList<TDb> where TDb : class
    {
        public List<SqlCePredicate<TDb>> Predicates { get; set; }
        public string OperatorConcat { get; set; }

        public SqlCePredicateList()
        {
            Predicates = new List<SqlCePredicate<TDb>>();
            OperatorConcat = "AND";
        }
    }

    public class SqlCePredicate<TDb> where TDb : class
    {
        public Expression<Func<TDb, object>> Property { get; set; }
        public string Operator { get; set; }
        public object Data { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataTableRemote.Models
{
    public class DataRecord<T>
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public IEnumerable<T> data { get; set; }
        public string error { get; set; }


    }

    public class DatatableParams<T>
    {
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public List<DataTableColumn> columns { get; set; }
        public DataTableSearch search { get; set; }

        internal IQueryable<T> OrderOnOrderable(IQueryable<T> customers)
        {
            if (this.order != null)
            {

                foreach (var order in this.order)
                {
                    var item = this.columns.ElementAt(order.column);

                    var propertyInfo = typeof(T).GetProperty(item.data);
                    var orderByAddress = customers.OrderBy(x => propertyInfo.GetValue(x, null));

                    if (order.dir == "asc")
                    {
                        customers = customers.OrderBy(x => propertyInfo.GetValue(x, null));
                    }
                    else if (order.dir == "desc")
                    {
                        customers = customers.OrderByDescending(x => propertyInfo.GetValue(x, null));
                    }
                }



            }


            return customers;
        }

        public List<DataTableOrder> order { get; set; }

        public IQueryable<T> FilterOnAllSearchable(IQueryable<T> customers)
        {
            if (this.search != null && !string.IsNullOrEmpty(this.search.value))
            {
                var searchBy = this.search.value.ToLower();

                var predicate = PredicateBuilder.False<T>();

                foreach (var item in this.columns)
                {
                    if (item.searchable)
                    {
                        var parameterExpression = Expression.Parameter(typeof(T), "c");
                        var constant = Expression.Constant(searchBy);
                        var property = Expression.Property(parameterExpression, item.data);

                        var containsMethodExp = Expression.Call(property, "IndexOf", null, constant, Expression.Constant(StringComparison.InvariantCultureIgnoreCase));

                        var like = Expression.GreaterThanOrEqual(containsMethodExp, Expression.Constant(0));

                        var lambda = Expression.Lambda<Func<T, bool>>(like, parameterExpression);

                        predicate = predicate.Or(lambda);


                    }


                }

                customers = customers.Where(predicate);
            }


            return customers;
        }

    }

    public class DataTableOrder
    {
        public int column { get; set; }
        public string dir { get; set; }
    }

    public class DataTableColumn
    {
        public string data { get; set; }
        public string name { get; set; }
        public bool searchable { get; set; }
        public bool orderable { get; set; }
        public DataTableSearch search { get; set; }
    }

    public class DataTableSearch
    {
        public string value { get; set; }
        public bool regex { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace WebBlog.Repository
{
    public class PagedResult<T> where T : class
    {
        public IList<T> Results { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }


        public PagedResult()
        {
            Results = new List<T>();
        }

        public int FirstRowOnPage
        {
            get { return (CurrentPage - 1) * PageSize + 1; }
        }

        public int LastRowOnPage
        {
            get { return Math.Min(CurrentPage * PageSize, RowCount); }
        }
    }
}

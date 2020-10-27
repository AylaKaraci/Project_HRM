using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_HRM.Common.PaginatedListModels
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; set; } //toplam kaç sayfa

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);//yuvarlama işlemi
            this.AddRange(items);

            //pageSize'ı dışarıdan gelen count'umla böldüm. Ceiling => 4,2 çıkarsa 5'e yuvarlar.
        }

        public bool PreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool NextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        //ekranda göstermek için :
        public static PaginatedList<T> CreateAsync(List<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gm.app.contracts.dtos
{
    public class PagedResultDto<T>
    {
        public long TotalCount { get; set; }
        private IReadOnlyList<T> _items;

        public IReadOnlyList<T> Items
        {
            get { return _items ?? (_items = new List<T>()); }
            set { _items = value; }
        }

        public PagedResultDto()
        {

        }

        public PagedResultDto(long totalCount, IReadOnlyList<T> items)
        {
            TotalCount = totalCount;
            Items = items;
        }

    }
}

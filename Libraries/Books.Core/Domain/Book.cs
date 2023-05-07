using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core.Domain
{
    public partial class Book : BaseEntity
    {
        public string Title { get;set; }

        public string Author { get;set; } 
        public string Publisher { get;set; }

        public DateTime PublisherTime { get; set; }
        public string Description { get;set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dapper_data_access.Models
{
    public class CareerItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Course Course { get; set; }
    }
}

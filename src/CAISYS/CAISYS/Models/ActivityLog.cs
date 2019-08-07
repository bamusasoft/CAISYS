using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAISYS.Models
{
    public class ActivityLog
    {
        public string Id { get; set; }

        public int ActionId { get; set; }

        public DateTime LodDate { get; set; }

        public string UserId { get; set; }


    }
}

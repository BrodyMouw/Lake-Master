using System;
using System.Collections.Generic;
using System.Text;

namespace LakeLife.Models
{
    public class Gig
    {
        public string Id => Guid.NewGuid().ToString("N");
        public string GigName { get; set; }
        public string Image { get; set; }
        public int Index { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
    }
}

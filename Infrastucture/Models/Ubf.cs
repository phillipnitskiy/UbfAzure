using System;
using System.Collections.Generic;

namespace Infrastucture.Models
{
    public partial class Ubf
    {
        public Guid Id { get; set; }
        public int ProducerId { get; set; }
        public int Status { get; set; }
    }
}

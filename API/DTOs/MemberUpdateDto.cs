using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class MemberUpdateDto
    {
        public string Introduction { get; set; }
        public string Interests { get; set; }
        public string city { get; set; }
        public string country { get; set; }
    }
}
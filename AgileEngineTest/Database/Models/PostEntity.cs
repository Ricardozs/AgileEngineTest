using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgileEngineTest.Database.Models
{
    public class PostEntity
    {
        public int PostId { get; set; }
        public int ParentId { get; set; }
        [MaxLength(50), MinLength(10)]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}

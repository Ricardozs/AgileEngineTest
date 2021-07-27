using AgileEngineTest.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgileEngineTest
{
    public class BlogEntity
    {
        public int BlogId { get; set; }
        [MaxLength(50), MinLength(10)]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public List<PostEntity> Articles { get; set; }
        public string IsActiveString
        {
            get { return IsActive ? "Blog is active" : "Blog is not active"; }
            set { IsActive = value == "Blog is active"; }
        }
    }
}

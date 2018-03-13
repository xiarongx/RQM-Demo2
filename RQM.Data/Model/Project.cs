using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RQM.Data.Model
{
    public class Project
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
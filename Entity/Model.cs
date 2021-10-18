using System;
using System.ComponentModel.DataAnnotations;

namespace testapisecond.Entity
{
    
    public class EntityModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="Name is required")][MaxLength(200)][RegularExpression(@"^[A-Z][a-z]+[^0-9]$",ErrorMessage="Format is Abc")]
        public string Name { get; set; }
        [Required(ErrorMessage="Email is required")][MaxLength(200)][RegularExpression(@"^([A-Z][a-zA-Z0-9]+)([\.{1}])?([a-zA-Z0-9]+)\@gmail([\.])com$",ErrorMessage="Format is Abc@gmail.com")]
        public string Email { get; set; }
        public DateTimeOffset DateTime { get; set; }

    }
}
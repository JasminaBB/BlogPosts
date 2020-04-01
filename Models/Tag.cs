using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogPost_WebAPI.Models
{
    public partial class Tag
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<BlogPostTag> BlogPosts { get; set; }
    }
}
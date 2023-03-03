using DevJJGR.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevJJGR.Domain.Entities
{
    public class Categories : Entity
    {
        [Key]
        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public IEnumerable<Products> Products { get; set; }
        public Categories()
        {
            CategoryId = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            ModifiedAt = DateTime.Now;
        }
    }
}

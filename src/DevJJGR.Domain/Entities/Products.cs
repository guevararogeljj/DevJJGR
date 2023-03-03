using DevJJGR.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace DevJJGR.Domain.Entities
{
    public class Products : Entity
    {
        [Key]
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }

        public Guid CategoryId { get; set; }
        public Categories Categories { get; set; }
        public Products()
        {
            ProductId = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            ModifiedAt = DateTime.Now;
            Visible = true;
        }
    }
}

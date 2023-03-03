namespace DevJJGR.Application.Dto
{
    public class ProductsDTO
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public CategoriesDTO Categories { get; set; }
    }
}

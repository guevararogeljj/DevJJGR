namespace DevJJGRCore.Common.Models
{
    public class PaginationDTO<T> : PagedResultDto
    {
        public List<T> Items { get; set; }

        public PaginationDTO()
        {

        }
        public PaginationDTO(List<T> items)
        {
            Items = items;
        }
    }
}

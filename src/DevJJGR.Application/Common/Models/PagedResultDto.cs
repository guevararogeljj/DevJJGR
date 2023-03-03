namespace DevJJGRCore.Common.Models
{
    public class PagedResultDto
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
        public int TotalPages { get => PaginationTotalPages(); }
        public bool ShowExport { get; set; }

        public int PaginationTotalPages()
        {
            if (PageSize > 0)
            {
                decimal resultado = Math.Ceiling((decimal)Total / (decimal)PageSize);
                return (int)resultado;
            }

            return 1;
        }

    }
}

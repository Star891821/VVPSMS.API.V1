namespace VVPSMS.Service.Filters
{
    public class PaginationFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? StatusCode { get; set; }
        public string? Name { get; set; }
        public PaginationFilter()
        {
            this.PageNumber = 1;
            this.PageSize = 100;
            StatusCode = null;
            Name = null;
        }
        public PaginationFilter(int? pageNumber, int? pageSize,int? statusCode,string? name)
        {
            if (pageNumber != null) {
                this.PageNumber = (int)pageNumber;
            }
            if(pageSize != null)
            {
                this.PageSize = (int)pageSize;
            }
            if(statusCode != null )
            {
                this.StatusCode = (int)statusCode;
            }
            if(!string.IsNullOrEmpty(name))
            {
                this.Name = name;
            }
            if(pageNumber == null && pageSize == null && statusCode == null && string.IsNullOrEmpty(name))
            {
                this.PageNumber = 1;
                this.PageSize = 100;
                StatusCode = null;
                Name = null;
                //StatusCode = 3;
            }
            //this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            //this.PageSize = pageSize > 10 ? pageSize : pageSize;
        }
    }
}

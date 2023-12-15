namespace VVPSMS.Service.Filters
{
    public class PaginationFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? StatusCode { get; set; }
        public string? Name { get; set; }

        public int? academic_id { get; set; }
        public int? stream_id { get; set; }
        public int? grade_id { get; set; }

        public PaginationFilter()
        {
            this.PageNumber = 1;
            this.PageSize = 100;
            StatusCode = null;
            Name = null;
            academic_id = null;
            stream_id = null;
            grade_id = null;
        }
        public PaginationFilter(int? pageNumber, int? pageSize,int? statusCode,string? name,int? academic_id,int? stream_id,int? grade_id)
        {
            if (academic_id != null)
            {
                this.academic_id = (int)academic_id;
            }
            if (stream_id != null)
            {
                this.stream_id = (int)stream_id;
            }
            if (grade_id != null)
            {
                this.grade_id = (int)grade_id;
            }
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
            if(pageNumber == null && pageSize == null && statusCode == null && string.IsNullOrEmpty(name)
                && academic_id == null && grade_id == null && stream_id == null)
            {
                this.PageNumber = 1;
                this.PageSize = 100;
                StatusCode = null;
                Name = null;
                academic_id = null;
                grade_id = null;
                stream_id = null;
                //StatusCode = 3;
            }
            //this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            //this.PageSize = pageSize > 10 ? pageSize : pageSize;
        }
    }
}

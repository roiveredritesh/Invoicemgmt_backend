namespace Invoice_Inventory_mgmt.Common
{

    public class CustomSearchResponse<T>
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string? TotalCount { get; set; }
        public T Data { get; set; }
    }


    public class CustomResponse<T>
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}

namespace New.Hope.Api
{
	public class Pagination
	{
		public object objects { get; set; }
		public Links links { get; set; }
		public int TotalPages { get; set; }
		public int TotalItens { get; set; }
	}
}
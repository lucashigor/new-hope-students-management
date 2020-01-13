namespace New.Hope.Api
{
	public class Links
	{
		public Links(int totalItens
								, int pageSize
								, int page)
		{
			first = "";
			next = "";
			previous = "";
			last = "";
		}
		public string first { get; private set; }
		public string next { get; private set; }
		public string previous { get; private set; }
		public string last { get; private set; }
	}
}
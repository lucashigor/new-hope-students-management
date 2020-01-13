using System.Collections.Generic;
using New.Hope.Application;

namespace New.Hope.Api
{
	public class DefaultResponse
	{
		public object data { get; set; }
		public List<Notify> messages { get; set; }
	}
}
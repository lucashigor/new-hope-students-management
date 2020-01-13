using System.Collections.Generic;

namespace New.Hope.Application
{
	public class Notify
	{
		public Notify()
		{
			Fields = new List<Notification>();
		}

		public Notify(string code, string message)
		{
			this.Code = code;
			this.Message = message;

			Fields = new List<Notification>();
		}


		public string Code { get; set; }

		public string Message { get; set; }

		public List<Notification> Fields { get; private set; }
	}
}

using System;
namespace New.Hope.Application
{
	public class Notification
	{
		public Notification(string field, string message, object value)
		{
			this.Field = field;
			this.Message = message;
			this.Value = value;
		}

		public string Field { get; private set; }
		public string Message { get; private set; }
		public object Value { get; private set; }

	}
}

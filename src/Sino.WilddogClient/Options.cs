namespace Sino.WilddogClient
{
	/// <summary>
	/// 附加条件
	/// </summary>
	public class Options
	{
		public int? LimitToFirst { get; set; }
		public int? LimitToLast { get; set; }
		public string Order { get; set; }
		public Range StartAt { get; set; }
		public Range EndAt { get; set; }
	}

	public class Range
	{
		public int IntValue { get; set; }
		public string StrValue { get; set; }
	}
}

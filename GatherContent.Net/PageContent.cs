namespace GatherContent.Net {
	/// <summary>
	/// Content tab.
	/// </summary>
	public class PageContent {
		/// <summary>
		/// Label for the content tab. Defaults to "Content".
		/// </summary>
		public string label { get; set; }
		/// <summary>
		/// Internal tab identifier.
		/// </summary>
		public string name { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public bool hidden { get; set; }
		/// <summary>
		/// Elements containing HTML or text that makeup this tab.
		/// </summary>
		public PageContentElement[] elements { get; set; }
	}
}
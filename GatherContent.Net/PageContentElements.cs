namespace GatherContent.Net {
	/// <summary>
	/// Text elements within a content tab.
	/// </summary>
	public class PageContentElement {
		/// <summary>
		/// Element type, such as "text".
		/// </summary>
		public string type { get; set; }
		/// <summary>
		/// Internal element identifier.
		/// </summary>
		public string name { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public bool required { get; set; }
		/// <summary>
		/// User declared content label.
		/// </summary>
		public string label { get; set; }
		/// <summary>
		/// Content HTML or text.
		/// </summary>
		public string value { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string microcopy { get; set; }
		/// <summary>
		/// How the content is limited, such as "words".
		/// </summary>
		public string limit_type { get; set; }
		/// <summary>
		/// Numeric limit of the content. Defaults to "0".
		/// </summary>
		public string limit { get; set; }
		/// <summary>
		/// True if <see cref="value"/> does not contain HTML.
		/// </summary>
		public bool plain_text { get; set; }
	}
}
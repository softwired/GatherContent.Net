using System;
using System.Text;
using Newtonsoft.Json;

namespace GatherContent.Net
{
    public class Page
    {
        public string id { get; set; }
        public string project_id { get; set; }
        public string name { get; set; }
        public string parent_id { get; set; }
        public string type { get; set; }
        public string due_date { get; set; }
        public string template_id { get; set; }
        public string repeatable { get; set; }
        public string repeatable_page_id { get; set; }
        public string position { get; set; }
        public string state { get; set; }
        public string custom_state_id { get; set; }
        public Field[] custom_field_config { get; set; }
        public object custom_field_values { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        /// <summary>
        /// Base64 page contents
        /// </summary>
        public string config { get; set; }
        /// <summary>
        /// Page content
        /// </summary>
        public PageContent[] contents { get; set; }
        /// <summary>
        /// Exception when calling <see cref="SetContents()"/>
        /// </summary>
        public Exception contentsException { get; set; }

        /// <summary>
        /// Populates <see cref="contents"/> by converted the <see cref="config"/> Base64 content.
        /// </summary>
        public void SetContents() {
            if (string.IsNullOrWhiteSpace(this.config)) {
                this.contents = new PageContent[0];
            }
            try {
                var configData = Convert.FromBase64String(this.config);
                var configJson = Encoding.UTF8.GetString(configData);
                this.contents = JsonConvert.DeserializeObject<PageContent[]>(configJson);
            } catch (Exception ex) {
                this.contentsException = ex;
            }
        }
    }
}
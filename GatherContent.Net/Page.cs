namespace GatherContent.Net
{
    public class Page
    {
        public string id { get; set; }
        public string project_id { get; set; }
        public string name { get; set; }
        public string parent_id { get; set; }
        public string repeatable { get; set; }
        public string repeatable_page_id { get; set; }
        public string position { get; set; }
        public string state { get; set; }
        public string custom_state_id { get; set; }
        public Field[] custom_field_config { get; set; }
        public object custom_field_values { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }
}
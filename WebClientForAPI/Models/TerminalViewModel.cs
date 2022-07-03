using System.Collections.Generic;

namespace WebClientForAPI.Models
{
    public class TerminalViewModel
    {
        public int Page_number { get; set; }
        public int Items_per_page { get; set; }
        public int Items_Count { get; set; }
        public List<TerminalViewModel> Items { get; set; }
        public bool Success { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Parameter1 { get; set; }
        public int Parameter2 { get; set; }
        public int Parameter3 { get; set; }
        public string Parameter_name1 { get; set; }
        public string Parameter_name2 { get; set; }
        public string Parameter_name3 { get; set; }
        public string Str_parameter_name1 { get; set; }
        public string Str_parameter_name2 { get; set; }
        public string Parameter_default_value1 { get; set; }
        public string Parameter_default_value2 { get; set; }
        public string Parameter_default_value3 { get; set; }
    }
}

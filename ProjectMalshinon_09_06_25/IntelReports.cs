using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMalshinon_09_06_25
{
    internal class IntelReports
    {
        public int Id {  get; set; }
        public int Reporter_id {  get; set; }
        public int Target_id {  get; set; }
        public string Text {  get; set; }
        public string Timestamp {  get; set; }

        public IntelReports(int id, int reporter_id, int target_id, string text, string timestamp)
        {
            Id = id;
            Reporter_id = reporter_id;
            Target_id = target_id;
            Text = text;
            Timestamp = timestamp;
        }
    }
}

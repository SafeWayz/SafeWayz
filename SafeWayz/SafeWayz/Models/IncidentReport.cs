namespace SafeWayz.Models
{
    public class IncidentReport
    {
        public int ID { get; set; }
        public string Area { get; set; }
        public string Incident { get; set; }
        public string IncidentDescription { get; set; }
        public Comment[] Comment { get; set; }
        public int UpvotesAmount { get; set; }
        public int DislikesAmount { get; set; }
    }
}

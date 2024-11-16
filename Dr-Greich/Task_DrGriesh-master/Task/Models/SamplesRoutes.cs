using System.ComponentModel.DataAnnotations.Schema;

namespace Task.Models
{
    public class SamplesRoutes
    {
        public int Id { get; set; }
        [ForeignKey("sample")]
        public int IdSample { get; set; }
        public Sample sample { get; set; }
        [ForeignKey("route")]
        public int IdRoute { get; set; }
        public Routes route { get; set; }
       
    }
}

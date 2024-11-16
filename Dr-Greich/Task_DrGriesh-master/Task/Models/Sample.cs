using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task.Models
{
    public class Sample
    {
        public Sample()
        {
            samplesRoutes = new List<SamplesRoutes>();
        }
        //public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Code { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        public List<SamplesRoutes> samplesRoutes { get; set; }
        public override string ToString()
        {
            return $"Code: {Code}, Name: {Name}";
        }
    }
}

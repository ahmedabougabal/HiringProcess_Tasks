using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task.Models
{
    public class Routes
    {
        public Routes()
        {
            samplesRoutes = new List<SamplesRoutes>();
        }
        //public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Code { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Location { get; set; }
        public int Duration { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        public List<SamplesRoutes> samplesRoutes { get; set; }
    }
}

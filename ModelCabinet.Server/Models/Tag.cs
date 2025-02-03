using System.ComponentModel.DataAnnotations;

namespace ModelCabinet.Server.Models
{
    public class Tag
    {
        [Key]
        public int TagID { get; set; }
        [Required]
        public string TagName { get; set; }

        public virtual ICollection<Asset> TaggedAssets { get; set; }
        public virtual ICollection<Project> TaggedProjects { get; set; }
    }
}

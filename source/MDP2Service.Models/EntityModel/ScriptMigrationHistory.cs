using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    [Table("__ScriptMigrationHistory")]
    public class ScriptMigrationHistory
    {
        [Key]
        [MaxLength(4000)]
        public string ScriptName { get; set; }

        [MaxLength(20)]
        public byte[] Hash { get; set; }

        public int Version { get; set; }
    }
}
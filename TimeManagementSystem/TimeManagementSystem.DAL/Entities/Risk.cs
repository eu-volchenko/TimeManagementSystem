namespace TimeManagementSystem.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Risk")]
    public partial class Risk
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(3000)]
        public string Description { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdProject { get; set; }

        public virtual Project Project { get; set; }
    }
}

namespace TimeManagementSystem.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ActivitiesInProject")]
    public partial class ActivitiesInProject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ActivitiesInProject()
        {
            Reports = new HashSet<Report>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Role { get; set; }

        [Required]
        [StringLength(40)]
        public string NameActivity { get; set; }

        public int IdProject { get; set; }

        public virtual Activity Activity { get; set; }

        public virtual Project Project { get; set; }

        public virtual Role Role1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Report> Reports { get; set; }
    }
}

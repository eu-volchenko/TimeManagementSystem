namespace TimeManagementSystem.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Report")]
    public partial class Report
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [StringLength(15)]
        public string Status { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Column(TypeName = "date")]
        public DateTime Worktime { get; set; }

        public int IdDeveloper { get; set; }

        public int IdProject { get; set; }

        public int IdActivity { get; set; }

        public int? IdTask { get; set; }

        public virtual ActivitiesInProject ActivitiesInProject { get; set; }

        public virtual Project Project { get; set; }

        public virtual Teammate Teammate { get; set; }

        public virtual Task Task { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC05_C_sharp_EFC_DI_HOST_MVVM_WPF.MVVM.Models.Entities
{
    internal class CaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(500)")]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime TimeOfCaseOpen { get; set; } = DateTime.Now;
        public DateTime? TimeOfCaseClosed { get; set; } = DateTime.Now;
        public DateTime? TimeOfCaseComment { get; set; } = DateTime.Now;

        [Required]
        [Column(TypeName = "char(1)")]
        public SeverityLevelEntity SeverityLevel { get; set; } = null!;

        [Required]
        [Column(TypeName = "char(1)")]
        public CaseStatusEntity CaseStatus { get; set; } = null!;

        public ICollection<CustomerEntity> Customers = new HashSet<CustomerEntity>();
    }
}

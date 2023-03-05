using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC05_C_sharp_EFC_DI_HOST_MVVM_WPF.MVVM.Models.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    internal class CustomerEntity
    {
        [Key] // PK 
        public int Id { get; set; }


        [Required]
        [StringLength(50)] // Will be nvarchar auto
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)] // Will be nvarchar auto
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)] // Will be nvarchar auto
        public string Email { get; set; } = string.Empty;


        [Column(TypeName = "char(13)")] // Takes string convert to char, also optional '?'. max 13.
        public string? PhoneNumber { get; set; }


        [Required]
        public int CaseId { get; set; }
        public CaseEntity Case { get; set; } = null!;
    }
}

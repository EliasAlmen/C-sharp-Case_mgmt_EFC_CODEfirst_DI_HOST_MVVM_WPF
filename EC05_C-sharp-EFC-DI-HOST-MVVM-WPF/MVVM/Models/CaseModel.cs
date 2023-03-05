using EC05_C_sharp_EFC_DI_HOST_MVVM_WPF.MVVM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC05_C_sharp_EFC_DI_HOST_MVVM_WPF.MVVM.Models
{
    internal class CaseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string Description { get; set; } = string.Empty;
        public int CaseId { get; set; }
        public CaseStatusEntity CaseStatus { get; set; } = null!;
        public SeverityLevelEntity SeverityLevel { get; set; } = null!;
        public DateTime TimeOfCaseOpen { get; set; }
        public DateTime? TimeOfCaseClosed { get; set; }
        public DateTime? TimeOfCaseComment { get; set; }

    }
}

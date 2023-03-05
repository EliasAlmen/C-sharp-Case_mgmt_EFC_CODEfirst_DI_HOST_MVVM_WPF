using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC05_C_sharp_EFC_DI_HOST_MVVM_WPF.MVVM.Models.Entities
{
    internal class CaseStatusEntity
    {
        [Key]
        public int Status { get; set; }
    }
}

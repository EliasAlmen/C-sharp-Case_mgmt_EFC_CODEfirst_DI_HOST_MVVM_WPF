using EC05_C_sharp_EFC_DI_HOST_MVVM_WPF.Contexts;
using EC05_C_sharp_EFC_DI_HOST_MVVM_WPF.MVVM.Models;
using EC05_C_sharp_EFC_DI_HOST_MVVM_WPF.MVVM.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC05_C_sharp_EFC_DI_HOST_MVVM_WPF.Services
{
    internal class CaseService
    {
        private static ApplicationDbContext _context = new();

        public static async Task SaveAsync(CaseModel caseModel)
        {
            var _customerEntity = new CustomerEntity
            {
                FirstName = caseModel.FirstName,
                LastName = caseModel.LastName,
                Email = caseModel.Email,
                PhoneNumber = caseModel.PhoneNumber,
                CaseId = caseModel.CaseId
            };

            var _caseEntity = await _context.Cases.FirstOrDefaultAsync(
                x =>  
                x.Description == caseModel.Description && 
                x.SeverityLevel == caseModel.SeverityLevel &&
                x.CaseStatus == caseModel.CaseStatus &&
                x.TimeOfCaseOpen == caseModel.TimeOfCaseOpen
                );
            if (_caseEntity != null)
            {
                _customerEntity.CaseId = _caseEntity.Id;
            }
            else
                _customerEntity.Case = new CaseEntity
                {
                    Description = caseModel.Description,
                    SeverityLevel = caseModel.SeverityLevel,
                    CaseStatus = caseModel.CaseStatus,
                    TimeOfCaseOpen = caseModel.TimeOfCaseOpen,
                };
            _context.Add(_customerEntity);
            await _context.SaveChangesAsync();
        }
    }
}

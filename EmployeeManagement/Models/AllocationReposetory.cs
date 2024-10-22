using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Models
{
    public class AllocationReposetory : IAllocationReposetory
    {
        private readonly EmployeeDbContext _context;

        public AllocationReposetory(EmployeeDbContext context)
        {
            _context = context;
        }
        public AllocationModel AllocateJobToUser(AllocationModel allocationModel)
        {
            _context.Allocations.Add(allocationModel);
            _context.SaveChanges(); 
            return allocationModel;
        }

        public List<AllocationModel> GetAll()
        {
            return _context.Allocations.ToList();
        }

        public AllocationModel GetAllocation(int allocationId)
        {
            return _context.Allocations.Find(allocationId);
        }

        public bool RemoveAllocation(AllocationModel allocationModel)
        {
            var existingAllocation = _context.Allocations.Find(allocationModel.AllocationId);
            if (existingAllocation != null)
            {
                _context.Allocations.Remove(existingAllocation); 
                _context.SaveChanges(); 
                return true;
            }
            return false;
        }

        public AllocationModel updateAllocation(AllocationModel allocationModel)
        {
            var existingAllocation = _context.Allocations.Find(allocationModel.AllocationId);
            if (existingAllocation != null)
            {
                existingAllocation.StaffId = allocationModel.StaffId;
                existingAllocation.JobId = allocationModel.JobId;
                existingAllocation.City = allocationModel.City;

                _context.SaveChanges(); 
                return existingAllocation; 
            }
            return null;
        }
    }
}

using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public interface IAllocationReposetory
    {
        public AllocationModel AllocateJobToUser(AllocationModel allocationModel);

        public bool RemoveAllocation(AllocationModel allocationModel);

        public AllocationModel GetAllocation(int allocationId);

        public List<AllocationModel> GetAll();

        public AllocationModel updateAllocation(AllocationModel allocationModel);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StaffCelebrationSystemAPI.Data.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        void RollbackTransactionAsync();
    }
}

using Microsoft.EntityFrameworkCore.Storage;
using StaffCelebrationSystemAPI.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StaffCelebrationSystemAPI.Data.Repositories.Implementations
{
    class UnitOfWork : IUnitOfWork
    {
        private StaffSystemDBContext context;
        private IDbContextTransaction transaction;

        public UnitOfWork(StaffSystemDBContext context)
        {
            this.context = context;
        }

        public async Task BeginTransactionAsync()
        {
            this.transaction = await this.context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (this.transaction != null)
            {
                await this.context.SaveChangesAsync();
                this.transaction.Commit();
                this.transaction.Dispose();
                this.transaction = null;
            }
        }

        public void RollbackTransactionAsync()
        {
            if (this.transaction != null)
            {
                this.transaction.Rollback();
                this.transaction.Dispose();
                this.transaction = null;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this.context.SaveChangesAsync();
        }
    }
}

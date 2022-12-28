using ComputerRepair.DataAccess.DataContext;
using ComputerRepair.DataAccess.Interfaces;
using ComputerRepair.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.DataAccess.Repositories.MsSql
{
    public class PayementRepository : IPayementRepository
    {

        private readonly ComputerRepairContext _computerRepairContext;
        public PayementRepository(ComputerRepairContext computerRepairContext)
        {
            _computerRepairContext = computerRepairContext;
        }
        public void Add(Payement payement)
        {
            _computerRepairContext.Add(payement);      
        }

        public void DeleteAsync(Payement payement)
        {
            _computerRepairContext.Remove(payement);
        }

        public Task<List<Payement>> GetAllAsync()
        {
            return _computerRepairContext.Payements
                  .AsNoTracking()
                  .ToListAsync();
        }

        public Task<Payement?> GetByIdAsync(int Id)
        {
            return _computerRepairContext.Payements
                .Where(p => p.PayementId == Id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

         }

        public Task SavechangesAsync()
        {
            return _computerRepairContext.SaveChangesAsync();
         }

        public void UpdateAsync(Payement payement)
        {
            _computerRepairContext.Update(payement);
         }

         
    }
}

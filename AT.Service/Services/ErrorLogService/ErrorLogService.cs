using AT.Data.Data;
using AT.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AT.Service.Services.ErrorLogService
{

    public interface IErrorLogService
    {
        Task<string> ErrorLogAdd();
    }
    public class ErrorLogService : IErrorLogService
    {
        private readonly ATContext _db;
        public ErrorLogService(ATContext db)
        {
            _db = db;
        }
        public async Task<string> ErrorLogAdd()
        {
            try
            {

                var error = new ErrorLogSystem
                {
                    ErrorRaisedMethod = "",
                    ErrorMessage = "",
                    ErrorRaisedClass = "",
                    CreatedOn = DateTime.Now
                };

                _db.Entry(error).State = EntityState.Added;
                await _db.SaveChangesAsync();
                return "";
            }
            catch (Exception ex)
            {
                return "";

            }
        }
    }
}

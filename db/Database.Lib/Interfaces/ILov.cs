
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

using Database.Models;
using Database.Lib.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Database.Lib.Repositories
{
   public interface ILov
    {
        Task<Dictionary<string, object>> getRecordsAsync(AppDbContext context, Dictionary<string, object> data, int comp_id = 0, string search_string = "");
    }
}


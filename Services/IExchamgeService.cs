
using System.Collections.Generic;
using System.Threading.Tasks;
using where_am_i_a_millionaire.Models;

namespace where_am_i_a_millionaire.Services
{
    public interface IExchangeService{
        Task<List<Something>> GetEquivalents(double amount, string currency);
    }
}
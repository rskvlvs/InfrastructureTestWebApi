using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsLogic.Repositories.Interfaces
{
    /// <summary>
    /// Interface for error repository.
    /// </summary>
    public interface IErrorRepository
    {
        public Task GenerateErrorsAsync();
    }
}

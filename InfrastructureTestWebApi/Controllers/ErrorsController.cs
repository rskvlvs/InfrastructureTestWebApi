using Microsoft.AspNetCore.Mvc;
using StatisticsLogic.Repositories.Interfaces;

namespace InfrastructureTestWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ErrorsController : ControllerBase
    {
        public IErrorRepository errorsRepository { get; set; }
        public ErrorsController(IErrorRepository errorsRepository)
        {
            this.errorsRepository = errorsRepository;
        }

        /// <summary>
        /// Generates errors.
        /// </summary>
        /// <returns>Action result</returns>
        [HttpPost]
        [Route(nameof(GenerateErrors))]
        public async Task<IActionResult> GenerateErrors()
        {
            try
            {
                await errorsRepository.GenerateErrorsAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }   
}

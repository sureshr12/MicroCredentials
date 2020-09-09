namespace PolicyManagementSystem.Api.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using PolicyManagementSystem.Api.Core.Model;
    using PolicyManagementSystem.Api.Services.Services;

    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyService _policyService;

        public PolicyController(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        [HttpGet("{policyNumber}/{productType}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PolicyModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<ActionResult> Get(string policyNumber, string productType)
        {
            if (string.IsNullOrEmpty(policyNumber) && string.IsNullOrEmpty(productType))
            {
                return BadRequest("Please enter the details to get the policy.");
            }

            var policy = await _policyService.GetAsync(policyNumber, productType);
            if (policy == null)
            {
                return NotFound($"Policy details which you entered is not available in our database.");
            }

            return Ok(policy);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<ActionResult> Post([FromBody] PolicyModel policy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please enter all the details correctly.");
            }
            var policyNumber = await _policyService.AddAsync(policy);
            if (!string.IsNullOrEmpty(policyNumber))
            {
                return Ok($"Policy {policyNumber} successfully created.");
            }

            return Accepted("Policy creation failed.");
        }

        [HttpDelete("{policyNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<ActionResult> Delete(string policyNumber)
        {
            if (string.IsNullOrEmpty(policyNumber))
            {
                return BadRequest("Please enter the policy number to delete the policy.");
            }

            var policy = await _policyService.GetByIdAsync(policyNumber);
            if (policy == null)
            {
                return NotFound($"Please enter a valid policy number or policy {policyNumber} is not found.");
            }

            var isSuccess = await _policyService.DeleteAsync(policy.Id, policy.Postcode);

            if (isSuccess)
            {
                return Ok($"Policy {policyNumber} successfully deleted.");
            }

            return BadRequest($"Policy deletion failed.");
        }

        [HttpPut("{policyNumber}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<ActionResult> Put(string policyNumber, [FromBody] PolicyModel policy)
        {
            if (string.IsNullOrEmpty(policyNumber))
            {
                return BadRequest("Please enter the details to update the policy.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Please enter all the details correctly.");
            }

            var result = await _policyService.GetByIdAsync(policyNumber);
            if (result == null)
            {
                return NotFound($"Policy {policyNumber} is not available.");
            }

            var isSuccess = await _policyService.UpdateAsync(policyNumber, policy);

            if (isSuccess)
            {
                return Ok($"Policy {policyNumber} successfully updated.");
            }

            return BadRequest($"Policy updation failed.");
        }

    }
}

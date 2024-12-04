using Microsoft.AspNetCore.Mvc;
using UserAdmin.Interfaces;

namespace UserAdmin.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly IAuthRepository mRepository;
        private readonly ITokenHandler tokenHandler;

        public AuthController(IAuthRepository authRepository, ITokenHandler tokenHandler)
        {
            this.mRepository = authRepository;
            this.tokenHandler = tokenHandler;
        }

        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(string code, string password)
        {
            // Check if user is authenticated
            // Check username and password
            try
            {
                var user = await mRepository.AuthenticateAsync(code, password);
                if (user != null)
                {
                    // Generate a JWT Token
                    var token = await tokenHandler.CreateTokenAsync(user);

                    Dictionary<string, object> data = new Dictionary<string, object>();
                    data.Add("user_id", user.user_id);
                    data.Add("user_code", user.user_code!);
                    data.Add("user_name", user.user_name!);
                    data.Add("user_email", user.user_email!);
                    data.Add("user_is_admin", user.user_is_admin!);
                    data.Add("user_company_id", user.rec_company_id!);
                    data.Add("user_branch_id", user.rec_branch_id!);
                    data.Add("user_token", token);
                    return Ok(data);
                }
                return Unauthorized("Invalid User Name/Password");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }


        [HttpPost]
        [Route("GetBranchListAsync")]
        public async Task<IActionResult> GetBranchListAsync([FromBody] Dictionary<string, object> data)
        {
            try
            {
                var Records = await this.mRepository.GetBranchListAsync(data);
                return Ok(Records);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message.ToString());
            }
        }

        [HttpPost]
        [Route("BranchLoginAsync")]
        public async Task<IActionResult> BranchLoginAsync([FromBody] Dictionary<string, object> data)
        {
            try
            {
                var Records = await this.mRepository.BranchLoginAsync(data);
                return Ok(Records);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message.ToString());
            }
        }

    }
}

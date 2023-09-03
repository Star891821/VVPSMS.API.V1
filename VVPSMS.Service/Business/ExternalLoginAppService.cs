using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Text;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Service.Models;
using VVPSMS.Service.Repository;

namespace VVPSMS.Service.Business
{
    public class ExternalLoginAppService: IExternalLoginAppService
    {
        private readonly IJwtAuthManager _JwtManager;
        private readonly GoogleConfig _GoogleConfig;
        private readonly ILoginService _LoginService;
        private const string Email = "email";
        public ExternalLoginAppService(IJwtAuthManager jwtManager,
            ILoginService loginService)
        {
            _GoogleConfig = new GoogleConfig();
            _JwtManager = jwtManager;
            _LoginService = loginService;
        }
        public async Task<LoginResponseDto> GoogleAuthenticationAsync(string authCode)
        {
            var creds = $"client_id={_GoogleConfig.ClientId}&client_secret={_GoogleConfig.ClientSecret}&code={authCode}" +
                $"&grant_type={_GoogleConfig.GrantType}&redirect_uri={_GoogleConfig.RedirectUri}";

            var accessToken = GetResponse(creds, _GoogleConfig.TokenUrl);

            if (accessToken == null)
            {
                throw new UnauthorizedAccessException("Invalid authentication code.");
            }

            var result = await GetUserInfo(accessToken, _GoogleConfig.GraphUrl);

            var items = JsonConvert.DeserializeObject<GoogleUserInfo>(result);

            if (items.email.IsNullOrEmpty())
            {
                throw new UnauthorizedAccessException("Google Authentication failed");
            }

            var loginResult = await _LoginService.GetEmployeeExternalvalidationAsync(items.email);

            //if (empResult == null)
            //{
            //    throw new UnauthorizedAccessException("login credentials are not updated in the facility, please contact administrator");
            //}

            //if (empResult.DelStatus.Value)
            //{
            //    await AuditLoginAsync(empResult.Id, (int)empResult.FacilityID, "Failure-Staff is Inactive", "Google");
            //    throw new UnauthorizedAccessException("Staff is Inactive, Please contact your administrator");
            //}

            var now = DateTime.Now;
            var id = Guid.NewGuid();
            //var tokens = _JwtManager.GenerateToken(empResult.QRPassCode, now, id);
            var tokens = _JwtManager.GenerateToken("", now, id);
            var refreshToken = _JwtManager.GenerateRefreshToken(now);

           // var isSaveToken = await SaveTokenAsync(empResult.Id, refreshToken.Item1, refreshToken.Item2);
            var isSaveToken = await SaveTokenAsync(0, refreshToken.Item1, refreshToken.Item2);
            if (!isSaveToken)
            {
                //throw new EntityNotFoundException("Internal server error.");
            }

            var item = new Token
            {
                AccessToken = tokens.Item1,
                AccessTokenExpiry = tokens.Item2,
                RefreshToken = refreshToken.Item1,
                RefreshTokenExpiry = refreshToken.Item2,
            };

            //var resultRS = new LoginRS.LoginItem
            //{
            //    EmployeeId = empResult.Id,
            //    EmployeeName = empResult.EmployeeName,
            //    EmployeeQRCode = empResult.QRPassCode,
            //    Token = item,
            //};

            //await AuditLoginAsync(empResult.Id, (int)empResult.FacilityID, "Success", "Google");

            //  var ret = new LoginRS { Result = resultRS };
            var ret = new LoginResponseDto();
            return ret;
        }

        public async Task<LoginResponseDto> MicrosoftAuthenticationAsync(MicrosoftRQ request)
        {
            LoginResponseDto ret = new LoginResponseDto();

            //try
            //{
            //    if (request.userId == null)
            //    {
            //        throw new UnauthorizedAccessException("Invalid request");
            //    }

            //    var empResult = await _LoginService.GetEmployeeExternalvalidationAsync(request.userId);

            //    if (empResult == null)
            //    {
            //        throw new UnauthorizedAccessException("login credentials are not updated in the facility, please contact administrator");
            //    }

            //    if (empResult.DelStatus.Value)
            //    {
            //        await AuditLoginAsync(empResult.Id, (int)empResult.FacilityID, "Failure-Staff is Inactive", "Microsoft");
            //        throw new UnauthorizedAccessException("Staff is Inactive, Please contact your administrator");
            //    }

            //    var now = DateTime.Now;
            //    var id = Guid.NewGuid();
            //    var tokens = _JwtManager.GenerateToken(empResult.QRPassCode, now, id);
            //    var refreshToken = _JwtManager.GenerateRefreshToken(now);


            //    var isSaveToken = await SaveTokenAsync(empResult.Id, refreshToken.Item1, refreshToken.Item2);

            //    if (!isSaveToken)
            //    {
            //       // throw new EntityNotFoundException("Internal server error.");
            //    }

            //    var item = new Token
            //    {
            //        AccessToken = tokens.Item1,
            //        AccessTokenExpiry = tokens.Item2,
            //        RefreshToken = refreshToken.Item1,
            //        RefreshTokenExpiry = refreshToken.Item2,
            //    };

            //    var resultRS = new LoginRS.LoginItem
            //    {
            //        EmployeeId = empResult.Id,
            //        EmployeeName = empResult.EmployeeName,
            //        EmployeeQRCode = empResult.QRPassCode,
            //        Token = item,
            //    };

            //    ret = new LoginRS { Result = resultRS };

            //    await AuditLoginAsync(empResult.Id, (int)empResult.FacilityID, "Success", "Microsoft");
            //}
            //catch (Exception ex)
            //{
            //    await LogErrorAsync("MicrosoftAuthenticationAsync", ex.Message, ex.StackTrace);
            //    //await RepoManager.EndTransactionAsync(true);
            //    throw ex;
            //}

            return ret;
        }

        public async Task<LoginResponseDto> AppleAuthenticationAsync(string idToken)
        {
            //var email = GetEmailFromToken(idToken);

            //if (email.NullOrWhiteSpace())
            //{
            //    throw new UnauthorizedAccessException("Please allow access for Email");
            //}

            //var empResult = await _LoginService.GetEmployeeExternalvalidationAsync(email);

            //if (empResult == null)
            //{
            //    throw new UnauthorizedAccessException("login credentials are not updated in the facility, please contact administrator");
            //}

            //if (empResult.DelStatus.Value)
            //{
            //    await AuditLoginAsync(empResult.Id, (int)empResult.FacilityID, "Failure-Staff is Inactive", "Apple");
            //    throw new UnauthorizedAccessException("Staff is Inactive, Please contact your administrator");
            //}

            //var now = DateTime.Now;
            //var id = Guid.NewGuid();
            //var tokens = JwtManager.GenerateToken(empResult.QRPassCode, now, id);
            //var refreshToken = JwtManager.GenerateRefreshToken(now);

            //var isSaveToken = await SaveTokenAsync(empResult.Id, refreshToken.Item1, refreshToken.Item2);

            //if (!isSaveToken)
            //{
            //    throw new EntityNotFoundException("Internal server error.");
            //}

            //var item = new Token
            //{
            //    AccessToken = tokens.Item1,
            //    AccessTokenExpiry = tokens.Item2,
            //    RefreshToken = refreshToken.Item1,
            //    RefreshTokenExpiry = refreshToken.Item2,
            //};

            //var resultRS = new LoginRS.LoginItem
            //{
            //    EmployeeId = empResult.Id,
            //    EmployeeName = empResult.EmployeeName,
            //    EmployeeQRCode = empResult.QRPassCode,
            //    Token = item,
            //};

            //await AuditLoginAsync(empResult.Id, (int)empResult.FacilityID, "Success", "Apple");

            var ret = new LoginResponseDto();

            return ret;
        }

        public async Task<bool> LogErrorAsync(string notificationId, string requests, string remarks)
        {

          //  var ret = await RepoLogin.LogErrorAsync(notificationId, requests, remarks);

            return true;
        }
        #region Private methods

        private string GetResponse(string creds, string url)
        {
            var hc = new HttpClient();
            hc.DefaultRequestHeaders.Accept.Clear();
            hc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            var content = new StringContent(creds, Encoding.UTF8, "application/x-www-form-urlencoded");
            var response = hc.PostAsync(url, content).Result;
            var jsonContent = response.Content.ReadAsStringAsync().Result;

            var tokenObj = JsonConvert.DeserializeObject<AuthResponse>(jsonContent);
            return tokenObj.access_token;
        }
        private async Task<string> GetUserInfo(string token, string url)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var result = await httpClient.GetAsync(url);
            var userInfo = result.Content.ReadAsStringAsync().Result;
            return userInfo;
        }

        private async Task<bool> SaveTokenAsync(int empId, string token, DateTime exp)
        {
            //var result = await RepoCommon.GetTokens(t => t.UserID == empId);

            //if (result.AnyAndNotNull())
            //{
            //    RepoCommon.RemoveRange(result);
            //}

            //var request = new TransTokens
            //{
            //    Token = token,
            //    UserID = empId,
            //    ExpiryDate = exp,
            //};

            //RepoManager.RepoCommon.Add(request);
            //var ret = await RepoManager.SaveChangesAsync();

            //return ret > 0;

            return true;
        }
        private async Task<bool> AuditLoginAsync(int empId, int? facilityId, string status, string method)
        {
            //CommonService service = new CommonService(AppContext);

            //var auditItem = new AuditLogin
            ////{
            ////    Status = status,
            ////    LoginMethod = method,
            ////};

            //var ret = await service.AuditTrialAsync(empId, facilityId, "Login", auditItem.ToJson());
            //return ret;
            return true;
        }
        private string GetEmailFromToken(string idToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = (JwtSecurityToken)tokenHandler.ReadToken(idToken);

            var value = securityToken.Claims.FirstOrDefault(c => c.Type == Email)?.Value;
            return value;
        }
        #endregion
    }
}

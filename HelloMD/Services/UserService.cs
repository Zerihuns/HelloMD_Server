using HelloMD.models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using HelloMD.Dtos;
using HelloMD.Helpers;
using HelloMD.Repositories.Interfaces;
using AutoMapper;

namespace HelloMD.Services
{
    public interface IUserService
    {
        (UserDto,string) Authenticate(AuthenticateRequestDto model);
        Task<IEnumerable<UserDto>> GetAll();
        UserDto GetById(int id);
    }

    public class UserService : IUserService
    {
       
        private readonly AppSettings _appSettings;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, IUserRepository userRepository, IOptions<AppSettings> appSettings)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _appSettings = appSettings.Value ?? throw new ArgumentNullException(nameof(appSettings)) ;
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public (UserDto, string) Authenticate(AuthenticateRequestDto model)
        {
            var user = _userRepository.Confirm(model.Username, model.Password);

            // return null if user not found
            if (user.Result == null) return (null,"");

            // authentication successful so generate jwt token
            var token = generateJwtToken(user.Result);

            return (_mapper.Map<UserDto>(user.Result),token);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var users = await _userRepository.GetAllAsync();
            return null;
        }

        public UserDto GetById(int id)
        {
            return _mapper.Map<UserDto>(_userRepository.GetByIdAsync(id));
        }

        // helper methods

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.UserID.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

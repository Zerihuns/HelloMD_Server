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
using HelloMD.Services.Interface;

namespace HelloMD.Services
{
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

        public async Task<ICollection<UserDto>> GetAll()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<List<UserDto>>(users.ToList());
        }

     
        public async Task<UserDto> GetById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserDto>(user);
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

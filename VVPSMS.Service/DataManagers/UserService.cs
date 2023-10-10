using AutoMapper;
using Microsoft.Extensions.Configuration;
using VVPSMS.Api.Models.Enums;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository;

namespace VVPSMS.Service.DataManagers
{
    public class UserService : IUserService<MstUserDto>
    {
        private IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IStorageService _storageService;
        public UserService(IMapper mapper, IConfiguration configuration, IStorageService storageService)
        {
            _mapper = mapper;
            _configuration = configuration;
            _storageService = storageService;
        }
        public bool Delete(int id)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var entity = dbContext.MstUsers.FirstOrDefault(e => e.UserId == id);
                if (entity != null)
                {
                    dbContext.MstUsers.Remove(entity);
                    dbContext.SaveChanges();
                }
                return true;
            }
        }

        public List<MstUserDto> GetAll()
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var result = dbContext.MstUsers.ToList();
                return _mapper.Map<List<MstUserDto>>(result);
            }
        }

        public MstUserDto? GetById(int id)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var result = dbContext.MstUsers?.FirstOrDefault(e => e.UserId.Equals(id));
                return _mapper.Map<MstUserDto>(result);
            }
        }

        public MstUserDto? GetByName(string userName)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                var result = dbContext.MstUsers?.FirstOrDefault(e => e.Username.Equals(userName));
                return _mapper.Map<MstUserDto>(result);
            }
        }

        public bool InsertOrUpdate(MstUserDto entity)
        {
            using (var dbContext = new VvpsmsdbContext())
            {
                if (entity != null)
                {
                   
                    if (entity.UserId != 0)
                    {
                        var dbentity = dbContext.MstUsers.FirstOrDefault(e => e.UserId == entity.UserId);
                        if (dbentity != null && dbentity.Userpassword == entity.Userpassword)
                        {

                            dbContext.Entry(dbentity).CurrentValues.SetValues(_mapper.Map<MstUser>(entity));
                        }
                        else
                        {
                            throw new Exception(ErrorCode.MissingData.ToString());
                        }                            
                    }
                    else
                    {
                        var existingUser = dbContext.MstUsers.FirstOrDefault(x=>x.Username.Equals(entity.Username));
                        if (existingUser != null)
                        {
                            throw new Exception(ErrorCode.AlreadyExist.ToString());
                        }
                        else
                        {
                            dbContext.MstUsers.Add(_mapper.Map<MstUser>(entity));
                        }
                                            
                    }
                    dbContext.SaveChanges();
                }
                return true;
            }
        }
    }
}

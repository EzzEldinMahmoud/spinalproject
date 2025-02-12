using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using spinalproject.src.appointDbContext;
using System.Linq;

public class UserService
{
    private appointDbContext dbcontext;
    private IMapper mapper;
    public UserService(appointDbContext _dbcontext,IMapper _mapper) {
        dbcontext = _dbcontext;
        mapper = _mapper;
    }
    public userDTO getUser(Guid userId)
    {
        var User = dbcontext.Users.FirstOrDefaultAsync(p => p.id == userId).Result;
        if(User != null)
        {
            return mapper.Map<userDTO>(User);
        } else
        {
            throw new Exception("User not found!");
        }
    }
    public Guid create(userDTO user) {
        try
        {
            var userEntity = mapper.Map<UserEntity>(user);
            var newUser = dbcontext.Users.FirstOrDefaultAsync(p => p.email_address == userEntity.email_address).Result;
            if (newUser != null)
            {
                throw new Exception("User already exists");
            }
            else
            {
                dbcontext.Users.Add(userEntity);
                dbcontext.SaveChanges();
                var User = dbcontext.Users.FirstOrDefaultAsync(p => p.email_address == userEntity.email_address).Result;
                if(User == null)
                {
                    throw new Exception("Something went wrong, please try again later!");
                }
                return User.id;
                

            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        

    }
    public Guid login(userDTO user) {
        var userEntity = mapper.Map<UserEntity>(user);
        var foundUser = dbcontext.Users.FirstOrDefaultAsync(p => p.email_address == userEntity.email_address).Result;

        if (foundUser == null)
        {
            throw new Exception("User not found");
        }
        else
        {
            if (foundUser.password != user.password)
            {
                throw new Exception("Invalid password");
            }
            else
            {
                return foundUser.id;
            }
        }
        }

}
using AutoMapper;
using BEL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TokenService
    {
        //auto mapper 6.1.1 used
        public static List<TokenModel> Get()
        {
            //AutoMapper.Mapper
            Mapper.Initialize(cfg => cfg.CreateMap<Token, TokenModel>());
            var data = AutoMapper.Mapper.Map<List<TokenModel>>(DataAccessFactory.TokenDataAccess().Get()); // for automapper 6.1.1
            return data;
        }
        public static TokenModel Get(string token)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Token, TokenModel>());
            var data = Mapper.Map<TokenModel>(DataAccessFactory.TokenDataAccess().Get(token)); // for automapper 6.1.1
            return data;
        }
        public static void Create(TokenModel token)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TokenModel, Token>());
            var data = Mapper.Map<Token>(token); // for automapper 6.1.1
            DataAccessFactory.TokenDataAccess().Add(data);

        }
        public static void Edit(TokenModel token)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TokenModel, Token>());
            var data = Mapper.Map<Token>(token); // for automapper 6.1.1
            DataAccessFactory.TokenDataAccess().Edit(data);

        }
        public static void Delete(string token)
        {
            DataAccessFactory.TokenDataAccess().Delete(token);
        }

    }
}

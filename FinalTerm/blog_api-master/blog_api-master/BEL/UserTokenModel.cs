using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class UserTokenModel : UserModel
    {
        public List<TokenModel> Tokens { get; set; }
    }
}

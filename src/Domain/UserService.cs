using System.Collections.Generic;

namespace Zunzun.Domain {

    public interface UserService {
    
        User FindByUserName(string UserName);
        
        void Follow(string UserName);
        List<User> Following { get; }
    }
}
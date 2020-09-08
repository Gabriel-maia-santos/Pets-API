using Pets_2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets_2.Interfaces {
    interface IRacas {
        Racas Register(Racas a);
        List<Racas> ReadAll();
        Racas SearchById(int id);
        Racas Update(int id,Racas a);
        void Delete(int id);


    }
}

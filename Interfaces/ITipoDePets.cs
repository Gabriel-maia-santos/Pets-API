using Pets_2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_Database_with_Pets.Interfaces {
    interface ITipoDePets {
        TipoDePets Register(TipoDePets a);
        List<TipoDePets> ReadAll();
        TipoDePets SearchById(int id);
        TipoDePets Update(int id, TipoDePets a);
        void Delete(int id);

    }
}

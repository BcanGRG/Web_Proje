using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Proje.Contexts;
using Web_Proje.Entities;
using Web_Proje.Interfaces;

namespace Web_Proje.Repositories
{
    //Urun repository ile method gövdelerini , IUrunrepo ilede method ları getiriyoruz . Bu yüzden ikisinden de kalıtım yapılıyor
    public class UrunRepository : GenericRepository<Urun> ,IUrunRepository
    {
      
    }
}

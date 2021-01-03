using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Web_Proje.Contexts;
using Web_Proje.Entities;

namespace Web_Proje.Interfaces
{
    public interface IUrunKategoriRepository : IGenericRepository<UrunKategori> 
    {
        // LINQ sorgusu ile filtreleme
        UrunKategori GetirFiltreile(Expression<Func<UrunKategori, bool>> filter);
        
    }
}

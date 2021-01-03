using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Web_Proje.Contexts;
using Web_Proje.Entities;
using Web_Proje.Interfaces;

namespace Web_Proje.Repositories
{
    public class UrunKategoriRepository : GenericRepository<UrunKategori>, IUrunKategoriRepository
    {
        public UrunKategori GetirFiltreile(Expression<Func<UrunKategori, bool>> filter)
        {
            using var context = new Context0();
           return context.UrunKategoriler.FirstOrDefault(filter);
        }
    }
}

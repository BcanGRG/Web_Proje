﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Proje.Entities;

namespace Web_Proje.Contexts
{
    public class Context0 : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { // SQL Server Bağlnatısı
            optionsBuilder.UseSqlServer("server = .\\SQLEXPRESS ; database = Web_Proje ; integrated security = true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {  // Çoka çok ilişkiyi oluşturma
            modelBuilder.Entity<Urun>().HasMany(I => I.UrunKategoriler).WithOne(I => I.Urun).HasForeignKey(I => I.UrunId);
            modelBuilder.Entity<Kategori>().HasMany(I => I.UrunKategoriler).WithOne(I => I.Kategori).HasForeignKey(I => I.KategoriId);

            //Aynı Alana Veri Girişini Engellemeyi Sağlıyor Unique yapma
            modelBuilder.Entity<UrunKategori>().HasIndex(I => new
            {
                I.KategoriId,
                I.UrunId,
            }).IsUnique();
        }
        public DbSet<UrunKategori> UrunKategoriler { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
    }
}
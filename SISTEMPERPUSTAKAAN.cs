using System;
using System.Collections.Generic;

namespace SistemPerpustakaan
{
    class Item
    {
        public string Judul { get; set; }
        public int Tahun { get; set; }

        public Item(string judul, int tahun)
        {
            Judul = judul;
            Tahun = tahun;
        }

        public virtual void Deskripsi()
        {
            Console.WriteLine("Ini adalah item perpustakaan.");
        }

        public void InfoItem()
        {
            Console.WriteLine("Judul : " + Judul);
            Console.WriteLine("Tahun : " + Tahun);
        }
    }

    // BUKU
    class Buku : Item
    {
        public string Penulis { get; set; }

        public Buku(string judul, int tahun, string penulis) : base(judul, tahun)
        {
            Penulis = penulis;
        }

        public void CekPenulis()
        {
            Console.WriteLine("Penulis buku ini: " + Penulis);
        }

        public override void Deskripsi()
        {
            Console.WriteLine("Buku '" + Judul + "' (" + Tahun + ") ditulis oleh " + Penulis);
        }
    }

    // ===================== MAJALAH =====================
    class Majalah : Item
    {
        public int Edisi { get; set; }

        public Majalah(string judul, int tahun, int edisi) : base(judul, tahun)
        {
            Edisi = edisi;
        }

        public void InfoEdisi()
        {
            Console.WriteLine("Majalah ini edisi ke-" + Edisi);
        }

        public override void Deskripsi()
        {
            Console.WriteLine("Majalah '" + Judul + "' (" + Tahun + ") edisi " + Edisi);
        }
    }

    // ===================== NOVEL & KOMIK (turunan Buku) =====================
    class Novel : Buku
    {
        public Novel(string judul, int tahun, string penulis) : base(judul, tahun, penulis) { }

        public void BacaSinopsis()
        {
            Console.WriteLine("Sinopsis novel '" + Judul + "': kisah petualangan yang seru.");
        }

        public override void Deskripsi()
        {
            Console.WriteLine("Novel '" + Judul + "' (" + Tahun + ") karya " + Penulis);
        }
    }

    class Komik : Buku
    {
        public Komik(string judul, int tahun, string penulis) : base(judul, tahun, penulis) { }

        public void TampilkanIlustrasi()
        {
            Console.WriteLine("Menampilkan ilustrasi komik '" + Judul + "'...");
        }

        public override void Deskripsi()
        {
            Console.WriteLine("Komik '" + Judul + "' (" + Tahun + ") karya " + Penulis);
        }
    }

    // ===================== MAJALAH ANAK & TEKNOLOGI (turunan Majalah) =====================
    class MajalahAnak : Majalah
    {
        public MajalahAnak(string judul, int tahun, int edisi) : base(judul, tahun, edisi) { }

        public void KategoriAnak()
        {
            Console.WriteLine("Kategori: majalah untuk anak-anak.");
        }

        public override void Deskripsi()
        {
            Console.WriteLine("Majalah Anak '" + Judul + "' (" + Tahun + ") edisi " + Edisi);
        }
    }

    class MajalahTeknologi : Majalah
    {
        public MajalahTeknologi(string judul, int tahun, int edisi) : base(judul, tahun, edisi) { }

        public void TopikTeknologi()
        {
            Console.WriteLine("Topik: gadget, software, dan teknologi terbaru.");
        }

        public override void Deskripsi()
        {
            Console.WriteLine("Majalah Teknologi '" + Judul + "' (" + Tahun + ") edisi " + Edisi);
        }
    }

    // ===================== PERPUSTAKAAN =====================
    class Perpustakaan
    {
        private List<Item> daftarItem = new List<Item>();

        public void TambahItem(Item item)
        {
            daftarItem.Add(item);
            Console.WriteLine("Item '" + item.Judul + "' ditambahkan ke perpustakaan.");
        }

        public void DaftarItem()
        {
            int no = 1;
            foreach (Item item in daftarItem)
            {
                Console.WriteLine("\n" + no + ".");
                item.InfoItem();
                item.Deskripsi();   
                no++;
            }
        }
    }

    // ===================== MAIN =====================
    class Program
    {
        static void Main(string[] args)
        {
            // a. Buat objek perpustakaan
            Perpustakaan perpus = new Perpustakaan();

            // b. Buat beberapa objek item
            Novel novel = new Novel("Laskar Pelangi", 2005, "Andrea Hirata");
            Komik komik = new Komik("Naruto", 2000, "Masashi Kishimoto");
            MajalahAnak majalahAnak = new MajalahAnak("Bobo", 2023, 15);
            MajalahTeknologi majalahTek = new MajalahTeknologi("Tech Today", 2024, 8);
            Majalah majalah = new Majalah("Majalah Umum", 2022, 3);

            // c. Tambahkan ke perpustakaan
            Console.WriteLine("=== TAMBAH ITEM ===");
            perpus.TambahItem(novel);
            perpus.TambahItem(komik);
            perpus.TambahItem(majalahAnak);
            perpus.TambahItem(majalahTek);
            perpus.TambahItem(majalah);

            // d. Tampilkan semua data
            Console.WriteLine("\n=== DAFTAR SEMUA ITEM ===");
            perpus.DaftarItem();

            // e. Demonstrasi polymorphism
            Console.WriteLine("\n=== POLYMORPHISM ===");
            List<Item> semua = new List<Item> { novel, komik, majalahAnak, majalahTek, majalah };
            foreach (Item i in semua)
            {
                i.Deskripsi();   
            }

            // f. Panggil method khusus
            Console.WriteLine("\n=== METHOD KHUSUS ===");
            novel.CekPenulis();
            komik.TampilkanIlustrasi();
            majalah.InfoEdisi();
            majalahAnak.KategoriAnak();
            majalahTek.TopikTeknologi();

            // ---------------- JAWABAN SOAL 1-5 ----------------

            // Soal 1: Deskripsi() pada Novel dan Majalah
            Console.WriteLine("\n=== SOAL 1: Deskripsi() Novel dan Majalah ===");
            novel.Deskripsi();
            majalah.Deskripsi();

            // Soal 2: BacaSinopsis() pada Novel
            Console.WriteLine("\n=== SOAL 2: BacaSinopsis() pada Novel ===");
            novel.BacaSinopsis();

            // Soal 3: Informasi lengkap Novel (judul, tahun, penulis)
            Console.WriteLine("\n=== SOAL 3: Informasi lengkap Novel ===");
            Console.WriteLine("Judul   : " + novel.Judul);
            Console.WriteLine("Tahun   : " + novel.Tahun);
            Console.WriteLine("Penulis : " + novel.Penulis);
            novel.InfoItem();
            novel.Deskripsi();

            // Soal 4: TopikTeknologi() pada MajalahTeknologi
            Console.WriteLine("\n=== SOAL 4: TopikTeknologi() ===");
            majalahTek.TopikTeknologi();

            // Soal 5: variabel bertipe Item diisi objek Komik
            Console.WriteLine("\n=== SOAL 5: Variabel Item berisi Komik ===");
            Item itemKomik = new Komik("One Piece", 1997, "Eiichiro Oda");
            itemKomik.Deskripsi();

            ((Komik)itemKomik).TampilkanIlustrasi();

            Console.ReadLine();
        }
    }
}
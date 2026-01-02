using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.AccessControl;

namespace QLThueThietBiXayDung.DAL
{
    // Entity classes
    public class ChucVu
    {
        [Key]
        public int MaChucVu { get; set; }

        [Required]
        [StringLength(50)]
        public string TenChucVu { get; set; }

        public string MoTa { get; set; }
    }

    public class NhanVien
    {
        [Key]
        public int MaNV { get; set; }

        [Required]
        [StringLength(100)]
        public string HoTen { get; set; }

        public int MaChucVu { get; set; }

        [ForeignKey("MaChucVu")]
        public virtual ChucVu ChucVu { get; set; }

        public DateTime? NgaySinh { get; set; } = DateTime.Now;

        [StringLength(200)]
        public string DiaChi { get; set; }

        [StringLength(15)]
        public string SoDienThoai { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        public DateTime NgayVaoLam { get; set; } = DateTime.Now;

        [StringLength(20)]
        public string TrangThai { get; set; }

        [StringLength(50)]
        [Index(IsUnique = true)]
        public string MaTK { get; set; }

        [Required]
        [StringLength(100)]
        public string MatKhau { get; set; }

        [NotMapped]
        public string TenChucVu
        {
            get
            {
                return ChucVu != null ? ChucVu.TenChucVu : string.Empty;
            }
        }
    }

    public class KhachHang
    {
        [Key]
        public int MaKH { get; set; }

        [Required]
        [StringLength(100)]
        public string HoTen { get; set; }

        [Required]
        [StringLength(200)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(15)]
        public string SoDienThoai { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public string GhiChu { get; set; }
    }

    public class LoaiThietBi
    {
        [Key]
        public int MaLoai { get; set; }

        [Required]
        [StringLength(100)]
        public string TenLoai { get; set; }

        public string MoTa { get; set; }
    }

    public class ThietBi
    {
        [Key]
        public int MaTB { get; set; }

        public int MaLoai { get; set; }

        [ForeignKey("MaLoai")]
        public virtual LoaiThietBi LoaiThietBi { get; set; }

        [Required]
        [StringLength(100)]
        public string TenThietBi { get; set; }

        [StringLength(50)]
        [Index(IsUnique = true)]
        public string SerialNumber { get; set; }

        [Required]
        public decimal GiaThueNgay { get; set; }

        [Required]
        [StringLength(20)]
        public string TrangThai { get; set; }

        public int? SoLuongTonKho { get; set; }

        public string GhiChu { get; set; }

        [NotMapped]
        public string TenLoaiTB 
        {
            get
            {
                return LoaiThietBi != null ? LoaiThietBi.TenLoai : string.Empty;
            }
        }
    }

    public class PhieuNhap
    {
        [Key]
        public int MaPhieuNhap { get; set; }

        public int MaNV { get; set; }

        [ForeignKey("MaNV")]
        public virtual NhanVien NhanVien { get; set; }

        [Required]
        public DateTime NgayNhap { get; set; } = DateTime.Now;

        [StringLength(100)]
        public string NhaCungCap { get; set; }

        public decimal? TongGiaNhap { get; set; }

        [StringLength(20)]
        public string TrangThai { get; set; }

        public string GhiChu { get; set; }

        [NotMapped]
        public string HoTenNVNhap
        {
            get
            {
                return NhanVien != null ? NhanVien.HoTen : string.Empty;
            }
        }

        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; } = new List<ChiTietPhieuNhap>();
    }

    public class ChiTietPhieuNhap
    {
        [Key]
        public int MaChiTietNhap { get; set; }

        public int MaPhieuNhap { get; set; }

        [ForeignKey("MaPhieuNhap")]
        public virtual PhieuNhap PhieuNhap { get; set; }

        public int MaTB { get; set; }

        [ForeignKey("MaTB")]
        public virtual ThietBi ThietBi { get; set; }

        [Required]
        public int SoLuongNhap { get; set; } = 0;

        public decimal? GiaNhap { get; set; } = 0;

        public decimal? ThanhTien { get; set; } = 0;

        public string GhiChu { get; set; }

        private string _tenThietBi = string.Empty;

        [NotMapped]
        public string TenThietBi
        {
            get
            {
                return ThietBi != null ? ThietBi.TenThietBi : _tenThietBi;
            } 
            set
            {
                _tenThietBi = value;
            }
        }
    }

    public class PhieuThue
    {
        [Key]
        public int MaPhieuThue { get; set; }

        public int MaKH { get; set; }

        [ForeignKey("MaKH")]
        public virtual KhachHang KhachHang { get; set; }

        public int MaNV { get; set; }

        [ForeignKey("MaNV")]
        public virtual NhanVien NhanVien { get; set; }

        [Required]
        public DateTime NgayThue { get; set; } = DateTime.Now;

        [Required]
        public DateTime NgayTraDuKien { get; set; } = DateTime.Now;

        public decimal? TongChiPhiDuKien { get; set; } = 0;

        [Required]
        [StringLength(20)]
        public string TrangThai { get; set; }

        public string GhiChu { get; set; }
        
        [NotMapped]
        public string HoTenKH
        {
            get
            {
                return KhachHang != null ? KhachHang.HoTen : string.Empty;
            }
        }

        [NotMapped]
        public string HoTenNV
        {
            get
            {
                return NhanVien != null ? NhanVien.HoTen : string.Empty;
            }
        }

        private string _info = string.Empty;
        [NotMapped]
        public string Info { 
            get {
                if (MaPhieuThue > 0)
                    return string.Format("{3} - phiếu số {0} cho khách {1} mượn ngày {2:dd/MM/yyyy}", MaPhieuThue, HoTenKH, NgayThue, TrangThai);
                else
                    return _info;
            }
            set
            {
                _info = value;
            }
        }
        public virtual ICollection<ChiTietPhieuThue> ChiTietPhieuThues { get; set; } = new List<ChiTietPhieuThue>();
    }

    public class ChiTietPhieuThue
    {
        [Key]
        public int MaChiTietThue { get; set; }

        public int MaPhieuThue { get; set; }

        [ForeignKey("MaPhieuThue")]
        public virtual PhieuThue PhieuThue { get; set; }

        public int MaTB { get; set; }

        [ForeignKey("MaTB")]
        public virtual ThietBi ThietBi { get; set; }

        [Required]
        public int SoLuongThue { get; set; } = 0;

        [Required]
        public decimal GiaThueNgay { get; set; } = 0;

        public decimal? ThanhTienDuKien { get; set; } = 0;

        public string GhiChu { get; set; }

        private string _tenThietBi = string.Empty;

        [NotMapped]        
        public string TenThietBi
        {
            get
            {
                return ThietBi != null ? ThietBi.TenThietBi : _tenThietBi;
            }

            set
            {
                _tenThietBi = value;
            }
        }
    }

    public class PhieuTra
    {
        [Key]
        public int MaPhieuTra { get; set; }

        public int MaPhieuThue { get; set; }

        [ForeignKey("MaPhieuThue")]
        [Index(IsUnique = true)]
        public virtual PhieuThue PhieuThue { get; set; }

        public int MaNV { get; set; }

        [ForeignKey("MaNV")]
        public virtual NhanVien NhanVien { get; set; }

        [Required]
        public DateTime NgayTraThucTe { get; set; }     = DateTime.Now;

        public decimal? TongChiPhiThucTe { get; set; } = 0;

        [StringLength(20)]
        public string TrangThai { get; set; }

        public bool DaThanhToan { get; set; } = false;

        public string GhiChu { get; set; }

        public string HoTenNV 
        {
            get
            {
                return NhanVien != null ? NhanVien.HoTen : string.Empty;
            }
        }

        public virtual ICollection<ChiTietPhieuTra> ChiTietPhieuTras { get; set; } = new List<ChiTietPhieuTra>();
    }

    public class ChiTietPhieuTra
    {
        [Key]
        public int MaChiTietTra { get; set; }

        public int MaPhieuTra { get; set; }

        [ForeignKey("MaPhieuTra")]
        public virtual PhieuTra PhieuTra { get; set; }

        public int MaTB { get; set; }

        [ForeignKey("MaTB")]
        public virtual ThietBi ThietBi { get; set; }

        [Required]
        public int SoLuongTra { get; set; } = 0;

        [StringLength(50)]
        public string TinhTrang { get; set; }

        public decimal? PhatThem { get; set; } = 0;

        public string GhiChu { get; set; }

        private string _tenThietBi = string.Empty;

        [NotMapped]
        public string TenThietBi
        {
            get
            {
                return ThietBi != null ? ThietBi.TenThietBi : _tenThietBi;
            }

            set
            {
                _tenThietBi = value;
            }
        }
    }

    // DBContext class

    public class QLThueThietBiXayDungDBContext : DbContext
    {
        public QLThueThietBiXayDungDBContext() : base("name=QLThueThietBiXayDungDBConnectionString")
        {
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<ChucVu> ChucVus { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<LoaiThietBi> LoaiThietBis { get; set; }
        public DbSet<ThietBi> ThietBis { get; set; }
        public DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public DbSet<PhieuThue> PhieuThues { get; set; }
        public DbSet<ChiTietPhieuThue> ChiTietPhieuThues { get; set; }
        public DbSet<PhieuTra> PhieuTras { get; set; }
        public DbSet<ChiTietPhieuTra> ChiTietPhieuTras { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Configure decimal properties
            modelBuilder.Properties<decimal>().Configure(p => p.HasPrecision(10, 2));

            // ChucVu
            modelBuilder.Entity<ChucVu>()
                .Property(e => e.TenChucVu)
                .IsRequired()
                .HasMaxLength(50);

            // NhanVien
            modelBuilder.Entity<NhanVien>()
                .Property(e => e.HoTen)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.NgayVaoLam)
                .IsRequired();

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.TrangThai)
                .HasMaxLength(20);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaTK)
                .HasMaxLength(50);

            modelBuilder.Entity<NhanVien>()
                .HasIndex(e => e.MaTK)
                .IsUnique();

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MatKhau)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<NhanVien>()
                .HasRequired(e => e.ChucVu)
                .WithMany()
                .HasForeignKey(e => e.MaChucVu);

            // KhachHang
            modelBuilder.Entity<KhachHang>()
                .Property(e => e.HoTen)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.DiaChi)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SoDienThoai)
                .IsRequired()
                .HasMaxLength(15);

            // LoaiThietBi
            modelBuilder.Entity<LoaiThietBi>()
                .Property(e => e.TenLoai)
                .IsRequired()
                .HasMaxLength(100);

            // ThietBi
            modelBuilder.Entity<ThietBi>()
                .Property(e => e.TenThietBi)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<ThietBi>()
                .Property(e => e.SerialNumber)
                .HasMaxLength(50);

            modelBuilder.Entity<ThietBi>()
                .HasIndex(e => e.SerialNumber)
                .IsUnique();

            modelBuilder.Entity<ThietBi>()
                .Property(e => e.GiaThueNgay)
                .IsRequired();

            modelBuilder.Entity<ThietBi>()
                .Property(e => e.TrangThai)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<ThietBi>()
                .HasRequired(e => e.LoaiThietBi)
                .WithMany()
                .HasForeignKey(e => e.MaLoai);

            // PhieuNhap
            modelBuilder.Entity<PhieuNhap>()
                .Property(e => e.NgayNhap)
                .IsRequired();

            modelBuilder.Entity<PhieuNhap>()
                .Property(e => e.TrangThai)
                .HasMaxLength(20);

            modelBuilder.Entity<PhieuNhap>()
                .HasRequired(e => e.NhanVien)
                .WithMany()
                .HasForeignKey(e => e.MaNV);

            modelBuilder.Entity<PhieuNhap>()
                .HasMany(e => e.ChiTietPhieuNhaps)
                .WithRequired(e => e.PhieuNhap)
                .HasForeignKey(e => e.MaPhieuNhap);

            // ChiTietPhieuNhap
            modelBuilder.Entity<ChiTietPhieuNhap>()
                .Property(e => e.SoLuongNhap)
                .IsRequired();

            modelBuilder.Entity<ChiTietPhieuNhap>()
                .HasRequired(e => e.ThietBi)
                .WithMany()
                .HasForeignKey(e => e.MaTB);

            // PhieuThue
            modelBuilder.Entity<PhieuThue>()
                .Property(e => e.NgayThue)
                .IsRequired();

            modelBuilder.Entity<PhieuThue>()
                .Property(e => e.NgayTraDuKien)
                .IsRequired();

            modelBuilder.Entity<PhieuThue>()
                .Property(e => e.TrangThai)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<PhieuThue>()
                .HasRequired(e => e.KhachHang)
                .WithMany()
                .HasForeignKey(e => e.MaKH);

            modelBuilder.Entity<PhieuThue>()
                .HasRequired(e => e.NhanVien)
                .WithMany()
                .HasForeignKey(e => e.MaNV);

            modelBuilder.Entity<PhieuThue>()
                .HasMany(e => e.ChiTietPhieuThues)
                .WithRequired(e => e.PhieuThue)
                .HasForeignKey(e => e.MaPhieuThue);

            // ChiTietPhieuThue
            modelBuilder.Entity<ChiTietPhieuThue>()
                .Property(e => e.SoLuongThue)
                .IsRequired();

            modelBuilder.Entity<ChiTietPhieuThue>()
                .Property(e => e.GiaThueNgay)
                .IsRequired();

            modelBuilder.Entity<ChiTietPhieuThue>()
                .HasRequired(e => e.ThietBi)
                .WithMany()
                .HasForeignKey(e => e.MaTB);

            // PhieuTra
            modelBuilder.Entity<PhieuTra>()
                .Property(e => e.NgayTraThucTe)
                .IsRequired();

            modelBuilder.Entity<PhieuTra>()
                .Property(e => e.TrangThai)
                .HasMaxLength(20);

            modelBuilder.Entity<PhieuTra>()
                .HasRequired(e => e.PhieuThue)
                .WithMany()
                .HasForeignKey(e => e.MaPhieuThue)
                .WillCascadeOnDelete(false); // Avoid cascade delete if needed

            modelBuilder.Entity<PhieuTra>()
                .HasIndex(e => e.MaPhieuThue)
                .IsUnique();

            modelBuilder.Entity<PhieuTra>()
                .HasRequired(e => e.NhanVien)
                .WithMany()
                .HasForeignKey(e => e.MaNV);

            modelBuilder.Entity<PhieuTra>()
                .HasMany(e => e.ChiTietPhieuTras)
                .WithRequired(e => e.PhieuTra)
                .HasForeignKey(e => e.MaPhieuTra);

            // ChiTietPhieuTra
            modelBuilder.Entity<ChiTietPhieuTra>()
                .Property(e => e.SoLuongTra)
                .IsRequired();

            modelBuilder.Entity<ChiTietPhieuTra>()
                .Property(e => e.TinhTrang)
                .HasMaxLength(50);

            modelBuilder.Entity<ChiTietPhieuTra>()
                .HasRequired(e => e.ThietBi)
                .WithMany()
                .HasForeignKey(e => e.MaTB);

            base.OnModelCreating(modelBuilder);
        }
    }
}


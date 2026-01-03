USE master
GO
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'QLThueThietBiXayDungDB')
BEGIN
    ALTER DATABASE [QLThueThietBiXayDungDB] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [QLThueThietBiXayDungDB];
END
GO
CREATE DATABASE [QLThueThietBiXayDungDB]
GO
USE [QLThueThietBiXayDungDB]
GO
/****** Object:  Table [dbo].[ChiTietPhieuNhap]    Script Date: 12/26/2025 23:06:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ChiTietPhieuNhap]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ChiTietPhieuNhap](
	[MaChiTietNhap] [int] IDENTITY(1,1) NOT NULL,
	[MaPhieuNhap] [int] NOT NULL,
	[MaTB] [int] NOT NULL,
	[SoLuongNhap] [int] NOT NULL,
	[GiaNhap] [decimal](10, 2) NULL,
	[ThanhTien] [decimal](10, 2) NULL,
	[GhiChu] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChiTietNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ChiTietPhieuThue]    Script Date: 12/26/2025 23:06:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ChiTietPhieuThue]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ChiTietPhieuThue](
	[MaChiTietThue] [int] IDENTITY(1,1) NOT NULL,
	[MaPhieuThue] [int] NOT NULL,
	[MaTB] [int] NOT NULL,
	[SoLuongThue] [int] NOT NULL,
	[GiaThueNgay] [decimal](10, 2) NOT NULL,
	[ThanhTienDuKien] [decimal](10, 2) NULL,
	[GhiChu] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChiTietThue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ChiTietPhieuTra]    Script Date: 12/26/2025 23:06:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ChiTietPhieuTra]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ChiTietPhieuTra](
	[MaChiTietTra] [int] IDENTITY(1,1) NOT NULL,
	[MaPhieuTra] [int] NOT NULL,
	[MaTB] [int] NOT NULL,
	[SoLuongTra] [int] NOT NULL,
	[TinhTrang] [nvarchar](50) NULL,
	[PhatThem] [decimal](10, 2) NULL,
	[GhiChu] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChiTietTra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 12/26/2025 23:06:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ChucVu]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ChucVu](
	[MaChucVu] [int] IDENTITY(1,1) NOT NULL,
	[TenChucVu] [nvarchar](50) NOT NULL,
	[MoTa] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChucVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 12/26/2025 23:06:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KhachHang]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](100) NOT NULL,
	[DiaChi] [nvarchar](200) NOT NULL,
	[SoDienThoai] [nvarchar](15) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[GhiChu] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[LoaiThietBi]    Script Date: 12/26/2025 23:06:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LoaiThietBi]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LoaiThietBi](
	[MaLoai] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](100) NOT NULL,
	[MoTa] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 12/26/2025 23:06:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NhanVien]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](100) NOT NULL,
	[MaChucVu] [int] NOT NULL,
	[NgaySinh] [date] NULL,
	[DiaChi] [nvarchar](200) NULL,
	[SoDienThoai] [nvarchar](15) NULL,
	[Email] [nvarchar](100) NULL,
	[NgayVaoLam] [date] NOT NULL,
	[TrangThai] [nvarchar](20) NULL,
	[MaTK] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 12/26/2025 23:06:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PhieuNhap]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PhieuNhap](
	[MaPhieuNhap] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [int] NOT NULL,
	[NgayNhap] [date] NOT NULL,
	[NhaCungCap] [nvarchar](100) NULL,
	[TongGiaNhap] [decimal](10, 2) NULL,
	[TrangThai] [nvarchar](20) NULL,
	[GhiChu] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieuNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[PhieuThue]    Script Date: 12/26/2025 23:06:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PhieuThue]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PhieuThue](
	[MaPhieuThue] [int] IDENTITY(1,1) NOT NULL,
	[MaKH] [int] NOT NULL,
	[MaNV] [int] NOT NULL,
	[NgayThue] [date] NOT NULL,
	[NgayTraDuKien] [date] NOT NULL,
	[TongChiPhiDuKien] [decimal](10, 2) NULL,
	[TrangThai] [nvarchar](20) NOT NULL,
	[GhiChu] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieuThue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[PhieuTra]    Script Date: 12/26/2025 23:06:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PhieuTra]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PhieuTra](
	[MaPhieuTra] [int] IDENTITY(1,1) NOT NULL,
	[MaPhieuThue] [int] NOT NULL,
	[MaNV] [int] NOT NULL,
	[NgayTraThucTe] [date] NOT NULL,
	[TongChiPhiThucTe] [decimal](10, 2) NULL,
	[TrangThai] [nvarchar](20) NULL,
	[GhiChu] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieuTra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ThietBi]    Script Date: 12/26/2025 23:06:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ThietBi]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ThietBi](
	[MaTB] [int] IDENTITY(1,1) NOT NULL,
	[MaLoai] [int] NOT NULL,
	[TenThietBi] [nvarchar](100) NOT NULL,
	[SerialNumber] [nvarchar](50) NULL,
	[GiaThueNgay] [decimal](10, 2) NOT NULL,
	[TrangThai] [nvarchar](20) NOT NULL,
	[SoLuongTonKho] [int] NULL,
	[GhiChu] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

-- Xóa dữ liệu cũ nếu muốn nhập lại từ đầu hoặc chỉ nhập nếu bảng rỗng
-- Ở đây mình sẽ chỉ chèn lệnh INSERT, nếu trùng ID (table cóIDENTITY_INSERT ON) thì có thể lỗi nếu ID đã tồn tại
-- Để an toàn, chúng ta cũng có thể check exist, nhưng với IDENTITY_INSERT chúng ta không thể check đơn giản trong VALUES.
-- Cách tốt nhất là xóa sạch bảng rồi insert, hoặc để nguyên nếu bảng đã có dữ liệu.
-- Tuy nhiên user script có vẻ là script backup đầy đủ.

SET IDENTITY_INSERT [dbo].[ChucVu] ON 
IF NOT EXISTS(SELECT 1 FROM [dbo].[ChucVu] WHERE [MaChucVu] = 1) INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [MoTa]) VALUES (1, N'Quản lý', N'Quản lý tổng thể hệ thống')
IF NOT EXISTS(SELECT 1 FROM [dbo].[ChucVu] WHERE [MaChucVu] = 2) INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [MoTa]) VALUES (2, N'Nhân viên kho', N'Quản lý kho thiết bị')
IF NOT EXISTS(SELECT 1 FROM [dbo].[ChucVu] WHERE [MaChucVu] = 3) INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [MoTa]) VALUES (3, N'Kế toán', N'Quản lý tài chính và hóa đơn')
IF NOT EXISTS(SELECT 1 FROM [dbo].[ChucVu] WHERE [MaChucVu] = 4) INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [MoTa]) VALUES (4, N'Nhân viên bán hàng', N'Xử lý giao dịch với khách hàng')
IF NOT EXISTS(SELECT 1 FROM [dbo].[ChucVu] WHERE [MaChucVu] = 5) INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [MoTa]) VALUES (5, N'Kỹ thuật viên', N'Bảo dưỡng thiết bị')
SET IDENTITY_INSERT [dbo].[ChucVu] OFF
GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON 
IF NOT EXISTS(SELECT 1 FROM [dbo].[KhachHang] WHERE [MaKH] = 1) INSERT [dbo].[KhachHang] ([MaKH], [HoTen], [DiaChi], [SoDienThoai], [Email], [GhiChu]) VALUES (1, N'Công ty Xây dựng XYZ', N'100 Đường 1, TP.HCM', N'0901234567', N'xyz@congty.com', N'Khách hàng lớn, công trình cao tầng')
IF NOT EXISTS(SELECT 1 FROM [dbo].[KhachHang] WHERE [MaKH] = 2) INSERT [dbo].[KhachHang] ([MaKH], [HoTen], [DiaChi], [SoDienThoai], [Email], [GhiChu]) VALUES (2, N'Cá nhân Ông D', N'200 Đường 2, Hà Nội', N'0912345678', N'ongd@gmail.com', N'Thuê lẻ thiết bị')
IF NOT EXISTS(SELECT 1 FROM [dbo].[KhachHang] WHERE [MaKH] = 3) INSERT [dbo].[KhachHang] ([MaKH], [HoTen], [DiaChi], [SoDienThoai], [Email], [GhiChu]) VALUES (3, N'Công ty ABC', N'300 Đường 3, Đà Nẵng', N'0923456789', N'abc@congty.com', N'Khách hàng thường xuyên')
IF NOT EXISTS(SELECT 1 FROM [dbo].[KhachHang] WHERE [MaKH] = 4) INSERT [dbo].[KhachHang] ([MaKH], [HoTen], [DiaChi], [SoDienThoai], [Email], [GhiChu]) VALUES (4, N'Công ty DEF', N'400 Đường 4, TP.HCM', N'0934567890', N'def@congty.com', N'Khách hàng mới')
IF NOT EXISTS(SELECT 1 FROM [dbo].[KhachHang] WHERE [MaKH] = 5) INSERT [dbo].[KhachHang] ([MaKH], [HoTen], [DiaChi], [SoDienThoai], [Email], [GhiChu]) VALUES (5, N'Cá nhân Bà E', N'500 Đường 5, Hà Nội', N'0945678901', N'bae@gmail.com', N'Thuê thiết bị xây dựng nhỏ')
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
GO
SET IDENTITY_INSERT [dbo].[LoaiThietBi] ON 
IF NOT EXISTS(SELECT 1 FROM [dbo].[LoaiThietBi] WHERE [MaLoai] = 1) INSERT [dbo].[LoaiThietBi] ([MaLoai], [TenLoai], [MoTa]) VALUES (1, N'Giàn giáo', N'Thiết bị hỗ trợ xây dựng cao tầng')
IF NOT EXISTS(SELECT 1 FROM [dbo].[LoaiThietBi] WHERE [MaLoai] = 2) INSERT [dbo].[LoaiThietBi] ([MaLoai], [TenLoai], [MoTa]) VALUES (2, N'Coffa', N'Khuôn đúc bê tông')
IF NOT EXISTS(SELECT 1 FROM [dbo].[LoaiThietBi] WHERE [MaLoai] = 3) INSERT [dbo].[LoaiThietBi] ([MaLoai], [TenLoai], [MoTa]) VALUES (3, N'Lu', N'Máy lu đường')
IF NOT EXISTS(SELECT 1 FROM [dbo].[LoaiThietBi] WHERE [MaLoai] = 4) INSERT [dbo].[LoaiThietBi] ([MaLoai], [TenLoai], [MoTa]) VALUES (4, N'Cối trộn', N'Máy trộn bê tông')
IF NOT EXISTS(SELECT 1 FROM [dbo].[LoaiThietBi] WHERE [MaLoai] = 5) INSERT [dbo].[LoaiThietBi] ([MaLoai], [TenLoai], [MoTa]) VALUES (5, N'Máy cắt', N'Máy cắt vật liệu xây dựng')
SET IDENTITY_INSERT [dbo].[LoaiThietBi] OFF
GO
SET IDENTITY_INSERT [dbo].[NhanVien] ON 
IF NOT EXISTS(SELECT 1 FROM [dbo].[NhanVien] WHERE [MaNV] = 1) INSERT [dbo].[NhanVien] ([MaNV], [HoTen], [MaChucVu], [NgaySinh], [DiaChi], [SoDienThoai], [Email], [NgayVaoLam], [TrangThai], [MaTK], [MatKhau]) VALUES (1, N'Nguyễn Văn A', 1, CAST(N'2025-12-01' AS Date), N'123 Đường ABC, TP.HCM', N'0123456789', N'vana@example.com', CAST(N'2025-12-02' AS Date), N'Hoạt động', N'tk001', N'123')
IF NOT EXISTS(SELECT 1 FROM [dbo].[NhanVien] WHERE [MaNV] = 2) INSERT [dbo].[NhanVien] ([MaNV], [HoTen], [MaChucVu], [NgaySinh], [DiaChi], [SoDienThoai], [Email], [NgayVaoLam], [TrangThai], [MaTK], [MatKhau]) VALUES (2, N'Trần Thị B', 2, CAST(N'2025-12-03' AS Date), N'456 Đường DEF, Hà Nội', N'0987654321', N'thib@example.com', CAST(N'2025-12-04' AS Date), N'Hoạt động', N'tk002', N'123')
IF NOT EXISTS(SELECT 1 FROM [dbo].[NhanVien] WHERE [MaNV] = 3) INSERT [dbo].[NhanVien] ([MaNV], [HoTen], [MaChucVu], [NgaySinh], [DiaChi], [SoDienThoai], [Email], [NgayVaoLam], [TrangThai], [MaTK], [MatKhau]) VALUES (3, N'Lê Văn C', 3, CAST(N'2025-12-05' AS Date), N'789 Đường GHI, Đà Nẵng', N'0112233445', N'vanc@example.com', CAST(N'2025-12-06' AS Date), N'Hoạt động', N'tk003', N'123')
IF NOT EXISTS(SELECT 1 FROM [dbo].[NhanVien] WHERE [MaNV] = 4) INSERT [dbo].[NhanVien] ([MaNV], [HoTen], [MaChucVu], [NgaySinh], [DiaChi], [SoDienThoai], [Email], [NgayVaoLam], [TrangThai], [MaTK], [MatKhau]) VALUES (4, N'Phạm Thị D', 4, CAST(N'2025-12-07' AS Date), N'101 Đường JKL, TP.HCM', N'0934567890', N'thid@example.com', CAST(N'2025-12-08' AS Date), N'Hoạt động', N'tk004', N'123')
IF NOT EXISTS(SELECT 1 FROM [dbo].[NhanVien] WHERE [MaNV] = 5) INSERT [dbo].[NhanVien] ([MaNV], [HoTen], [MaChucVu], [NgaySinh], [DiaChi], [SoDienThoai], [Email], [NgayVaoLam], [TrangThai], [MaTK], [MatKhau]) VALUES (5, N'Hoàng Văn E', 5, CAST(N'2025-12-09' AS Date), N'202 Đường MNO, Hà Nội', N'0945678901', N'vane@example.com', CAST(N'2025-12-10' AS Date), N'Hoạt động', N'tk005', N'123')
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
GO
SET IDENTITY_INSERT [dbo].[PhieuNhap] ON 
IF NOT EXISTS(SELECT 1 FROM [dbo].[PhieuNhap] WHERE [MaPhieuNhap] = 1) INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNV], [NgayNhap], [NhaCungCap], [TongGiaNhap], [TrangThai], [GhiChu]) VALUES (1, 1, CAST(N'2025-12-01' AS Date), N'Nhà cung cấp A 1', CAST(79250000.00 AS Decimal(10, 2)), N'Hoàn thành', N'Nhập lô mới 1')
IF NOT EXISTS(SELECT 1 FROM [dbo].[PhieuNhap] WHERE [MaPhieuNhap] = 2) INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNV], [NgayNhap], [NhaCungCap], [TongGiaNhap], [TrangThai], [GhiChu]) VALUES (2, 2, CAST(N'2025-12-05' AS Date), N'Nhà cung cấp B', CAST(4000000.00 AS Decimal(10, 2)), N'Hoàn thành', N'Nhập bổ sung')
IF NOT EXISTS(SELECT 1 FROM [dbo].[PhieuNhap] WHERE [MaPhieuNhap] = 3) INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNV], [NgayNhap], [NhaCungCap], [TongGiaNhap], [TrangThai], [GhiChu]) VALUES (3, 3, CAST(N'2025-12-10' AS Date), N'Nhà cung cấp C', CAST(40000000.00 AS Decimal(10, 2)), N'Hoàn thành', N'Nhập thiết bị mới')
IF NOT EXISTS(SELECT 1 FROM [dbo].[PhieuNhap] WHERE [MaPhieuNhap] = 4) INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNV], [NgayNhap], [NhaCungCap], [TongGiaNhap], [TrangThai], [GhiChu]) VALUES (4, 4, CAST(N'2025-12-15' AS Date), N'Nhà cung cấp D', CAST(40000000.00 AS Decimal(10, 2)), N'Hoàn thành', N'Nhập lô lớn')
IF NOT EXISTS(SELECT 1 FROM [dbo].[PhieuNhap] WHERE [MaPhieuNhap] = 5) INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNV], [NgayNhap], [NhaCungCap], [TongGiaNhap], [TrangThai], [GhiChu]) VALUES (5, 5, CAST(N'2025-12-20' AS Date), N'Nhà cung cấp E', CAST(4500000.00 AS Decimal(10, 2)), N'Hoàn thành', N'Nhập cuối tháng')
IF NOT EXISTS(SELECT 1 FROM [dbo].[PhieuNhap] WHERE [MaPhieuNhap] = 11) INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNV], [NgayNhap], [NhaCungCap], [TongGiaNhap], [TrangThai], [GhiChu]) VALUES (11, 1, CAST(N'2025-06-15' AS Date), N'df', CAST(682332.00 AS Decimal(10, 2)), N'Hoàn thành', N'fdf')
SET IDENTITY_INSERT [dbo].[PhieuNhap] OFF
GO
SET IDENTITY_INSERT [dbo].[PhieuThue] ON 
IF NOT EXISTS(SELECT 1 FROM [dbo].[PhieuThue] WHERE [MaPhieuThue] = 1) INSERT [dbo].[PhieuThue] ([MaPhieuThue], [MaKH], [MaNV], [NgayThue], [NgayTraDuKien], [TongChiPhiDuKien], [TrangThai], [GhiChu]) VALUES (1, 1, 1, CAST(N'2025-12-02' AS Date), CAST(N'2025-12-10' AS Date), CAST(3200000.00 AS Decimal(10, 2)), N'Đã trả', N'Thuê cho công trình lớn')
IF NOT EXISTS(SELECT 1 FROM [dbo].[PhieuThue] WHERE [MaPhieuThue] = 2) INSERT [dbo].[PhieuThue] ([MaPhieuThue], [MaKH], [MaNV], [NgayThue], [NgayTraDuKien], [TongChiPhiDuKien], [TrangThai], [GhiChu]) VALUES (2, 2, 2, CAST(N'2025-12-04' AS Date), CAST(N'2025-12-12' AS Date), CAST(2400000.00 AS Decimal(10, 2)), N'Đã trả', N'Thuê lẻ')
IF NOT EXISTS(SELECT 1 FROM [dbo].[PhieuThue] WHERE [MaPhieuThue] = 3) INSERT [dbo].[PhieuThue] ([MaPhieuThue], [MaKH], [MaNV], [NgayThue], [NgayTraDuKien], [TongChiPhiDuKien], [TrangThai], [GhiChu]) VALUES (3, 3, 3, CAST(N'2025-12-06' AS Date), CAST(N'2025-12-14' AS Date), CAST(1600000.00 AS Decimal(10, 2)), N'Đã trả', N'Thuê thường xuyên')
IF NOT EXISTS(SELECT 1 FROM [dbo].[PhieuThue] WHERE [MaPhieuThue] = 4) INSERT [dbo].[PhieuThue] ([MaPhieuThue], [MaKH], [MaNV], [NgayThue], [NgayTraDuKien], [TongChiPhiDuKien], [TrangThai], [GhiChu]) VALUES (4, 4, 4, CAST(N'2025-12-08' AS Date), CAST(N'2025-12-16' AS Date), CAST(1680000.00 AS Decimal(10, 2)), N'Đã trả', N'Thuê mới')
IF NOT EXISTS(SELECT 1 FROM [dbo].[PhieuThue] WHERE [MaPhieuThue] = 5) INSERT [dbo].[PhieuThue] ([MaPhieuThue], [MaKH], [MaNV], [NgayThue], [NgayTraDuKien], [TongChiPhiDuKien], [TrangThai], [GhiChu]) VALUES (5, 5, 5, CAST(N'2025-12-10' AS Date), CAST(N'2025-12-18' AS Date), CAST(2240000.00 AS Decimal(10, 2)), N'Đã trả', N'Thuê nhỏ')
IF NOT EXISTS(SELECT 1 FROM [dbo].[PhieuThue] WHERE [MaPhieuThue] = 8) INSERT [dbo].[PhieuThue] ([MaPhieuThue], [MaKH], [MaNV], [NgayThue], [NgayTraDuKien], [TongChiPhiDuKien], [TrangThai], [GhiChu]) VALUES (8, 1, 1, CAST(N'2025-12-26' AS Date), CAST(N'2026-01-02' AS Date), CAST(560000.00 AS Decimal(10, 2)), N'Đã trả', N'dfdf')
SET IDENTITY_INSERT [dbo].[PhieuThue] OFF
GO
SET IDENTITY_INSERT [dbo].[PhieuTra] ON 
IF NOT EXISTS(SELECT 1 FROM [dbo].[PhieuTra] WHERE [MaPhieuTra] = 1) INSERT [dbo].[PhieuTra] ([MaPhieuTra], [MaPhieuThue], [MaNV], [NgayTraThucTe], [TongChiPhiThucTe], [TrangThai], [GhiChu]) VALUES (1, 1, 1, CAST(N'2025-12-11' AS Date), CAST(3200000.00 AS Decimal(10, 2)), N'Hoàn thành', N'Trả muộn 1 ngày')
IF NOT EXISTS(SELECT 1 FROM [dbo].[PhieuTra] WHERE [MaPhieuTra] = 2) INSERT [dbo].[PhieuTra] ([MaPhieuTra], [MaPhieuThue], [MaNV], [NgayTraThucTe], [TongChiPhiThucTe], [TrangThai], [GhiChu]) VALUES (2, 2, 2, CAST(N'2025-12-13' AS Date), CAST(2900000.00 AS Decimal(10, 2)), N'Hoàn thành', N'Trả đúng hạn')
IF NOT EXISTS(SELECT 1 FROM [dbo].[PhieuTra] WHERE [MaPhieuTra] = 3) INSERT [dbo].[PhieuTra] ([MaPhieuTra], [MaPhieuThue], [MaNV], [NgayTraThucTe], [TongChiPhiThucTe], [TrangThai], [GhiChu]) VALUES (3, 3, 3, CAST(N'2025-12-15' AS Date), CAST(1600000.00 AS Decimal(10, 2)), N'Hoàn thành', N'Trả sớm')
IF NOT EXISTS(SELECT 1 FROM [dbo].[PhieuTra] WHERE [MaPhieuTra] = 4) INSERT [dbo].[PhieuTra] ([MaPhieuTra], [MaPhieuThue], [MaNV], [NgayTraThucTe], [TongChiPhiThucTe], [TrangThai], [GhiChu]) VALUES (4, 4, 4, CAST(N'2025-12-17' AS Date), CAST(1680000.00 AS Decimal(10, 2)), N'Hoàn thành', N'Trả muộn')
IF NOT EXISTS(SELECT 1 FROM [dbo].[PhieuTra] WHERE [MaPhieuTra] = 5) INSERT [dbo].[PhieuTra] ([MaPhieuTra], [MaPhieuThue], [MaNV], [NgayTraThucTe], [TongChiPhiThucTe], [TrangThai], [GhiChu]) VALUES (5, 5, 5, CAST(N'2025-12-19' AS Date), CAST(2440000.00 AS Decimal(10, 2)), N'Hoàn thành', N'Trả đúng')
IF NOT EXISTS(SELECT 1 FROM [dbo].[PhieuTra] WHERE [MaPhieuTra] = 6) INSERT [dbo].[PhieuTra] ([MaPhieuTra], [MaPhieuThue], [MaNV], [NgayTraThucTe], [TongChiPhiThucTe], [TrangThai], [GhiChu]) VALUES (6, 8, 1, CAST(N'2025-12-26' AS Date), CAST(595000.00 AS Decimal(10, 2)), N'Hoàn thành', N'dfdf')
SET IDENTITY_INSERT [dbo].[PhieuTra] OFF
GO
SET IDENTITY_INSERT [dbo].[ThietBi] ON 
IF NOT EXISTS(SELECT 1 FROM [dbo].[ThietBi] WHERE [MaTB] = 1) INSERT [dbo].[ThietBi] ([MaTB], [MaLoai], [TenThietBi], [SerialNumber], [GiaThueNgay], [TrangThai], [SoLuongTonKho], [GhiChu]) VALUES (1, 1, N'Giàn giáo sắt 2m', N'GG001', CAST(50000.00 AS Decimal(10, 2)), N'Sẵn sàng', 70, N'Mới nhập')
IF NOT EXISTS(SELECT 1 FROM [dbo].[ThietBi] WHERE [MaTB] = 2) INSERT [dbo].[ThietBi] ([MaTB], [MaLoai], [TenThietBi], [SerialNumber], [GiaThueNgay], [TrangThai], [SoLuongTonKho], [GhiChu]) VALUES (2, 2, N'Coffa gỗ 1x2m', N'CF001', CAST(30000.00 AS Decimal(10, 2)), N'Sẵn sàng', 925, N'Chất lượng cao')
IF NOT EXISTS(SELECT 1 FROM [dbo].[ThietBi] WHERE [MaTB] = 3) INSERT [dbo].[ThietBi] ([MaTB], [MaLoai], [TenThietBi], [SerialNumber], [GiaThueNgay], [TrangThai], [SoLuongTonKho], [GhiChu]) VALUES (3, 3, N'Lu rung 5 tấn', N'LU001', CAST(100000.00 AS Decimal(10, 2)), N'Sẵn sàng', 4, N'Máy nặng')
IF NOT EXISTS(SELECT 1 FROM [dbo].[ThietBi] WHERE [MaTB] = 4) INSERT [dbo].[ThietBi] ([MaTB], [MaLoai], [TenThietBi], [SerialNumber], [GiaThueNgay], [TrangThai], [SoLuongTonKho], [GhiChu]) VALUES (4, 4, N'Cối trộn 500L', N'CT001', CAST(70000.00 AS Decimal(10, 2)), N'Sẵn sàng', 8, N'Điện 220V')
IF NOT EXISTS(SELECT 1 FROM [dbo].[ThietBi] WHERE [MaTB] = 5) INSERT [dbo].[ThietBi] ([MaTB], [MaLoai], [TenThietBi], [SerialNumber], [GiaThueNgay], [TrangThai], [SoLuongTonKho], [GhiChu]) VALUES (5, 5, N'Máy cắt bê tông', N'MC001', CAST(40000.00 AS Decimal(10, 2)), N'Sẵn sàng', 15, N'Công suất cao')
SET IDENTITY_INSERT [dbo].[ThietBi] OFF
GO
SET IDENTITY_INSERT [dbo].[ChiTietPhieuNhap] ON 
IF NOT EXISTS(SELECT 1 FROM [dbo].[ChiTietPhieuNhap] WHERE [MaChiTietNhap] = 2) INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietNhap], [MaPhieuNhap], [MaTB], [SoLuongNhap], [GiaNhap], [ThanhTien], [GhiChu]) VALUES (2, 2, 2, 20, CAST(200000.00 AS Decimal(10, 2)), CAST(4000000.00 AS Decimal(10, 2)), N'Lô coffa')
IF NOT EXISTS(SELECT 1 FROM [dbo].[ChiTietPhieuNhap] WHERE [MaChiTietNhap] = 3) INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietNhap], [MaPhieuNhap], [MaTB], [SoLuongNhap], [GiaNhap], [ThanhTien], [GhiChu]) VALUES (3, 3, 3, 5, CAST(8000000.00 AS Decimal(10, 2)), CAST(40000000.00 AS Decimal(10, 2)), N'Lô lu')
IF NOT EXISTS(SELECT 1 FROM [dbo].[ChiTietPhieuNhap] WHERE [MaChiTietNhap] = 4) INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietNhap], [MaPhieuNhap], [MaTB], [SoLuongNhap], [GiaNhap], [ThanhTien], [GhiChu]) VALUES (4, 4, 4, 8, CAST(5000000.00 AS Decimal(10, 2)), CAST(40000000.00 AS Decimal(10, 2)), N'Lô cối trộn')
IF NOT EXISTS(SELECT 1 FROM [dbo].[ChiTietPhieuNhap] WHERE [MaChiTietNhap] = 5) INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietNhap], [MaPhieuNhap], [MaTB], [SoLuongNhap], [GiaNhap], [ThanhTien], [GhiChu]) VALUES (5, 5, 5, 15, CAST(300000.00 AS Decimal(10, 2)), CAST(4500000.00 AS Decimal(10, 2)), N'Lô máy cắt')
IF NOT EXISTS(SELECT 1 FROM [dbo].[ChiTietPhieuNhap] WHERE [MaChiTietNhap] = 19) INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietNhap], [MaPhieuNhap], [MaTB], [SoLuongNhap], [GiaNhap], [ThanhTien], [GhiChu]) VALUES (19, 1, 1, 10, CAST(400000.00 AS Decimal(10, 2)), CAST(4000000.00 AS Decimal(10, 2)), N'Lô giàn giáo')
IF NOT EXISTS(SELECT 1 FROM [dbo].[ChiTietPhieuNhap] WHERE [MaChiTietNhap] = 20) INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietNhap], [MaPhieuNhap], [MaTB], [SoLuongNhap], [GiaNhap], [ThanhTien], [GhiChu]) VALUES (20, 1, 2, 301, CAST(250000.00 AS Decimal(10, 2)), CAST(75250000.00 AS Decimal(10, 2)), N'')
IF NOT EXISTS(SELECT 1 FROM [dbo].[ChiTietPhieuNhap] WHERE [MaChiTietNhap] = 31) INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietNhap], [MaPhieuNhap], [MaTB], [SoLuongNhap], [GiaNhap], [ThanhTien], [GhiChu]) VALUES (31, 11, 1, 1, CAST(256666.00 AS Decimal(10, 2)), CAST(256666.00 AS Decimal(10, 2)), N'')
IF NOT EXISTS(SELECT 1 FROM [dbo].[ChiTietPhieuNhap] WHERE [MaChiTietNhap] = 32) INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietNhap], [MaPhieuNhap], [MaTB], [SoLuongNhap], [GiaNhap], [ThanhTien], [GhiChu]) VALUES (32, 11, 2, 1, CAST(425666.00 AS Decimal(10, 2)), CAST(425666.00 AS Decimal(10, 2)), N'')
SET IDENTITY_INSERT [dbo].[ChiTietPhieuNhap] OFF
GO
SET IDENTITY_INSERT [dbo].[ChiTietPhieuThue] ON 
IF NOT EXISTS(SELECT 1 FROM [dbo].[ChiTietPhieuThue] WHERE [MaChiTietThue] = 17) INSERT [dbo].[ChiTietPhieuThue] ([MaChiTietThue], [MaPhieuThue], [MaTB], [SoLuongThue], [GiaThueNgay], [ThanhTienDuKien], [GhiChu]) VALUES (17, 1, 1, 6, CAST(50000.00 AS Decimal(10, 2)), CAST(2400000.00 AS Decimal(10, 2)), N'Thuê giàn giáo')
IF NOT EXISTS(SELECT 1 FROM [dbo].[ChiTietPhieuThue] WHERE [MaChiTietThue] = 18) INSERT [dbo].[ChiTietPhieuThue] ([MaChiTietThue], [MaPhieuThue], [MaTB], [SoLuongThue], [GiaThueNgay], [ThanhTienDuKien], [GhiChu]) VALUES (18, 1, 2, 1, CAST(30000.00 AS Decimal(10, 2)), CAST(240000.00 AS Decimal(10, 2)), N'Thuê mới')
IF NOT EXISTS(SELECT 1 FROM [dbo].[ChiTietPhieuThue] WHERE [MaChiTietThue] = 19) INSERT [dbo].[ChiTietPhieuThue] ([MaChiTietThue], [MaPhieuThue], [MaTB], [SoLuongThue], [GiaThueNgay], [ThanhTienDuKien], [GhiChu]) VALUES (19, 1, 4, 1, CAST(70000.00 AS Decimal(10, 2)), CAST(560000.00 AS Decimal(10, 2)), N'Thuê mới')
IF NOT EXISTS(SELECT 1 FROM [dbo].[ChiTietPhieuThue] WHERE [MaChiTietThue] = 30) INSERT [dbo].[ChiTietPhieuThue] ([MaChiTietThue], [MaPhieuThue], [MaTB], [SoLuongThue], [GiaThueNgay], [ThanhTienDuKien], [GhiChu]) VALUES (30, 8, 1, 1, CAST(50000.00 AS Decimal(10, 2)), CAST(400000.00 AS Decimal(10, 2)), N'Thuê mới')
IF NOT EXISTS(SELECT 1 FROM [dbo].[ChiTietPhieuThue] WHERE [MaChiTietThue] = 31) INSERT [dbo].[ChiTietPhieuThue] ([MaChiTietThue], [MaPhieuThue], [MaTB], [SoLuongThue], [GiaThueNgay], [ThanhTienDuKien], [GhiChu]) VALUES (31, 8, 2, 1, CAST(30000.00 AS Decimal(10, 2)), CAST(240000.00 AS Decimal(10, 2)), N'Thuê mới')
IF NOT EXISTS(SELECT 1 FROM [dbo].[ChiTietPhieuThue] WHERE [MaChiTietThue] = 33) INSERT [dbo].[ChiTietPhieuThue] ([MaChiTietThue], [MaPhieuThue], [MaTB], [SoLuongThue], [GiaThueNgay], [ThanhTienDuKien], [GhiChu]) VALUES (33, 2, 2, 10, CAST(30000.00 AS Decimal(10, 2)), CAST(2400000.00 AS Decimal(10, 2)), N'Thuê coffa')
IF NOT EXISTS(SELECT 1 FROM [dbo].[ChiTietPhieuThue] WHERE [MaChiTietThue] = 34) INSERT [dbo].[ChiTietPhieuThue] ([MaChiTietThue], [MaPhieuThue], [MaTB], [SoLuongThue], [GiaThueNgay], [ThanhTienDuKien], [GhiChu]) VALUES (34, 4, 4, 3, CAST(70000.00 AS Decimal(10, 2)), CAST(1680000.00 AS Decimal(10, 2)), N'Thuê cối trộn')
IF NOT EXISTS(SELECT 1 FROM [dbo].[ChiTietPhieuThue] WHERE [MaChiTietThue] = 35) INSERT [dbo].[ChiTietPhieuThue] ([MaChiTietThue], [MaPhieuThue], [MaTB], [SoLuongThue], [GiaThueNgay], [ThanhTienDuKien], [GhiChu]) VALUES (35, 5, 5, 7, CAST(40000.00 AS Decimal(10, 2)), CAST(2240000.00 AS Decimal(10, 2)), N'Thuê máy cắt')
IF NOT EXISTS(SELECT 1 FROM [dbo].[ChiTietPhieuThue] WHERE [MaChiTietThue] = 36) INSERT [dbo].[ChiTietPhieuThue] ([MaChiTietThue], [MaPhieuThue], [MaTB], [SoLuongThue], [GiaThueNgay], [ThanhTienDuKien], [GhiChu]) VALUES (36, 3, 3, 2, CAST(100000.00 AS Decimal(10, 2)), CAST(1600000.00 AS Decimal(10, 2)), N'Thuê lu')
SET IDENTITY_INSERT [dbo].[ChiTietPhieuThue] OFF
GO
SET IDENTITY_INSERT [dbo].[ChiTietPhieuTra] ON 
IF NOT EXISTS(SELECT 1 FROM [dbo].[ChiTietPhieuTra] WHERE [MaChiTietTra] = 15) INSERT [dbo].[ChiTietPhieuTra] ([MaChiTietTra], [MaPhieuTra], [MaTB], [SoLuongTra], [TinhTrang], [PhatThem], [GhiChu]) VALUES (15, 1, 1, 6, N'Tốt', CAST(0.00 AS Decimal(10, 2)), N'Trạng thái tốt')
IF NOT EXISTS(SELECT 1 FROM [dbo].[ChiTietPhieuTra] WHERE [MaChiTietTra] = 16) INSERT [dbo].[ChiTietPhieuTra] ([MaChiTietTra], [MaPhieuTra], [MaTB], [SoLuongTra], [TinhTrang], [PhatThem], [GhiChu]) VALUES (16, 1, 2, 1, N'Tốt', CAST(0.00 AS Decimal(10, 2)), N'Trạng thái tốt')
IF NOT EXISTS(SELECT 1 FROM [dbo].[ChiTietPhieuTra] WHERE [MaChiTietTra] = 17) INSERT [dbo].[ChiTietPhieuTra] ([MaChiTietTra], [MaPhieuTra], [MaTB], [SoLuongTra], [TinhTrang], [PhatThem], [GhiChu]) VALUES (17, 1, 4, 1, N'Tốt', CAST(0.00 AS Decimal(10, 2)), N'Trạng thái tốt')
IF NOT EXISTS(SELECT 1 FROM [dbo].[ChiTietPhieuTra] WHERE [MaChiTietTra] = 22) INSERT [dbo].[ChiTietPhieuTra] ([MaChiTietTra], [MaPhieuTra], [MaTB], [SoLuongTra], [TinhTrang], [PhatThem], [GhiChu]) VALUES (22, 6, 1, 1, N'Tốt', CAST(10000.00 AS Decimal(10, 2)), N'Trạng thái tốt')
IF NOT EXISTS(SELECT 1 FROM [dbo].[ChiTietPhieuTra] WHERE [MaChiTietTra] = 23) INSERT [dbo].[ChiTietPhieuTra] ([MaChiTietTra], [MaPhieuTra], [MaTB], [SoLuongTra], [TinhTrang], [PhatThem], [GhiChu]) VALUES (23, 6, 2, 1, N'Tốt', CAST(25000.00 AS Decimal(10, 2)), N'Trạng thái tốt')
IF NOT EXISTS(SELECT 1 FROM [dbo].[ChiTietPhieuTra] WHERE [MaChiTietTra] = 25) INSERT [dbo].[ChiTietPhieuTra] ([MaChiTietTra], [MaPhieuTra], [MaTB], [SoLuongTra], [TinhTrang], [PhatThem], [GhiChu]) VALUES (25, 2, 2, 10, N'Hỏng một phần', CAST(500000.00 AS Decimal(10, 2)), N'Phạt hỏng')
IF NOT EXISTS(SELECT 1 FROM [dbo].[ChiTietPhieuTra] WHERE [MaChiTietTra] = 26) INSERT [dbo].[ChiTietPhieuTra] ([MaChiTietTra], [MaPhieuTra], [MaTB], [SoLuongTra], [TinhTrang], [PhatThem], [GhiChu]) VALUES (26, 4, 4, 3, N'Tốt', CAST(0.00 AS Decimal(10, 2)), N'Trạng thái tốt')
IF NOT EXISTS(SELECT 1 FROM [dbo].[ChiTietPhieuTra] WHERE [MaChiTietTra] = 27) INSERT [dbo].[ChiTietPhieuTra] ([MaChiTietTra], [MaPhieuTra], [MaTB], [SoLuongTra], [TinhTrang], [PhatThem], [GhiChu]) VALUES (27, 5, 5, 7, N'Hỏng', CAST(200000.00 AS Decimal(10, 2)), N'Phạt hỏng')
IF NOT EXISTS(SELECT 1 FROM [dbo].[ChiTietPhieuTra] WHERE [MaChiTietTra] = 28) INSERT [dbo].[ChiTietPhieuTra] ([MaChiTietTra], [MaPhieuTra], [MaTB], [SoLuongTra], [TinhTrang], [PhatThem], [GhiChu]) VALUES (28, 3, 3, 2, N'Tốt', CAST(0.00 AS Decimal(10, 2)), N'Trạng thái tốt')
SET IDENTITY_INSERT [dbo].[ChiTietPhieuTra] OFF
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = N'UQ__NhanVien__272500710B435170' AND object_id = OBJECT_ID(N'[dbo].[NhanVien]'))
BEGIN
ALTER TABLE [dbo].[NhanVien] ADD UNIQUE NONCLUSTERED 
(
	[MaTK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = N'UQ__PhieuTra__08322817A9B01B0A' AND object_id = OBJECT_ID(N'[dbo].[PhieuTra]'))
BEGIN
ALTER TABLE [dbo].[PhieuTra] ADD UNIQUE NONCLUSTERED 
(
	[MaPhieuThue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
END
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = N'UQ__ThietBi__048A0008610A47AC' AND object_id = OBJECT_ID(N'[dbo].[ThietBi]'))
BEGIN
ALTER TABLE [dbo].[ThietBi] ADD UNIQUE NONCLUSTERED 
(
	[SerialNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
END
GO
-- Foreign keys
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ChiTietPh__MaPhi__123456]'))
BEGIN
-- Note: Skipping FK naming to avoid errors if they are auto-named or different. 
-- Adding constraints only if they don't exist is tricky without names. 
-- But since CREATE TABLE was wrapped in IF NOT EXISTS, we usually add FKs there or alter.
-- The user script alters.
-- I'll skip IF checks for FKs to keep it simple, expecting that if tables were created, FKs were not yet added if I didn't add them in CREATE TABLE.
-- But wait, I split CREATE TABLE.
-- Let's just run the ALTER TABLEs. If they exist, they might error.
-- To be safe, I'm just going to rely on the fact that if tables didn't exist, these will run fine.
-- If tables existed, we might have issues. But the user said DB didn't exist.
-- So I will trust the ALTERS.
PRINT 'Adding Foreign Keys...'
END
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD FOREIGN KEY([MaPhieuNhap])
REFERENCES [dbo].[PhieuNhap] ([MaPhieuNhap])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD FOREIGN KEY([MaTB])
REFERENCES [dbo].[ThietBi] ([MaTB])
GO
ALTER TABLE [dbo].[ChiTietPhieuThue]  WITH CHECK ADD FOREIGN KEY([MaPhieuThue])
REFERENCES [dbo].[PhieuThue] ([MaPhieuThue])
GO
ALTER TABLE [dbo].[ChiTietPhieuThue]  WITH CHECK ADD FOREIGN KEY([MaTB])
REFERENCES [dbo].[ThietBi] ([MaTB])
GO
ALTER TABLE [dbo].[ChiTietPhieuTra]  WITH CHECK ADD FOREIGN KEY([MaPhieuTra])
REFERENCES [dbo].[PhieuTra] ([MaPhieuTra])
GO
ALTER TABLE [dbo].[ChiTietPhieuTra]  WITH CHECK ADD FOREIGN KEY([MaTB])
REFERENCES [dbo].[ThietBi] ([MaTB])
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD FOREIGN KEY([MaChucVu])
REFERENCES [dbo].[ChucVu] ([MaChucVu])
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[PhieuThue]  WITH CHECK ADD FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[PhieuThue]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[PhieuTra]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[PhieuTra]  WITH CHECK ADD FOREIGN KEY([MaPhieuThue])
REFERENCES [dbo].[PhieuThue] ([MaPhieuThue])
GO
ALTER TABLE [dbo].[ThietBi]  WITH CHECK ADD FOREIGN KEY([MaLoai])
REFERENCES [dbo].[LoaiThietBi] ([MaLoai])
GO

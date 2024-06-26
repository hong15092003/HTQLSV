USE [master]
GO
/****** Object:  Database [HTQLSV]    Script Date: 20/05/2024 16:25:10 ******/
CREATE DATABASE [HTQLSV]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HTQLSV', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\HTQLSV.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HTQLSV_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\HTQLSV_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [HTQLSV] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HTQLSV].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HTQLSV] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HTQLSV] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HTQLSV] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HTQLSV] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HTQLSV] SET ARITHABORT OFF 
GO
ALTER DATABASE [HTQLSV] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HTQLSV] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HTQLSV] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HTQLSV] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HTQLSV] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HTQLSV] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HTQLSV] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HTQLSV] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HTQLSV] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HTQLSV] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HTQLSV] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HTQLSV] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HTQLSV] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HTQLSV] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HTQLSV] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HTQLSV] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HTQLSV] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HTQLSV] SET RECOVERY FULL 
GO
ALTER DATABASE [HTQLSV] SET  MULTI_USER 
GO
ALTER DATABASE [HTQLSV] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HTQLSV] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HTQLSV] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HTQLSV] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HTQLSV] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HTQLSV] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'HTQLSV', N'ON'
GO
ALTER DATABASE [HTQLSV] SET QUERY_STORE = ON
GO
ALTER DATABASE [HTQLSV] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [HTQLSV]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 20/05/2024 16:25:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DayHoc]    Script Date: 20/05/2024 16:25:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DayHoc](
	[MaDayHoc] [int] NOT NULL,
	[SoTiet] [int] NULL,
	[ThoiGian] [varchar](50) NULL,
	[MaMonHoc] [int] NULL,
	[MaGV] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDayHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Diem]    Script Date: 20/05/2024 16:25:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diem](
	[MaDiem] [int] NOT NULL,
	[DiemA] [decimal](5, 2) NULL,
	[DiemB] [decimal](5, 2) NULL,
	[DiemC] [decimal](5, 2) NULL,
	[MaSV] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDiem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiangVien]    Script Date: 20/05/2024 16:25:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiangVien](
	[MaGV] [int] NOT NULL,
	[HoTen] [varchar](255) NULL,
	[GioiTinh] [varchar](10) NULL,
	[NgaySinh] [date] NULL,
	[QueQuan] [varchar](255) NULL,
	[SDT] [varchar](20) NULL,
	[Email] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaGV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HocDayHoc]    Script Date: 20/05/2024 16:25:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocDayHoc](
	[MaDayHoc] [int] NOT NULL,
	[SoTiet] [int] NULL,
	[ThoiGian] [varchar](50) NULL,
	[MaMonHoc] [int] NULL,
	[MaGV] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDayHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HocPhan]    Script Date: 20/05/2024 16:25:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocPhan](
	[MaHocPhan] [int] NOT NULL,
	[SoTiet] [int] NULL,
	[ThoiGian] [varchar](50) NULL,
	[MaMonHoc] [int] NULL,
	[MaSV] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHocPhan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HocPhi]    Script Date: 20/05/2024 16:25:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocPhi](
	[MaHocPhi] [int] NOT NULL,
	[HocKi] [int] NULL,
	[SoTien] [decimal](10, 2) NULL,
	[MaSV] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHocPhi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Khoa]    Script Date: 20/05/2024 16:25:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Khoa](
	[MaKhoa] [int] NOT NULL,
	[TenKhoa] [varchar](255) NULL,
	[MaPhongBan] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKhoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LopChinhKhoa]    Script Date: 20/05/2024 16:25:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LopChinhKhoa](
	[MaLopCK] [int] NOT NULL,
	[TenLopHoc] [varchar](255) NULL,
	[NienKhoa] [varchar](20) NULL,
	[MaKhoa] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLopCK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonHoc]    Script Date: 20/05/2024 16:25:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonHoc](
	[MaMonHoc] [int] NOT NULL,
	[TenMonHoc] [varchar](255) NULL,
	[SoTC] [int] NULL,
	[SoTietTH] [int] NULL,
	[SoTietLT] [int] NULL,
	[MaKhoa] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaMonHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhongBan]    Script Date: 20/05/2024 16:25:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongBan](
	[MaPhongBan] [int] NOT NULL,
	[TenPhongBan] [varchar](255) NULL,
	[TruongPhong] [varchar](255) NULL,
	[NhiemVu] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhongBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SinhVien]    Script Date: 20/05/2024 16:25:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinhVien](
	[MaSV] [int] NOT NULL,
	[HoTen] [varchar](255) NULL,
	[GioiTinh] [varchar](10) NULL,
	[NgaySinh] [date] NULL,
	[QueQuan] [varchar](255) NULL,
	[SDT] [varchar](20) NULL,
	[Email] [varchar](255) NULL,
	[MaLopCK] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([id], [UserName], [Password]) VALUES (1, N'admin', N'admin')
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
INSERT [dbo].[GiangVien] ([MaGV], [HoTen], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [Email]) VALUES (1, N'Nguyen Van A', N'Nam', CAST(N'1980-05-10' AS Date), N'Hanoi', N'0987654321', N'nguyenvana@example.com')
INSERT [dbo].[GiangVien] ([MaGV], [HoTen], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [Email]) VALUES (2, N'Tran Thi B', N'Nu', CAST(N'1985-08-15' AS Date), N'HCMC', N'0123456789', N'tranthib@example.com')
INSERT [dbo].[GiangVien] ([MaGV], [HoTen], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [Email]) VALUES (3, N'Le Van C', N'Nam', CAST(N'1975-03-20' AS Date), N'Danang', N'0987123456', N'levanc@example.com')
INSERT [dbo].[GiangVien] ([MaGV], [HoTen], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [Email]) VALUES (4, N'Pham Thanh D', N'Nu', CAST(N'1982-11-25' AS Date), N'Hue', N'0932123456', N'phamthanhd@example.com')
INSERT [dbo].[GiangVien] ([MaGV], [HoTen], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [Email]) VALUES (5, N'Vo Minh E', N'Nam', CAST(N'1978-09-18' AS Date), N'Haiphong', N'0978123456', N'vominhe@example.com')
INSERT [dbo].[GiangVien] ([MaGV], [HoTen], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [Email]) VALUES (6, N'Truong Thi F', N'Nu', CAST(N'1983-07-30' AS Date), N'Nhatrang', N'0909123456', N'truongthif@example.com')
INSERT [dbo].[GiangVien] ([MaGV], [HoTen], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [Email]) VALUES (7, N'Hoang Van G', N'Nam', CAST(N'1976-12-05' AS Date), N'Dalat', N'0967123456', N'hoangvang@example.com')
INSERT [dbo].[GiangVien] ([MaGV], [HoTen], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [Email]) VALUES (8, N'Doan Ngoc H', N'Nu', CAST(N'1980-06-28' AS Date), N'Quangninh', N'0945123456', N'doanngoch@example.com')
INSERT [dbo].[GiangVien] ([MaGV], [HoTen], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [Email]) VALUES (9, N'Nguyen Thi I', N'Nu', CAST(N'1979-02-15' AS Date), N'Cantho', N'0923123456', N'nguyenthi@example.com')
INSERT [dbo].[GiangVien] ([MaGV], [HoTen], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [Email]) VALUES (10, N'Le Van K', N'Nam', CAST(N'1984-04-22' AS Date), N'SocTrang', N'0912123456', N'levank@example.com')
GO
INSERT [dbo].[Khoa] ([MaKhoa], [TenKhoa], [MaPhongBan]) VALUES (1, N'Khoa A', 1)
INSERT [dbo].[Khoa] ([MaKhoa], [TenKhoa], [MaPhongBan]) VALUES (2, N'Khoa B', 2)
GO
INSERT [dbo].[LopChinhKhoa] ([MaLopCK], [TenLopHoc], [NienKhoa], [MaKhoa]) VALUES (1, N'Lop A', N'2023-2024', 1)
INSERT [dbo].[LopChinhKhoa] ([MaLopCK], [TenLopHoc], [NienKhoa], [MaKhoa]) VALUES (2, N'Lop B', N'2022-2023', 1)
INSERT [dbo].[LopChinhKhoa] ([MaLopCK], [TenLopHoc], [NienKhoa], [MaKhoa]) VALUES (3, N'Lop C', N'2024-2025', 2)
INSERT [dbo].[LopChinhKhoa] ([MaLopCK], [TenLopHoc], [NienKhoa], [MaKhoa]) VALUES (4, N'Lop D', N'2021-2022', 2)
GO
INSERT [dbo].[MonHoc] ([MaMonHoc], [TenMonHoc], [SoTC], [SoTietTH], [SoTietLT], [MaKhoa]) VALUES (1, N'Toan', 4, 60, 30, 1)
INSERT [dbo].[MonHoc] ([MaMonHoc], [TenMonHoc], [SoTC], [SoTietTH], [SoTietLT], [MaKhoa]) VALUES (2, N'Van', 3, 45, 30, 1)
INSERT [dbo].[MonHoc] ([MaMonHoc], [TenMonHoc], [SoTC], [SoTietTH], [SoTietLT], [MaKhoa]) VALUES (3, N'Anh', 3, 45, 30, 1)
INSERT [dbo].[MonHoc] ([MaMonHoc], [TenMonHoc], [SoTC], [SoTietTH], [SoTietLT], [MaKhoa]) VALUES (4, N'Ly', 4, 60, 30, 2)
INSERT [dbo].[MonHoc] ([MaMonHoc], [TenMonHoc], [SoTC], [SoTietTH], [SoTietLT], [MaKhoa]) VALUES (5, N'Hoa', 4, 60, 30, 2)
INSERT [dbo].[MonHoc] ([MaMonHoc], [TenMonHoc], [SoTC], [SoTietTH], [SoTietLT], [MaKhoa]) VALUES (6, N'Sinh', 3, 45, 30, 2)
INSERT [dbo].[MonHoc] ([MaMonHoc], [TenMonHoc], [SoTC], [SoTietTH], [SoTietLT], [MaKhoa]) VALUES (7, N'Dia Ly', 3, 45, 30, 2)
INSERT [dbo].[MonHoc] ([MaMonHoc], [TenMonHoc], [SoTC], [SoTietTH], [SoTietLT], [MaKhoa]) VALUES (8, N'Tin', 4, 60, 30, 1)
GO
INSERT [dbo].[PhongBan] ([MaPhongBan], [TenPhongBan], [TruongPhong], [NhiemVu]) VALUES (1, N'Phong Ban A', N'Truong A', N'Nhiem vu A')
INSERT [dbo].[PhongBan] ([MaPhongBan], [TenPhongBan], [TruongPhong], [NhiemVu]) VALUES (2, N'Phong Ban B', N'Truong B', N'Nhiem vu B')
INSERT [dbo].[PhongBan] ([MaPhongBan], [TenPhongBan], [TruongPhong], [NhiemVu]) VALUES (3, N'Phong Ban C', N'Truong C', N'Nhiem vu C')
INSERT [dbo].[PhongBan] ([MaPhongBan], [TenPhongBan], [TruongPhong], [NhiemVu]) VALUES (4, N'Phong Ban D', N'Truong D', N'Nhiem vu D')
GO
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [Email], [MaLopCK]) VALUES (1, N'Nguyen Van An', N'Nam', CAST(N'2000-01-01' AS Date), N'Hanoi', N'0123456789', N'nguyenvanan@example.com', 1)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [Email], [MaLopCK]) VALUES (2, N'Tran Thi Bao', N'Nu', CAST(N'2000-02-02' AS Date), N'HCMC', N'0234567890', N'tranbao@example.com', 1)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [Email], [MaLopCK]) VALUES (3, N'Le Xuan Cuong', N'Nam', CAST(N'2000-03-03' AS Date), N'Danang', N'0345678901', N'levancuong@example.com', 1)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [Email], [MaLopCK]) VALUES (4, N'Pham Thi Dung', N'Nu', CAST(N'2000-04-04' AS Date), N'Hue', N'0456789012', N'phamdung@example.com', 1)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [Email], [MaLopCK]) VALUES (5, N'Vo Minh Dan', N'Nam', CAST(N'2000-05-05' AS Date), N'Haiphong', N'0567890123', N'vodan@example.com', 2)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [Email], [MaLopCK]) VALUES (6, N'Truong Thi Eo', N'Nu', CAST(N'2000-06-06' AS Date), N'Nhatrang', N'0678901234', N'truongeo@example.com', 2)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [Email], [MaLopCK]) VALUES (7, N'Hoang Van F', N'Nam', CAST(N'2000-07-07' AS Date), N'Dalat', N'0789012345', N'hoangf@example.com', 2)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [Email], [MaLopCK]) VALUES (8, N'Doan Thi Gai', N'Nu', CAST(N'2000-08-08' AS Date), N'Quangninh', N'0890123456', N'doangai@example.com', 2)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [Email], [MaLopCK]) VALUES (9, N'Nguyen Van Hieu', N'Nam', CAST(N'2000-09-09' AS Date), N'Cantho', N'0901234567', N'nguyenhieu@example.com', 3)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [Email], [MaLopCK]) VALUES (10, N'Le Thi Thao', N'Nu', CAST(N'2000-10-10' AS Date), N'SocTrang', N'0912345678', N'lethao@example.com', 3)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [Email], [MaLopCK]) VALUES (11, N'Tran Van Khoa', N'Nam', CAST(N'2000-11-11' AS Date), N'Haiphong', N'0923456789', N'trankhoa@example.com', 3)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [Email], [MaLopCK]) VALUES (12, N'Pham Thi Lan', N'Nu', CAST(N'2000-12-12' AS Date), N'HCMC', N'0934567890', N'phamlan@example.com', 3)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [Email], [MaLopCK]) VALUES (13, N'Vo Minh Luan', N'Nam', CAST(N'2000-01-13' AS Date), N'Danang', N'0945678901', N'voluan@example.com', 4)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [Email], [MaLopCK]) VALUES (14, N'Truong Van Mau', N'Nam', CAST(N'2000-02-14' AS Date), N'Dalat', N'0956789012', N'truongmau@example.com', 4)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [Email], [MaLopCK]) VALUES (15, N'Hoang Thi Nga', N'Nu', CAST(N'2000-03-15' AS Date), N'Hanoi', N'0967890123', N'hoangnga@example.com', 4)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [Email], [MaLopCK]) VALUES (16, N'Doan Van Oanh', N'Nam', CAST(N'2000-04-16' AS Date), N'HCMC', N'0978901234', N'doanoanh@example.com', 4)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [Email], [MaLopCK]) VALUES (17, N'Le Xuan Nam', N'Nam', CAST(N'2000-03-03' AS Date), N'Danang', N'0345678901', N'levancuong@example.com', 4)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [Email], [MaLopCK]) VALUES (18, N'Nguyen van b', N'Nam', CAST(N'2003-01-15' AS Date), N'Ba Vi', N'0123456789', N'hong15092003@gmail.com', 1)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Account__C9F28456CDA25CCE]    Script Date: 20/05/2024 16:25:11 ******/
ALTER TABLE [dbo].[Account] ADD UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DayHoc]  WITH CHECK ADD FOREIGN KEY([MaGV])
REFERENCES [dbo].[GiangVien] ([MaGV])
GO
ALTER TABLE [dbo].[DayHoc]  WITH CHECK ADD FOREIGN KEY([MaMonHoc])
REFERENCES [dbo].[MonHoc] ([MaMonHoc])
GO
ALTER TABLE [dbo].[Diem]  WITH CHECK ADD FOREIGN KEY([MaSV])
REFERENCES [dbo].[SinhVien] ([MaSV])
GO
ALTER TABLE [dbo].[HocDayHoc]  WITH CHECK ADD FOREIGN KEY([MaGV])
REFERENCES [dbo].[GiangVien] ([MaGV])
GO
ALTER TABLE [dbo].[HocDayHoc]  WITH CHECK ADD FOREIGN KEY([MaMonHoc])
REFERENCES [dbo].[MonHoc] ([MaMonHoc])
GO
ALTER TABLE [dbo].[HocPhan]  WITH CHECK ADD FOREIGN KEY([MaMonHoc])
REFERENCES [dbo].[MonHoc] ([MaMonHoc])
GO
ALTER TABLE [dbo].[HocPhan]  WITH CHECK ADD FOREIGN KEY([MaSV])
REFERENCES [dbo].[SinhVien] ([MaSV])
GO
ALTER TABLE [dbo].[HocPhi]  WITH CHECK ADD FOREIGN KEY([MaSV])
REFERENCES [dbo].[SinhVien] ([MaSV])
GO
ALTER TABLE [dbo].[Khoa]  WITH CHECK ADD FOREIGN KEY([MaPhongBan])
REFERENCES [dbo].[PhongBan] ([MaPhongBan])
GO
ALTER TABLE [dbo].[LopChinhKhoa]  WITH CHECK ADD FOREIGN KEY([MaKhoa])
REFERENCES [dbo].[Khoa] ([MaKhoa])
GO
ALTER TABLE [dbo].[MonHoc]  WITH CHECK ADD FOREIGN KEY([MaKhoa])
REFERENCES [dbo].[Khoa] ([MaKhoa])
GO
ALTER TABLE [dbo].[SinhVien]  WITH CHECK ADD FOREIGN KEY([MaLopCK])
REFERENCES [dbo].[LopChinhKhoa] ([MaLopCK])
GO
USE [master]
GO
ALTER DATABASE [HTQLSV] SET  READ_WRITE 
GO

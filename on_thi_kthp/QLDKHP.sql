USE [master]
GO
/****** Object:  Database [QLDKHP]    Script Date: 6/13/2022 9:39:23 AM ******/
CREATE DATABASE [QLDKHP]
 
GO
USE [QLDKHP]
GO
/****** Object:  Table [dbo].[ChuongTrinhDT]    Script Date: 6/13/2022 9:39:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuongTrinhDT](
	[MaCTDT] [int] IDENTITY(1,1) NOT NULL,
	[TenCTDT] [nvarchar](50) NOT NULL,
	[MoTa] [nvarchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCTDT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hoc]    Script Date: 6/13/2022 9:39:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hoc](
	[MaSV] [int] NOT NULL,
	[MaMH] [nchar](10) NOT NULL,
	[Diem] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSV] ASC,
	[MaMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lop]    Script Date: 6/13/2022 9:39:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lop](
	[MaLop] [int] IDENTITY(1,1) NOT NULL,
	[TenLop] [char](5) NOT NULL,
	[MaCTĐT] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonHoc]    Script Date: 6/13/2022 9:39:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonHoc](
	[MaMH] [nchar](10) NOT NULL,
	[TenMH] [nvarchar](50) NOT NULL,
	[SoTC] [int] NOT NULL,
	[MaCTĐT] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SinhVien]    Script Date: 6/13/2022 9:39:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinhVien](
	[MaSV] [int] IDENTITY(2100000,1) NOT NULL,
	[HoTen] [nvarchar](50) NOT NULL,
	[MaLop] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ChuongTrinhDT] ON 

INSERT [dbo].[ChuongTrinhDT] ([MaCTDT], [TenCTDT], [MoTa]) VALUES (1, N'Chương trình đào tạo 2015', NULL)
INSERT [dbo].[ChuongTrinhDT] ([MaCTDT], [TenCTDT], [MoTa]) VALUES (2, N'Chương trình đào tạo 2017', NULL)
INSERT [dbo].[ChuongTrinhDT] ([MaCTDT], [TenCTDT], [MoTa]) VALUES (3, N'Chương trình đào tạo 2020', NULL)
SET IDENTITY_INSERT [dbo].[ChuongTrinhDT] OFF
GO
INSERT [dbo].[Hoc] ([MaSV], [MaMH], [Diem]) VALUES (1923244, N'CT2201    ', 6)
INSERT [dbo].[Hoc] ([MaSV], [MaMH], [Diem]) VALUES (1923244, N'NN1002    ', 9)
INSERT [dbo].[Hoc] ([MaSV], [MaMH], [Diem]) VALUES (1923244, N'QP2002    ', 7)
INSERT [dbo].[Hoc] ([MaSV], [MaMH], [Diem]) VALUES (1923244, N'TC1002    ', 5)
INSERT [dbo].[Hoc] ([MaSV], [MaMH], [Diem]) VALUES (1923244, N'TN1101    ', 5)
INSERT [dbo].[Hoc] ([MaSV], [MaMH], [Diem]) VALUES (1934567, N'CT2201    ', 9)
INSERT [dbo].[Hoc] ([MaSV], [MaMH], [Diem]) VALUES (1934567, N'NN1002    ', 9)
INSERT [dbo].[Hoc] ([MaSV], [MaMH], [Diem]) VALUES (1934567, N'TC1001    ', 5)
INSERT [dbo].[Hoc] ([MaSV], [MaMH], [Diem]) VALUES (1934567, N'TN1101    ', 8)
INSERT [dbo].[Hoc] ([MaSV], [MaMH], [Diem]) VALUES (1945465, N'TC1001    ', 6)
INSERT [dbo].[Hoc] ([MaSV], [MaMH], [Diem]) VALUES (1945465, N'TN1101    ', 7)
INSERT [dbo].[Hoc] ([MaSV], [MaMH], [Diem]) VALUES (2056566, N'20CT2201  ', 9)
INSERT [dbo].[Hoc] ([MaSV], [MaMH], [Diem]) VALUES (2056566, N'20NN1002  ', 6)
INSERT [dbo].[Hoc] ([MaSV], [MaMH], [Diem]) VALUES (2056567, N'20NN1002  ', 8)
INSERT [dbo].[Hoc] ([MaSV], [MaMH], [Diem]) VALUES (2167698, N'20CT2201  ', 7)
INSERT [dbo].[Hoc] ([MaSV], [MaMH], [Diem]) VALUES (2167698, N'20NN1002  ', 9)
GO
SET IDENTITY_INSERT [dbo].[Lop] ON 

INSERT [dbo].[Lop] ([MaLop], [TenLop], [MaCTĐT]) VALUES (1, N'CTK42', 1)
INSERT [dbo].[Lop] ([MaLop], [TenLop], [MaCTĐT]) VALUES (2, N'CTK43', 2)
INSERT [dbo].[Lop] ([MaLop], [TenLop], [MaCTĐT]) VALUES (3, N'CTK44', 3)
INSERT [dbo].[Lop] ([MaLop], [TenLop], [MaCTĐT]) VALUES (4, N'CTK45', 3)
SET IDENTITY_INSERT [dbo].[Lop] OFF
GO
INSERT [dbo].[MonHoc] ([MaMH], [TenMH], [SoTC], [MaCTĐT]) VALUES (N'20CT2201  ', N'Nguyên lý lập trình hướng đối tượng', 4, 3)
INSERT [dbo].[MonHoc] ([MaMH], [TenMH], [SoTC], [MaCTĐT]) VALUES (N'20NN1002  ', N'Tiếng Anh chuyên ngành CNTT', 3, 3)
INSERT [dbo].[MonHoc] ([MaMH], [TenMH], [SoTC], [MaCTĐT]) VALUES (N'20TN1101  ', N'Toán cao cấp', 3, 3)
INSERT [dbo].[MonHoc] ([MaMH], [TenMH], [SoTC], [MaCTĐT]) VALUES (N'CT2201    ', N'Nguyên lý lập trình', 4, 1)
INSERT [dbo].[MonHoc] ([MaMH], [TenMH], [SoTC], [MaCTĐT]) VALUES (N'NN1002    ', N'Tiếng Anh thương mại', 3, 2)
INSERT [dbo].[MonHoc] ([MaMH], [TenMH], [SoTC], [MaCTĐT]) VALUES (N'QP2001    ', N'Quốc phòng 1', 3, 1)
INSERT [dbo].[MonHoc] ([MaMH], [TenMH], [SoTC], [MaCTĐT]) VALUES (N'QP2002    ', N'Quốc phòng 2', 3, 1)
INSERT [dbo].[MonHoc] ([MaMH], [TenMH], [SoTC], [MaCTĐT]) VALUES (N'TC1001    ', N'Thể chất 1', 3, 2)
INSERT [dbo].[MonHoc] ([MaMH], [TenMH], [SoTC], [MaCTĐT]) VALUES (N'TC1002    ', N'Thể chất 2', 3, 3)
INSERT [dbo].[MonHoc] ([MaMH], [TenMH], [SoTC], [MaCTĐT]) VALUES (N'TN1101    ', N'Toán cao cấp', 3, 1)
INSERT [dbo].[MonHoc] ([MaMH], [TenMH], [SoTC], [MaCTĐT]) VALUES (N'VL1020    ', N'Vật lý đại cương', 3, 2)
GO
SET IDENTITY_INSERT [dbo].[SinhVien] ON 

INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [MaLop]) VALUES (1923244, N'Trung', 1)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [MaLop]) VALUES (1934567, N'Quốc', 1)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [MaLop]) VALUES (1945465, N'Mai', 1)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [MaLop]) VALUES (2056566, N'Thành', 2)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [MaLop]) VALUES (2056567, N'Hòa', 2)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [MaLop]) VALUES (2167698, N'Hạnh', 3)
INSERT [dbo].[SinhVien] ([MaSV], [HoTen], [MaLop]) VALUES (2267879, N'Vân Anh', 4)
SET IDENTITY_INSERT [dbo].[SinhVien] OFF
GO
ALTER TABLE [dbo].[Hoc]  WITH CHECK ADD FOREIGN KEY([MaMH])
REFERENCES [dbo].[MonHoc] ([MaMH])
GO
ALTER TABLE [dbo].[Hoc]  WITH CHECK ADD FOREIGN KEY([MaSV])
REFERENCES [dbo].[SinhVien] ([MaSV])
GO
ALTER TABLE [dbo].[Lop]  WITH CHECK ADD FOREIGN KEY([MaCTĐT])
REFERENCES [dbo].[ChuongTrinhDT] ([MaCTDT])
GO
ALTER TABLE [dbo].[SinhVien]  WITH CHECK ADD FOREIGN KEY([MaLop])
REFERENCES [dbo].[Lop] ([MaLop])
GO

create proc LayDS_ChuongTrinhDT
AS
BEGIN
	select * from ChuongTrinhDT
END
GO

create proc ThemSuaXoa_MonHoc
	@mamh int output, @ten nvarchar(50), @sotc int, @ctdt int, @thaotac int
AS
BEGIN
	if @thaotac = 0 -- Thêm môn học mới
		begin
			insert into MonHoc (TenMH, SoTC, MaCTĐT) values (@ten, @sotc, @ctdt)
			select @mamh = SCOPE_IDENTITY()
		end
	else if @thaotac = 1 -- Sửa thông ton môn học
		begin
			update	MonHoc
			set
				TenMH = @ten,
				SoTC = @sotc,
				MaCTĐT = @ctdt
			where	MaMH = @mamh
		end
	else if @thaotac = 2 -- Xoá môn học
		begin
			delete from MonHoc
			where MaMH = @mamh
		end
END
GO

--create proc Them_MonHoc
--	@MaMH int output, @TenMH nvarchar(50), @SoTC int, @MaCTDT int
--AS
--BEGIN
--	insert into MonHoc (TenMH, SoTC, MaCTĐT) values (@TenMH, @SoTC, @MaCTDT)
--	select @MaMH = SCOPE_IDENTITY()
--END
--GO

--create proc Sua_MonHoc
--	@MaMH int, @TenMH nvarchar(50), @SoTC int, @MaCTDT int
--AS
--BEGIN
--	update	MonHoc
--	set		TenMH = @TenMH, SoTC = @SoTC, MaCTĐT = @MaCTDT
--	where	MaMH = @MaMH
--END
--GO

create proc LayDS_MonHoc	@mactdt int
AS
BEGIN
	if @mactdt = 0
		begin
			select * from MonHoc
		end
	else if @mactdt > 0
		begin
			select	*
			from	MonHoc
			where	MaCTĐT = @mactdt
		end
END
GO
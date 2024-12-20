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

----------------------------------------------------
create proc LayDS_ChuongTrinhDT
AS
BEGIN
	select * from ChuongTrinhDT
END
GO

---------- Các hàm tạo MaMH -----------
 -- Hàm chuyển chuỗi có dấu thành chuỗi không dấu
create function BoDau (@ChuoiDau nvarchar(max)) returns nvarchar(max)
 AS
 BEGIN
	declare @ChuoiKhongDau nvarchar(max)
	declare @i int = 1
	-- Bảng các ký tự cần thay thế
	declare @BangKTTT table ( KyTuGoc nvarchar(10), KyTuThayThe nvarchar(10) )

	insert into @BangKTTT (KyTuGoc, KyTuThayThe)
	values	(N'á', N'A'), (N'à', N'A'), (N'ả', N'A'), (N'ã', N'A'), (N'ạ', N'A'),
			(N'â', N'A'), (N'ấ', N'A'), (N'ầ', N'A'), (N'ẩ', N'A'), (N'ẫ', N'A'), (N'ậ', N'A'),
			(N'Á', N'A'), (N'À', N'A'), (N'Ả', N'A'), (N'Ã', N'A'), (N'Ạ', N'A'),
			(N'Â', N'A'), (N'Ấ', N'A'), (N'Ầ', N'A'), (N'Ẩ', N'A'), (N'Ẫ', N'A'), (N'Ậ', N'A'),

			(N'é', N'E'), (N'è', N'E'), (N'ẻ', N'E'), (N'ẽ', N'E'), (N'ẹ', N'E'),
			(N'ê', N'E'), (N'ế', N'E'), (N'ề', N'E'), (N'ể', N'E'), (N'ễ', N'E'), (N'ệ', N'E'),
			(N'É', N'E'), (N'È', N'E'), (N'Ẻ', N'E'), (N'Ẽ', N'E'), (N'Ẹ', N'E'),
			(N'Ê', N'E'), (N'Ế', N'E'), (N'Ề', N'E'), (N'Ể', N'E'), (N'Ễ', N'E'), (N'Ệ', N'E'),


			(N'í', N'I'), (N'ì', N'I'), (N'ỉ', N'I'), (N'ĩ', N'I'), (N'ị', N'I'), 
			(N'Í', N'I'), (N'Ì', N'I'), (N'Ỉ', N'I'), (N'Ĩ', N'I'), (N'Ị', N'I'),

			(N'ó', N'O'), (N'ò', N'O'), (N'ỏ', N'O'), (N'õ', N'O'), (N'ọ', N'O'),
			(N'ô', N'O'), (N'ố', N'O'), (N'ồ', N'O'), (N'ổ', N'O'), (N'ỗ', N'O'), (N'ộ', N'O'),
			(N'ơ', N'O'), (N'ớ', N'O'), (N'ờ', N'O'), (N'ở', N'O'), (N'ỡ', N'O'), (N'ợ', N'O'),
			(N'Ó', N'O'), (N'Ò', N'O'), (N'Ỏ', N'O'), (N'Õ', N'O'), (N'Ọ', N'O'),
			(N'Ô', N'O'), (N'Ố', N'O'), (N'Ồ', N'O'), (N'Ổ', N'O'), (N'Ỗ', N'O'), (N'Ộ', N'O'),
			(N'Ơ', N'O'), (N'Ớ', N'O'), (N'Ờ', N'O'), (N'Ở', N'O'), (N'Ỡ', N'O'), (N'Ợ', N'O'),

			(N'ú', N'U'), (N'ù', N'U'), (N'ủ', N'U'), (N'ũ', N'U'), (N'ụ', N'U'),
			(N'ư', N'U'), (N'ứ', N'U'), (N'ừ', N'U'), (N'ử', N'U'), (N'ữ', N'U'), (N'ự', N'U'),
			(N'Ú', N'U'), (N'Ù', N'U'), (N'Ủ', N'U'), (N'Ũ', N'U'), (N'Ụ', N'U'),
			(N'Ư', N'U'), (N'Ứ', N'U'), (N'Ừ', N'U'), (N'Ử', N'U'), (N'Ữ', N'U'), (N'Ự', N'U'),


			(N'ý', N'Y'), (N'ỳ', N'Y'), (N'ỷ', N'Y'), (N'ỹ', N'Y'), (N'ỵ', N'Y'), 
			(N'Ý', N'Y'), (N'Ỳ', N'Y'), (N'Ỷ', N'Y'), (N'Ỹ', N'Y'), (N'Ỵ', N'Y'),

			(N'đ', N'D'), (N'Đ', N'D')

	set	@ChuoiKhongDau = @ChuoiDau
	DECLARE @KyTuGoc NVARCHAR(10), @KyTuThayThe NVARCHAR(10);

    WHILE EXISTS (SELECT 1 FROM @BangKTTT)
    BEGIN
        SELECT TOP 1 @KyTuGoc = KyTuGoc, @KyTuThayThe = KyTuThayThe
        FROM @BangKTTT;

        -- Thay thế ký tự có dấu thành không dấu
        SET @ChuoiKhongDau = REPLACE(@ChuoiKhongDau, @KyTuGoc, @KyTuThayThe);

        -- Xóa ký tự đã xử lý khỏi bảng tạm
        DELETE FROM @BangKTTT WHERE KyTuGoc = @KyTuGoc;
    END;

    -- Loại bỏ khoảng trắng
    SET @ChuoiKhongDau = REPLACE(@ChuoiKhongDau, N' ', N'');
	set @ChuoiKhongDau = UPPER(@ChuoiKhongDau)

	return	@ChuoiKhongDau
 END
 GO

 -- Hàm tạo mã môn học
 create function TaoMaMH (@TenMH nvarchar(50)) returns varchar(10)
 AS
 BEGIN
	-- Khai báo các biến cần thiết
	declare	@MaMH nvarchar(10)
	declare	@KyTuDau nvarchar(3)
	declare	@KyTuNam nvarchar(4)
	declare	@SoThuTu nvarchar(3)

	-- Lấy 3 ký tự đầu của tên môn học (không dấu)
	set @KyTuDau = LEFT(dbo.BoDau(@TenMH), 3)

	-- Lấy năm của hệ thống tại thời điểm nhập môn học
	set	@KyTuNam = CAST(YEAR(GETDATE()) as nvarchar)

	-- Xác định số thứ tự tiếp theo dựa trên 3 ký tự đầu của mã
	select	@SoThuTu = RIGHT('000' + CAST(COUNT(*) + 1 as nvarchar), 3)
	from	MonHoc
	where	LEFT(MaMH, 3) = @KyTuDau

	select	@MaMH = @KyTuDau + @KyTuNam + @SoThuTu

	return @MaMH
 END
 GO

---------------------------------------

create proc ThemSuaXoa_MonHoc
	@mamh nchar(10) , @ten nvarchar(50), @sotc int, @ctdt int, @thaotac int
AS
BEGIN
	if @thaotac = 0 -- Thêm môn học mới
		begin
			set @mamh = dbo.TaoMaMH(@ten)

			insert into MonHoc (MaMH, TenMH, SoTC, MaCTĐT) values (@mamh, @ten, @sotc, @ctdt)
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
	if @mactdt = 0 -- Lấy toàn bộ danh sách môn học
		begin
			select	MaMH, TenMH, MaCTĐT, TenCTDT, SoTC
			from	MonHoc mh, ChuongTrinhDT ct
			where	mh.MaCTĐT = ct.MaCTDT
		end
	else if @mactdt > 0
		begin
			select	MaMH, TenMH, MaCTĐT, TenCTDT, SoTC
			from	MonHoc mh, ChuongTrinhDT ct
			where	mh.MaCTĐT = ct.MaCTDT and MaCTĐT = @mactdt
		end
END
GO

-- Thủ tục tính số sinh viên đăng ký một môn học
create proc TinhSoSV_DangKyMH	@mamh varchar(10), @kq int output
AS
BEGIN
	select	@kq = COUNT(MaSV)
	from	Hoc h
	where	LTRIM(RTRIM (h.MaMH)) = @mamh
END
GO

select * from MonHoc
select * from ChuongTrinhDT
create database QuanLyPhongKhachSan
go
use QuanLyPhongKhachSan
go

--------------------------------------
--	Các bảng của CSDL
--------------------------------------
create table HangPhong
(
	ID_HP			int	primary key	identity(1,1),
	HangPhong		nvarchar(50) not null,
	Gia				float not null,
	GiaGio			float not null,
	DienTich		float not null,
	DonViDT			nvarchar(50) not null,
	SucChuaToiDa	nvarchar(1000) not null,
	GhiChu			nvarchar(3000),
	KhaDung			tinyint not null
)
go

create table Tang
(
	ID_Tang		int	primary key	identity(1,1),
	Tang		nvarchar(50) not null,
	KhaDung		tinyint not null
)
go

create table Phong
(
	ID_Phong	int	primary key	identity(1,1),
	SoPhong		varchar(5)	not null,
	ID_HP		int references HangPhong(ID_HP)	not null,
	ID_Tang		int references Tang(ID_Tang) not null,
	MoTa		nvarchar(500),
	TrangThai	tinyint	not null,
	GhiChu		nvarchar(3000),
	KhaDung		tinyint	not null
)
go

create table KhachHang
(
	ID_KH		int	primary key	identity(1,1),
	TenKH		nvarchar(50) not null,
	GioiTinh	bit	not null,
	NgaySinh	smalldatetime not null,
	SDT			char(10) not null,
	Email		varchar(50),
	SoGiayTo	varchar(15) not null,
	GhiChu		nvarchar(3000),
	KhaDung		tinyint
)
go

create table ViTriLV
(
	ID_VT	int primary key identity(1,1),
	TenVT	nvarchar(50) not null,
	Luong	float not null,
	KhaDung	tinyint
)
go

create table NhanVien
(
	ID_NV		int primary key identity(1,1),
	TenNV		nvarchar(50) not null,
	SoCCCD		char(10) not null,
	GioiTinh	bit not null,
	NgaySinh	smalldatetime not null,
	NgayVaoLam	smalldatetime not null,
	SDT			char(10) not null,
	Email		varchar(100) not null,
	ID_VT		int references ViTriLV(ID_VT) not null,
	TenTK		nvarchar(50) not null,
	MatKhau		varchar(25) not null,
	GhiChu		nvarchar(3000),
	KhaDung		tinyint not null,
)
go

create table HoaDon
(
	ID_HD		int primary key identity(1,1),
	ID_NV		int references NhanVien(ID_NV) not null,
	ID_KH		int references KhachHang(ID_KH) not null,
	NgayLap		datetime not null,
	NgayToi		datetime not null,
	NgayDi		datetime not null,
	DatCoc		float,
	HinhThucThanhToan	tinyint not null,
	PhuThu		float,
	TrangThai	tinyint not null,
	TongTien	float not null,
	GhiChu		nvarchar(3000),
	KhaDung		tinyint not null,
)
go

create table CT_HD
(
	ID_CT			int primary key identity(1,1),
	ID_HD			int references HoaDon(ID_HD) not null,
	ID_Phong		int references Phong(ID_Phong) not null,
	Gia				float not null,
	ThoiGianThue	float not null,
	DonVi			nvarchar(5) not null,
	KhaDung			tinyint not null
)
go

------------------------- Các hàm và thủ tục -------------------------

CREATE PROC ThemXoaSua_HangPhong
	@id int output, @hangphong nvarchar(50), @gia float, @giagio float, @dientich float, 
	@donvidt nvarchar(50), @succhua nvarchar(1000), @ghichu nvarchar(3000), @action tinyint
AS
BEGIN
	if @action = 0
		begin
			insert into HangPhong (HangPhong, Gia, GiaGio, DienTich, DonViDT, SucChuaToiDa, GhiChu, KhaDung)
			values (@hangphong, @gia, @giagio, @dientich, @donvidt, @succhua, @ghichu, 0)
			select @id = SCOPE_IDENTITY();
		end
	else if @action = 1
		begin
			update HangPhong
			set 
				HangPhong = @hangphong, Gia = @gia, GiaGio = @giagio, DienTich = @dientich, 
				DonViDT = @donvidt, SucChuaToiDa = @succhua, GhiChu = @ghichu
			where ID_HP = @id
		end
	else if @action = 2
		begin
			update HangPhong
			set KhaDung = 1
			where ID_HP = @id
			
			update	Phong
			set		ID_HP = 0
			where	ID_HP = @id
		end
END
GO

CREATE PROC LayDSHangPhong
AS
BEGIN
	select	ID_HP, HangPhong, Gia, GiaGio, DienTich, DonViDT, SucChuaToiDa, GhiChu
	from	HangPhong
	where	KhaDung = 0
END
GO

CREATE PROC LayDSTang
AS
BEGIN
	select	ID_Tang, Tang
	from	Tang
	where	KhaDung = 0
END
GO

CREATE PROC ThemXoaSua_Tang		@id int output, @tang nvarchar(50), @action tinyint
AS
BEGIN
	if @action = 0
		begin
			insert into Tang (Tang, KhaDung) values (@tang, 0)
			select @id = SCOPE_IDENTITY();
		end
	else if @action = 1
		begin
			update	Tang
			set		Tang = @tang
			where	ID_Tang = @id
		end
	else if @action = 2
		begin
			update	Tang
			set		KhaDung = 1
			where	ID_Tang = @id

			update	Phong
			set		ID_Tang = 0
			where	ID_Tang = @id
		end
END
GO

CREATE PROC LayDSPhong
AS
BEGIN
	select	ID_Phong, SoPhong, HangPhong, Tang, MoTa, TrangThai, p.GhiChu
	from	Phong p, HangPhong hp, Tang t
	where	p.ID_HP = hp.ID_HP and p.ID_Tang = t.ID_Tang and p.KhaDung = 0
END
GO

CREATE PROC ThemXoaSua_Phong
	@id int output, @sophong varchar(5), @idhp int, @idtang int, @mota nvarchar(500), 
	@trangthai tinyint, @ghichu nvarchar(3000), @action tinyint
AS
BEGIN
	if @action = 0
		begin
			insert into Phong (SoPhong, ID_HP, ID_Tang, MoTa, TrangThai, GhiChu, KhaDung)
			values (@sophong, @idhp, @idtang, @mota, @trangthai, @ghichu, 0)
			select @id = SCOPE_IDENTITY();
		end
	else if @action = 1
		begin
			update Phong
			set
				SoPhong = @sophong,
				ID_HP = @idhp,
				ID_Tang = @idtang,
				MoTa = @mota,
				TrangThai = @trangthai,
				GhiChu = @ghichu
			where ID_Phong = @id
		end
	else if @action = 2
		begin
			update	Phong
			set		KhaDung = 1
			where	ID_Phong = @id
		end
END
GO

CREATE PROC LayDSKhachHang
AS
BEGIN
	select	ID_KH, TenKH, GioiTinh, NgaySinh, SDT,
			Email, SoGiayTo, GhiChu
	from	KhachHang
	where	KhaDung = 0
END
GO

CREATE PROC ThemXoaSua_KhachHang
	@id int output, @ten nvarchar(50), @gt bit, @ngaysinh smalldatetime, @sdt char(10),
	@email varchar(50), @sogiayto varchar(15), @ghichu nvarchar(3000), @action tinyint
AS
BEGIN
	if @action = 0
		begin
			insert into KhachHang (TenKH, GioiTinh, NgaySinh, SDT, Email, SoGiayTo, GhiChu, KhaDung) values
			(@ten, @gt, @ngaysinh, @sdt, @email, @sogiayto, @ghichu, 0)
			select @id = SCOPE_IDENTITY();
		end
	else if @action = 1
		begin
			update KhachHang
			set
				TenKH = @ten, GioiTinh = @gt, NgaySinh = @ngaysinh,
				SDT = @sdt,	Email = @email, SoGiayTo = @sogiayto, GhiChu = @ghichu
			where ID_KH = @id
		end
	else if @action = 2
		begin
			update	KhachHang
			set		KhaDung = 1
			where	ID_KH = @id
		end
END		
GO

CREATE PROC	LayDSViTriLV
AS
BEGIN
	select	ID_VT, TenVT, Luong
	from	ViTriLV
	where	KhaDung = 0
END
GO

CREATE PROC ThemXoaSua_ViTriLV	@id int output, @ten nvarchar(50), @luong float, @action tinyint
AS
BEGIN
	if @action = 0
		begin
			insert into ViTriLV (TenVT, Luong, KhaDung) values (@ten, @luong, 0)
			select @id = SCOPE_IDENTITY();
		end
	else if @action = 1
		begin
			update	ViTriLV
			set		TenVT = @ten, Luong = @luong
			where	ID_VT = @id
		end
	else if @action = 2
		begin
			update	ViTriLV
			set		KhaDung = 1
			where	ID_VT = @id

			update	NhanVien
			set		ID_VT = 0
			where	ID_VT = @id
		end
END
GO

CREATE PROC LayDSNhanVien
AS
BEGIN
	select	ID_NV, TenNV, SoCCCD, GioiTinh, NgaySinh, NgayVaoLam, SDT, Email, TenVT, TenTK
	from	NhanVien nv, ViTriLV vt
	where	nv.ID_VT = vt.ID_VT and nv.KhaDung = 0
END
GO

CREATE PROC ThemXoaSua_NhanVien
	@id int output, @ten nvarchar(50), @cccd char(10), @gt bit, @ngaysinh smalldatetime,
	@ngayvaolam smalldatetime, @sdt char(10), @email varchar(100), @idvt int,
	@tentk nvarchar(50), @matkhau varchar(25), @ghichu nvarchar(3000), @action tinyint
AS
BEGIN
	if @action = 0
		begin
			insert into NhanVien (TenNV, SoCCCD, GioiTinh, NgaySinh, NgayVaoLam, SDT, Email, ID_VT, TenTK, MatKhau, GhiChu, KhaDung)
			values (@ten, @cccd, @gt, @ngaysinh, @ngayvaolam, @sdt, @email, @idvt, @tentk, 'Hotel1', @ghichu, 0)
			select @id = SCOPE_IDENTITY();
		end
	else if @action = 1
		begin
			update NhanVien
			set
				TenNV = @ten, SoCCCD = @cccd, GioiTinh = @gt, NgaySinh = @ngaysinh,
				NgayVaoLam = @ngayvaolam, SDT = @sdt, Email = @email, ID_VT = @idvt,
				TenTK = @tentk, MatKhau = @matkhau, GhiChu = @ghichu
			where ID_NV = @id
		end
	else if @action = 2
		begin
			update	NhanVien
			set		KhaDung = 1
			where	ID_NV = @id
		end
END
GO

CREATE PROC CapNhatHoaDon
	@idhd int, @idnv int, @idkh int, @ngaylap datetime, @ngaytoi datetime, @ngaydi datetime,
	@datcoc float, @hinhthuctt tinyint, @trangthai tinyint, @phuthu float, @tongtien float, 
	@ghichu nvarchar(3000)
AS
BEGIN
	update HoaDon
	set
		ID_NV = @idnv, ID_KH = @idkh, NgayLap = @ngaylap, NgayToi = @ngaytoi, 
		NgayDi = @ngaydi, DatCoc = @datcoc, HinhThucThanhToan = @hinhthuctt,
		TrangThai = @trangthai, PhuThu = @phuthu, TongTien = @tongtien, GhiChu = @ghichu
	where ID_HD = @idhd

	if @@ERROR <> 0
		return 0
	else
		return 1
END
GO

CREATE PROC ThemXoa_HoaDon
	@id int output, @idnv int, @idkh int, @ngaylap datetime, @ngaytoi datetime, 
	@ngaydi datetime,@datcoc float, @hinhthuctt tinyint, @phuthu float, @tongtien float, 
	@ghichu nvarchar(3000), @action tinyint
AS
BEGIN
	if @action = 0
		begin
			insert into HoaDon (ID_NV, ID_KH, NgayLap, NgayToi, NgayDi, DatCoc, HinhThucThanhToan, PhuThu, TrangThai, TongTien, GhiChu, KhaDung)
			values (@idnv, @idkh, @ngaylap, @ngaytoi, @ngaydi, @datcoc, @hinhthuctt, @phuthu, 0, @tongtien, @ghichu, 0)
			select @id = SCOPE_IDENTITY();
		end
	else if @action = 1 -- Xoá hoá đơn
		begin
			delete from HoaDon where ID_HD = @id
		end
END
GO

CREATE PROC LayHDCuaKH		@idkh int
AS
BEGIN
	select	ID_HD, TenNV, NgayLap, NgayToi, NgayDi, DatCoc, HinhThucThanhToan, PhuThu, 
			TrangThai, TongTien, hd.GhiChu
	from	HoaDon hd, KhachHang kh, NhanVien nv
	where	hd.ID_NV = nv.ID_NV and hd.ID_KH = kh.ID_KH and hd.ID_KH = @idkh and hd.KhaDung = 0
END
GO

CREATE PROC LayDSHDCuaKH_Ngay	@idkh int, @ngaybd datetime, @ngaykt datetime
AS
BEGIN
	select	ID_HD, TenNV, NgayLap, NgayToi, NgayDi, DatCoc, HinhThucThanhToan, PhuThu, 
			TrangThai, TongTien, hd.GhiChu
	from	HoaDon hd, NhanVien nv, KhachHang kh
	where	hd.ID_NV = nv.ID_NV and hd.ID_KH = kh.ID_KH and
			hd.ID_KH = @idkh and NgayLap between @ngaybd and @ngaykt
END
GO

CREATE PROC LayHDCuaPhong	@idp int
AS
BEGIN
	select	hd.ID_HD, TenNV, TenKH, NgayLap, NgayToi, NgayDi, DatCoc, HinhThucThanhToan, PhuThu, 
			TrangThai, TongTien, hd.GhiChu 
	from	HoaDon hd, CT_HD ct, KhachHang kh, NhanVien nv
	where	hd.ID_HD = ct.ID_HD and hd.ID_KH = kh.ID_KH and nv.ID_NV = hd.ID_NV and ct.ID_Phong = @idp
END
GO

CREATE PROC LayCTHDCuaHD	@idhd int
AS
BEGIN
	select	ID_CT, ID_HD, ct.ID_Phong, SoPhong, Gia, ThoiGianThue, DonVi
	from	CT_HD ct, Phong p
	where	ct.ID_Phong = p.ID_Phong and ID_HD = @idhd and ct.KhaDung = 0
END
GO

CREATE FUNCTION TinhThoiGianThue (@ngaytoi datetime, @ngaydi datetime) RETURNS float
AS
BEGIN
	declare @tg float

	if (DATEDIFF(DAY, @ngaytoi, @ngaydi) >= 1)
		begin
			select	@tg = DATEDIFF(DAY, @ngaytoi, @ngaydi)

		end
	else if (DATEDIFF(DAY, @ngaytoi, @ngaydi) < 1 and DATEDIFF(DAY, @ngaytoi, @ngaydi) >= 0)
		begin
			select	@tg =  ROUND(DATEDIFF(SECOND, @ngaytoi, @ngaydi) / 3600.0, 2)
		end

	return @tg
END
GO

CREATE FUNCTION LayGiaPhong (@ngaytoi datetime, @ngaydi datetime, @idp int) RETURNS float
AS
BEGIN
	declare @gia float

	if (DATEDIFF(DAY, @ngaytoi, @ngaydi) >= 1)
		begin
			select	@gia = Gia
			from	Phong p, HangPhong h
			where	ID_Phong = @idp and p.ID_HP = h.ID_HP
		end
	else if (DATEDIFF(DAY, @ngaytoi, @ngaydi) < 1 and DATEDIFF(DAY, @ngaytoi, @ngaydi) >= 0)
		begin
			select	@gia = GiaGio
			from	Phong p, HangPhong h
			where	ID_Phong = @idp and p.ID_HP = h.ID_HP
		end

	return @gia
END
GO

CREATE FUNCTION LayDVTThoiGian (@ngaytoi datetime, @ngaydi datetime) RETURNS nvarchar(5)
AS
BEGIN
	declare @dvt nvarchar(5)

	if (DATEDIFF(DAY, @ngaytoi, @ngaydi) >= 1)
		begin
			select	@dvt = N'ngày'

		end
	else if (DATEDIFF(DAY, @ngaytoi, @ngaydi) < 1 and DATEDIFF(DAY, @ngaytoi, @ngaydi) >= 0)
		begin
			select	@dvt = N'giờ'
		end

	return @dvt
END
GO


CREATE PROC ThemXoa_CTHD
	@idct int output, @idhd int, @idp int, @action tinyint
AS
BEGIN
	declare @tgThue float
	declare @gia float
	declare @dvt nvarchar(5)

	select	@tgThue = dbo.TinhThoiGianThue(NgayToi, NgayDi)
	from	HoaDon
	where	ID_HD = @idhd

	select	@gia = dbo.LayGiaPhong(NgayToi, NgayDi, @idp)
	from	HoaDon
	where	ID_HD = @idhd

	select	@dvt = dbo.LayDVTThoiGian(NgayToi, NgayDi)
	from	HoaDon
	where	ID_HD = @idhd

	if @action = 0 -- Thêm chi tiết hoá đơn
		begin
			insert into CT_HD (ID_HD, ID_Phong, Gia, ThoiGianThue, Donvi, KhaDung) 
			values (@idhd, @idp, @gia, @tgThue, @dvt, 0)
			select @idct = SCOPE_IDENTITY();
		end
	if @action = 1 -- Cập nhật chi tiết hoá đơn
		begin
			update CT_HD
			set
				ID_HD = @idhd,
				ID_Phong = @idp,
				Gia = @gia,
				ThoiGianThue = @tgThue,
				DonVi = @dvt
		end
	else if @action = 2 -- Xoá chi tiết hoá đơn
		begin
			delete from CT_HD where ID_CT = @idct
		end
END
GO

CREATE PROC LayHDCuaPhong_Ngay	@idp int, @ngaybd datetime, @ngaykt datetime
AS
BEGIN
	select	hd.ID_HD, TenNV, TenKH, NgayLap, NgayToi, NgayDi, DatCoc, HinhThucThanhToan, PhuThu, 
			TrangThai, TongTien, hd.GhiChu 
	from	HoaDon hd, CT_HD ct, KhachHang kh, NhanVien nv
	where	hd.ID_HD = ct.ID_HD and hd.ID_KH = kh.ID_KH and nv.ID_NV = hd.ID_NV and
			ct.ID_Phong = @idp and NgayLap between @ngaybd and @ngaykt
END
GO

WITH HoaDonTrongKhoang AS (
                SELECT 
                    HD.ID_HD, 
                    HD.ID_NV, 
                    NV.TenNV, 
                    HD.ID_KH, 
                    KH.TenKH, 
                    HD.NgayLap, 
                    HD.NgayToi, 
                    HD.NgayDi, 
                    HD.DatCoc, 
                    HD.HinhThucThanhToan, 
                    HD.PhuThu, 
                    HD.TrangThai, 
                    HD.TongTien, 
                    HD.GhiChu
                FROM 
                    HoaDon AS HD
                INNER JOIN 
                    NhanVien AS NV ON HD.ID_NV = NV.ID_NV
                INNER JOIN 
                    KhachHang AS KH ON HD.ID_KH = KH.ID_KH
                WHERE 
                    (HD.NgayToi <= @NgayKetThuc) AND (HD.NgayDi >= @NgayBatDau)
            )
            SELECT 
                P.ID_Phong,
                P.SoPhong,
                HP.HangPhong
            FROM 
                Phong AS P
            INNER JOIN 
                HangPhong AS HP ON P.ID_HP = HP.ID_HP
            WHERE 
                P.KhaDung = 1
                AND NOT EXISTS (
                    SELECT 1
                    FROM HoaDonTrongKhoang AS HD
                    INNER JOIN CT_HD AS CTHD ON HD.ID_HD = CTHD.ID_HD
                    WHERE CTHD.ID_Phong = P.ID_Phong
                )
            ORDER BY 
                P.SoPhong;"

insert into HangPhong (HangPhong, Gia, GiaGio, DienTich, DonViDT, SucChuaToiDa, GhiChu, KhaDung)
values	(N'Phòng đơn', 220000, 70000, 20, N'mét vuông', N'Một người lớn và một trẻ em', '', 0),
		(N'Phòng đôi', 270000, 85000, 25, N'mét vuông', N'Hai người lớn và một trẻ em', '', 0),
		(N'Phòng ba', 300000, 95000, 30, N'mét vuông', N'Ba người lớn và hai trẻ em', '', 0),
		(N'Phòng bốn', 350000, 100000, 40, N'mét vuông', N'Bốn người lớn và ba trẻ em', '', 0)
go

insert into Tang (Tang, KhaDung) 
values	(N'Tầng 1', 0), (N'Tâng 2', 0), (N'Tầng 3', 0), (N'Tầng 4', 0)
go

insert into Phong (SoPhong, ID_HP, ID_Tang, MoTa, TrangThai, GhiChu, KhaDung)
values	(N'P101', 1, 1, N'View hướng phố', 0, '', 0),
		(N'P102', 2, 1, N'View hướng ra hồ Xuân Hương; Có ban công', 1, '', 0),
		(N'P103', 1, 1, N'View hướng phố', 1, '', 0),
		(N'P104', 3, 1, N'View hướng ra hồ Xuân Hương; Có ban công; Có ghế sofa', 0, '', 0),
		(N'P105', 2, 1, N'View hướng phố; Có bàn trà', 2, '', 0),
		(N'P106', 1, 1, N'View hướng ra hồ Xuân Hương; Có ban công', 0, '', 0),
		(N'P107', 4, 1, N'View hướng phố; Có bàn trà; Có ghế sofa', 0, '', 0),
		(N'P108', 4, 1, N'View hướng ra hồ Xuân Hương; Có ban công; Có ghế sofa', 1, '', 0),
		(N'P109', 1, 1, N'View hướng phố', 1, '', 0),
		(N'P110', 2, 1, N'View hướng ra hồ Xuân Hương; Có ban công', 0, '', 0),
		(N'P201', 2, 2, N'View hướng phố', 2, '', 0),
		(N'P202', 2, 2, N'View hướng ra hồ Xuân Hương; Có ban công', 3, N'Phòng đang bị hỏng lan can', 0),
		(N'P203', 3, 2, N'View hướng phố; Có ghế sofa', 1, '', 0),
		(N'P204', 3, 2, N'View hướng ra hồ Xuân Hương; Có ban công; Có ghế sofa', 1, '', 0),
		(N'P205', 1, 1, N'View hướng phố; Có bàn trà', 3, N'Máy sấy tóc của phòng bị mất', 0),
		(N'P206', 1, 1, N'View hướng ra hồ Xuân Hương; Có ban công', 0, '', 0),
		(N'P301', 3, 3, N'View hướng phố; Có ghế sofa', 1, '', 0),
		(N'P302', 3, 3, N'View hướng ra hồ Xuân Hương; Có ban công; Có ghế sofa', 0, '', 0),
		(N'P303', 4, 3, N'View hướng phố; Có ghế sofa; Có bàn trà', 2, '',0),
		(N'P304', 4, 3, N'View hướng ra hồ Xuân Hương; Có ban công; Có ghế sofa', 3, '', 0),
		(N'P305', 2, 3, N'View hướng phố; Có bàn trà', 0, '', 0),
		(N'P401', 4, 4, N'View hướng phố; Có ghế sofa; Có bàn trà', 0, '', 0),
		(N'P402', 4, 4, N'View hướng ra hồ Xuân Hương; Có ban công; Có ghế sofa', 1, '', 0),
		(N'P403', 4, 4, N'View hướng phố; Có ghế sofa; Có bàn trà', 2, '', 0),
		(N'P404', 4, 4, N'View hướng ra hồ Xuân Hương; Có ban công; Có ghế sofa', 3, '', 0)
go

set dateformat dmy
go
insert into KhachHang (TenKH, GioiTinh, NgaySinh, SDT, Email, SoGiayTo, GhiChu, KhaDung)
values	(N'Hồ Văn Nguyên', 1, '10/10/2002', '0924100000', 'nguyenhv@gmail.com', '1000000001', '', 0),
		(N'Nguyễn Xuân Thắng', 1, '12/05/2003','0364100001', '', '1000000002', N'Yêu cầu kê thêm giường', 0),
		(N'Nguyễn Thị Kim Thuỳ', 0, '06/02/2001','0984100003', '', '2123996521', '', 0),
		(N'Nguyễn Hoàng Anh', 1, '20/02/1999', '0724100004', 'anhnh@gmail.gmail', '2130001001', '', 0),
		(N'Lê Thuỳ Lan Chi', 0, '12/07/2000', '0984100005', '', '2130001002', '', 0),
		(N'Hứa Duy Băng', 1, '30/12/2006','0324100004', '', '1000000010', '', 0)
go

insert into ViTriLV (TenVT, Luong, KhaDung)
values	(N'Quản lý', 10000000, 0),
		(N'Lễ tân', 5000000, 0),
		(N'Admin', 7000000, 1)
go

set dateformat dmy
go
insert into NhanVien (TenNV, SoCCCD, GioiTinh, NgaySinh, NgayVaoLam, SDT, Email, ID_VT, TenTK, MatKhau, KhaDung)
values	(N'Nguyễn Đức Duy Ân', '202411001', 1, '10/07/2002', '10/09/2023', '0624000011', 'ducannd@gmail.com', 1, 'DuyAn107', 'Hotel1', 0),
		(N'Võ Thị Thu Ngân', '202411002', 0, '24/05/2001', '10/10/2022', '0324100009', 'thunganvt@gmail.com', 1, 'ThuNgan24', 'Hotel1', 0),
		(N'Nguyễn Quốc Anh', '202412001', 1, '18/01/2003', '20/07/2023', '0924100011', 'anhnq@gmail.com', 2, 'Anh181', 'Hotel1',0),
		(N'Vũ Thiên Quân', '202412002', 1, '09/09/2002', '15/12/2022', '0728409910', 'quanvt@gmail.com', 2, 'Quan02', 'Hotel1', 0),
		(N'Nguyễn Thảo Quỳnh', '202412003', 0, '16/06/2004', '13/07/2024', '0314765524', 'quynhnt@gmail.com', 2, 'Quynh16', 'Hotel1', 0),
		(N'Nguyễn Ngọc Tuyết', '202412004', 0, '09/08/2001', '18/10/2022', '0423312789', 'tuyetngn@gmail.com', 2, 'Tuyet18', 'Hotel1',0)
go

set dateformat dmy
go
insert into HoaDon (ID_NV, ID_KH, NgayLap, NgayToi, NgayDi, DatCoc, HinhThucThanhToan, PhuThu, TrangThai, TongTien, GhiChu, KhaDung)
values	(3, 1, '11/05/2023 12:00', '11/05/2023 12:00', '13/05/2023 12:00', 0, 1, 0, 1, 0, '', 0),
		(4, 2, '10/10/2023 13:30', '12/10/2023 12:30', '16/10/2023 12:30', 50000, 1, 20000, 1, 0, N'Có thêm một trẻ em', 0),
		(6, 6, '20/01/2024 07:30', '20/01/2024 07:30', '20/01/2024 10:30', 0, 0, 0, 1, 0, '', 0),
		(5, 5, '12/02/2024 13:30', '14/02/2024 13:00', '19/02/2024 13:00', 50000, 0, 0, 1, 0, '', 0),
		(4, 1, '14/02/2024 08:00', '14/02/2024 08:00', '14/02/2024 12:30', 0, 1, 0, 1, 0, '', 0),
		-- Hoá đơn phòng có người ở
		(6, 3, '09/11/2024 15:15:15', '09/11/2024 15:15:15', '11/11/2024 15:15:15', 0, 0, 0, 0, 0, '', 0),
		(5, 2, '08/11/2024 12:30:20', '08/11/2024 12:30:20', '10/11/2024 12:30:00', 0, 0, 20000, 0, 0, N'Khách có yêu cầu kê thêm giường', 0),
		(3, 4, '07/11/2024 17:00:00', '07/11/2024 17:00:00', '12/11/2024 17:00:00', 0, 0, 0, 0, 0, '', 0),
		-- Hoá đơn phòng đặt trước
		(4, 3, '06/11/2024 10:30:30', '20/11/2024 13:30:00', '23/11/2024 13:30:00', 50000, 0, 0, 0, 0, '', 0),
		(3, 1, '10/11/2024 09:00:00', '10/12/2024 09:30:00', '14/12/2024 09:30:00', 50000, 1, 0, 0, 0, '', 0)
go

insert into CT_HD (ID_HD, ID_Phong, Gia, ThoiGianThue, DonVi, KhaDung)
values	(1, 1, 0, 0, '', 0), (1, 4, 0, 0, '', 0),
		(2, 19, 0, 0, '', 0), 
		(3, 12, 0, 0, '', 0), (3, 5, 0, 0, '', 0), (3, 3, 0, 0, '', 0),
		(4, 20, 0, 0, '', 0), (4, 21, 0, 0, '', 0), 
		(5, 15, 0, 0, '', 0), (5, 16, 0, 0, '', 0), (5, 17, 0, 0, '', 0), (5, 18, 0, 0, '', 0),
		(6, 2, 0, 0, '', 0), (6, 8, 0, 0, '', 0),
		(7, 3, 0, 0, '', 0), (7, 9, 0, 0, '', 0), (7, 23, 0, 0, '', 0),
		(8, 14, 0, 0, '', 0), (8, 17, 0, 0, '', 0), (8, 13, 0, 0, '', 0),
		(9, 5, 0, 0, '', 0), (9, 11, 0, 0, '', 0),
		(10, 19, 0, 0, '', 0), (10, 24, 0, 0, '', 0)
go

update CT_HD 
set
	Gia = dbo.LayGiaPhong(NgayToi, NgayDi, ID_Phong),
	ThoiGianThue = dbo.TinhThoiGianThue(NgayToi, NgayDi),
	DonVi = dbo.LayDVTThoiGian(NgayToi, NgayDi)
from	HoaDon hd
where	CT_HD.ID_HD = hd.ID_HD

go

create function TinhTongTien (@idhd int) returns float
AS
Begin
	declare @tong float

	select	@tong = SUM(Gia * ThoiGianThue) + PhuThu
	from	HoaDon hd, CT_HD ct
	where	hd.ID_HD = @idhd and ct.ID_HD = @idhd
	group by	hd.ID_HD, Gia, ThoiGianThue, PhuThu

	return @tong
END
GO

update	HoaDon
set		TongTien = dbo.TinhTongTien(ID_HD)

exec LayDSHangPhong 
exec LayDSTang 
exec LayDSPhong 
exec LayDSKhachHang 
exec LayDSViTriLV 
exec LayDSNhanVien 
select * from HoaDon 
select * from CT_HD
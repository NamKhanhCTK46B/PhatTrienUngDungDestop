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
	DonViDT			nvarchar not null,
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
	SoPhong		nvarchar(5)	not null,
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
	ID_CT		int primary key identity(1,1),
	ID_HD		int references HoaDon(ID_HD) not null,
	ID_Phong	int references Phong(ID_Phong) not null,
	Gia			float not null,
	SoNgay		tinyint not null,
	KhaDung		tinyint not null
)
go

------------------------- Các hàm và thủ tục -------------------------
CREATE PROC ThemHangPhong
	@id int output, @hangphong nvarchar(50), @gia float, @giagio float, @dientich float, 
	@donvidt nvarchar(50), @succhua nvarchar(1000), @ghichu nvarchar(3000)
AS
BEGIN
	insert into HangPhong (HangPhong, Gia, GiaGio, DienTich, DonViDT, SucChuaToiDa, GhiChu, KhaDung)
	values (@hangphong, @gia, @giagio, @dientich, @donvidt, @succhua, @ghichu, 0)
	
	select @id = SCOPE_IDENTITY();
END
GO

CREATE PROC CapNhatHangPhong
	@id int, @hangphong nvarchar(50), @gia float, @giagio float, @dientich float, 
	@donvidt nvarchar(50), @succhua nvarchar(1000), @ghichu nvarchar(3000)
AS
BEGIN
	update HangPhong
	set 
		HangPhong = @hangphong,
		Gia = @gia,
		GiaGio = @giagio,
		DienTich = @dientich,
		DonViDT = @donvidt,
		SucChuaToiDa = @succhua,
		GhiChu = @ghichu
	where ID_HP = @id

	if @@ERROR <> 0
		return 0
	else
		return 1
END
GO

CREATE PROC XoaHangPhong	 @id int
AS
BEGIN
	update HangPhong
	set KhaDung = 1
	where ID_HP = @id
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

CREATE PROC ThemTang	@id int output, @tang nvarchar(50), @khaDung tinyint
AS
BEGIN
	insert into Tang (Tang, KhaDung) values (@tang, 0)
	
	select @id = SCOPE_IDENTITY();
END
GO

CREATE PROC CapNhatTang		@id int, @tang nvarchar(50)
AS
BEGIN
	update	Tang
	set		Tang = @tang
	where	ID_Tang = @id

	if @@ERROR <> 0
		return 0
	else
		return 1
END
GO

CREATE PROC XoaTang		@id int
AS
BEGIN
	update	Tang
	set		KhaDung = 1
	where	ID_Tang = @id
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

CREATE PROC ThemPhong
	@id int output, @sophong nvarchar(5), @idhp int, @idtang int,
	@mota nvarchar(500), @trangthai tinyint, @ghichu nvarchar(3000)
AS
BEGIN
	insert into Phong (SoPhong, ID_HP, ID_Tang, MoTa, TrangThai, GhiChu, KhaDung) values 
	(@sophong, @idhp, @idtang, @mota, @trangthai, @ghichu, 0)
	
	select @id = SCOPE_IDENTITY();
END
GO

CREATE PROC CapNhatPhong
	@id int, @sophong nvarchar(5), @idhp int, @idtang int,
	@mota nvarchar(500), @trangthai tinyint, @ghichu nvarchar(3000)
AS
BEGIN
	update Phong
	set
		SoPhong = @sophong,
		ID_HP = @idhp,
		ID_Tang = @idtang,
		MoTa = @mota,
		TrangThai = @trangthai,
		GhiChu = @ghichu
	where ID_Phong = @id

	if @@ERROR <> 0
		return 0
	else
		return 1
END
GO

CREATE PROC XoaPhong	@id int
AS
BEGIN
	update	Phong
	set		KhaDung = 1
	where	ID_Phong = @id
END
GO

CREATE PROC LayDSKhachHang
AS
BEGIN
	select	ID_KH, TenKH, GioiTinh, CONVERT(char(10),NgaySinh, 103) as NgaySinh, SDT,
			Email, SoGiayTo, GhiChu
	from	KhachHang
	where	KhaDung = 0
END
GO

CREATE PROC ThemKhachHang
	@id int output, @ten nvarchar(50), @gt bit, @ngaysinh smalldatetime, @sdt char(10),
	@email varchar(50), @sogiayto varchar(15), @ghichu nvarchar(3000)
AS
BEGIN
	insert into KhachHang (TenKH, GioiTinh, NgaySinh, SDT, Email, SoGiayTo, GhiChu, KhaDung) values
	(@ten, @gt, @ngaysinh, @sdt, @email, @sogiayto, @ghichu, 0)

	select @id = SCOPE_IDENTITY();
END
GO

CREATE PROC CapNhatKhachHang
	@id int, @ten nvarchar(50), @gt bit, @ngaysinh smalldatetime, @sdt char(10),
	@email varchar(50), @sogiayto varchar(15), @gc nvarchar(3000)
AS
BEGIN
	update KhachHang
	set
		TenKH = @ten,
		GioiTinh = @gt,
		NgaySinh = @ngaysinh,
		SDT = @sdt,
		Email = @email,
		SoGiayTo = @sogiayto,
		GhiChu = @gc
	where ID_KH = @id

	if @@ERROR <> 0
		return 0
	else
		return 1
END
GO

CREATE PROC XoaKhachHang	@id int
AS
BEGIN
	update	KhachHang
	set		KhaDung = 1
	where	ID_KH = @id
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

CREATE PROC ThemViTriLV		@id int output, @ten nvarchar(50), @luong float
AS
BEGIN
	insert into ViTriLV (TenVT, Luong, KhaDung) values (@ten, @luong, 0)

	select @id = SCOPE_IDENTITY();
END
GO

CREATE PROC CapNhatViTriLV		@id int output, @ten nvarchar(50), @luong float
AS
BEGIN
	update ViTriLV
	set
		TenVT = @ten,
		Luong = @luong
	where	ID_VT = @id

	if @@ERROR <> 0
		return 0
	else
		return 1
END
GO

CREATE PROC XoaViTriLV	@id int
AS
BEGIN
	update	ViTriLV
	set		KhaDung = 1
	where	ID_VT = @id
END
GO

CREATE PROC LayDSNhanVien
AS
BEGIN
	select	ID_NV, TenNV, SoCCCD, GioiTinh, NgaySinh, NgayVaoLam, SDT, Email, ID_VT, TenTK
	from	NhanVien
	where	KhaDung = 0
END
GO

CREATE PROC ThemNhanVien
	@id int output, @ten nvarchar(50), @cccd char(10), @gt bit, @ngaysinh smalldatetime,
	@ngayvaolam smalldatetime, @sdt char(10), @email varchar(100), @idvt int,
	@tentk nvarchar(50), @matkhau varchar(25), @ghichu nvarchar(3000)
AS
BEGIN
	insert into NhanVien (TenNV, SoCCCD, GioiTinh, NgaySinh, NgayVaoLam, SDT, Email, ID_VT, TenTK, MatKhau, GhiChu, KhaDung)
	values (@ten, @cccd, @gt, @ngaysinh, @ngayvaolam, @sdt, @email, @idvt, @tentk, 'Hotel1', @ghichu, 0)

	select @id = SCOPE_IDENTITY();
END
GO

CREATE PROC CapNhatNhanVien
	@id int, @ten nvarchar(50), @cccd char(10), @gt bit, @ngaysinh smalldatetime,
	@ngayvaolam smalldatetime, @sdt char(10), @email varchar(100), @idvt int,
	@tentk nvarchar(50), @matkhau varchar(25), @ghichu nvarchar(3000)
AS
BEGIN
	update NhanVien
	set
		TenNV = @ten,
		SoCCCD = @cccd,
		GioiTinh = @gt,
		NgaySinh = @ngaysinh,
		NgayVaoLam = @ngayvaolam,
		SDT = @sdt,
		Email = @email,
		ID_VT = @idvt,
		TenTK = @tentk,
		MatKhau = @matkhau,
		GhiChu = @ghichu
	where ID_NV = @id
END
GO

CREATE PROC XoaNhanVien		@id int
AS
BEGIN
	update	NhanVien
	set		KhaDung = 1
	where	ID_NV = @id
END
GO

CREATE PROC	ThemHoaDon
	@id int output, @idnv int, @idkh int, @ngaylap datetime, @ngaytoi datetime, @ngaydi datetime,
	@datcoc float, @hinhthuctt tinyint, @phuthu float, @tongtien float, @ghichu nvarchar(3000)
AS
BEGIN
	insert into HoaDon (ID_NV, ID_KH, NgayLap, NgayToi, NgayDi, DatCoc, HinhThucThanhToan, PhuThu, TrangThai, TongTien, GhiChu, KhaDung)
	values (@idnv, @idkh, @ngaylap, @ngaytoi, @ngaydi, @datcoc, @hinhthuctt, @phuthu, 0, @tongtien, @ghichu, 0)

	select @id = SCOPE_IDENTITY();
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
		ID_NV = @idnv,
		ID_KH = @idkh,
		NgayLap = @ngaylap,
		NgayToi = @ngaytoi,
		NgayDi = @ngaydi,
		DatCoc = @datcoc,
		HinhThucThanhToan = @hinhthuctt,
		TrangThai = @trangthai,
		PhuThu = @phuthu,
		TongTien = @tongtien,
		GhiChu = @ghichu
	where ID_HD = @idhd

	if @@ERROR <> 0
		return 0
	else
		return 1
END
GO

CREATE PROC XoaHD	@id int
AS
BEGIN
	update	HoaDon
	set		KhaDung = 1
	where	ID_HD = @id
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

CREATE PROC LayHDCuaPhong	@idp int
AS
BEGIN
	select	hd.ID_HD, TenNV, TenKH, NgayLap, NgayToi, NgayDi, DatCoc, HinhThucThanhToan, PhuThu, 
			TrangThai, TongTien, hd.GhiChu 
	from	HoaDon hd, CT_HD ct, KhachHang kh, NhanVien nv
	where	hd.ID_HD = ct.ID_HD and hd.ID_KH = kh.ID_KH and nv.ID_NV = hd.ID_NV and ct.ID_Phong = @idp
END
GO

CREATE PROC ThemCTHD
	@idct int output, @idhd int, @idp int, @gia float, @songay tinyint
AS
BEGIN
	insert into CT_HD (ID_HD, ID_Phong, Gia, SoNgay) values (@idhd, @idp, @gia, @songay)

	select @idct = SCOPE_IDENTITY();
END
GO

CREATE PROC CapNhatCTHD
	@idct int , @idhd int, @idp int, @gia float, @songay tinyint
AS
BEGIN
	update CT_HD
	set
		ID_HD = @idhd,
		ID_Phong = @idp,
		Gia = @gia,
		SoNgay = @songay
	where ID_CT = @idct

	if @@ERROR <> 0
		return 0
	else
		return 1
END
GO

CREATE PROC LayDSCTHDCuaHD	@idhd int
AS
BEGIN
	select	ID_CT, ID_HD, SoPhong, Gia, SoNgay
	from	CT_HD ct, Phong p
	where	ct.ID_Phong = p.ID_Phong and ID_HD = @idhd and ct.KhaDung = 0
END
GO
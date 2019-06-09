create database QLBD
use QLBD

--- Bảng Đội Bóng ---
create table doibong(
	MaDoiBong char(4) primary key,
	TenDoiBong nvarchar not null,
	SoLuongCauThu int,
	SoCauThuNgoai int,
	TenSanNha nvarchar(100)
)

--- Bảng Cầu Thủ ---
create table cauthu(
	MaCauThu char(4) primary key,
	TenCauThu nvarchar not null,
	NgaySinh smalldatetime,
	GhiChu nvarchar(200),
	TongSoBT int,
	TuoiCauThu int,
	MaLoaiCT char(4),
	MaDoiBong char(4)
)	

--- Bảng Loại Cầu Thủ ---
create table loaicauthu(
	MaLoaiCT char(4) primary key,
	LoaiCauThu nvarchar(200) not null

)

--- Bảng Vòng Thi Đấu ---
create table vongthidau(
	MaVongDau char(4) primary key,
	TenVongDau nvarchar(200) not null

)

--- Bảng Trận Đấu ---
create table trandau(
	MaTranDau char(4) primary key,
	MaDoiNha char(4),
	MaDoiKhach char(4),
	ThoiGian smalldatetime,
	MaVongDau char(4)

)

--- Bảng Kết Quả Trận Đấu ---
create table ketquatrandau(
	MaKetQua char(4) primary key,
	SoBTDoiNha int,
	SoBTDoiKhach int,
	MaTranDau char(4)

)

--- Bảng Bàn Thắng ---
create table banthang(
	MaBanThang char(4) primary key,
	MaKetQua char(4),
	MaCauThu char(4),
	MaLoaiBT char(4),
	ThoiDiem int

)

--- Bảng Loại Bàn Thắng ---
create table loaibanthang(
	MaLoaiBT char(4) primary key,
	TenLoaiBT nvarchar(200)

)

--- Bảng Bảng Xếp Hạng ---
create table bangxephang(
	MaBXH char(4) primary key,
	NgayGio smalldatetime

)

--- Bảng Chi Tiết BXH ---
create table chitietBXH(
	MaCTBXH char(4) primary key,
	MaDoiBong char(4),
	MaBXH char(4),
	Thang int,
	Hoa int,
	Thua int,
	HieuSo int,
	Diem int,
	Hang int,
	TongSBT int

)
--- bảng tham số ---
create table ThamSo(
	TuoiCTMin int,
	TuoiCTMax int,
	SoLuongCTMin int,
	SoLuongCTMax int,
	SoCTNgoaiMax int,
	TGGhiBanMax int
)
---khóa ngoại bảng cầu thủ ---
alter table cauthu add constraint CT_DB_FK foreign key (MaDoiBong) references doibong (MaDoiBong) 
alter table cauthu add constraint CT_LCT_FK foreign key (MaLoaiCT) references loaicauthu (MaLoaiCT)
--- khóa ngoại bảng trận đấu ---
alter table trandau add constraint TD_DB_FK1 foreign key (MaDoiNha) references doibong (MaDoiBong)
alter table trandau add constraint TD_DB_FK2 foreign key (MaDoiKhach) references doibong (MaDoiBong)
alter table trandau add constraint TD_VTD_FK foreign key (MaVongDau) references vongthidau (MaVongDau)
--- khóa ngoại bảng kết quả trận đấu ---
alter table ketquatrandau add constraint KQ_TD_FK foreign key (MaTranDau) references trandau (MaTranDau)
--- khóa ngoại bảng bàn thắng ---
alter table banthang add constraint BT_KQ_FK foreign key (MaKetQua) references ketquatrandau (MaKetQua)
alter table banthang add constraint BT_CT_FK foreign key (MaCauThu) references cauthu (MaCauThu)
alter table banthang add constraint BT_LBT_FK foreign key (MaLoaiBT) references loaibanthang (MaLoaiBT)
--- khóa ngoại bảng CTBXH ---
alter table chitietBXH add constraint CTBXH_BXH_FK foreign key (MaBXH) references bangxephang (MaBXH)
alter table chitietBXH add constraint CTBXH_DB_FK foreign key (MaDoiBong) references doibong (MaDoiBong)
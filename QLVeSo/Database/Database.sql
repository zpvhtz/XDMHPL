CREATE DATABASE QLVeSo
GO
--
USE QLVeSo
GO

--TABLE--
CREATE TABLE DaiLy
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	MaDaiLy VARCHAR(10) UNIQUE NOT NULL,
	Ten NVARCHAR(100),
	DiaChi NVARCHAR(200),
	DienThoai VARCHAR(12),
	TinhTrang NVARCHAR(20)
)

CREATE TABLE LoaiVeSo
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	MaLoaiVeSo VARCHAR(10) UNIQUE NOT NULL,
	Tinh NVARCHAR(50),
	TinhTrang NVARCHAR(20)
)

CREATE TABLE DangKy
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	IdDaiLy UNIQUEIDENTIFIER NOT NULL, --FK--
	NgayDangKy DATE,
	SoLuong INT
)

CREATE TABLE PhanPhoi
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	IdDaiLy UNIQUEIDENTIFIER NOT NULL, --FK--
	IdLoaiVeSo UNIQUEIDENTIFIER NOT NULL, --FK--
	Ngay DATE,
	SoLuongGiao INT,
	SoLuongBan INT
)

CREATE TABLE Giai
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	MaGiai VARCHAR(10) UNIQUE NOT NULL,
	GiaiThuong FLOAT
)

CREATE TABLE KetQuaXoSo
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	MaKetQua VARCHAR(10) UNIQUE NOT NULL,
	IdLoaiVeSo UNIQUEIDENTIFIER NOT NULL, --FK--
	Ngay DATE,
	IdGiai UNIQUEIDENTIFIER NOT NULL, --FK--
	SoTrung VARCHAR(20)
)

CREATE TABLE CongNo
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	MaCongNo VARCHAR(10) UNIQUE NOT NULL,
	IdDaiLy UNIQUEIDENTIFIER NOT NULL, --FK--
	Ngay DATE,
	TongTien FLOAT
)

CREATE TABLE PhieuThu
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	MaPhieuThu VARCHAR(10) UNIQUE NOT NULL,
	IdDaiLy UNIQUEIDENTIFIER NOT NULL, --FK--
	Ngay DATE,
	TongTien FLOAT
)
--CONSTRAINT--
ALTER TABLE DangKy
	ADD
		CONSTRAINT FK_DangKy_DaiLy_IdDaiLy FOREIGN KEY (IdDaiLy) REFERENCES DaiLy(Id)
GO

ALTER TABLE PhanPhoi
	ADD
		CONSTRAINT FK_PhanPhoi_LoaiVeSo_IdLoaiVeSo FOREIGN KEY (IdLoaiVeSo) REFERENCES LoaiVeSo(Id),
		CONSTRAINT FK_PhanPhoi_DaiLy_IdDaiLy FOREIGN KEY (IdDaiLy) REFERENCES DaiLy(Id)

ALTER TABLE KetQuaXoSo
	ADD
		CONSTRAINT FK_KetQuaXoSo_LoaiVeSo_IdLoaiVeSo FOREIGN KEY (IdLoaiVeSo) REFERENCES LoaiVeSo(Id),
		CONSTRAINT FK_KetQuaXoSo_Giai_IdGiai FOREIGN KEY (IdGiai) REFERENCES Giai(Id)

ALTER TABLE CongNo
	ADD
		CONSTRAINT FK_CongNo_DaiLy_IdDaiLy FOREIGN KEY (IdDaiLy) REFERENCES DaiLy(Id)

ALTER TABLE PhieuThu
	ADD
		CONSTRAINT FK_PhieuThu_DaiLy_IdDaiLy FOREIGN KEY (IdDaiLy) REFERENCES DaiLy(Id)

--ADD DATA--
INSERT INTO LoaiVeSo
	VALUES('ee5a75e6-89c5-461e-b11b-d3e23d78f550', 'VSBT', N'Bến Tre', N'Không khoá'),
		  ('730d0c60-2546-4854-b88a-6ddfbfe11cbb', 'VSLA', N'Long An', N'Không khoá'),
	      ('570b0397-2061-4add-8563-2e965322cf01', 'VSCM', N'Cà Mau', N'Không khoá'),
		  ('cc3cf4fe-9665-4c5f-ada5-c1d14bdd8b78', 'VSVT', N'Vũng Tàu', N'Không khoá'),
		  ('4e8b9ef4-cbff-40d5-ae44-2ff4f3c6bbfb', 'VSCT', N'Cần Thơ', N'Không khoá'),
		  ('5469fda6-ae0f-4772-9bec-757a2ae4245f', 'VSBL', N'Bạc Liêu', N'Không khoá'),
		  ('0219a36f-e572-4921-ad4e-c920ff75cf23', 'VSVL', N'Vĩnh Long', N'Không khoá'),
		  ('543571f0-c178-4f29-a7c9-603be01d1a8a', 'VSRG', N'Rạch giá', N'Không khoá'),
		  ('758b0c57-d32c-412e-b30d-d55e445f4220', 'VSLX', N'Long Xuyên', N'Không khoá'),
	      ('dba7fa9b-c5aa-4541-985d-8e27131468f8', 'VSCL', N'Cao Lãnh', N'Không khoá'),
		  ('de25f16c-43f4-4a41-9089-7f21c0fdb26f', 'VSTA', N'Tân An', N'Không khoá'),
		  ('5cf29f46-bc5b-4b4f-b6a4-cfa74057764f', 'VSBH', N'Biên Hoà', N'Không khoá'),
		  ('f7e693cc-2cc9-4141-b6bf-d90bb1d7bd63', 'VSPT', N'Phan Thiết', N'Không khoá'),
		  ('aa0a7b91-85e6-4d14-ae3b-ad1a6be67d65', 'VSPR', N'Phan Rang', N'Không khoá')

INSERT INTO DaiLy
	VALUES('1d627550-fdcb-4df8-8141-a5ad9900fb2b','DL01',N'Đại lý 1',N'26 Nguuyễn Trãi',N'0935263748',N'Không khoá'),
		  ('0064e9b1-2992-4258-b800-d4bafc43eaf7','DL02',N'Đại lý 2',N'73 An Dương Vương',N'0943728574',N'Không khoá'),
		  ('44fa4066-84b9-44ec-924b-8ca535314cd3','DL03',N'Đại lý 3',N'94 Kinh Dương Vương',N'0912345673',N'Không khoá'),
		  ('4411c19d-e4c2-46b6-8aa1-0fde5a36234d','DL04',N'Đại lý 4',N'122 Vĩnh Viễn',N'0962835263',N'Không khoá'),
		  ('74cdbb04-a926-4221-83c3-9643b846199b','DL05',N'Đại lý 5',N'12 Hoà Hảo',N'0946372839',N'Không khoá')

INSERT INTO DangKy
	VALUES('397c5455-1fd5-4bb3-9743-7d04affaa522','1d627550-fdcb-4df8-8141-a5ad9900fb2b','2018-05-01',50),
		  ('e1017914-e230-4926-a553-fff6ecfabbb7','1d627550-fdcb-4df8-8141-a5ad9900fb2b','2018-06-01',80),
		  ('d361af43-9f6c-4c4b-9b5d-30419b902000','0064e9b1-2992-4258-b800-d4bafc43eaf7','2018-02-02',100),
		  ('800ca87b-be3d-4225-abf2-0ba90f1c2d76','44fa4066-84b9-44ec-924b-8ca535314cd3','2018-03-06',150)

--CREATE PROC ThemSoLuongGiao
--AS
--	--Khai báo con trỏ, lấy giá trị từng row--
--	DECLARE CUR CURSOR FOR
--		SELECT DISTINCT IdDaiLy,SoLuong
--		FROM DangKy
--		ORDER BY NgayDangKy DESC
--	--
--	INSERT INTO PhanPhoi
--		VALUES(NEWID(), 
--GO

--select Table2.IdDaiLy, Table2.NgayDangKy, Table2.SoLuong
--from
--	(
--	select  IdDaiLy as TempDaiLy, Max(NgayDangky) as TempNgay
--	from DangKy 
--	group by IdDaiLy 
--	) as Table1, DangKy as Table2
--where Table1.TempDaiLy = Table2.IdDaiLy and Table1.TempNgay=Table2.NgayDangKy


--select  IdDaiLy as TempDaiLy, Max(NgayDangky) as TempNgay
--	from DangKy 
--	group by IdDaiLy 

--	select  IdDaiLy as TempDaiLy, Max(NgayDangky) as TempNgay, sum(SoLuong)
--	from DangKy 
--	group by IdDaiLy,NgayDangKy
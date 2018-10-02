﻿CREATE DATABASE QLVeSo
GO
--
USE QLVeSo
GO

--TABLE--
CREATE TABLE DaiLy
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	Ma VARCHAR(10) NOT NULL,
	Ten NVARCHAR(100),
	DiaChi NVARCHAR(200),
	DienThoai VARCHAR(12),
	TinhTrang NVARCHAR(20)
)

CREATE TABLE LoaiVeSo
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	Ma VARCHAR(10) NOT NULL,
	Tinh NVARCHAR(50),
	TinhTrang NVARCHAR(20)
)

CREATE TABLE DangKy
(
	IdDaiLy UNIQUEIDENTIFIER NOT NULL,
	IdVeSo UNIQUEIDENTIFIER NOT NULL,
	NgayDangKy DATE,
	SoLuong INT
)

CREATE TABLE PhanPhoi
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	IdDaiLy UNIQUEIDENTIFIER NOT NULL,
	IdVeSo UNIQUEIDENTIFIER NOT NULL,
	Ngay DATE,
	SoLuongGiao INT,
	SoLuongBan INT
)

--CONSTRAINT--
ALTER TABLE DangKy
	ADD
		CONSTRAINT FK_DangKy_LoaiVeSo_MaVeSo FOREIGN KEY (IdVeSo) REFERENCES LoaiVeSo(Id),
		CONSTRAINT FK_DangKy_DaiLy_MaDaiLy FOREIGN KEY (IdDaiLy) REFERENCES DaiLy(Id),
		CONSTRAINT PK_DangKy_MaDaiLy_MaVeSo PRIMARY KEY (IdDaiLy, IdVeSo)
GO

ALTER TABLE PhanPhoi
	ADD
		CONSTRAINT FK_PhanPhoi_LoaiVeSo_MaVeSo FOREIGN KEY (IdVeSo) REFERENCES LoaiVeSo(Id),
		CONSTRAINT FK_PhanPhoi_DaiLy_MaDaiLy FOREIGN KEY (IdDaiLy) REFERENCES DaiLy(Id)

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
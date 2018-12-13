USE QLCuocDT
GO

CREATE TRIGGER TG_Add_HoaDonThanhToan ON CuocGoi AFTER INSERT
AS
	DECLARE @MaCuocGoi INT
	DECLARE @MaKH INT
	DECLARE @MaSim INT
	DECLARE @TG_BatDau DATETIME
	DECLARE @TG_KetThuc DATETIME
	DECLARE @TG_Loop DATETIME
	DECLARE @TongTien DECIMAL(18, 0) = 0
	--
	SELECT @MaCuocGoi = i.MaCuocGoi, @MaKH = hd.MaKH, @MaSim = i.MaSim, @TG_BatDau = TG_BatDau, @TG_KetThuc = TG_KetThuc
	FROM inserted i JOIN HoaDonDK hd ON i.MaSim = hd.MaSim
	--
	SET @TG_Loop = @TG_BatDau
	WHILE(@TG_Loop < @TG_KetThuc)
	BEGIN
		DECLARE @GiaCuoc DECIMAL(18, 0)
		DECLARE @TG_Goi TIME = CONVERT(TIME, DATEADD(MINUTE, 1, @TG_Loop))
		--
		IF(@TG_Goi >= '07:00:00' AND @TG_Goi < '23:00:00')
		BEGIN
			SELECT @GiaCuoc = GiaCuoc
			FROM LoaiCuoc
			WHERE (@TG_Loop >= NgayApdung) AND (TG_BatDau = '07:00:00') AND (Status = 1)
			ORDER BY NgayApdung DESC
		END
		ELSE
		BEGIN
			SELECT @GiaCuoc = GiaCuoc
			FROM LoaiCuoc
			WHERE (@TG_Loop >= NgayApdung) AND (TG_BatDau = '23:00:00') AND (Status = 1)
		END
		--
		SET @TongTien = @TongTien + @GiaCuoc
		SET @TG_Loop = DATEADD(MINUTE, 1, @TG_Loop)
	END
	--
	IF EXISTS
	(
		SELECT *
		FROM HoaDonThanhToan
		WHERE (MaSim = @MaSim) AND (MONTH(NgayHD) = MONTH(@TG_BatDau))
	)
	BEGIN
		UPDATE HoaDonThanhToan
		SET ThanhTien = ThanhTien + @TongTien, NgayHD = @TG_BatDau
		WHERE (MaSim = @MaSim) AND (MONTH(NgayHD) = MONTH(@TG_BatDau))
		--
		UPDATE CuocGoi
		SET PhiCuocGoi = @TongTien
		WHERE MaCuocGoi = @MaCuocGoi
	END
	ELSE
	BEGIN
		INSERT INTO HoaDonThanhToan(MaKH, MaSim, CuocThueBao, NgayHD, ThanhToan, ThanhTien, Status)
			VALUES(@MaKH, @MaSim, 50000, @TG_BatDau, 0, @TongTien, 1)
		--
		UPDATE CuocGoi
		SET PhiCuocGoi = @TongTien
		WHERE MaCuocGoi = @MaCuocGoi
	END
GO

DELETE FROM HoaDonDK
DELETE FROM CuocGoi
DELETE FROM HoaDonThanhToan
DELETE FROM Sim
DELETE FROM LoaiCuoc
DELETE FROM KhachHang

DBCC CHECKIDENT ('HoaDonDK', RESEED, 0);
GO
DBCC CHECKIDENT ('CuocGoi', RESEED, 0);
GO
DBCC CHECKIDENT ('HoaDonThanhToan', RESEED, 0);
GO
DBCC CHECKIDENT ('Sim', RESEED, 0);
GO
DBCC CHECKIDENT ('LoaiCuoc', RESEED, 0);
GO
DBCC CHECKIDENT ('KhachHang', RESEED, 0);
GO

INSERT INTO KhachHang
	VALUES(N'Nguyễn Hoàng Trung', '0163254365', N'Bác sĩ', N'209 Trần Phú P4 Q5',N'nguyenhoangtrung@gmail.com', 1),
		  (N'Hoàng Việt Tuấn', '045823698', N'Kĩ sư', N'386 Lê Hồng Phong P1 Q10',N'hoangviettuan@gmail.com', 1),
		  (N'Nguyễn Kim Hà', '065874265', N'Giáo viên', N'S322B Quốc lộ 62 P6',N'nguyenkimha@gmail.com', 1),
		  (N'Nguyễn Quốc Anh', '035412685', N'Kiến trúc sư', N'92A Tán Kế P3',N'nguyenquocanh@gmail.com', 1),
		  (N'Nguyễn Quốc Thanh', '032541265', N'Giáo viên', N'49 Cách Mạng Tháng Tám P3',N'nguyenquocthanh@gmail.com', 1)

INSERT INTO LoaiCuoc
	VALUES('LC-01', '07:00:00', '22:59:59', '06/01/2018', 200, 1),
		  ('LC-02', '23:00:00', '06:59:59', '06/01/2018', 150, 1)

INSERT INTO Sim
	VALUES('0938932950', 1),
		  ('0938932951', 1),
		  ('0938932952', 1),
		  ('0938932953', 1),
		  ('0938932954', 1),
		  ('0938932955', 1),
		  ('0938932956', 1),
		  ('0938932957', 1),
		  ('0938932958', 1),
		  ('0938932969', 1),
		  ('0938942910', 1),
		  ('0938942911', 1),
		  ('0938942912', 1),
		  ('0938942913', 1),
		  ('0938942914', 1),
		  ('0938942915', 1),
		  ('0938942916', 1),
		  ('0938942917', 1),
		  ('0938942918', 1),
		  ('0938942919', 1),
		  ('0938942920', 1)
GO

INSERT INTO HoaDonDK
	VALUES(1, '07/12/2018', 50000, 1),
		  (2, '07/15/2018', 50000, 2),
		  (3, '08/02/2018', 50000, 3),
		  (4, '08/24/2018', 50000, 4),
		  (5, '09/10/2018', 50000, 5)
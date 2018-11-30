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
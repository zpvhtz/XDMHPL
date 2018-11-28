USE QLCuocDT
GO

ALTER TRIGGER TG_Add_HoaDonThanhToan ON CuocGoi AFTER INSERT
AS
	DECLARE @MaKH INT
	DECLARE @MaSim INT
	DECLARE @TG_BatDau DATETIME
	DECLARE @TG_KetThuc DATETIME
	DECLARE @TG_Loop DATETIME
	DECLARE @TongTien DECIMAL(18, 0) = 0
	--
	SELECT @MaKH = hd.MaKH, @MaSim = i.MaSim, @TG_BatDau = TG_BatDau, @TG_KetThuc = TG_KetThuc
	FROM inserted i JOIN HoaDonDK hd ON i.MaSim = hd.MaSim

	PRINT @MaKH
	--
	SET @TG_Loop = @TG_BatDau
	WHILE(@TG_Loop < @TG_KetThuc)
	BEGIN
		DECLARE @GiaCuoc DECIMAL(18, 0)
		DECLARE @TG_Goi TIME = CONVERT(TIME, DATEADD(MINUTE, 1, @TG_Loop))
		--
		SELECT @GiaCuoc = GiaCuoc
		FROM LoaiCuoc
		WHERE (@TG_Loop >= NgayApdung) AND (@TG_Goi BETWEEN TG_BatDau AND TG_KetThuc) AND (Status = 1)
		ORDER BY NgayApdung DESC
		--
		SET @TongTien = @TongTien + @GiaCuoc
		SET @TG_Loop = DATEADD(MINUTE, 1, @TG_Loop)
	END
	--
	IF EXISTS
	(
		SELECT *
		FROM HoaDonThanhToan
		WHERE (MaSim = @MaSim) AND (MONTH(GETDATE()) = MONTH(NgayHD))
	)
	BEGIN
		UPDATE HoaDonThanhToan
		SET ThanhTien = ThanhTien + @TongTien
		WHERE (MaSim = @MaSim) AND (MONTH(GETDATE()) = MONTH(NgayHD))
	END
	ELSE
	BEGIN
		INSERT INTO HoaDonThanhToan(MaKH, MaSim, CuocThueBao, NgayHD, ThanhToan, ThanhTien, Status)
			VALUES(@MaKH, @MaSim, 50000, GETDATE(), 0, @TongTien, 1)
	END
GO

INSERT INTO CuocGoi(MaSim, TG_BatDau, TG_KetThuc, SoPhutSD, trangthai)
	VALUES (11, '07:01:01', '07:02:01', 1, 1)
select * from CuocGoi
CREATE DATABASE sqlQuanLyKhamBenh ON 
(
	NAME = 'QuanLyKhamBenh',
	FILENAME = 'D:\sqlQuanLyKhamBenh\QuanLyKhamBenh.mdf',
	SIZE = 100MB,
	MAXSIZE = UNLIMITED,
	FILEGROWTH = 10%
)


use sqlQuanLyKhamBenh

-- =================== TABLES ===================

CREATE TABLE tblTaiKhoan
(
	iMaTK int IDENTITY,
	sTenTaiKhoan nvarchar(50) NOT NULL UNIQUE,
	sMatKhau nvarchar(50) NOT NULL,
	CONSTRAINT PK_tblTaiKhoan PRIMARY KEY (iMaTK)
)



CREATE TABLE tblNhanVien
(
	sMaNhanVien nvarchar(50) NOT NULL,
	sTenNhanVien nvarchar(50) NOT NULL,
	sSDT nvarchar(20) NOT NULL UNIQUE,
	dNgaySinh date,
	iGioiTinh int NOT NULL, -- 1: Nữ, 0: Nam
	CONSTRAINT PK_tblNhanVien PRIMARY KEY (sMaNhanVien),
	CONSTRAINT CK_tuoiNhanVien CHECK (DATEDIFF(DAY, dNgaySinh, GETDATE()) / 365 >= 18)
)

CREATE TABLE tblBacSi
(
	sMaBacSi nvarchar(50) NOT NULL,
	sTenBacSi nvarchar(50) NOT NULL,
	sSDT nvarchar(20) NOT NULL UNIQUE,
	iGioiTinh int NOT NULL, -- 1: N?, 0: Nam
	dNgaySinh datetime,
	CONSTRAINT PK_tblBacSi PRIMARY KEY (sMaBacSi),
	CONSTRAINT CK_tuoiBacSi CHECK (DATEDIFF(DAY, dNgaySinh, GETDATE()) / 365 >= 18)
)

CREATE TABLE tblBenhNhan
(
	sMaBenhNhan nvarchar(50) NOT NULL,
	sTenBenhNhan nvarchar(50) NOT NULL,
	sSDT nvarchar(20) NOT NULL UNIQUE,
	iGioiTinh int NOT NULL, -- 1: N?, 0: Nam
	dNgaySinh datetime,
	CONSTRAINT PK_tblBenhNhan PRIMARY KEY (sMaBenhNhan),
)

CREATE TABLE tblLoaiDichVu
(
	iMaLoaiDichVu int IDENTITY,
	sTenLoaiDichVu nvarchar(50) NOT NULL,
	CONSTRAINT PK_tblLoaiDichVu PRIMARY KEY (iMaLoaiDichVu)
)

CREATE TABLE tblDichVu
(
	iMaDichVu int IDENTITY,
	sTenDichVu nvarchar(50) NOT NULL,
	iMaLoaiDichVu int NOT NULL,
	fGiaTien float DEFAULT 0,
	CONSTRAINT PK_tblDichVu PRIMARY KEY (iMaDichVu),
	CONSTRAINT FK_tblDichVu_tblLoaiDichVu_maLoaiDichVu FOREIGN KEY (iMaLoaiDichVu) 
		REFERENCES tblLoaiDichVu(iMaLoaiDichVu)
)


CREATE TABLE tblPhieuKham
(
	iSoPK int IDENTITY,
	dNgayLap date NOT NULL DEFAULT GETDATE(),
	iTrangThai int NOT NULL DEFAULT 0,-- 1: ĐÃ THANH TOÁN // 0: CHƯA THANH TOÁN
	sMaBacSi nvarchar(50) NOT NULL,
	sMaBenhNhan nvarchar(50) NOT NULL,
	sMaNhanVien nvarchar(50) NOT NULL,
	fTongTien float DEFAULT 0 NOT NULL,
	CONSTRAINT PK_tblPhieuKham PRIMARY KEY (iSoPK),
	CONSTRAINT FK_tblPhieuKham_tblBacSi FOREIGN KEY (sMaBacSi) REFERENCES tblBacSi(sMaBacSi),
	CONSTRAINT FK_tblPhieuKham_tblBenhNhan FOREIGN KEY (sMaBenhNhan) REFERENCES tblBenhNhan(sMaBenhNhan),
	CONSTRAINT FK_tblPhieuKham_tblNhanVien FOREIGN KEY (sMaNhanVien) REFERENCES tblNhanVien(sMaNhanVien),
)


CREATE TABLE tblChiTietPhieuKham
(
	iMaChiTietHoaDon int IDENTITY,
	iSoPK int NOT NULL,
	iMaDichVu int NOT NULL,
	iSoLuong int NOT NULL,
	fDonGia float DEFAULT 0 NOT NULL,
	CONSTRAINT PK_tblChiTietHoaDon PRIMARY KEY (iMaChiTietHoaDon, iSoPK),
	CONSTRAINT FK_tblChiTietHoaDon_tblPhieuKham FOREIGN KEY (iSoPK) REFERENCES tblPhieuKham(iSoPK)ON DELETE CASCADE,
	CONSTRAINT FK_tblChiTietHoaDon_tblDichVu FOREIGN KEY (iMaDichVu) REFERENCES tblDichVu(iMaDichVu)
)

-- =================== SELECT ===================
SELECT * FROM tblBacSi
SELECT * FROM tblBenhNhan
SELECT * FROM tblNhanVien
SELECT * FROM tblLoaiDichVu
SELECT * FROM tblDichVu
SELECT * FROM tblPhieuKham
SELECT * FROM tblChiTietPhieuKham
SELECT * FROM tblTaiKhoan

-- =================== STORED PROCEDURE ===================
-- thủ tục thêm bệnh nhân
CREATE PROC spAddBenhNhan @maBenhNhan nvarchar(50), @hoTenBenhNhan nvarchar(50), @sdt nvarchar(20), @gioiTinh int, @ngaySinh datetime
AS
BEGIN
	INSERT INTO tblBenhNhan
	VALUES (@maBenhNhan, @hoTenBenhNhan, @sdt, @gioiTinh, @ngaySinh)
END

exec spAddBenhNhan 'BN05', N'Nguyễn Văn A', '1234556789', '1999-03-22', N'Nam'

-- thủ tục xóa bệnh nhân
CREATE PROC spDeleteBenhNhan @maBenhNhan nvarchar(50)
AS
BEGIN
	DELETE FROM tblBenhNhan
	WHERE sMaBenhNhan = @maBenhNhan
END

exec spDeleteBenhNhan 'BN06'

select * from viewDSBenhNhan

-- thủ tục update bệnh nhân
CREATE PROC spUpdateBenhNhan @maBenhNhan nvarchar(50), @hoTenBenhNhan nvarchar(50), @sdt nvarchar(20), @gioiTinh int, @ngaySinh datetime
AS
BEGIN
	UPDATE tblBenhNhan
	SET sTenBenhNhan = @hoTenBenhNhan, sSDT = @sdt, dNgaySinh = @ngaySinh, iGioiTinh = @gioiTinh
	WHERE sMaBenhNhan = @maBenhNhan
END


-- thủ tục thêm bệnh án
ALTER PROC spAddBenhAn @maBacSi nvarchar(50), @maBenhNhan nvarchar(50), @maNhanVien nvarchar(50)
AS
BEGIN
	INSERT INTO tblBenhAn (sMaBacSi, sMaBenhNhan, sMaNhanVien)
	VALUES (@maBacSi, @maBenhNhan, @maNhanVien)
END

-- thủ tục thêm bệnh án
CREATE PROC spUpdateBenhAn @maBenhAn int, @maBacSi nvarchar(50), @maBenhNhan nvarchar(50), @maNhanVien nvarchar(50)
AS
BEGIN
	UPDATE tblBenhAn
	SET sMaBacSi = @maBacSi, sMaBenhNhan = @maBenhNhan, sMaNhanVien = @maNhanVien
	WHERE iMaBenhAn = @maBenhAn
END

-- thủ tục xóa bệnh án
ALTER PROC spDeleteBenhAn @maBenhAn int
AS
BEGIN
	DELETE FROM tblBenhAn
	WHERE iMaBenhAn = @maBenhAn
END

ALTER PROC spAddBacSi @maBacSi nvarchar(50), @tenBacSi nvarchar(50), @sdt nvarchar(20), @ngaySinh datetime, @gioiTinh int
AS
BEGIN
	INSERT INTO tblBacSi
	VALUES (@maBacSi, @tenBacSi, @sdt, @gioiTinh, @ngaySinh)
END

-- thủ tục update bác sĩ
ALTER PROC spUpdateBacSi @maBacSi nvarchar(50), @tenBacSi nvarchar(50), @sdt nvarchar(20), @gioiTinh int, @ngaySinh datetime
AS
BEGIN
	UPDATE tblBacSi
	SET sTenBacSi = @tenBacSi, sSDT = @sdt, dNgaySinh = @ngaySinh, iGioiTinh = @gioiTinh
	WHERE sMaBacSi = @maBacSi
END

-- thủ tục xóa bác sĩ
CREATE PROC spDeleteBacSi @maBacSi nvarchar(50)
AS
BEGIN
	DELETE FROM tblBacSi
	WHERE sMaBacSi = @maBacSi
END

-- thủ tục thêm nhân viên
CREATE PROC spAddNhanVien @maNhanVien nvarchar(50), @hoTen nvarchar(50), @sdt nvarchar(20), @gioiTinh int, @ngaySinh datetime
AS
BEGIN
	INSERT INTO tblNhanVien
	VALUES (@maNhanVien, @hoTen, @sdt, @ngaySinh, @gioiTinh)
END

-- thủ tục sửa nhân viên
CREATE PROC spUpdateNhanVien @maNhanVien nvarchar(50), @hoTen nvarchar(50), @sdt nvarchar(20), @gioiTinh int, @ngaySinh datetime
AS
BEGIN
	UPDATE tblNhanVien
	SET sTenNhanVien = @hoTen, sSDT = @sdt, dNgaySinh = @ngaySinh, iGioiTinh = @gioiTinh
	WHERE sMaNhanVien = @maNhanVien
END

-- thủ tục xóa nhân viên
CREATE PROC spDeleteNhanVien @maNhanVien nvarchar(50)
AS
BEGIN
	DELETE FROM tblNhanVien
	WHERE sMaNhanVien = @maNhanVien
END

-- thủ tục thêm dịch vụ
CREATE PROC spAddDichVu @tenDichVu nvarchar(50), @maLoaiDichVu int, @giaTien float
AS
BEGIN
	INSERT INTO tblDichVu (sTenDichVu, iMaLoaiDichVu, fGiaTien)
	VALUES (@tenDichVu, @maLoaiDichVu, @giaTien)
END

-- thủ tục update dịch vụ
CREATE PROC spUpdateDichVu @maDichVu int, @tenDichVu nvarchar(50), @maLoaiDichVu int, @giaTien float
AS
BEGIN
	UPDATE tblDichVu
	SET sTenDichVu = @tenDichVu, iMaLoaiDichVu = @maLoaiDichVu, fGiaTien = @giaTien
	WHERE iMaDichVu = @maDichVu
END

-- thủ tục xóa dịch vụ
CREATE PROC spDeleteDichVu @maDichVu int
AS
BEGIN
	DELETE FROM tblDichVu
	WHERE iMaDichVu = @maDichVu
END


-- thủ tục thêm tài khoản
CREATE PROC spAddTaiKhoan @tenTK nvarchar(50), @matKhau nvarchar(50), @phanQuyen int
AS
BEGIN
	INSERT INTO tblTaiKhoan(sTenTaiKhoan, sMatKhau, iPhanLoaiTaiKhoan)
	VALUES (@tenTK, @matKhau, @phanQuyen)
END

-- thủ tục update tài khoản
CREATE PROC spUpdateTaiKhoan @id int, @tenTK nvarchar(50), @matKhau nvarchar(50), @phanQuyen int
AS
BEGIN
	UPDATE tblTaiKhoan
	SET sTenTaiKhoan = @tenTK, sMatKhau = @matKhau, iPhanLoaiTaiKhoan = @phanQuyen
	WHERE iMaTK = @id
END

-- thủ tục xóa tài khoản
CREATE PROC spDeleteTaiKhoan @id int
AS
BEGIN
	DELETE FROM tblTaiKhoan
	WHERE iMaTK = @id
END


-- thủ tục in hóa đơn
ALTER PROC spInHoaDon @soPK int
AS
BEGIN
	SELECT PK.iSoPK , BS.sTenBacSi, BN.sTenBenhNhan, NV.sTenNhanVien, DV.sTenDichVu, DV.fGiaTien, BILL.iSoLuong, BILL.fDonGia
	FROM tblBacSi AS BS, tblBenhNhan AS BN, tblNhanVien AS NV, tblDichVu AS DV, tblPhieuKham AS PK, tblChiTietPhieuKham AS BILL
	WHERE PK.iSoPK = @soPK AND PK.iSoPK = BILL.iSoPK AND BILL.iMaDichVu = DV.iMaDichVu
	AND PK.sMaBacSi = BS.sMaBacSi AND PK.sMaBenhNhan = BN.sMaBenhNhan AND PK.sMaNhanVien = NV.sMaNhanVien
END

EXEC spInHoaDon 1

-- thủ tục thống kê doanh thu
ALTER PROC spThongKeDoanhThu @ngay date
AS
BEGIN
	SELECT iSoPK , fTongTien
	FROM tblPhieuKham
	WHERE dNgayLap like @ngay  AND iTrangThai = 1
END

EXEC spThongKeDoanhThu '20230421'


CREATE PROC checkLogin @username nvarchar(50), @password nvarchar(50)
AS
BEGIN
	SELECT * FROM tblTaiKhoan
	WHERE sTenTaiKhoan = @username AND sMatKhau = @password
END

CREATE PROC spDSBacSi
AS
BEGIN
	SELECT * FROM tblBacSi
END

alter PROC getBacSiByName @hoTen nvarchar(50)
AS
BEGIN
	SELECT * FROM tblBacSi
	WHERE sTenBacSi like N'%' + @hoTen + N'%'
END

exec getBacSiByName N'a'
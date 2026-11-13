-- ===================================================================
-- LAB 14: BÁO CÁO THAM SỐ, NHÓM, THỐNG KÊ VÀ XUẤT EXCEL
-- Học phần: Lập trình .NET (IT3212) - EAUT
-- Sinh viên: Phan Văn Thắng - MSSV: 24002545 - Lớp: IT3212
-- CSDL: QLSinhVien ((localdb)\MSSQLLocalDB)
-- ===================================================================

USE QLSinhVien;
GO

-- 1. View cơ bản: vw_BaoCaoSinhVien
CREATE OR ALTER VIEW vw_BaoCaoSinhVien
AS
SELECT sv.MaSV, sv.HoTen, sv.NgaySinh,
       CASE sv.GioiTinh WHEN 1 THEN N'Nam' ELSE N'Nữ' END AS GioiTinh,
       k.MaKhoa, k.TenKhoa, sv.DiemTB, sv.Email, sv.IsActive
FROM SinhVien sv
JOIN Khoa k ON sv.MaKhoa = k.MaKhoa
WHERE sv.IsActive = 1;
GO

-- 2. View tổng hợp đăng ký theo học kỳ: vw_BaoCaoDangKyHocKy (Bài 7)
CREATE OR ALTER VIEW vw_BaoCaoDangKyHocKy
AS
SELECT 
    ISNULL(dk.HocKy, 1) AS HocKy,
    hp.MaHP,
    hp.TenHP,
    hp.SoTinChi,
    COUNT(dk.MaSV) AS SoLuotDangKy,
    ISNULL(AVG(dk.Diem), 0.0) AS DiemTrungBinhMon
FROM HocPhan hp
LEFT JOIN DangKy dk ON hp.MaHP = dk.MaHP
GROUP BY ISNULL(dk.HocKy, 1), hp.MaHP, hp.TenHP, hp.SoTinChi;
GO

-- 3. View chi tiết đăng ký học phần kèm sinh viên (Bài 7 & Bài 10)
CREATE OR ALTER VIEW vw_ChiTietDangKyHocKy
AS
SELECT 
    dk.HocKy,
    hp.MaHP,
    hp.TenHP,
    hp.SoTinChi,
    sv.MaSV,
    sv.HoTen,
    k.TenKhoa,
    ISNULL(dk.Diem, 0.0) AS Diem,
    dk.NgayDangKy
FROM DangKy dk
JOIN SinhVien sv ON dk.MaSV = sv.MaSV
JOIN HocPhan hp ON dk.MaHP = hp.MaHP
JOIN Khoa k ON sv.MaKhoa = k.MaKhoa;
GO

-- 4. Bổ sung sinh viên có điểm phong phú nếu chưa có
IF NOT EXISTS (SELECT 1 FROM SinhVien WHERE MaSV = 'SV031')
BEGIN
    INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, GioiTinh, MaKhoa, DiemTB, Email, IsActive) VALUES
    ('SV031', N'Hoàng Văn Nam', '2005-05-18', 1, 'CNTT', 5.50, 'namhv@eaut.edu.vn', 1),
    ('SV032', N'Đặng Phương Linh', '2005-09-22', 0, 'KT', 4.30, 'linhdp@eaut.edu.vn', 1),
    ('SV033', N'Đỗ Quốc Khánh', '2005-06-11', 1, 'CNTT', 3.80, 'khanhdq@eaut.edu.vn', 1);
END;
GO

-- 5. Bổ sung dữ liệu Đăng ký học phần cho các học kỳ 1, 2, 3 an toàn
IF NOT EXISTS (SELECT 1 FROM DangKy WHERE MaSV = 'SV003' AND MaHP = 'IT3212')
    INSERT INTO DangKy (MaSV, MaHP, HocKy, Diem, NgayDangKy) VALUES ('SV003', 'IT3212', 1, 8.80, '2026-09-05');

IF NOT EXISTS (SELECT 1 FROM DangKy WHERE MaSV = 'SV004' AND MaHP = 'IT3212')
    INSERT INTO DangKy (MaSV, MaHP, HocKy, Diem, NgayDangKy) VALUES ('SV004', 'IT3212', 1, 9.40, '2026-09-05');

IF NOT EXISTS (SELECT 1 FROM DangKy WHERE MaSV = 'SV005' AND MaHP = 'HP01')
    INSERT INTO DangKy (MaSV, MaHP, HocKy, Diem, NgayDangKy) VALUES ('SV005', 'HP01', 1, 8.70, '2026-09-05');

IF NOT EXISTS (SELECT 1 FROM DangKy WHERE MaSV = 'SV006' AND MaHP = 'HP02')
    INSERT INTO DangKy (MaSV, MaHP, HocKy, Diem, NgayDangKy) VALUES ('SV006', 'HP02', 2, 7.60, '2027-01-10');

IF NOT EXISTS (SELECT 1 FROM DangKy WHERE MaSV = 'SV007' AND MaHP = 'HP02')
    INSERT INTO DangKy (MaSV, MaHP, HocKy, Diem, NgayDangKy) VALUES ('SV007', 'HP02', 2, 9.00, '2027-01-10');

IF NOT EXISTS (SELECT 1 FROM DangKy WHERE MaSV = 'SV008' AND MaHP = 'HP03')
    INSERT INTO DangKy (MaSV, MaHP, HocKy, Diem, NgayDangKy) VALUES ('SV008', 'HP03', 2, 6.50, '2027-01-10');

IF NOT EXISTS (SELECT 1 FROM DangKy WHERE MaSV = 'SV009' AND MaHP = 'HP03')
    INSERT INTO DangKy (MaSV, MaHP, HocKy, Diem, NgayDangKy) VALUES ('SV009', 'HP03', 2, 7.20, '2027-01-10');

IF NOT EXISTS (SELECT 1 FROM DangKy WHERE MaSV = 'SV010' AND MaHP = 'HP04')
    INSERT INTO DangKy (MaSV, MaHP, HocKy, Diem, NgayDangKy) VALUES ('SV010', 'HP04', 2, 8.20, '2027-01-10');

IF NOT EXISTS (SELECT 1 FROM DangKy WHERE MaSV = 'SV011' AND MaHP = 'HP04')
    INSERT INTO DangKy (MaSV, MaHP, HocKy, Diem, NgayDangKy) VALUES ('SV011', 'HP04', 2, 5.80, '2027-01-10');

IF NOT EXISTS (SELECT 1 FROM DangKy WHERE MaSV = 'SV012' AND MaHP = 'HP05')
    INSERT INTO DangKy (MaSV, MaHP, HocKy, Diem, NgayDangKy) VALUES ('SV012', 'HP05', 3, 9.50, '2027-05-15');

IF NOT EXISTS (SELECT 1 FROM DangKy WHERE MaSV = 'SV013' AND MaHP = 'HP05')
    INSERT INTO DangKy (MaSV, MaHP, HocKy, Diem, NgayDangKy) VALUES ('SV013', 'HP05', 3, 8.40, '2027-05-15');

IF NOT EXISTS (SELECT 1 FROM DangKy WHERE MaSV = 'SV014' AND MaHP = 'HP06')
    INSERT INTO DangKy (MaSV, MaHP, HocKy, Diem, NgayDangKy) VALUES ('SV014', 'HP06', 3, 9.10, '2027-05-15');

IF NOT EXISTS (SELECT 1 FROM DangKy WHERE MaSV = 'SV015' AND MaHP = 'HP06')
    INSERT INTO DangKy (MaSV, MaHP, HocKy, Diem, NgayDangKy) VALUES ('SV015', 'HP06', 3, 7.90, '2027-05-15');
GO

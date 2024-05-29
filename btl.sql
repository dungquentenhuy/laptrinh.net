create database btl ;
use btl ;
create table tbltheloai(
Maloai nvarchar(10) primary key,
Tenloai nvarchar(30))  ;

create table tbldongco(
Madongco nvarchar(10) primary key,
Tendongco nvarchar(30)) ;

create table tblmausac(
Mamau nvarchar(10) primary key,
Tenmau nvarchar(30)) ;

create table tbltinhtrang(
Matinhtrang nvarchar(10) primary key,
Tentinhtrang nvarchar(30));

create table tblnuocsanxuat(
Manuoc nvarchar(10) primary key,
Tennuoc nvarchar(30)) ;

create table tblhangsx(
Mahangsx nvarchar(10) primary key,
Tenhangsx nvarchar(30)) ;

create table tblphanhxe(
Maphanh nvarchar(10) primary key,
Tenphanh nvarchar(30)) ;

create table tbldmhang(
Mahang nvarchar(20) primary key,
Tenhang nvarchar(30),
Maloai nvarchar(10),
Mahangsx nvarchar(10),
Mamau nvarchar(10),
Namsx int,
Maphanh nvarchar(10),
Madongco nvarchar(10),
Dungtich int,
Manuoc nvarchar(10),
Tinhtrang nvarchar(10),
Anh image ,
Soluong int,
Dongianhap float,
Dongiaban float,
Thoigianbaohanh int) ;

create table tblcongviec(
Macv nvarchar(10) primary key,
Tencv nvarchar(30),
Luongthang int)

create table tblnhanvien(
Manv nvarchar(10)primary key,
Tennv nvarchar(30),
Gioitinh nvarchar(10),
Ngaysinh date,
Dienthoai int,
Diachi nvarchar(30),
Macv nvarchar(10),
foreign key (Macv) references tblcongviec(Macv) ) ;

create table tblkhachhang(
Makhach nvarchar(10),
Tenkhach nvarchar(30),
Diachi nvarchar(30),
Dienthoai int) ;


create table tbldondathang(
SoDDH nvarchar(10) primary key,
Manv nvarchar(10),
Makhach nvarchar(10),
Ngaymua date,
Datcoc int,
Thue int,
Tongtien int) ;

create table tblhoadonnhap(
SoHDN nvarchar(10) primary key,
Manv nvarchar(10),
Ngaynhap date,
Mancc nvarchar(10),
Tongtien int) ;

create table tblnhacungcap(
Mancc nvarchar(10),
Tenncc nvarchar(30),
Diachi nvarchar(30),
Dienthoai int);

create table tblchitietdondathang(
SoDDH nvarchar(10),
Mahang nvarchar(20),
Soluong int,
Giamgia int,
Thanhtien int,
primary key(SoDDH,Mahang),
foreign key (SoDDH) references tbldondathang(SoDDH),
foreign key (Mahang) references tbldmhang(Mahang)) ;

create table tblchitiethoadonnhap(
SoHDN nvarchar(10),
Mahang nvarchar(20),
Soluong int,
Dongia int,
Giamgia int,
Thanhtien int,
primary key(SoHDN,Mahang),
foreign key (SoHDN) references tblhoadonnhap(SoHDN),
foreign key (Mahang) references tbldmhang(Mahang)) ;




Use btl; 
-- doi theo ten db 

--insert theo thu tu, tung cai 1

-- 1. tbltheloai
INSERT INTO tbltheloai (Maloai, Tenloai) VALUES
('TL01', 'Sedan'),
('TL02', 'SUV'),
('TL03', 'Hatchback'),
('TL04', 'Coupe'),
('TL05', 'Convertible');

-- 2. tbldongco
INSERT INTO tbldongco (Madongco, Tendongco) VALUES
('DC01', 'I4'),
('DC02', 'V6'),
('DC03', 'V8'),
('DC04', 'Electric'),
('DC05', 'Hybrid');

-- 3. tblmausac
INSERT INTO tblmausac (Mamau, Tenmau) VALUES
('M01', 'Red'),
('M02', 'Blue'),
('M03', 'Black'),
('M04', 'White'),
('M05', 'Gray');

-- 4. tbltinhtrang
INSERT INTO tbltinhtrang (Matinhtrang, Tentinhtrang) VALUES
('TT01', 'New'),
('TT02', 'Used'),
('TT03', 'Refurbished'),
('TT04', 'Damaged'),
('TT05', 'Vintage');

-- 5. tblnuocsanxuat
INSERT INTO tblnuocsanxuat (Manuoc, Tennuoc) VALUES
('N01', 'Japan'),
('N02', 'Germany'),
('N03', 'USA'),
('N04', 'Korea'),
('N05', 'Italy');

-- 6. tblhangsx
INSERT INTO tblhangsx (Mahangsx, Tenhangsx) VALUES
('HSX01', 'Toyota'),
('HSX02', 'BMW'),
('HSX03', 'Ford'),
('HSX04', 'Hyundai'),
('HSX05', 'Ferrari');

-- 7. tblphanhxe
INSERT INTO tblphanhxe (Maphanh, Tenphanh) VALUES
('P01', 'ABS'),
('P02', 'Disc'),
('P03', 'Drum'),
('P04', 'Ceramic'),
('P05', 'Carbon');

-- 8. tblcongviec
INSERT INTO tblcongviec (Macv, Tencv, Luongthang) VALUES
('CV01', 'Manager', 5000),
('CV02', 'Sales', 3000),
('CV03', 'Technician', 2500),
('CV04', 'Clerk', 2000),
('CV05', 'Driver', 2200);

-- 9. tblnhanvien
INSERT INTO tblnhanvien (Manv, Tennv, Gioitinh, Ngaysinh, Dienthoai, Diachi, Macv) VALUES
('NV01', 'John Doe', 'Male', '1985-01-01', 1234567890, '123 Main St', 'CV01'),
('NV02', 'Jane Smith', 'Female', '1990-02-02', 2345678901, '456 Elm St', 'CV02'),
('NV03', 'Jim Brown', 'Male', '1982-03-03', 3456789012, '789 Oak St', 'CV03'),
('NV04', 'Jill White', 'Female', '1995-04-04', 4567890123, '101 Maple St', 'CV04'),
('NV05', 'Jack Black', 'Male', '1988-05-05', 5678901234, '202 Pine St', 'CV05');

-- 10. tblkhachhang
INSERT INTO tblkhachhang (Makhach, Tenkhach, Diachi, Dienthoai) VALUES
('KH01', 'Alice Green', '333 Cedar St', 12345),
('KH02', 'Bob Yellow', '444 Birch St', 78901),
('KH03', 'Charlie Blue', '555 Spruce St', 89018),
('KH04', 'Diana Red', '666 Willow St', 45678),
('KH05', 'Edward Purple', '777 Poplar St', 67890);

-- 11. tblnhacungcap
INSERT INTO tblnhacungcap (Mancc, Tenncc, Diachi, Dienthoai) VALUES
('NCC01', 'Supply Co.', '888 Fir St', 678901),
('NCC02', 'Parts Inc.', '999 Palm St', 345012),
('NCC03', 'Auto Supply', '111 Cypress St', 890123),
('NCC04', 'Gear Ltd.', '222 Magnolia St', 56734),
('NCC05', 'Motor Co.', '333 Pine St', 12345);

-- 12. tbldmhang
INSERT INTO tbldmhang (Mahang, Tenhang, Maloai, Mahangsx, Mamau, Namsx, Maphanh, Madongco, Dungtich, Manuoc, Tinhtrang, Anh, Soluong, Dongianhap, Dongiaban, Thoigianbaohanh) VALUES
('MH01', 'Camry', 'TL01', 'HSX01', 'M01', 2020, 'P01', 'DC01', 2500, 'N01', 'TT01', NULL, 10, 20000, 25000, 24),
('MH02', 'X5', 'TL02', 'HSX02', 'M02', 2021, 'P02', 'DC02', 3000, 'N02', 'TT01', NULL, 5, 40000, 45000, 24),
('MH03', 'Mustang', 'TL04', 'HSX03', 'M03', 2019, 'P03', 'DC03', 5000, 'N03', 'TT01', NULL, 3, 35000, 40000, 24),
('MH04', 'Tucson', 'TL02', 'HSX04', 'M04', 2022, 'P04', 'DC04', 2000, 'N04', 'TT01', NULL, 7, 30000, 35000, 24),
('MH05', '488', 'TL04', 'HSX05', 'M05', 2018, 'P05', 'DC05', 3900, 'N05', 'TT01', NULL, 2, 200000, 250000, 24);

-- 13. tbldondathang
INSERT INTO tbldondathang (SoDDH, Manv, Makhach, Ngaymua, Datcoc, Thue, Tongtien) VALUES
('DDH01', 'NV01', 'KH01', '2023-01-01', 5000, 500, 25500),
('DDH02', 'NV02', 'KH02', '2023-02-01', 8000, 800, 45800),
('DDH03', 'NV03', 'KH03', '2023-03-01', 10000, 1000, 41000),
('DDH04', 'NV04', 'KH04', '2023-04-01', 6000, 600, 35600),
('DDH05', 'NV05', 'KH05', '2023-05-01', 20000, 2000, 252000);

-- 14. tblhoadonnhap
INSERT INTO tblhoadonnhap (SoHDN, Manv, Ngaynhap, Mancc, Tongtien) VALUES
('HDN01', 'NV01', '2023-01-10', 'NCC01', 100000),
('HDN02', 'NV02', '2023-02-10', 'NCC02', 200000),
('HDN03', 'NV03', '2023-03-10', 'NCC03', 150000),
('HDN04', 'NV04', '2023-04-10', 'NCC04', 250000),
('HDN05', 'NV05', '2023-05-10', 'NCC05', 300000);

-- 15. tblchitietdondathang
INSERT INTO tblchitietdondathang (SoDDH, Mahang, Soluong, Giamgia, Thanhtien) VALUES
('DDH01', 'MH01', 1, 0, 25000),
('DDH02', 'MH02', 1, 0, 45000),
('DDH03', 'MH03', 1, 0, 40000),
('DDH04', 'MH04', 1, 0, 35000),
('DDH05', 'MH05', 1, 0, 250000);

-- 16. tblchitiethoadonnhap
INSERT INTO tblchitiethoadonnhap (SoHDN, Mahang, Soluong, Dongia, Giamgia, Thanhtien) VALUES
('HDN01', 'MH01', 5, 20000, 0, 100000),
('HDN02', 'MH02', 5, 40000, 0, 200000),
('HDN03', 'MH03', 3, 50000, 0, 150000),
('HDN04', 'MH04', 5, 50000, 0, 250000),
('HDN05', 'MH05', 1, 200000, 0, 200000);


using QuanLyTrungTam.Enities;
using System.Text;

public class Program
{
    private static AppDbContext context = new AppDbContext();
    static List<HocSinh> LayDanhSachHocSinh(int? namSinh = null, string tenHocVien = null)
    {
        var lst = context.HocSinhs.OrderByDescending(x => x.NgayDangKy).ToList();
        if (namSinh.HasValue)
        {
             lst.Where(x => x.NgaySinh.Year == namSinh);
        }
        if (!string.IsNullOrEmpty(tenHocVien))
        {
             lst.Where(x => x.HoTen.ToLower().Contains(tenHocVien.ToLower()));
        }
        return lst;
    }
    static List<HocSinh> LayDanhSachHocSinhTheoKey(int? namSinh = null, string tenHocVien =null)
    {
        var lst = context.HocSinhs.OrderByDescending(x => x.NgayDangKy).ToList();
        if(namSinh.HasValue)
        {
           lst= lst.Where(x => x.NgaySinh.Year == namSinh).ToList();
        }
        if (!string.IsNullOrEmpty(tenHocVien))
        {
           lst =lst.Where(x=>x.HoTen.ToLower().Contains(tenHocVien.ToLower())).ToList(); 
        }
        return lst;
    }
    static  HocSinh ThemHocVien (HocSinh hocSinh)
    {
        context.HocSinhs.Add(hocSinh);
        context.SaveChanges();
        return hocSinh;
    }
    static string CapNhatThongTinHocVien (HocSinh hocSinh)
    {
        if (context.HocSinhs.Any(x => x.HocSinhId == hocSinh.HocSinhId))
        {
            context.HocSinhs.Update(hocSinh);
            context.SaveChanges();
            return "đã cập nhật thành công";
        }
        else return $"Học Viên có Id là {hocSinh.HocSinhId} không tồn tại";
    }
    static string XoaHocVien(int HocSinhId)
    {
        if (context.HocSinhs.Any(x => x.HocSinhId == HocSinhId))
        {
            var hocSinh = context.HocSinhs.Find(HocSinhId);
            context.HocSinhs.Remove(hocSinh);
            context.SaveChanges();
            return "Đã xóa thành công";
        }
        else return $"Học Viên có Id là {HocSinhId} không tồn tại";
    }
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        var lstHocVien = LayDanhSachHocSinh();
        foreach (var hocVien in lstHocVien)
        {
            Console.WriteLine($"Hoc viên {hocVien.HoTen} -- Trình độ hiện tai {hocVien.TrinhDoHienTai} -- Ngày sinh {hocVien.NgaySinh.ToShortDateString} -- Email {hocVien.Email} -- Ngày đăng ký {hocVien.NgayDangKy}");
        }
        var lstHocViens = LayDanhSachHocSinhTheoKey(2002, "An");
        foreach (var hocVien in lstHocViens)
        {
            Console.WriteLine($"Hoc viên {hocVien.HoTen} -- Trình độ hiện tai {hocVien.TrinhDoHienTai} -- Ngày sinh {hocVien.NgaySinh.ToShortDateString} -- Email {hocVien.Email} -- Ngày đăng ký {hocVien.NgayDangKy}");
        }
        HocSinh hocSinh = new HocSinh()
        {
           HoTen = "An",
           NgaySinh = new DateTime(2002, 1, 3),
           NgayDangKy = new DateTime(2021,2,4)
        };
        var res = ThemHocVien(hocSinh);
        Console.ReadLine();
        
    }
}
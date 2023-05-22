using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Websitebangiay.Models;
using System.Data.Entity;
namespace Websitebangiay.Areas.Admin.Controllers
{
    public class ThongkesController : Controller
    {
        private ShopShoe db = new ShopShoe();

        // GET: Admin/Thongkes
        public ActionResult Index()
        {
            var donhangs = db.Donhangs.ToList();
            var dataThongke = (from s in db.Donhangs //Lấy các đơn hàng từ bảng Donhangs trong đối tượng db.
                               join x in db.Nguoidungs on s.MaNguoidung equals x.MaNguoiDung //Kết nối bảng Donhangs với bảng Nguoidungs bằng khóa ngoại MaNguoidung trong Donhangs và khóa chính MaNguoiDung trong Nguoidungs.
                               group s by s.MaNguoidung into g //Gom nhóm các đơn hàng theo MaNguoidung trong Donhangs và lưu vào biến g.
                               select new Thongke //tạo 1 đối tượng thongke
                      {
                          Tennguoidung = g.FirstOrDefault().Nguoidung.Hoten, // lấy tên người dùng đầu tiên trong g
                          Tongtien = g.Sum(x => x.Tongtien), // tính tổng tiền
                          Dienthoai = g.FirstOrDefault().Nguoidung.Dienthoai, // lấy sđt người dùng 
                          Soluong = g.Count() // đếm số lượng đơn hàng trong g
                      });
            var dataFinal = dataThongke.OrderByDescending(s => s.Tongtien).Take(5).ToList(); // sắp xếp theo tổng tiền và lấy ra 5 người đầu tiên 
            return View(dataFinal); // lưu vào biến dataFinal 
        }
    }
}
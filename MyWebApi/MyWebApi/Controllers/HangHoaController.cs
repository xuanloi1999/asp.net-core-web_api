using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Models;
using MyWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> danhSachHangHoa = new List<HangHoa>()
        {
            new HangHoa()
            {
                TenHangHoa = "Abc",
                DonGia = 145667,
                MaHangHoa = Guid.NewGuid()
            },
            new HangHoa()
            {
                TenHangHoa = "xyz",
                DonGia = 20000,
                MaHangHoa = Guid.NewGuid()
            },
            new HangHoa()
            {
                TenHangHoa = "be loi",
                DonGia = 111111,
                MaHangHoa = Guid.NewGuid()
            }
        };
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(danhSachHangHoa);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var ketQua = danhSachHangHoa.Find(x => x.MaHangHoa == id);
            return Ok(new
            { Success = true, Data = ketQua
            });
        }

        [HttpPost]
        public IActionResult Create(HangHoaVM hangHoaVM)
        {
            var hangHoa = new HangHoa
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaVM.TenHangHoa,
                DonGia = hangHoaVM.DonGia

            };
            danhSachHangHoa.Add(hangHoa);
            return Ok(new
            {
                Success = true,
                Data = hangHoa
            });
        }
        
        [HttpPut]
        public IActionResult Edit(Guid id, HangHoa suaHangHoa)
        {
            var ketQua = danhSachHangHoa.Find(x => x.MaHangHoa == id);
            if(ketQua != null)
            {
                ketQua.TenHangHoa = suaHangHoa.TenHangHoa;
                ketQua.DonGia = suaHangHoa.DonGia;
            }
            return Ok(danhSachHangHoa);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var kq = danhSachHangHoa.Find(x => x.MaHangHoa == id);
            danhSachHangHoa.Remove(kq);
            return Ok(danhSachHangHoa);
        }

        

    }
}

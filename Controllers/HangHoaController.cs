using api_ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_ecommerce.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class HangHoaController : ControllerBase
  {
    public static List<HangHoa> hangHoas = new List<HangHoa>();

    [HttpGet]
    public IActionResult GetAll() {
      return Ok(hangHoas);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
      try
      {
        // Linq [Object] query
        var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
        if (hangHoa == null)
        {
          return NotFound();
        }
        return Ok(hangHoa);
      }
      catch
      {
        return BadRequest();
      }
    }

    [HttpPost]
    public IActionResult Create(HangHoaVM hangHoaVM)
    {
      var hanghoa = new HangHoa
      {
        MaHangHoa = Guid.NewGuid(),
        TenHangHoa = hangHoaVM.TenHangHoa,
        DonGia = hangHoaVM.DonGia
      };
      hangHoas.Add(hanghoa);
      return Ok(new
      {
        Success = true,
        Data = hanghoa
      });
    }

    [HttpPut("{id}")]
    public IActionResult Edit(string id, HangHoa hangHoaedit)
    {
      try
      {
        // Linq [Object] query
        var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
        if (hangHoa == null)
        {
          return NotFound();
        }
        if(id != hangHoa.MaHangHoa.ToString())
        {
          return BadRequest();
        }
        //update
        hangHoa.TenHangHoa = hangHoaedit.TenHangHoa;
        hangHoa.DonGia = hangHoaedit.DonGia;

        return Ok();
      }
      catch
      {
        return BadRequest();
      }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
      try
      {
        // Linq [Object] query
        var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
        if (hangHoa == null)
        {
          return NotFound();
        }
        hangHoas.Remove(hangHoa);
        return Ok();
      }
      catch
      {
        return BadRequest();
      }
    }
  }
}

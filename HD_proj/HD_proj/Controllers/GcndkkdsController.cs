using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HD_proj.Data;
using HD_proj.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using HD_proj.Areas.Identity.Pages.Account;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.WebUtilities;

namespace HD_proj.Controllers
{
    public class GcndkkdsController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _env;


        public GcndkkdsController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
             IWebHostEnvironment env
            )
        {
            _env = env;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }




        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            var gcnkd = await (from a in _context.Gcndkkds
                              join b in _context.Giaytotuythans on a.Cmnd equals b.IdCmnd into join1
                              from j1 in join1.DefaultIfEmpty()
                              join c in _context.Quyetdinhs on a.Quyetdinh equals c.Id into join2
                              from j2 in join2.DefaultIfEmpty()
                              select new ModelViewmodel
                              {
                                  Giaytotuythan = j1,
                                  Gcndkkd = a,
                                  Quyetdinh = j2
                              }
                              ).ToListAsync();
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_DataTablePartial", gcnkd);
            }
            return View(gcnkd);
        }

        [Authorize]
        public async Task<IActionResult> Create(Guid? id)
        {
            var gcnkd = new Gcndkkd();
            ViewData["Giayto"] = _context.Giaytotuythans.ToList();
            if (id.HasValue)
            {

                ViewData["File"] = _context.DanhmucFiles.Where(a => a.FatherId == id).ToList();
                gcnkd = await _context.Gcndkkds.FindAsync(id);
                ViewData["Giaytotuythan"] = _context.Giaytotuythans.Where(a => a.IdCmnd == gcnkd.Cmnd).FirstOrDefault();
                ViewData["Quyetdinh"] = _context.Quyetdinhs.Where(a => a.Id == gcnkd.Quyetdinh).FirstOrDefault();
            }

            return PartialView("_OrderPartial", gcnkd);
        }

        // POST: Cchns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Guid? id, [Bind("So,Loai,Tencoso,Truso,Diachikinhdoanh,Loaihinh,Phamvi,Ngaycap,Ngayhieuluc,Trangthai,Nguoikyduyet,Id,Ghichu")] Gcndkkd gcnkd, IFormCollection collect)
        {
            gcnkd.UpdateBy = User.Identity.Name;

            var giayto = _context.Giaytotuythans.AsNoTracking().Where(a => a.IdCmnd == collect["old_giayto"].ToString()).FirstOrDefault();
            if (giayto != null)
            {
                _context.Giaytotuythans.Remove(giayto);
                _context.SaveChanges();
            }
            giayto = new Giaytotuythan();
            giayto.IdCmnd = collect["sogiayto"];
            giayto.Hoten = collect["Hoten"];
            giayto.Noicap = collect["noicap"];
            giayto.Ngaysinh = DateTime.Parse(collect["ngaysinh"]);
            giayto.Ngaycap = DateTime.Parse(collect["ngaycapgiayto"]);
            giayto.Sodienthoai = collect["sodienthoai"];
            giayto.Email = collect["email"];
            giayto.Diachi = collect["diachi"];


            var quyetdinh = new Quyetdinh();
            if (collect["quyetdinhID"].ToString() != Guid.Empty.ToString())
            {
                quyetdinh = _context.Quyetdinhs.Where(a => a.Id == Guid.Parse(collect["quyetdinhID"].ToString())).FirstOrDefault();
                if (quyetdinh != null && quyetdinh.Id != Guid.Parse(collect["quyetdinhID"].ToString()))
                {
                    _context.Quyetdinhs.Remove(quyetdinh);
                    _context.SaveChanges();
                }
            }
            quyetdinh.Id = Guid.NewGuid();
            quyetdinh.Sohieu = collect["sohieuquyetdinh"];
            quyetdinh.Nguoiky = gcnkd.Nguoikyduyet;
            quyetdinh.Ngayky = DateTime.Parse(collect["ngayquyetdinh"]);

            gcnkd.Quyetdinh = quyetdinh.Id;
            gcnkd.Cmnd = collect["sogiayto"];
            gcnkd.Trangthai =Gcndkkd.Trangthaivb.ACTIVE;

            await _context.Quyetdinhs.AddAsync(quyetdinh);
            _context.Giaytotuythans.Add(giayto);



            if (ModelState.IsValid)
            {
                try
                {
                    if (id.HasValue)
                    {
                        _context.Update(gcnkd);
                        await _context.SaveChangesAsync();
                        TempData["Notifications"] = "Updated Successfully";
                    }
                    else
                    {
                        await _context.AddAsync(gcnkd);
                        await _context.SaveChangesAsync();
                        TempData["Notifications"] = " Successfully";
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (id.HasValue && !gcnkdExists(gcnkd.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return PartialView("_OrderPartial", gcnkd);
        }

        [Authorize]
        public async Task<IActionResult> Replace(Guid? id)
        {
            var gcnkd = new Gcndkkd();
            ViewData["Giayto"] = _context.Giaytotuythans.ToList();
            if (id.HasValue)
            {

                ViewData["File"] = _context.DanhmucFiles.Where(a => a.FatherId == id).ToList();
                gcnkd = await _context.Gcndkkds.FindAsync(id);
                ViewData["Giaytotuythan"] = _context.Giaytotuythans.Where(a => a.IdCmnd == gcnkd.Cmnd).FirstOrDefault();
                ViewData["Quyetdinh"] = _context.Quyetdinhs.Where(a => a.Id == gcnkd.Quyetdinh).FirstOrDefault();
            }
            if (gcnkd != null && gcnkd.Trangthai == Gcndkkd.Trangthaivb.ACTIVE)
            {
                return PartialView("_ReplacePartial", gcnkd);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Replace(Guid? id, [Bind("So,Loai,Tencoso,Truso,Diachikinhdoanh,Loaihinh,Phamvi,Ngaycap,Ngayhieuluc,Trangthai,Nguoikyduyet,Id,Ghichu")] Gcndkkd gcnkd, IFormCollection collect)
        {
            gcnkd.UpdateBy = User.Identity.Name;
            var cccu = _context.Gcndkkds.Find(Guid.Parse(collect["Socu"].ToString()));
            if (cccu != null)
            {
                cccu.Trangthai = Gcndkkd.Trangthaivb.REPLACE;
                cccu.Ghichu = cccu.Ghichu + Environment.NewLine + "Đã được thay thế bởi Giáy chứng nhân ĐKKD số: " + gcnkd.So;
            }
            var giayto = _context.Giaytotuythans.AsNoTracking().Where(a => a.IdCmnd == collect["sogiayto"].ToString()).FirstOrDefault();
            if (giayto != null)
            {
                giayto.Hoten = collect["Hoten"];
                giayto.Noicap = collect["noicap"];
                giayto.Ngaysinh = DateTime.Parse(collect["ngaysinh"]);
                giayto.Ngaycap = DateTime.Parse(collect["ngaycapgiayto"]);
                giayto.Sodienthoai = collect["sodienthoai"];
                giayto.Email = collect["email"];
                giayto.Diachi = collect["diachi"];
                _context.Giaytotuythans.Update(giayto);
            }
            else
            {
                var giayto_new = new Giaytotuythan();
                giayto_new.IdCmnd = collect["sogiayto"];
                giayto_new.Hoten = collect["Hoten"];
                giayto_new.Noicap = collect["noicap"];
                giayto_new.Ngaysinh = DateTime.Parse(collect["ngaysinh"]);
                giayto_new.Ngaycap = DateTime.Parse(collect["ngaycapgiayto"]);
                giayto_new.Sodienthoai = collect["sodienthoai"];
                giayto_new.Email = collect["email"];
                giayto_new.Diachi = collect["diachi"];
                _context.Giaytotuythans.Add(giayto_new);
            }

            var quyetdinh = new Quyetdinh();
            quyetdinh.Id = Guid.NewGuid();
            quyetdinh.Sohieu = collect["sohieuquyetdinh"];
            quyetdinh.Nguoiky = gcnkd.Nguoikyduyet;
            quyetdinh.Ngayky = DateTime.Parse(collect["ngayquyetdinh"]);

            gcnkd.Quyetdinh = quyetdinh.Id;
            gcnkd.Cmnd = collect["sogiayto"];
            gcnkd.Trangthai = Gcndkkd.Trangthaivb.ACTIVE;
            gcnkd.Id = Guid.NewGuid();

            _context.Quyetdinhs.Add(quyetdinh);



            if (ModelState.IsValid)
            {
                try
                {
                    await _context.AddAsync(gcnkd);
                    await _context.SaveChangesAsync();
                    TempData["Notifications"] = " Successfully";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (id.HasValue && !gcnkdExists(gcnkd.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return PartialView("_OrderPartial", gcnkd);
        }

        [Authorize]
        public async Task<IActionResult> Delete(Guid? id)
        {
            var gcnkd = new Gcndkkd();
            if (id.HasValue)
            {
                gcnkd = await _context.Gcndkkds.FindAsync(id);
            }
            return PartialView("_DeletePartial", gcnkd);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            var gcnkd = await _context.Gcndkkds.FindAsync(id);
            gcnkd.Trangthai = Gcndkkd.Trangthaivb.CANCEL;
            _context.Update(gcnkd);
            await _context.SaveChangesAsync();
            return PartialView("_DeletePartial", gcnkd);
        }

        [Authorize]
        public async Task<IActionResult> Print(Guid? id)
        {
            var gcnkd = new Gcndkkd();
            ViewData["Giayto"] = _context.Giaytotuythans.ToList();
            if (id.HasValue)
            {

                ViewData["File"] = _context.DanhmucFiles.Where(a => a.FatherId == id).ToList();
                gcnkd = await _context.Gcndkkds.FindAsync(id);
                ViewData["Giaytotuythan"] = _context.Giaytotuythans.Where(a => a.IdCmnd == gcnkd.Cmnd).FirstOrDefault();
                ViewData["Quyetdinh"] = _context.Quyetdinhs.Where(a => a.Id == gcnkd.Quyetdinh).FirstOrDefault();
            }

            return PartialView("_PdfPartialcshtml", gcnkd);
        }



        private bool gcnkdExists(Guid id)
        {
            return _context.Gcndkkds.Any(e => e.Id == id);
        }
    }
}

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
    public class CchnsController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _env;


        public CchnsController(ApplicationDbContext context,
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
            var cchn = await (from a in _context.Cchns
                              join b in _context.Giaytotuythans on a.Cmnd equals b.IdCmnd into join1
                              from j1 in join1.DefaultIfEmpty()
                              join c in _context.Quyetdinhs on a.Quyetdinh equals c.Id into join2
                              from j2 in join2.DefaultIfEmpty()
                              select new ModelViewmodel
                              {
                                 Giaytotuythan = j1,
                                 Cchn = a,
                                 Quyetdinh = j2
                              }
                              ).ToListAsync();
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_DataTablePartial", cchn);
            }
            return View(cchn);
        }

        [Authorize]
        public async Task<IActionResult> Create(Guid? id)
        {
            var cchn = new Cchn();
            ViewData["Giayto"] = _context.Giaytotuythans.ToList();
            if (id.HasValue)
            {
                
                ViewData["File"] = _context.DanhmucFiles.Where(a => a.FatherId == id).ToList();
                cchn = await _context.Cchns.FindAsync(id);
                ViewData["Giaytotuythan"] = _context.Giaytotuythans.Where(a => a.IdCmnd == cchn.Cmnd).FirstOrDefault();
                ViewData["Quyetdinh"] = _context.Quyetdinhs.Where(a => a.Id == cchn.Quyetdinh).FirstOrDefault();
            }

            return PartialView("_OrderPartial", cchn);
        }

        // POST: Cchns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Guid? id, [Bind("So,Ngaycap,Loai,Trinhdo,Phamvi,Hinhthuccap,Ngayhieuluc,Nguoikyduyet,Id,Ghichu")] Cchn cchn, IFormCollection collect)
        {
            cchn.UpdateBy = User.Identity.Name;

            var giayto = _context.Giaytotuythans.Where(a => a.IdCmnd == collect["sogiayto"].ToString()).FirstOrDefault();
            if (giayto != null && giayto.IdCmnd != collect["sogiayto"])
            {
                _context.Remove(giayto);
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
                    _context.Remove(quyetdinh);
                    _context.SaveChanges();
                }
            }
            quyetdinh.Id = Guid.NewGuid();
            quyetdinh.Sohieu = collect["sohieuquyetdinh"];
            quyetdinh.Nguoiky = cchn.Nguoikyduyet;
            quyetdinh.Ngayky = DateTime.Parse(collect["ngayquyetdinh"]);

            cchn.Quyetdinh = quyetdinh.Id;
            cchn.Cmnd = collect["sogiayto"];
           

            await _context.Quyetdinhs.AddAsync(quyetdinh);
            await _context.Giaytotuythans.AddAsync(giayto);



            if (ModelState.IsValid)
            {
                try
                {
                    if (id.HasValue)
                    {
                        _context.Update(cchn);
                        await _context.SaveChangesAsync();
                        TempData["Notifications"] = "Updated Successfully";
                    }
                    else
                    {
                        cchn.Trangthai = Cchn.Trangthaivb.ACTIVE;
                        await _context.AddAsync(cchn);
                        await _context.SaveChangesAsync();
                        TempData["Notifications"] = " Successfully";
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (id.HasValue && !CchnExists(cchn.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return PartialView("_OrderPartial", cchn);
        }

        [Authorize]
        public async Task<IActionResult> Replace(Guid? id)
        {
            var cchn = new Cchn();
            ViewData["Giayto"] = _context.Giaytotuythans.ToList();
            if (id.HasValue)
            {

                ViewData["File"] = _context.DanhmucFiles.Where(a => a.FatherId == id).ToList();
                cchn = await _context.Cchns.FindAsync(id);
                ViewData["Giaytotuythan"] = _context.Giaytotuythans.Where(a => a.IdCmnd == cchn.Cmnd).FirstOrDefault();
             
            }

            return PartialView("_ReplacePartial", cchn);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Replace(Guid? id, [Bind("So,Ngaycap,Loai,Trinhdo,Phamvi,Hinhthuccap,Ngayhieuluc,Nguoikyduyet,Id,Ghichu")] Cchn cchn, IFormCollection collect)
        {
            cchn.UpdateBy = User.Identity.Name;

            var giayto = _context.Giaytotuythans.Where(a => a.IdCmnd == collect["sogiayto"].ToString()).FirstOrDefault();
            if (giayto != null && giayto.IdCmnd != collect["sogiayto"])
            {
                giayto.Hoten = collect["Hoten"];
                giayto.Noicap = collect["noicap"];
                giayto.Ngaysinh = DateTime.Parse(collect["ngaysinh"]);
                giayto.Ngaycap = DateTime.Parse(collect["ngaycapgiayto"]);
                giayto.Sodienthoai = collect["sodienthoai"];
                giayto.Email = collect["email"];
                giayto.Diachi = collect["diachi"];
                _context.Giaytotuythans.Update(giayto);
                _context.SaveChanges();
            }
            else
            {
                giayto = new Giaytotuythan();
                giayto.IdCmnd = collect["sogiayto"];
                giayto.Hoten = collect["Hoten"];
                giayto.Noicap = collect["noicap"];
                giayto.Ngaysinh = DateTime.Parse(collect["ngaysinh"]);
                giayto.Ngaycap = DateTime.Parse(collect["ngaycapgiayto"]);
                giayto.Sodienthoai = collect["sodienthoai"];
                giayto.Email = collect["email"];
                giayto.Diachi = collect["diachi"];
                _context.Giaytotuythans.Update(giayto);
                _context.SaveChanges();
            }

            var quyetdinh = new Quyetdinh();
            quyetdinh.Id = Guid.NewGuid();
            quyetdinh.Sohieu = collect["sohieuquyetdinh"];
            quyetdinh.Nguoiky = cchn.Nguoikyduyet;
            quyetdinh.Ngayky = DateTime.Parse(collect["ngayquyetdinh"]);

            cchn.Quyetdinh = quyetdinh.Id;
            cchn.Cmnd = collect["sogiayto"];
            cchn.Trangthai = Cchn.Trangthaivb.ACTIVE;
            cchn.Id = Guid.NewGuid();

            await _context.Quyetdinhs.AddAsync(quyetdinh);
            await _context.Giaytotuythans.AddAsync(giayto);



            if (ModelState.IsValid)
            {
                try
                {
                        await _context.AddAsync(cchn);
                        await _context.SaveChangesAsync();
                        TempData["Notifications"] = " Successfully";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (id.HasValue && !CchnExists(cchn.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return PartialView("_OrderPartial", cchn);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cchn = await _context.Cchns
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cchn == null)
            {
                return NotFound();
            }

            return View(cchn);
        }

        // POST: Cchns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var cchn = await _context.Cchns.FindAsync(id);
            _context.Cchns.Remove(cchn);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CchnExists(Guid id)
        {
            return _context.Cchns.Any(e => e.Id == id);
        }
    }
}

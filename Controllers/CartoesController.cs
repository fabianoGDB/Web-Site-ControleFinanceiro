using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Site.GerenciadorCartao.Database;
using Web.Site.GerenciadorCartao.Models;

namespace Web.Site.GerenciadorCartao.Controllers
{
    public class CartoesController : Controller
    {
        private readonly DatabaseContext _context;
        public CartoesController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        // Novo
        [HttpGet]
        public IActionResult NovoCartao()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NovoCartao(Cartao cartao)
        {
            if (ModelState.IsValid)
            {
                await _context.Cartoes.AddAsync(cartao);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cartao);
        }

        // Listagem
        [HttpGet]
        public async Task<IActionResult> ListagemCartoes()
        {
            return View(await _context.Cartoes.ToListAsync());
        }
        
        // Atualizar
        [HttpGet]
        public async Task<IActionResult> AtualizarCartao(int id)
        {
            Cartao cartao = await _context.Cartoes.FindAsync(id);
            if (cartao != null)
            {
                return View(cartao);
            }
            return NotFound();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AtualizarCartao(Cartao cartao, int id)
        {
           
            if (cartao.Id != id){
                return NotFound();
            }
            
            if (ModelState.IsValid){
                    
                _context.Cartoes.Update(cartao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListagemCartoes));
            }
                
            // TempData["ErrorMessage"] = "Dados inválidos";
            return View(cartao);
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirCartao(int id)
        {
            Cartao cartao = await _context.Cartoes.FindAsync(id);
            _context.Cartoes.Remove(cartao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListagemCartoes));
        }
        
    }
}
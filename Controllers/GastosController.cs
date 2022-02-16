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
    public class GastosController : Controller
    {
        private readonly DatabaseContext _context;

        public GastosController(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> ListagemGastos(int cartaoId)
        {
            Cartao cartao = await _context.Cartoes.FindAsync(cartaoId);
            double soma = await _context.Gastos.Where(c => c.CartaoId == cartaoId).SumAsync(c => c.Valor);

            GastosViewModel gastosViewModel = new GastosViewModel
            {
                CartaoId = cartaoId,
                NumeroCartao = cartao.NumeroCartao,
                ListaGastos = await _context.Gastos.Where(c => c.CartaoId == cartaoId).ToListAsync(),
                PorcentagemGasto = Convert.ToInt32((soma / cartao.Limite) * 100)
            };

            return View(gastosViewModel);
        }

        [HttpGet]
        public IActionResult NovoGasto(int cartaoId)
        {
            Gasto gasto = new Gasto
            {
                CartaoId = cartaoId
            };

            return View(gasto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NovoGasto(Gasto gasto)
        {
            if (ModelState.IsValid)
            {
                await _context.AddAsync(gasto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListagemGastos), new {cartaoId = gasto.CartaoId});
            }

            return View(gasto);
        }

        [HttpGet]
        public async Task<IActionResult> AtualizarGasto(int gastoId)
        {
            Gasto gasto = await _context.Gastos.FindAsync(gastoId);
            
            if (gasto == null)
                return NotFound();

            return View(gasto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AtualizarGasto(int gastoId, Gasto gasto)
        {
            if (!ModelState.IsValid) 
                return View(gasto);
            
            _context.Update(gasto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListagemGastos), new { cartaoId = gasto.CartaoId });

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExcluirGasto(int gastoId)
        {
            Gasto gasto = await _context.Gastos.FindAsync(gastoId);
            _context.Remove(gasto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListagemGastos), new { cartaoId = gasto.CartaoId });
        }
        
    }
}
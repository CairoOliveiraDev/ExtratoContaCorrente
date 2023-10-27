namespace ExtratoContaCorrente.Controllers
{
    using ExtratoContaCorrente.Context;
    using ExtratoContaCorrente.Model;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [Route("api/lancamentos")]
    [ApiController]
    public class LancamentosController : ControllerBase
    {
        // MOCK private List<Lancamento> lancamentos = new List<Lancamento>();

        private readonly LancamentoContext _context;

        public LancamentosController(LancamentoContext context)
        {
            _context = context;
        }

        // Obter lançamentos com base no range de datas
        [HttpGet]
        public IActionResult ObterLancamentos(DateTime dataInicial, DateTime dataFinal)
        {
            var lancamentosFiltrados = _context.Lancamentos
                .Where(l => l.Data >= dataInicial && l.Data <= dataFinal)
                .ToList();
            return Ok(lancamentosFiltrados);
        }

        // Inserir um lançamento
        [HttpPost]
        public IActionResult InserirLancamento(Lancamento lancamento)
        {
            lancamento.Status = "Válido";
            _context.Lancamentos.Add(lancamento);
            _context.SaveChanges();
            return Ok(lancamento);
        }

        // Atualizar  lançamento por ID
        [HttpPut("{id}")]
        public IActionResult AtualizarLancamento(int id, Lancamento lancamento)
        {
            var lancamentoExistente = _context.Lancamentos.FirstOrDefault(l => l.Id == id);
            if (lancamentoExistente == null)
            {
                return NotFound();
            }

            lancamentoExistente.Valor = lancamento.Valor;
            lancamentoExistente.Data = lancamento.Data;
            _context.SaveChanges();

            return Ok(lancamentoExistente);
        }

        // Cancelar um lançamento por ID
        [HttpDelete("{id}")]
        public IActionResult CancelarLancamento(int id)
        {
            var lancamentoExistente = _context.Lancamentos.FirstOrDefault(l => l.Id == id);
            if (lancamentoExistente == null)
            {
                return NotFound();
            }

            lancamentoExistente.Status = "Cancelado";
            _context.SaveChanges(); // Salvar as alterações no banco de dados

            return Ok(lancamentoExistente);
        }
    }
}

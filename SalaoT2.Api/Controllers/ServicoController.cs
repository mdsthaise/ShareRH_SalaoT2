using Microsoft.AspNetCore.Mvc;
using SalaoT2.Dominio;
using System.Collections.Generic;

namespace SalaoT2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly MinhaBaseServicos baseServico;

        public ServicoController()
        {
            baseServico = new MinhaBaseServicos();
        }

        [HttpGet]
        public IEnumerable<Servico> Get()
        {
            return baseServico.Servicos;
        }
        
        [HttpGet("{id}")]
        public Servico Get(int id)
        {
            return baseServico.ConsultarPorId(id);
        }
        
        [HttpPost]
        public IEnumerable<Servico> Post([FromBody] Servico servico)
        {
            baseServico.Incluir(servico);
            return baseServico.Servicos;
        }
        
        [HttpPut("{id}")]
        public IEnumerable<Servico> Put(int id, [FromBody] Servico servico)
        {
            baseServico.AlterarUmServico(id, servico.Nome, servico.MinutosParaExecucao, servico.Preco);
            return baseServico.Servicos;
        }
        
        [HttpDelete("{id}")]
        public IEnumerable<Servico> Delete(int id)
        {
            baseServico.ExcluirUmServico(id);
            return baseServico.Servicos;
        }
    }
}

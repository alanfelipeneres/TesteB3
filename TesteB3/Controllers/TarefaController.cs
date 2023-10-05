using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TesteB3.Core.BO;
using TesteB3.Core.Models;
using TesteB3.Core.Repository;

namespace TesteB3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private UnitOfWork _unit;
        private TarefaBO _tarefaBO;

        private readonly ILogger<TarefaController> _logger;

        public TarefaController(ILogger<TarefaController> logger)
        {
            _logger = logger;
            _unit = new UnitOfWork();
            _tarefaBO = new TarefaBO(_unit);
        }

        [HttpGet()]
        public IEnumerable<Tarefa> Get() => _tarefaBO.Listar();

        [HttpGet("{idTarefa}")]
        public Tarefa GetById(int idTarefa) => _tarefaBO.ListarPorId(idTarefa);

        [HttpPost]
        public Tarefa Post(Tarefa tarefa) => _tarefaBO.Salvar(tarefa);

        [HttpDelete]
        public void Delete(int idTarefa) => _tarefaBO.Excluir(idTarefa);

        [HttpPut]
        public Tarefa Put(Tarefa tarefa) => _tarefaBO.Alterar(tarefa);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using TesteB3.Core.BO.Base;
using TesteB3.Core.Models;
using TesteB3.Core.Repository;
using TesteB3.RabbitMq;

namespace TesteB3.Core.BO
{
    public class TarefaBO : BaseBO<Tarefa>
    {
        private UnitOfWork _unit;
        private Publisher _publisher;

        public TarefaBO(UnitOfWork unit) : base(unit.Context)
        {
            _unit = unit;
            _publisher = new Publisher();
        }

        public Tarefa Salvar(Tarefa tarefa)
        {
            if (string.IsNullOrWhiteSpace(tarefa.Descricao))
                throw new Exception("Descrição é um campo obrigatório");

            if(tarefa.IdTarefa == 0)
                base.Add(tarefa);
            else
                base.Update(tarefa);

            base.SaveChanges();

            _publisher.SendMessage(JsonSerializer.Serialize(tarefa), "testeB3");

            return tarefa;
        }

        public List<Tarefa> Listar()
        {
            var tarefas = _unit.Context.Tarefa.ToList();


            if (tarefas == null || tarefas.Count() == 0)
            {
                throw new Exception("Nenhum registro encontrado");
            }

            return tarefas;
        }

        public Tarefa ListarPorId(int idTarefa)
        {
            var tarefa = base.GetById(idTarefa);
            return tarefa;
        }

        public void Excluir(int idTarefa)
        {
            Tarefa tarefa = base.GetById(idTarefa);

            if (tarefa == null || tarefa.IdTarefa == 0)
                throw new Exception("Task não encontrada");

            var task = base.GetByIdNoTracking(tarefa.IdTarefa);

            if (task == null)
                throw new Exception("Task não encontrada");

            base.Delete(tarefa);
            base.SaveChanges();
        }

        public Tarefa Alterar(Tarefa tarefa)
        {
            if (tarefa == null || tarefa.IdTarefa == 0)
                throw new Exception("Task não encontrada");

            var task = base.GetByIdNoTracking(tarefa.IdTarefa);

            if (task == null)
                throw new Exception("Task não encontrada");

            base.Update(tarefa);
            base.SaveChanges();

            return tarefa;
        }
    }
}

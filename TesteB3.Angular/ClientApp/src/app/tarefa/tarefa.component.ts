import { Component } from '@angular/core';
import { ApiService } from "../../api/ApiService";
import * as moment from 'moment';

@Component({
  selector: 'app-root',
  templateUrl: './tarefa.component.html'
})
export class TarefaComponent {

  tarefas: any[] | undefined;
  formTarefa: any = {};
  showCadastro: boolean | undefined;

  constructor(private apiService: ApiService) { }

  ngOnInit() {
    this.showCadastro = false;
    this.apiService.getTarefa().subscribe((data: any[]) => {
      this.tarefas = data;
    });
  }

  onExcluir(id: number) {
    if (confirm("Pressione OK para excluir, CANCELAR para manter o registro")) {
      this.apiService.deleteTarefa(id);
      location.reload();
    }
  }

  onAlterar(id: number) {
    

    this.validarShowCadastro();
    this.apiService.getTarefaById(id).subscribe(event => {
      this.formTarefa = event;
      this.formTarefa.data = moment(this.formTarefa.data).format("DD/MM/YYYY");
    });
  }

  novaTarefa() {
    this.formTarefa = {};
    this.validarShowCadastro();
  }

  submitFormTarefa() {
    debugger;

    if (!this.formTarefa.descricao) {
      alert("Descrição é de preenchimento de obrigatório.");
      return;
    }
      

    if (!this.formTarefa.data) {
      alert("Data é de preenchimento de obrigatório.");
      return;
    }

    let data = moment(this.formTarefa.data, 'DD/MM/YYYY').toDate();
    if (data < moment().toDate()) {
      alert("A Data não pode ser menor que adata atual.");
      return;
    }

    this.formTarefa.data = moment(this.formTarefa.data, 'DD/MM/YYYY').toDate();
    this.formTarefa.status = !this.formTarefa.idTarefa ? 1 : parseInt(this.formTarefa.status);

    this.apiService.addTarefa(this.formTarefa).subscribe();

    this.validarShowCadastro();
    location.reload();
  }

  validarShowCadastro() {
    this.showCadastro = !this.showCadastro;
  }
}

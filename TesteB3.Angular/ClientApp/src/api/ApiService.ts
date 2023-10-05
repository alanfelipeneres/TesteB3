import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  apiUrl = 'https://localhost:7170';

  constructor(private http: HttpClient) { }

  getTarefa(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/tarefa`);
  }

  getTarefaById(id: number): Observable<any> {
    //this.http.get<any>(`${this.apiUrl}/Tarefa/${id}`).subscribe(x => this.object = x);
    //console.log(this.object);
    //alert(`${this.apiUrl}/Tarefa/${id}`);

    return this.http.get<any>(`${this.apiUrl}/Tarefa/${id}`);
  }

  addTarefa(tarefa: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/Tarefa`, tarefa);
  }

  updateTarefat(id: number, post: any): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/Tarefa/${id}`, post);
  }

  deleteTarefa(id: number){
    var request = `${this.apiUrl}/Tarefa?idTarefa=${id}`;
    //alert("No service " + id + ` ${request}`);
    this.http.delete(request).subscribe(() => console.log("Excluído"));
  }
}

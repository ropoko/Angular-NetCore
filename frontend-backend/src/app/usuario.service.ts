import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { Observable, throwError } from 'rxjs';  
import { Usuario } from './usuario'; 
var httpOptions = {headers: new HttpHeaders({"Content-Type": "application/json"})};
@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  url = 'http://localhost:5000/api/Usuarios';  

  constructor(private http: HttpClient) { }

  getAllUsuarios(): Observable<Usuario[]> {  
    return this.http.get<Usuario[]>(this.url);  
  }  

  getUsuarioById(id: string): Observable<Usuario> {  
    const apiurl = `${this.url}/${id}`;
    return this.http.get<Usuario>(apiurl);  
  } 
  
  createUsuario(Usuario: Usuario): Observable<Usuario> {  
    return this.http.post<Usuario>(this.url, Usuario, httpOptions);  
  }  

  updateUsuario(id: string, Usuario: Usuario): Observable<Usuario> {  
    const apiurl = `${this.url}/${id}`;
    return this.http.put<Usuario>(apiurl,Usuario, httpOptions);  
  }  
  
  deleteUsuarioById(id: string): Observable<number> {  
    const apiurl = `${this.url}/${id}`;
    return this.http.delete<number>(apiurl, httpOptions);  
  }  

  // handleError(error: HttpErrorResponse){
  //   return throwError(error);
  // }
}
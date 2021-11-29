import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Usuario } from "../models/usuario";

@Injectable({
    providedIn: "root",
})
export class UsuarioService {
    private baseUrl = "http://localhost:5000/api/usuario";

    constructor(private http: HttpClient) {}

    list(): Observable<Usuario[]> {
        return this.http.get<Usuario[]>(`${this.baseUrl}/list`);
    }
    create(usuario: Usuario): Observable<Usuario> {
        return this.http.post<Usuario>(`${this.baseUrl}/create`, usuario);
    }
}

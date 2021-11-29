import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Amigo } from "../models/amigo";

@Injectable({
    providedIn: "root",
})
export class AmigoService {
    private baseUrl = "http://localhost:5000/api/amigo";

    constructor(private http: HttpClient) {}

    list(): Observable<Amigo[]> {
        return this.http.get<Amigo[]>(`${this.baseUrl}/list`);
    }
    create(amigo: Amigo): Observable<Amigo> {
        return this.http.post<Amigo>(`${this.baseUrl}/create`, amigo);
    }
}

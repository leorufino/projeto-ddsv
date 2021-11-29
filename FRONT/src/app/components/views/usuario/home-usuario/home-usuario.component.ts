import { Component, OnInit } from "@angular/core";
import { Amigo } from "src/app/models/amigo";
import { AmigoService } from "src/app/services/amigo.service";

@Component({
    selector: "app-home-usuario",
    templateUrl: "./home-usuario.component.html",
    styleUrls: ["./home-usuario.component.css"],
})
export class HomeUsuarioComponent implements OnInit {
    amigos: Amigo[] = [];
    colunasExibidas: String[] = [
        "id",
        "nome",
        "email"
    ];

    constructor(private service: AmigoService) {}

    ngOnInit(): void {
        this.service.list().subscribe((amigos) => {
            this.amigos = amigos;
        });
    }
}

import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Usuario } from "src/app/models/usuario";
import { UsuarioService } from "src/app/services/usuario.service";

@Component({
    selector: "app-index",
    templateUrl: "./index.component.html",
    styleUrls: ["./index.component.css"],
})
export class IndexComponent implements OnInit {
    usuarios: Usuario[] = [];

    constructor(
        private usuarioService: UsuarioService,
        private router: Router
    ) {}

    ngOnInit(): void {
        this.usuarioService.list().subscribe((usuarios) => {
            this.usuarios = usuarios;
        });
    }
}

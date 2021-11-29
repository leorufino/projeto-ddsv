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
    email!: string;
    senha!: string;

    constructor(
        private usuarioService: UsuarioService,
        private router: Router
    ) {}

    ngOnInit(): void {

    }

    logar(): void {
        let usuario: Usuario = {
            email: this.email,
            senha: this.senha,
            nome: "",
            sobrenome: "",
            cpf: "",
            dataNascimento: ""
        };
        this.usuarioService.login(usuario).subscribe((usuario) => {
            console.log(usuario);
            this.router.navigate(["usuario/home"]);
        });
    }

    criarConta(): void {
         this.router.navigate(["usuario/cadastrar"]);
    }
}

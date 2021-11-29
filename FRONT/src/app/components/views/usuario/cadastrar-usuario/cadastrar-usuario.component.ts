import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Usuario } from "src/app/models/usuario";
import { UsuarioService } from "src/app/services/usuario.service";

@Component({
    selector: "app-cadastrar-usuario",
    templateUrl: "./cadastrar-usuario.component.html",
    styleUrls: ["./cadastrar-usuario.component.css"],
})
export class CadastrarUsuarioComponent implements OnInit {
    nome!: string;
    sobrenome!: string;
    cpf!: string;
    dataNascimento!: string;
    email!: string;
    senha!: string;

    constructor(
        private router: Router,
        private usuarioService: UsuarioService,
    ) {}

    ngOnInit(): void {

    }

    cadastrar(): void {
        let usuario: Usuario = {
            nome: this.nome,
            sobrenome: this.sobrenome,
            cpf: this.cpf,
            dataNascimento: this.dataNascimento,
            email: this.email,
            senha: this.senha
        };
        this.usuarioService.create(usuario).subscribe((usuario) => {
            console.log(usuario);
            this.router.navigate(["usuario/home"]);
        });
    }
}

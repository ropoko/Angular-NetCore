import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { UsuarioService } from '../Usuario.service';
import { Usuario } from '../Usuario';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})

export class UsuarioComponent implements OnInit {

  hide = true;
  dataSaved = false;
  userForm: any;
  allUsuarios: Observable<Usuario[]>;
  UsuarioIdUpdate = null;
  //message = null;

  constructor(private formbulider: FormBuilder, private UsuarioService: UsuarioService) { }

  ngOnInit() {
    this.userForm = this.formbulider.group({
      Nome: ['', [Validators.required]],
      Email: ['', [Validators.email]],
      Password: ['', [Validators.required]],
      Role: ['']
    });

    this.loadAllUsuarios();
  }
  loadAllUsuarios() {
    this.allUsuarios = this.UsuarioService.getAllUsuarios();
  }
  onFormSubmit() {
    this.dataSaved = false;
    const Usuario = this.userForm.value;
    this.CreateUsuario(Usuario);
    console.log(Usuario);
    this.successMessage();
    this.userForm.reset();
  }
  CreateUsuario(Usuario: Usuario) {
    try {
      let email = this.userForm.get('Email').value;
      console.log(this.UsuarioIdUpdate);
      if (this.UsuarioIdUpdate == null) {
        this.allUsuarios.subscribe((data: Usuario[]) => {
          let usuEmail = data.find(u => u.email == email);

          if (usuEmail != undefined) {
            Swal.fire({
              icon: 'error',
              title: 'Oops!',
              text: 'O email que está tentando cadastrar já está sendo utilizado'
            });
            this.userForm.reset();
            return;
          }
          else {
            this.UsuarioService.createUsuario(Usuario).subscribe(
              () => {
                this.dataSaved = true;
                //this.message = 'Registro salvo com sucesso';
                this.loadAllUsuarios();
                this.UsuarioIdUpdate = null;
              }
            );
          }
        });

      } else {
        Usuario.idUsuario = this.UsuarioIdUpdate;

        this.UsuarioService.updateUsuario(this.UsuarioIdUpdate, Usuario).subscribe(() => {
          this.dataSaved = true;
          //this.message = 'Registro atualizado com sucesso';
          this.loadAllUsuarios();
          this.UsuarioIdUpdate = null;
        });
      }
    } catch (error) {
      this.dataSaved = false;
      console.log(error);
      this.errorMessage();
    }

    this.userForm.reset();
  }

  loadUsuarioToEdit(Usuarioid: string) {
    this.UsuarioService.getUsuarioById(Usuarioid).subscribe(Usuario => {
      //this.message = null;
      this.dataSaved = false;
      this.UsuarioIdUpdate = Usuario.idUsuario;
      this.userForm.controls['Nome'].setValue(Usuario.nome);
      this.userForm.controls['Email'].setValue(Usuario.email);
      this.userForm.controls['Role'].setValue(Usuario.role);
      this.userForm.controls['Password'].setValue(Usuario.password);
    });
  }

  deleteUsuario(Usuarioid: string) {
    Swal.fire({
      title: 'Tem certeza que deseja excluir?',
      text: "esta ação não pode ser revertida!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Sim, excluir!'
    }).then((result) => {
      if (result.isConfirmed) {
        this.UsuarioService.deleteUsuarioById(Usuarioid).subscribe(() => {
          this.dataSaved = true;
          this.loadAllUsuarios();
          this.UsuarioIdUpdate = null;
          this.userForm.reset();
        });

        Swal.fire(
          'Excluido!',
          'O usuário foi excluído',
          'success'
        )
      }
    })
  }

  resetForm() {
    this.userForm.reset();
    //this.message = null;
    this.dataSaved = false;
  }

  successMessage() {
    Swal.fire({
      title: "Cadastrado com sucesso!",
      text: "O usuário foi gravado no sistema.",
      icon: "success",
    });
  }

  errorMessage() {
    Swal.fire({
      title: "Oops!",
      text: "Ocorreu um erro, tente novamente em instantes.",
      icon: "warning",
    });
  }
}

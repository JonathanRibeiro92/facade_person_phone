import { Component, ElementRef, OnInit, ViewChild } from "@angular/core";
import { FormBuilder, Validators } from "@angular/forms";
import { Phone } from "src/app/models/phone";
import { PhoneService } from "src/app/services/phone.service";

@Component({
  selector: "app-phone",
  templateUrl: "./phone.component.html",
  styleUrls: ["./phone.component.css"],
})
export class PhoneComponent implements OnInit {
  dataSaved = false;
  phoneNaoEncontrado = false;
  phoneForm: any;
  allPhones: Phone[];
  phoneIdUpdate = null;
  message = null;
  opcaoPesquisa: string;
  @ViewChild("campoBusca") campoBuscaElement: ElementRef;
  key: string;
  reverse = false;

  constructor(
    private formbulider: FormBuilder,
    private phoneService: PhoneService,
    private element: ElementRef
  ) {}

  ngOnInit(): void {
    this.phoneForm = this.formbulider.group({
      Numero: ["", [Validators.required]],
      Tipo: [""]
    });
    this.loadAllPhones();
    this.opcaoPesquisa = "1";
  }

  loadAllPhones(): void {
    this.phoneService
      .getAllPhones()
      .subscribe((phoneList) => (this.allPhones = phoneList.phoneObjects));
  }

  onFormSubmit(): void {
    this.dataSaved = false;
    this.phoneNaoEncontrado = false;
    const aluno = this.phoneForm.value;
    this.CreatePhone(aluno);
    this.phoneForm.reset();
  }

  CreatePhone(phone: Phone): void {
    if (this.phoneIdUpdate == null) {
      this.phoneService.createPhone(phone).subscribe(() => {
        this.dataSaved = true;
        this.phoneNaoEncontrado = false;
        this.message = "Cadastro de telefone realizado com sucesso";
        this.loadAllPhones();
        this.phoneIdUpdate = null;
        this.phoneForm.reset();
        this.campoBuscaElement.nativeElement.value = null;
      });
    } else {
      phone.BusinessEntityID = this.phoneIdUpdate;
      this.phoneService.updatePhone(this.phoneIdUpdate, phone).subscribe(() => {
        this.dataSaved = true;
        this.phoneNaoEncontrado = false;
        this.message = "Cadastro de telefone atualizado com sucesso";
        this.loadAllPhones();
        this.phoneIdUpdate = null;
        this.phoneForm.reset();
        this.campoBuscaElement.nativeElement.value = null;
      });
    }
  }

  loadPhoneToEdit(phoneId: number): void {
    this.phoneService.getPhone(phoneId).subscribe((phoneResponse) => {
      this.message = null;
      this.dataSaved = false;
      this.phoneIdUpdate = phoneResponse.phoneObject.BusinessEntityID;
      this.phoneForm.controls.Numero.setValue(
        phoneResponse.phoneObject.PhoneNumber
      );
      this.phoneForm.controls.Tipo.setValue(
        phoneResponse.phoneObject.PhoneNumberType
      );
    });
  }

  pesquisarPhone(campoBusca: number): void {
    if (this.opcaoPesquisa == "1") {
      this.phoneService.getPhone(campoBusca).subscribe(
        (phoneResponse) => {
          this.message = null;
          this.dataSaved = false;
          this.phoneIdUpdate = phoneResponse.phoneObject.BusinessEntityID;
          this.phoneForm.controls.Numero.setValue(
            phoneResponse.phoneObject.PhoneNumber
          );
          this.phoneForm.controls.Tipo.setValue(
            phoneResponse.phoneObject.PhoneNumberType
          );
        },
        (err) => {
          this.message = "Aluno não encontrado";
          this.phoneNaoEncontrado = true;
        }
      );
    } else {
      this.phoneService.getPhone(campoBusca).subscribe(
        (phoneResponse) => {
          this.message = null;
          this.dataSaved = false;
          this.phoneIdUpdate = phoneResponse.phoneObject.BusinessEntityID;
          this.phoneForm.controls.Numero.setValue(
            phoneResponse.phoneObject.PhoneNumber
          );
          this.phoneForm.controls.Tipo.setValue(
            phoneResponse.phoneObject.PhoneNumberType
          );
        },
        (err) => {
          this.message = "Telefone não encontrado";
          this.phoneNaoEncontrado = true;
        }
      );
    }
  }

  deletePhone(phoneId: number): void {
    if (confirm("Deseja realmente excluir o cadastro desse aluno ?")) {
      this.phoneService.deletePhone(phoneId).subscribe(() => {
        this.dataSaved = true;
        this.message = "Cadastro do telefone foi excluído com sucesso";
        this.loadAllPhones();
        this.phoneIdUpdate = null;
        this.phoneForm.reset();
      });
    }
  }

  resetForm(): void {
    this.phoneForm.reset();
    this.message = null;
    this.dataSaved = true;
    this.phoneNaoEncontrado = false;
  }
}

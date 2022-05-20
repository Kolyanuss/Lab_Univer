import { Component } from "@angular/core";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"],
})
export class AppComponent {
  name: string = "Петро";
  surname: string = "Петренко";
  age: number = 25;

  langs = {
    name: "Petro",
    surname: "Petrenko",
    age: 25,
  };

  countries = {
    Варшава: "Poland",
    Вільнюс: "Litva",
    Київ: "Ukraine",
  };

  workers = [
    { name: "Anton", age: 20, salary: 15000 },
    { name: "Roman", age: 18, salary: 18900 },
    { name: "Alex", age: 20, salary: 10000 },
  ];

  arrLang = ["html", "css", "js", "php"];

  ngOnInit(): void {}

  changeName() {
    this.name = "Dmytro";
  }

  change(el: any) {
    if (el == 1) this.name = "Ivan";
    if (el == 2) this.surname = "Ivanov";
    if (el == 3) this.age = 30;
  }

  changeSql() {
    var myIndex = this.arrLang.indexOf("php");
    this.arrLang[myIndex] = "sql";
  }

  addToArr() {
    this.arrLang.push("sql");
  }

  addToStart() {
    this.arrLang.unshift("sql");
  }

  deleteHtml() {
    var myIndex = this.arrLang.indexOf("html");
    this.arrLang.splice(myIndex, 1);
  }

  deletePhp() {
    var myIndex = this.arrLang.indexOf("php");
    this.arrLang.splice(myIndex, 1);
  }
}

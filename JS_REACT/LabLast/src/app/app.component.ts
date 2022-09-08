import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'LabLast';
  sqrt = 0;
  num = 9;

  showSqrt() {
    this.sqrt = Math.sqrt(this.num);
  }

}

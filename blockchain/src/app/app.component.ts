import { Component, OnInit } from '@angular/core';
import { BlockService } from './history-service.service';
import { BlockEntity } from './model/blockmodel';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  title = 'blockchain';
  items: BlockEntity[] = [];
  constructor(private service: BlockService) {

  }
  ngOnInit(): void {
    this.load();
    // setInterval(x => {
    //   this.load();
    // }, 20000)
  }

  load() {
    this.service.getHistory()
      .subscribe(data => {
        this.items = data.data
      }, err => {
        console.log(err);
      })
  }

  sortData(criteria: number) {
    switch (criteria) {
      case 1:
        this.items.sort((x, y) => x.gasLimit.localeCompare(y.gasLimit));
        break;
      case 2:
        this.items.sort((x, y) => x.gasUsed.localeCompare(y.gasUsed));
        break;
      case 3:
        this.items.sort((x, y) => x.hash.localeCompare(y.hash));
        break;
      case 4:
        this.items.sort((x, y) => x.size.localeCompare(y.size));
        break;
      case 5:
        this.items.sort((x, y) => x.timestamp.localeCompare(y.timestamp));
        break;
    }
  }
}

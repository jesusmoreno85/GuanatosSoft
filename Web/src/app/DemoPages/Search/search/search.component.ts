import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { RestaurantService } from 'src/app/Services/restaurant.service';
import { Restaurant } from 'src/app/Services/restaurant.model';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html'
})
export class SearchComponent implements OnInit {
  searchForm: FormGroup;
  textControl = new FormControl('', Validators.required);
  showErrors = false;
  restaurants: Restaurant[] = [];

  constructor(
    private titleService: Title,
    private restaurantService: RestaurantService) { }

  ngOnInit() {
    this.titleService.setTitle(`Search - ${this.titleService.getTitle()}`);

    this.searchForm = new FormGroup({
      text: this.textControl,
    });
  }

  onSearch() {
    this.showErrors = true;
    if (this.searchForm.invalid) { return; }

    this.restaurantService.searchByText(this.textControl.value).subscribe((res) => {
      this.restaurants = res;
    });
  }
}

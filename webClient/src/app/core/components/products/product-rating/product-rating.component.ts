import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { IconDefinition, faStarHalfStroke, faStar as faStarSolid} from '@fortawesome/free-solid-svg-icons';
import { faStar as faStarRegular } from '@fortawesome/free-regular-svg-icons';
import { ProductRating } from 'src/app/core/models/productRating';
import { ProductService } from 'src/app/core/services/product.service';

@Component({
  selector: 'app-product-rating',
  standalone: true,
  imports: [CommonModule, FontAwesomeModule],
  templateUrl: './product-rating.component.html',
  styleUrls: ['./product-rating.component.scss']
})
export class ProductRatingComponent implements OnInit{
  // Fontawsome icons
  readonly fa = {
    star: faStarSolid,
    starHalf: faStarHalfStroke,
    starEmpty: faStarRegular
  }
  @Input() productRating: ProductRating | undefined;

  availableSymbols = {
    0: this.fa.starEmpty,
    1: this.fa.star
  }
  ratingSymbols = [
    this.fa.starEmpty, this.fa.starEmpty, this.fa.starEmpty, this.fa.starEmpty, this.fa.starEmpty
  ];
  private initialSymbols: IconDefinition[] = [];

  constructor(private productService: ProductService){}
  
  ngOnInit(): void {
    this.initSymbols();
  }

  // TODO make this more responsive
  initSymbols(){
    this.populateSymbolsFromData();
    this.initialSymbols = [...this.ratingSymbols];
  }

  onMouseEnter(symbolIndex: number){
    if(!this.productRating || !this.productRating.ratable) return;
    this.populateSymbols(symbolIndex + 1);
  }

  onMouseOut(){
    this.ratingSymbols = [...this.initialSymbols];
  }

  //TODO Implement reload mechanism
  // Certain properties should be filled
  onClick(symbolIndex: number){
    if(!this.productRating || !this.productRating.ratable) return;
    this.productService.addReview({
      rating: symbolIndex + 1,
      productId: this.productRating.productId
    }).subscribe({
      next: review => console.log(review),
      error: error => console.log(error)
    });
  }

  //TODO Implement this for decimal number
  private populateSymbols(fullCount: number){
    for(var i = 0; i < 5; i++){
      if(i < fullCount){
        this.ratingSymbols[i] = this.fa.star;
      }
      else{
        this.ratingSymbols[i] = this.fa.starEmpty;
      }
    }
  }

  private populateSymbolsFromData(){
    if(!this.productRating || this.productRating.ratings.length < 1) return;
    this.populateSymbols(this.productRating.ratings[0]);
  }
}

import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faStarHalfStroke, faStar as faStarSolid} from '@fortawesome/free-solid-svg-icons';
import { faStar as faStarRegular } from '@fortawesome/free-regular-svg-icons';
import { ProductRating } from 'src/app/core/models/productRating';

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
  ratingSymbols = [
    this.fa.star, this.fa.star, this.fa.star, this.fa.starHalf, this.fa.starEmpty
  ];
  
  ngOnInit(): void {
    this.initSymbols();
  }

  // TODO make this more responsive
  initSymbols(){
    if(!this.productRating || this.productRating.ratings.length < 1) return;
    for(var i = 0; i < 5; i++){
      if(i < this.productRating.ratings[0]){
        this.ratingSymbols[i] = this.fa.star;
      }
      else{
        this.ratingSymbols[i] = this.fa.starEmpty;
      }
    }
  }
}

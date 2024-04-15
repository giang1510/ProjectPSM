import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductCard } from 'src/app/core/models/productCard';
import { faEye, faHeart, faRandom, faShoppingCart, faStar, faStarHalfStroke } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faStar as faStarRegular} from '@fortawesome/free-regular-svg-icons';
import { ProductRatingComponent } from '../product-rating/product-rating.component';
import { ProductRating } from 'src/app/core/models/productRating';

@Component({
  selector: 'app-product-card',
  standalone: true,
  imports: [CommonModule, FontAwesomeModule, ProductRatingComponent],
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.scss']
})
export class ProductCardComponent implements OnInit{
  @Input() productCard: ProductCard | undefined;
  productRating: ProductRating = {
    ratings: []
  };

  // Fontawsome icons
  readonly fa = {
    star: faStar,
    shoppingCart: faShoppingCart,
    heart: faHeart,
    eye: faEye,
    random: faRandom,
    starHalf: faStarHalfStroke,
    starEmpty: faStarRegular
  }

  ngOnInit(): void {
    this.initRating();
  }

  initRating(){
    if(!this.productCard) return;
    console.log(this.productCard.reviews);
    this.productCard.reviews.forEach(review => {
      this.productRating.ratings.push(review.rating);
    });
  }
}

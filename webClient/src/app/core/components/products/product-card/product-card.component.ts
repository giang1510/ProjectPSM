import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductCard } from 'src/app/core/models/productCard';
import { faEye, faHeart, faRandom, faShoppingCart, faStar, faStarHalfStroke } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faStar as faStarRegular} from '@fortawesome/free-regular-svg-icons';
import { ProductRatingComponent } from '../product-rating/product-rating.component';
import { ProductRating } from 'src/app/core/models/productRating';
import { Router } from '@angular/router';
import { APP_ROUTES } from 'src/app/app-routing.module';

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
  urls = {
    productDetail: APP_ROUTES.PRODUCT_DETAIL
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

  constructor(private router: Router){}

  ngOnInit(): void {
    this.initRating();
    this.initUrls();
  }

  initRating(){
    if(!this.productCard) return;
    console.log(this.productCard.reviews);
    this.productCard.reviews.forEach(review => {
      this.productRating.ratings.push(review.rating);
    });
  }

  initUrls(){
    if(!this.productCard) return;
    this.urls.productDetail = APP_ROUTES.PRODUCT_DETAIL + this.productCard.id;
  }
}

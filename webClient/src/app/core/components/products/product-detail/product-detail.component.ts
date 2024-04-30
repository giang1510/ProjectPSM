import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductService } from 'src/app/core/services/product.service';
import { ProductDetail } from 'src/app/core/models/productDetail';
import { ProductRatingComponent } from '../product-rating/product-rating.component';
import { ProductRating } from 'src/app/core/models/productRating';
import { AccountService } from 'src/app/core/services/account.service';

@Component({
  selector: 'app-product-detail',
  standalone: true,
  imports: [CommonModule, ProductRatingComponent],
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent implements OnInit{
  @Input() productId: number = 0;
  productDetail: ProductDetail | undefined;
  userProductRating: ProductRating | undefined;
  productRating: ProductRating | undefined;
  photoStr: string = '';

  constructor(private productService: ProductService, private accountService: AccountService){}

  ngOnInit(): void {
    this.getProductDetail();
  }

  getProductDetail() {
    this.productService.getProductDetail(this.productId).subscribe({
      next: prodDetail => {
        if(prodDetail){
          this.productDetail = prodDetail;
          if(prodDetail.photos.length > 0 && prodDetail.photos[0].url){
            this.photoStr = prodDetail.photos[0].url;
          }
          this.getProductRating();
          this.getUserProductRating();
        }
        
      },
      error: error => console.log(error)
    });
  }

  getProductRating(){
    if(!this.productDetail) return;
    const ratings: number[] = this.productDetail.reviews
      .reduce<number[]>((arr, elem) => arr.concat(elem.rating), []);
    this.productRating = {
      ratable: false,
      ratings: ratings,
      productId: this.productDetail.id
    };
  }

  getUserProductRating(){
    if(!this.productDetail || ! this.productDetail.reviews
      || !this.accountService.currentUser) return;
    
    var userReview = this.productDetail.reviews
      .find(review => review.userId == this.accountService.currentUser?.id)

    if(userReview){
      this.userProductRating = {
        ratable: true,
        ratings: [userReview.rating],
        productId: this.productDetail.id
      }
    }
    else{
      this.userProductRating = {
        ratable: true,
        ratings: [],
        productId: this.productDetail.id
      }
    }
  }
}

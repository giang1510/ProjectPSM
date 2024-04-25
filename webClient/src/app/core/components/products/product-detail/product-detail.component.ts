import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductService } from 'src/app/core/services/product.service';
import { ProductDetail } from 'src/app/core/models/productDetail';
import { ProductRatingComponent } from '../product-rating/product-rating.component';

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
  photoStr: string = '';

  constructor(private productService: ProductService){}

  ngOnInit(): void {
    this.productService.getProductDetail(this.productId).subscribe({
      next: prodDetail => {
        if(prodDetail){
          this.productDetail = prodDetail;
          if(prodDetail.photos.length > 0 && prodDetail.photos[0].url){
            this.photoStr = prodDetail.photos[0].url;
          }
        }
        
      },
      error: error => console.log(error)
    })
  }
}

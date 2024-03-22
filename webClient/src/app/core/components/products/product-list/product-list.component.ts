import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Observable } from 'rxjs';
import { ProductCard } from 'src/app/core/models/productCard';
import { ProductService } from 'src/app/core/services/product.service';
import { ProductCardComponent } from '../product-card/product-card.component';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [CommonModule, ProductCardComponent],
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit{
  productCards$: Observable<ProductCard[]> | undefined;

  constructor(private productService: ProductService){}

  ngOnInit(): void {
    this.initProductCards();
  }

  initProductCards(): void {
    this.productCards$ = this.productService.getProductCards();
  }
}



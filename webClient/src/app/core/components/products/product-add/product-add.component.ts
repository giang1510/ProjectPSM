import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductEntry } from 'src/app/core/models/productEntry';
import { ProductService } from 'src/app/core/services/product.service';

@Component({
  selector: 'app-product-add',
  standalone: true,
  imports: [],
  templateUrl: './product-add.component.html',
  styleUrl: './product-add.component.scss'
})
export class ProductAddComponent implements OnInit{
  productEntry: ProductEntry = {
    name: '',
    description: undefined,
    price: undefined,
    category: 'Other',
    manufacturer: undefined,
    isActive: true,
    photos: []
  };

  constructor(private productService: ProductService, private router: Router) { }

  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

  addProduct() : void {
    this.productService.addProduct(this.productEntry).subscribe({
      next: productDetail => {
        this.router.navigate(['/products', productDetail.id], {
          state: { productDetail: productDetail }
        });
      },
      error: error => console.log(error) // TODO handle error
    });
  }
}

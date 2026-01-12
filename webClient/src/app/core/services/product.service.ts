import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ProductCard } from '../models/productCard';
import { ProductDetail } from '../models/productDetail';
import { ReviewEntry } from '../models/reviewEntry';
import { ProductEntry } from '../models/productEntry';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl = environment.apiUrl + 'products';
  constructor(private http: HttpClient) { }

  /**
   * Get all product cards
   * Each product card contains the product's id, name, price, and image
   * @returns 
   */
  getProductCards(){
    return this.http.get<ProductCard[]>(this.baseUrl);
  }

  /**
   * Get all public details of a product
   * @param id - Product id
   * @returns 
   */
  getProductDetail(id: number){
    return this.http.get<ProductDetail>(this.baseUrl + '/' + id);
  }

  /**
   * Add a new product
   * @param productEntry - Product details
   * @returns 
   */
  addProduct(productEntry: ProductEntry){
    return this.http.post<ProductDetail>(this.baseUrl + '/add', productEntry);
  }

  /**
   * Add a review for a product
   * @param review - Review details
   * @returns 
   */
  addReview(review: ReviewEntry){
    return this.http.post(this.baseUrl + '/review', review);
  }
}

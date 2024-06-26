import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ProductCard } from '../models/productCard';
import { ProductDetail } from '../models/productDetail';
import { ReviewEntry } from '../models/reviewEntry';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl = environment.apiUrl + 'products';
  constructor(private http: HttpClient) { }

  getProductCards(){
    return this.http.get<ProductCard[]>(this.baseUrl);
  }

  getProductDetail(id: number){
    return this.http.get<ProductDetail>(this.baseUrl + '/' + id);
  }

  addReview(review: ReviewEntry){
    return this.http.post(this.baseUrl + '/review', review);
  }
}

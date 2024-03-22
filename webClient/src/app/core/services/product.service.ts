import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ProductCard } from '../models/productCard';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl = environment.apiUrl + 'products';
  constructor(private http: HttpClient) { }

  getProductCards(){
    return this.http.get<ProductCard[]>(this.baseUrl);
  }
}

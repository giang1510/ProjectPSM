import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductCard } from 'src/app/core/models/productCard';
import { faEye, faHeart, faRandom, faShoppingCart, faStar } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@Component({
  selector: 'app-product-card',
  standalone: true,
  imports: [CommonModule, FontAwesomeModule],
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.scss']
})
export class ProductCardComponent {
  @Input() productCard: ProductCard | undefined;

  // Fontawsome icons
  readonly fa = {
    star: faStar,
    shoppingCart: faShoppingCart,
    heart: faHeart,
    eye: faEye,
    random: faRandom
  }
}

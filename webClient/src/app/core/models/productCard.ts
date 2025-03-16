import { Photo } from "./photo";
import { Review } from "./review";

export interface ProductCard{
    id: number;
    name: string;
    price: number | null;
    category: string;
    isActive: boolean;
    manufacturer: string;
    photos: Photo[];
    reviews: Review[];
}
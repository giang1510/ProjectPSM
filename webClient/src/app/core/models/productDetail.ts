import { Photo } from "./photo";
import { Review } from "./review";

export interface ProductDetail{
    id: number;
    name: string;
    description: string;
    price: number;
    category: string
    createdDate: Date;
    lastUpdated: Date;
    isActive: boolean;
    manufacturer: string;
    photos: Photo[];
    reviews: Review[];
}
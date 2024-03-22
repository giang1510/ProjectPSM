import { Photo } from "./photo";

export interface ProductCard{
    name: string;
    price: number;
    category: string;
    isActive: boolean;
    manufacturer: string;
    photos: Photo[];
}
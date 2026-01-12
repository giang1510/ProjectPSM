import { Photo } from "./photo";

export interface ProductEntry {
    name: string;
    description?: string;
    price?: number;
    category: string;
    isActive: boolean;
    manufacturer?: string;
    photos?: Photo[];
}
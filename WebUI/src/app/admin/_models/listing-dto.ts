export interface CreateListingDto {
    sku: string;
    title: string;
    shortDescription: string;
    longDescription: string;
    price: number;
    thumbImage: string;
    isPriceNegotiable: boolean;
    categoryId: number;
  }

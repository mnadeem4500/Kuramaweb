export interface Categoryitem {
  id: number,
  name: string;
  parentId: number;
  icon: string;
  maxAllowedImages: number;
  postValidity: number
}
export interface Parent {
  id: number;
  name: string;
}
export interface subcategory {
  mainCategory: number;
  subCategory: number;
  childCategory: number;
}

export interface CategoryitemWithSub {
  id: number,
  name: string;
  parentId: number;
  icon: string;
  maxAllowedImages: number;
  postValidity: number;
  subCat: CategoryitemWithSub[]
  hasSub:boolean
}
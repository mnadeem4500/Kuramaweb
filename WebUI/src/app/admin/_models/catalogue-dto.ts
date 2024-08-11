export interface CatalogueMasterDto {
    masterId: string;
    catalogueName: string;
    description: string;
    catalogueDetails: CatalogueDetailDto[];
}
export interface CatalogueDetailDto {
    detailId: string;
    name: string;
    masterId: string;
}
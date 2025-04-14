export interface IPaginatedSearchRequest<T> {
    pageNumber?: number;
    pageSize?: number;
    searchTerm?: string;
    orderBy?: string;
}
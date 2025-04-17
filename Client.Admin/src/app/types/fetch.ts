export interface IFetchCount {
    pageCount: number
}

export interface IPage<T> {
    totalItems: number;
    pageSize: number;
    currentPage: number;
    totalPages: number;
    hasPrevious: boolean;
    hasNext: boolean;
    data: T[]
}
export interface  IBaseResponse<T> {
    data: T;
    status: boolean;
    message: string;
  }
  
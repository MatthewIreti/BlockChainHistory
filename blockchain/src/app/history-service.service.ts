import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { IBaseResponse } from './model/baseresponse';
import { BlockEntity } from './model/blockmodel';

@Injectable({
  providedIn: 'root'
})
export class BlockService {
  baseUrl = environment.baseUrl;
  constructor(private http:HttpClient) {
  }

  getHistory():Observable<IBaseResponse<BlockEntity[]>>
  {
    return this.http.get<IBaseResponse<BlockEntity[]>>(`${this.baseUrl}api/ethereum`);
  }

}

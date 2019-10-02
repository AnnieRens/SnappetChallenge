import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {map} from 'rxjs/internal/operators';
import {ClassProgressItem} from '../models/class-progress-item.model';
import {ApiResponse} from '../../common/models/api-response.model';
import {environment} from '../../../environments/environment';

@Injectable()
export class ClassWorkProgressService {
  constructor(private http: HttpClient) {}
  apiUrl = environment.apiUrl;
  resourceName = 'class-progress';


  public getStudentStatistic(startDate: string, endDate: string): Observable<ClassProgressItem[]> {
    return this.http.get<ApiResponse<ClassProgressItem[]>>(`${this.apiUrl}/${this.resourceName}?startDate=${startDate}&endDate=${endDate}`)
      .pipe(map(response => {
        debugger;


       // response.data;
        let res = response as ApiResponse<ClassProgressItem[]>;

        // check error

        return res.data;
      }));
  }
}

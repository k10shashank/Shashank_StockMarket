import { Time } from '@angular/common';
import { Timestamp } from 'rxjs';

export class Stockprice {
    stockPriceId: number;
    companyCode: number;
    stockExchangeId: number;
    currentPrice: number;
    date: Date;
    time: Date;
}

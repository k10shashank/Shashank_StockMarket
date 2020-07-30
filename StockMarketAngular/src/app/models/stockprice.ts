import { Time } from '@angular/common';

export class Stockprice {
    stockPriceId: number;
    companyCode: number;
    stockExchangeId: number;
    currentPrice: number;
    date: Date;
    time: Time;
}

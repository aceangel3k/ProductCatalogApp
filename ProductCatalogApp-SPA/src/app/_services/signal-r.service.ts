import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { environment } from 'src/environments/environment';
import { Product } from '../_models/product';

@Injectable({
    providedIn: 'root'
})
export class SignalRService {
    baseUrl = `${environment.apiUrl}`;
    signalrHub = `http://localhost:5000/producthub`;
    products: Product[];
    private hubConnection: signalR.HubConnection;

    public startConnection = () => {
      this.hubConnection = new signalR.HubConnectionBuilder()
          .withUrl(`${this.signalrHub}`)
          .withAutomaticReconnect()
          .build();

      this.hubConnection
        .start()
        .then(() => console.log('Connection started'))
        .catch(err => console.log(`Error while starting connection: ${err}`));
    }

    public addTransferProductDataListener = () => {
      this.hubConnection.on('transferproductdata', products => {
        this.products = products;
        // console.log(products);
      });
    }
}

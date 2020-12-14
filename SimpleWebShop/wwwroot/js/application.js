const HOST_URL = "/EventHub"

window.onload = () => {
    const hubConnection = new signalR.HubConnectionBuilder()
        .withUrl(HOST_URL)
        .withAutomaticReconnect()
        .build();

    hubConnection
        .start()
        .then(() => {
            hubConnection.on('needUpdateCars', (newCar) => {
   
                let item = document.getElementById('homePageDiv');
                item.innerHTML = `
               
                    <div class="col-lg-4">
                        <div class="lot">
                            <img class="lot__image" src="${newCar.image}" alt="@Model.name" />
                        </div>
                        <h2>${newCar.name}</h2>
                        <p>${newCar.shortDescription}</p>
                        <p>Цена: $${newCar.price} </p>
                        <p><a class="btn btn-warning" href="/Cars/CarDetailView?carID=${newCar.id}">Подробнее</a></p>
                    </div>                        
             
                ` + item.innerHTML;
            });
        })
}

const startConnaction = () => {
    const hubConnection = new signalR.HubConnectionBuilder()
        .withUrl(HOST_URL)
        .build();

    return this.hubConnection.start();
}
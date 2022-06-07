// ------ Visualizza i videogiochi in card, se sono presenti all'interno dei videogiochi preferiti il bottone cambia ------
function filtroPreferiti(gioco) {

    var url = "/Home/Dettagli/" + gioco.id;
    var prezzo = gioco.prezzo.toFixed(2);

    axios.get('/api/VideogiochiMiPiace/Get').then(videogiochiPreferiti => {

        if (videogiochiPreferiti.data.length == 0) {

            document.getElementById("videogiochi_div").innerHTML +=
                `                                       
                        <div class="col-12 col-md-6 col-lg-4 d-flex justify-content-center">
                            <div class="card p-3 mb-5 pt-0 px-0 text-center" style="width: 18rem; background-image: linear-gradient(to right, #d1edf7, white)">
                                <div class="badgeCategoria"><span style="color: white">${gioco.categoria.tema}</span></div>
                                <img src="${gioco.foto}" class="card-img-top img-fluid" alt="${gioco.nome}" />
                                <div class="card-body pt-2 mt-0">
                                    <h5 class="card-title py-2 text-dark">${gioco.nome} <br> € ${prezzo}</h5>
                                    <a href="${url}" class="btn btn-danger">Acquista</a>
                                    <button id="Piace${gioco.id}" onclick="aggiungiVideogiocoFav(${gioco.id})" class="buttonLike">${gioco.miPiace}
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-heart" viewBox="0 0 16 16"><path d="m8 2.748-.717-.737C5.6.281 2.514.878 1.4 3.053c-.523 1.023-.641 2.5.314 4.385.92 1.815 2.834 3.989 6.286 6.357 3.452-2.368 5.365-4.542 6.286-6.357.955-1.886.838-3.362.314-4.385C13.486.878 10.4.28 8.717 2.01L8 2.748zM8 15C-7.333 4.868 3.279-3.04 7.824 1.143c.06.055.119.112.176.171a3.12 3.12 0 0 1 .176-.17C12.72-3.042 23.333 4.867 8 15z"/></svg>
                                    </button>
                                    <button id="NonPiace${gioco.id}" onclick="togliVideogiocoFav(${gioco.id})" class="buttonDislike d-none">${gioco.miPiace + 1}
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-heart" viewBox="0 0 16 16"><path d="m8 2.748-.717-.737C5.6.281 2.514.878 1.4 3.053c-.523 1.023-.641 2.5.314 4.385.92 1.815 2.834 3.989 6.286 6.357 3.452-2.368 5.365-4.542 6.286-6.357.955-1.886.838-3.362.314-4.385C13.486.878 10.4.28 8.717 2.01L8 2.748zM8 15C-7.333 4.868 3.279-3.04 7.824 1.143c.06.055.119.112.176.171a3.12 3.12 0 0 1 .176-.17C12.72-3.042 23.333 4.867 8 15z"/></svg>
                                    </button>
                                </div>
                            </div>                                                  
                        </div>                                       
                    `
        }
        else {

            for (var i = 0; i < videogiochiPreferiti.data.length; i++) {

                if (JSON.stringify(videogiochiPreferiti.data[i]) == JSON.stringify(gioco)) {

                    document.getElementById("videogiochi_div").innerHTML +=
                        `                                       
                                <div class="col-12 col-md-6 col-lg-4 d-flex justify-content-center">
                                    <div class="card p-3 mb-5 pt-0 px-0 text-center" style="width: 18rem; background-image: linear-gradient(to right, #d1edf7, white)">
                                        <div class="badgeCategoria"><span style="color: white">${gioco.categoria.tema}</span></div>
                                        <img src="${gioco.foto}" class="card-img-top img-fluid" alt="${gioco.nome}" />
                                        <div class="card-body pt-2 mt-0">
                                            <h5 class="card-title py-2 text-dark">${gioco.nome} <br> € ${gioco.prezzo}</h5>
                                            <a href="${url}" class="btn btn-danger">Acquista</a>
                                            <button id="Piace${gioco.id}" onclick="aggiungiVideogiocoFav(${gioco.id})" class="buttonLike d-none">${gioco.miPiace}
                                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-heart" viewBox="0 0 16 16"><path d="m8 2.748-.717-.737C5.6.281 2.514.878 1.4 3.053c-.523 1.023-.641 2.5.314 4.385.92 1.815 2.834 3.989 6.286 6.357 3.452-2.368 5.365-4.542 6.286-6.357.955-1.886.838-3.362.314-4.385C13.486.878 10.4.28 8.717 2.01L8 2.748zM8 15C-7.333 4.868 3.279-3.04 7.824 1.143c.06.055.119.112.176.171a3.12 3.12 0 0 1 .176-.17C12.72-3.042 23.333 4.867 8 15z"/></svg>
                                            </button>
                                            <button id="NonPiace${gioco.id}" onclick="togliVideogiocoFav(${gioco.id})" class="buttonDislike">${gioco.miPiace + 1}
                                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-heart" viewBox="0 0 16 16"><path d="m8 2.748-.717-.737C5.6.281 2.514.878 1.4 3.053c-.523 1.023-.641 2.5.314 4.385.92 1.815 2.834 3.989 6.286 6.357 3.452-2.368 5.365-4.542 6.286-6.357.955-1.886.838-3.362.314-4.385C13.486.878 10.4.28 8.717 2.01L8 2.748zM8 15C-7.333 4.868 3.279-3.04 7.824 1.143c.06.055.119.112.176.171a3.12 3.12 0 0 1 .176-.17C12.72-3.042 23.333 4.867 8 15z"/></svg>
                                            </button>
                                        </div>
                                    </div>                                                  
                                </div>                                       
                            `
                    break;
                }
            }

            if (JSON.stringify(videogiochiPreferiti.data[i]) != JSON.stringify(gioco)) {

                document.getElementById("videogiochi_div").innerHTML +=
                    `                                       
                            <div class="col-12 col-md-6 col-lg-4 d-flex justify-content-center">
                                <div class="card p-3 mb-5 pt-0 px-0 text-center" style="width: 18rem; background-image: linear-gradient(to right, #d1edf7, white)">
                                    <div class="badgeCategoria"><span style="color: white">${gioco.categoria.tema}</span></div>
                                    <img src="${gioco.foto}" class="card-img-top img-fluid" alt="${gioco.nome}" />
                                    <div class="card-body pt-2 mt-0">
                                        <h5 class="card-title py-2 text-dark">${gioco.nome} <br> € ${gioco.prezzo}</h5>
                                        <a href="${url}" class="btn btn-danger">Acquista</a>
                                        <button id="Piace${gioco.id}" onclick="aggiungiVideogiocoFav(${gioco.id})" class="buttonLike">${gioco.miPiace}
                                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-heart" viewBox="0 0 16 16"><path d="m8 2.748-.717-.737C5.6.281 2.514.878 1.4 3.053c-.523 1.023-.641 2.5.314 4.385.92 1.815 2.834 3.989 6.286 6.357 3.452-2.368 5.365-4.542 6.286-6.357.955-1.886.838-3.362.314-4.385C13.486.878 10.4.28 8.717 2.01L8 2.748zM8 15C-7.333 4.868 3.279-3.04 7.824 1.143c.06.055.119.112.176.171a3.12 3.12 0 0 1 .176-.17C12.72-3.042 23.333 4.867 8 15z"/></svg>
                                        </button>
                                        <button id="NonPiace${gioco.id}" onclick="togliVideogiocoFav(${gioco.id})" class="buttonDislike d-none">${gioco.miPiace + 1}
                                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-heart" viewBox="0 0 16 16"><path d="m8 2.748-.717-.737C5.6.281 2.514.878 1.4 3.053c-.523 1.023-.641 2.5.314 4.385.92 1.815 2.834 3.989 6.286 6.357 3.452-2.368 5.365-4.542 6.286-6.357.955-1.886.838-3.362.314-4.385C13.486.878 10.4.28 8.717 2.01L8 2.748zM8 15C-7.333 4.868 3.279-3.04 7.824 1.143c.06.055.119.112.176.171a3.12 3.12 0 0 1 .176-.17C12.72-3.042 23.333 4.867 8 15z"/></svg>
                                        </button>
                                    </div>
                                </div>                                                  
                            </div>                                       
                        `
            }
        }
    }).catch(error => {
        console.log("C'è stato un errore: " + error);
    })
}

// ------ Riempe il filtro di categorie ------       
function caricaDropdown() {
    document.getElementById('categoria').innerHTML = `<li class="dropdown-item Steam-dropdown text-white" onclick="cercaPerCategoria(-1)">Tutte</li>`;

    axios.get('/api/Categoria/Get')
        .then((result) => {

            result.data.forEach(categoria => {
                document.getElementById('categoria').innerHTML +=
                    `
                    <li class="dropdown-item Steam-dropdown text-white" onclick="cercaPerCategoria(${categoria.id})">${categoria.tema}</li>
                    `
            })
        }).catch(error => {
            console.log("C'è stato un errore: " + error);
        })
}

// ------ barra di ricerca ------
function cercaVideogioco() {
    var inputTesto = document.getElementById('search_input').value;
    caricaVideogiochi(inputTesto);
}

// ------ Aggiunge il videogioco alla lista dei videogiochi preferiti ------
function aggiungiVideogiocoFav(idDaPrendere) {

    axios.post('/api/VideogiochiMiPiace/Post', {
        Id: idDaPrendere
    }).then(result => {

        document.getElementById("Piace" + idDaPrendere).classList.add("d-none");

        document.getElementById("NonPiace" + idDaPrendere).classList.remove("d-none");

    }).catch(error => {
        console.log("C'è stato un errore: " + error);
    })
}

// ------ Rimuove il videogioco dalla lista dei videogiochi preferiti ------
function togliVideogiocoFav(idDaPrendere) {

    axios.delete('/api/VideogiochiMiPiace/Delete/' + idDaPrendere, {
        Id: idDaPrendere
    }).then(result => {

        document.getElementById("NonPiace" + idDaPrendere).classList.add("d-none");

        document.getElementById("Piace" + idDaPrendere).classList.remove("d-none");

    }).catch(error => {
        console.log("C'è stato un errore: " + error);
    })
}
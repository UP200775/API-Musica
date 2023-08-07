const url = 'https://localhost:7204/Album';
const cancionUrl = 'https://localhost:7204/api/Cancion';

class Album {
    constructor() {
        this.albumContainer = document.getElementById('albumContainer');
    }

    leeAlbumes() {
        fetch(url)
            .then(response => {
                if (!response.ok) {
                    throw new Error(`Network response was not ok. Status: ${response.status}`);
                }
                return response.json();
            })
            .then(data => {
                this.muestraAlbumes(data);
            })
            .catch(error => {
                console.error('Valio burguer:', error);
            });
    }

    muestraAlbumes(albumes) {
        // Limpia el contenedor antes de mostrar los nuevos datos
        this.albumContainer.innerHTML = '';

        albumes.forEach(album => {
            // Crea una tarjeta de Bootstrap para cada álbum
            const albumCard = document.createElement('div');
            albumCard.classList.add('col-4', 'mb-4');

            // Muestra la carátula del álbum como imagen en la parte superior de la tarjeta
            const albumCover = document.createElement('img');
            albumCover.classList.add('card-img-top');
            albumCover.src = `../Imagenes/${album.nombre_Album}.jpg`;
            albumCover.alt = 'Carátula del álbum';
            albumCover.style.width = '250px';
            albumCard.appendChild(albumCover);

            // Crea el contenido de la tarjeta en el div con la clase "card-body"
            const cardBody = document.createElement('div');
            cardBody.classList.add('card-body');
            albumCard.appendChild(cardBody);

            // Muestra el nombre del álbum como título de la tarjeta
            const albumName = document.createElement('h5');
            albumName.classList.add('card-title');
            albumName.textContent = album.nombre_Album;
            cardBody.appendChild(albumName);

            const viewSongsButton = document.createElement('button');
            viewSongsButton.classList.add('btn', 'btn-primary');
            viewSongsButton.textContent = 'Ver canciones';
            cardBody.appendChild(viewSongsButton);

            // Asociar el evento clic al botón para mostrar las canciones del álbum
            viewSongsButton.addEventListener('click', () => {
                this.mostrarCancionesPorAlbum(album.id_album);
            });

            // Agrega la tarjeta del álbum al contenedor principal
            this.albumContainer.appendChild(albumCard);
        });
    }

    mostrarCancionesPorAlbum(id_album) {
        fetch(cancionUrl)
            .then(response => {
                if (!response.ok) {
                    throw new Error(`Network response was not ok. Status: ${response.status}`);
                }
                return response.json();
            })
            .then(data => {
                const cancionesDelAlbum = data.filter(cancion => cancion.id_album === id_album);
                this.muestraCanciones(cancionesDelAlbum);
            })
            .catch(error => {
                console.error('Valio burg:', error);
            });
    }

    muestraCanciones(canciones) {
        // Aquí puedes mostrar las canciones en la interfaz como desees
        // Por ejemplo, podrías mostrarlas en una lista, tabla, etc.
        console.log('Canciones:', canciones);
    }
}

// Instancia un objeto de la clase Album y llama a la función para mostrar los álbumes
const albumInstance = new Album();
albumInstance.leeAlbumes();
const url = 'https://localhost:7204/api/Cancion';

class cancion {
    leeCanciones() {
        debugger;
        fetch(url, {
            method: 'GET'
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error(`Network response was not ok. Status: ${response.status}`);
                }
                return response.json(); // Parse the response body as JSON
            })
            .then(data => {
                debugger;
                this.muestraCanciones(data);
            })
            .catch(error => {
                // Handle errors that might occur during the fetch
                console.error('Valio burg:', error);
            });
    }

    guardaCancion() {

        var data = {
            "Nombre_Cancion": $("#txtCancion").val(),
            "ID_Artista": $("#txtArtista").val(),
            "ID_Genero": $("#txtGenero").val(),
            "ID_Album": $("#txtAlbum").val()
        };

        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json' // Correct for JSON data
            },
            body: JSON.stringify(data)
        })
            .then(response => {
                debugger;
                if (!response.ok) {
                    throw new Error(`Network response was not ok. Status: ${response.status}`);
                }
                else {
                    alert("La cancion se almaceno correctamente")
                }
                return response.json();
            })
            .then(data => {
                this.muestraCanciones(data)
            })
            .catch(error => {
                // Handle errors that might occur during the fetch
                console.error('Album no agregado (Fetch error):', error);
            });
    }

     //El paramatero "idAlbum" debe ser igual al que se llama en el service
     borrarCancion(idCancion) {
        var data = {
            "id": idCancion
        };
        fetch(url+'/'+idCancion, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
            
        }) 
            .then(response => {
                
                if (!response.ok) {
                    throw new Error(`Network response was not ok. Status: ${response.status}`);
                }
                else {
                    alert("La cancion se elimino correctamente")
                }
                return response.json();
            })
            .catch(error => {
                console.error('Fetch error:', error);
            });
    }


    muestraCanciones(canciones) {
        var table = $("<table>").addClass("table table-striped");

        // Encabezados de la tabla
        var thead = $("<thead>");
        var headerRow = $("<tr>");
        headerRow.append($("<th>").text("ID_CANCION"));
        headerRow.append($("<th>").text("ID_ARTISTA"));
        headerRow.append($("<th>").text("ID_ALBUM"));
        headerRow.append($("<th>").text("ID_GENERO"));
        headerRow.append($("<th>").text("Cancion"));
        headerRow.append($("<th>").text("Borrar"));
        thead.append(headerRow);
        table.append(thead);

        // Crea el llenado de datos
        var tbody = $("<tbody>");

        $.each(canciones, function (index, cancion) {
            var row = $("<tr>");
            var lnk = $("<a>");
            lnk.attr("href", "#");  // Add the href attribute to the <a> element
            lnk.attr("id", cancion.iD_Album);  // Set the id attribute to the <a> element
            var icon = $("<i>").addClass("fas fa-star");  // Adjust the class based on the desired Font Awesome icon
            lnk.append(icon);
            row.append($("<td>").text(cancion.iD_Cancion));
            row.append($("<td>").text(cancion.iD_Artista));
            row.append($("<td>").text(cancion.iD_Album));
            row.append($("<td>").text(cancion.iD_Genero));
            row.append($("<td>").text(cancion.nombre_Cancion));

            var btn = $("<div>");
            btn.on("click", function () {
                Borrar(cancion.iD_Cancion);
            });
            var icon2 = $("<i>").addClass("fa fa-trash");  // Adjust the class based on the desired Font Awesome icon
            btn.append(icon2);
            row.append(btn);


            tbody.append(row);
            table.append(tbody);
        });

        // Append the table to the container
        $("#table-container").append(table);
        $("#contenedor_tabla").append(table);

    }
}

function guardar() {
    var _cancion = new cancion();
    _cancion.guardaCancion();

}

function Borrar(iD_Cancion) {
    var _cancion = new cancion();
    _cancion.borrarCancion(iD_Cancion);

}
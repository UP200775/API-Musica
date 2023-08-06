const url = 'https://localhost:7204/Album';

class album {
    leeAlbumes() {
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
                this.muestraAlbumes(data);
            })
            .catch(error => {
                // Handle errors that might occur during the fetch
                console.error('Valio burg:', error);
            });
    }

    guardaAlbum() {

        var data = {
            "Nombre_Album": $("#txtAlbum").val(),
            "ID_Artista": $("#txtArtista").val(),
            "ID_Genero": $("#txtGenero").val()
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
                    alert("El album se almaceno correctamente")
                }
                return response.json();
            })
            .then(data => {
                this.muestraAlbumes(data)
            })
            .catch(error => {
                // Handle errors that might occur during the fetch
                console.error('Album no agregado (Fetch error):', error);
            });
    }

    borrarAlbum(iD_Album) {
        var data = {
            "ID_Album": iD_Album
        };

        fetch(url, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json' // Correct for JSON data
            },
            body: JSON.stringify(data)

        })
            .then(response => {
                if (!response.ok) {
                    throw new Error(`Network response was not ok. Status: ${response.status}`);
                }
                else {
                    alert("El album se elimino correctamente")
                }
                return response.json();
            })
            .then(data => {
                this.muestraAlbumes(data)
            })
            .catch(error => {
                // Handle errors that might occur during the fetch
                console.error('Fetch error:', error);
            });
    }

    muestraAlbumes(albumes) {
        var table = $("<table>").addClass("table table-striped");

        // Encabezados de la tabla
        var thead = $("<thead>");
        var headerRow = $("<tr>");
        headerRow.append($("<th>").text("Link"));
        headerRow.append($("<th>").text("ID"));
        headerRow.append($("<th>").text("Album"));
        headerRow.append($("<th>").text("ID Artista"));
        headerRow.append($("<th>").text("ID Genero"));
        headerRow.append($("<th>").text("Borrar"));
        thead.append(headerRow);
        table.append(thead);

        // Crea el llenado de datos
        var tbody = $("<tbody>");

        $.each(albumes, function (index, album) {
            var row = $("<tr>");
            var lnk = $("<a>");
            lnk.attr("href", "#");  // Add the href attribute to the <a> element
            lnk.attr("id", album.iD_Album);  // Set the id attribute to the <a> element
            var icon = $("<i>").addClass("fas fa-star");  // Adjust the class based on the desired Font Awesome icon
            lnk.append(icon);

            row.append($("<td>").append(lnk));
            row.append($("<td>").text(album.iD_Album));
            row.append($("<td>").text(album.nombre_Album));
            row.append($("<td>").text(album.iD_Artista));
            row.append($("<td>").text(album.iD_Genero));

            var btn = $("<div>");
            btn.on("click", function () {
                Borrar(album.iD_Album);
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
    var _album = new album();
    _album.guardaAlbum();

}

function Borrar(iD_Album) {
    var _album = new album();
    _album.borrarAlbum(iD_Album);

}
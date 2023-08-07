const url = 'https://localhost:7204/api/Artista';

class Artista {
    leeArtistas() {
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
                this.muestraArtistas(data);
            })
            .catch(error => {
                // Handle errors that might occur during the fetch
                console.error('Fetch error:', error);
            });
    }

    guardaArtista() {

        var data = {
            "NombreArtista": $("#txtNombreArtista").val(),
            "NacionalidadArtista": $("#txtNacionalidadArtista").val(),
            "IdGenero": $("#txtIdGenero").val()
        };

        fetch(url, {
            method: 'POST',
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
                    alert("El artista se almacenó correctamente");
                }
                return response.json();
            })
            .then(data => {
                this.muestraArtistas(data);
            })
            .catch(error => {
                // Handle errors that might occur during the fetch
                console.error('Fetch error:', error);
            });
    }

    borrarArtista(idArtista) {
        var data = {
            "idArtista": idArtista
        };
        fetch(url+'?idArtista='+idArtista, {
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
                    alert("El artista se elimino correctamente")
                }
                return response.json();
            })
            .catch(error => {
                console.error('Fetch error:', error);
            });
    }

    muestraArtistas(artistas) {
        var table = $("<table>").addClass("table table-striped");

        // Encabezados de la tabla
        var thead = $("<thead>");
        var headerRow = $("<tr>");
        headerRow.append($("<th>").text("Link"));
        headerRow.append($("<th>").text("ID Artista"));
        headerRow.append($("<th>").text("Nombre Artista"));
        headerRow.append($("<th>").text("Nacionalidad"));
        headerRow.append($("<th>").text("ID Genero"));
        headerRow.append($("<th>").text("Borrar"));
        thead.append(headerRow);
        table.append(thead);

        // Crea el llenado de datos
        var tbody = $("<tbody>");

        $.each(artistas, function (index, artista) {
            var row = $("<tr>");
            var lnk = $("<a>");
            lnk.attr("href", "#");
            lnk.attr("id", artista.IdArtista);
            var icon = $("<i>").addClass("fas fa-star");
            lnk.append(icon);

            row.append($("<td>").append(lnk));
            row.append($("<td>").text(artista.idArtista));
            row.append($("<td>").text(artista.nombreArtista));
            row.append($("<td>").text(artista.nacionalidadArtista));
            row.append($("<td>").text(artista.idGenero));

            var btn = $("<div>");
            btn.on("click", function () {
                Borrar(artista.idArtista);
            });
            var icon2 = $("<i>").addClass("fa fa-trash");
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
    var _artista = new Artista();
    _artista.guardaArtista();
}

function Borrar(idArtista) {
    var _artista = new Artista();
    _artista.borrarArtista(idArtista);
}
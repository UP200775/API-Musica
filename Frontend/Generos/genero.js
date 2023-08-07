const url = 'https://localhost:7204/api/Genero';

class Genero {
    leeGeneros() {
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
                this.muestraGeneros(data);
            })
            .catch(error => {
                // Handle errors that might occur during the fetch
                console.error('Fetch error:', error);
            });
    }

    guardaGenero() {

        var data = {
            "IdGenero": $("#txtIdGenero").val(),
            "NombreGenero": $("#txtNombreGenero").val()
            
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
                    alert("El genero se almacenó correctamente");
                }
                return response.json();
            })
            .then(data => {
                this.muestraGeneros(data);
            })
            .catch(error => {
                // Handle errors that might occur during the fetch
                console.error('Fetch error:', error);
            });
    }

    borrarGenero(idGenero) {
        var data = {
            "idAlbum": idGenero
        };
        fetch(url+'?idGenero='+idGenero, {
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
                    alert("El album se elimino correctamente")
                }
                return response.json();
            })
            .catch(error => {
                console.error('Fetch error:', error);
            });
    }

    muestraGeneros(generos) {
        var table = $("<table>").addClass("table table-striped");

        // Encabezados de la tabla
        var thead = $("<thead>");
        var headerRow = $("<tr>");
        headerRow.append($("<th>").text("Link"));
        headerRow.append($("<th>").text("ID Genero"));
        headerRow.append($("<th>").text("Nombre Genero"));
        headerRow.append($("<th>").text("Borrar"));
        thead.append(headerRow);
        table.append(thead);

        // Crea el llenado de datos
        var tbody = $("<tbody>");

        $.each(generos, function (index, genero) {
            var row = $("<tr>");
            var lnk = $("<a>");
            lnk.attr("href", "#");
            lnk.attr("id", genero.IdGenero);
            var icon = $("<i>").addClass("fas fa-star");
            lnk.append(icon);

            row.append($("<td>").append(lnk));
            row.append($("<td>").text(genero.idGenero));
            row.append($("<td>").text(genero.nombreGenero));
            

            var btn = $("<div>");
            btn.on("click", function () {
                borrarGenero(genero.idGenero);
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
    var _genero = new Genero();
    _genero.guardaGenero();
}

function borrarGenero(idGenero) {
    var _genero = new Genero();
    _genero.borrarGenero(idGenero);
}
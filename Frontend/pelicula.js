        const url = 'https://localhost:7284/Pelicula';

class pelicula{

     leePeliculas(){
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
                this.muestraPeliculas(data)
                return this;
            })
            .catch(error => {
                // Handle errors that might occur during the fetch
                console.error('Fetch error:', error);
            });
    }
    guardaPelicula(){

     var data = {
        "Nombre":$("#txtNombre").val(),
        "Genero":$("#txtGenero").val()
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
                else{
                    alert("La pelicula se almaceno correctamente")
                }
                return response.json();
            })

            .then(data => {
                this.muestraPeliculas(data)
            })
            .catch(error => {
                // Handle errors that might occur during the fetch
                console.error('Fetch error:', error);
            });
    }

    borrarPelicula(idPelicula){
        debugger;
        var data = {
           "idPelicula":idPelicula
       };
   
           fetch(url, {
               method: 'DELETE',
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
                   else{
                       alert("La pelicula se almaceno correctamente")
                   }
                   return response.json();
               })
                .then(data => {
                    this.muestraPeliculas(data)
                })
               .catch(error => {
                   // Handle errors that might occur during the fetch
                   console.error('Fetch error:', error);
               });
       }

    muestraPeliculas(peliculas){
        debugger;
        var table = $("<table>").addClass("table table-striped");

        // Create the table header row
        var thead = $("<thead>");
        var headerRow = $("<tr>");
        headerRow.append($("<th>").text("Show"));
        headerRow.append($("<th>").text("Pelicula"));
        headerRow.append($("<th>").text("Genero"));
        headerRow.append($("<th>").text("Borrar"));
        thead.append(headerRow);
        table.append(thead);
    
        // Create table rows with data
        var tbody = $("<tbody>");

        $.each(peliculas, function(index, pelicula) {
            var row = $("<tr>");
            var lnk=$("<a>");
            lnk.attr("href", "#");  // Add the href attribute to the <a> element
            lnk.attr("id",pelicula.idPelicula);  // Set the id attribute to the <a> element
            var icon = $("<i>").addClass("fas fa-star");  // Adjust the class based on the desired Font Awesome icon
            lnk.append(icon);

            row.append($("<td>").append(lnk));//text(pelicula.idPelicula));
            row.append($("<td>").text(pelicula.nombre));
            row.append($("<td>").text(pelicula.genero));

            var btn=$("<div>");
            btn.on("click", function() {  
                Borrar(pelicula.idPelicula);
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


function guardar(){
    var _pelicula=new pelicula();
    _pelicula.guardaPelicula();

}


function Borrar(idPelicula){
    var _pelicula=new pelicula();
    _pelicula.borrarPelicula(idPelicula);

}

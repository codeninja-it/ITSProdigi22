class tacciuinoElettronico {
	constructor(tavoli, piatti, pulsante, tabella, totali){
		this.selTavoli = document.getElementById(tavoli);
		this.selPiatti = document.getElementById(piatti);
		this.tabella = document.getElementById(tabella);
		this.totali = document.getElementById(totali);
		document.getElementById(pulsante).addEventListener("click", this.click.bind(this) );
		this.init();
		setInterval(this.refresh.bind(this), 5000);
	}
	
	chiamaServer(endPoint, callable){
		let telefono = new XMLHttpRequest();
		let baseUrl = "endpoint.php?";
		telefono.open("GET", baseUrl + endPoint, true);
		telefono.onreadystatechange = function(){
			if(telefono.status == 200 && telefono.readyState == 4){
				let dati = JSON.parse(telefono.response);
				if(callable != undefined)
					callable(dati);
			}
				
		};
		telefono.send();
	}
	
	refresh(){
		// chiedere al server i dati del tavolo selezionato
		this.chiamaServer("mod=list&id=" + this.selTavoli.value, function(dati){
			let righe = "";
			let totale = 0;
			for(let n in dati){
				let riga = dati[n];
				righe += "<tr style=''>" +
							"<td>" + riga["piatto"] + "</td>" +
							"<td align='right'>" + riga["prezzo"] + "</td>" +
						"</tr>";
				totale += riga["prezzo"];
			}
			this.tabella.innerHTML = righe;
			this.totali.innerHTML = totale;
		}.bind(this));
	}
	
	init(){
		this.chiamaServer("mod=tavoli", function(dati){
			let buffer = "<option value='0'>Tutti</option>";
			for(let n in dati){
				let tavolo = dati[n];
				buffer += "<option value='" + tavolo["idtavolo"] + "'>" + tavolo["tavolo"] + "</option>";
			}
			this.selTavoli.innerHTML = buffer;
		}.bind(this));
		this.chiamaServer("mod=piatti", function(dati){
			let buffer = "";
			for(let n in dati){
				let piatto = dati[n];
				buffer += "<option value='" + piatto["idpiatto"] + "'>" + piatto["piatto"] + "</option>";
			}
			this.selPiatti.innerHTML = buffer;
		}.bind(this));
	}
	
	click(){
		this.chiamaServer("mod=add" + 
							"&idpiatto=" + this.selPiatti.value + 
							"&idtavolo=" + this.selTavoli.value);
	}
}


window.addEventListener("load", function(){
	new tacciuinoElettronico("selTavolo", "selPiatto", "btnRegistra", "tblComande", "totPrezzo");
});
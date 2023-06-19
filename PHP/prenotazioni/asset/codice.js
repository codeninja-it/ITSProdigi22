class tacciuinoElettronico {
	constructor(tavoli, tipi, piatti, pulsante, tabella, totali, sedi) {
		// recupero i riferimenti
		this.selSedi = document.getElementById(sedi);
		this.selTavoli = document.getElementById(tavoli);
		this.selTipi = document.getElementById(tipi);
		this.selPiatti = document.getElementById(piatti);
		this.tabella = document.getElementById(tabella);
		this.totali = document.getElementById(totali);

		// definisco gli eventi
		this.selSedi.addEventListener("change", this.aggiornaTavoli.bind(this));
		this.selTavoli.addEventListener("change", this.aggiornaTipi.bind(this));
		this.selTipi.addEventListener("change", this.aggiornaPiatti.bind(this));

		// definisco anche il pulsante di add di cui non ho bisogno di riferimenti
		document.getElementById(pulsante).addEventListener("click", this.click.bind(this));

		this.aggiornaSedi();
	}

	// utility che chiama il server ed esegue sui dati una callable ricevuta come parametro
	chiamaServer(endPoint, callable) {
		let telefono = new XMLHttpRequest();
		let baseUrl = "endpoint.php?";
		telefono.open("GET", baseUrl + endPoint, true);
		telefono.onreadystatechange = function () {
			if (telefono.status == 200 && telefono.readyState == 4) {
				let dati = JSON.parse(telefono.response);
				if (callable != undefined)
					callable(dati);
			}

		};
		telefono.send();
	}

	aggiornaSedi() {
		this.chiamaServer("mod=sedi", function (dati) {
			let buffer = "";
			for (let i = 0; i < dati.length; i++) {
				let riga = dati[i];
				buffer += "<option value='" + riga["idsede"] + "'>" + riga["sede"] + "</option>";
			}
			this.selSedi.innerHTML = buffer;
			this.selSedi.value = dati[0]["idsede"];
			this.aggiornaTavoli();
		}.bind(this));
	}

	aggiornaTavoli() {
		this.chiamaServer("mod=tavoli&idsede=" + this.selSedi.value, function (dati) {
			let buffer = "";
			for (let i = 0; i < dati.length; i++) {
				let riga = dati[i];
				buffer += "<option value='" + riga["idtavolo"] + "'>" + riga["tavolo"] + "</option>";
			}
			this.selTavoli.innerHTML = buffer;
			this.selTavoli.value = dati[0]["idtavolo"];
			this.aggiornaTipi();
		}.bind(this));
	}

	aggiornaTipi() {
		this.chiamaServer("mod=tipi&idtavolo=" + this.selTavoli.value, function (dati) {
			let buffer = "";
			for (let i = 0; i < dati.length; i++) {
				let riga = dati[i];
				buffer += "<option value='" + riga["idtipo"] + "'>" + riga["tipo"] + "</option>";
			}
			this.selTipi.innerHTML = buffer;
			this.selTipi.value = dati[0]["idtipo"];
			this.aggiornaPiatti();
		}.bind(this));
	}

	aggiornaPiatti() {
		this.chiamaServer("mod=piatti&idtipo=" + this.selTipi.value + "&idtavolo=" + this.selTavoli.value, function (dati) {
			let buffer = "";
			for (let n in dati) {
				let piatto = dati[n];
				buffer += "<option value='" + piatto["idpiatto"] + "'>" + piatto["piatto"] + " €" + piatto["prezzo"] + "</option>";
			}
			this.selPiatti.innerHTML = buffer;
		}.bind(this));
	}

	click() {
		this.chiamaServer("mod=add" +
			"&idpiatto=" + this.selPiatti.value +
			"&idtavolo=" + this.selTavoli.value);
		this.refresh();
	}
}


window.addEventListener("load", function () {
	new tacciuinoElettronico("selTavolo", "selTipo", "selPiatto", "btnRegistra", "tblComande", "totPrezzo", "selSede");
});
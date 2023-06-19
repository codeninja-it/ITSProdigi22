<?php

	define("DBIP", "127.0.0.1");
    define("DBUSER", "enngzjko_wp9");
    define("DBPASS", "3[].X@n5uBS!5pua");
    define("DBDB", "enngzjko_wp9");
    
    function EseguiDB($sql){
        $dbcon = new mysqli(DBIP, DBUSER, DBPASS, DBDB);
		$dbrec = $dbcon->query($sql);
		if(is_object($dbrec)){
			$buffer = [];
			while($riga = $dbrec->fetch_assoc()){
				$buffer[] = $riga;
			}
			return $buffer;
		} else {
			return $dbrec;
		}
	}

	$buffer = array();
	switch($_GET["mod"]){
		case "list":
			$buffer = EseguiDB("SELECT rst_comande.idcomanda, rst_piatti.piatto, rst_comande.prezzo, rst_comande.fatto
								FROM rst_comande
								left join rst_piatti on rst_comande.idpiatto=rst_piatti.idpiatto ".
								(intval($_GET["id"]) > 0 
									? " WHERE rst_comande.idtavolo=".intval($_GET["id"]) 
									: "")
								);
		break;
		
		case "consegna": // ?mod=consegna&id=1
			EseguiDB("UPDATE rst_comande
						SET fatto = not fatto
						WHERE idcomanda=".intval($_GET["id"]));
		break;
		
		case "sedi": // ?mod=sedi
			$buffer = EseguiDB("SELECT idsede, sede
								FROM rst_sedi");
		break;
		
		case "tavoli": // ?mod=tavoli&idsede=1
			$buffer = EseguiDB("SELECT idtavolo, tavolo 
								FROM rst_tavoli
								WHERE idsede=".intval($_GET["idsede"]));
		break;
		
		case "tipi": //?mod=tipi&idtavolo=1
			$buffer = EseguiDB("SELECT rst_tipipiatti.idtipo, rst_tipipiatti.tipo
								FROM rst_tavoli
								LEFT JOIN rst_prezzi ON rst_tavoli.idsede=rst_prezzi.idsede
								LEFT JOIN rst_piatti ON rst_prezzi.idpiatto=rst_piatti.idpiatto
								LEFT JOIN rst_tipipiatti ON rst_piatti.idtipo=rst_tipipiatti.idtipo
								WHERE rst_tavoli.idtavolo=".intval($_GET["idtavolo"])."
								GROUP BY rst_tipipiatti.idtipo;");
		break;

		case "piatti": // ?mod=piatti&idtipo=1&idtavolo=1
			$buffer = EseguiDB("SELECT rst_piatti.idpiatto, rst_piatti.piatto, rst_prezzi.prezzo
								FROM rst_piatti
								left join rst_prezzi on rst_piatti.idpiatto=rst_prezzi.idpiatto
								left join rst_sedi on rst_prezzi.idsede=rst_sedi.idsede
								left join rst_tavoli on rst_sedi.idsede=rst_tavoli.idsede
								WHERE rst_piatti.idtipo=".intval($_GET["idtipo"])."
								and rst_tavoli.idtavolo=".intval($_GET["idtavolo"]));
		break;		
				
		case "add":
			EseguiDB("INSERT INTO rst_comande (idtavolo, idpiatto, registrazione, 
												fatto)
						VALUES (".intval($_GET["idtavolo"]).", 
						".intval($_GET["idpiatto"]).", NOW(), false)");
			EseguiDB("UPDATE rst_comande
						SET prezzo=(SELECT rst_piatti.prezzo
									FROM rst_piatti
									WHERE rst_piatti.idpiatto=rst_comande.idpiatto)
						WHERE prezzo is null");
		break;
	}
	
	echo json_encode($buffer, JSON_NUMERIC_CHECK);
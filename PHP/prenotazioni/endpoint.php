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
			$buffer = EseguiDB("SELECT rst_piatti.piatto, rst_piatti.prezzo, rst_comande.fatto
								FROM rst_comande
								left join rst_piatti on rst_comande.idpiatto=rst_piatti.idpiatto ".
								(intval($_GET["id"]) > 0 
									? " WHERE rst_comande.idtavolo=".intval($_GET["id"]) 
									: "")
								);
		break;
		
		case "piatti":
			$buffer = EseguiDB("SELECT idpiatto, piatto 
								FROM rst_piatti");
		break;
		
		case "tavoli":
			$buffer = EseguiDB("SELECT idtavolo, tavolo 
								FROM rst_tavoli");
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
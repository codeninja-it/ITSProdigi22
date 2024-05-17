<?php
	
	function creaInsert($dbcon, $target){
		$dati = $dbcon->query("describe ".$target);
		// INSERT INTO [target] ($campi) VALUES ($valori);
		$campi = [];
		$valori = [];
		while($colonna = $dati->fetch_assoc()){
			if($colonna["Extra"] != "auto_increment" && isset($_POST[ $colonna["Field"] ])){
				$campi[] = $colonna["Field"];
				if(is_numeric( $_POST[ $colonna["Field"] ] )){
					$valori[] = $_POST[ $colonna["Field"] ];
				} else {
					$valori[] = "'".addslashes($_POST[ $colonna["Field"] ])."'" ;
				}
			}
		}
		return "INSERT INTO ".$target.
				" (".implode(", ", $campi).") 
				VALUES (".implode(", ", $valori).")";
	}
	
	function creUpdate($dbcon, $target){
		$dati = $dbcon->query("describe ".$target);
		// UPDATE $target SET campo=valore, campo2=valore2 WHERE campo3=valore3 AND campo4=valore4;
		$campiSet = [];
		$campiWhere = [];
		while($campo = $dati->fetch_assoc()){
			if(is_numeric( $_POST[ $campo["Field"] ] )){
				$regola = $campo["Field"]." = ".$_POST[ $campo["Field"] ];
			} else {
				$regola = $campo["Field"]." = '".addslashes($_POST[ $campo["Field"] ])."' ";
			}
			
			if($campo["Key"] == "PRI"){
				// where
				$campiWhere[] = $regola;
			} else {
				// set
				$campiSet[] = $regola;
			}
		}
		return "UPDATE ".$target.
				" SET ".implode(", ", $campiSet).
				" WHERE ".implode(" AND ", $campiWhere);
	}


	// CRUD
	$controllo = "leggi";
	if(isset($_GET["azione"])){
		$controllo = $_GET["azione"];
	}
	
	$suChi = "sensori";
	if(isset($_GET["target"])){
		$suChi = $_GET["target"];
	}
	
	$telefono = new mysqli("127.0.0.1", "root", "", "iot");
	
	// endpoint.php?target=[sensori/luoghi/letture]&azione=[add/del/mod/view]&chi=1
	switch($controllo){
		case "add": // C - inserisco un elemento
		
		break;
		
		case "mod": // U -modifico una riga
		
		break;
		
		case "del": // D - cancello un sensore
			// ?azione=del&target=luoghi&pk=idluogo&chi=1
			$daCancellare = $_GET["chi"];
			$primaria = $_GET["pk"];
			$telefono->query("DELETE 
								FROM ".$suChi."
								WHERE ".$primaria."=".$daCancellare."
								LIMIT 1;");
		break;
		
		case "view": // R - visualizzo tutto
			$dati = $telefono->query("SELECT * FROM ".$suChi);
			$buffer = [];
			while( $riga = $dati->fetch_assoc() ){
				$buffer[] = $riga;
			}
			echo json_encode($buffer, JSON_NUMERIC_CHECK | JSON_PRETTY_PRINT);
		break;
		
		default: // blocco la richiesta
		break;
	}
	
	$telefono->close();
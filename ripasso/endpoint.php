<?php

	// endpoint.php
	$dbcon = new MySQLi("127.0.0.1", "root", "", "auto");
	
	$dati = $dbcon->query("SELECT * FROM ".$_GET["tabella"]);
	
	$buffer = [];
	
	while($riga = $dati->fetch_assoc()){
		foreach( $riga as $chiave => $valore ){
			$riga[$chiave] = utf8_decode($valore);
		}
		$buffer[] = $riga;
	}	
	
	// 00000100
	// 00010000
	// 00010100
	
	echo json_encode($buffer, JSON_PRETTY_PRINT | JSON_NUMERIC_CHECK);
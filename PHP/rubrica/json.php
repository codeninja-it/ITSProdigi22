<?php
    $cosa = $_GET["q"];
    $numero = $_GET["n"] > 0 ? $_GET["n"] : 100;
    // creo una coneessione verso mysql
    $connessione = new mysqli("127.0.0.1","enngzjko_wp9", "3[].X@n5uBS!5pua", "enngzjko_wp9");
    // se non c'è stato nessun errore
    if(!$connessione->connect_errorno){
        // eseguo una query SQL sulla macchina remota
        $risultato = $connessione->query("SELECT *
                                            FROM contatti
                                            LEFT JOIN tipi ON contatti.idtipo=tipi.idtipo
                                            WHERE nome LIKE '%".$cosa."%'
                                            LIMIT ".$numero."
                                        ");
        $buffer = array();
        while($riga = $risultato->fetch_assoc()){
            $buffer[] = $riga;
        }
        header("Content-Type: application/json");
        echo json_encode($buffer);
    } else {
        // avverto che la connessione non è andata a buon fine
        echo "connessione fallita...";
    }
    // chiudo la mia connessione liberando ram
    $connessione->close();
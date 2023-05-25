<?php
    echo empty($_POST) ? "niente in post" : "dati in post";

    // creo una coneessione verso mysql
    $connessione = new mysqli("127.0.0.1","enngzjko_wp9", "3[].X@n5uBS!5pua", "enngzjko_wp9");
    // se non c'è stato nessun errore
    if(!$connessione->connect_errorno){
        // eseguo una query SQL sulla macchina remota
        $risultato = $connessione->query("SELECT *
                                            FROM contatti
                                            LEFT JOIN tipi ON contatti.idtipo=tipi.idtipo
                                        ");
        // stampo quante righe ho trovato
        echo "<p>trovati <b>".$risultato->num_rows."</b> records</p>";
        echo "<ol>";
        while($riga = $risultato->fetch_assoc()){
            echo "<li>".$riga["tipo"]." ".$riga["nome"]." ".$riga["cognome"]." : ".$riga["telefono"]."</li>";
        }
        echo "</ol>";
    } else {
        // avverto che la connessione non è andata a buon fine
        echo "connessione fallita...";
    }
    // chiudo la mia connessione liberando ram
    $connessione->close();
    ?>
<form method="post">
    <input name="nome" placeholder="nome..." />
    <input name="cognome" placeholder="cognome..." />
    <input name="telefono" placeholder="telefono..." />
    <button>salva</button>
</form>
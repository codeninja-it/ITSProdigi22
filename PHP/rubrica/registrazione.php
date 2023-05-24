<html>
    <head>
        <title>Registrazione utente</title>
    </head>
    <body>
        <h1>Registrazione utente</h1>
        <?php
            if(empty($_POST)){
                if(empty($_GET["codice"])){
                    // gli mostro il form di registrazione
                    ?>
                        <form method="post">
                            <p>
                                <label for="email">Email</label>
                                <input id="email" name="email" />
                            </p>
                            <p>
                                <label for="pass">Password</label>
                                <input type="password" id="pass" name="pass" />
                            </p>
                            <button>registrati</button>
                        </form>
                    <?php
                } else {
                    // ho ricevuto un codice di verifica
                    $codice = $_GET["codice"];
                    // per cui valido gli utenti
                    $conn = new mysqli("127.0.0.1","enngzjko_wp9", "3[].X@n5uBS!5pua", "enngzjko_wp9");
                        $conn->query("UPDATE utenti 
                                        SET valido=true 
                                        WHERE MD5('attivazione' & pass) = '".$codice."';");
                        if($conn->affected_rows == 0){
                            echo "<p>Non ho davvero idea di chi tu sia...</p>";
                        } else {
                            echo "<p>Grazie della conferma!<br>Da adesso puoi entrare!</p>";
                        }
                    $conn->close();
                }
            } else {
                // salviamo i dati di registrazione dentro la banca dati
                $conn = new mysqli("127.0.0.1","enngzjko_wp9", "3[].X@n5uBS!5pua", "enngzjko_wp9");
                    $conn->query("INSERT INTO utenti (email, pass)
                                            VALUES ('".$_POST["email"]."', MD5('".$_POST["pass"]."'))");
                    // recupero e genero una chiave di verifica
                    $dati = $conn->query("SELECT MD5('attivazione' & pass) AS chiave 
                                            FROM utenti 
                                            WHERE email='".$_POST["email"]."' AND pass=MD5('".$_POST["pass"]."');");
                    $riga = $dati->fetch_assoc();
                    // gli spedisco una mail con il codice di controllo
                    mail($_POST["email"], 
                        "Conferma identità", 
                        "<p>Per confermare la tua identità <a href='".$_SERVER["SCRIPT_URI"]."?codice=".$riga["chiave"]."'>clicca qui</a>, arrivederci.</p>", 
                        "Content-type: text/html"
                    );
                // chiudo la connessione
                $conn->close();
                // gli mostro una thankyou page
                ?>
                    <p>Grazie per esserti registrato!<br>
                        Controlla la tua email per poter abilitare il tuo account.
                    </p>
                <?php
            }
        ?>
    </body>
</html>
<?php 
    session_start();
    if($_SESSION["utente"] == null){
        header("Location : login.php");
        $_SESSION["utente"] = null;
    }
?>
<html>
    <head>
        <title>Messaggi</title>
        <meta charset="UTF-8" />
        <link rel="stylesheet" href="asset/stile.css" />
    </head>
    <body>
        <h1>Messaggi</h1>
        <p>qui sotto tutti i messaggi, usa il form in pagina per poterne caricare altri!</p>
        
        <?php
            // se c'è del post lo carico in db
            $dbcon = new mysqli("127.0.0.1","enngzjko_wp9", "3[].X@n5uBS!5pua", "enngzjko_wp9");
            
                // CREATE
                if(!empty($_POST)){ 
                    $dbcon->query("INSERT INTO messaggi (messaggio, idutente) 
                                                VALUES ('".addslashes($_POST["messaggio"])."', ".$_SESSION["utente"]["idutente"].")");
                }
                
                // DELETE   $"{urlendpoint}?action=delete&id={idpost}"
                if($_GET["action"] == "delete"){
                    $dbcon->query("DELETE FROM messaggi WHERE idmessaggio=".intval($_GET["id"])." LIMIT 1");
                }
                
                
                // READ
                $dbrec = $dbcon->query("SELECT * FROM messaggi");
                echo "<ol>";
                while($riga = $dbrec->fetch_assoc()){
                    echo "<li>".$riga["messaggio"]." <a href='?action=delete&id=".$riga["idmessaggio"]."'>cancella</a></li>";
                }
                echo "</ol>";
               
            
            $dbcon->close();
        ?>
        
        <form method="post">
            <textarea name="messaggio"></textarea>
            <button>invia</button>
        </form>
    </body>
</html>
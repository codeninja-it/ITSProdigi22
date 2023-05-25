<?php
    session_start();
?>
<html>
    <head>
        <title>Login</title>
        <meta charset="UTF-8" />
        <link rel="stylesheet" href="asset/stile.css" />
    </head>
    <body>
        <h1>Login</h1>
        <?php
            if(empty($_POST)){
                ?>
                    <p>Usa il form qui sotto per poterti autenticare!</p>
                    <form method="post">
                        <p><input placeholder="email..." name="email" /></p>
                        <p><input placeholder="password..." type="password" name="pass" /></p>
                        <button>accedi</button>
                    </form>
                <?php
            } else {
                $dbcon = new mysqli("127.0.0.1","enngzjko_wp9", "3[].X@n5uBS!5pua", "enngzjko_wp9");
                    $dbrec = $dbcon->query("SELECT *
                                            FROM utenti
                                            WHERE email='".addslashes($_POST["email"])."'
                                            AND pass=MD5('".addslashes($_POST["pass"])."')
                                            AND valido=true
                                            LIMIT 1;");
                    if($dbrec->num_rows == 1){
                        echo "<p>Grazie per esserti registrato!</p>";
                        $_SESSION["utente"] = $dbrec->fetch_assoc();
                    } else {
                        echo "<p>Controlla i tuoi dati...</p>";
                    }                     
                $dbcon->close();
            }
        ?>
    </body>
</html>
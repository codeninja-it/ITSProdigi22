<?php
    session_start();
    define("DBIP", "127.0.0.1");
    define("DBUSER", "enngzjko_wp9");
    define("DBPASS", "3[].X@n5uBS!5pua");
    define("DBDB", "enngzjko_wp9");
    
    function EseguiDB($sql){
        $dbcon = new mysqli(DBIP, DBUSER, DBPASS, DBDB);
            $dati = $dbcon->query($sql);
        $dbcon->close();
        return $dati;
    }
    
    $buffer = array();
    $buffer["status"] = 200;
    $buffer["data"] = $_POST;
    
    
    switch($_GET["mod"]){
        
        case "ticket":
            if(!empty($_SESSION["utente"])){
                $dati = EseguiDB("SELECT * FROM tkt_tickets where idticket > ".intval($_GET["ultimo"]));
                $buffer["data"] = [];
                while($riga = $dati->fetch_assoc()){
                    $buffer["data"][] = $riga;
                }
            } else {
                $buffer["status"] = 403;
                $buffer["data"] = "Accesso non consentito";
            }
            break;
        
        case "login": // $_POST["email"], $_POST["pass"]
            if(!empty($_POST)){
                $dati = EseguiDB("SELECT * 
                                    FROM tkt_utenti 
                                    WHERE email='".addslashes($_POST["email"])."'
                                    AND pass=MD5('".addslashes($_POST["pass"])."')
                                    LIMIT 1;");
                if($riga = $dati->fetch_assoc()){
                    $_SESSION["utente"] = $riga;
                    $buffer["status"] = 200;
                    $buffer["data"] = $riga;
                } else {
                    $buffer["status"] = 403;
                    $buffer["data"] = "nome utente o password errati";
                }
            }
            break;
        
        default:
            $buffer["status"] = 403;
            break;
    }
    
    echo json_encode($buffer);
<?php
    include("config.php");
    
    switch($_GET["act"]){
        case "register":
            
            break;
        default:
            if(empty($_POST)){
                include("templates/login.htm");
            } else {
                $dbcon = new mysqli($dbip, $dbuser, $dbpass, $dbdb);
                $dati = $dbcon->query("SELECT * 
                                        FROM tkt_utenti
                                        WHERE email='".addslashes($_POST["email"])."'
                                        AND pass = MD5('".addslashes($_POST["pass"])."')
                                        AND valido=1
                                        LIMIT 1;");
                if($dati->num_rows > 0){
                    //include("templates/login_ok.htm");
                    header("location: categorie.php");
                } else {
                    include("templates/login_no.htm");
                }
                $dbcon->close();
            }
            break;
    }
    
    
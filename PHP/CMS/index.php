<?php
    session_start();
    include("config.php");
    // index.php?mod=ticket&act=del&id=3&out=json
    //                      &act=mod
    //                      &act=new
    //                      &act=lst
    // index.php?mod=ticket&q=pc
    
    $modulo = $_GET["mod"];
    if(file_exists("moduli/".$modulo.".php")){
        // se non c'è sessione
        if(empty($_SESSION["utente"])){
            // rigira alla login
            header("location: index.php");
        }
        include("moduli/".$modulo.".php");
    } else {
        if(empty($_POST)){
            // gli mostriamo un form
            $buffer = form(
                        input("email", "email", "").
                        input("pass", "pass", "", "password"),
                        false, "login"
                        );
        } else {
            // controlliamo se esiste l'utente
            $dati = EseguiDB("SELECT * 
                                FROM tkt_utenti
                                WHERE email='".addslashes($_POST["email"])."'
                                AND pass = MD5('".addslashes($_POST["pass"])."')
                                AND valido=1
                                LIMIT 1;");
            if($dati->num_rows){
                $_SESSION["utente"] = $dati->fetch_assoc();
                header("location: ?mod=tickets");
            }
            // conferma e registrazione in session dei suoi dati
            $buffer = "<p class='alert alert-danger'>errore di login</p>";
        }
        echo template("templates/standard.htm", "CMS", $buffer);
    }
<?php
    include("config.php");
    $singolare = $_GET["s"]; //"stato";
    $plurale = $_GET["p"];  //"statiticket";
    // lut.php?act=del&id=3&p=statiticket&s=stato
    // lut.php?act=new&p=tipiutente&tipo
    // lut.php?p=categorie&s=categoria
    
    switch($_GET["act"]){
        case "new": // ?act=new
            if(empty($_POST)){
                include("templates/".$plurale."_new.htm");
            } else {
                $dbcon = new mysqli($dbip, $dbuser, $dbpass, $dbdb);
                    $dbcon->query("INSERT INTO tkt_".$plurale." (".$singolare.")
                                    VALUES ('".addslashes($_POST["nome"])."')");
                    if($dbcon->affected_rows == 1){
                        header("location: ".$plurale.".php");
                    } else {
                        include("templates/".$plurale."_no.htm");
                    }
                $dbcon->close();
            }
            break;
        
        case "del": // ?act=del&id=12
            $dbcon = new mysqli($dbip, $dbuser, $dbpass, $dbdb);
                $dbcon->query("DELETE FROM tkt_".$plurale." 
                                WHERE id".$singolare."=".intval($_GET["id"])." LIMIT 1;");
                header("location: statiticket.php");
            $dbcon->close();
            break;
        
        default:
            $dbcon = new mysqli($dbip, $dbuser, $dbpass, $dbdb);
                $dati = $dbcon->query("SELECT id".$singolare.", ".$singolare."
                                        FROM tkt_".$plurale);
                $buffer = "";
                while($riga = $dati->fetch_assoc()){
                    $buffer .= "<tr>
                                    <td>".$riga["id".$singolare]."</td>
                                    <td>".$riga[$singolare]."</td>
                                    <td><a href='?act=del&id=".$riga["id".$singolare]."'>-</a></td>
                                </tr>";
                }
            $dbcon->close();
            $pagina = file_get_contents("templates/".$singolare.".htm");
            $pagina = str_replace("<corpo_tabella/>", $buffer, $pagina);
            echo $pagina;
            break;
    }
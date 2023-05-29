<?php
    include("config.php");
    switch($_GET["act"]){
        case "new": // ?act=new
            if(empty($_POST)){
                include("templates/categorie_new.htm");
            } else {
                $dbcon = new mysqli($dbip, $dbuser, $dbpass, $dbdb);
                    $dbcon->query("INSERT INTO tkt_categorie (categoria)
                                    VALUES ('".addslashes($_POST["nome"])."')");
                    if($dbcon->affected_rows == 1){
                        header("location: categorie.php");
                    } else {
                        include("templates/categorie_no.htm");
                    }
                $dbcon->close();
            }
            break;
        
        case "del": // ?act=del&id=12
            $dbcon = new mysqli($dbip, $dbuser, $dbpass, $dbdb);
                $dbcon->query("DELETE FROM tkt_categorie 
                                WHERE idcategoria=".intval($_GET["id"])." LIMIT 1;");
                header("location: categorie.php");
            $dbcon->close();
            break;
        
        default:
            $dbcon = new mysqli($dbip, $dbuser, $dbpass, $dbdb);
                $dati = $dbcon->query("SELECT idcategoria, categoria
                                        FROM tkt_categorie");
                $buffer = "";
                while($riga = $dati->fetch_assoc()){
                    $buffer .= "<tr>
                                    <td>".$riga["idcategoria"]."</td>
                                    <td>".$riga["categoria"]."</td>
                                    <td><a href='?act=del&id=".$riga["idcategoria"]."'>-</a></td>
                                </tr>";
                }
            $dbcon->close();
            $pagina = file_get_contents("templates/categorie.htm");
            $pagina = str_replace("<corpo_tabella/>", $buffer, $pagina);
            echo $pagina;
            break;
    }
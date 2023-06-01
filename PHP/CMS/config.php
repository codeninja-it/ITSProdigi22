<?php
    define("DBIP", "127.0.0.1");
    define("DBUSER", "enngzjko_wp9");
    define("DBPASS", "3[].X@n5uBS!5pua");
    define("DBDB", "enngzjko_wp9");
    
    $links = array();
        $links[] = "https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css";
    $scripts = array();
        $scripts[] = "https://cdn.jsdelivr.net/npm/jquery@3.6.4/dist/jquery.slim.min.js";
        $scripts[] = "https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/js/bootstrap.bundle.min.js";
        
        
    function EseguiDB($sql){
        $dbcon = new mysqli(DBIP, DBUSER, DBPASS, DBDB);
            $dati = $dbcon->query($sql);
        $dbcon->close();
        return $dati;
    }
        
    function menu(){
        $moduli = scandir("moduli");
        $buffer = "<div class='btn-group-vertical'>";
        foreach($moduli as $singolo){
            if(strpos($singolo, ".php") != false){
                $nome = str_replace(".php", "", $singolo);
                $buffer .= "<a href='?mod=".$nome."' class='btn btn-".($_GET["mod"]==$nome ? "primary" : "secondary")."'>".$nome."</a>";
            }
        }
        $buffer .= "</div>";
        return $buffer;
    }
        
    function template($urlTemplate, $titolo, $corpo){
        $buffer = "";
        foreach($GLOBALS["links"] as $link){
            $buffer .= "<link rel='stylesheet' href='".$link."'>";
        }
        
        foreach($GLOBALS["scripts"] as $script){
            $buffer .= "<script src='".$script."'></script>";
        }
        $template = file_get_contents($urlTemplate);
        $pagina = str_replace("<intestazioni/>", $buffer, $template);
        $pagina = str_replace("<titolo/>", $titolo, $pagina);
        $pagina = str_replace("<corpo/>", $corpo, $pagina);
        $pagina = str_replace("<menu/>", menu(), $pagina);
        return $pagina;
    }
    
    // <% echo lista("idcategoria", "idcategoria", "categoria", "tkt_categorie"); %>
    function lista($id, $chiave, $descrizione, $tabella){
        $buffer = "<p class='form-group'><label for='".$id."'>".$descrizione."</label><br><select id='".$id."' name='".$id."' class='form-control'>";
        $con = new mysqli(DBIP, DBUSER, DBPASS, DBDB);
            $dati = $con->query("SELECT ".$chiave.", ".$descrizione."
                                FROM ".$tabella."
                                ORDER BY ".$descrizione.";");
            while($riga = $dati->fetch_assoc()){
                $buffer .= "<option value='".$riga[$chiave]."'>".$riga[$descrizione]."</option>";
            }
            $buffer .= "</select></p>";
        $con->close();
        return $buffer;
    }
    
    function input($id, $descrizione, $valore = "", $type = "text"){
        return "<p class='form-group'>
                    <label for='".$id."'>".$descrizione."</label><br>
                    <input type='".$type."' id='".$id."' name='".$id."' value='".addslashes($valore)."' class='form-control'>
                </p>";
    }
    
    function textarea($id, $descrizione, $valore = ""){
        return "<p class='form-group'>
                    <label for='".$id."'>".$descrizione."</label><br>
                    <textarea class='form-control' id='".$id."' name='".$id."'>".addslashes($valore)."</textarea>
                </p>";
    }
    
    function form($corpo, $get = false, $label = "invia"){
        return "<form method='".($get ? "GET" : "POST")."'>
                    ".$corpo."
                    <button class='btn btn-primary'>".$label."</button> 
                    <button class='btn btn-secondary' type='reset'>annulla</button>
                </form>";
    }
    
    function tabella($sql, $pk){
        $dati = EseguiDB($sql);
        $buffer = "<table class='table table-hover'>";
        $primaRiga = true;
        while($riga = $dati->fetch_assoc()){
            if($primaRiga){
                $buffer .= "<tr>";
                foreach($riga as $chiave => $valore){
                    if($chiave != $pk)
                        $buffer .= "<th>".$chiave."</th>";
                }
                $buffer .= "<th><a class='btn btn-success' href='?mod=".$_GET["mod"]."&act=new'>new</a></th></tr>";
            }
            $buffer .= "<tr>";
                foreach($riga as $chiave => $campo){
                    if($chiave != $pk)
                        $buffer .= "<td>".$campo."</td>";
                }
                $buffer .= "<td><a class='btn btn-danger' href='?mod=".$_GET["mod"]."&act=del&id=".$riga[$pk]."'>cancella</a></td>";
            $buffer .= "</tr>";
            $primaRiga = false;
        }
        $buffer .= "</table>";
        return $buffer;
    }
    
    function EsportaJSON($sql){
        $dati = EseguiDB($sql);
        $buffer = array();
        while($riga = $dati->fetch_assoc()){
            $buffer[] = $riga;
        }
        return json_encode($buffer);
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
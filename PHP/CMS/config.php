<?php
    $dbip = "127.0.0.1";
    $dbuser = "enngzjko_wp9";
    $dbpass = "3[].X@n5uBS!5pua";
    $dbdb = "enngzjko_wp9";
    
    $links = array();
        $links[] = "asset/stile.css";
        $links[] = "https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css";
    $scripts = array();
        $scripts[] = "https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.min.js";
        $scripts[] = "asset/miocodice.js";
        
        
    function template($urlTemplate, $titolo, $corpo){
        $buffer = "";
        foreach($links as $link){
            $buffer .= "<link rel='stylesheet' href='".$link."'>";
        }
        
        foreach($scripts as $script){
            $buffer .= "<script src='".$script."'></script>";
        }
        $template = file_get_contents($urlTemplate);
        $pagina = str_replace("<intestazioni/>", $buffer, $template);
        $pagina = str_replace("<titolo/>", $titolo, $pagina);
        $pagina = str_replace("<corpo/>", $corpo, $pagina);
        return $pagina;
    }
    
    // <% echo lista("idcategoria", "idcategoria", "categoria", "tkt_categorie"); %>
    function lista($id, $chiave, $descrizione, $tabella){
        $buffer = "<select id='".$id."' name='".$id."'>";
        $con = new mysqli($dbip, $dbuser, $dbpass, $dbdb);
            $dati = $con->query("SELECT ".$chiave.", ".$descrizione."
                                FROM ".$tabella.";");
            while($riga = $dati->fetch_assoc()){
                $buffer .= "<option value='".$riga[$chiave]."'>".$riga[$descrizione]."</option>";
            }
            $buffer .= "</select>";
        $con->close();
        return $buffer;
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
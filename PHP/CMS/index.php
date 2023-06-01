<?php
    include("config.php");
    // index.php?mod=ticket&act=del&id=3&out=json
    //                      &act=mod
    //                      &act=new
    //                      &act=lst
    // index.php?mod=ticket&q=pc
    
    $modulo = $_GET["mod"];
    if(file_exists("moduli/".$modulo.".php")){
        include("moduli/".$modulo.".php");
    } else {
        echo template("templates/standard.htm", "CMS", $buffer);
    }
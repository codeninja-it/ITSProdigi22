<?php
    $indice = "<ul>";
    for($i = 0; $i < 10; $i++){
        $indice .= "<li><a href='numerazione_".$i.".php'>numero ".$i."</a></li>";
        $pagina = "<?php echo 'stampo il numero ".$i."';";
        file_put_contents("numerazione_".$i.".php", $pagina);
    }
    file_put_contents("numeri.php", $indice."</ul>");
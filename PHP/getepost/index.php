<?php
    function stampa($variabile){
        $variabile = json_encode($variabile, JSON_PRETTY_PRINT);
        $variabile = str_replace("\t", "&nbsp;&nbsp;&nbsp;", $variabile);
        return nl2br($variabile);
    }
?>
<html>
    <head>
        <title>Get & Post</title>
        <meta charset="UTF-8"/>
        <style>
            body {
                background-color: #eeeeee;
            }
            
            h1 {
                background-color: orange;
                color: rgb(255, 255, 255);
                border-radius: .5em;
            }
            
            p {
                background-color: white;
                border-radius: .5em;
                margin: 1em;
                padding: 1em;
            }
            
            input {
                width: calc(100% - 1em);
                border: 1px solid orange;
                border-radius: .2em;
                box-shadow: 5px 5px 5px #00000077;
                padding: .2em;
                margin: .2em;
            }
        </style>
    </head>
    <body>
        <h1>Get & Post</h1>
        <h2>Get</h2>
        <p>
           <?php
                echo stampa($_GET);
           ?>
        </p>
        <h2>Post</h2>
        <p>
           <?php
                echo stampa($_POST);
           ?>
        </p>
        <h2>SERVER</h2>
        <p>
            <?php
                echo stampa($_SERVER);
            ?>
        </p>
        <form method="post">
            <p>
                <label for="mess">Messaggio</label>
                <input id="mess" name="mess" />
            </p>
            <button>invia</button>
        </form>
    </body>
</html>
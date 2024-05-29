<?php // CRUD

	include("config.php");

	if(empty($_GET["azione"])){ // R-ead
		$dati = $dbcon->query("SELECT *
								FROM utenti");
		echo "<a href='?azione=inserisci'>nuovo</a>";
		echo "<table>";
		while( $riga = $dati->fetch_assoc() ){
			?>
				<tr>
					<td><?php echo $riga["idutente"]; ?></td>
					<td><?php echo $riga["nome"]; ?></td>
					<td><?php echo $riga["cognome"]; ?></td>
					<td>
						<a href='?azione=modifica&id=<?php echo $riga["idutente"]; ?>'>modifica</a>
					</td>
					<td>
						<a href='?azione=cancella&id=<?php echo $riga["idutente"]; ?>'>cancella</a>
					</td>
				</tr>
			<?php
		}
		echo "</table>";
	} else {
		switch($_GET["azione"]){
			case "cancella": // D-elete
				$dbcon->query("DELETE
								FROM utenti 
								WHERE idutente=".$_GET["id"]);
			break;
			
			case "modifica":
				if(!empty($_POST)){
					$dbcon->query("UPDATE utenti 
									SET nome = '".$_POST["nome"]."',
									cognome = '".$_POST["cognome"]."'
									WHERE idutente=".$_GET["id"].";");
				}
				$dati = $dbcon->query("SELECT *
										FROM utenti
										WHERE idutente=".$_GET["id"]);
				if($riga = $dati->fetch_assoc()){
					?>
						<form method="POST">
							<input name='nome' value="<?php echo $riga["nome"]; ?>">
							<input name='cognome' value="<?php echo $riga["cognome"]; ?>">
							<button type="submit">invia</button>
						</form>
					<?php
				}
			break;
			
			case "inserisci": // C-reate
				if(!empty($_POST)){
					$dbcon->query("INSERT INTO utenti (nome, cognome) 
									VALUES ('".$_POST["nome"]."', '".$_POST["cognome"]."');");
				}
				?>
					<form method="POST">
						<input name='nome'>
						<input name='cognome'>
						<button type="submit">invia</button>
					</form>
				<?php
			break;
		}
	}
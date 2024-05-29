<?php // CRUD

	include("config.php");

	if(empty($_GET["azione"])){ // R-ead
		$dati = $dbcon->query("SELECT *
								FROM tipi");
		echo "<a href='?azione=inserisci'>nuovo</a>";
		echo "<table>";
		while( $riga = $dati->fetch_assoc() ){
			?>
				<tr>
					<td><?php echo $riga["idtipo"]; ?></td>
					<td><?php echo $riga["tipo"]; ?></td>
					<td>
						<a href='?azione=modifica&id=<?php echo $riga["idtipo"]; ?>'>modifica</a>
					</td>
					<td>
						<a href='?azione=cancella&id=<?php echo $riga["idtipo"]; ?>'>cancella</a>
					</td>
				</tr>
			<?php
		}
		echo "</table>";
	} else {
		switch($_GET["azione"]){
			case "cancella": // D-elete
				$dbcon->query("DELETE
								FROM tipi 
								WHERE idtipo=".$_GET["id"]);
			break;
			
			case "modifica":
				if(!empty($_POST)){
					$dbcon->query("UPDATE tipi 
									SET tipo = '".$_POST["tipo"]."'
									WHERE idtipo=".$_GET["id"].";");
				}
				$dati = $dbcon->query("SELECT *
										FROM tipi
										WHERE idtipo=".$_GET["id"]);
				if($riga = $dati->fetch_assoc()){
					?>
						<form method="POST">
							<input name='tipo' value="<?php echo $riga["tipo"]; ?>">
							<button type="submit">invia</button>
						</form>
					<?php
				}
			break;
			
			case "inserisci": // C-reate
				if(!empty($_POST)){
					$dbcon->query("INSERT INTO tipi (tipo) 
									VALUES ('".$_POST["tipo"]."');");
				}
				?>
					<form method="POST">
						<input name='tipo'>
						<button type="submit">invia</button>
					</form>
				<?php
			break;
		}
	}
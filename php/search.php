<?php

#echo "text";
require('connect.php');

if(isset($_POST['completedsearch']))
{
	$term = $_POST['query'];

	mysql_select_db("CompareTest");

	$qu = mysql_query("SELECT * FROM keywords WHERE keyword LIKE '%{$term}%' "); //selects the row that contains ANYTHING like the submitted strin


	echo "Results found: ".mysql_num_rows($qu);


	while($row = mysql_fetch_array($qu))
	{
		echo "<html>";
		echo "<table>";
		echo "<tr>";
		echo "<td>";
		echo $row['keyword'];
		echo "</td>";
		echo "</tr>";
		echo "</table>";
		echo "</html>";
	}
}
?>

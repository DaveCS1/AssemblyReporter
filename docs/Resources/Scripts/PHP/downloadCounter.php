<!DOCTYPE html>
<html lang="en">
<head>
<meta http-equiv="Content-Type" content="text/html;charset=utf-8" >
<?php

// The log file must be in a subdirectory. The subdirectory might need 777 permissions.

$LocationOfLogFile = "/logs/filename.txt";

// Specify the URL of the downloadable file.

$URLofDownloadableFile = "/file.zip";

$LocationOfLogFile = $_SERVER['DOCUMENT_ROOT'].$LocationOfLogFile;
$filehandle = fopen($LocationOfLogFile,'a');
if($filehandle)
{
   $line = date('r')."\t".$_SERVER['REMOTE_ADDR']."\t$URLofDownloadableFile\t".$_SERVER['HTTP_USER_AGENT']."\n";
   fwrite($filehandle,$line);
}
fclose($filehandle);
?>
<meta http-equiv="refresh" content="0; url=<?php echo($URLofDownloadableFile) ?>">
<script type="text/javascript"><!--
window.location = "<?php echo($URLofDownloadableFile) ?>";
//-->
</script>
</head>
<body>
<p> If download does not start presently, <a href="<?php echo($URLofDownloadableFile) ?>"> click here. </a> </p>
</div>
</body>
</html>

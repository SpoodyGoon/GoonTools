<?php
/*************************************************************************
 *                      GetUpdateInfo.php
 *
 *  Copyright (C) 2009 Andrew York <goontools@brdstudio.net>
 *
 *************************************************************************/
/*
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>
 */


/************************* Global Variables ********************************/

#region Input Variables

// the file version that the calling GUPdotNET is using
$XMLFileVersion = 1.0
   	
// the operating system for the update 
// expected values (Windows, Linux, Mac)
$OS = '';
// the type of install for the update
// expected values (Installer,RPM, DEB, BIN, TGZ, SRC)  
$InstallType = '';

#endregion Input Variables

#region Feedback Variables

// Major version of the update program
$UpdateMajorVersion = 0;
// Minor version of the update program
$UpdateMinorVersion = 2;
// friendly version string format
$LatestVersion = '0.2';
// http URL of the new program
$UpdateFileURL = '';
// http URL of the update details if any
// this is intended for the change log put it could change
// for starting it will be just a text file.
$UpdateDetailsURL = '';
// for any error that may happen
$UpdateError = '';
// the type of CheckSum that is used 
// expected values (MD5, SHA1, SHA256, SHA384, SHA512)
$CheckSumType = ''
// the CheckSum
$CheckSum = ''

#endregion Feedback Variables

#region Validate Input 

  if(!$_GET['OS']) 
  {
      $UpdateError .= "Missing OS - Invalid Request\n";
  }
  
  if(!$_GET['InstallType'])
  { 
      $UpdateError .= "Missing Install Type - Invalid Request\n";
  }
  
#endregion Validate Input 

  switch($_GET['OS'])
  {
      case 'Windows':
	    $UpdateFileURL = 'http://www.brdstudio.net/gupdotnet/gupdotnet.7z';
	    $UpdateDetailsURL = 'http://www.brdstudio.net/gupdotnet/testchangelog.txt';
		$CheckSumType = 'MD5';
		$CheckSum = '69C559942301ACB9CE87C2A39DAFCCE0';
	  break;
      case 'Linux':
	    $UpdateFileURL = '';
	    $UpdateDetailsURL = '';
	    $UpdateError .= "Sorry Linux is not currently supported\n";
		$CheckSumType = 'MD5';
		$CheckSum = '69C559942301ACB9CE87C2A39DAFCCE0';
	  break;
      case 'Mac':
	    $UpdateFileURL = '';
	    $UpdateDetailsURL = '';
	    $UpdateError .= "Sorry Mac is not currently supported\n";
		$CheckSumType = 'MD5';
		$CheckSum = '69C559942301ACB9CE87C2A39DAFCCE0';
	  break;
      case 'BSD':
	    $UpdateFileURL = '';
	    $UpdateDetailsURL = '';
	    $UpdateError .= "Sorry BSD is not currently supported\n";
		$CheckSumType = 'MD5';
		$CheckSum = '69C559942301ACB9CE87C2A39DAFCCE0';
	  break;
      default:
	  $UpdateError .= "Should not get here\n";
	  break;

  }
  

print "<?xml version=\"1.0\"?>";
print "<GUPdotNET>";
print "<XMLFileVersion>$XMLFileVersion</XMLFileVersion>")
print "<UpdateMajorVersion>$UpdateMajorVersion</UpdateMajorVersion>";
print "<UpdateMinorVersion>$UpdateMinorVersion</UpdateMinorVersion>";
print "<LatestVersion>$LatestVersion</LatestVersion>";
print "<UpdateFileURL>$UpdateFileURL</UpdateFileURL>";
print "<CheckSumType>$CheckSumType</CheckSumType>";
print "<CheckSum>$CheckSum</CheckSum>";
print "<UpdateDetailsURL>$UpdateDetailsURL</UpdateDetailsURL>";
print "<Error>$UpdateError</Error>";
print "</GUPdotNET>";

?>

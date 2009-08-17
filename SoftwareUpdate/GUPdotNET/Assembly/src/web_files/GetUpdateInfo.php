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
    	
// the operating system for the update 
// expected values (Windows, Linux, Mac, BSD)
$OS = "";
// the type of install for the update
// expected values (Installer,RPM, DEB, BIN, TGZ, SRC)  
$InstallType = "";

#endregion Input Variables

#region Feedback Variables

// Major version of the update program
$UpdateMajorVersion = 0;
// Minor version of the update program
$UpdateMinorVersion = 2;
// friendly version string format
$LatestVersion = "0.2";
// http URL of the new program
$UpdateFileURL = "";
// http URL of the update details if any
// this is intended for the change log put it could change
// for starting it will be just a text file.
$UpdateDetailsURL = "";
// for any error that may happen
$Error = "";


  if(!$_GET['OS']) 
  {
      $Error .= "Missing OS - Invalid Request\n";
  }
  
  if(!$_GET['InstallType'])
  { 
      $Error .= "Missing Install Type - Invalid Request\n";
  }

  switch($_GET['OS'])
  {
      case "Windows":
	    $UpdateFileURL = "http://www.brdstudio.net/gupdotnet/gupdotnet.7z";
	    $UpdateDetailsURL = "http://www.brdstudio.net/gupdotnet/testchangelog.txt";
	  break;
      case "Linux":
	    $UpdateFileURL = "";
	    $UpdateDetailsURL = "";
	    $Error .= "Sorry Linux is not currently supported";
	  break;
      case "Mac":
	    $UpdateFileURL = "";
	    $UpdateDetailsURL = "";
	    $Error .= "Sorry Mac is not currently supported";
	  break;
      case "BSD":
	    $UpdateFileURL = "";
	    $UpdateDetailsURL = "";
	    $Error .= "Sorry BSD is not currently supported";
	  break;
      default:
	  $Error .= "Should not get here";
	  break;

  }
  

print "<?xml version=\"1.0\"?>";
print "<GUPdotNET>";
print "<UpdateMajorVersion>$UpdateMajorVersion</UpdateMajorVersion>";
print "<UpdateMinorVersion>$UpdateMinorVersion</UpdateMinorVersion>";
print "<LatestVersion>$LatestVersion</LatestVersion>";
print "<UpdateFileURL>$UpdateFileURL</UpdateFileURL>";
print "<UpdateDetailsURL>$UpdateDetailsURL</UpdateDetailsURL>";
print "<Error>$Error</Error>";
print "</GUPdotNET>";

?>

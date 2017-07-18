function Test-UserPasswordExpires
{
param(
     $UserName = $env:username,
     $Domain = $env:userdomain
   )
  $x=(Get-WmiObject -Class Win32_UserAccount -Filter "Name='$UserName' and Domain='$Domain'")
  $x.PasswordExpires
}
Get-WmiObject -Class Win32_UserAccount -Filter "Name='$env:username' and Domain='$env:userdomain'"
Get-WmiObject -Class Win32_UserAccount -Filter "Name='$env:username' and Domain='$env:userdomain'" | Select-Object *

$env:username
$env:userdomain
$env:USERPROFILE
$env:COMPUTERNAME
$env:JAVA_HOME
$env:PUBLIC
Test-UserPasswordExpires 